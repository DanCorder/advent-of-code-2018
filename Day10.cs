namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day10
    {
        private const string ProblemInput = @"position=<-31761,  10798> velocity=< 3, -1>
position=< 32025, -10468> velocity=<-3,  1>
position=< 32018, -31724> velocity=<-3,  3>
position=< 21393, -52982> velocity=<-2,  5>
position=< 42645,  10793> velocity=<-4, -1>
position=<-21111, -10461> velocity=< 2,  1>
position=< 21436, -10468> velocity=<-2,  1>
position=< 42695, -10468> velocity=<-4,  1>
position=< 21388, -10463> velocity=<-2,  1>
position=<-31720, -42355> velocity=< 3,  4>
position=< 10800, -31725> velocity=<-1,  3>
position=< 32052,  42691> velocity=<-3, -4>
position=< 10808,  53314> velocity=<-1, -5>
position=< 42690, -21097> velocity=<-4,  2>
position=< 32060, -52979> velocity=<-3,  5>
position=< 32007, -31728> velocity=<-3,  3>
position=< 10808,  21423> velocity=<-1, -2>
position=<-31760, -21095> velocity=< 3,  2>
position=<-21111, -42353> velocity=< 2,  4>
position=<-10457, -21096> velocity=< 1,  2>
position=<-53001, -10466> velocity=< 5,  1>
position=< 32052, -31728> velocity=<-3,  3>
position=< 32047, -21098> velocity=<-3,  2>
position=< 21395,  42691> velocity=<-2, -4>
position=<-53009, -31727> velocity=< 5,  3>
position=<-53017,  21428> velocity=< 5, -2>
position=<-21135, -52986> velocity=< 2,  5>
position=<-21140,  32061> velocity=< 2, -3>
position=< 10774,  53316> velocity=<-1, -5>
position=< 42653, -52984> velocity=<-4,  5>
position=<-53033,  53318> velocity=< 5, -5>
position=<-53001,  53313> velocity=< 5, -5>
position=< 42685, -42353> velocity=<-4,  4>
position=<-21135, -52981> velocity=< 2,  5>
position=<-31733, -31720> velocity=< 3,  3>
position=<-21082,  10795> velocity=< 2, -1>
position=<-52972,  21423> velocity=< 5, -2>
position=<-21087,  10800> velocity=< 2, -1>
position=< 10806, -21098> velocity=<-1,  2>
position=< 21406,  42691> velocity=<-2, -4>
position=< 21409, -10468> velocity=<-2,  1>
position=<-53013, -52988> velocity=< 5,  5>
position=<-31745, -31721> velocity=< 3,  3>
position=< 42681,  21425> velocity=<-4, -2>
position=< 21378, -21089> velocity=<-2,  2>
position=< 53286,  32052> velocity=<-5, -3>
position=<-52982,  21422> velocity=< 5, -2>
position=<-10484,  21431> velocity=< 1, -2>
position=<-53001,  21431> velocity=< 5, -2>
position=< 32066, -52988> velocity=<-3,  5>
position=< 32060, -21090> velocity=<-3,  2>
position=< 42673, -10464> velocity=<-4,  1>
position=<-42378, -21091> velocity=< 4,  2>
position=<-21110, -31728> velocity=< 2,  3>
position=< 21389,  21429> velocity=<-2, -2>
position=< 10755,  21424> velocity=<-1, -2>
position=<-31725, -42357> velocity=< 3,  4>
position=< 21437,  42686> velocity=<-2, -4>
position=<-31721,  53318> velocity=< 3, -5>
position=<-10502, -42354> velocity=< 1,  4>
position=< 42642, -31719> velocity=<-4,  3>
position=< 21379,  42691> velocity=<-2, -4>
position=<-52973, -52988> velocity=< 5,  5>
position=<-42359,  42685> velocity=< 4, -4>
position=<-53017, -31725> velocity=< 5,  3>
position=<-21143, -52982> velocity=< 2,  5>
position=< 32051, -31725> velocity=<-3,  3>
position=<-53001,  42685> velocity=< 5, -4>
position=<-42379,  42682> velocity=< 4, -4>
position=<-31757, -52985> velocity=< 3,  5>
position=<-31765, -52988> velocity=< 3,  5>
position=<-10460, -52987> velocity=< 1,  5>
position=< 42678, -42356> velocity=<-4,  4>
position=<-53004, -21090> velocity=< 5,  2>
position=< 53311,  53319> velocity=<-5, -5>
position=<-53017, -42350> velocity=< 5,  4>
position=<-10501,  21429> velocity=< 1, -2>
position=< 42669,  42688> velocity=<-4, -4>
position=< 53275,  32059> velocity=<-5, -3>
position=< 21387,  10796> velocity=<-2, -1>
position=< 21418,  10795> velocity=<-2, -1>
position=<-21092,  42687> velocity=< 2, -4>
position=<-42359, -10462> velocity=< 4,  1>
position=<-21118,  42684> velocity=< 2, -4>
position=< 10764, -10459> velocity=<-1,  1>
position=< 42682,  32053> velocity=<-4, -3>
position=< 42653, -42350> velocity=<-4,  4>
position=<-31738, -31724> velocity=< 3,  3>
position=<-10469,  10794> velocity=< 1, -1>
position=<-31725, -42358> velocity=< 3,  4>
position=<-10456,  21426> velocity=< 1, -2>
position=< 21417, -10459> velocity=<-2,  1>
position=<-42385,  10801> velocity=< 4, -1>
position=< 10792, -52987> velocity=<-1,  5>
position=< 21401,  32053> velocity=<-2, -3>
position=<-31712, -10466> velocity=< 3,  1>
position=< 32016, -42354> velocity=<-3,  4>
position=< 32049,  53316> velocity=<-3, -5>
position=<-10494, -42349> velocity=< 1,  4>
position=<-52977, -10459> velocity=< 5,  1>
position=<-31773,  10798> velocity=< 3, -1>
position=< 10776, -10468> velocity=<-1,  1>
position=< 21385,  32059> velocity=<-2, -3>
position=<-10462, -52988> velocity=< 1,  5>
position=< 10795, -42351> velocity=<-1,  4>
position=<-21090,  42684> velocity=< 2, -4>
position=<-31745, -21091> velocity=< 3,  2>
position=< 53275,  21427> velocity=<-5, -2>
position=< 53283, -21092> velocity=<-5,  2>
position=<-10477, -52988> velocity=< 1,  5>
position=< 53267, -21098> velocity=<-5,  2>
position=< 10757, -31728> velocity=<-1,  3>
position=< 21433,  53315> velocity=<-2, -5>
position=<-53033,  21426> velocity=< 5, -2>
position=<-31725, -10463> velocity=< 3,  1>
position=< 21413,  32056> velocity=<-2, -3>
position=< 21402, -21095> velocity=<-2,  2>
position=< 42672,  32056> velocity=<-4, -3>
position=<-53033, -42354> velocity=< 5,  4>
position=< 10788, -31726> velocity=<-1,  3>
position=<-10488, -52981> velocity=< 1,  5>
position=< 42654,  10801> velocity=<-4, -1>
position=< 10779, -52985> velocity=<-1,  5>
position=<-31755,  53321> velocity=< 3, -5>
position=<-10508,  42691> velocity=< 1, -4>
position=<-52985,  42686> velocity=< 5, -4>
position=< 32047,  21430> velocity=<-3, -2>
position=<-42350,  10800> velocity=< 4, -1>
position=<-42403, -10459> velocity=< 4,  1>
position=< 42669,  10801> velocity=<-4, -1>
position=< 42693, -31724> velocity=<-4,  3>
position=<-10463, -52984> velocity=< 1,  5>
position=<-52985,  21430> velocity=< 5, -2>
position=<-10503, -31728> velocity=< 1,  3>
position=<-53017,  10800> velocity=< 5, -1>
position=<-42359,  21428> velocity=< 4, -2>
position=<-21116,  10796> velocity=< 2, -1>
position=< 53295,  10795> velocity=<-5, -1>
position=<-52980, -10467> velocity=< 5,  1>
position=<-42363, -21097> velocity=< 4,  2>
position=< 53283, -52983> velocity=<-5,  5>
position=< 21433,  10797> velocity=<-2, -1>
position=< 10760,  53321> velocity=<-1, -5>
position=<-31764, -52984> velocity=< 3,  5>
position=< 32039,  53314> velocity=<-3, -5>
position=<-21135,  21423> velocity=< 2, -2>
position=< 21390, -21095> velocity=<-2,  2>
position=< 10787, -10467> velocity=<-1,  1>
position=< 42637,  21430> velocity=<-4, -2>
position=<-31769, -10459> velocity=< 3,  1>
position=<-21108, -10468> velocity=< 2,  1>
position=<-21132,  10792> velocity=< 2, -1>
position=<-31753, -52979> velocity=< 3,  5>
position=<-53017,  21423> velocity=< 5, -2>
position=<-10487,  10797> velocity=< 1, -1>
position=<-42378,  32058> velocity=< 4, -3>
position=< 32051, -52986> velocity=<-3,  5>
position=<-52985, -52981> velocity=< 5,  5>
position=<-10497, -42356> velocity=< 1,  4>
position=<-10465, -10463> velocity=< 1,  1>
position=< 42671, -42358> velocity=<-4,  4>
position=< 21396,  10801> velocity=<-2, -1>
position=< 53267, -31724> velocity=<-5,  3>
position=<-42363,  32053> velocity=< 4, -3>
position=< 32048,  10799> velocity=<-3, -1>
position=< 53280, -31727> velocity=<-5,  3>
position=<-52985, -21096> velocity=< 5,  2>
position=< 21385,  53312> velocity=<-2, -5>
position=<-10479,  42682> velocity=< 1, -4>
position=<-10487,  10796> velocity=< 1, -1>
position=<-42352, -10463> velocity=< 4,  1>
position=<-53007,  32056> velocity=< 5, -3>
position=< 21386,  32052> velocity=<-2, -3>
position=<-10465,  10792> velocity=< 1, -1>
position=<-31757,  42683> velocity=< 3, -4>
position=< 42678, -10461> velocity=<-4,  1>
position=<-52975,  32056> velocity=< 5, -3>
position=<-53009,  32060> velocity=< 5, -3>
position=<-10476, -42358> velocity=< 1,  4>
position=<-31752, -10460> velocity=< 3,  1>
position=<-10481,  53313> velocity=< 1, -5>
position=<-21125, -21098> velocity=< 2,  2>
position=< 53303, -31728> velocity=<-5,  3>
position=< 21429, -10464> velocity=<-2,  1>
position=<-53009,  21431> velocity=< 5, -2>
position=< 32047,  32060> velocity=<-3, -3>
position=< 21405, -52986> velocity=<-2,  5>
position=<-42359,  21424> velocity=< 4, -2>
position=< 10758,  10792> velocity=<-1, -1>
position=< 32055,  32059> velocity=<-3, -3>
position=< 21433,  53320> velocity=<-2, -5>
position=< 32027, -21089> velocity=<-3,  2>
position=<-31721, -10464> velocity=< 3,  1>
position=<-31733, -52988> velocity=< 3,  5>
position=< 42645,  21425> velocity=<-4, -2>
position=<-53033, -31719> velocity=< 5,  3>
position=<-10513, -31727> velocity=< 1,  3>
position=< 10747,  53314> velocity=<-1, -5>
position=< 42693,  53313> velocity=<-4, -5>
position=< 53299, -21098> velocity=<-5,  2>
position=<-10452,  32055> velocity=< 1, -3>
position=<-21098,  32052> velocity=< 2, -3>
position=< 53301,  21426> velocity=<-5, -2>
position=< 21389,  42688> velocity=<-2, -4>
position=< 32016,  32056> velocity=<-3, -3>
position=< 53323,  32059> velocity=<-5, -3>
position=< 10808, -52985> velocity=<-1,  5>
position=< 32007, -42356> velocity=<-3,  4>
position=< 21390,  53314> velocity=<-2, -5>
position=< 21405,  21429> velocity=<-2, -2>
position=<-31717, -31721> velocity=< 3,  3>
position=<-10457, -42353> velocity=< 1,  4>
position=< 42685, -21089> velocity=<-4,  2>
position=<-21095,  21430> velocity=< 2, -2>
position=<-21102, -42352> velocity=< 2,  4>
position=<-10465,  32052> velocity=< 1, -3>
position=< 21433,  42691> velocity=<-2, -4>
position=<-21135, -31720> velocity=< 2,  3>
position=< 42653, -31727> velocity=<-4,  3>
position=< 32063, -31725> velocity=<-3,  3>
position=< 32032, -21092> velocity=<-3,  2>
position=< 10798,  21422> velocity=<-1, -2>
position=< 32060, -10459> velocity=<-3,  1>
position=<-10479, -21098> velocity=< 1,  2>
position=<-21091,  32052> velocity=< 2, -3>
position=<-31745, -52982> velocity=< 3,  5>
position=<-31752, -10467> velocity=< 3,  1>
position=< 53317, -52988> velocity=<-5,  5>
position=< 32032,  10794> velocity=<-3, -1>
position=<-42378,  42684> velocity=< 4, -4>
position=< 21389,  21429> velocity=<-2, -2>
position=<-21098, -42349> velocity=< 2,  4>
position=<-42355,  10795> velocity=< 4, -1>
position=< 32043,  42682> velocity=<-3, -4>
position=< 10755,  53313> velocity=<-1, -5>
position=< 53267,  21427> velocity=<-5, -2>
position=< 53300,  42686> velocity=<-5, -4>
position=<-42354,  21426> velocity=< 4, -2>
position=< 21409, -10463> velocity=<-2,  1>
position=<-21135,  42688> velocity=< 2, -4>
position=< 32039, -42354> velocity=<-3,  4>
position=<-31717, -21091> velocity=< 3,  2>
position=< 53323,  32058> velocity=<-5, -3>
position=< 21412,  32052> velocity=<-2, -3>
position=< 53308,  10795> velocity=<-5, -1>
position=<-53020, -31727> velocity=< 5,  3>
position=< 10791,  21428> velocity=<-1, -2>
position=<-31741, -10461> velocity=< 3,  1>
position=< 42649,  32058> velocity=<-4, -3>
position=< 10755, -52979> velocity=<-1,  5>
position=<-21114,  10792> velocity=< 2, -1>
position=<-21143, -10461> velocity=< 2,  1>
position=< 32052,  53320> velocity=<-3, -5>
position=<-10470,  53316> velocity=< 1, -5>
position=<-21092, -31724> velocity=< 2,  3>
position=<-10465,  21428> velocity=< 1, -2>
position=< 32036, -21097> velocity=<-3,  2>
position=< 32007, -52985> velocity=<-3,  5>
position=< 42669, -21091> velocity=<-4,  2>
position=< 42669, -10467> velocity=<-4,  1>
position=< 53283,  32059> velocity=<-5, -3>
position=<-10505,  10796> velocity=< 1, -1>
position=< 53302, -21098> velocity=<-5,  2>
position=< 21394,  21422> velocity=<-2, -2>
position=< 53317,  10792> velocity=<-5, -1>
position=<-10476, -10468> velocity=< 1,  1>
position=<-42387, -31725> velocity=< 4,  3>
position=< 42697,  53316> velocity=<-4, -5>
position=<-42376,  10797> velocity=< 4, -1>
position=<-31724, -21098> velocity=< 3,  2>
position=< 53267,  42683> velocity=<-5, -4>
position=< 32023,  10794> velocity=<-3, -1>
position=<-10452, -31727> velocity=< 1,  3>
position=<-21143,  32057> velocity=< 2, -3>
position=< 32033,  21427> velocity=<-3, -2>
position=<-10457,  32053> velocity=< 1, -3>
position=<-21092, -31724> velocity=< 2,  3>
position=<-10500, -42357> velocity=< 1,  4>
position=< 42645, -31722> velocity=<-4,  3>
position=< 10803, -21093> velocity=<-1,  2>
position=<-10492, -31720> velocity=< 1,  3>
position=< 42650, -21089> velocity=<-4,  2>
position=< 53267, -42357> velocity=<-5,  4>
position=< 21428,  21426> velocity=<-2, -2>
position=<-31725,  10794> velocity=< 3, -1>
position=<-21102, -31721> velocity=< 2,  3>
position=<-42347,  10793> velocity=< 4, -1>
position=< 42654, -42358> velocity=<-4,  4>
position=< 42671, -10464> velocity=<-4,  1>
position=<-53025, -21094> velocity=< 5,  2>
position=< 21410,  42682> velocity=<-2, -4>
position=< 42669, -31725> velocity=<-4,  3>
position=< 53278,  53312> velocity=<-5, -5>
position=< 53299,  21430> velocity=<-5, -2>
position=< 32035, -31726> velocity=<-3,  3>
position=< 21393, -31724> velocity=<-2,  3>
position=<-21091, -10461> velocity=< 2,  1>
position=<-10504, -21098> velocity=< 1,  2>
position=< 42650, -21096> velocity=<-4,  2>
position=<-10481,  53314> velocity=< 1, -5>
position=< 21436,  42686> velocity=<-2, -4>
position=<-42347, -31725> velocity=< 4,  3>
position=< 42693, -31728> velocity=<-4,  3>
position=<-21111,  10798> velocity=< 2, -1>
position=< 32063,  21424> velocity=<-3, -2>
position=< 21434, -10468> velocity=<-2,  1>
position=< 21401, -31727> velocity=<-2,  3>
position=< 21420,  42687> velocity=<-2, -4>
position=<-10500, -21090> velocity=< 1,  2>
position=<-10485, -31725> velocity=< 1,  3>
position=< 32063, -42356> velocity=<-3,  4>
position=< 21406, -52987> velocity=<-2,  5>
position=<-31732,  53318> velocity=< 3, -5>
position=<-42361, -10463> velocity=< 4,  1>
position=<-31713, -31724> velocity=< 3,  3>
position=<-10468, -21097> velocity=< 1,  2>
position=<-10492,  32060> velocity=< 1, -3>
position=< 42694, -10464> velocity=<-4,  1>
position=<-42403, -42351> velocity=< 4,  4>
position=< 42661,  42690> velocity=<-4, -4>
position=<-53017, -21091> velocity=< 5,  2>
position=< 32056,  21426> velocity=<-3, -2>
position=< 10805,  42682> velocity=<-1, -4>
position=< 53299, -21089> velocity=<-5,  2>
position=<-31765,  42685> velocity=< 3, -4>
position=< 21394,  53312> velocity=<-2, -5>
position=< 10800,  42690> velocity=<-1, -4>
position=< 53309,  10797> velocity=<-5, -1>
position=< 53325,  42686> velocity=<-5, -4>
position=< 53323,  32052> velocity=<-5, -3>
position=< 21377, -52988> velocity=<-2,  5>
position=<-10505, -42358> velocity=< 1,  4>
position=< 21389, -31724> velocity=<-2,  3>
position=< 32017, -10464> velocity=<-3,  1>
position=< 42685,  10794> velocity=<-4, -1>
position=< 53279,  53312> velocity=<-5, -5>
position=< 32048, -52985> velocity=<-3,  5>
position=< 21385,  10797> velocity=<-2, -1>
position=< 53267,  32055> velocity=<-5, -3>
position=<-21143,  32061> velocity=< 2, -3>";
        private const string ProblemTestInput = @"position=< 9,  1> velocity=< 0,  2>
position=< 7,  0> velocity=<-1,  0>
position=< 3, -2> velocity=<-1,  1>
position=< 6, 10> velocity=<-2, -1>
position=< 2, -4> velocity=< 2,  2>
position=<-6, 10> velocity=< 2, -2>
position=< 1,  8> velocity=< 1, -1>
position=< 1,  7> velocity=< 1,  0>
position=<-3, 11> velocity=< 1, -2>
position=< 7,  6> velocity=<-1, -1>
position=<-2,  3> velocity=< 1,  0>
position=<-4,  3> velocity=< 2,  0>
position=<10, -3> velocity=<-1,  1>
position=< 5, 11> velocity=< 1, -2>
position=< 4,  7> velocity=< 0, -1>
position=< 8, -2> velocity=< 0,  1>
position=<15,  0> velocity=<-2,  0>
position=< 1,  6> velocity=< 1,  0>
position=< 8,  9> velocity=< 0, -1>
position=< 3,  3> velocity=<-1,  1>
position=< 0,  5> velocity=< 0, -1>
position=<-2,  2> velocity=< 2,  0>
position=< 5, -2> velocity=< 1,  2>
position=< 1,  4> velocity=< 2,  1>
position=<-2,  7> velocity=< 2, -2>
position=< 3,  6> velocity=<-1, -1>
position=< 5,  0> velocity=< 1,  0>
position=<-6,  0> velocity=< 2,  0>
position=< 5,  9> velocity=< 1, -2>
position=<14,  7> velocity=<-2,  0>
position=<-3,  6> velocity=< 2, -1>";

        public static int SolveProblem1()
        {
            var lines = ProblemInput.SplitToLines();
            var points = lines.Select(l => {
                var parts = l.Split('<', '>');
                var posParts = parts[1].Split(',');
                var point = new Point();
                point.X = Int32.Parse(posParts[0]);
                point.Y = Int32.Parse(posParts[1]);
                var velocityParts = parts[3].Split(',');
                point.XVelocity = Int32.Parse(velocityParts[0]);
                point.YVelocity = Int32.Parse(velocityParts[1]);
                return point;
            }).ToList();

            var time = 0;
            while(true)
            {
                var close = PrintPoints(points);

                if (close)
                {
                    Console.WriteLine(time);
                    var dummy = "breakpoint here";
                }

                foreach (var point in points)
                {
                    point.Move();
                }
                time++;
            }

            return 0;
        }

        private static bool PrintPoints(List<Point> points)
        {
            var minX = points.Min(p => p.X);
            var maxX = points.Max(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxY = points.Max(p => p.Y);

            if (maxX - minX > 200 || maxY - minY > 200)
            {
                Console.WriteLine("Too spread out");
                return false;
            }

            var grid = new bool[maxX - minX + 1, maxY - minY + 1];

            foreach(var point in points)
            {
                grid[point.X - minX, point.Y - minY] = true;
            }

            for (var y = minY; y <= maxY; y++)
            {
                for (var x = minX; x <= maxX; x++)
                {
                    Console.Write(grid[x-minX,y-minY] ? '#' : '.');
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            return true;
        }

        public static int SolveProblem2()
        {
            return 0;
        }

        private class Point
        {
            public int X;
            public int Y;

            public int XVelocity;
            public int YVelocity;

            public void Move()
            {
                X += XVelocity;
                Y += YVelocity;
            }
        }

    }
}