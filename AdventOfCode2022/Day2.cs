namespace AdventOfCode
{
    internal class Day2
    {
        public static void Run()
        {
            var totalScore = 0;
            var lines = File.ReadAllLines("InputData/input2.txt");
            foreach (var line in lines)
            {
                var strings = line.Split(new[] { ' ' });
                var opponentHand = strings[0];
                var myHand = strings[1];
                var score = 0;

                if (opponentHand.Equals("A")) // Rock
                {
                    if (myHand.Equals("X")) // Rock
                    {
                        totalScore += 1 + 3;
                    }
                    else if (myHand.Equals("Y")) // Paper
                    {
                        totalScore += 2 + 6;
                    }
                    else if (myHand.Equals("Z")) // Scissors
                    {
                        totalScore += 3 + 0;
                    }
                }
                else if (opponentHand.Equals("B")) // Paper
                {
                    if (myHand.Equals("X")) // Rock
                    {
                        totalScore += 1 + 0;
                    }
                    else if (myHand.Equals("Y")) // Paper
                    {
                        totalScore += 2 + 3;
                    }
                    else if (myHand.Equals("Z")) // Scissors
                    {
                        totalScore += 3 + 6;
                    }
                }
                else if (opponentHand.Equals("C")) // Scissors
                {
                    if (myHand.Equals("X")) // Rock
                    {
                        totalScore += 1 + 6;
                    }
                    else if (myHand.Equals("Y")) // Paper
                    {
                        totalScore += 2 + 0;
                    }
                    else if (myHand.Equals("Z")) // Scissors
                    {
                        totalScore += 3 + 3;
                    }
                }
            }
            Console.WriteLine(totalScore);


            totalScore = 0;
            foreach (var line in lines)
            {
                var strings = line.Split(new[] { ' ' });
                var opponentHand = strings[0];
                var myHand = strings[1];
                var score = 0;

                if (opponentHand.Equals("A")) // Rock
                {
                    if (myHand.Equals("X")) // Lose
                    {
                        totalScore += 3 + 0; // Scissors
                    }
                    else if (myHand.Equals("Y")) // Draw
                    {
                        totalScore += 1 + 3; // Rock
                    }
                    else if (myHand.Equals("Z")) // Win
                    {
                        totalScore += 2 + 6; // Paper
                    }
                }
                else if (opponentHand.Equals("B")) // Paper
                {
                    if (myHand.Equals("X")) // Lose
                    {
                        totalScore += 1 + 0; // Rock
                    }
                    else if (myHand.Equals("Y")) // Draw
                    {
                        totalScore += 2 + 3; // Paper
                    }
                    else if (myHand.Equals("Z")) // Win
                    {
                        totalScore += 3 + 6; // Scissors
                    }
                }
                else if (opponentHand.Equals("C")) // Scissors
                {
                    if (myHand.Equals("X")) // Lose
                    {
                        totalScore += 2 + 0; // Paper
                    }
                    else if (myHand.Equals("Y")) // Draw
                    {
                        totalScore += 3 + 3; // Scissors
                    }
                    else if (myHand.Equals("Z")) // Win
                    {
                        totalScore += 1 + 6; // Rock
                    }
                }
            }
            Console.WriteLine(totalScore);
            Console.ReadLine();
        }
    }
}
