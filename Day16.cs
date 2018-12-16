namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day16
    {
        private const string ProblemInput = @"Before: [1, 1, 0, 3]
3 0 2 0
After:  [0, 1, 0, 3]

Before: [0, 1, 2, 3]
12 1 2 3
After:  [0, 1, 2, 0]

Before: [1, 1, 2, 0]
12 1 2 2
After:  [1, 1, 0, 0]

Before: [2, 1, 1, 1]
1 1 3 0
After:  [1, 1, 1, 1]

Before: [0, 3, 1, 2]
15 0 0 2
After:  [0, 3, 1, 2]

Before: [1, 1, 1, 3]
5 2 1 2
After:  [1, 1, 2, 3]

Before: [0, 1, 0, 1]
1 1 3 3
After:  [0, 1, 0, 1]

Before: [2, 1, 2, 0]
8 0 1 0
After:  [1, 1, 2, 0]

Before: [3, 1, 2, 1]
4 3 2 1
After:  [3, 1, 2, 1]

Before: [2, 2, 1, 3]
15 3 3 3
After:  [2, 2, 1, 1]

Before: [2, 1, 2, 0]
15 2 0 2
After:  [2, 1, 1, 0]

Before: [1, 1, 1, 1]
0 1 0 1
After:  [1, 1, 1, 1]

Before: [1, 1, 1, 2]
0 1 0 3
After:  [1, 1, 1, 1]

Before: [2, 1, 0, 2]
8 0 1 3
After:  [2, 1, 0, 1]

Before: [2, 3, 2, 1]
4 3 2 1
After:  [2, 1, 2, 1]

Before: [0, 1, 1, 0]
10 0 0 2
After:  [0, 1, 0, 0]

Before: [2, 0, 2, 1]
7 0 1 0
After:  [1, 0, 2, 1]

Before: [0, 2, 2, 1]
4 3 2 2
After:  [0, 2, 1, 1]

Before: [2, 1, 1, 0]
5 2 1 2
After:  [2, 1, 2, 0]

Before: [3, 1, 2, 1]
4 3 2 0
After:  [1, 1, 2, 1]

Before: [1, 1, 0, 2]
13 3 3 0
After:  [0, 1, 0, 2]

Before: [0, 1, 1, 0]
10 0 0 1
After:  [0, 0, 1, 0]

Before: [0, 1, 1, 3]
5 2 1 0
After:  [2, 1, 1, 3]

Before: [1, 1, 2, 3]
0 1 0 0
After:  [1, 1, 2, 3]

Before: [2, 3, 3, 1]
13 3 3 2
After:  [2, 3, 0, 1]

Before: [0, 1, 2, 2]
12 1 2 0
After:  [0, 1, 2, 2]

Before: [0, 1, 3, 3]
15 3 3 3
After:  [0, 1, 3, 1]

Before: [1, 2, 2, 2]
2 0 2 2
After:  [1, 2, 0, 2]

Before: [2, 1, 1, 2]
5 2 1 2
After:  [2, 1, 2, 2]

Before: [0, 1, 2, 0]
12 1 2 3
After:  [0, 1, 2, 0]

Before: [1, 1, 1, 1]
5 2 1 1
After:  [1, 2, 1, 1]

Before: [1, 1, 2, 1]
13 3 3 2
After:  [1, 1, 0, 1]

Before: [2, 1, 3, 1]
1 1 3 3
After:  [2, 1, 3, 1]

Before: [2, 1, 2, 2]
12 1 2 2
After:  [2, 1, 0, 2]

Before: [1, 0, 2, 0]
2 0 2 1
After:  [1, 0, 2, 0]

Before: [3, 2, 1, 3]
14 2 1 1
After:  [3, 2, 1, 3]

Before: [2, 2, 0, 1]
11 0 3 3
After:  [2, 2, 0, 1]

Before: [2, 2, 0, 1]
11 0 3 1
After:  [2, 1, 0, 1]

Before: [0, 2, 2, 3]
10 0 0 0
After:  [0, 2, 2, 3]

Before: [1, 2, 3, 1]
13 3 3 3
After:  [1, 2, 3, 0]

Before: [2, 0, 2, 1]
11 0 3 3
After:  [2, 0, 2, 1]

Before: [1, 2, 0, 0]
3 0 2 0
After:  [0, 2, 0, 0]

Before: [2, 3, 1, 2]
13 3 3 2
After:  [2, 3, 0, 2]

Before: [3, 1, 3, 2]
9 1 2 2
After:  [3, 1, 0, 2]

Before: [3, 1, 0, 1]
13 3 3 1
After:  [3, 0, 0, 1]

Before: [1, 1, 0, 1]
3 0 2 0
After:  [0, 1, 0, 1]

Before: [1, 1, 3, 2]
9 1 2 3
After:  [1, 1, 3, 0]

Before: [1, 2, 1, 3]
6 1 3 1
After:  [1, 0, 1, 3]

Before: [3, 3, 2, 3]
6 2 3 2
After:  [3, 3, 0, 3]

Before: [1, 3, 2, 3]
2 0 2 3
After:  [1, 3, 2, 0]

Before: [0, 1, 1, 0]
5 2 1 0
After:  [2, 1, 1, 0]

Before: [1, 0, 1, 3]
6 2 3 3
After:  [1, 0, 1, 0]

Before: [1, 1, 2, 1]
7 3 1 0
After:  [0, 1, 2, 1]

Before: [1, 0, 0, 1]
3 0 2 1
After:  [1, 0, 0, 1]

Before: [0, 1, 2, 1]
12 1 2 2
After:  [0, 1, 0, 1]

Before: [1, 3, 0, 0]
3 0 2 1
After:  [1, 0, 0, 0]

Before: [1, 1, 2, 0]
12 1 2 1
After:  [1, 0, 2, 0]

Before: [2, 1, 2, 1]
12 1 2 1
After:  [2, 0, 2, 1]

Before: [3, 3, 2, 1]
13 3 3 1
After:  [3, 0, 2, 1]

Before: [2, 3, 2, 1]
13 3 3 0
After:  [0, 3, 2, 1]

Before: [2, 0, 1, 1]
11 0 3 2
After:  [2, 0, 1, 1]

Before: [1, 1, 2, 3]
0 1 0 2
After:  [1, 1, 1, 3]

Before: [2, 1, 3, 2]
9 1 2 0
After:  [0, 1, 3, 2]

Before: [2, 3, 2, 1]
13 3 3 2
After:  [2, 3, 0, 1]

Before: [0, 1, 1, 1]
1 1 3 1
After:  [0, 1, 1, 1]

Before: [3, 1, 2, 1]
4 3 2 2
After:  [3, 1, 1, 1]

Before: [3, 2, 1, 2]
14 2 1 0
After:  [2, 2, 1, 2]

Before: [2, 2, 1, 1]
14 2 1 2
After:  [2, 2, 2, 1]

Before: [3, 1, 1, 3]
5 2 1 1
After:  [3, 2, 1, 3]

Before: [2, 1, 2, 0]
12 1 2 2
After:  [2, 1, 0, 0]

Before: [0, 3, 1, 0]
10 0 0 1
After:  [0, 0, 1, 0]

Before: [0, 3, 1, 0]
10 0 0 0
After:  [0, 3, 1, 0]

Before: [0, 3, 3, 0]
10 0 0 3
After:  [0, 3, 3, 0]

Before: [1, 3, 2, 0]
2 0 2 1
After:  [1, 0, 2, 0]

Before: [0, 2, 1, 0]
10 0 0 2
After:  [0, 2, 0, 0]

Before: [2, 1, 2, 1]
15 2 0 3
After:  [2, 1, 2, 1]

Before: [0, 1, 2, 1]
1 1 3 3
After:  [0, 1, 2, 1]

Before: [0, 0, 0, 2]
15 0 0 1
After:  [0, 1, 0, 2]

Before: [0, 1, 1, 1]
5 2 1 0
After:  [2, 1, 1, 1]

Before: [2, 1, 0, 1]
7 3 1 0
After:  [0, 1, 0, 1]

Before: [2, 1, 1, 2]
8 0 1 3
After:  [2, 1, 1, 1]

Before: [0, 2, 3, 2]
10 0 0 2
After:  [0, 2, 0, 2]

Before: [0, 1, 1, 1]
5 2 1 1
After:  [0, 2, 1, 1]

Before: [3, 1, 1, 0]
5 2 1 0
After:  [2, 1, 1, 0]

Before: [3, 2, 2, 0]
8 0 2 3
After:  [3, 2, 2, 1]

Before: [3, 2, 2, 2]
7 3 2 1
After:  [3, 0, 2, 2]

Before: [1, 0, 0, 1]
3 0 2 0
After:  [0, 0, 0, 1]

Before: [2, 1, 3, 2]
13 3 3 0
After:  [0, 1, 3, 2]

Before: [1, 1, 0, 0]
0 1 0 0
After:  [1, 1, 0, 0]

Before: [1, 0, 0, 3]
3 0 2 1
After:  [1, 0, 0, 3]

Before: [1, 2, 0, 1]
3 0 2 2
After:  [1, 2, 0, 1]

Before: [0, 1, 0, 2]
10 0 0 1
After:  [0, 0, 0, 2]

Before: [1, 1, 2, 0]
2 0 2 3
After:  [1, 1, 2, 0]

Before: [0, 1, 2, 1]
12 1 2 1
After:  [0, 0, 2, 1]

Before: [1, 1, 2, 0]
15 2 2 3
After:  [1, 1, 2, 1]

Before: [2, 2, 2, 0]
15 2 0 1
After:  [2, 1, 2, 0]

Before: [0, 1, 3, 1]
13 3 3 0
After:  [0, 1, 3, 1]

Before: [0, 2, 0, 3]
6 1 3 3
After:  [0, 2, 0, 0]

Before: [3, 1, 1, 2]
5 2 1 2
After:  [3, 1, 2, 2]

Before: [1, 1, 0, 3]
15 3 3 0
After:  [1, 1, 0, 3]

Before: [1, 1, 3, 1]
7 3 1 2
After:  [1, 1, 0, 1]

Before: [3, 1, 1, 1]
13 2 3 3
After:  [3, 1, 1, 0]

Before: [2, 0, 2, 1]
4 3 2 0
After:  [1, 0, 2, 1]

Before: [0, 2, 2, 1]
4 3 2 1
After:  [0, 1, 2, 1]

Before: [3, 1, 2, 2]
12 1 2 2
After:  [3, 1, 0, 2]

Before: [1, 0, 2, 1]
4 3 2 3
After:  [1, 0, 2, 1]

Before: [0, 1, 3, 1]
9 1 2 3
After:  [0, 1, 3, 0]

Before: [2, 2, 3, 1]
7 2 0 2
After:  [2, 2, 1, 1]

Before: [2, 2, 1, 1]
11 0 3 3
After:  [2, 2, 1, 1]

Before: [3, 1, 3, 0]
15 2 1 1
After:  [3, 0, 3, 0]

Before: [3, 1, 1, 1]
5 2 1 0
After:  [2, 1, 1, 1]

Before: [0, 2, 1, 2]
10 0 0 3
After:  [0, 2, 1, 0]

Before: [3, 2, 2, 3]
6 2 3 1
After:  [3, 0, 2, 3]

Before: [2, 1, 1, 1]
5 2 1 3
After:  [2, 1, 1, 2]

Before: [1, 1, 2, 1]
2 0 2 1
After:  [1, 0, 2, 1]

Before: [1, 0, 2, 2]
7 3 2 1
After:  [1, 0, 2, 2]

Before: [2, 0, 3, 1]
11 0 3 0
After:  [1, 0, 3, 1]

Before: [3, 1, 3, 0]
9 1 2 0
After:  [0, 1, 3, 0]

Before: [2, 1, 1, 1]
11 0 3 0
After:  [1, 1, 1, 1]

Before: [1, 1, 0, 3]
3 0 2 2
After:  [1, 1, 0, 3]

Before: [0, 2, 1, 0]
14 2 1 3
After:  [0, 2, 1, 2]

Before: [1, 1, 2, 2]
12 1 2 2
After:  [1, 1, 0, 2]

Before: [1, 1, 1, 2]
5 2 1 2
After:  [1, 1, 2, 2]

Before: [3, 2, 0, 0]
7 0 2 3
After:  [3, 2, 0, 1]

Before: [2, 1, 1, 3]
7 2 1 1
After:  [2, 0, 1, 3]

Before: [2, 1, 0, 3]
8 0 1 0
After:  [1, 1, 0, 3]

Before: [3, 2, 2, 1]
4 3 2 0
After:  [1, 2, 2, 1]

Before: [1, 1, 1, 0]
5 2 1 3
After:  [1, 1, 1, 2]

Before: [2, 0, 3, 1]
7 0 1 3
After:  [2, 0, 3, 1]

Before: [0, 2, 2, 1]
4 3 2 0
After:  [1, 2, 2, 1]

Before: [1, 2, 1, 0]
14 2 1 2
After:  [1, 2, 2, 0]

Before: [1, 1, 2, 1]
1 1 3 3
After:  [1, 1, 2, 1]

Before: [1, 1, 1, 0]
0 1 0 0
After:  [1, 1, 1, 0]

Before: [1, 3, 2, 3]
6 2 3 2
After:  [1, 3, 0, 3]

Before: [2, 1, 1, 1]
11 0 3 1
After:  [2, 1, 1, 1]

Before: [2, 3, 3, 1]
11 0 3 1
After:  [2, 1, 3, 1]

Before: [3, 0, 1, 3]
15 3 2 0
After:  [0, 0, 1, 3]

Before: [2, 1, 2, 1]
4 3 2 1
After:  [2, 1, 2, 1]

Before: [1, 1, 0, 3]
3 0 2 3
After:  [1, 1, 0, 0]

Before: [1, 3, 2, 2]
2 0 2 3
After:  [1, 3, 2, 0]

Before: [1, 2, 3, 3]
6 1 3 2
After:  [1, 2, 0, 3]

Before: [0, 0, 1, 1]
10 0 0 0
After:  [0, 0, 1, 1]

Before: [2, 1, 2, 1]
11 0 3 1
After:  [2, 1, 2, 1]

Before: [1, 0, 2, 0]
2 0 2 2
After:  [1, 0, 0, 0]

Before: [0, 1, 1, 2]
5 2 1 3
After:  [0, 1, 1, 2]

Before: [1, 1, 2, 2]
0 1 0 0
After:  [1, 1, 2, 2]

Before: [0, 1, 0, 1]
1 1 3 2
After:  [0, 1, 1, 1]

Before: [1, 1, 3, 1]
0 1 0 2
After:  [1, 1, 1, 1]

Before: [3, 1, 1, 1]
1 1 3 1
After:  [3, 1, 1, 1]

Before: [1, 3, 2, 3]
2 0 2 0
After:  [0, 3, 2, 3]

Before: [2, 2, 1, 3]
6 2 3 0
After:  [0, 2, 1, 3]

Before: [0, 1, 1, 2]
5 2 1 0
After:  [2, 1, 1, 2]

Before: [2, 1, 3, 1]
13 3 3 0
After:  [0, 1, 3, 1]

Before: [2, 1, 2, 3]
12 1 2 3
After:  [2, 1, 2, 0]

Before: [3, 2, 2, 1]
4 3 2 1
After:  [3, 1, 2, 1]

Before: [1, 2, 1, 3]
6 2 3 1
After:  [1, 0, 1, 3]

Before: [1, 3, 1, 3]
6 2 3 2
After:  [1, 3, 0, 3]

Before: [1, 1, 2, 1]
0 1 0 1
After:  [1, 1, 2, 1]

Before: [2, 3, 2, 3]
6 2 3 2
After:  [2, 3, 0, 3]

Before: [1, 1, 3, 3]
15 3 3 3
After:  [1, 1, 3, 1]

Before: [0, 0, 2, 3]
6 2 3 3
After:  [0, 0, 2, 0]

Before: [1, 1, 3, 1]
0 1 0 0
After:  [1, 1, 3, 1]

Before: [3, 2, 1, 3]
15 3 3 0
After:  [1, 2, 1, 3]

Before: [1, 0, 2, 1]
2 0 2 0
After:  [0, 0, 2, 1]

Before: [3, 1, 0, 3]
7 0 2 3
After:  [3, 1, 0, 1]

Before: [1, 1, 3, 1]
1 1 3 1
After:  [1, 1, 3, 1]

Before: [2, 3, 0, 1]
11 0 3 2
After:  [2, 3, 1, 1]

Before: [2, 3, 3, 1]
7 2 0 2
After:  [2, 3, 1, 1]

Before: [1, 3, 2, 1]
13 3 3 3
After:  [1, 3, 2, 0]

Before: [0, 3, 2, 2]
7 3 2 3
After:  [0, 3, 2, 0]

Before: [2, 1, 3, 2]
13 3 3 3
After:  [2, 1, 3, 0]

Before: [2, 0, 1, 1]
7 0 1 1
After:  [2, 1, 1, 1]

Before: [3, 1, 2, 3]
8 0 2 1
After:  [3, 1, 2, 3]

Before: [2, 1, 1, 3]
6 2 3 2
After:  [2, 1, 0, 3]

Before: [2, 1, 1, 0]
5 2 1 3
After:  [2, 1, 1, 2]

Before: [0, 0, 0, 0]
10 0 0 3
After:  [0, 0, 0, 0]

Before: [2, 1, 2, 1]
1 1 3 3
After:  [2, 1, 2, 1]

Before: [3, 1, 0, 2]
7 0 2 0
After:  [1, 1, 0, 2]

Before: [1, 2, 2, 1]
13 3 3 2
After:  [1, 2, 0, 1]

Before: [3, 1, 1, 1]
5 2 1 1
After:  [3, 2, 1, 1]

Before: [1, 3, 0, 2]
3 0 2 1
After:  [1, 0, 0, 2]

Before: [0, 1, 0, 1]
1 1 3 0
After:  [1, 1, 0, 1]

Before: [3, 1, 2, 1]
12 1 2 0
After:  [0, 1, 2, 1]

Before: [1, 3, 2, 1]
2 0 2 2
After:  [1, 3, 0, 1]

Before: [2, 3, 1, 1]
11 0 3 0
After:  [1, 3, 1, 1]

Before: [0, 1, 1, 0]
5 2 1 2
After:  [0, 1, 2, 0]

Before: [0, 1, 3, 0]
9 1 2 2
After:  [0, 1, 0, 0]

Before: [2, 1, 1, 1]
5 2 1 0
After:  [2, 1, 1, 1]

Before: [1, 1, 1, 1]
0 1 0 0
After:  [1, 1, 1, 1]

Before: [1, 0, 0, 1]
3 0 2 2
After:  [1, 0, 0, 1]

Before: [0, 1, 3, 2]
9 1 2 0
After:  [0, 1, 3, 2]

Before: [1, 3, 0, 1]
3 0 2 2
After:  [1, 3, 0, 1]

Before: [2, 0, 2, 1]
4 3 2 1
After:  [2, 1, 2, 1]

Before: [0, 2, 1, 3]
6 2 3 1
After:  [0, 0, 1, 3]

Before: [1, 2, 0, 2]
3 0 2 0
After:  [0, 2, 0, 2]

Before: [0, 1, 2, 2]
12 1 2 3
After:  [0, 1, 2, 0]

Before: [1, 1, 1, 2]
0 1 0 2
After:  [1, 1, 1, 2]

Before: [1, 1, 1, 0]
0 1 0 3
After:  [1, 1, 1, 1]

Before: [3, 1, 2, 3]
6 1 3 3
After:  [3, 1, 2, 0]

Before: [2, 2, 1, 1]
11 0 3 2
After:  [2, 2, 1, 1]

Before: [2, 3, 3, 1]
11 0 3 2
After:  [2, 3, 1, 1]

Before: [0, 2, 3, 2]
15 0 0 1
After:  [0, 1, 3, 2]

Before: [0, 3, 1, 3]
6 2 3 3
After:  [0, 3, 1, 0]

Before: [3, 2, 3, 1]
15 2 3 2
After:  [3, 2, 0, 1]

Before: [0, 1, 1, 1]
7 2 1 2
After:  [0, 1, 0, 1]

Before: [3, 1, 2, 1]
1 1 3 0
After:  [1, 1, 2, 1]

Before: [0, 0, 0, 3]
10 0 0 0
After:  [0, 0, 0, 3]

Before: [1, 1, 3, 1]
9 1 2 0
After:  [0, 1, 3, 1]

Before: [0, 3, 1, 3]
10 0 0 1
After:  [0, 0, 1, 3]

Before: [1, 2, 1, 1]
14 2 1 2
After:  [1, 2, 2, 1]

Before: [3, 1, 0, 1]
1 1 3 3
After:  [3, 1, 0, 1]

Before: [0, 1, 1, 1]
1 1 3 2
After:  [0, 1, 1, 1]

Before: [1, 1, 2, 0]
0 1 0 2
After:  [1, 1, 1, 0]

Before: [0, 3, 2, 2]
7 3 2 0
After:  [0, 3, 2, 2]

Before: [0, 3, 0, 3]
10 0 0 3
After:  [0, 3, 0, 0]

Before: [1, 1, 2, 1]
12 1 2 3
After:  [1, 1, 2, 0]

Before: [0, 0, 2, 1]
4 3 2 2
After:  [0, 0, 1, 1]

Before: [1, 1, 2, 0]
12 1 2 0
After:  [0, 1, 2, 0]

Before: [0, 1, 2, 1]
12 1 2 3
After:  [0, 1, 2, 0]

Before: [0, 1, 1, 3]
6 1 3 0
After:  [0, 1, 1, 3]

Before: [2, 3, 2, 1]
11 0 3 0
After:  [1, 3, 2, 1]

Before: [1, 1, 1, 1]
5 2 1 3
After:  [1, 1, 1, 2]

Before: [1, 0, 2, 0]
2 0 2 3
After:  [1, 0, 2, 0]

Before: [1, 1, 2, 3]
2 0 2 2
After:  [1, 1, 0, 3]

Before: [2, 0, 0, 1]
11 0 3 0
After:  [1, 0, 0, 1]

Before: [3, 0, 3, 3]
15 3 2 2
After:  [3, 0, 1, 3]

Before: [1, 2, 2, 2]
2 0 2 3
After:  [1, 2, 2, 0]

Before: [1, 1, 2, 1]
12 1 2 2
After:  [1, 1, 0, 1]

Before: [1, 1, 2, 0]
0 1 0 1
After:  [1, 1, 2, 0]

Before: [1, 0, 2, 2]
13 3 3 1
After:  [1, 0, 2, 2]

Before: [2, 1, 2, 1]
12 1 2 3
After:  [2, 1, 2, 0]

Before: [0, 3, 2, 2]
10 0 0 3
After:  [0, 3, 2, 0]

Before: [1, 1, 1, 2]
5 2 1 1
After:  [1, 2, 1, 2]

Before: [3, 3, 0, 1]
13 3 3 0
After:  [0, 3, 0, 1]

Before: [1, 1, 0, 2]
3 0 2 3
After:  [1, 1, 0, 0]

Before: [2, 1, 2, 3]
15 2 2 0
After:  [1, 1, 2, 3]

Before: [2, 1, 1, 1]
8 0 1 2
After:  [2, 1, 1, 1]

Before: [0, 1, 1, 2]
10 0 0 0
After:  [0, 1, 1, 2]

Before: [1, 1, 2, 1]
0 1 0 2
After:  [1, 1, 1, 1]

Before: [1, 2, 2, 1]
15 2 2 2
After:  [1, 2, 1, 1]

Before: [0, 3, 2, 1]
4 3 2 0
After:  [1, 3, 2, 1]

Before: [0, 1, 3, 3]
9 1 2 0
After:  [0, 1, 3, 3]

Before: [0, 1, 1, 0]
7 2 1 3
After:  [0, 1, 1, 0]

Before: [1, 2, 2, 1]
2 0 2 3
After:  [1, 2, 2, 0]

Before: [2, 2, 3, 1]
11 0 3 1
After:  [2, 1, 3, 1]

Before: [3, 2, 1, 1]
14 2 1 1
After:  [3, 2, 1, 1]

Before: [3, 1, 3, 1]
9 1 2 1
After:  [3, 0, 3, 1]

Before: [2, 1, 0, 1]
1 1 3 3
After:  [2, 1, 0, 1]

Before: [1, 1, 3, 1]
0 1 0 3
After:  [1, 1, 3, 1]

Before: [2, 2, 2, 1]
4 3 2 0
After:  [1, 2, 2, 1]

Before: [1, 3, 2, 2]
2 0 2 0
After:  [0, 3, 2, 2]

Before: [2, 1, 3, 3]
9 1 2 0
After:  [0, 1, 3, 3]

Before: [3, 0, 2, 0]
8 0 2 0
After:  [1, 0, 2, 0]

Before: [1, 1, 1, 3]
0 1 0 1
After:  [1, 1, 1, 3]

Before: [2, 1, 2, 1]
11 0 3 0
After:  [1, 1, 2, 1]

Before: [1, 1, 2, 1]
2 0 2 0
After:  [0, 1, 2, 1]

Before: [1, 1, 0, 0]
3 0 2 0
After:  [0, 1, 0, 0]

Before: [0, 3, 1, 1]
15 0 0 0
After:  [1, 3, 1, 1]

Before: [1, 3, 2, 3]
6 2 3 0
After:  [0, 3, 2, 3]

Before: [0, 0, 1, 2]
13 3 3 1
After:  [0, 0, 1, 2]

Before: [1, 1, 2, 1]
4 3 2 3
After:  [1, 1, 2, 1]

Before: [1, 2, 1, 3]
14 2 1 0
After:  [2, 2, 1, 3]

Before: [0, 3, 1, 1]
10 0 0 3
After:  [0, 3, 1, 0]

Before: [2, 3, 1, 1]
13 2 3 1
After:  [2, 0, 1, 1]

Before: [3, 1, 2, 1]
4 3 2 3
After:  [3, 1, 2, 1]

Before: [2, 2, 1, 1]
11 0 3 1
After:  [2, 1, 1, 1]

Before: [0, 2, 2, 2]
10 0 0 2
After:  [0, 2, 0, 2]

Before: [0, 0, 2, 1]
4 3 2 0
After:  [1, 0, 2, 1]

Before: [3, 1, 1, 3]
5 2 1 2
After:  [3, 1, 2, 3]

Before: [2, 2, 0, 3]
6 1 3 1
After:  [2, 0, 0, 3]

Before: [3, 0, 2, 1]
4 3 2 2
After:  [3, 0, 1, 1]

Before: [3, 0, 2, 1]
8 0 2 3
After:  [3, 0, 2, 1]

Before: [3, 1, 0, 0]
7 0 2 3
After:  [3, 1, 0, 1]

Before: [2, 1, 3, 2]
9 1 2 2
After:  [2, 1, 0, 2]

Before: [0, 2, 2, 0]
10 0 0 0
After:  [0, 2, 2, 0]

Before: [1, 2, 2, 1]
4 3 2 2
After:  [1, 2, 1, 1]

Before: [2, 1, 1, 0]
8 0 1 2
After:  [2, 1, 1, 0]

Before: [1, 0, 2, 3]
6 2 3 2
After:  [1, 0, 0, 3]

Before: [1, 1, 2, 3]
6 1 3 2
After:  [1, 1, 0, 3]

Before: [2, 3, 2, 1]
4 3 2 0
After:  [1, 3, 2, 1]

Before: [1, 2, 1, 0]
14 2 1 3
After:  [1, 2, 1, 2]

Before: [1, 1, 0, 3]
0 1 0 1
After:  [1, 1, 0, 3]

Before: [2, 2, 1, 3]
15 3 3 0
After:  [1, 2, 1, 3]

Before: [0, 2, 1, 3]
10 0 0 1
After:  [0, 0, 1, 3]

Before: [1, 1, 3, 2]
0 1 0 2
After:  [1, 1, 1, 2]

Before: [2, 0, 3, 1]
11 0 3 3
After:  [2, 0, 3, 1]

Before: [2, 1, 2, 3]
12 1 2 1
After:  [2, 0, 2, 3]

Before: [1, 1, 0, 0]
3 0 2 2
After:  [1, 1, 0, 0]

Before: [3, 1, 1, 1]
13 3 3 0
After:  [0, 1, 1, 1]

Before: [0, 0, 2, 3]
10 0 0 3
After:  [0, 0, 2, 0]

Before: [3, 1, 3, 1]
9 1 2 0
After:  [0, 1, 3, 1]

Before: [1, 1, 2, 0]
0 1 0 0
After:  [1, 1, 2, 0]

Before: [0, 1, 2, 3]
6 2 3 1
After:  [0, 0, 2, 3]

Before: [2, 1, 3, 3]
9 1 2 1
After:  [2, 0, 3, 3]

Before: [1, 2, 1, 3]
14 2 1 1
After:  [1, 2, 1, 3]

Before: [0, 1, 2, 2]
10 0 0 3
After:  [0, 1, 2, 0]

Before: [2, 1, 2, 0]
12 1 2 1
After:  [2, 0, 2, 0]

Before: [1, 1, 0, 1]
1 1 3 1
After:  [1, 1, 0, 1]

Before: [1, 3, 2, 3]
15 3 2 3
After:  [1, 3, 2, 0]

Before: [1, 2, 2, 2]
7 3 2 2
After:  [1, 2, 0, 2]

Before: [3, 3, 2, 0]
8 0 2 3
After:  [3, 3, 2, 1]

Before: [0, 3, 1, 1]
10 0 0 0
After:  [0, 3, 1, 1]

Before: [0, 1, 1, 2]
13 3 3 0
After:  [0, 1, 1, 2]

Before: [1, 1, 1, 0]
5 2 1 1
After:  [1, 2, 1, 0]

Before: [1, 2, 0, 1]
3 0 2 1
After:  [1, 0, 0, 1]

Before: [3, 1, 3, 1]
9 1 2 3
After:  [3, 1, 3, 0]

Before: [1, 2, 2, 3]
2 0 2 0
After:  [0, 2, 2, 3]

Before: [0, 3, 2, 1]
4 3 2 2
After:  [0, 3, 1, 1]

Before: [1, 2, 2, 1]
15 2 1 0
After:  [1, 2, 2, 1]

Before: [2, 0, 3, 0]
7 2 0 1
After:  [2, 1, 3, 0]

Before: [1, 3, 2, 1]
4 3 2 1
After:  [1, 1, 2, 1]

Before: [1, 3, 0, 1]
3 0 2 0
After:  [0, 3, 0, 1]

Before: [3, 1, 1, 1]
13 2 3 1
After:  [3, 0, 1, 1]

Before: [2, 2, 3, 1]
11 0 3 3
After:  [2, 2, 3, 1]

Before: [3, 3, 2, 1]
15 2 2 3
After:  [3, 3, 2, 1]

Before: [3, 0, 3, 3]
15 3 2 3
After:  [3, 0, 3, 1]

Before: [1, 1, 0, 1]
3 0 2 1
After:  [1, 0, 0, 1]

Before: [1, 1, 0, 2]
0 1 0 3
After:  [1, 1, 0, 1]

Before: [0, 0, 2, 1]
10 0 0 1
After:  [0, 0, 2, 1]

Before: [1, 1, 3, 0]
0 1 0 1
After:  [1, 1, 3, 0]

Before: [1, 0, 0, 3]
3 0 2 0
After:  [0, 0, 0, 3]

Before: [0, 2, 1, 3]
10 0 0 0
After:  [0, 2, 1, 3]

Before: [3, 1, 2, 0]
12 1 2 3
After:  [3, 1, 2, 0]

Before: [2, 1, 3, 0]
8 0 1 0
After:  [1, 1, 3, 0]

Before: [1, 0, 2, 1]
4 3 2 1
After:  [1, 1, 2, 1]

Before: [2, 1, 2, 3]
6 1 3 0
After:  [0, 1, 2, 3]

Before: [1, 1, 0, 0]
0 1 0 3
After:  [1, 1, 0, 1]

Before: [3, 1, 1, 3]
7 2 1 3
After:  [3, 1, 1, 0]

Before: [0, 2, 1, 1]
14 2 1 2
After:  [0, 2, 2, 1]

Before: [2, 1, 0, 1]
11 0 3 3
After:  [2, 1, 0, 1]

Before: [1, 1, 2, 3]
0 1 0 1
After:  [1, 1, 2, 3]

Before: [2, 1, 3, 0]
9 1 2 0
After:  [0, 1, 3, 0]

Before: [0, 2, 1, 3]
6 1 3 0
After:  [0, 2, 1, 3]

Before: [1, 1, 3, 2]
0 1 0 0
After:  [1, 1, 3, 2]

Before: [0, 2, 1, 3]
14 2 1 0
After:  [2, 2, 1, 3]

Before: [0, 0, 1, 1]
13 3 3 1
After:  [0, 0, 1, 1]

Before: [2, 1, 1, 0]
5 2 1 0
After:  [2, 1, 1, 0]

Before: [3, 1, 1, 1]
13 3 3 3
After:  [3, 1, 1, 0]

Before: [1, 1, 2, 1]
1 1 3 1
After:  [1, 1, 2, 1]

Before: [0, 1, 2, 1]
1 1 3 2
After:  [0, 1, 1, 1]

Before: [0, 1, 1, 2]
5 2 1 1
After:  [0, 2, 1, 2]

Before: [2, 1, 1, 2]
8 0 1 1
After:  [2, 1, 1, 2]

Before: [2, 1, 1, 2]
8 0 1 0
After:  [1, 1, 1, 2]

Before: [2, 1, 1, 1]
5 2 1 1
After:  [2, 2, 1, 1]

Before: [3, 2, 1, 0]
14 2 1 2
After:  [3, 2, 2, 0]

Before: [2, 3, 0, 1]
11 0 3 0
After:  [1, 3, 0, 1]

Before: [0, 1, 1, 0]
5 2 1 1
After:  [0, 2, 1, 0]

Before: [3, 3, 0, 3]
7 0 2 1
After:  [3, 1, 0, 3]

Before: [1, 1, 2, 3]
6 2 3 1
After:  [1, 0, 2, 3]

Before: [1, 1, 2, 0]
2 0 2 0
After:  [0, 1, 2, 0]

Before: [3, 0, 2, 3]
8 0 2 0
After:  [1, 0, 2, 3]

Before: [0, 1, 1, 1]
1 1 3 3
After:  [0, 1, 1, 1]

Before: [2, 1, 2, 2]
12 1 2 1
After:  [2, 0, 2, 2]

Before: [3, 3, 2, 1]
4 3 2 3
After:  [3, 3, 2, 1]

Before: [1, 2, 2, 3]
2 0 2 3
After:  [1, 2, 2, 0]

Before: [1, 1, 0, 1]
0 1 0 2
After:  [1, 1, 1, 1]

Before: [0, 2, 2, 1]
4 3 2 3
After:  [0, 2, 2, 1]

Before: [0, 1, 1, 1]
7 3 1 0
After:  [0, 1, 1, 1]

Before: [2, 0, 0, 1]
11 0 3 3
After:  [2, 0, 0, 1]

Before: [1, 1, 2, 2]
0 1 0 1
After:  [1, 1, 2, 2]

Before: [1, 2, 0, 3]
3 0 2 1
After:  [1, 0, 0, 3]

Before: [1, 1, 3, 3]
9 1 2 2
After:  [1, 1, 0, 3]

Before: [3, 1, 3, 0]
9 1 2 3
After:  [3, 1, 3, 0]

Before: [1, 1, 1, 2]
0 1 0 1
After:  [1, 1, 1, 2]

Before: [0, 1, 2, 1]
4 3 2 2
After:  [0, 1, 1, 1]

Before: [1, 1, 1, 0]
5 2 1 2
After:  [1, 1, 2, 0]

Before: [1, 1, 3, 3]
6 1 3 3
After:  [1, 1, 3, 0]

Before: [0, 1, 0, 1]
7 3 1 0
After:  [0, 1, 0, 1]

Before: [3, 1, 1, 1]
1 1 3 0
After:  [1, 1, 1, 1]

Before: [2, 1, 2, 1]
4 3 2 0
After:  [1, 1, 2, 1]

Before: [2, 3, 1, 1]
13 3 3 1
After:  [2, 0, 1, 1]

Before: [2, 0, 3, 1]
11 0 3 2
After:  [2, 0, 1, 1]

Before: [0, 1, 3, 0]
9 1 2 0
After:  [0, 1, 3, 0]

Before: [1, 2, 2, 3]
2 0 2 1
After:  [1, 0, 2, 3]

Before: [1, 3, 0, 0]
3 0 2 0
After:  [0, 3, 0, 0]

Before: [0, 2, 1, 1]
14 2 1 1
After:  [0, 2, 1, 1]

Before: [1, 2, 2, 2]
2 0 2 1
After:  [1, 0, 2, 2]

Before: [0, 3, 2, 0]
10 0 0 0
After:  [0, 3, 2, 0]

Before: [1, 1, 0, 1]
0 1 0 0
After:  [1, 1, 0, 1]

Before: [3, 1, 2, 2]
7 3 2 1
After:  [3, 0, 2, 2]

Before: [1, 1, 1, 1]
5 2 1 2
After:  [1, 1, 2, 1]

Before: [1, 0, 0, 2]
3 0 2 3
After:  [1, 0, 0, 0]

Before: [1, 1, 3, 0]
0 1 0 3
After:  [1, 1, 3, 1]

Before: [0, 3, 2, 0]
15 0 0 1
After:  [0, 1, 2, 0]

Before: [2, 2, 2, 3]
15 2 2 0
After:  [1, 2, 2, 3]

Before: [1, 1, 1, 1]
0 1 0 3
After:  [1, 1, 1, 1]

Before: [0, 1, 3, 1]
15 2 3 3
After:  [0, 1, 3, 0]

Before: [0, 0, 0, 2]
10 0 0 1
After:  [0, 0, 0, 2]

Before: [1, 3, 0, 3]
3 0 2 3
After:  [1, 3, 0, 0]

Before: [3, 2, 2, 2]
8 0 2 1
After:  [3, 1, 2, 2]

Before: [2, 1, 2, 3]
6 1 3 2
After:  [2, 1, 0, 3]

Before: [3, 1, 1, 1]
5 2 1 3
After:  [3, 1, 1, 2]

Before: [0, 0, 3, 1]
10 0 0 3
After:  [0, 0, 3, 0]

Before: [3, 1, 3, 1]
9 1 2 2
After:  [3, 1, 0, 1]

Before: [1, 2, 2, 1]
13 3 3 0
After:  [0, 2, 2, 1]

Before: [1, 0, 0, 2]
13 3 3 0
After:  [0, 0, 0, 2]

Before: [0, 2, 1, 0]
14 2 1 1
After:  [0, 2, 1, 0]

Before: [3, 1, 1, 2]
5 2 1 0
After:  [2, 1, 1, 2]

Before: [2, 1, 0, 3]
8 0 1 2
After:  [2, 1, 1, 3]

Before: [1, 1, 0, 3]
0 1 0 0
After:  [1, 1, 0, 3]

Before: [2, 2, 2, 1]
4 3 2 1
After:  [2, 1, 2, 1]

Before: [1, 3, 0, 3]
3 0 2 2
After:  [1, 3, 0, 3]

Before: [2, 0, 2, 0]
7 0 1 0
After:  [1, 0, 2, 0]

Before: [3, 1, 0, 1]
1 1 3 0
After:  [1, 1, 0, 1]

Before: [1, 1, 0, 0]
3 0 2 3
After:  [1, 1, 0, 0]

Before: [2, 1, 0, 1]
11 0 3 2
After:  [2, 1, 1, 1]

Before: [3, 2, 2, 3]
6 2 3 3
After:  [3, 2, 2, 0]

Before: [2, 0, 0, 3]
7 0 1 2
After:  [2, 0, 1, 3]

Before: [0, 0, 2, 1]
4 3 2 3
After:  [0, 0, 2, 1]

Before: [0, 3, 0, 2]
10 0 0 3
After:  [0, 3, 0, 0]

Before: [2, 0, 2, 2]
7 3 2 3
After:  [2, 0, 2, 0]

Before: [1, 1, 0, 3]
0 1 0 2
After:  [1, 1, 1, 3]

Before: [2, 0, 2, 1]
11 0 3 1
After:  [2, 1, 2, 1]

Before: [1, 2, 3, 3]
15 3 2 0
After:  [1, 2, 3, 3]

Before: [2, 1, 3, 1]
7 3 1 1
After:  [2, 0, 3, 1]

Before: [1, 1, 0, 3]
6 1 3 0
After:  [0, 1, 0, 3]

Before: [1, 0, 0, 0]
3 0 2 2
After:  [1, 0, 0, 0]

Before: [2, 1, 3, 1]
11 0 3 2
After:  [2, 1, 1, 1]

Before: [2, 0, 1, 1]
11 0 3 1
After:  [2, 1, 1, 1]

Before: [1, 1, 1, 3]
0 1 0 3
After:  [1, 1, 1, 1]

Before: [1, 2, 2, 0]
2 0 2 0
After:  [0, 2, 2, 0]

Before: [1, 2, 0, 3]
3 0 2 3
After:  [1, 2, 0, 0]

Before: [1, 3, 2, 1]
4 3 2 3
After:  [1, 3, 2, 1]

Before: [0, 2, 1, 2]
14 2 1 3
After:  [0, 2, 1, 2]

Before: [3, 0, 2, 3]
8 0 2 1
After:  [3, 1, 2, 3]

Before: [0, 1, 1, 3]
10 0 0 3
After:  [0, 1, 1, 0]

Before: [2, 1, 2, 1]
4 3 2 3
After:  [2, 1, 2, 1]

Before: [1, 1, 2, 3]
6 1 3 0
After:  [0, 1, 2, 3]

Before: [2, 1, 1, 2]
5 2 1 0
After:  [2, 1, 1, 2]

Before: [2, 1, 1, 0]
5 2 1 1
After:  [2, 2, 1, 0]

Before: [0, 1, 1, 1]
5 2 1 2
After:  [0, 1, 2, 1]

Before: [2, 3, 1, 1]
11 0 3 1
After:  [2, 1, 1, 1]

Before: [1, 1, 3, 0]
0 1 0 0
After:  [1, 1, 3, 0]

Before: [1, 3, 2, 3]
2 0 2 1
After:  [1, 0, 2, 3]

Before: [0, 1, 1, 1]
5 2 1 3
After:  [0, 1, 1, 2]

Before: [0, 1, 3, 3]
6 1 3 2
After:  [0, 1, 0, 3]

Before: [2, 0, 2, 3]
6 2 3 0
After:  [0, 0, 2, 3]

Before: [2, 2, 3, 1]
7 2 0 3
After:  [2, 2, 3, 1]

Before: [1, 3, 0, 3]
3 0 2 1
After:  [1, 0, 0, 3]

Before: [1, 2, 0, 2]
3 0 2 1
After:  [1, 0, 0, 2]

Before: [2, 2, 1, 1]
14 2 1 0
After:  [2, 2, 1, 1]

Before: [2, 1, 3, 3]
9 1 2 3
After:  [2, 1, 3, 0]

Before: [1, 1, 2, 2]
0 1 0 3
After:  [1, 1, 2, 1]

Before: [0, 1, 1, 3]
15 3 3 3
After:  [0, 1, 1, 1]

Before: [1, 3, 2, 1]
4 3 2 0
After:  [1, 3, 2, 1]

Before: [2, 1, 2, 3]
8 0 1 0
After:  [1, 1, 2, 3]

Before: [1, 0, 2, 3]
2 0 2 3
After:  [1, 0, 2, 0]

Before: [0, 0, 2, 3]
15 3 3 2
After:  [0, 0, 1, 3]

Before: [0, 0, 2, 2]
15 2 2 0
After:  [1, 0, 2, 2]

Before: [3, 3, 2, 2]
8 0 2 1
After:  [3, 1, 2, 2]

Before: [1, 1, 3, 1]
13 3 3 1
After:  [1, 0, 3, 1]

Before: [3, 2, 2, 1]
4 3 2 3
After:  [3, 2, 2, 1]

Before: [1, 1, 3, 1]
1 1 3 0
After:  [1, 1, 3, 1]

Before: [0, 3, 2, 1]
4 3 2 3
After:  [0, 3, 2, 1]

Before: [3, 1, 2, 3]
12 1 2 1
After:  [3, 0, 2, 3]

Before: [1, 2, 1, 2]
14 2 1 1
After:  [1, 2, 1, 2]

Before: [1, 3, 0, 2]
3 0 2 2
After:  [1, 3, 0, 2]

Before: [1, 1, 3, 3]
0 1 0 3
After:  [1, 1, 3, 1]

Before: [3, 3, 2, 1]
4 3 2 1
After:  [3, 1, 2, 1]

Before: [0, 1, 1, 2]
10 0 0 1
After:  [0, 0, 1, 2]

Before: [1, 2, 1, 0]
14 2 1 1
After:  [1, 2, 1, 0]

Before: [2, 1, 0, 1]
1 1 3 2
After:  [2, 1, 1, 1]

Before: [2, 1, 0, 2]
13 3 3 2
After:  [2, 1, 0, 2]

Before: [1, 2, 0, 0]
3 0 2 1
After:  [1, 0, 0, 0]

Before: [3, 2, 1, 1]
14 2 1 3
After:  [3, 2, 1, 2]

Before: [3, 0, 1, 1]
13 2 3 0
After:  [0, 0, 1, 1]

Before: [2, 2, 2, 1]
11 0 3 2
After:  [2, 2, 1, 1]

Before: [2, 1, 1, 1]
1 1 3 2
After:  [2, 1, 1, 1]

Before: [0, 2, 0, 0]
10 0 0 1
After:  [0, 0, 0, 0]

Before: [1, 1, 1, 3]
0 1 0 2
After:  [1, 1, 1, 3]

Before: [3, 2, 2, 3]
8 0 2 2
After:  [3, 2, 1, 3]

Before: [1, 3, 0, 0]
3 0 2 2
After:  [1, 3, 0, 0]

Before: [2, 1, 1, 3]
15 3 3 3
After:  [2, 1, 1, 1]

Before: [2, 1, 0, 1]
11 0 3 1
After:  [2, 1, 0, 1]

Before: [3, 3, 2, 1]
13 3 3 3
After:  [3, 3, 2, 0]

Before: [3, 1, 1, 2]
5 2 1 3
After:  [3, 1, 1, 2]

Before: [1, 1, 3, 3]
6 1 3 0
After:  [0, 1, 3, 3]

Before: [0, 1, 1, 1]
1 1 3 0
After:  [1, 1, 1, 1]

Before: [1, 1, 0, 0]
0 1 0 1
After:  [1, 1, 0, 0]

Before: [1, 1, 2, 3]
2 0 2 0
After:  [0, 1, 2, 3]

Before: [1, 3, 0, 0]
3 0 2 3
After:  [1, 3, 0, 0]

Before: [0, 1, 2, 3]
15 0 0 2
After:  [0, 1, 1, 3]

Before: [0, 0, 2, 2]
10 0 0 3
After:  [0, 0, 2, 0]

Before: [1, 1, 3, 3]
0 1 0 0
After:  [1, 1, 3, 3]

Before: [0, 2, 2, 0]
10 0 0 1
After:  [0, 0, 2, 0]

Before: [0, 3, 3, 0]
10 0 0 1
After:  [0, 0, 3, 0]

Before: [0, 1, 1, 3]
5 2 1 2
After:  [0, 1, 2, 3]

Before: [3, 3, 2, 2]
8 0 2 2
After:  [3, 3, 1, 2]

Before: [2, 3, 3, 1]
11 0 3 3
After:  [2, 3, 3, 1]

Before: [2, 1, 3, 1]
7 3 1 0
After:  [0, 1, 3, 1]

Before: [3, 1, 1, 1]
5 2 1 2
After:  [3, 1, 2, 1]

Before: [3, 1, 3, 1]
1 1 3 3
After:  [3, 1, 3, 1]

Before: [0, 1, 1, 3]
5 2 1 3
After:  [0, 1, 1, 2]

Before: [2, 2, 3, 3]
6 1 3 1
After:  [2, 0, 3, 3]

Before: [3, 2, 1, 3]
15 3 0 1
After:  [3, 1, 1, 3]

Before: [1, 1, 1, 3]
0 1 0 0
After:  [1, 1, 1, 3]

Before: [2, 1, 0, 3]
6 1 3 0
After:  [0, 1, 0, 3]

Before: [1, 2, 2, 2]
15 2 1 2
After:  [1, 2, 1, 2]

Before: [2, 3, 2, 1]
11 0 3 3
After:  [2, 3, 2, 1]

Before: [2, 3, 2, 1]
11 0 3 1
After:  [2, 1, 2, 1]

Before: [1, 1, 2, 2]
2 0 2 0
After:  [0, 1, 2, 2]

Before: [1, 1, 1, 2]
5 2 1 3
After:  [1, 1, 1, 2]

Before: [2, 1, 3, 1]
11 0 3 3
After:  [2, 1, 3, 1]

Before: [2, 2, 1, 2]
14 2 1 1
After:  [2, 2, 1, 2]

Before: [0, 0, 2, 3]
15 3 3 3
After:  [0, 0, 2, 1]

Before: [2, 0, 3, 1]
7 0 1 2
After:  [2, 0, 1, 1]

Before: [3, 1, 3, 2]
9 1 2 0
After:  [0, 1, 3, 2]

Before: [0, 3, 3, 1]
13 3 3 1
After:  [0, 0, 3, 1]

Before: [1, 1, 1, 3]
6 1 3 2
After:  [1, 1, 0, 3]

Before: [3, 2, 2, 0]
15 2 1 1
After:  [3, 1, 2, 0]

Before: [0, 2, 1, 2]
14 2 1 1
After:  [0, 2, 1, 2]

Before: [3, 3, 2, 3]
15 3 3 3
After:  [3, 3, 2, 1]

Before: [2, 1, 1, 3]
5 2 1 2
After:  [2, 1, 2, 3]

Before: [2, 3, 2, 1]
11 0 3 2
After:  [2, 3, 1, 1]

Before: [3, 3, 2, 2]
7 3 2 3
After:  [3, 3, 2, 0]

Before: [1, 1, 3, 3]
0 1 0 2
After:  [1, 1, 1, 3]

Before: [0, 1, 2, 1]
4 3 2 0
After:  [1, 1, 2, 1]

Before: [2, 1, 3, 0]
8 0 1 3
After:  [2, 1, 3, 1]

Before: [2, 1, 1, 3]
6 2 3 1
After:  [2, 0, 1, 3]

Before: [1, 2, 2, 1]
4 3 2 3
After:  [1, 2, 2, 1]

Before: [0, 2, 0, 3]
15 3 1 3
After:  [0, 2, 0, 0]

Before: [0, 3, 2, 1]
4 3 2 1
After:  [0, 1, 2, 1]

Before: [3, 1, 2, 2]
7 3 2 0
After:  [0, 1, 2, 2]

Before: [3, 1, 3, 2]
9 1 2 1
After:  [3, 0, 3, 2]

Before: [1, 1, 1, 1]
0 1 0 2
After:  [1, 1, 1, 1]

Before: [0, 2, 1, 1]
14 2 1 3
After:  [0, 2, 1, 2]

Before: [1, 1, 3, 2]
9 1 2 1
After:  [1, 0, 3, 2]

Before: [2, 0, 2, 1]
11 0 3 2
After:  [2, 0, 1, 1]

Before: [2, 1, 1, 3]
8 0 1 1
After:  [2, 1, 1, 3]

Before: [0, 3, 2, 2]
10 0 0 2
After:  [0, 3, 0, 2]

Before: [1, 2, 0, 0]
3 0 2 2
After:  [1, 2, 0, 0]

Before: [3, 0, 2, 1]
4 3 2 1
After:  [3, 1, 2, 1]

Before: [2, 1, 1, 1]
11 0 3 2
After:  [2, 1, 1, 1]

Before: [2, 1, 1, 2]
5 2 1 1
After:  [2, 2, 1, 2]

Before: [1, 1, 0, 1]
1 1 3 0
After:  [1, 1, 0, 1]

Before: [0, 3, 3, 1]
13 3 3 0
After:  [0, 3, 3, 1]

Before: [0, 3, 2, 2]
10 0 0 0
After:  [0, 3, 2, 2]

Before: [3, 1, 2, 1]
1 1 3 3
After:  [3, 1, 2, 1]

Before: [2, 0, 3, 2]
7 0 1 1
After:  [2, 1, 3, 2]

Before: [0, 1, 3, 0]
9 1 2 3
After:  [0, 1, 3, 0]

Before: [1, 1, 2, 3]
12 1 2 3
After:  [1, 1, 2, 0]

Before: [1, 1, 2, 3]
0 1 0 3
After:  [1, 1, 2, 1]

Before: [1, 3, 0, 1]
3 0 2 3
After:  [1, 3, 0, 0]

Before: [1, 1, 2, 2]
12 1 2 1
After:  [1, 0, 2, 2]

Before: [3, 2, 1, 3]
14 2 1 2
After:  [3, 2, 2, 3]

Before: [2, 2, 1, 0]
14 2 1 2
After:  [2, 2, 2, 0]

Before: [2, 1, 3, 1]
1 1 3 0
After:  [1, 1, 3, 1]

Before: [1, 1, 1, 1]
5 2 1 0
After:  [2, 1, 1, 1]

Before: [3, 1, 1, 3]
5 2 1 0
After:  [2, 1, 1, 3]

Before: [1, 1, 0, 1]
0 1 0 3
After:  [1, 1, 0, 1]

Before: [0, 3, 1, 3]
10 0 0 2
After:  [0, 3, 0, 3]

Before: [1, 0, 0, 1]
3 0 2 3
After:  [1, 0, 0, 0]

Before: [0, 2, 1, 3]
14 2 1 3
After:  [0, 2, 1, 2]

Before: [1, 1, 3, 2]
15 2 1 2
After:  [1, 1, 0, 2]

Before: [3, 1, 3, 3]
9 1 2 0
After:  [0, 1, 3, 3]

Before: [2, 0, 2, 1]
4 3 2 2
After:  [2, 0, 1, 1]

Before: [2, 0, 2, 2]
7 3 2 1
After:  [2, 0, 2, 2]

Before: [2, 3, 2, 3]
15 3 2 0
After:  [0, 3, 2, 3]

Before: [2, 1, 1, 0]
7 2 1 0
After:  [0, 1, 1, 0]

Before: [1, 0, 0, 2]
3 0 2 2
After:  [1, 0, 0, 2]

Before: [1, 2, 2, 1]
4 3 2 0
After:  [1, 2, 2, 1]

Before: [0, 2, 1, 1]
10 0 0 3
After:  [0, 2, 1, 0]

Before: [3, 3, 2, 1]
8 0 2 3
After:  [3, 3, 2, 1]

Before: [3, 3, 2, 1]
8 0 2 0
After:  [1, 3, 2, 1]

Before: [2, 1, 1, 1]
8 0 1 1
After:  [2, 1, 1, 1]

Before: [1, 1, 2, 2]
2 0 2 2
After:  [1, 1, 0, 2]

Before: [1, 3, 2, 2]
2 0 2 2
After:  [1, 3, 0, 2]

Before: [2, 1, 1, 3]
5 2 1 1
After:  [2, 2, 1, 3]

Before: [2, 1, 3, 2]
8 0 1 1
After:  [2, 1, 3, 2]

Before: [0, 1, 3, 3]
15 2 1 1
After:  [0, 0, 3, 3]

Before: [1, 1, 2, 1]
0 1 0 3
After:  [1, 1, 2, 1]

Before: [3, 2, 0, 3]
6 1 3 1
After:  [3, 0, 0, 3]

Before: [2, 1, 2, 2]
8 0 1 3
After:  [2, 1, 2, 1]

Before: [0, 3, 0, 0]
10 0 0 0
After:  [0, 3, 0, 0]

Before: [3, 1, 1, 0]
5 2 1 3
After:  [3, 1, 1, 2]

Before: [1, 1, 0, 2]
3 0 2 2
After:  [1, 1, 0, 2]

Before: [0, 1, 2, 3]
6 1 3 1
After:  [0, 0, 2, 3]

Before: [0, 3, 1, 1]
13 3 3 1
After:  [0, 0, 1, 1]

Before: [0, 1, 2, 1]
7 3 1 1
After:  [0, 0, 2, 1]

Before: [1, 0, 0, 0]
3 0 2 0
After:  [0, 0, 0, 0]

Before: [3, 1, 2, 1]
1 1 3 2
After:  [3, 1, 1, 1]

Before: [1, 3, 2, 1]
2 0 2 0
After:  [0, 3, 2, 1]

Before: [0, 1, 2, 3]
12 1 2 1
After:  [0, 0, 2, 3]

Before: [1, 1, 0, 2]
13 3 3 1
After:  [1, 0, 0, 2]

Before: [0, 1, 2, 3]
10 0 0 1
After:  [0, 0, 2, 3]

Before: [1, 3, 2, 0]
2 0 2 3
After:  [1, 3, 2, 0]

Before: [1, 1, 2, 1]
1 1 3 0
After:  [1, 1, 2, 1]

Before: [1, 1, 2, 0]
12 1 2 3
After:  [1, 1, 2, 0]

Before: [2, 3, 1, 1]
11 0 3 3
After:  [2, 3, 1, 1]

Before: [3, 3, 0, 2]
7 0 2 3
After:  [3, 3, 0, 1]

Before: [0, 3, 0, 1]
10 0 0 1
After:  [0, 0, 0, 1]

Before: [3, 3, 1, 2]
13 3 3 1
After:  [3, 0, 1, 2]

Before: [1, 1, 3, 2]
0 1 0 3
After:  [1, 1, 3, 1]

Before: [3, 3, 2, 2]
8 0 2 0
After:  [1, 3, 2, 2]

Before: [3, 2, 1, 0]
14 2 1 0
After:  [2, 2, 1, 0]

Before: [1, 1, 3, 2]
13 3 3 2
After:  [1, 1, 0, 2]

Before: [2, 1, 2, 2]
7 3 2 1
After:  [2, 0, 2, 2]

Before: [1, 3, 2, 1]
2 0 2 1
After:  [1, 0, 2, 1]

Before: [1, 1, 3, 1]
0 1 0 1
After:  [1, 1, 3, 1]

Before: [2, 0, 3, 1]
11 0 3 1
After:  [2, 1, 3, 1]

Before: [0, 2, 1, 0]
14 2 1 0
After:  [2, 2, 1, 0]

Before: [1, 1, 3, 1]
9 1 2 1
After:  [1, 0, 3, 1]

Before: [3, 1, 3, 3]
9 1 2 3
After:  [3, 1, 3, 0]

Before: [2, 0, 2, 1]
4 3 2 3
After:  [2, 0, 2, 1]

Before: [1, 1, 2, 2]
12 1 2 0
After:  [0, 1, 2, 2]

Before: [2, 0, 3, 1]
7 2 0 0
After:  [1, 0, 3, 1]

Before: [1, 3, 2, 2]
7 3 2 2
After:  [1, 3, 0, 2]

Before: [1, 1, 1, 0]
0 1 0 1
After:  [1, 1, 1, 0]

Before: [2, 2, 1, 3]
14 2 1 1
After:  [2, 2, 1, 3]

Before: [1, 3, 3, 1]
13 3 3 3
After:  [1, 3, 3, 0]

Before: [3, 2, 2, 3]
6 1 3 1
After:  [3, 0, 2, 3]

Before: [1, 1, 0, 0]
3 0 2 1
After:  [1, 0, 0, 0]

Before: [1, 2, 1, 3]
14 2 1 3
After:  [1, 2, 1, 2]

Before: [3, 2, 2, 2]
7 3 2 2
After:  [3, 2, 0, 2]

Before: [1, 2, 0, 2]
3 0 2 3
After:  [1, 2, 0, 0]

Before: [0, 1, 2, 1]
1 1 3 0
After:  [1, 1, 2, 1]

Before: [1, 1, 0, 1]
3 0 2 3
After:  [1, 1, 0, 0]

Before: [0, 2, 3, 0]
10 0 0 3
After:  [0, 2, 3, 0]

Before: [2, 1, 2, 3]
12 1 2 0
After:  [0, 1, 2, 3]

Before: [2, 1, 2, 2]
12 1 2 0
After:  [0, 1, 2, 2]

Before: [0, 1, 3, 2]
10 0 0 3
After:  [0, 1, 3, 0]

Before: [3, 0, 2, 1]
4 3 2 3
After:  [3, 0, 2, 1]

Before: [1, 2, 2, 3]
15 2 1 3
After:  [1, 2, 2, 1]

Before: [0, 0, 1, 2]
10 0 0 1
After:  [0, 0, 1, 2]

Before: [1, 2, 1, 2]
14 2 1 0
After:  [2, 2, 1, 2]

Before: [2, 1, 3, 3]
9 1 2 2
After:  [2, 1, 0, 3]

Before: [2, 2, 2, 2]
15 2 0 0
After:  [1, 2, 2, 2]

Before: [1, 1, 3, 2]
9 1 2 2
After:  [1, 1, 0, 2]

Before: [1, 2, 0, 2]
13 3 3 3
After:  [1, 2, 0, 0]

Before: [0, 2, 1, 0]
14 2 1 2
After:  [0, 2, 2, 0]

Before: [2, 2, 1, 1]
13 3 3 2
After:  [2, 2, 0, 1]

Before: [2, 1, 1, 2]
7 2 1 3
After:  [2, 1, 1, 0]

Before: [2, 0, 3, 2]
13 3 3 1
After:  [2, 0, 3, 2]

Before: [0, 2, 1, 1]
14 2 1 0
After:  [2, 2, 1, 1]

Before: [1, 2, 2, 1]
2 0 2 2
After:  [1, 2, 0, 1]

Before: [0, 1, 1, 3]
10 0 0 0
After:  [0, 1, 1, 3]

Before: [0, 3, 2, 2]
7 3 2 1
After:  [0, 0, 2, 2]

Before: [0, 1, 1, 2]
5 2 1 2
After:  [0, 1, 2, 2]

Before: [1, 1, 2, 0]
2 0 2 1
After:  [1, 0, 2, 0]

Before: [0, 1, 3, 1]
13 3 3 2
After:  [0, 1, 0, 1]

Before: [0, 2, 1, 3]
14 2 1 2
After:  [0, 2, 2, 3]

Before: [0, 1, 2, 3]
12 1 2 2
After:  [0, 1, 0, 3]

Before: [2, 1, 2, 0]
8 0 1 2
After:  [2, 1, 1, 0]

Before: [0, 1, 0, 1]
1 1 3 1
After:  [0, 1, 0, 1]

Before: [2, 2, 2, 1]
4 3 2 3
After:  [2, 2, 2, 1]

Before: [0, 0, 1, 0]
10 0 0 3
After:  [0, 0, 1, 0]

Before: [2, 1, 3, 0]
8 0 1 2
After:  [2, 1, 1, 0]

Before: [0, 1, 3, 1]
9 1 2 0
After:  [0, 1, 3, 1]

Before: [1, 0, 2, 1]
4 3 2 2
After:  [1, 0, 1, 1]

Before: [1, 1, 3, 1]
1 1 3 3
After:  [1, 1, 3, 1]

Before: [3, 1, 2, 2]
15 2 2 2
After:  [3, 1, 1, 2]

Before: [2, 3, 3, 2]
7 2 0 2
After:  [2, 3, 1, 2]

Before: [1, 1, 3, 1]
15 2 1 2
After:  [1, 1, 0, 1]

Before: [2, 2, 1, 2]
14 2 1 0
After:  [2, 2, 1, 2]

Before: [2, 2, 1, 0]
14 2 1 1
After:  [2, 2, 1, 0]

Before: [0, 2, 3, 1]
13 3 3 3
After:  [0, 2, 3, 0]

Before: [2, 1, 0, 2]
8 0 1 1
After:  [2, 1, 0, 2]

Before: [1, 3, 2, 3]
2 0 2 2
After:  [1, 3, 0, 3]

Before: [0, 0, 2, 0]
10 0 0 0
After:  [0, 0, 2, 0]

Before: [1, 1, 1, 1]
7 3 1 3
After:  [1, 1, 1, 0]

Before: [2, 1, 1, 1]
1 1 3 3
After:  [2, 1, 1, 1]

Before: [3, 2, 1, 2]
14 2 1 3
After:  [3, 2, 1, 2]

Before: [2, 2, 0, 1]
11 0 3 2
After:  [2, 2, 1, 1]

Before: [0, 1, 3, 1]
1 1 3 1
After:  [0, 1, 3, 1]

Before: [0, 2, 0, 2]
10 0 0 2
After:  [0, 2, 0, 2]

Before: [2, 2, 1, 3]
6 1 3 2
After:  [2, 2, 0, 3]

Before: [1, 3, 0, 2]
3 0 2 0
After:  [0, 3, 0, 2]

Before: [3, 1, 1, 0]
7 2 1 0
After:  [0, 1, 1, 0]

Before: [1, 1, 0, 1]
0 1 0 1
After:  [1, 1, 0, 1]

Before: [3, 1, 3, 0]
9 1 2 1
After:  [3, 0, 3, 0]

Before: [1, 2, 0, 1]
3 0 2 3
After:  [1, 2, 0, 0]

Before: [3, 0, 2, 1]
13 3 3 0
After:  [0, 0, 2, 1]

Before: [2, 1, 2, 2]
13 3 3 2
After:  [2, 1, 0, 2]

Before: [1, 1, 3, 1]
9 1 2 3
After:  [1, 1, 3, 0]

Before: [1, 1, 3, 1]
1 1 3 2
After:  [1, 1, 1, 1]

Before: [2, 1, 2, 1]
8 0 1 0
After:  [1, 1, 2, 1]

Before: [3, 1, 3, 3]
6 1 3 3
After:  [3, 1, 3, 0]

Before: [0, 3, 1, 2]
10 0 0 3
After:  [0, 3, 1, 0]

Before: [0, 1, 2, 0]
12 1 2 0
After:  [0, 1, 2, 0]

Before: [2, 0, 3, 1]
13 3 3 0
After:  [0, 0, 3, 1]

Before: [0, 1, 1, 3]
6 1 3 1
After:  [0, 0, 1, 3]

Before: [0, 1, 2, 2]
12 1 2 1
After:  [0, 0, 2, 2]

Before: [2, 0, 2, 2]
7 0 1 2
After:  [2, 0, 1, 2]

Before: [1, 0, 2, 2]
2 0 2 1
After:  [1, 0, 2, 2]

Before: [3, 0, 2, 1]
4 3 2 0
After:  [1, 0, 2, 1]

Before: [1, 1, 1, 0]
0 1 0 2
After:  [1, 1, 1, 0]

Before: [3, 3, 2, 1]
4 3 2 2
After:  [3, 3, 1, 1]

Before: [1, 1, 2, 2]
12 1 2 3
After:  [1, 1, 2, 0]

Before: [3, 2, 3, 3]
15 3 1 2
After:  [3, 2, 0, 3]

Before: [0, 1, 3, 2]
9 1 2 1
After:  [0, 0, 3, 2]

Before: [2, 1, 0, 1]
1 1 3 1
After:  [2, 1, 0, 1]

Before: [0, 1, 3, 1]
9 1 2 1
After:  [0, 0, 3, 1]

Before: [1, 2, 1, 2]
14 2 1 2
After:  [1, 2, 2, 2]

Before: [3, 1, 0, 1]
1 1 3 1
After:  [3, 1, 0, 1]

Before: [2, 1, 1, 3]
5 2 1 3
After:  [2, 1, 1, 2]

Before: [3, 2, 2, 1]
4 3 2 2
After:  [3, 2, 1, 1]

Before: [2, 1, 2, 1]
4 3 2 2
After:  [2, 1, 1, 1]

Before: [0, 1, 1, 2]
13 3 3 3
After:  [0, 1, 1, 0]

Before: [1, 2, 2, 0]
2 0 2 3
After:  [1, 2, 2, 0]

Before: [0, 2, 1, 3]
6 2 3 2
After:  [0, 2, 0, 3]

Before: [0, 1, 2, 1]
4 3 2 1
After:  [0, 1, 2, 1]

Before: [2, 2, 1, 1]
14 2 1 1
After:  [2, 2, 1, 1]

Before: [2, 1, 2, 3]
12 1 2 2
After:  [2, 1, 0, 3]

Before: [3, 1, 2, 1]
12 1 2 2
After:  [3, 1, 0, 1]

Before: [2, 1, 2, 1]
1 1 3 1
After:  [2, 1, 2, 1]

Before: [1, 2, 2, 0]
2 0 2 1
After:  [1, 0, 2, 0]

Before: [2, 1, 2, 2]
8 0 1 1
After:  [2, 1, 2, 2]

Before: [2, 1, 1, 3]
5 2 1 0
After:  [2, 1, 1, 3]

Before: [3, 1, 3, 3]
9 1 2 2
After:  [3, 1, 0, 3]

Before: [2, 3, 2, 1]
4 3 2 2
After:  [2, 3, 1, 1]

Before: [3, 3, 1, 1]
13 3 3 1
After:  [3, 0, 1, 1]

Before: [0, 1, 1, 2]
10 0 0 3
After:  [0, 1, 1, 0]

Before: [2, 0, 1, 1]
11 0 3 3
After:  [2, 0, 1, 1]

Before: [3, 1, 3, 1]
1 1 3 1
After:  [3, 1, 3, 1]

Before: [2, 1, 3, 1]
9 1 2 2
After:  [2, 1, 0, 1]

Before: [0, 1, 2, 1]
10 0 0 3
After:  [0, 1, 2, 0]

Before: [1, 0, 2, 2]
2 0 2 0
After:  [0, 0, 2, 2]

Before: [0, 1, 3, 3]
9 1 2 2
After:  [0, 1, 0, 3]

Before: [1, 1, 0, 3]
0 1 0 3
After:  [1, 1, 0, 1]

Before: [3, 3, 2, 0]
8 0 2 0
After:  [1, 3, 2, 0]

Before: [1, 1, 2, 3]
12 1 2 1
After:  [1, 0, 2, 3]

Before: [2, 1, 2, 1]
12 1 2 0
After:  [0, 1, 2, 1]

Before: [1, 0, 2, 1]
4 3 2 0
After:  [1, 0, 2, 1]

Before: [1, 2, 0, 2]
3 0 2 2
After:  [1, 2, 0, 2]

Before: [2, 3, 2, 1]
4 3 2 3
After:  [2, 3, 2, 1]

Before: [0, 1, 2, 1]
1 1 3 1
After:  [0, 1, 2, 1]

Before: [2, 1, 2, 1]
11 0 3 3
After:  [2, 1, 2, 1]

Before: [0, 0, 2, 1]
4 3 2 1
After:  [0, 1, 2, 1]

Before: [2, 1, 2, 2]
15 2 0 0
After:  [1, 1, 2, 2]

Before: [2, 1, 3, 1]
9 1 2 3
After:  [2, 1, 3, 0]

Before: [1, 1, 3, 0]
9 1 2 1
After:  [1, 0, 3, 0]

Before: [0, 1, 1, 1]
13 3 3 3
After:  [0, 1, 1, 0]

Before: [2, 3, 1, 3]
6 2 3 2
After:  [2, 3, 0, 3]

Before: [2, 1, 1, 1]
1 1 3 1
After:  [2, 1, 1, 1]

Before: [0, 3, 1, 3]
10 0 0 3
After:  [0, 3, 1, 0]

Before: [2, 1, 3, 2]
9 1 2 1
After:  [2, 0, 3, 2]

Before: [2, 2, 2, 1]
13 3 3 0
After:  [0, 2, 2, 1]

Before: [3, 3, 2, 3]
8 0 2 2
After:  [3, 3, 1, 3]

Before: [1, 1, 0, 2]
0 1 0 1
After:  [1, 1, 0, 2]

Before: [1, 2, 2, 3]
2 0 2 2
After:  [1, 2, 0, 3]

Before: [1, 1, 1, 3]
5 2 1 3
After:  [1, 1, 1, 2]

Before: [2, 1, 1, 1]
8 0 1 3
After:  [2, 1, 1, 1]

Before: [0, 2, 1, 3]
14 2 1 1
After:  [0, 2, 1, 3]

Before: [1, 1, 0, 3]
3 0 2 1
After:  [1, 0, 0, 3]

Before: [0, 1, 1, 0]
5 2 1 3
After:  [0, 1, 1, 2]

Before: [3, 0, 0, 1]
7 0 2 0
After:  [1, 0, 0, 1]

Before: [2, 1, 3, 0]
9 1 2 1
After:  [2, 0, 3, 0]

Before: [2, 1, 1, 3]
6 1 3 2
After:  [2, 1, 0, 3]

Before: [1, 1, 0, 0]
0 1 0 2
After:  [1, 1, 1, 0]

Before: [2, 1, 0, 1]
1 1 3 0
After:  [1, 1, 0, 1]

Before: [3, 1, 1, 1]
1 1 3 2
After:  [3, 1, 1, 1]

Before: [0, 3, 1, 1]
13 2 3 3
After:  [0, 3, 1, 0]

Before: [2, 2, 1, 0]
14 2 1 3
After:  [2, 2, 1, 2]

Before: [1, 1, 3, 0]
9 1 2 3
After:  [1, 1, 3, 0]

Before: [2, 2, 0, 1]
11 0 3 0
After:  [1, 2, 0, 1]

Before: [1, 1, 2, 1]
4 3 2 1
After:  [1, 1, 2, 1]

Before: [2, 1, 2, 1]
11 0 3 2
After:  [2, 1, 1, 1]

Before: [2, 0, 3, 3]
7 2 0 2
After:  [2, 0, 1, 3]

Before: [3, 1, 2, 1]
1 1 3 1
After:  [3, 1, 2, 1]

Before: [1, 1, 2, 1]
1 1 3 2
After:  [1, 1, 1, 1]

Before: [2, 1, 3, 2]
7 2 0 3
After:  [2, 1, 3, 1]

Before: [1, 1, 3, 0]
0 1 0 2
After:  [1, 1, 1, 0]

Before: [0, 2, 3, 3]
15 0 0 1
After:  [0, 1, 3, 3]

Before: [3, 1, 1, 1]
1 1 3 3
After:  [3, 1, 1, 1]

Before: [0, 0, 1, 3]
6 2 3 3
After:  [0, 0, 1, 0]

Before: [2, 1, 0, 1]
7 3 1 1
After:  [2, 0, 0, 1]

Before: [1, 1, 3, 1]
15 2 3 3
After:  [1, 1, 3, 0]

Before: [1, 1, 3, 2]
0 1 0 1
After:  [1, 1, 3, 2]

Before: [0, 1, 3, 3]
6 1 3 1
After:  [0, 0, 3, 3]

Before: [0, 1, 2, 3]
6 2 3 3
After:  [0, 1, 2, 0]

Before: [0, 2, 3, 3]
10 0 0 0
After:  [0, 2, 3, 3]

Before: [2, 1, 0, 0]
8 0 1 2
After:  [2, 1, 1, 0]

Before: [2, 1, 3, 0]
15 2 1 1
After:  [2, 0, 3, 0]

Before: [0, 2, 1, 3]
15 3 1 0
After:  [0, 2, 1, 3]

Before: [0, 1, 3, 1]
1 1 3 0
After:  [1, 1, 3, 1]

Before: [2, 0, 2, 1]
13 3 3 1
After:  [2, 0, 2, 1]

Before: [2, 2, 1, 3]
6 1 3 3
After:  [2, 2, 1, 0]

Before: [2, 0, 2, 2]
7 3 2 0
After:  [0, 0, 2, 2]

Before: [3, 1, 1, 0]
5 2 1 2
After:  [3, 1, 2, 0]

Before: [2, 1, 3, 1]
8 0 1 3
After:  [2, 1, 3, 1]

Before: [1, 2, 2, 1]
4 3 2 1
After:  [1, 1, 2, 1]

Before: [0, 1, 2, 3]
12 1 2 0
After:  [0, 1, 2, 3]

Before: [1, 1, 2, 1]
0 1 0 0
After:  [1, 1, 2, 1]

Before: [1, 1, 1, 3]
5 2 1 1
After:  [1, 2, 1, 3]";
        private const string ProblemTestInput = @"";

        private const string ProblemProgram = @"2 2 3 3
2 0 3 2
2 2 1 0
15 0 3 3
10 3 1 3
5 1 3 1
2 2 3 3
10 1 0 0
14 0 0 0
7 2 3 2
10 2 3 2
5 1 2 1
4 1 1 0
2 3 2 1
10 1 0 2
14 2 0 2
12 1 3 3
10 3 3 3
5 3 0 0
4 0 0 3
10 0 0 0
14 0 2 0
2 1 1 1
2 3 0 2
13 0 2 1
10 1 1 1
5 1 3 3
2 0 3 2
2 1 1 1
3 1 0 2
10 2 1 2
10 2 2 2
5 3 2 3
4 3 0 1
2 1 3 3
10 3 0 2
14 2 3 2
3 3 0 3
10 3 1 3
10 3 3 3
5 3 1 1
2 0 1 3
2 2 0 2
10 0 0 0
14 0 3 0
0 2 3 3
10 3 1 3
5 1 3 1
4 1 2 3
2 1 1 0
2 0 0 1
4 0 2 2
10 2 3 2
5 2 3 3
4 3 2 1
10 2 0 3
14 3 3 3
2 3 1 2
10 2 0 0
14 0 2 0
12 3 0 0
10 0 3 0
5 0 1 1
4 1 0 2
2 3 2 0
2 2 0 1
2 1 0 3
12 0 1 1
10 1 3 1
5 2 1 2
2 2 3 1
2 3 0 3
2 1 3 0
12 3 1 3
10 3 2 3
5 2 3 2
4 2 2 3
2 3 1 1
2 1 0 2
9 1 2 2
10 2 1 2
5 2 3 3
4 3 2 1
10 1 0 2
14 2 2 2
2 3 1 3
4 0 2 3
10 3 3 3
5 3 1 1
2 0 2 0
2 0 1 3
6 3 2 0
10 0 2 0
5 0 1 1
2 3 2 0
10 1 0 3
14 3 2 3
2 1 3 2
2 2 0 3
10 3 3 3
10 3 2 3
5 3 1 1
2 1 0 3
2 1 2 0
2 3 0 2
10 2 2 2
5 1 2 1
4 1 1 0
2 3 3 1
2 3 0 3
10 2 0 2
14 2 3 2
9 1 2 1
10 1 3 1
5 1 0 0
4 0 3 3
10 1 0 1
14 1 2 1
10 0 0 0
14 0 0 0
1 1 2 0
10 0 1 0
5 0 3 3
4 3 0 1
2 0 3 2
10 0 0 3
14 3 1 3
10 3 0 0
14 0 2 0
11 0 3 2
10 2 2 2
5 1 2 1
2 2 3 3
2 3 1 0
2 2 3 2
12 0 3 2
10 2 1 2
5 1 2 1
2 1 1 0
10 1 0 2
14 2 0 2
7 2 3 0
10 0 1 0
5 0 1 1
4 1 1 3
2 1 1 1
2 2 0 0
2 3 1 2
13 0 2 2
10 2 2 2
10 2 1 2
5 2 3 3
2 1 1 0
2 2 0 2
2 2 1 1
4 0 2 2
10 2 3 2
10 2 3 2
5 3 2 3
4 3 3 1
2 1 3 3
2 1 2 2
2 2 2 0
11 0 3 0
10 0 2 0
5 1 0 1
4 1 2 2
2 2 2 3
2 1 2 1
2 2 2 0
15 0 3 3
10 3 1 3
10 3 3 3
5 3 2 2
4 2 2 1
2 0 0 0
2 0 3 3
2 2 2 2
6 3 2 2
10 2 1 2
5 1 2 1
4 1 1 0
2 2 2 2
2 2 1 1
10 3 0 3
14 3 2 3
0 1 3 2
10 2 2 2
5 2 0 0
10 0 0 2
14 2 0 2
2 1 0 3
2 0 1 1
14 3 1 1
10 1 2 1
10 1 2 1
5 1 0 0
4 0 3 1
10 1 0 0
14 0 0 0
2 0 1 3
2 2 2 2
0 2 3 0
10 0 3 0
10 0 2 0
5 1 0 1
2 2 2 0
2 1 1 3
11 0 3 3
10 3 2 3
5 3 1 1
4 1 2 2
10 1 0 3
14 3 2 3
10 1 0 1
14 1 3 1
15 0 3 3
10 3 3 3
5 3 2 2
4 2 0 1
10 0 0 3
14 3 1 3
2 3 3 2
13 0 2 0
10 0 3 0
5 0 1 1
2 2 3 3
2 1 0 0
10 0 2 3
10 3 2 3
5 1 3 1
2 1 1 2
2 1 3 3
2 2 0 0
11 0 3 2
10 2 2 2
5 1 2 1
4 1 3 0
2 3 1 1
10 2 0 2
14 2 0 2
9 1 2 3
10 3 1 3
5 0 3 0
4 0 1 1
2 0 0 3
2 1 3 2
2 2 0 0
0 0 3 3
10 3 1 3
5 3 1 1
4 1 3 3
10 1 0 1
14 1 2 1
10 1 0 0
14 0 3 0
2 3 0 2
1 1 0 0
10 0 3 0
5 0 3 3
10 2 0 2
14 2 1 2
2 3 0 1
2 3 0 0
9 1 2 1
10 1 1 1
10 1 1 1
5 3 1 3
4 3 1 1
2 1 2 0
10 1 0 2
14 2 2 2
2 2 2 3
3 0 3 3
10 3 1 3
10 3 2 3
5 1 3 1
4 1 2 2
2 3 2 1
2 2 3 0
10 2 0 3
14 3 1 3
3 3 0 0
10 0 2 0
10 0 3 0
5 0 2 2
4 2 0 1
10 0 0 3
14 3 0 3
2 3 2 2
2 0 0 0
7 3 2 0
10 0 2 0
5 1 0 1
4 1 3 2
2 3 3 1
2 2 0 0
2 3 3 3
8 0 1 0
10 0 1 0
10 0 3 0
5 0 2 2
4 2 2 3
2 2 3 0
2 2 1 2
8 0 1 0
10 0 1 0
10 0 1 0
5 3 0 3
4 3 1 1
2 3 1 0
2 1 2 2
2 0 3 3
9 0 2 3
10 3 3 3
5 3 1 1
2 2 0 2
10 2 0 0
14 0 1 0
2 1 3 3
5 0 3 0
10 0 3 0
5 1 0 1
4 1 2 3
2 1 2 0
10 3 0 2
14 2 0 2
2 0 3 1
10 0 2 1
10 1 1 1
5 1 3 3
4 3 1 1
2 2 0 2
10 2 0 3
14 3 0 3
6 3 2 0
10 0 1 0
10 0 2 0
5 0 1 1
4 1 1 3
2 3 0 1
2 0 2 2
2 3 2 0
13 2 0 0
10 0 1 0
5 3 0 3
4 3 0 2
2 1 0 0
10 3 0 3
14 3 2 3
2 1 2 1
3 1 3 1
10 1 1 1
5 2 1 2
4 2 3 1
2 0 1 3
2 2 1 2
2 0 1 0
6 3 2 3
10 3 1 3
5 3 1 1
4 1 2 2
2 3 2 3
2 2 2 1
2 2 2 0
12 3 1 0
10 0 1 0
5 0 2 2
2 1 0 0
2 2 2 3
3 0 3 3
10 3 1 3
5 2 3 2
4 2 3 1
2 1 3 2
2 3 3 0
2 2 3 3
12 0 3 3
10 3 1 3
10 3 3 3
5 1 3 1
2 0 3 2
2 2 2 0
2 1 0 3
11 0 3 3
10 3 3 3
5 3 1 1
2 3 3 2
2 0 3 3
1 0 2 2
10 2 1 2
5 2 1 1
4 1 0 2
2 3 0 1
10 2 0 3
14 3 2 3
15 0 3 1
10 1 3 1
10 1 1 1
5 1 2 2
4 2 1 1
2 3 3 2
2 0 1 3
2 0 1 0
7 3 2 2
10 2 1 2
5 1 2 1
4 1 0 0
2 0 2 1
2 2 3 2
6 3 2 2
10 2 1 2
5 2 0 0
4 0 0 1
2 0 0 2
2 3 1 0
13 2 0 0
10 0 2 0
5 1 0 1
4 1 3 0
2 2 3 2
2 3 2 1
6 3 2 3
10 3 1 3
10 3 2 3
5 0 3 0
2 1 3 3
2 0 1 2
14 3 1 2
10 2 3 2
5 2 0 0
2 2 0 3
2 0 1 2
7 2 3 1
10 1 1 1
10 1 3 1
5 1 0 0
4 0 3 1
2 0 1 3
10 3 0 0
14 0 3 0
2 2 2 2
6 3 2 3
10 3 2 3
5 3 1 1
2 1 2 0
2 0 3 3
2 3 2 0
10 0 2 0
5 1 0 1
2 3 1 0
2 3 1 3
8 2 0 2
10 2 3 2
5 1 2 1
4 1 2 3
2 0 2 2
2 2 1 1
13 2 0 2
10 2 1 2
10 2 2 2
5 2 3 3
4 3 2 1
2 1 3 0
2 0 3 3
2 2 2 2
0 2 3 0
10 0 2 0
10 0 1 0
5 1 0 1
2 1 1 0
2 1 3 3
5 3 0 2
10 2 1 2
5 2 1 1
4 1 0 3
10 1 0 2
14 2 1 2
2 2 1 0
2 1 3 1
3 1 0 0
10 0 3 0
5 0 3 3
2 2 2 2
10 3 0 1
14 1 2 1
2 1 3 0
4 0 2 1
10 1 3 1
10 1 2 1
5 3 1 3
4 3 0 1
2 3 0 3
2 2 2 0
2 3 2 2
12 3 0 3
10 3 2 3
5 3 1 1
4 1 1 3
2 3 0 1
9 1 2 0
10 0 3 0
5 0 3 3
4 3 2 1
2 0 2 2
10 2 0 3
14 3 2 3
10 1 0 0
14 0 3 0
7 2 3 0
10 0 1 0
10 0 1 0
5 0 1 1
2 2 1 0
2 2 2 2
15 0 3 0
10 0 2 0
5 0 1 1
4 1 0 0
2 0 2 1
2 0 2 3
2 3 3 2
7 3 2 3
10 3 2 3
5 0 3 0
4 0 2 2
2 2 0 0
2 1 3 3
2 2 1 1
11 0 3 3
10 3 2 3
5 2 3 2
2 1 3 3
2 0 1 1
11 0 3 1
10 1 1 1
5 1 2 2
4 2 3 0
2 2 2 2
2 3 1 1
8 2 1 3
10 3 2 3
10 3 1 3
5 0 3 0
10 0 0 3
14 3 1 3
2 0 1 2
10 1 0 1
14 1 0 1
14 3 1 2
10 2 1 2
10 2 1 2
5 0 2 0
4 0 1 1
2 1 2 2
2 2 0 3
10 3 0 0
14 0 1 0
3 0 3 2
10 2 3 2
5 2 1 1
2 0 2 2
2 1 2 3
10 1 0 0
14 0 0 0
10 3 2 3
10 3 3 3
5 1 3 1
4 1 3 0
2 1 0 2
10 1 0 1
14 1 3 1
2 1 0 3
5 3 3 3
10 3 1 3
10 3 2 3
5 0 3 0
2 0 3 2
2 2 0 3
2 2 3 1
7 2 3 1
10 1 2 1
10 1 2 1
5 0 1 0
4 0 1 2
2 1 1 1
2 3 2 3
10 0 0 0
14 0 2 0
3 1 0 1
10 1 2 1
10 1 2 1
5 2 1 2
4 2 3 0
2 0 1 1
2 3 3 2
2 1 0 3
10 3 2 1
10 1 2 1
5 0 1 0
4 0 3 1
2 1 3 2
2 2 0 0
2 2 0 3
15 0 3 2
10 2 2 2
5 1 2 1
2 1 0 0
2 2 2 2
2 1 0 3
4 0 2 0
10 0 3 0
5 0 1 1
2 1 2 0
2 0 0 3
4 0 2 0
10 0 1 0
10 0 2 0
5 0 1 1
4 1 1 0
2 0 0 1
2 2 1 3
2 0 2 2
7 2 3 2
10 2 1 2
5 0 2 0
2 2 0 1
2 0 3 2
7 2 3 2
10 2 3 2
5 2 0 0
4 0 1 3
2 1 0 0
2 2 1 2
2 1 1 1
5 1 0 0
10 0 1 0
5 0 3 3
4 3 2 0
2 3 2 1
2 1 0 2
10 0 0 3
14 3 3 3
9 1 2 2
10 2 1 2
10 2 2 2
5 0 2 0
4 0 1 2
2 2 3 1
2 0 2 3
2 1 2 0
5 0 0 3
10 3 2 3
5 2 3 2
4 2 3 3
10 1 0 1
14 1 0 1
2 2 2 2
4 0 2 1
10 1 3 1
10 1 3 1
5 3 1 3
4 3 2 0
2 2 0 1
2 3 1 3
10 0 0 2
14 2 0 2
9 3 2 1
10 1 1 1
10 1 2 1
5 0 1 0
4 0 2 2
2 2 0 3
2 3 1 1
2 2 2 0
15 0 3 0
10 0 1 0
10 0 2 0
5 0 2 2
2 2 1 0
2 0 0 1
2 1 0 3
14 3 1 1
10 1 1 1
5 2 1 2
2 1 3 1
11 0 3 0
10 0 1 0
5 0 2 2
4 2 1 0
2 0 3 1
2 0 1 3
2 2 1 2
0 2 3 3
10 3 2 3
5 3 0 0
4 0 2 1
10 3 0 3
14 3 1 3
2 2 3 0
2 1 1 2
3 3 0 0
10 0 1 0
10 0 2 0
5 1 0 1
2 1 3 0
2 2 0 2
4 0 2 2
10 2 1 2
5 1 2 1
10 2 0 3
14 3 0 3
2 2 2 2
6 3 2 2
10 2 1 2
5 2 1 1
2 2 1 2
2 3 2 0
8 2 0 0
10 0 2 0
5 1 0 1
4 1 2 3
2 0 0 1
2 3 2 0
2 3 3 2
9 0 2 1
10 1 2 1
10 1 1 1
5 3 1 3
4 3 2 0
10 1 0 1
14 1 1 1
2 2 2 3
10 1 2 3
10 3 3 3
10 3 3 3
5 0 3 0
4 0 1 2
2 2 2 0
10 3 0 1
14 1 2 1
2 1 2 3
11 0 3 1
10 1 2 1
5 1 2 2
4 2 2 1
2 3 1 2
11 0 3 0
10 0 3 0
5 0 1 1
4 1 1 3
10 3 0 1
14 1 1 1
2 2 0 0
1 0 2 1
10 1 3 1
5 1 3 3
4 3 0 1
2 1 3 0
2 3 0 3
2 2 2 2
4 0 2 2
10 2 3 2
5 1 2 1
10 0 0 2
14 2 3 2
2 2 0 0
13 0 2 0
10 0 1 0
10 0 3 0
5 1 0 1
4 1 0 3
2 1 2 0
10 1 0 1
14 1 3 1
9 1 2 0
10 0 1 0
5 3 0 3
4 3 0 1
2 2 3 2
2 2 3 0
2 0 2 3
6 3 2 0
10 0 2 0
5 1 0 1
4 1 3 0
2 3 3 2
2 1 1 1
10 2 0 3
14 3 3 3
10 1 2 1
10 1 3 1
10 1 2 1
5 0 1 0
4 0 2 3
2 0 1 2
10 1 0 1
14 1 1 1
2 2 3 0
3 1 0 0
10 0 3 0
5 0 3 3
4 3 3 1
2 3 0 0
2 0 1 3
2 3 2 2
9 0 2 3
10 3 3 3
5 1 3 1
4 1 0 0
2 2 0 3
10 3 0 2
14 2 2 2
2 1 0 1
3 1 3 2
10 2 1 2
5 0 2 0
2 0 0 2
10 3 0 1
14 1 2 1
2 3 3 3
12 3 1 2
10 2 1 2
5 0 2 0
4 0 0 1
2 1 2 3
2 3 1 2
2 1 1 0
5 0 3 3
10 3 3 3
5 1 3 1
4 1 0 0
2 3 1 1
2 0 2 3
7 3 2 2
10 2 3 2
10 2 1 2
5 2 0 0
4 0 2 1
2 1 2 3
2 3 3 0
2 2 3 2
8 2 0 3
10 3 1 3
5 3 1 1
10 3 0 2
14 2 0 2
2 1 0 3
13 2 0 2
10 2 1 2
5 1 2 1
4 1 0 0
10 0 0 2
14 2 1 2
2 2 2 1
2 3 0 3
9 3 2 1
10 1 2 1
5 1 0 0
4 0 1 1
10 3 0 2
14 2 3 2
2 3 2 0
2 2 3 2
10 2 3 2
10 2 1 2
5 2 1 1
4 1 0 0";

        public static int SolveProblem1()
        {
            var lines = ProblemInput.SplitToLines().ToList();

            var count = 0;

            for (var i = 0; i < lines.Count; i++)
            {
                if (lines[i] == "")
                {
                    continue;
                }
                var beforeRegisters = GetRegisterValues(lines[i]);
                var afterRegisters = GetRegisterValues(lines[i+2]);
                var instruction = GetInstruction(lines[i+1]);

                if (TestInstruction(instruction, beforeRegisters, afterRegisters))
                    count++;

                i += 3;
            }

            return count;
        }

        private static bool TestInstruction(int[] instruction, int[] beforeRegisters, int[] afterRegisters)
        {
            var count = 0;
            if (addr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (addi(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (mulr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (muli(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (banr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (bani(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (borr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (bori(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (setr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (seti(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (gtir(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (gtri(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (gtrr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (eqir(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (eqri(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;
            if (eqrr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                count++;

            return count >= 3;
        }

        private static int[] addr(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] + beforeRegisters[instruction[2]];
            return ret;
        }

        private static int[] addi(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] + instruction[2];
            return ret;
        }

        private static int[] mulr(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] * beforeRegisters[instruction[2]];
            return ret;
        }

        private static int[] muli(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] * instruction[2];
            return ret;
        }

        private static int[] banr(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] & beforeRegisters[instruction[2]];
            return ret;
        }

        private static int[] bani(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] & instruction[2];
            return ret;
        }

        private static int[] borr(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] | beforeRegisters[instruction[2]];
            return ret;
        }

        private static int[] bori(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] | instruction[2];
            return ret;
        }

        private static int[] setr(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]];
            return ret;
        }

        private static int[] seti(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = instruction[1];
            return ret;
        }

        private static int[] gtir(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = instruction[1] > beforeRegisters[instruction[2]] ? 1 : 0;
            return ret;
        }

        private static int[] gtri(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] > instruction[2] ? 1 : 0;
            return ret;
        }

        private static int[] gtrr(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] > beforeRegisters[instruction[2]] ? 1 : 0;
            return ret;
        }

        private static int[] eqir(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = instruction[1] == beforeRegisters[instruction[2]] ? 1 : 0;
            return ret;
        }

        private static int[] eqri(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] == instruction[2] ? 1 : 0;
            return ret;
        }

        private static int[] eqrr(int[] instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction[3]] = beforeRegisters[instruction[1]] == beforeRegisters[instruction[2]] ? 1 : 0;
            return ret;
        }

        private static int[] GetInstruction(string inputLine)
        {
            var instructionStrings = inputLine.Split(' ');
            return new int[4] {
                Int32.Parse(instructionStrings[0]),
                Int32.Parse(instructionStrings[1]),
                Int32.Parse(instructionStrings[2]),
                Int32.Parse(instructionStrings[3])};
        }

        private static int[] GetRegisterValues(string inputLine)
        {
            var registerStrings = inputLine.Split('[', ',', ']');
            return new int[4] {
                Int32.Parse(registerStrings[1]),
                Int32.Parse(registerStrings[2]),
                Int32.Parse(registerStrings[3]),
                Int32.Parse(registerStrings[4])};
        }

        public static int SolveProblem2()
        {
            var lines = ProblemInput.SplitToLines().ToList();

            var opCodes = new Dictionary<int, HashSet<OpCode>>();

            for (var i = 0; i < lines.Count; i++)
            {
                if (lines[i] == "")
                {
                    continue;
                }
                var beforeRegisters = GetRegisterValues(lines[i]);
                var afterRegisters = GetRegisterValues(lines[i+2]);
                var instruction = GetInstruction(lines[i+1]);
                var opCode = instruction[0];

                var possibleOpCodes = GetPossibleOpCodes(instruction, beforeRegisters, afterRegisters);

                if (!opCodes.ContainsKey(opCode))
                {
                    opCodes[opCode] = possibleOpCodes;
                }
                else
                {
                    opCodes[opCode] = possibleOpCodes.Intersect(opCodes[opCode]).ToHashSet();
                }
                i += 3;
            }

            var finalOpCodeMapping = new Dictionary<int, OpCode>();
            while (finalOpCodeMapping.Count < 16)
            {
                var mapped = opCodes.Where(kv => kv.Value.Count == 1).Select(kv => new Tuple<int, OpCode>(kv.Key, kv.Value.First())).ToList();
                foreach (var mapping in mapped)
                {
                    var mappedValue = mapping.Item1;
                    var mappedCode = mapping.Item2;
                    finalOpCodeMapping[mappedValue] = mappedCode;
                    opCodes.Remove(mappedValue);
                    foreach (var remainingValue in opCodes.Keys)
                    {
                        opCodes[remainingValue].Remove(mappedCode);
                    }
                }
            }

            var programLines = ProblemProgram.SplitToLines();

            var registers = new int[] {0,0,0,0};

            foreach (var line in programLines)
            {
                var instruction = GetInstruction(line);
                switch (finalOpCodeMapping[instruction[0]])
                {
                    case OpCode.addi:
                        registers = addi(instruction, registers);
                        break;
                    case OpCode.addr:
                        registers = addr(instruction, registers);
                        break;
                    case OpCode.muli:
                        registers = muli(instruction, registers);
                        break;
                    case OpCode.mulr:
                        registers = mulr(instruction, registers);
                        break;
                    case OpCode.bani:
                        registers = bani(instruction, registers);
                        break;
                    case OpCode.banr:
                        registers = banr(instruction, registers);
                        break;
                    case OpCode.bori:
                        registers = bori(instruction, registers);
                        break;
                    case OpCode.borr:
                        registers = borr(instruction, registers);
                        break;
                    case OpCode.seti:
                        registers = seti(instruction, registers);
                        break;
                    case OpCode.setr:
                        registers = setr(instruction, registers);
                        break;
                    case OpCode.gtir:
                        registers = gtir(instruction, registers);
                        break;
                    case OpCode.gtrr:
                        registers = gtrr(instruction, registers);
                        break;
                    case OpCode.gtri:
                        registers = gtri(instruction, registers);
                        break;
                    case OpCode.eqir:
                        registers = eqir(instruction, registers);
                        break;
                    case OpCode.eqri:
                        registers = eqri(instruction, registers);
                        break;
                    case OpCode.eqrr:
                        registers = eqrr(instruction, registers);
                        break;
                }
            }

            return registers[0];
        }

        private enum OpCode
        {
            addr,
            addi,
            mulr,
            muli,
            banr,
            bani,
            borr,
            bori,
            setr,
            seti,
            gtir,
            gtri,
            gtrr,
            eqri,
            eqir,
            eqrr
        }

        private static HashSet<OpCode> GetPossibleOpCodes(int[] instruction, int[] beforeRegisters, int[] afterRegisters)
        {
            var ret = new HashSet<OpCode>();
            if (addr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.addr);
            if (addi(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.addi);
            if (mulr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.mulr);
            if (muli(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.muli);
            if (banr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.banr);
            if (bani(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.bani);
            if (borr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.borr);
            if (bori(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.bori);
            if (setr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.setr);
            if (seti(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.seti);
            if (gtir(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.gtir);
            if (gtri(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.gtri);
            if (gtrr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.gtrr);
            if (eqir(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.eqir);
            if (eqri(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.eqri);
            if (eqrr(instruction, beforeRegisters).SequenceEqual(afterRegisters))
                ret.Add(OpCode.eqrr);

            return ret;
        }
    }
}