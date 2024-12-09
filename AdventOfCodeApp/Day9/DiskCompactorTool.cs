using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeApp.Day9
{
    public static class DiskCompactorTool
    {
        public static double CompactDiskAndGetChecksum(string input)
        {
            input = input.Trim();
            var mappedString = MapDrive(input);
            var compactedDriveMap = CompactDrive(mappedString);
            var checksum = CalculateDriveChecksum(compactedDriveMap);
            return checksum;            
            
        }

        public static double CompactDiskAndGetChecksumWithDefragmentation(string input)
        {
            input = input.Trim();
            var mappedString = MapDrive(input);
            var compactedDriveMap = CompactDriveWithDefragmentation(mappedString);
            var checksum = CalculateDriveChecksum(compactedDriveMap);
            return checksum;            
        }

        private static double CalculateDriveChecksum(List<int> driveMap) 
        {
            double checksum = 0;
            for (int i = 0; i < driveMap.Count; i++)
            {
                if (driveMap[i] != -1)
                {
                    checksum += double.Parse(driveMap[i].ToString()) * i;
                }
            }
            return checksum;
        }

        private static List<int> CompactDrive(List<int> driveMap)
        {
            var compactedDriveMap = new int[driveMap.Count];
            driveMap.CopyTo(compactedDriveMap);
            for (int i = driveMap.Count - 1; i >= 0; i--)
            {
                int firstFreeSpaceIndex = Array.IndexOf(compactedDriveMap, -1);
                if (firstFreeSpaceIndex < i)
                {
                    compactedDriveMap[firstFreeSpaceIndex] = driveMap[i];
                    compactedDriveMap[i] = -1;
                }
            }            

            return [.. compactedDriveMap];
        }

        private static List<int> CompactDriveWithDefragmentation(List<int> driveMap)
        {
            var compactedDriveMap = new int[driveMap.Count];
            driveMap.CopyTo(compactedDriveMap);
            var largestId = driveMap.Max();
            for (int i = largestId; i > -1; i--)
            {
                var blockSize = driveMap.Count(x => x == i);
                var movingBlockIndex = Array.IndexOf(compactedDriveMap, i);
                var blockSizeCount = 0;
                var blockStartIndex = 0;

                for (int b = 0; b < movingBlockIndex; b++)
                {
                    if (compactedDriveMap[b] == -1) blockSizeCount++;
                    else
                    {
                        blockSizeCount = 0;
                        blockStartIndex = b + 1;
                    }
                    if (blockSizeCount == blockSize) break;
                }

                if (blockSizeCount == blockSize)
                {
                    for (int bs = movingBlockIndex; bs < movingBlockIndex + blockSize; bs++)
                    {
                        compactedDriveMap[bs] = -1;
                    }

                    for (int bs = blockStartIndex; bs < blockStartIndex + blockSize; bs++)
                    {
                        compactedDriveMap[bs] = i;
                    }                    
                }

            }

            return [.. compactedDriveMap];
        }

        private static List<int> MapDrive(string input)
        {
            int currentId = 0;
            bool freeSpaceMode = false;
            var mappedDrive = new List<int>();
            foreach (var character in input)
            {
                var number = int.Parse(character.ToString());
                if (freeSpaceMode)
                {
                    for (int i = 0; i < number; i++)
                    {
                        mappedDrive.Add(-1);
                    }
                    freeSpaceMode = !freeSpaceMode;
                }
                else
                {
                    for (int i = 0; i < number; i++)
                    {
                        mappedDrive.Add(currentId);
                    }
                    currentId++;
                    freeSpaceMode = !freeSpaceMode;
                }
            }
            return mappedDrive;
        }
    }
}
