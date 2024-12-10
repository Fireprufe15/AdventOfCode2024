using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day10
{
    public static class TrailheadSolver
    {
        public static int SolveTrailheadScores(string input, bool countSingleDestinationAsOneTrail)
        {
            var map = TopographicMapParser.Parse(input);
            var trailHeadScores = 0;
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y] == 0)
                    {
                        trailHeadScores += FindRoutesToNine(map, x, y, 0, countSingleDestinationAsOneTrail ? new List<Tuple<int, int>>() : null);
                    }
                }
            }
            return trailHeadScores;
        }

        public static int FindRoutesToNine(int[,] map, int x, int y, int currentHeight, List<Tuple<int,int>>? reachedNines)
        {
            if (reachedNines == null)
            {
                if (currentHeight == 9)
                {
                    return 1;
                }
            } 
            else
            {
                if (currentHeight == 9 && !reachedNines.Exists(coord => coord.Item1 == x && coord.Item2 == y))
                {
                    reachedNines.Add(new Tuple<int, int>(x, y));
                    return 1;
                }
                else if (currentHeight == 9)
                {
                    return 0;
                }
            }
            

            int routesToNine = 0;

            if ((x-1 > -1) && map[x-1,y] == currentHeight + 1)
            {
                routesToNine += FindRoutesToNine(map, x-1, y, currentHeight + 1, reachedNines);
            }
            if ((x + 1 < map.GetLength(0)) && map[x+1,y] == currentHeight + 1)
            {
                routesToNine += FindRoutesToNine(map, x+1, y, currentHeight + 1, reachedNines);
            }
            if ((y - 1 > -1) && map[x,y-1] == currentHeight + 1)
            {
                routesToNine += FindRoutesToNine(map, x, y-1, currentHeight + 1, reachedNines);
            }
            if ((y + 1 < map.GetLength(1)) && map[x,y+1] == currentHeight + 1)
            {
                routesToNine += FindRoutesToNine(map, x, y+1, currentHeight + 1, reachedNines);
            }

            return routesToNine;
        }
    }
}
