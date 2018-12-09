namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day09
    {
        private const string ProblemInput = @"400 players; last marble is worth 71864 points";
        private const string ProblemTestInput = @"";

        public static int SolveProblem1()
        {
            // var numberOfPlayers = 9;
            // var lastMarbleScore = 25;
            var numberOfPlayers = 400;
            var lastMarbleScore = 71864;

            var circle = new List<int>() { 0 };
            var currentMarbleIndex = 0;
            var marbleToPlaceScore = 1;
            var playerScores = new int[numberOfPlayers];
            var currentPlayerIndex = 0;

            while (marbleToPlaceScore <= lastMarbleScore)
            {
                if (marbleToPlaceScore % 23 == 0)
                {
                    playerScores[currentPlayerIndex] += marbleToPlaceScore;
                    var removeResult = RemoveMarble(circle, currentMarbleIndex);
                    playerScores[currentPlayerIndex] += removeResult.Item1;
                    currentMarbleIndex = removeResult.Item2;
                }
                else
                {
                    var nextPlacementIndex = GetNextPosition(circle, currentMarbleIndex);
                    nextPlacementIndex = nextPlacementIndex == 0 ? circle.Count : nextPlacementIndex;
                    circle.Insert(nextPlacementIndex, marbleToPlaceScore);
                    currentMarbleIndex = nextPlacementIndex;
                }

                marbleToPlaceScore++;
                currentPlayerIndex++;
                currentPlayerIndex = currentPlayerIndex % numberOfPlayers;
            }

            return playerScores.Max();
        }

        private static int GetNextPosition(List<int> circle, int currentMarbleIndex)
        {
            if (circle.Count == 1)
                return 1;

            return (currentMarbleIndex + 2) % (circle.Count);
        }

        private static Tuple<int, int> RemoveMarble(List<int> circle, int currentMarbleIndex)
        {
            while (currentMarbleIndex < 7)
            {
                currentMarbleIndex += circle.Count;
            }
            var removalIndex = (currentMarbleIndex - 7);
            var removedValue = circle[removalIndex];
            circle.RemoveAt(removalIndex);
            var newCurrentPosition = removalIndex;

            return new Tuple<int, int>(removedValue, newCurrentPosition);
        }

        private static Tuple<int, LinkedListNode<int>> RemoveMarble2(LinkedList<int> circle, LinkedListNode<int> currentMarbleIndex)
        {
            for (int i = 0; i < 6; i++)
            {
                currentMarbleIndex = currentMarbleIndex.Previous;
                if (currentMarbleIndex == null)
                {
                    currentMarbleIndex = circle.Last;
                }

            }

            var removalIndex = currentMarbleIndex.Previous == null ? circle.Last : currentMarbleIndex.Previous;
            var removedValue = removalIndex.Value;
            if (currentMarbleIndex.Previous == null)
            {
                circle.RemoveLast();
            }
            else
            {
                circle.Remove(currentMarbleIndex.Previous);
            }

            return new Tuple<int, LinkedListNode<int>>(removedValue, currentMarbleIndex);
        }

        private static LinkedListNode<int> GetNextPosition2(LinkedList<int> circle, LinkedListNode<int> currentMarbleIndex)
        {
            if (circle.Count == 1)
                return currentMarbleIndex;

            if (currentMarbleIndex.Next == null)
            {
                return circle.First;
            }
            return currentMarbleIndex.Next;
        }

        public static Int64 SolveProblem2()
        {
            // var numberOfPlayers = 9;
            // var lastMarbleScore = 25;
            var numberOfPlayers = 400;
            var lastMarbleScore = 7186400;

            var circle = new LinkedList<int>();
            circle.AddFirst(0);
            var currentMarbleIndex = circle.First;
            var marbleToPlaceScore = 1;
            var playerScores = new Int64[numberOfPlayers];
            var currentPlayerIndex = 0;

            while (marbleToPlaceScore <= lastMarbleScore)
            {
                if (marbleToPlaceScore % 23 == 0)
                {
                    playerScores[currentPlayerIndex] += marbleToPlaceScore;
                    var removeResult = RemoveMarble2(circle, currentMarbleIndex);
                    playerScores[currentPlayerIndex] += removeResult.Item1;
                    currentMarbleIndex = removeResult.Item2;
                }
                else
                {
                    var nextPlacementIndex = GetNextPosition2(circle, currentMarbleIndex);
                    circle.AddAfter(nextPlacementIndex, marbleToPlaceScore);
                    currentMarbleIndex = nextPlacementIndex.Next;
                }

                marbleToPlaceScore++;
                currentPlayerIndex++;
                currentPlayerIndex = currentPlayerIndex % numberOfPlayers;
            }

            return playerScores.Max();
        }
    }
}