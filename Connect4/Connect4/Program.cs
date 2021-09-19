using System;
using System.Threading;

namespace Connect4
{
    class Program
    {
        static char[,] grid = new char[7, 8] {
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' } };
        static int player = 1;
        static int colChoice;
        static int[] maxRow = new int[8] { 0, 6, 6, 6, 6, 6, 6, 6 };

        static int game = 0;
        static void Main(string[] args)
        {
            do
            {
                game = CheckWin();

                Console.Clear();

                Console.WriteLine("Player1:X and Player2:O");

                Console.WriteLine("\n");

                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2 turn");
                }
                else
                {
                    Console.WriteLine("Player 1 turn");
                }

                Console.WriteLine("\n");

                Board();

                colChoice = int.Parse(Console.ReadLine());


                if (player % 2 == 1 && maxRow[colChoice] != 0)
                {
                    grid[maxRow[colChoice], colChoice] = 'X';
                    maxRow[colChoice] = maxRow[colChoice] - 1;

                    player++;
                }
                else if (player % 2 == 0 && maxRow[colChoice] != 0)
                {
                    grid[maxRow[colChoice], colChoice] = 'O';
                    maxRow[colChoice] = maxRow[colChoice] - 1;

                    player++;
                }
                else
                {
                    Console.WriteLine("Cannot select this column please choose another");
                    Thread.Sleep(3500);
                }

                

            } while (game == 0);

            if (game == 1)
            {
                Console.WriteLine("Player 1 has won!");
            }
            else if (game == 2)
            {
                Console.WriteLine("Player 2 has won!");
            }
            else if (game == -1)
            {
                Console.WriteLine("It's a tie!");
            }



        }

        private static int CheckWin()
        {
            if (player >= 8)
            {
                //Check Horizontal win for Player 1
                for (int x = 1; x <= 6; x++)
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        if (grid[x, i] == 'X' && grid[x, i + 1] == grid[x, i] && grid[x, i + 2] == grid[x, i] && grid[x, i + 3] == grid[x, i])
                        {
                            return 1;
                        }
                    }
                }

                //Check Vertical Win for Player 1

                for (int y = 1; y <= 7; y++)
                {
                    for (int x = 1; x <= 3; x++)
                    {
                        if (grid[x, y] == 'X' && grid[x + 1, y] == grid[x, y] && grid[x + 2, y] == grid[x, y] && grid[x + 3, y] == grid[x, y])
                        {
                            return 1;
                        }
                    }
                }

                //Check upper diagonal win for Player 1

                for (int x = 4; x <= 6; x++)
                {
                    for (int y = 1; y <= 4; y++)
                    {
                        if (grid[x, y] == 'X' && grid[x - 1, y + 1] == grid[x, y] && grid[x - 2, y + 2] == grid[x, y] && grid[x - 3, y + 3] == grid[x, y])
                            return 1;
                    }
                }

                //Check lower diagonal win for Player 1

                for (int x = 1; x <= 3; x++)
                {
                    for (int y = 1; y <= 4; y++)
                    {
                        if (grid[x, y] == 'X' && grid[x + 1, y + 1] == grid[x, y] && grid[x + 2, y + 2] == grid[x, y] && grid[x + 3, y + 3] == grid[x, y])
                        {
                            return 1;
                        }
                    }
                }

                //Check Horizontal win for Player 2
                for (int x = 1; x <= 6; x++)
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        if (grid[x, i] == 'O' && grid[x, i + 1] == grid[x, i] && grid[x, i + 2] == grid[x, i] && grid[x, i + 3] == grid[x, i])
                        {
                            return 2;
                        }
                    }
                }

                //Check Vertical Win for Player 2

                for (int y = 1; y <= 7; y++)
                {
                    for (int x = 1; x <= 3; x++)
                    {
                        if (grid[x, y] == 'O' && grid[x + 1, y] == grid[x, y] && grid[x + 2, y] == grid[x, y] && grid[x + 3, y] == grid[x, y])
                        {
                            return 2;
                        }
                    }
                }

                //Check upper diagonal win for Player 2

                for (int x = 4; x <= 6; x++)
                {
                    for (int y = 1; y <= 4; y++)
                    {
                        if (grid[x, y] == 'O' && grid[x - 1, y + 1] == grid[x, y] && grid[x - 2, y + 2] == grid[x, y] && grid[x - 3, y + 3] == grid[x, y])
                            return 2;
                    }
                }

                //Check lower diagonal win for Player 2

                for (int x = 1; x <= 3; x++)
                {
                    for (int y = 1; y <= 4; y++)
                    {
                        if (grid[x, y] == 'O' && grid[x + 1, y + 1] == grid[x, y] && grid[x + 2, y + 2] == grid[x, y] && grid[x + 3, y + 3] == grid[x, y])
                        {
                            return 2;
                        }
                    }
                }
            }


            if (player == 43)
            {
                return -1;
            }

            return 0;


        }
        private static void Board()
        {
            Console.WriteLine("  1   2   3   4   5   6   7 ");
            Console.WriteLine("|   |   |   |   |   |   |   |");
            Console.WriteLine("|_{0}_|_{1}_|_{2}_|_{3}_|_{4}_|_{5}_|_{6}_|", grid[1,1], grid[1, 2], grid[1, 3], grid[1, 4], grid[1, 5], grid[1, 6], grid[1, 7]);
            Console.WriteLine("|   |   |   |   |   |   |   |");
            Console.WriteLine("|_{0}_|_{1}_|_{2}_|_{3}_|_{4}_|_{5}_|_{6}_|", grid[2, 1], grid[2, 2], grid[2, 3], grid[2, 4], grid[2, 5], grid[2, 6], grid[2, 7]);
            Console.WriteLine("|   |   |   |   |   |   |   |");
            Console.WriteLine("|_{0}_|_{1}_|_{2}_|_{3}_|_{4}_|_{5}_|_{6}_|", grid[3, 1], grid[3, 2], grid[3, 3], grid[3, 4], grid[3, 5], grid[3, 6], grid[3, 7]);
            Console.WriteLine("|   |   |   |   |   |   |   |");
            Console.WriteLine("|_{0}_|_{1}_|_{2}_|_{3}_|_{4}_|_{5}_|_{6}_|", grid[4, 1], grid[4, 2], grid[4, 3], grid[4, 4], grid[4, 5], grid[4, 6], grid[4, 7]);
            Console.WriteLine("|   |   |   |   |   |   |   |");
            Console.WriteLine("|_{0}_|_{1}_|_{2}_|_{3}_|_{4}_|_{5}_|_{6}_|", grid[5, 1], grid[5, 2], grid[5, 3], grid[5, 4], grid[5, 5], grid[5, 6], grid[5, 7]);
            Console.WriteLine("|   |   |   |   |   |   |   |");
            Console.WriteLine("|_{0}_|_{1}_|_{2}_|_{3}_|_{4}_|_{5}_|_{6}_|", grid[6, 1], grid[6, 2], grid[6, 3], grid[6, 4], grid[6, 5], grid[6, 6], grid[6, 7]);
            

        }


    }
}
