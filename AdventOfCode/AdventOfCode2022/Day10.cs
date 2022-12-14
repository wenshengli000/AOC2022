namespace AdventOfCode
{
    internal class Day10
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("InputData/input10.txt");
            var registerPosition = 1;
            var currentCycle = 1;

            var cyclesToCheck = new List<int> { 20, 60, 100, 140, 180, 220};
            var sumOfSignalStrength = 0;

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
                    currentCycle++;

                    CheckSumOfSignals(cyclesToCheck, currentCycle, registerPosition, ref sumOfSignalStrength);

                    DrawPixel(crt, registerPosition, width, ref col, ref row);
                    currentCycle++;

                    registerPosition += Convert.ToInt32(line.Split(new[] { ' ' })[1]);
                    CheckSumOfSignals(cyclesToCheck, currentCycle, registerPosition, ref sumOfSignalStrength);
                }
                if (line.StartsWith("noop"))
                {
                    DrawPixel(crt, registerPosition, width, ref col, ref row);
                    currentCycle++;
                    CheckSumOfSignals(cyclesToCheck, currentCycle, registerPosition, ref sumOfSignalStrength);
                }
            }

            if (sumOfSignalStrength != 15140) throw new Exception();

            var output = string.Join(string.Empty, crt.Cast<string>());
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

        private static void CheckSumOfSignals(List<int> cyclesToCheck, int currentCycle, int registerPosition, ref int sumOfSignalStrength)
        {
            if (cyclesToCheck.Any(cycle => cycle <= currentCycle))
            {
                var cycle = cyclesToCheck.First(cycle => cycle <= currentCycle);
                var signalStrength = cycle * registerPosition;
                sumOfSignalStrength += signalStrength;
                cyclesToCheck.Remove(cycle);
            }
        }
    }
}
