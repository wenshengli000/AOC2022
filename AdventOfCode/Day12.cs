namespace AdventOfCode
{
    internal class Day12
    {
        public static void Run()
        {
            var testHeightMap = new string[5, 8];
            var heightMap = new string[41, 159];
            var lines = File.ReadAllLines("InputData/input12Test.txt");
            for (int row = 0; row < lines.Length; row++)
            {
                for (int col = 0; col < lines[row].Length; col++)
                {
                    testHeightMap[row, col] = lines[row][col].ToString();
                }
            }

            lines = File.ReadAllLines("InputData/input12.txt");
            for (int row = 0; row < lines.Length; row++)
            {
                for (int col = 0; col < lines[row].Length; col++)
                {
                    heightMap[row, col] = lines[row][col].ToString();
                }
            }

            var allPaths = new List<List<Movement>>
            {
                new()
                {
                    new(0, 0, "S")
                }
            };

            foreach (var listOfMovements in allPaths)
            {
                foreach (var movement in listOfMovements)
                {
                    //if (testHeightMap[movement.Row++, movement.Col] <= movement.Letter)
                    //{
                        
                    //}
                }
            }

            Console.ReadLine();
        }
    }

    internal class Movement
    {
        public Movement(int row, int col, string letter)
        {
            Row = row;
            Col = col;
            Letter = letter;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public string Letter { get; set;}
    }
}
