using System.Text;

namespace AdventOfCode
{
    internal class Day3
    {
        public static void RunPart1()
        {
            var lines = File.ReadAllLines("InputData/input3.txt");
            var prioritySum = 0;
            foreach (var line in lines)
            {
                var sharedLetter = FindSharedLetter(line);
                int priority = CalculatePriority(sharedLetter);
                prioritySum += priority;
            }
            Console.WriteLine(prioritySum);
            Console.ReadLine();
        }

        public static void RunPart2()
        {
            var lines = File.ReadAllLines("InputData/input3.txt");
            var prioritySum = 0;
            for (int i = 0; i < lines.Length; i+=3)
            {
                var sharedLetter = FindSharedLetter(new[] { lines[i], lines[i + 1], lines[i +2 ] });
                int priority = CalculatePriority(sharedLetter);
                prioritySum += priority;
            }
             
            Console.WriteLine(prioritySum);
            Console.ReadLine();
        }



        private static int CalculatePriority(char sharedLetter)
        {
            var asciiCode = Encoding.ASCII.GetBytes(sharedLetter.ToString())[0];
            if (asciiCode >= 97 && asciiCode <= 122 ) // a - z 
            {
                return asciiCode - 96;
            }

            if (asciiCode >= 65 && asciiCode <= 90) // A - Z
            {
                return asciiCode - 38;
            }

            throw new Exception("Ascii code not found!");
        }

        private static char FindSharedLetter(string line)
        {
            var firstCompartment = line.Substring(0, line.Length/ 2);
            var secondCompartment = line.Substring(line.Length / 2, line.Length/2);
            for (int i = 0; i <= firstCompartment.Length - 1; i++)
            {
                if (secondCompartment.Contains(firstCompartment[i]))
                {
                    return firstCompartment[i];
                }
            }

            throw new Exception("Shared letter not found");
        }

        private static char FindSharedLetter(string[] line)
        {
            for (int i = 0; i <= line[0].Length - 1; i++)
            {
                if (line[1].Contains(line[0][i]) && line[2].Contains(line[0][i]))
                {
                    return line[0][i];
                }
            }

            throw new Exception("Shared letter not found");
        }
    }
}
