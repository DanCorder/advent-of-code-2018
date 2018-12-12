namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day12
    {
        private const string ProblemInput = @"#..######..#....#####..###.##..#######.####...####.##..#....#.##.....########.#...#.####........#.#.";
        private const string Rules = @"#...# => .
##.## => .
###.. => .
.#### => .
#.#.# => .
##..# => #
..#.# => #
.##.. => #
##... => #
#..## => #
#..#. => .
.###. => #
#.##. => .
..### => .
.##.# => #
....# => .
##### => .
#.### => .
.#..# => .
#.... => .
...## => .
.#.## => .
##.#. => #
#.#.. => #
..... => .
.#... => #
...#. => #
..#.. => .
..##. => .
###.# => .
####. => .
.#.#. => .";
        private const string ProblemTestInput = @"";

        public static int SolveProblem1()
        {
            var numberOfGenerations = 20;
            var buffer = numberOfGenerations*2 + 4;
            var maxLength = ProblemInput.Length + buffer;
            var plants = new bool[maxLength];
            var newPlants = new bool[maxLength];

            for (var i = (buffer/2); i < ProblemInput.Length + buffer/2; i++)
            {
                plants[i] = ProblemInput[i-buffer/2] == '#';
            }

            var rules = Rules.SplitToLines().Select(r => {
                var rule = new bool[6];
                for (var i = 0; i < 5; i++)
                {
                    rule[i] = r[i] == '#';
                }
                rule[5] = r[9] == '#';
                return rule;
            }).ToList();


            for (var t = 0; t < numberOfGenerations; t++)
            {
                for (var i = 2; i < maxLength-2; i++)
                {
                    foreach (var rule in rules)
                    {
                        if (rule[0] == plants[i-2] &&
                            rule[1] == plants[i-1] &&
                            rule[2] == plants[i] &&
                            rule[3] == plants[i+1] &&
                            rule[4] == plants[i+2])
                        {
                            newPlants[i] = rule[5];
                            break;
                        }
                    }
                }
                plants = newPlants;
                Console.WriteLine(String.Concat(plants.Select(p => p ? '#' : '.')));
                newPlants = new bool[maxLength];
            }

            var sum = 0;
            for (var i = 2; i < maxLength-2; i++)
            {
                if (plants[i])
                {
                    sum += (i - buffer/2);
                }
            }

            return sum;
        }

        private class PreviousState
        {
            public int Time = 0;
            public bool[] State;
            public long Offset = 0;
        }
        public static long SolveProblem2()
        {
            var numberOfGenerations = 50000000000;
            //var numberOfGenerations = 20; // should return 2736
            long offset = 0;

            var plants = ProblemInput.Select(c => c == '#').ToList();
            var newPlants = new List<bool>();

            var rules = Rules.SplitToLines().Select(r => {
                var rule = new bool[6];
                for (var i = 0; i < 5; i++)
                {
                    rule[i] = r[i] == '#';
                }
                rule[5] = r[9] == '#';
                return rule;
            }).ToList();

            var previousTimesByState = new Dictionary<bool[], long>();
            var previousStatesByTime = new Dictionary<long, PreviousState>();
            for (var t = 0; t < numberOfGenerations; t++)
            {
                plants = TrimPlantsEnd(plants);

                if (t % 10000 == 0)
                {
                    Console.WriteLine("Time: " + t);
                    Console.WriteLine("Plants length: " + plants.Count);
                    Console.WriteLine("Offset: " + offset);
                    //Console.WriteLine(String.Concat(plants.Select(p => p ? '#' : '.')));
                }

                var match = previousTimesByState.Keys.SingleOrDefault(k => Enumerable.SequenceEqual(k, plants));
                if (match != null)
                {
                    Console.WriteLine("Found loop at time: " + t);
                    // 15 generations
                    // 0123456789012345
                    // abcdefcdefcdefcd

                    // 15 generations
                    // 0123456789012345
                    // abcdefghijklllll
                    var loopEndTime = t; // 6    12
                    var loopStartTime = previousTimesByState[match]; // 2   11
                    var loopLength = loopEndTime - loopStartTime; // 4    1
                    var timeRemaining = numberOfGenerations - t; // 15 - 6 = 9     15 - 12 = 3
                    var endTimeInLoop = timeRemaining % loopLength; // 1     0
                    long numberOfLoopsRemaining = timeRemaining / loopLength;   // 3


                    var endPlantsState = previousStatesByTime[loopStartTime + endTimeInLoop]; // 3    11
                    var loopStartState = previousStatesByTime[loopStartTime]; // 3      11
                    plants = new List<bool>(endPlantsState.State);
                    var offsetDeltaPerLoop = offset - loopStartState.Offset; // 5
                    var offsetDeltaToFinalState = endPlantsState.Offset - loopStartState.Offset; // 0
                    offset = offset + (offsetDeltaPerLoop*numberOfLoopsRemaining) + offsetDeltaToFinalState;
                    break;
                }

                previousTimesByState[plants.ToArray()] = t;
                var state = new PreviousState();
                state.Offset = offset;
                state.State = plants.ToArray();
                state.Time = t;
                previousStatesByTime[t] = state;

                newPlants = new List<bool>();
                for (var i = -1; i < plants.Count + 1; i++)
                {
                    var subSection = GetPlantSubsection(plants, i);
                    var rule = rules.Single(r =>
                        r[0] == subSection[0] &&
                        r[1] == subSection[1] &&
                        r[2] == subSection[2] &&
                        r[3] == subSection[3] &&
                        r[4] == subSection[4]);

                    if (i == -1)
                    {
                        if (rule[5])
                        {
                            offset--;
                            newPlants.Add(true);
                        }
                    }
                    else
                    {
                        newPlants.Add(rule[5]);
                    }
                }

                while (!newPlants[0])
                {
                    newPlants.RemoveAt(0);
                    offset++;
                }
                plants = newPlants;

                //Console.WriteLine("Offset: " + offset);
                //Console.WriteLine(String.Concat(plants.Select(p => p ? '#' : '.')));
            }

            long sum = 0;
            for (var i = 0; i < plants.Count; i++)
            {
                if (plants[i])
                {
                    sum += offset;
                    sum += i;
                }
            }

            // 3150000000842 too low
            // 3150000000905

            return sum;
        }

        private static bool[] GetPlantSubsection(List<bool> plants, int index)
        {
            if (index == -1)
            {
                return new bool[] { false, false, false, plants[0], plants[1]};
            }
            if (index == 0)
            {
                return new bool[] { false, false, plants[0], plants[1], plants[2]};
            }
            if (index == 1)
            {
                return new bool[] { false, plants[0], plants[1], plants[2], plants[3]};
            }

            if (index == plants.Count)
            {
                return new bool[] { plants[plants.Count - 2], plants[plants.Count - 1], false, false, false };
            }
            if (index == plants.Count - 1)
            {
                return new bool[] { plants[plants.Count - 3], plants[plants.Count - 2], plants[plants.Count - 1], false, false};
            }
            if (index == plants.Count - 2)
            {
                return new bool[] { plants[plants.Count - 4], plants[plants.Count - 3], plants[plants.Count - 2], plants[plants.Count - 1], false};
            }

            return new bool[] { plants[index - 2], plants[index - 1], plants[index], plants[index + 1], plants[index + 2]};
        }

        private static List<bool> TrimPlantsEnd(List<bool> plants)
        {
            var i = 0;
            for (i = 0; i < plants.Count; i++)
            {
                if (plants[plants.Count - 1 - i])
                {
                    break;
                }
            }

            return plants.Take(plants.Count - i).ToList();
        }
    }
}