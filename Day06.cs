namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day06
    {
        private const string Problem1Input = @"227, 133
140, 168
99, 112
318, 95
219, 266
134, 144
306, 301
189, 188
58, 334
337, 117
255, 73
245, 144
102, 257
255, 353
303, 216
141, 167
40, 321
201, 50
60, 188
132, 74
125, 199
176, 307
204, 218
338, 323
276, 278
292, 229
109, 228
85, 305
86, 343
97, 254
182, 151
110, 292
285, 124
43, 223
153, 188
285, 136
334, 203
84, 243
92, 185
330, 223
259, 275
106, 199
183, 205
188, 212
231, 150
158, 95
174, 212
279, 97
172, 131
247, 320";
// private const string Problem1Input = @"1, 1
// 1, 6
// 8, 3
// 3, 4
// 5, 5
// 8, 9";

        public static int SolveProblem1()
        {
            var points = Problem1Input.SplitToLines().Select((l, i) => new Point(
                Int32.Parse(l.Split(',')[0]),
                Int32.Parse(l.Split(',')[1]),
                i
            )).ToList();

            var MaxX = points.Aggregate((l, r) => l.X > r.X ? l : r).X;
            var MinX = points.Aggregate((l, r) => l.X < r.X ? l : r).X;
            var MaxY = points.Aggregate((l, r) => l.Y > r.Y ? l : r).Y;
            var MinY = points.Aggregate((l, r) => l.Y < r.Y ? l : r).Y;

            Console.WriteLine(MinX);
            Console.WriteLine(MaxX);
            Console.WriteLine(MinY);
            Console.WriteLine(MaxY);

            var grid = new Point[MaxX - MinX + 1, MaxY - MinY + 1];

            for (var x = MinX; x <= MaxX; x++)
            {
                for (var y = MinY; y <= MaxY; y++)
                {
                    var point = findClosestPointIndex(x, y, points);
                    grid[x-MinX, y-MinY] = point;

                    if (point != null &&
                        (x == MinX ||
                         x == MaxX ||
                         y == MinY ||
                         y == MaxY))
                    {
                        point.AreaReachesEdge = true;
                    }
                }
            }

            PrintGrid(grid, MaxX - MinX + 1, MaxY - MinY + 1, MinX, MinY);

            return points.Where(p => !p.AreaReachesEdge).Aggregate((l,r) => l.AreaSize > r.AreaSize ? l : r).AreaSize;
        }

        private static void PrintGrid(Point[,] grid, int width, int height, int xOffset, int yOffset)
        {
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var toPrint = "";

                    if (grid[x,y] == null)
                    {
                        toPrint = " . ";
                    }
                    else
                    {
                        var prefix = ' ';
                        if (x + xOffset == grid[x,y].X && y + yOffset == grid[x,y].Y)
                        {
                            prefix = '#';
                        }
                        toPrint = prefix + grid[x,y].Index.ToString() + ' ';
                    }
                    Console.Write(toPrint);
                }
                Console.WriteLine("");
            }
        }

        private static Point findClosestPointIndex(int x, int y, List<Point> points)
        {
            var minDistance = int.MaxValue;
            Point closestPoint = null;

            foreach (var point in points)
            {
                var distance = Math.Abs(point.X - x) + Math.Abs(point.Y - y);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestPoint = point;
                }
                else if (distance == minDistance)
                {
                    closestPoint = null;
                }
            }

            if (closestPoint != null)
            {
                closestPoint.AreaSize++;
            }

            return closestPoint;
        }

        public static int SolveProblem2()
        {
           var points = Problem1Input.SplitToLines().Select((l, i) => new Point(
                Int32.Parse(l.Split(',')[0]),
                Int32.Parse(l.Split(',')[1]),
                i
            )).ToList();

            var MaxX = points.Aggregate((l, r) => l.X > r.X ? l : r).X;
            var MinX = points.Aggregate((l, r) => l.X < r.X ? l : r).X;
            var MaxY = points.Aggregate((l, r) => l.Y > r.Y ? l : r).Y;
            var MinY = points.Aggregate((l, r) => l.Y < r.Y ? l : r).Y;

            Console.WriteLine(MinX);
            Console.WriteLine(MaxX);
            Console.WriteLine(MinY);
            Console.WriteLine(MaxY);

            var grid = new int[MaxX - MinX + 1, MaxY - MinY + 1];
            var withinArea = 0;

            for (var x = MinX; x <= MaxX; x++)
            {
                for (var y = MinY; y <= MaxY; y++)
                {
                    withinArea += WithinArea(x,y,points) ? 1 : 0;
                }
            }

            return withinArea;
        }

        private static bool WithinArea(int x, int y, List<Point> points)
        {
            var totalDistance = 0;

            foreach (var point in points)
            {
                totalDistance += Math.Abs(point.X - x);
                totalDistance += Math.Abs(point.Y - y);

                if (totalDistance >= 10000)
                {
                    return false;
                }
            }

            return true;
        }

        private class Point
        {
            public int X;
            public int Y;

            public int Index;

            public int AreaSize = 0;

            public bool AreaReachesEdge = false;

            public Point(int x, int y, int i)
            {
                X = x;
                Y = y;
                Index = i;
            }
        }
    }
}