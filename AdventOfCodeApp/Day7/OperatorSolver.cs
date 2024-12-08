using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day7
{
    public static class OperatorSolver
    {
        public static BigInteger Solve(string input, bool includeConcatOperator = false)
        {
            var equations = OperatorParser.Parse(input);
            BigInteger trueableEquationsSum = 0;
            var possibleOperators = new List<string> { "+", "*" };
            if (includeConcatOperator)
            {
                possibleOperators.Add("|");
            }
            foreach (var equation in equations)
            {
                var operatorCount = equation.Numbers.Length - 1;
                List<string> operatorCombinations;
                if (operatorCount == 1)
                {
                    operatorCombinations = possibleOperators;
                }
                else
                {
                    var permutations = GetPossiblePermutations(possibleOperators, operatorCount);
                    operatorCombinations = permutations.Select(p => string.Join("", p)).ToList();
                }

                foreach (var operatorCombination in operatorCombinations)
                {
                    var runningSolution = equation.Numbers[0];
                    for (int i = 0; i < operatorCombination.Length; i++)
                    {
                        if (operatorCombination[i] == '*')
                        {
                            runningSolution *= equation.Numbers[i + 1];
                        }
                        else if (operatorCombination[i] == '+')
                        {
                            runningSolution += equation.Numbers[i + 1];
                        }
                        else if (operatorCombination[i] == '|')
                        {
                            runningSolution = BigInteger.Parse(runningSolution.ToString() + equation.Numbers[i + 1].ToString());
                        }
                    }
                    if (runningSolution == equation.TestValue)
                    {
                        trueableEquationsSum+= equation.TestValue;
                        break;
                    }
                }

            }
            return trueableEquationsSum;
        }

        public static List<string> GetPossiblePermutations(List<string> operators, int length)
        {
            var permutations = new List<string>();
            if (length == 1)
            {
                return operators;
            }
            else
            {
                var subPermutations = GetPossiblePermutations(operators, length - 1);
                foreach (var subPermutation in subPermutations)
                {
                    foreach (var op in operators)
                    {
                        permutations.Add(subPermutation + op);
                    }
                }
            }
            return permutations;
        }

    }
}
