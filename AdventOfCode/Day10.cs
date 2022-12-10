using System.Text;

namespace AdventOfCode
{
    internal class Day10
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("input10.txt");
            var registerPosition = 1;
            var currentCycles = 1;

            var cyclesToCheck = new List<int> { 20, 60, 100, 140, 180, 220};
            var sumOfSignals = 0;

            var width = 40;
            var height = 6;

            var crt = new string[height, width];
            var row = 0;
            var col = 0;

            foreach (var line in lines)
            {
                if (line.StartsWith("addx"))
                {
                    DrawPixel(crt, registerPosition, width, ref col, ref row);
                    currentCycles++;

                    sumOfSignals = CheckSumOfSignals(cyclesToCheck, currentCycles, registerPosition, sumOfSignals);

                    DrawPixel(crt, registerPosition, width, ref col, ref row);
                    currentCycles++;

                    registerPosition += Convert.ToInt32(line.Split(new[] { ' ' })[1]);
                    sumOfSignals = CheckSumOfSignals(cyclesToCheck, currentCycles, registerPosition, sumOfSignals);
                }
                if (line.StartsWith("noop"))
                {
                    DrawPixel(crt, registerPosition, width, ref col, ref row);
                    currentCycles++;
                    sumOfSignals = CheckSumOfSignals(cyclesToCheck, currentCycles, registerPosition, sumOfSignals);
                }
            }

            if (sumOfSignals != 15140) throw new Exception();

            var output =new StringBuilder();
            for (int r = 0; r < height; r++)
            {
                var line = string.Empty;
                for (int c = 0; c < width; c++)
                {
                    line += crt[r, c];
                }

                output.Append(line);
                Console.WriteLine(line);
            }

            if (!output.Equals(
                    "###..###....##..##..####..##...##..###..#..#.#..#....#.#..#....#.#..#.#..#.#..#.###..#..#...." +
                    "#.#..#...#..#....#..#.#..#.#..#.###.....#.####..#...#.##.####.###..#..#.#....#..#.#..#.#....#..#.#.." +
                    "#.#....###..#.....##..#..#.####..###.#..#.#...."))
                throw new Exception();
            Console.ReadLine();
        }

        private static void DrawPixel(string[,] crt, int registerPosition, int width, ref int col, ref int row)
        {
            if (registerPosition <= col + 1 && registerPosition >= col - 1)
            {
                crt[row, col] = "#";
            }
            else
            {
                crt[row, col] = ".";
            }
            if (col < width - 1)
            {
                col++;
            }
            else
            {
                col = 0;
                row++;
            }
        }

        private static int CheckSumOfSignals(List<int> cyclesToCheck, int currentCycles, int valueOfX, int sumOfSignals)
        {
            if (cyclesToCheck.Any(x => x <= currentCycles))
            {
                var currentCycle = cyclesToCheck.First(x => x <= currentCycles);
                var signalStrength = currentCycle * valueOfX;
                sumOfSignals += signalStrength;
                cyclesToCheck.Remove(currentCycle);
            }

            return sumOfSignals;
        }
    }
}
