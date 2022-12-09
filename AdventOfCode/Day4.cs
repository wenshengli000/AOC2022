
namespace AdventOfCode
{
    internal class Day4
    {
        public static void RunPart1()
        {
            var lines = File.ReadAllLines("input4.txt");
            var totalFullyContainingPairs = 0;
            foreach (var line in lines)
            {
                var firstPair = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0];
                var secondPair = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1];
                if (DoesContainOneAnother(firstPair, secondPair))
                {
                    totalFullyContainingPairs++;
                }
                else if (DoesContainOneAnother(secondPair, firstPair))
                {
                    totalFullyContainingPairs++;
                }
            }
            Console.WriteLine(totalFullyContainingPairs);
            Console.ReadLine();
        }

        private static bool DoesContainOneAnother(string pair1, string pair2)
        {
            return Convert.ToInt32(pair1.Split(new[] { '-' })[0]) <=
                   Convert.ToInt32(pair2.Split(new[] { '-' })[0])
                   && Convert.ToInt32(pair1.Split(new[] { '-' })[1]) >=
                   Convert.ToInt32(pair2.Split(new[] { '-' })[1]);
        }

        public static void RunPart2()
        {
            var lines = File.ReadAllLines("input4.txt");
            var totalOverlaps = 0;
            var totalNotOverlaps = 0;
            foreach (var line in lines)
            {
                var firstPair = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0];
                var secondPair = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1];
                if (DoesOverlap(firstPair, secondPair))
                {
                    totalOverlaps++;
                }
                else if (DoesOverlap(secondPair, firstPair))
                {
                    totalOverlaps++;
                }
                else
                {
                    totalNotOverlaps++;
                }
            }
            Console.WriteLine(totalOverlaps);
            Console.WriteLine(totalNotOverlaps);
            Console.ReadLine();
        }

        private static bool DoesOverlap(string pair1, string pair2)
        {
            return Convert.ToInt32(pair1.Split(new[] { '-' })[1]) >=
                   Convert.ToInt32(pair2.Split(new[] { '-' })[0])
                   && Convert.ToInt32(pair1.Split(new[] { '-' })[0]) <=
                   Convert.ToInt32(pair2.Split(new[] { '-' })[1]);
        }
    }
}
