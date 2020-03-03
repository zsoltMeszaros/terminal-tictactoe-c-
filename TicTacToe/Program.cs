using System;
using System.Collections;

namespace TicTacToe
{
    class Program
    {
        static void StartMenu()
        {
            Console.WriteLine("TicTacToe!");
            Console.WriteLine("Hello, this is my first C# project!");
            Console.WriteLine("This one took (2.5 hours), Enjoy!");
            Console.WriteLine("\n\n\n1. New Game\n2. Settings\n0.Exit");

            string option;

            do
            {
                Console.WriteLine("\nSelect option and press enter: ");
                option = Console.ReadLine();
                
            } while (option != "1" && option != "2" && option != "0");

            if (option == "1")
            {
                Console.Clear();
                NewGame();
            }
            else if (option == "2")
            {
                Console.Clear();
                SettingsMenu();
            }
            else if (option == "0")
            {
                System.Environment.Exit(0);
            }
        }

        static void NewGame()
        {
            int mapSize = 3;
            char[,] map = FillLevel(mapSize);

            DrawLevel(map, mapSize);

            int counter = 0;
            char playerX = 'X';
            char playerO = 'O';

            while (true)
            {
                if (counter % 2 == 0)
                {
                    char currentPlayer = playerX;
                    map = PlayerMove(map, currentPlayer);
                    
                    if(PlayerWinCheck(map, mapSize, currentPlayer))
                    {
                        PlayerWonEnding(currentPlayer);
                    }else if(TieCheck(map, mapSize))
                    {
                        TieEnding();
                    }
                }
                else
                {
                    char currentPlayer = playerO;
                    map = PlayerMove(map, currentPlayer);

                    if (PlayerWinCheck(map, mapSize, currentPlayer))
                    {
                        PlayerWonEnding(currentPlayer);
                    }
                    else if (TieCheck(map, mapSize))
                    {
                        TieEnding();
                    }
                }

                counter++;
                DrawLevel(map, mapSize);
            }
        }

        static bool TieCheck(char[,] map, int mapSize)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if(map[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void TieEnding()
        {
            Console.Clear();
            Console.WriteLine("It's a Tie!");
            Console.WriteLine("\n\n1. Play again!");
            Console.WriteLine("2. Main Menu.");
            Console.WriteLine("0. Exit.");

            string option;

            do
            {
                Console.WriteLine("\nSelect option and press enter: ");
                option = Console.ReadLine();

            } while (option != "1" && option != "2" && option != "0");

            if (option == "1")
            {
                Console.Clear();
                NewGame();
            }
            else if (option == "2")
            {
                Console.Clear();
                StartMenu();
            }
            else if (option == "0")
            {
                System.Environment.Exit(0);
            }
        }

        static bool PlayerWinCheck(char[,] map, int mapSize, char player)
        {

            int counter;


            // check horizontal
            for (int i = 0; i < mapSize; i++)
            {
                counter = 0;
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == player)
                    {
                        counter++;
                        if (counter == 3)
                        {
                            return true;
                        }
                    }
                }
            }

            // check vertical
            for (int i = 0; i < mapSize; i++)
            {
                counter = 0;
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[j, i] == player)
                    {
                        counter++;
                        if (counter == 3)
                        {
                            return true;
                        }
                    }
                }
            }

            // check átlósan
            if(map[0,0] == player && map[1,1] == player && map[2,2] == player)
            {
                return true;
            }
            else if (map[2, 0] == player && map[1, 1] == player && map[0, 2] == player)
            {
                return true;
            }

            return false;
        }

        static void PlayerWonEnding(char player)
        {
            Console.Clear();
            Console.WriteLine(player + " Won! Congratulations.");
            Console.WriteLine("\n\n1. Play again!");
            Console.WriteLine("2. Main Menu.");
            Console.WriteLine("0. Exit.");

            string option;

            do
            {
                Console.WriteLine("\nSelect option and press enter: ");
                option = Console.ReadLine();

            } while (option != "1" && option != "2" && option != "0");

            if (option == "1")
            {
                Console.Clear();
                NewGame();
            }
            else if (option == "2")
            {
                Console.Clear();
                StartMenu();
            }
            else if (option == "0")
            {
                System.Environment.Exit(0);
            }
        }

        static int GetCoordinate(char player, string rowOrColumn)
        {
            string coordinate;

            do
            {
                Console.WriteLine("\nPlayer " + player + ", type the" + rowOrColumn + " number then press enter (1-3): ");
                coordinate = Console.ReadLine();
            } while (coordinate != "1" && coordinate != "2" && coordinate != "3");

            return int.Parse(coordinate);
        }

        static char[,] PlayerMove(char[,] map, char player)
        {

            int x;
            int y;

            do
            {
                x = GetCoordinate(player, "row");
                y = GetCoordinate(player, "column");
            }while(map[x - 1, y - 1] != ' ');


            map[x - 1, y - 1] = player;

            return map;
        }

        static char[,] FillLevel(int mapSize)
        {
            char[,] map = new char[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = ' ';
                }
            }

            return map;
        }

        static void DrawLevel(char[,] map, int mapSize)
        {

            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {

                if (i != 0)
                {
                    Console.WriteLine("- - -");
                }
                for (int j = 0; j < mapSize; j++)
                {
                    if (j < mapSize - 1)
                    {
                        Console.Write(map[i, j] + "|");
                    }
                    else
                    {
                        Console.Write(map[i, j] + "\n");
                    }
                }
            }
        }

        static void SettingsMenu()
        {
            Console.WriteLine("Well there's nothing here yet, so you might go back..");
            Console.WriteLine("\n\n0. Main Menu");


            string option;

            do
            {
                Console.WriteLine("\nSelect option and press enter: ");
                option = Console.ReadLine();
            } while (option != "0");

            Console.Clear();
            StartMenu();
        }

        static void Main(string[] args)
        {
            StartMenu();
        }
    }
}
