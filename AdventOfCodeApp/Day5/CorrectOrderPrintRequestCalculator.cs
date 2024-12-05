using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day5
{
    public static class CorrectOrderPrintRequestCalculator
    {
        public static int Solve(string input, bool solveForIncorrect = false)
        {
            var request = PrintRequestParser.Parse(input);
            var correctOrderUpdates = new List<List<int>>();
            var incorrectOrderUpdates = new List<List<int>>();
            foreach (var update in request.Updates)
            {
                bool ruleBroken = false;
                foreach (var rule in request.Rules)
                {
                    if (!CheckRule(rule.Item1, rule.Item2, update))
                    {
                        ruleBroken = true;
                        incorrectOrderUpdates.Add(update);
                        break;
                    }
                }
                if (!ruleBroken)
                {
                    correctOrderUpdates.Add(update);
                }
            }
            int correctOrderRequestMiddleNumberSum = 0;
            if (solveForIncorrect == false)
            {
                foreach (var item in correctOrderUpdates)
                {
                    correctOrderRequestMiddleNumberSum += item[(int)Math.Ceiling((double)(item.Count / 2))];
                }
            }
            else
            {
                foreach (var item in incorrectOrderUpdates)
                {
                    while (AnyRuleBroken(item, request.Rules))
                    {
                        foreach (var rule in request.Rules)
                        {
                            if (!CheckRule(rule.Item1, rule.Item2, item))
                            {
                                var temp = item[item.IndexOf(rule.Item1)];
                                item[item.IndexOf(rule.Item1)] = item[item.IndexOf(rule.Item2)];
                                item[item.IndexOf(rule.Item2)] = temp;
                                break;
                            }
                        }
                    }
                    correctOrderRequestMiddleNumberSum += item[(int)Math.Ceiling((double)(item.Count / 2))];
                }
            }
            return correctOrderRequestMiddleNumberSum;

        }

        public static bool AnyRuleBroken(List<int> update, List<Tuple<int, int>> rules)
        {
            foreach (var rule in rules)
            {
                if (!CheckRule(rule.Item1, rule.Item2, update))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckRule (int x, int y, List<int> update)
        {
            if (!update.Contains(x) || !update.Contains(y))
            {
                return true;
            }

            if (update.IndexOf(x) > update.IndexOf(y))
            {
                return false;
            }

            return true;


        }
    }
}
