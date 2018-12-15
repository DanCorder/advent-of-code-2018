namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day15
    {
        private const string ProblemInput = @"################################
##########G###.#################
##########..G#G.G###############
##########G......#########...###
##########...##.##########...###
##########...##.#########G..####
###########G....######....######
#############...............####
#############...G..G.......#####
#############.............######
############.............E######
######....G..G.........E....####
####..G..G....#####.E.G.....####
#####...G...G#######........####
#####.......#########........###
####G.......#########.......####
####...#....#########.#.....####
####.#..#...#########E#..E#..###
####........#########..E.#######
###......#..G#######....########
###.......G...#####.....########
##........#............#########
#...##.....G......E....#########
#.#.###..#.....E.......###.#####
#######................###.#####
##########.......E.....###.#####
###########...##........#...####
###########..#####.............#
############..#####.....#......#
##########...######...........##
#########....######..E#....#####
################################";
        private const string ProblemTestInput = @"#######
#.G...#
#...EG#
#.#.#G#
#..G#E#
#.....#
#######";

        private const string ProblemTest2Input = @"#######
#G..#E#
#E#E.E#
#G.##.#
#...#E#
#...E.#
#######";

        private const string ProblemTest3Input = @"#######
#E..EG#
#.#G.E#
#E.##E#
#G..#.#
#..E#.#
#######";

        private const string ProblemTest6Input = @"#########
#G......#
#.E.#...#
#..##..G#
#...##..#
#...#...#
#.G...G.#
#.....G.#
#########";


        private class Creature
        {
            public int ID;
            public bool IsElf;
            public int HP = 200;
            public int X;
            public int Y;

            public int AttackPower = 3;
        }

        public static int SolveProblem1()
        {
            var lines = ProblemInput.SplitToLines().ToList();
            var map = new char[lines[0].Length, lines.Count];
            var creatures = new List<Creature>();
            var creatureId = 0;
            for (var y = 0; y < lines.Count; y++)
            {
                for (var x = 0; x < lines[0].Length; x++)
                {
                    var charAtPos = lines[y][x];
                    if (charAtPos == 'E')
                    {
                        var elf = new Creature() { IsElf = true, X = x, Y = y, ID = creatureId };
                        creatures.Add(elf);
                        map[x,y] = '.';
                        creatureId++;
                    }
                    else if (charAtPos == 'G')
                    {
                        var goblin = new Creature() { IsElf = false, X = x, Y = y, ID = creatureId };
                        creatures.Add(goblin);
                        map[x,y] = '.';
                        creatureId++;
                    }
                    else
                    {
                        map[x,y] = charAtPos;
                    }
                }
            }

            var completedRounds = 0;
            var endCombat = false;
            while (true)
            {
                // Console.WriteLine("Completed rounds: " + completedRounds);
                // PrintMap(map, creatures);

                var creaturesInTurnOrder = creatures.OrderBy(c => c.Y).ThenBy(c => c.X);
                foreach (var creature in creaturesInTurnOrder)
                {
                    if (creature.HP <= 0)
                        continue;

                    if (creatures.All(c => c.IsElf == creature.IsElf))
                    {
                        endCombat = true;
                        break;
                    }

                    var rangesFromCreature = GetRanges(creature, map, creatures);
                    var targetPosition = FindClosestReachableTargetPosition(creature, map, creatures, rangesFromCreature);
                    if (targetPosition != null && (targetPosition.Item1 != creature.X || targetPosition.Item2 != creature.Y))
                    {
                        var nextPosition = FindNextPosition(targetPosition, creature, map, creatures);
                        if (nextPosition != null)
                        {
                            creature.X = nextPosition.Item1;
                            creature.Y = nextPosition.Item2;
                        }
                    }
                    TryAttack(creature, creatures);
                }

                if (endCombat)
                {
                    break;
                }

                completedRounds++;
            }

            // 230867 too high
            PrintMap(map, creatures);
            Console.WriteLine("Rounds: " + completedRounds);
            Console.WriteLine("Remaining health: " + creatures.Sum(c => c.HP));
            return completedRounds * creatures.Sum(c => c.HP);
        }

        private static void PrintMap(char[,] map, List<Creature> creatures)
        {
            for (var y = 0; y < map.GetLength(1); y++)
            {
                var creaturesOnRow = new List<Creature>();
                for (var x = 0; x < map.GetLength(0); x++)
                {
                    var creature = creatures.SingleOrDefault(c => c.X == x && c.Y == y);
                    if (creature != null)
                    {
                        creaturesOnRow.Add(creature);
                        Console.Write(creature.IsElf ? 'E' : 'G');
                    }
                    else
                    {
                        Console.Write(map[x,y]);
                    }
                }
                foreach(var creature in creaturesOnRow)
                {
                    Console.Write(" " + (creature.IsElf ? 'E' : 'G') + '(' + creature.HP + ')');
                }
                Console.WriteLine();
            }
        }

        private static int[,] GetRanges(Creature creature, char[,] map, List<Creature> creatures)
        {
            var ranges = new int[map.GetLength(0), map.GetLength(1)];
            for (var x = 0; x < map.GetLength(0); x++)
            {
                for (var y = 0; y < map.GetLength(0); y++)
                {
                    ranges[x,y] = int.MaxValue;
                }
            }

            FillRanges(creature.X, creature.Y, ranges, 0, map, creatures);

            return ranges;
        }

        private static void FillRanges(int X, int Y, int[,] ranges, int currentRange, char[,] map, List<Creature> creatures)
        {
            if (ranges[X, Y] <= currentRange)
                return;

            ranges[X, Y] = currentRange;
            var nextPositions = new Tuple<int, int>[4] {
                new Tuple<int, int>(X-1, Y),
                new Tuple<int, int>(X+1, Y),
                new Tuple<int, int>(X, Y-1),
                new Tuple<int, int>(X, Y+1)};

            foreach(var nextPosition in nextPositions)
            {
                if (nextPosition.Item1 >= 0 &&
                    nextPosition.Item1 < map.GetLength(0) &&
                    nextPosition.Item2 >= 0 &&
                    nextPosition.Item2 < map.GetLength(1) &&
                    map[nextPosition.Item1, nextPosition.Item2] != '#' &&
                    !creatures.Any(c => c.X == nextPosition.Item1 && c.Y == nextPosition.Item2))
                {
                    FillRanges(nextPosition.Item1, nextPosition.Item2, ranges, currentRange+1, map, creatures);
                }
            }
        }

        private static Tuple<int, int> FindClosestReachableTargetPosition(
            Creature creature, char[,] map, List<Creature> creatures, int[,] ranges)
        {
            var targets = creatures.Where(c => c.IsElf != creature.IsElf);
            var otherCreatures = creatures.Where(c => c.ID != creature.ID);
            var targetPositions = targets.SelectMany(t => {
                    var possibleTargetPositions = new Tuple<int, int>[4] {
                        new Tuple<int, int>(t.X-1, t.Y),
                        new Tuple<int, int>(t.X+1, t.Y),
                        new Tuple<int, int>(t.X, t.Y-1),
                        new Tuple<int, int>(t.X, t.Y+1)};

                    return possibleTargetPositions.Where(pt =>
                        map[pt.Item1, pt.Item2] == '.' &&
                        !otherCreatures.Any(c => c.X == pt.Item1 && c.Y == pt.Item2));
                }).ToList();

            if (targetPositions.Count == 0)
                return null;

            var positionsByDistance = targetPositions.GroupBy(tp => ranges[tp.Item1, tp.Item2]).OrderBy(g => g.Key).ToList();
            if (positionsByDistance.First().Key == int.MaxValue)
                return null;

            var closestPosition = positionsByDistance.First().OrderBy(tp => tp.Item2).ThenBy(tp => tp.Item1).First();
            return closestPosition;
        }

        private static Tuple<int, int> FindNextPosition(Tuple<int, int> targetPosition, Creature creature, char[,] map, List<Creature> creatures)
        {
            var ranges = new int[map.GetLength(0), map.GetLength(1)];
            for (var x = 0; x < map.GetLength(0); x++)
            {
                for (var y = 0; y < map.GetLength(0); y++)
                {
                    ranges[x,y] = int.MaxValue;
                }
            }
            FillRanges(targetPosition.Item1, targetPosition.Item2, ranges, 0, map, creatures);

            var possibleNextPositions = new List<Tuple<int, int>>();

            if (creature.X > 0)
            {
                possibleNextPositions.Add(new Tuple<int, int>(creature.X-1, creature.Y));
            }
            if (creature.X < map.GetLength(0))
            {
                possibleNextPositions.Add(new Tuple<int, int>(creature.X+1, creature.Y));
            }
            if (creature.Y > 0)
            {
                possibleNextPositions.Add(new Tuple<int, int>(creature.X, creature.Y-1));
            }
            if (creature.Y < map.GetLength(1))
            {
                possibleNextPositions.Add(new Tuple<int, int>(creature.X, creature.Y+1));
            }

            var positionsByDistance = possibleNextPositions
                .GroupBy(tp => ranges[tp.Item1, tp.Item2])
                .Where(g => g.Key != int.MaxValue)
                .OrderBy(g => g.Key)
                .ToList();
            if (positionsByDistance.Count == 0)
                return null;

            var closestPosition = positionsByDistance.First().OrderBy(tp => tp.Item2).ThenBy(tp => tp.Item1).First();
            return closestPosition;
        }

        private static void TryAttack(Creature creature, List<Creature> creatures)
        {
            var possibleTargets = creatures.Where(c => c.IsElf != creature.IsElf &&
                ((c.X == creature.X && c.Y == creature.Y + 1) ||
                 (c.X == creature.X && c.Y == creature.Y - 1) ||
                 (c.X == creature.X + 1 && c.Y == creature.Y) ||
                 (c.X == creature.X - 1 && c.Y == creature.Y)));

            var targets = possibleTargets.GroupBy(t => t.HP).OrderBy(g => g.Key).FirstOrDefault();
            if (targets == null)
                return;

            var target = targets.OrderBy(t => t.Y).ThenBy(t => t.X).First();

            target.HP -= creature.AttackPower;
            if (target.HP <= 0)
            {
                creatures.Remove(target);
            }
        }

        private static void TryAttack2(Creature creature, List<Creature> creatures)
        {
            var possibleTargets = creatures.Where(c => c.IsElf != creature.IsElf &&
                ((c.X == creature.X && c.Y == creature.Y + 1) ||
                 (c.X == creature.X && c.Y == creature.Y - 1) ||
                 (c.X == creature.X + 1 && c.Y == creature.Y) ||
                 (c.X == creature.X - 1 && c.Y == creature.Y)));

            var targets = possibleTargets.GroupBy(t => t.HP).OrderBy(g => g.Key).FirstOrDefault();
            if (targets == null)
                return;

            var target = targets.OrderBy(t => t.Y).ThenBy(t => t.X).First();

            target.HP -= creature.AttackPower;
            if (target.HP <= 0)
            {
                if (target.IsElf)
                {
                    throw new Exception("Dead elf!");
                }
                creatures.Remove(target);
            }
        }

        public static int SolveProblem2()
        {
            var minElfPower = 4;
            var maxElfPower = 200;
            var elfPower = 102;
            var result = -1;

            while(true)
            {
                try
                {
                    Console.WriteLine("Trying power: " + elfPower);
                    result = CombatSuccess(elfPower);
                    maxElfPower = elfPower;
                }
                catch (Exception)
                {
                    minElfPower = elfPower + 1;
                }

                if (minElfPower == maxElfPower)
                    break;

                elfPower = minElfPower + ((maxElfPower - minElfPower)/2);
            }

            return result;
        }

        public static int CombatSuccess(int elfPower)
        {
            var lines = ProblemInput.SplitToLines().ToList();
            var map = new char[lines[0].Length, lines.Count];
            var creatures = new List<Creature>();
            var creatureId = 0;
            for (var y = 0; y < lines.Count; y++)
            {
                for (var x = 0; x < lines[0].Length; x++)
                {
                    var charAtPos = lines[y][x];
                    if (charAtPos == 'E')
                    {
                        var elf = new Creature() { IsElf = true, X = x, Y = y, ID = creatureId, AttackPower = elfPower };
                        creatures.Add(elf);
                        map[x,y] = '.';
                        creatureId++;
                    }
                    else if (charAtPos == 'G')
                    {
                        var goblin = new Creature() { IsElf = false, X = x, Y = y, ID = creatureId };
                        creatures.Add(goblin);
                        map[x,y] = '.';
                        creatureId++;
                    }
                    else
                    {
                        map[x,y] = charAtPos;
                    }
                }
            }

            var completedRounds = 0;
            var endCombat = false;
            while (true)
            {
                // Console.WriteLine("Completed rounds: " + completedRounds);
                // PrintMap(map, creatures);

                var creaturesInTurnOrder = creatures.OrderBy(c => c.Y).ThenBy(c => c.X);
                foreach (var creature in creaturesInTurnOrder)
                {
                    if (creature.HP <= 0)
                        continue;

                    if (creatures.All(c => c.IsElf == creature.IsElf))
                    {
                        endCombat = true;
                        break;
                    }

                    var rangesFromCreature = GetRanges(creature, map, creatures);
                    var targetPosition = FindClosestReachableTargetPosition(creature, map, creatures, rangesFromCreature);
                    if (targetPosition != null && (targetPosition.Item1 != creature.X || targetPosition.Item2 != creature.Y))
                    {
                        var nextPosition = FindNextPosition(targetPosition, creature, map, creatures);
                        if (nextPosition != null)
                        {
                            creature.X = nextPosition.Item1;
                            creature.Y = nextPosition.Item2;
                        }
                    }
                    TryAttack2(creature, creatures);
                }

                if (endCombat)
                {
                    break;
                }

                completedRounds++;
            }

            PrintMap(map, creatures);
            Console.WriteLine("Rounds: " + completedRounds);
            Console.WriteLine("Remaining health: " + creatures.Sum(c => c.HP));
            return completedRounds * creatures.Sum(c => c.HP);
        }
    }
}