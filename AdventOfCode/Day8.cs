namespace AdventOfCode
{
    internal class Day8
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("input8.txt");
            var height = lines.Length;
            var width = lines[0].Length;
            var forrest = new int[height, width];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    forrest[i, j] = Convert.ToInt32(lines[i][j].ToString());
                }
            }

            var numberOfVisibleTrees = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (IsTreeVisible(forrest, x, y, width, height))
                    {
                        numberOfVisibleTrees++;
                    }
                }
            }

            if (numberOfVisibleTrees != 1669) throw new Exception();


            var highestScenicScore = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var scenicScore = CalculateScenicScore(forrest, x, y, width, height);
                    if (scenicScore > highestScenicScore)
                    {
                        highestScenicScore = scenicScore;
                    }
                }
            }

            if (highestScenicScore != 331344) throw new Exception();
            Console.ReadLine();
        }

        private static bool IsTreeVisible(int[,] forrest, int x, int y, int width, int height)
        {
            if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
            {
                return true;
            }

            var list = new List<int>();

            //To the top
            for (int i = x - 1; i >= 0; i--)
            {
                list.Add(forrest[i, y]);
            }
            if (list.All(l => l < forrest[x, y]))
            {
                return true;
            }
            list.Clear();

            
            //To the right
            for (int i = y + 1; i <= width - 1; i++)
            {
                list.Add(forrest[x, i]);
            }

            if (list.All(l => l < forrest[x, y]))
            {
                return true;
            }
            list.Clear();

            //To the left
            for (int i = y -1 ; i >= 0; i--)
            {
                list.Add(forrest[x, i]);
            }

            if (list.All(l => l < forrest[x, y]))
            {
                return true;
            }
            list.Clear();

            //To the bottom
            for (int i = x + 1; i <= height - 1; i++)
            {
                list.Add(forrest[i, y]);
            }

            if (list.All(l => l < forrest[x, y]))
            {
                return true;
            }
            list.Clear();

            return false;
        }

        private static int CalculateScenicScore(int[,] forrest, int x, int y, int width, int height)
        {
            int score = 1;
            int count = 0;

            //To the top
            for (int i = x - 1; i >= 0; i--)
            {
                count++;
                if (forrest[i, y] >= forrest[x, y])
                {
                    break;
                }
            }

            score *= count;
            count = 0;

            //To the right
            for (int i = y + 1; i <= width - 1; i++)
            {
                count++;
                if (forrest[x, i] >= forrest[x, y])
                {
                    break;
                }
            }

            score *= count;
            count = 0;

            //To the left
            for (int i = y - 1; i >= 0; i--)
            {
                count++;
                if (forrest[x, i] >= forrest[x, y])
                {
                    break;
                }
            }

            score *= count;
            count = 0;

            //To the bottom
            for (int i = x + 1; i <= height - 1; i++)
            {
                count++;
                if (forrest[i, y] >= forrest[x, y])
                {
                    break;
                }
            }
            score *= count;
            return score;
        }
    }
}
