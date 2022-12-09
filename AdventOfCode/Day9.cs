namespace AdventOfCode
{
    internal class Day9
    {
        public static void Run()
        {
            var actions = new List<Movements>();
            var lines = File.ReadAllLines("input9.txt");
            foreach (var line in lines)
            {
                actions.Add(new Movements(line.Split(new[] { ' ' })[0], Convert.ToInt32(line.Split(new[] { ' ' })[1])));
            }

            var tailVisitedPositions = new List<Position>{ new(0, 0) };
            
            SimulateMovement(actions, tailVisitedPositions, 2);
            if (tailVisitedPositions.Count != 6098) throw new Exception();

            tailVisitedPositions = new List<Position> { new(0, 0) };
            SimulateMovement(actions, tailVisitedPositions, 10);
            if (tailVisitedPositions.Count != 2597) throw new Exception();
            Console.WriteLine(tailVisitedPositions.Count);
            Console.ReadLine();
        }

        private static void SimulateMovement(List<Movements> actions, List<Position> tailVisitedPositions, int length)
        {
            var positions = new Position[length];
            for (int i = 0; i < length; i++)
            {
                positions[i] = new Position(0, 0);
            }

            foreach (var action in actions)
            {
                if (action.Direction.Equals("L"))
                {
                    for (int i = 0; i < action.Step; i++)
                    {
                        for (int j = 0; j < length -1; j++)
                        {
                            if (j == 0)
                            {
                                positions[j].X--;
                            }

                            if (positions[j + 1].X - positions[j].X > 1)
                            {
                                positions[j + 1].X--;
                                if (positions[j].Y > positions[j + 1].Y)
                                {
                                    positions[j + 1].Y++;
                                }

                                if (positions[j].Y < positions[j + 1].Y)
                                {
                                    positions[j + 1].Y--;
                                }
                            }

                            if (positions[j].Y - positions[j + 1].Y > 1)
                            {
                                positions[j + 1].Y++;
                                if (positions[j].X > positions[j + 1].X)
                                {
                                    positions[j + 1].X++;
                                }

                                if (positions[j].X < positions[j + 1].X)
                                {
                                    positions[j + 1].X--;
                                }
                            }

                            if (positions[j + 1].Y - positions[j].Y > 1)
                            {
                                positions[j + 1].Y--;
                                if (positions[j].X > positions[j + 1].X)
                                {
                                    positions[j + 1].X++;
                                }

                                if (positions[j].X < positions[j + 1].X)
                                {
                                    positions[j + 1].X--;
                                }
                            }

                            if (j + 1 == length - 1 && !tailVisitedPositions.Any(p => p.X == positions[j + 1].X && p.Y == positions[j + 1].Y))
                            {
                                tailVisitedPositions.Add(new Position(positions[j + 1].X, positions[j + 1].Y));
                            }
                        }
                    }
                    Console.WriteLine($@"Head x:{positions[0].X} y:{positions[0].Y},  Tail x: {positions[1].X} y:{positions[1].Y}");
                }
                else if (action.Direction.Equals("R"))
                {
                    for (int i = 0; i < action.Step; i++)
                    {
                        for (int j = 0; j < length - 1; j++)
                        {
                            if (j == 0)
                            {
                                positions[j].X++;
                            }
                            
                            if (positions[j].X - positions[j + 1].X > 1)
                            {
                                positions[j + 1].X++;
                                if (positions[j].Y > positions[j + 1].Y)
                                {
                                    positions[j + 1].Y++;
                                }

                                if (positions[j].Y < positions[j + 1].Y)
                                {
                                    positions[j + 1].Y--;
                                }
                            }

                            if (positions[j].Y - positions[j + 1].Y > 1)
                            {
                                positions[j + 1].Y++;
                                if (positions[j].X > positions[j + 1].X)
                                {
                                    positions[j + 1].X++;
                                }

                                if (positions[j].X < positions[j + 1].X)
                                {
                                    positions[j + 1].X--;
                                }
                            }

                            if (positions[j + 1].Y - positions[j].Y > 1)
                            {
                                positions[j + 1].Y--;
                                if (positions[j].X > positions[j + 1].X)
                                {
                                    positions[j + 1].X++;
                                }

                                if (positions[j].X < positions[j + 1].X)
                                {
                                    positions[j + 1].X--;
                                }
                            }

                            if (j + 1 == length - 1 && !tailVisitedPositions.Any(p => p.X == positions[j + 1].X && p.Y == positions[j + 1].Y))
                            {
                                tailVisitedPositions.Add(new Position(positions[j + 1].X, positions[j + 1].Y));
                            }
                        }
                    }
                    Console.WriteLine($@"Head x:{positions[0].X} y:{positions[0].Y},  Tail x: {positions[1].X} y:{positions[1].Y}");
                }
                else if (action.Direction.Equals("U"))
                {
                    for (int i = 0; i < action.Step; i++)
                    {
                        for (int j = 0; j < length - 1; j++)
                        {
                            if (j == 0)
                            {
                                positions[j].Y--;
                            }

                            if (positions[j + 1].Y - positions[j].Y > 1)
                            {
                                positions[j + 1].Y--;
                                if (positions[j].X > positions[j + 1].X)
                                {
                                    positions[j + 1].X++;
                                }

                                if (positions[j].X < positions[j + 1].X)
                                {
                                    positions[j + 1].X--;
                                }
                            }

                            if (positions[j].X - positions[j + 1].X > 1)
                            {
                                positions[j + 1].X++;
                                if (positions[j].Y > positions[j + 1].Y)
                                {
                                    positions[j + 1].Y++;
                                }

                                if (positions[j].Y < positions[j + 1].Y)
                                {
                                    positions[j + 1].Y--;
                                }
                            }

                            if (positions[j+1].X - positions[j].X > 1)
                            {
                                positions[j + 1].X--;
                                if (positions[j].Y > positions[j + 1].Y)
                                {
                                    positions[j + 1].Y++;
                                }

                                if (positions[j].Y < positions[j + 1].Y)
                                {
                                    positions[j + 1].Y--;
                                }
                            }

                            if (j + 1 == length - 1 && !tailVisitedPositions.Any(p => p.X == positions[j + 1].X && p.Y == positions[j + 1].Y))
                            {
                                tailVisitedPositions.Add(new Position(positions[j + 1].X, positions[j + 1].Y));
                            }
                        }
                    }
                    Console.WriteLine($@"Head x:{positions[0].X} y:{positions[0].Y},  Tail x: {positions[1].X} y:{positions[1].Y}");
                }
                else if (action.Direction.Equals("D"))
                {
                    for (int i = 0; i < action.Step; i++)
                    {
                        for (int j = 0; j < length - 1; j++)
                        {
                            if (j == 0)
                            {
                                positions[j].Y++;
                            }
                            
                            if (positions[j].Y - positions[j + 1].Y > 1)
                            {
                                positions[j + 1].Y++;
                                if (positions[j].X > positions[j + 1].X)
                                {
                                    positions[j + 1].X++;
                                }

                                if (positions[j].X < positions[j + 1].X)
                                {
                                    positions[j + 1].X--;
                                }
                            }

                            if (positions[j].X - positions[j + 1].X > 1)
                            {
                                positions[j + 1].X++;
                                if (positions[j].Y > positions[j + 1].Y)
                                {
                                    positions[j + 1].Y++;
                                }

                                if (positions[j].Y < positions[j + 1].Y)
                                {
                                    positions[j + 1].Y--;
                                }
                            }

                            if (positions[j + 1].X - positions[j].X > 1)
                            {
                                positions[j + 1].X--;
                                if (positions[j].Y > positions[j + 1].Y)
                                {
                                    positions[j + 1].Y++;
                                }

                                if (positions[j].Y < positions[j + 1].Y)
                                {
                                    positions[j + 1].Y--;
                                }
                            }

                            if ((j + 1 == length - 1 && !tailVisitedPositions.Any(p => p.X == positions[j + 1].X && p.Y == positions[j + 1].Y)))
                            {
                                tailVisitedPositions.Add(new Position(positions[j + 1].X, positions[j + 1].Y));
                            }
                        }
                    }
                    Console.WriteLine($@"Head x:{positions[0].X} y:{positions[0].Y},  Tail x: {positions[1].X} y:{positions[1].Y}");
                }
                else
                {
                    throw new Exception("Invalid input!");
                }
            }
        }
    }

    internal class Movements
    {
        public Movements(string direction, int step)
        {
            Direction = direction;
            Step = step;
        }

        public string Direction { get; set; }
        public int Step { get; set; }
    }

    internal class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
