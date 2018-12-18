namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day18
    {
        private const string ProblemInput = @".#||#|||##....|..#......|..#...##..|#....#|.......
|..#..#....|.#|.|......||.|..#|...||#......|.....|
..#|##.#.#.##...#..........#.#|...||.|..|##.#.|.||
|.#.#|#.#.||...|...|||#|.#..#|..|#.#..##.|......#|
#..|#|........|......##.|##..|..#|...#||.......|#.
#...|#..#......##...##.|......|.#|#.|..|#.|#...|.#
|#.....|.|.###..#...|....|..|.....|#..#..|.......#
.....##.|........|...#...|#..|..##...|......||.|..
#....#..|..#.........||.##..##|#.##.#....|...#.|.|
...|..#.|.|#||..|#.||.....#|.#|.|#|.....#|#.###|##
...|..#.||....||.#.|....|#...#|.||#.#..#...#...##.
...||.|#......|...|#...#..|...||..|.#|.....##.|||.
...|.#|.|#.|...#.....|.|...#|.|.........|||.|.##.|
..|..|#..|........#.|#.||.#|..#.|....||...|.|.#...
.|.|...#.|.#..........|..|........#|.|....|..|....
|...|.#..|..||#.||#........|...|.|.|..|.#|..|...|.
..#.#..#|......#|.#....###...#.#..|..|.....|....#.
..|||..#...|#|.##..#|#.#.#..|......#.....||.##.##.
...|...#.|##..|..|.|.#.|||#|......|.|..|.||#.#..||
||.....|..#|.#...|.|.#.||.....##...|.#...|#.#.##..
.|.|.#|..#........#..||.|.#|...###|.#..#........||
|.##......|.|||..|...##.|.....#|||....#...#||||.|.
...#...|||.......#..|.#.||.|.......|#|..|..#.|....
|..|#.............|...##|....|.#|..|#...|#...|.|..
|.|....|#...|##...#.....|..|..|...||#..|...|.#..||
...|.##.##....#.|#......##|...|..#.#....||||.||||.
||.#....#..#...|.||||##.....#..##......#..||##.#..
........#....|..#..#|#|....#..|..#.....##|...#.|..
..#.|#.|.#.#..#.....|..#...###....|#...........#.|
#.|#|.#...|.#.#.|..|....|..|.|.#|.#|#.............
.||......|||||...||.#......|#...|#.|.|..#.|.#|....
|.#|.#.|#.#..#.##......#.#|#.....#..#....#.##|.#..
#.#..|....###..|..|.||..|#..|...|...#|##....|#.#..
.|#...|..#|..#.|||.|..||...|..#.#...|..|#......#..
.##...#||..|#.#...|.......|.##.....|..|.#..|.#.|.#
#||##....#.|.||.#....|.#|..|.|.#....#..#...||.....
......||.#|........#....||.##...#....|.||...|..##|
#........|..#|.......#.#.#|..|...#..||||...|.....#
....#||.##....|..##...##|.....|..#.#.....#..|.....
.|.|#....|..|.#|#....#..|...|..#|#...#.||...#.#...
#....|.|#||....#.#|#|.#..|.#.....##........|...|#.
#...#...|..|.#....|..|.#....#.|#...#...#|.|.#.....
....#.......#....##|.#.|....##..|||##.....#|.....#
.....||||..|.#|#..|...|.#..|...#|...|.##||.#||....
.||....#...|..#.|#.#.|#|#|..#.........##...||..|#.
...|.#.#..........##...#|...|.##.|.|.||.#......#..
...###.#..|..#.....#|#.#.|#.######|.|#.....###.|.#
..##.....##...|..|....#|..||....|.|....#..|...|..#
.|.##.#...|.|.||.||.|#.#.....||#.#|.#|.|..#|.#..|#
.|...............#.#..#.##......#|||.|..||..#....#";
        private const string ProblemTestInput = @".#.#...|#.
.....#|##|
.|..|...#.
..|#.....#
#.#|||#|#|
...#.||...
.|....|...
||...#|.#|
|.||||..|.
...#.|..|.";

        public static int SolveProblem1()
        {
            var lines = ProblemInput.SplitToLines().ToList();
            var width = lines[0].Length + 2;
            var height = lines.Count + 2;
            var area = new char[width, height];
            var newArea = new char[width, height];
            var numberOfMinutesToCount = 10;

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        area[x,y] = 'Q';
                        newArea[x,y] = 'Q';
                    }
                    else
                    {
                        area[x,y] = lines[y-1][x-1];
                    }
                }
            }

            for (var t = 0; t < numberOfMinutesToCount; t++)
            {
                //PrintArea(area);
                for (var y = 1; y < height - 1; y++)
                {
                    for (var x = 1; x < width - 1; x++)
                    {
                        switch (area[x,y])
                        {
                            case '.':
                                if (CountSurrounding(area, '|', x, y) >= 3)
                                    newArea[x,y] = '|';
                                else
                                    newArea[x,y] = '.';
                                break;
                            case '|':
                                if (CountSurrounding(area, '#', x, y) >= 3)
                                    newArea[x,y] = '#';
                                else
                                    newArea[x,y] = '|';
                                break;
                            case '#':
                                if (CountSurrounding(area, '#', x, y) >= 1 &&
                                    CountSurrounding(area, '|', x, y) >= 1)
                                    newArea[x,y] = '#';
                                else
                                    newArea[x,y] = '.';
                                break;
                            default:
                                throw new Exception("What's this? " + area[x,y]);
                        }
                    }
                }
                //PrintArea(newArea);

                var temp = area;
                area = newArea;
                newArea = temp;
            }

            var treeCount = 0;
            var yardCount = 0;
            for (var y = 1; y < height - 1; y++)
            {
                for (var x = 1; x < width - 1; x++)
                {
                    if (area[x,y] == '|')
                        treeCount++;

                    if (area[x,y] == '#')
                        yardCount++;
                }
            }

            return treeCount * yardCount;
        }

        private static int CountSurrounding(char[,] area, char type, int x, int y)
        {
            var count = 0;
            for (var xDelta = -1; xDelta <= 1; xDelta++)
            {
                for (var yDelta = -1; yDelta <= 1; yDelta++)
                {
                    if (xDelta == 0 && yDelta == 0)
                        continue;

                    if (area[x+xDelta, y+yDelta] == type)
                        count++;
                }
            }

            // 722142 too low
            return count;
        }

        private static void PrintArea(char[,] area)
        {
            for (var y = 1; y < area.GetLength(1) - 1; y++)
            {
                for (var x = 1; x < area.GetLength(0) - 1; x++)
                {
                    Console.Write(area[x,y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static int SolveProblem2()
        {
            var lines = ProblemInput.SplitToLines().ToList();
            var width = lines[0].Length + 2;
            var height = lines.Count + 2;
            var area = new char[width, height];
            var numberOfMinutesToCount = 1000000000;
            var areasByTime = new Dictionary<int, char[,]>();

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        area[x,y] = 'Q';
                    }
                    else
                    {
                        area[x,y] = lines[y-1][x-1];
                    }
                }
            }

            var defaultPair = new KeyValuePair<int,char[,]>();
            var loopStartTime = -1;
            var loopEndTime = -1;

            for (var t = 0; t < numberOfMinutesToCount; t++)
            {
                if (t % 10000 == 0)
                    Console.WriteLine("t = " + t);

                var match = areasByTime.SingleOrDefault(kv => kv.Value.Cast<char>().SequenceEqual(area.Cast<char>()));
                if (!match.Equals(defaultPair))
                {
                    loopStartTime = match.Key;
                    loopEndTime = t;
                    break;
                }

                areasByTime[t] = area;
                var newArea = new char[width, height];
                for (var y = 0; y < height; y++)
                {
                    newArea[0, y] = 'Q';
                    newArea[width - 1, y] = 'Q';
                }
                for (var x = 0; x < width; x++)
                {
                    newArea[x, 0] = 'Q';
                    newArea[x, height-1] = 'Q';
                }
                //PrintArea(area);
                for (var y = 1; y < height - 1; y++)
                {
                    for (var x = 1; x < width - 1; x++)
                    {
                        switch (area[x,y])
                        {
                            case '.':
                                if (CountSurrounding(area, '|', x, y) >= 3)
                                    newArea[x,y] = '|';
                                else
                                    newArea[x,y] = '.';
                                break;
                            case '|':
                                if (CountSurrounding(area, '#', x, y) >= 3)
                                    newArea[x,y] = '#';
                                else
                                    newArea[x,y] = '|';
                                break;
                            case '#':
                                if (CountSurrounding(area, '#', x, y) >= 1 &&
                                    CountSurrounding(area, '|', x, y) >= 1)
                                    newArea[x,y] = '#';
                                else
                                    newArea[x,y] = '.';
                                break;
                            default:
                                throw new Exception("What's this? " + area[x,y]);
                        }
                    }
                }
                //PrintArea(newArea);
                area = newArea;
            }

            Console.WriteLine("Loop start: " + loopStartTime);
            Console.WriteLine("Loop end: " + loopEndTime);

            // 0123456789
            // abcdecdecd
            var loopLength = loopEndTime - loopStartTime; // 5 - 2 = 3
            var loopIndexAtEnd = (numberOfMinutesToCount - loopStartTime) % loopLength; // (9 - 2) % 3 = 1
            var areaAtEnd = areasByTime[loopStartTime + loopIndexAtEnd];

            var treeCount = 0;
            var yardCount = 0;
            for (var y = 1; y < height - 1; y++)
            {
                for (var x = 1; x < width - 1; x++)
                {
                    if (areaAtEnd[x,y] == '|')
                        treeCount++;

                    if (areaAtEnd[x,y] == '#')
                        yardCount++;
                }
            }

            return treeCount * yardCount;
        }
    }
}