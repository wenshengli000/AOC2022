namespace AdventOfCode
{
    internal class Day12
    {
        public static void Run()
        {
            var testHeightMap = new char[5, 8];
            var visitedTestMap = new VisitedDirection[5, 8];


            var heightMap = new char[41, 159];
            var visitedMap = new VisitedDirection[41, 159];
            var lines = File.ReadAllLines("InputData/input12Test.txt");
            for (int row = 0; row < lines.Length; row++)
            {
                for (int col = 0; col < lines[row].Length; col++)
                {
                    testHeightMap[row, col] = lines[row][col];
                    visitedTestMap[row, col] = new VisitedDirection();
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
                AddNeighboringReachableElvesPositions(startPosition, testHeightMap, visitedTestMap, ref destinationReached);
            }

            Console.WriteLine(steps);
            Console.ReadLine();
        }

        private static void AddNeighboringReachableElvesPositions(ElvesPosition currentPosition, char[, ] heightMap, VisitedDirection[, ] visitedDirectionMap, ref bool destinationReached)
        {
            if (!currentPosition.NeighboringReachableElvesPositions.Any())
            {
                //Look up
                if (currentPosition.Row - 1 > 0 && !visitedDirectionMap[currentPosition.Row - 1, currentPosition.Col].IsUpVisited)
                {
                    visitedDirectionMap[currentPosition.Row, currentPosition.Col].IsUpVisited = AddNeighbor(currentPosition,
                        heightMap, ref destinationReached, currentPosition.Row - 1, currentPosition.Col);
                }

                //Look down
                if (currentPosition.Row + 1 < heightMap.GetLength(0) && !visitedDirectionMap[currentPosition.Row + 1, currentPosition.Col].IsUpVisited)
                {
                    visitedDirectionMap[currentPosition.Row, currentPosition.Col].IsDownVisited = AddNeighbor(currentPosition, 
                        heightMap, ref destinationReached, currentPosition.Row + 1, currentPosition.Col);
                }

                //Look left
                if (currentPosition.Col - 1 > 0 && !visitedDirectionMap[currentPosition.Row, currentPosition.Col - 1].IsUpVisited)
                {
                    visitedDirectionMap[currentPosition.Row, currentPosition.Col].IsLeftVisited = AddNeighbor(currentPosition, 
                        heightMap, ref destinationReached, currentPosition.Row, currentPosition.Col - 1);
                }

                //Look right
                if (currentPosition.Col + 1 < heightMap.GetLength(1) && !visitedDirectionMap[currentPosition.Row, currentPosition.Col + 1].IsUpVisited)
                {
                    visitedDirectionMap[currentPosition.Row, currentPosition.Col].IsRightVisited = AddNeighbor(currentPosition, 
                        heightMap, ref destinationReached, currentPosition.Row, currentPosition.Col + 1);
                }
            }
            else
            {
                foreach (var neighboringReachableElvesPosition in currentPosition.NeighboringReachableElvesPositions)
                {
                    AddNeighboringReachableElvesPositions(neighboringReachableElvesPosition, 
                        heightMap, visitedDirectionMap, ref destinationReached);
                }
            }
        }

        private static bool AddNeighbor(ElvesPosition currentPosition, char[,] heightMap, ref bool destinationReached, int row, int col)
        {
            var neighbor = heightMap[row, col];
            if (neighbor.Equals('S'))
                return false;
            if(currentPosition.PreviousElvesPosition?.Row == row && currentPosition.PreviousElvesPosition?.Col == col)
                return false;
            if (neighbor.Equals('Z'))
            {
                destinationReached = true;
            }
            else if (currentPosition.Letter.Equals('S')|| Convert.ToInt32(neighbor) - Convert.ToInt32(currentPosition.Letter) <= 1)
            {
                currentPosition.NeighboringReachableElvesPositions.Add(new ElvesPosition(row,
                    col, neighbor, new List<ElvesPosition>(), currentPosition));
            }
            return true;
        }
    }

    internal class VisitedDirection
    {
        public bool IsUpVisited { get; set; }
        public bool IsDownVisited { get; set; }
        public bool IsLeftVisited { get; set; }
        public bool IsRightVisited { get; set; }
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
