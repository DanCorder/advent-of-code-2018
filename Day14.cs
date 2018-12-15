namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day14
    {
        private const int ProblemInput = 681901;
        //private const int ProblemInput = 9;
        //private const int ProblemInput = 59414;
        private const string ProblemTestInput = @"";

        public static string SolveProblem1()
        {
            var numberOfFinalRecipes = 10;
            var finalRecipeCount = ProblemInput + numberOfFinalRecipes;
            var recipes = new int[finalRecipeCount + 1];
            recipes[0] = 3;
            recipes[1] = 7;
            var numberOfRecipesFound = 2;
            var elf1Position = 0;
            var elf2Position = 1;

            while (numberOfRecipesFound < finalRecipeCount)
            {
                var newTotalScore = recipes[elf1Position] + recipes[elf2Position];
                if (newTotalScore > 9)
                {
                    recipes[numberOfRecipesFound] = newTotalScore / 10;
                    recipes[numberOfRecipesFound + 1] = newTotalScore % 10;
                    numberOfRecipesFound += 2;
                }
                else
                {
                    recipes[numberOfRecipesFound] = newTotalScore;
                    numberOfRecipesFound += 1;
                }
                elf1Position = (1 + recipes[elf1Position] + elf1Position) % numberOfRecipesFound;
                elf2Position = (1 + recipes[elf2Position] + elf2Position) % numberOfRecipesFound;

                // Console.WriteLine("Elf1: " + elf1Position);
                // Console.WriteLine("Elf2: " + elf2Position);
                // for (var i = 0; i < numberOfRecipesFound; i++)
                // {
                //     Console.Write(recipes[i]);
                // }
                // Console.WriteLine();
            }

            return recipes[finalRecipeCount - 10].ToString() +
                recipes[finalRecipeCount - 9].ToString() +
                recipes[finalRecipeCount - 8].ToString() +
                recipes[finalRecipeCount - 7].ToString() +
                recipes[finalRecipeCount - 6].ToString() +
                recipes[finalRecipeCount - 5].ToString() +
                recipes[finalRecipeCount - 4].ToString() +
                recipes[finalRecipeCount - 3].ToString() +
                recipes[finalRecipeCount - 2].ToString() +
                recipes[finalRecipeCount - 1].ToString();
        }

        public static int SolveProblem2()
        {
            var finalRecipeCount = 100000000;
            var recipes = new int[finalRecipeCount + 1];
            recipes[0] = 3;
            recipes[1] = 7;
            var numberOfRecipesFound = 2;
            var elf1Position = 0;
            var elf2Position = 1;

            while (numberOfRecipesFound < finalRecipeCount)
            {
                var newTotalScore = recipes[elf1Position] + recipes[elf2Position];
                if (newTotalScore > 9)
                {
                    recipes[numberOfRecipesFound] = newTotalScore / 10;
                    recipes[numberOfRecipesFound + 1] = newTotalScore % 10;
                    numberOfRecipesFound += 2;


                }
                else
                {
                    recipes[numberOfRecipesFound] = newTotalScore;
                    numberOfRecipesFound += 1;
                }

                if (numberOfRecipesFound > 6)
                {
                    if ((recipes[numberOfRecipesFound - 6] * 100000) +
                        (recipes[numberOfRecipesFound - 5] * 10000) +
                        (recipes[numberOfRecipesFound - 4] * 1000) +
                        (recipes[numberOfRecipesFound - 3] * 100) +
                        (recipes[numberOfRecipesFound - 2] * 10) +
                        (recipes[numberOfRecipesFound - 1] * 1) == ProblemInput)
                    {
                        return numberOfRecipesFound - 6;
                    }
                    if ((recipes[numberOfRecipesFound - 7] * 100000) +
                        (recipes[numberOfRecipesFound - 6] * 10000) +
                        (recipes[numberOfRecipesFound - 5] * 1000) +
                        (recipes[numberOfRecipesFound - 4] * 100) +
                        (recipes[numberOfRecipesFound - 3] * 10) +
                        (recipes[numberOfRecipesFound - 2] * 1) == ProblemInput)
                    {
                        return numberOfRecipesFound - 7;
                    }
                }

                elf1Position = (1 + recipes[elf1Position] + elf1Position) % numberOfRecipesFound;
                elf2Position = (1 + recipes[elf2Position] + elf2Position) % numberOfRecipesFound;

                // Console.WriteLine("Elf1: " + elf1Position);
                // Console.WriteLine("Elf2: " + elf2Position);
                // for (var i = 0; i < numberOfRecipesFound; i++)
                // {
                //     Console.Write(recipes[i]);
                // }
                // Console.WriteLine();
            }

            return -1;
        }
    }
}