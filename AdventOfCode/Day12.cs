namespace AdventOfCode
{
    internal class Day12
    {
        public static void Run()
        {
            var testHeightMap = new char[5, 8];
            var heightMap = new char[41, 159];
            var lines = File.ReadAllLines("InputData/input12Test.txt");
            for (int row = 0; row < lines.Length; row++)
            {
                for (int col = 0; col < lines[row].Length; col++)
                {
                    testHeightMap[row, col] = lines[row][col];
                }
            }

            lines = File.ReadAllLines("InputData/input12.txt");
            for (int row = 0; row < lines.Length; row++)
            {
                for (int col = 0; col < lines[row].Length; col++)
                {
                    heightMap[row, col] = lines[row][col];
                }
            }

            var startPosition = new ElvesPosition(0, 0, 'S', new List<ElvesPosition>(), null);
            var steps = 0;
            var destinationReached = false;
            for (int i = 0; i < 100; i++)
            {
                if (destinationReached)
                    break;
                steps++;
                AddNeighboringReachableElvesPositions(startPosition, testHeightMap, ref destinationReached);
            }

            Console.WriteLine(steps);
            Console.ReadLine();
        }

        private static void AddNeighboringReachableElvesPositions(ElvesPosition currentPosition, char[, ] heightMap, ref bool destinationReached)
        {
            if (!currentPosition.NeighboringReachableElvesPositions.Any())
            {
                //Look up
                AddNeighbor(currentPosition, heightMap, ref destinationReached, currentPosition.Row - 1, currentPosition.Col);

                //Look down
                AddNeighbor(currentPosition, heightMap, ref destinationReached, currentPosition.Row + 1, currentPosition.Col);

                //Look left
                AddNeighbor(currentPosition, heightMap, ref destinationReached, currentPosition.Row, currentPosition.Col - 1);

                //Look right
                AddNeighbor(currentPosition, heightMap, ref destinationReached, currentPosition.Row, currentPosition.Col + 1);
            }
            else
            {
                foreach (var neighboringReachableElvesPosition in currentPosition.NeighboringReachableElvesPositions)
                {
                    AddNeighboringReachableElvesPositions(neighboringReachableElvesPosition, heightMap, ref destinationReached);
                }
            }
        }

        private static void AddNeighbor(ElvesPosition currentPosition, char[,] heightMap, ref bool destinationReached, int row, int col)
        {
            try
            {
                var neighbor = heightMap[row, col];
                if(currentPosition.PreviousElvesPosition?.Row == row && currentPosition.PreviousElvesPosition?.Col == col)
                    return;
                if (neighbor.Equals('Z'))
                {
                    destinationReached = true;
                }
                else if (currentPosition.Letter.Equals('S')|| Convert.ToInt32(neighbor) - Convert.ToInt32(currentPosition.Letter) <= 1)
                {
                    currentPosition.NeighboringReachableElvesPositions.Add(new ElvesPosition(row,
                        col, neighbor, new List<ElvesPosition>(), currentPosition));
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
        }
    }

    internal class ElvesPosition
    {
        public ElvesPosition PreviousElvesPosition { get; set; }
        public List<ElvesPosition> NeighboringReachableElvesPositions{ get; set;}

        public ElvesPosition(int row, int col, char letter, List<ElvesPosition> neighboringReachableElvesPositions, ElvesPosition previousElvesPosition)
        {
            Row = row;
            Col = col;
            Letter = letter;
            NeighboringReachableElvesPositions = neighboringReachableElvesPositions;
            PreviousElvesPosition = previousElvesPosition;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public char Letter { get; set; }
    }
}
