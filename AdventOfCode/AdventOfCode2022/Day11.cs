namespace AdventOfCode
{
    internal class Day11
    {
        public static void Run()
        {
            var numberOfRounds = 10000;
            var testMonkeys = CreateTestMonkeys();
            
            for (var i = 0; i < numberOfRounds; i++)
            {
                PlayMonkeyGame(testMonkeys);
            }

            var levelOfMonkeyBusiness = CalculateLevelOfMonkeyBusiness(testMonkeys);
            if (levelOfMonkeyBusiness != 2713310158) throw new Exception();


            var monkeys = CreateMonkeys();
            for (var i = 0; i < numberOfRounds; i++)
            {
                PlayMonkeyGame(monkeys);
            }

            levelOfMonkeyBusiness = CalculateLevelOfMonkeyBusiness(monkeys);
            if (levelOfMonkeyBusiness != 19754471646) throw new Exception();

            Console.ReadLine();
        }

        private static ulong CalculateLevelOfMonkeyBusiness(List<Monkey> testMonkeys)
        {
            testMonkeys = testMonkeys.OrderByDescending(monkey => monkey.NumberOfTimesInspectItem).ToList();
            var top1 = testMonkeys[0].NumberOfTimesInspectItem;
            var top2 = testMonkeys[1].NumberOfTimesInspectItem;
            var levelOfMonkeyBusiness = top1 * top2;
            return levelOfMonkeyBusiness;
        }

        private static void PlayMonkeyGame(List<Monkey> monkeys)
        {
            var divisibleCeiling = monkeys.Aggregate<Monkey?, ulong>(1, (current, monkey) => current * (ulong)monkey.DivisibleBy);
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.Items.ToList())
                {
                    monkey.NumberOfTimesInspectItem++;
                    var worryLevel = monkey.Operation(item, divisibleCeiling);
                    if (worryLevel % (ulong)monkey.DivisibleBy == 0)
                    {
                        monkeys[monkey.ThrowToIfTrue].Items.Add(worryLevel);
                    }
                    else
                    {
                        monkeys[monkey.ThrowToIfFalse].Items.Add(worryLevel);
                    }

                    monkey.Items.Remove(item);
                }
            }
        }

        private static List<Monkey> CreateTestMonkeys()
        {
            return new List<Monkey>
            {
                new()
                {
                    Items = new List<ulong> { 79, 98 },
                    Operation = (old, divisibleCeiling) => (old * 19) % divisibleCeiling,
                    DivisibleBy = 23,
                    ThrowToIfTrue = 2,
                    ThrowToIfFalse = 3
                },

                new()
                {
                    Items = new List<ulong> { 54, 65, 75, 74 },
                    Operation = (old, divisibleCeiling) => (old + 6) % divisibleCeiling,
                    DivisibleBy = 19,
                    ThrowToIfTrue = 2,
                    ThrowToIfFalse = 0
                },

                new()
                {
                    Items = new List<ulong> { 79, 60, 97 },
                    Operation = (old, divisibleCeiling) => old * old % divisibleCeiling,
                    DivisibleBy = 13,
                    ThrowToIfTrue = 1,
                    ThrowToIfFalse = 3
                },

                new()
                {
                    Items = new List<ulong> { 74 },
                    Operation = (old, divisibleCeiling) => (old + 3) % divisibleCeiling,
                    DivisibleBy = 17,
                    ThrowToIfTrue = 0,
                    ThrowToIfFalse = 1
                }
            };
        }

        private static List<Monkey> CreateMonkeys()
        {
            return new List<Monkey>
            {
                new()
                {
                    Items = new List<ulong> { 91, 66 },
                    Operation = (old, divisibleCeiling) => (old * 13) % divisibleCeiling,
                    DivisibleBy = 19,
                    ThrowToIfTrue = 6,
                    ThrowToIfFalse = 2
                },

                new()
                {
                    Items = new List<ulong> { 78, 97, 59 },
                    Operation = (old, divisibleCeiling) => (old + 7) % divisibleCeiling,
                    DivisibleBy = 5,
                    ThrowToIfTrue = 0,
                    ThrowToIfFalse = 3
                },

                new()
                {
                    Items = new List<ulong> {  57, 59, 97, 84, 72, 83, 56, 76},
                    Operation = (old, divisibleCeiling) => (old + 6) % divisibleCeiling,
                    DivisibleBy = 11,
                    ThrowToIfTrue = 5,
                    ThrowToIfFalse = 7
                },

                new()
                {
                    Items = new List<ulong> { 81, 78, 70, 58, 84},
                    Operation = (old, divisibleCeiling) => (old + 5) % divisibleCeiling,
                    DivisibleBy = 17,
                    ThrowToIfTrue = 6,
                    ThrowToIfFalse = 0
                },

                new()
                {
                    Items = new List<ulong> { 60},
                    Operation = (old, divisibleCeiling) => (old + 8) % divisibleCeiling,
                    DivisibleBy = 7,
                    ThrowToIfTrue = 1,
                    ThrowToIfFalse = 3
                },

                new()
                {
                    Items = new List<ulong> { 57, 69, 63, 75, 62, 77, 72},
                    Operation = (old, divisibleCeiling) => (old * 5) % divisibleCeiling,
                    DivisibleBy = 13,
                    ThrowToIfTrue = 7,
                    ThrowToIfFalse = 4
                },

                new()
                {
                    Items = new List<ulong> { 73, 66, 86, 79, 98, 87},
                    Operation = (old, divisibleCeiling) => (old * old) % divisibleCeiling,
                    DivisibleBy = 3,
                    ThrowToIfTrue = 5,
                    ThrowToIfFalse = 2
                },

                new()
                {
                    Items = new List<ulong> { 95, 89, 63, 67},
                    Operation = (old, divisibleCeiling) => (old + 2) % divisibleCeiling,
                    DivisibleBy = 2,
                    ThrowToIfTrue = 1,
                    ThrowToIfFalse = 4
                }
            };
        }
    }

    internal class Monkey
    {
        public ulong NumberOfTimesInspectItem { get; set; }
        public List<ulong> Items { get; set; }
        public Func<ulong, ulong, ulong> Operation { get; set; }

        public int DivisibleBy { get; set; }
        public int ThrowToIfTrue { get; set; }
        public int ThrowToIfFalse { get; set; }
    }
}
