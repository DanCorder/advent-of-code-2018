namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day07
    {
        private const string Problem1TestInput =  @"Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin.";
        private const string Problem1Input = @"Step I must be finished before step Q can begin.
Step B must be finished before step O can begin.
Step J must be finished before step M can begin.
Step W must be finished before step Y can begin.
Step U must be finished before step X can begin.
Step T must be finished before step Q can begin.
Step G must be finished before step M can begin.
Step K must be finished before step C can begin.
Step F must be finished before step Z can begin.
Step D must be finished before step A can begin.
Step N must be finished before step Y can begin.
Step Y must be finished before step Q can begin.
Step Q must be finished before step Z can begin.
Step V must be finished before step E can begin.
Step A must be finished before step X can begin.
Step E must be finished before step C can begin.
Step O must be finished before step R can begin.
Step P must be finished before step L can begin.
Step H must be finished before step R can begin.
Step M must be finished before step R can begin.
Step C must be finished before step Z can begin.
Step R must be finished before step L can begin.
Step L must be finished before step S can begin.
Step S must be finished before step X can begin.
Step Z must be finished before step X can begin.
Step T must be finished before step O can begin.
Step D must be finished before step Z can begin.
Step P must be finished before step R can begin.
Step M must be finished before step Z can begin.
Step L must be finished before step Z can begin.
Step W must be finished before step N can begin.
Step Q must be finished before step R can begin.
Step P must be finished before step C can begin.
Step U must be finished before step O can begin.
Step F must be finished before step O can begin.
Step K must be finished before step X can begin.
Step G must be finished before step K can begin.
Step M must be finished before step C can begin.
Step Y must be finished before step Z can begin.
Step A must be finished before step O can begin.
Step D must be finished before step P can begin.
Step K must be finished before step S can begin.
Step I must be finished before step E can begin.
Step G must be finished before step F can begin.
Step S must be finished before step Z can begin.
Step N must be finished before step V can begin.
Step F must be finished before step D can begin.
Step A must be finished before step Z can begin.
Step F must be finished before step X can begin.
Step T must be finished before step Y can begin.
Step W must be finished before step H can begin.
Step D must be finished before step H can begin.
Step W must be finished before step G can begin.
Step J must be finished before step X can begin.
Step T must be finished before step X can begin.
Step U must be finished before step R can begin.
Step O must be finished before step P can begin.
Step L must be finished before step X can begin.
Step I must be finished before step B can begin.
Step M must be finished before step L can begin.
Step C must be finished before step R can begin.
Step R must be finished before step X can begin.
Step F must be finished before step N can begin.
Step V must be finished before step H can begin.
Step K must be finished before step A can begin.
Step W must be finished before step O can begin.
Step U must be finished before step Q can begin.
Step O must be finished before step C can begin.
Step K must be finished before step V can begin.
Step R must be finished before step S can begin.
Step E must be finished before step S can begin.
Step J must be finished before step A can begin.
Step E must be finished before step X can begin.
Step K must be finished before step Y can begin.
Step Y must be finished before step X can begin.
Step P must be finished before step Z can begin.
Step W must be finished before step X can begin.
Step Y must be finished before step A can begin.
Step V must be finished before step X can begin.
Step O must be finished before step M can begin.
Step I must be finished before step J can begin.
Step W must be finished before step L can begin.
Step I must be finished before step G can begin.
Step D must be finished before step O can begin.
Step D must be finished before step N can begin.
Step M must be finished before step X can begin.
Step I must be finished before step R can begin.
Step Y must be finished before step M can begin.
Step F must be finished before step M can begin.
Step U must be finished before step M can begin.
Step Y must be finished before step H can begin.
Step K must be finished before step D can begin.
Step N must be finished before step O can begin.
Step H must be finished before step S can begin.
Step G must be finished before step L can begin.
Step T must be finished before step D can begin.
Step J must be finished before step N can begin.
Step K must be finished before step M can begin.
Step K must be finished before step P can begin.
Step E must be finished before step R can begin.
Step N must be finished before step H can begin.";

        public static string SolveProblem1()
        {
            var lines = Problem1Input.SplitToLines();
            var previousStepsByStep = new Dictionary<char, List<char>>();
            var allSteps = new List<char>();

            foreach (var line in lines)
            {
                var words = line.Split(' ');
                var step = words[7][0];
                var previousStep = words[1][0];

                if (!previousStepsByStep.ContainsKey(step))
                {
                    previousStepsByStep[step] = new List<char>();
                }

                previousStepsByStep[step].Add(previousStep);

                if (!allSteps.Contains(step))
                {
                    allSteps.Add(step);
                }
                if (!allSteps.Contains(previousStep))
                {
                    allSteps.Add(previousStep);
                }
            }
            allSteps = allSteps.OrderBy(c => c).ToList();
            var numberOfSteps = allSteps.Count;

            var allStepsInOrder = new List<char>();

            while (allStepsInOrder.Count < numberOfSteps)
            {
                var stepsWithNoPrevious = new List<char>();
                foreach (var step in allSteps)
                {
                    if (!previousStepsByStep.ContainsKey(step) ||
                        previousStepsByStep[step].Count == 0)
                    {
                        stepsWithNoPrevious.Add(step);
                    }
                }

                stepsWithNoPrevious = stepsWithNoPrevious.OrderBy(c => c).ToList();
                var nextStep = stepsWithNoPrevious[0];

                allStepsInOrder.Add(nextStep);

                allSteps.Remove(nextStep);
                previousStepsByStep.Remove(nextStep);

                foreach (var step in previousStepsByStep.Keys)
                {
                    previousStepsByStep[step].Remove(nextStep);
                }
            }

            return String.Concat(allStepsInOrder);
        }

        public static int SolveProblem2()
        {
            var lines = Problem1Input.SplitToLines();
            var previousStepsByStep = new Dictionary<char, List<char>>();
            var stepsRemaining = new List<char>();

            foreach (var line in lines)
            {
                var words = line.Split(' ');
                var step = words[7][0];
                var previousStep = words[1][0];

                if (!previousStepsByStep.ContainsKey(step))
                {
                    previousStepsByStep[step] = new List<char>();
                }

                previousStepsByStep[step].Add(previousStep);

                if (!stepsRemaining.Contains(step))
                {
                    stepsRemaining.Add(step);
                }
                if (!stepsRemaining.Contains(previousStep))
                {
                    stepsRemaining.Add(previousStep);
                }
            }
            stepsRemaining = stepsRemaining.OrderBy(c => c).ToList();
            var numberOfSteps = stepsRemaining.Count;

            var workers = new Worker[] {new Worker(), new Worker(), new Worker(), new Worker(), new Worker()};
            var time = 0;

            while(true)
            {
                var nextSteps = getAvailableSteps(stepsRemaining, previousStepsByStep);
                foreach (var worker in workers)
                {
                    if (worker.TimeRemaining == 0 &&
                        nextSteps.Count > 0)
                    {
                        char step = nextSteps[0];
                        worker.Job = step;
                        worker.TimeRemaining = getTimeForJob(step);
                        nextSteps.Remove(step);
                        stepsRemaining.Remove(step);
                    }
                }

                if (workers.All(w => w.TimeRemaining == 0))
                    break;

                var minTime = int.MaxValue;
                foreach (var worker in workers)
                {
                    if (worker.TimeRemaining != 0)
                        minTime = Math.Min(minTime, worker.TimeRemaining);
                }
                time += minTime;

                foreach (var worker in workers)
                {
                    if (worker.TimeRemaining != 0)
                    {
                        worker.TimeRemaining -= minTime;
                        if (worker.TimeRemaining == 0)
                        {
                            completeStep(worker.Job, previousStepsByStep);
                        }
                    }
                }
            }

            return time;
        }

        private class Worker
        {
            public int TimeRemaining = 0;
            public char Job = ' ';
        }

        private static int getTimeForJob(char step)
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(step) + 61;
        }

        private static List<char> getAvailableSteps(List<char> allSteps, Dictionary<char, List<char>> previousStepsByStep)
        {
            var stepsWithNoPrevious = new List<char>();
            foreach (var step in allSteps)
            {
                if (!previousStepsByStep.ContainsKey(step) ||
                    previousStepsByStep[step].Count == 0)
                {
                    stepsWithNoPrevious.Add(step);
                }
            }

            return stepsWithNoPrevious.OrderBy(c => c).ToList();
        }

        private static void completeStep(char completedStep, Dictionary<char, List<char>> previousStepsByStep)
        {
            previousStepsByStep.Remove(completedStep);

            foreach (var step in previousStepsByStep.Keys)
            {
                previousStepsByStep[step].Remove(completedStep);
            }
        }
    }

}