
namespace AdventOfCode
{
    internal class Day6
    {
        public static void RunPart1()
        {
            var line0 = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
            var line1 = "bvwbjplbgvbhsrlpgdmjqwftvncz";
            var line2 = "nppdvjthqldpwncqszvftbrmjlhg";
            var line3 = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";
            var line4 = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";

            if (FindMarkerPosition(line0, 14) != 19) throw new Exception();
            if (FindMarkerPosition(line1, 14) != 23) throw new Exception();
            if (FindMarkerPosition(line2, 14) != 23) throw new Exception();
            if (FindMarkerPosition(line3, 14) != 29) throw new Exception();
            if (FindMarkerPosition(line4, 14) != 26) throw new Exception(); FindMarkerPosition(line4, 14);
            
            var line = File.ReadAllLines("InputData/input6.txt")[0];
            if (FindMarkerPosition(line, 14) != 2178) throw new Exception();

            Console.WriteLine("Day 6 test passes!");
            Console.ReadLine();
        }

        private static int FindMarkerPosition(string line, int numberOfDistinctCharacters)
        {
            var lineAsArray = line.ToList();
            for (int i = 0; i < lineAsArray.Count; i++)
            {
                var startOfMessage = lineAsArray.GetRange(i, numberOfDistinctCharacters);
                var uniqueLetterCount = startOfMessage.Select(x => x).Distinct().Count();
                if (uniqueLetterCount == numberOfDistinctCharacters)
                {
                    return i + numberOfDistinctCharacters;
                }
            }

            throw new Exception("Not found!");
        }

        private static int FindMarkerPosition(string line)
        {
            int markerPosition = 0;
            int length = 14;

            for (var i = 0; i <= line.Length - 1; i++)
            {
                if (HasDuplicateCharacters(line, length, i))
                {
                    continue;
                }

                markerPosition = i + length;
                break;
            }

            return markerPosition;
        }

        private static bool HasDuplicateCharacters(string line, int length, int startingIndex)
        {
            for (int j = 0; j < length - 1; j++)
            {
                if (line.Substring(startingIndex + j + 1, length - j - 1).Contains(line[startingIndex + j]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
