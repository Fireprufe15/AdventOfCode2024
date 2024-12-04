using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day4
{
    public static class XSolver
    {
        public static int Solve(string input)
        {
            var inputArray = DerangedWordSearchParser.Parse(input);
            int xmasCount = 0;

            for (int y = 0; y < inputArray.GetLength(0); y++)
            {
                for (int x = 0; x < inputArray.GetLength(1); x++)
                {
                    if (inputArray[x, y] == "A")
                    {
                        try
                        {
                            if (
                                ((inputArray[x - 1, y - 1] == "S" && inputArray[x + 1, y + 1] == "M") || (inputArray[x - 1, y - 1] == "M" && inputArray[x + 1, y + 1] == "S")) &&
                                ((inputArray[x - 1, y + 1] == "S" && inputArray[x + 1, y - 1] == "M") || (inputArray[x - 1, y + 1] == "M" && inputArray[x + 1, y - 1] == "S"))
                            ) { xmasCount++; }
                        }
                        catch { }
                    }
                }
            }

            return xmasCount;
        }
    }
}
