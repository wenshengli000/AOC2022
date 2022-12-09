
namespace AdventOfCode
{
    internal class Day5
    {
        public static void RunPart1()
        {
            var lines = File.ReadAllLines("input5.txt");
            var stacksOfCrates = CreateStackOfCrates(lines);
            MoveStackOfCrates(lines, stacksOfCrates);

            var message = "";
            for (int i = 1; i <= stacksOfCrates.Count; i++)
            {
                message += stacksOfCrates[i].Last();
            }
            Console.WriteLine(message);
            Console.ReadLine();
        }

        private static void MoveStackOfCrates(string[] lines, Dictionary<int, List<string>> stacksOfCrates)
        {
            foreach (var line in lines)
            {
                if (line.StartsWith("move"))
                {
                    var actions = line.Split(new[] { ' ' });
                    var numberOfCrates = Convert.ToInt32(actions[1]);
                    var stackFrom = Convert.ToInt32(actions[3]);
                    var stackTo = Convert.ToInt32(actions[5]);

                    var cratesToMove = stacksOfCrates[stackFrom].TakeLast(numberOfCrates).Reverse().ToList();
                    stacksOfCrates[stackFrom].RemoveRange(stacksOfCrates[stackFrom].Count - numberOfCrates, numberOfCrates);
                    stacksOfCrates[stackTo].AddRange(cratesToMove);
                }
            }
        }

        private static Dictionary<int, List<string>> CreateStackOfCrates(string[] lines)
        {
            var stacksOfCrates = new Dictionary<int, List<string>>
            {
                { 1, new List<string> ()},
                { 2, new List<string> ()},
                { 3, new List<string> ()},
                { 4, new List<string> ()},
                { 5, new List<string> ()},
                { 6, new List<string> ()},
                { 7, new List<string> ()},
                { 8, new List<string> ()},
                { 9, new List<string> () },
            };
            foreach (var line in lines)
            {
                if (line.StartsWith("["))
                {
                    var charArray = line.ToCharArray();
                    foreach (var index in stacksOfCrates.Keys)
                    {
                        var value = charArray[4 * (index - 1) + 1].ToString();
                        if (!String.IsNullOrWhiteSpace(value))
                        {
                            stacksOfCrates[index].Add(value);
                        }
                    }
                }
            }

            foreach (var crate in stacksOfCrates.Values)
            {
                crate.Reverse();
            }

            return stacksOfCrates;
        }

        public static void RunPart2()
        {
            var lines = File.ReadAllLines("input5.txt");
            var totalOverlaps = 0;
            var totalNotOverlaps = 0;
            foreach (var line in lines)
            {
               
            }
            Console.WriteLine(totalOverlaps);
            Console.WriteLine(totalNotOverlaps);
            Console.ReadLine();
        }
    }
}
