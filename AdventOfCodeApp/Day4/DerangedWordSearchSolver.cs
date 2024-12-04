using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day4
{
    public static class DerangedWordSearchSolver
    {
        public static int Solve(string input)
        {
            var inputArray = DerangedWordSearchParser.Parse(input);
            int xmasCount = 0;

            for (int y = 0; y < inputArray.GetLength(0); y++)
            {
                for (int x = 0; x < inputArray.GetLength(1); x++)
                {
                    if (inputArray[x, y] == "X")                   
                    {                        
                        var instances = SearchAroundForWord(inputArray, x, y);
                        xmasCount += instances;
                    }
                }
            }

            return xmasCount;
        }

        private static int SearchAroundForWord(string[,] inputArray, int x, int y)
        {
            var result = 0;

            // Check backwards horizontal
            try { if (inputArray[x, y] + inputArray[x, y - 1] + inputArray[x, y - 2] + inputArray[x, y - 3] == "XMAS") result++;} catch (Exception){ }
            // Check forwards horizontal
            try { if (inputArray[x, y] + inputArray[x, y + 1] + inputArray[x, y + 2] + inputArray[x, y + 3] == "XMAS") result++; } catch (Exception) { }            
            // Check upwards vertical
            try { if (inputArray[x, y] + inputArray[x - 1, y] + inputArray[x - 2, y] + inputArray[x - 3, y] == "XMAS") result++; } catch (Exception) { }
            // Check downwards vertical
            try { if (inputArray[x, y] + inputArray[x + 1, y] + inputArray[x + 2, y] + inputArray[x + 3, y] == "XMAS") result++; } catch (Exception) { }
            // Check diagonal up-left
            try { if (inputArray[x, y] + inputArray[x - 1, y - 1] + inputArray[x - 2, y - 2] + inputArray[x - 3, y - 3] == "XMAS") result++; } catch (Exception) { }
            // Check diagonal up-right
            try { if (inputArray[x, y] + inputArray[x - 1, y + 1] + inputArray[x - 2, y + 2] + inputArray[x - 3, y + 3] == "XMAS") result++; } catch (Exception) { }
            // Check diagonal down-left
            try { if (inputArray[x, y] + inputArray[x + 1, y - 1] + inputArray[x + 2, y - 2] + inputArray[x + 3, y - 3] == "XMAS") result++; } catch (Exception) { }
            // Check diagonal down-right
            try { if (inputArray[x, y] + inputArray[x + 1, y + 1] + inputArray[x + 2, y + 2] + inputArray[x + 3, y + 3] == "XMAS") result++; } catch (Exception) { }

            return result;
        }
    }
}
