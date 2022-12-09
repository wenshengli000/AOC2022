namespace AdventOfCode
{
    public class Day1
    {
        public static void Run()
        {
            //var client = new WebClient();
            //client.Headers["Content-Type"] = "application/json;charset=UTF-8";
            //var input = client.DownloadString("https://adventofcode.com/2022/day/1/input");


            var maxTotal = 0;
            var subTotal = 0;
            var subTotalList = new List<int>();


            var lines = File.ReadAllLines("input1.txt");

            foreach (var line in lines)
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    if (subTotal > maxTotal)
                    {
                        maxTotal = subTotal;
                    }

                    subTotalList.Add(subTotal);
                    subTotal = 0;
                }
                else
                {
                    var number = Convert.ToInt32(line);
                    subTotal += number;
                }
            }

            Console.WriteLine(maxTotal);

            subTotalList.Sort();
            Console.WriteLine(subTotalList.TakeLast(3).Sum());
            Console.ReadLine();
        }
    }
}
