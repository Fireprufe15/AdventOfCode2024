using AdventOfCodeApp.Day8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day12
{
    public static class GardenFenceCalculator
    {
        public static (int, int) Solve(string input)
        {
            var map = AntennaMapParser.ParseMap(input);
            var regions = new List<List<(int x, int y, int edges)>>();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    var region = new List<(int x, int y, int edges)>();
                    if (regions.Exists(r => r.Exists(coord => coord.x == x && coord.y == y)))
                    {
                        continue;
                    }
                    regions.Add(ExpandRegion(map, (x, y), region));
                }
            }

            int totalCost = 0;
            int totalCostWithDiscount = 0;
            foreach (var region in regions)
            {
                var regionArea = region.Count;
                var regionEdges = region.Sum(r => r.edges);
                var regionSides = CountRegionStraightSides(region);
                totalCostWithDiscount += regionArea * regionSides;
                totalCost += regionArea * regionEdges;
            }
            return (totalCost, totalCostWithDiscount);
        }

        private static int CountRegionStraightSides(List<(int x, int y, int edges)> region)
        {      
            int sides = 0;
            for (int i = 0; i < region.Max(x => x.x)+1; i++)
            {
                var corners = region.Where(x => x.x == i).Sum(x => x.edges - 1 >= 0 ? x.edges - 1 : 0);
                sides += corners / 2;
            }

            for (int i = 0; i < region.Max(x => x.y)+1; i++)
            {
                var corners = region.Where(x => x.y == i).Sum(x => x.edges - 1 >= 0 ? x.edges - 1 : 0);
                sides += corners / 2;
            }
            return sides;
            //var corners = region.Sum(r => r.edges - 1 >= 0 ? r.edges - 1 : 0);
            //return corners / 2;
            //int xSides = region.Count(r => !region.Exists(regCoord => (regCoord.x == r.x + 1) && regCoord.y == r.y));
            //xSides += region.Count(r => !region.Exists(regCoord => (regCoord.x == r.x - 1) && regCoord.y == r.y));
            //int ySides = region.Count(r => !region.Exists(regCoord => (regCoord.y == r.y + 1) && regCoord.x == r.x));
            //ySides += region.Count(r => !region.Exists(regCoord => (regCoord.y == r.y - 1) && regCoord.x == r.x));
            //return xSides + ySides;
        }

        private static List<(int x, int y, int edges)> ExpandRegion(char[,] map, (int x, int y) coord, List<(int x, int y, int edges)> existingRegionArea)
        {
            if (!existingRegionArea.Exists(x => x.x == coord.x && x.y == coord.y))
            {
                var edges = 0;
                if (coord.x + 1 == map.GetLength(0) || map[coord.x + 1, coord.y] != map[coord.x, coord.y]) edges++;
                if (coord.y + 1 == map.GetLength(1) || map[coord.x, coord.y + 1] != map[coord.x, coord.y]) edges++;
                if (coord.x - 1 == -1 || map[coord.x - 1, coord.y] != map[coord.x, coord.y]) edges++;
                if (coord.y - 1 == -1 || map[coord.x, coord.y - 1] != map[coord.x, coord.y]) edges++;

                existingRegionArea.Add((coord.x, coord.y, edges));

                if (coord.x + 1 < map.GetLength(0) && map[coord.x + 1, coord.y] == map[coord.x, coord.y])
                {
                    ExpandRegion(map, (coord.x + 1, coord.y), existingRegionArea);
                }
                if (coord.x - 1 >= 0 && map[coord.x - 1, coord.y] == map[coord.x, coord.y])
                {
                    ExpandRegion(map, (coord.x - 1, coord.y), existingRegionArea);
                }
                if (coord.y + 1 < map.GetLength(1) && map[coord.x, coord.y + 1] == map[coord.x, coord.y])
                {
                    ExpandRegion(map, (coord.x, coord.y + 1), existingRegionArea);
                }
                if (coord.y - 1 >= 0 && map[coord.x, coord.y - 1] == map[coord.x, coord.y])
                {
                    ExpandRegion(map, (coord.x, coord.y - 1), existingRegionArea);
                }
            }
            
            return existingRegionArea;
        }
    }
}
