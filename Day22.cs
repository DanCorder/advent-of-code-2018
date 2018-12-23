namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day22
    {
        private const string ProblemInput = @"";
        private const string ProblemTestInput = @"";

        public static int SolveProblem1()
        {
            var depth = 6084;
            var size = 710;

            var map = new char[size,size];
            var erosionLevels = new int[size,size];

            for (var i = 0; i < size; i++)
            {
                for (var y = i; y < size; y++)
                {
                    var x = i;
                    var geologicIndex = -1;
                    if (x == 0)
                        geologicIndex = (y * 48271);
                    else
                        geologicIndex = erosionLevels[x-1,y] * erosionLevels[x,y-1];

                    erosionLevels[x,y] = (geologicIndex + depth) % 20183;
                    var type = erosionLevels[x,y] % 3;
                    if (type == 0)
                        map[x,y] = '.';
                    if (type == 1)
                        map[x,y] = '=';
                    if (type == 2)
                        map[x,y] = '|';
                }

                for (var x = i; x < size; x++)
                {
                    var y = i;
                    var geologicIndex = -1;
                    if (y == 0)
                        geologicIndex = (x * 16807);
                    else
                        geologicIndex = erosionLevels[x-1,y] * erosionLevels[x,y-1];

                    erosionLevels[x,y] = (geologicIndex + depth) % 20183;
                    var type = erosionLevels[x,y] % 3;
                    if (type == 0)
                        map[x,y] = '.';
                    if (type == 1)
                        map[x,y] = '=';
                    if (type == 2)
                        map[x,y] = '|';
                }
            }
            map[0,0] = 'M';
            map[14,709] = 'T';

            var total = 0;
            for (var x = 0; x < 15; x++)
            {
                for (var y = 0; y < 710; y++)
                {
                    switch(map[x,y])
                    {
                        case '=':
                            total += 1;
                            break;
                        case '|':
                            total += 2;
                            break;
                    }
                }
            }

            return total;
        }

        private enum tool
        {
            none,
            torch,
            climbingGear
        }

        private class state
        {
            public tool Equipped;
            public int Time;
        }

        private class node
        {
            public tool Equipped;
            public int Time;
            public int X;
            public int Y;
            public bool Visited;
        }

        public static int SolveProblem2()
        {
            var depth = 6084;
            var padding = 30;
            var size = 709 + padding;

            // var depth = 510;
            // var size = 13;

            var map = new char[size,size];
            var erosionLevels = new int[size,size];

            for (var i = 0; i < size; i++)
            {
                for (var y = i; y < size; y++)
                {
                    var x = i;
                    var geologicIndex = -1;
                    if (x == 0)
                        geologicIndex = (y * 48271);
                    else
                        geologicIndex = erosionLevels[x-1,y] * erosionLevels[x,y-1];

                    erosionLevels[x,y] = (geologicIndex + depth) % 20183;
                    var type = erosionLevels[x,y] % 3;
                    if (type == 0)
                        map[x,y] = '.';
                    if (type == 1)
                        map[x,y] = '=';
                    if (type == 2)
                        map[x,y] = '|';
                }

                for (var x = i; x < size; x++)
                {
                    var y = i;
                    var geologicIndex = -1;
                    if (y == 0)
                        geologicIndex = (x * 16807);
                    else
                        geologicIndex = erosionLevels[x-1,y] * erosionLevels[x,y-1];

                    erosionLevels[x,y] = (geologicIndex + depth) % 20183;
                    var type = erosionLevels[x,y] % 3;
                    if (type == 0)
                        map[x,y] = '.';
                    if (type == 1)
                        map[x,y] = '=';
                    if (type == 2)
                        map[x,y] = '|';
                }
            }
            map[0,0] = 'M';
            map[14,709] = '.';
            var nodeMap = new List<node>[14+padding,709+padding];
            var unvisited = new HashSet<node>();

            var nodes = new HashSet<node>();
            for (var x = 0; x < nodeMap.GetLength(0); x++)
            {
                for (var y = 0; y < nodeMap.GetLength(1); y++)
                {
                    if (!(x == 0 && y ==0))
                    {
                        var state1 = new node() { X = x, Y = y, Time = int.MaxValue, Visited = false };
                        var state2 = new node() { X = x, Y = y, Time = int.MaxValue, Visited = false };

                        switch (map[x,y])
                        {
                            case '.':
                                state1.Equipped = tool.climbingGear;
                                state2.Equipped = tool.torch;
                                break;
                            case '=':
                                state1.Equipped = tool.climbingGear;
                                state2.Equipped = tool.none;
                                break;
                            case '|':
                                state1.Equipped = tool.none;
                                state2.Equipped = tool.torch;
                                break;
                        }
                        nodes.Add(state1);
                        nodes.Add(state2);
                        nodeMap[x,y] = new List<node>() { state1, state2 };
                        unvisited.Add(state1);
                        unvisited.Add(state2);
                    }
                }
            }

            var start1 = new node() { X = 0, Y = 0, Time = int.MaxValue, Visited = false, Equipped = tool.none };
            var start2 = new node() { X = 0, Y = 0, Time = int.MaxValue, Visited = false, Equipped = tool.climbingGear };
            var currentNode = new node() { X = 0, Y = 0, Time = 0, Equipped = tool.torch, Visited = true };

            nodes.Add(start1);
            nodes.Add(start2);
            unvisited.Add(start1);
            unvisited.Add(start2);
            nodeMap[0,0] = new List<node>() { start1, start2, currentNode };
            var minTime = 0;

            while (!IsEnd(currentNode))
            {
                var adjacents = GetAdjacentNodes(currentNode, nodeMap);
                foreach (var adjacent in adjacents)
                {
                    var time = currentNode.Equipped == adjacent.Equipped ? 1 : 7;
                    if (adjacent.Time > currentNode.Time + time)
                    {
                        adjacent.Time = currentNode.Time + time;
                    }
                }
                currentNode.Visited = true;
                unvisited.Remove(currentNode);
                currentNode = nodes.Where(n => !n.Visited).Aggregate((l, r) => l.Time < r.Time ? l : r);

                if (currentNode.Time >= minTime + 10)
                {
                    Console.WriteLine(DateTime.Now);
                    minTime = currentNode.Time;
                    Console.WriteLine("Time: " + minTime);
                }
            }

            // 953 too high
            return currentNode.Time;
        }

        private static bool IsEnd(node toCheck)
        {
            return
                toCheck.X == 14 &&
                toCheck.Y == 709 &&
                toCheck.Equipped == tool.torch;
        }

        private static List<node> GetAdjacentNodes(node root, List<node>[,] nodeMap)
        {
            var ret = new List<node>();
            if (root.X != 0)
            {
                ret.AddRange(nodeMap[root.X - 1, root.Y].Where(n => n.Equipped == root.Equipped));
            }
            if (root.Y != 0)
            {
                ret.AddRange(nodeMap[root.X, root.Y - 1].Where(n => n.Equipped == root.Equipped));
            }
            if (root.X != nodeMap.GetLength(0) - 1)
            {
                ret.AddRange(nodeMap[root.X + 1, root.Y].Where(n => n.Equipped == root.Equipped));
            }
            if (root.Y != nodeMap.GetLength(1) - 1)
            {
                ret.AddRange(nodeMap[root.X, root.Y + 1].Where(n => n.Equipped == root.Equipped));
            }
            ret.AddRange(nodeMap[root.X, root.Y].Where(n => n.Equipped != root.Equipped));

            return ret;

            // return nodes.Where(n =>
            //     (n.X == root.X && n.Y == root.Y - 1 && n.Equipped == root.Equipped) ||
            //     (n.X == root.X && n.Y == root.Y + 1 && n.Equipped == root.Equipped) ||
            //     (n.X == root.X + 1 && n.Y == root.Y && n.Equipped == root.Equipped) ||
            //     (n.X == root.X - 1 && n.Y == root.Y && n.Equipped == root.Equipped) ||
            //     (n.X == root.X && n.Y == root.Y && n.Equipped != root.Equipped)).ToList();
        }

        private static void Navigate(List<state>[,] states, char[,] map, int currentX, int currentY)
        {
            foreach(var state in states[currentX, currentY].ToArray())
            {
                if (currentX == 0 && currentY == 0)
                {
                    var nextType = map[1, 0];
                    if (nextType == '.' || nextType == '|')
                    {
                        states[1, 0].Add(new state{ Equipped = tool.torch, Time = 1});
                    }
                    else
                    {
                        states[1, 0].Add(new state{ Equipped = tool.climbingGear, Time = 8});
                        states[1, 0].Add(new state{ Equipped = tool.none, Time = 8});
                    }
                    nextType = map[0, 1];
                    if (nextType == '.' || nextType == '|')
                    {
                        states[0, 1].Add(new state{ Equipped = tool.torch, Time = 1});
                    }
                    else
                    {
                        states[0, 1].Add(new state{ Equipped = tool.climbingGear, Time = 8});
                        states[0, 1].Add(new state{ Equipped = tool.none, Time = 8});
                    }
                    Navigate(states, map, 1, 0);
                    Navigate(states, map, 0, 1);
                }
                else
                {
                    if (currentX != 0 && !(currentY == 0 && currentX == 1))
                    {
                        var currentType = map[currentX, currentY];
                        var nextType = map[currentX - 1, currentY];
                        var currentTool = state.Equipped;
                        var nextTool = NextTool(currentType, nextType, currentTool);
                        var changeTime = currentTool == nextTool ? 0 : 7;

                        var nextState = new state{ Equipped = nextTool, Time = state.Time + changeTime + 1};

                        var nextRegionState = states[currentX - 1, currentY].SingleOrDefault(s => s.Equipped == nextState.Equipped);

                        if (nextRegionState == null || nextRegionState.Time > nextState.Time)
                        {
                            states[currentX - 1, currentY].Remove(nextRegionState);
                            states[currentX - 1, currentY].Add(nextState);
                            Navigate(states, map, currentX - 1, currentY);
                        }
                    }
                    if (currentY != 0 && !(currentY == 1 && currentX == 0))
                    {
                        var currentType = map[currentX, currentY];
                        var nextType = map[currentX, currentY - 1];
                        var currentTool = state.Equipped;
                        var nextTool = NextTool(currentType, nextType, currentTool);
                        var changeTime = currentTool == nextTool ? 0 : 7;

                        var nextState = new state{ Equipped = nextTool, Time = state.Time + changeTime + 1};

                        var nextRegionState = states[currentX, currentY - 1].SingleOrDefault(s => s.Equipped == nextState.Equipped);

                        if (currentX == 1 && currentY == 1)
                        {
                            var d = "qq";
                        }

                        if (nextRegionState == null || nextRegionState.Time > nextState.Time)
                        {
                            states[currentX, currentY - 1].Remove(nextRegionState);
                            states[currentX, currentY - 1].Add(nextState);
                            Navigate(states, map, currentX, currentY - 1);
                        }
                    }
                    if (currentX != states.GetLength(0) - 1)
                    {
                        var currentType = map[currentX, currentY];
                        var nextType = map[currentX + 1, currentY];
                        var currentTool = state.Equipped;
                        var nextTool = NextTool(currentType, nextType, currentTool);
                        var changeTime = currentTool == nextTool ? 0 : 7;

                        var nextState = new state{ Equipped = nextTool, Time = state.Time + changeTime + 1};

                        var nextRegionState = states[currentX + 1, currentY].SingleOrDefault(s => s.Equipped == nextState.Equipped);

                        if (nextRegionState == null || nextRegionState.Time > nextState.Time)
                        {
                            states[currentX + 1, currentY].Remove(nextRegionState);
                            states[currentX + 1, currentY].Add(nextState);
                            Navigate(states, map, currentX + 1, currentY);
                        }
                    }
                    if (currentY != states.GetLength(1) - 1)
                    {
                        var currentType = map[currentX, currentY];
                        var nextType = map[currentX, currentY + 1];
                        var currentTool = state.Equipped;
                        var nextTool = NextTool(currentType, nextType, currentTool);
                        var changeTime = currentTool == nextTool ? 0 : 7;

                        var nextState = new state{ Equipped = nextTool, Time = state.Time + changeTime + 1};

                        var nextRegionState = states[currentX, currentY + 1].SingleOrDefault(s => s.Equipped == nextState.Equipped);

                        if (nextRegionState == null || nextRegionState.Time > nextState.Time)
                        {
                            states[currentX, currentY + 1].Remove(nextRegionState);
                            states[currentX, currentY + 1].Add(nextState);

                            Navigate(states, map, currentX, currentY + 1);
                        }
                    }
                }
            }
        }

        private static tool NextTool(char currentType, char nextType, tool currentTool)
        {
            if (currentType == nextType)
            {
                return currentTool;
            }
            else if (currentType == '.' && nextType == '=')
            {
                return tool.climbingGear;
            }
            else if (currentType == '.' && nextType == '|')
            {
                return tool.torch;
            }
            else if (currentType == '=' && nextType == '.')
            {
                return tool.climbingGear;
            }
            else if (currentType == '=' && nextType == '|')
            {
                return tool.none;
            }
            else if (currentType == '|' && nextType == '.')
            {
                return tool.torch;
            }
            else
            {
                return tool.none;
            }
        }
    }
}