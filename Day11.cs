namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day11
    {
        private const string ProblemInput = @"";
        private const string ProblemTestInput = @"";

        public static string SolveProblem1()
        {
            var gridSerialNumber = 5791;
            var powerGrid = new int[300, 300];

            for (var x = 0; x < 300; x++)
            {
                for (var y = 0; y < 300; y++)
                {
                    var rackId = x + 11;
                    var powerLevel = rackId * (y + 1);
                    powerLevel += gridSerialNumber;
                    powerLevel *= rackId;
                    if (powerLevel < 100)
                        powerLevel = 0;
                    else
                        powerLevel = (powerLevel / 100) % 10;
                    powerGrid[x,y] = powerLevel - 5;
                }
            }

            var maxPower = int.MinValue;
            var maxX = -1;
            var maxY = -1;
            for (var x = 0; x < 297; x++)
            {
                for (var y = 0; y < 297; y++)
                {
                    var power =
                        powerGrid[x,y] +
                        powerGrid[x+1,y] +
                        powerGrid[x+2,y] +
                        powerGrid[x,y+1] +
                        powerGrid[x+1,y+1] +
                        powerGrid[x+2,y+1] +
                        powerGrid[x,y+2] +
                        powerGrid[x+1,y+2] +
                        powerGrid[x+2,y+2];

                    if (power > maxPower)
                    {
                        maxPower = power;
                        maxX = x+1;
                        maxY = y+1;
                    }
                }
            }

            return maxX.ToString() + "," + maxY.ToString();
        }

        public static string SolveProblem2()
        {
            var gridSerialNumber = 5791;
            var powerGrid = new int[300, 300];

            for (var x = 0; x < 300; x++)
            {
                for (var y = 0; y < 300; y++)
                {
                    var rackId = x + 11;
                    var powerLevel = rackId * (y + 1);
                    powerLevel += gridSerialNumber;
                    powerLevel *= rackId;
                    if (powerLevel < 100)
                        powerLevel = 0;
                    else
                        powerLevel = (powerLevel / 100) % 10;
                    powerGrid[x,y] = powerLevel - 5;
                }
            }

            var maxPower = int.MinValue;
            var maxX = -1;
            var maxY = -1;
            var maxSize = -1;
            for (var x = 0; x < 300; x++)
            {
                for (var y = 0; y < 300; y++)
                {
                    var maxAvailableSize = Math.Min(300 - x, 300 - y);
                    for (var size = 1; size <= maxAvailableSize; size++)
                    {
                        var power = 0;
                        for (var xPos = x; xPos < x + size; xPos++)
                        {
                            for (var yPos = y; yPos < y + size; yPos++)
                            {
                                power += powerGrid[xPos, yPos];
                            }
                        }

                        if (power > maxPower)
                        {
                            maxPower = power;
                            maxX = x+1;
                            maxY = y+1;
                            maxSize = size;
                        }
                    }
                }
            }

            return maxX.ToString() + "," + maxY.ToString() + "," + maxSize.ToString();
        }
    }
}