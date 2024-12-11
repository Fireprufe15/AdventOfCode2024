using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeApp.Day11
{ 
    public static class StoneCounter
    {
        // Memoization dictionary: (stone configuration, blinks) -> stone count
        private static Dictionary<(string, int), double> memo = new Dictionary<(string, int), double>();

        public static double Solve(string input, int blinks)
        {
            // Parse the input stones and group them by their value
            var stoneCounts = input.Split(' ')
                                   .Select(double.Parse)
                                   .GroupBy(s => s)
                                   .ToDictionary(g => g.Key, g => (double)g.Count());

            memo.Clear(); // Clear the memoization dictionary for a fresh solve
            return RecursiveBlinker(stoneCounts, blinks);
        }

        private static double RecursiveBlinker(Dictionary<double, double> stoneCounts, int blinks)
        {
            if (blinks == 0)
            {
                // Sum up all stone counts when no blinks are left
                return stoneCounts.Values.Sum();
            }

            // Create a unique key for the current stone configuration and remaining blinks
            var key = (string.Join(",", stoneCounts.Select(kvp => $"{kvp.Key}:{kvp.Value}")), blinks);
            if (memo.ContainsKey(key))
            {
                // Return the memoized result if available
                return memo[key];
            }

            // Compute the next state of stones
            var newStoneCounts = DoABlink(stoneCounts);

            // Recursively process the next blinks
            var result = RecursiveBlinker(newStoneCounts, blinks - 1);

            // Store the result in the memoization dictionary
            memo[key] = result;

            return result;
        }

        private static Dictionary<double, double> DoABlink(Dictionary<double, double> stoneCounts)
        {
            var newStoneCounts = new Dictionary<double, double>();

            foreach (var (stone, count) in stoneCounts)
            {
                if (stone == 0)
                {
                    // If the stone is 0, it becomes a stone with value 1
                    AddStone(newStoneCounts, 1, count);
                }
                else if (stone.ToString().Length % 2 == 0)
                {
                    // If the stone has an even number of digits, split it into two stones
                    var stoneString = stone.ToString();
                    var halfLength = stoneString.Length / 2;

                    // Left half of the digits
                    var leftHalf = double.Parse(stoneString.Substring(0, halfLength));
                    AddStone(newStoneCounts, leftHalf, count);

                    // Right half of the digits
                    var rightHalf = double.Parse(stoneString.Substring(halfLength));
                    AddStone(newStoneCounts, rightHalf, count);
                }
                else
                {
                    // Otherwise, multiply the stone by 2024
                    AddStone(newStoneCounts, stone * 2024, count);
                }
            }

            return newStoneCounts;
        }

        private static void AddStone(Dictionary<double, double> stoneCounts, double stone, double count)
        {
            // Add the count of the stone to the dictionary, aggregating if it already exists
            if (!stoneCounts.ContainsKey(stone))
            {
                stoneCounts[stone] = 0;
            }
            stoneCounts[stone] += count;
        }
    }

}