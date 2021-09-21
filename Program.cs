/*This is game "ButtleShip". The game works without mistakes. 
 *There are not many comments, because the code is very simple and clear. 
 *The bot in single mod is stupid:). I will do him smart someday*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    class Program
    {

        static string playerName; // Variable for First player(double mod) and single player mod 
        static string playerName2; // Variable for Second player(double mod)
        static int[,] CellSinglePlayer = new int[12, 12];/*Field for player Single Game Mod(arrangement) and for First player(double mod)*/
        static int[,] CellSinglePlayerShow = new int[12, 12];//Field for player Single Game mod(game)
        static int[,] CellSingleComputer = new int[12, 12];//Field for computer Single Game Mod(arrangement)
        static int[,] CellSingleComputerShow = new int[12, 12]; //Field for computer Single Game Mod(game)
        static int[,] CellSinglePlayer_2 = new int[12, 12]; //Field for Second Player Double Game Mod(arrangement) 
        static int[,] CellSinglePlayer_2Show = new int[12, 12]; //Field for Second Player Double Game Mod(game)

        //Function for Choice(single or double game mod) and initializes variables  by " 0 "
        static void GameModChoice()
        {
            Top("Game Mod");
            Console.WriteLine("One Player (O)");
            Console.WriteLine("Two Players (D)");
            Console.WriteLine("Back (V)");

            char mod = char.ToLower(Console.ReadKey().KeyChar);

            switch (mod)
            {
                case 'o':
                    CellFree(CellSinglePlayerShow);
                    CellFree(CellSingleComputerShow);
                    CellFree(CellSinglePlayer);
                    CellFree(CellSingleComputer);
                    GameSingleMod();
                    break;
                case 'd':
                    CellFree(CellSinglePlayerShow);
                    CellFree(CellSinglePlayer);
                    CellFree(CellSinglePlayer_2);
                    CellFree(CellSinglePlayer_2Show);
                    GameDoubleMod();
                    break;

                case ' ':
                case '\n':
                case '\t':
                case 'v':
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Sintex error, press any key to return back...");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine();

        }

        //Game single: calls functions(Name, Arrangement, SinglePlayerMod, SingleComputerMod, CheckWin. 
        static void GameSingleMod()
        {
            playerName = Name("Player name: ");
            playerName2 = "Computer";

            FieldArrangement(CellSinglePlayer, playerName);
            ShipArrangement4(CellSinglePlayer);
            for (int i = 1; i <= 2; i++)
            {
                FieldArrangement(CellSinglePlayer, playerName);
                ShipArrangement3(CellSinglePlayer);
            }
            for (int i = 1; i <= 3; i++)
            {
                FieldArrangement(CellSinglePlayer, playerName);
                ShipArrangement2(CellSinglePlayer);
            }
            for (int i = 1; i <= 4; i++)
            {
                FieldArrangement(CellSinglePlayer, playerName);
                ShipArrangement1(CellSinglePlayer);
            }
            FieldArrangement(CellSinglePlayer, playerName);
            Console.WriteLine();
            Console.WriteLine(" This is your field");
            Console.WriteLine(" Press any key to continue");
            Console.ReadKey();

            FieldArrangement(CellSingleComputer, playerName2);
            ShipArrangement4Computer(CellSingleComputer);
            for (int i = 1; i <= 2; i++)
            {
                FieldArrangement(CellSingleComputer, playerName2);
                ShipArrangement3Computer(CellSingleComputer);
            }
            for (int i = 1; i <= 3; i++)
            {
                FieldArrangement(CellSingleComputer, playerName2);
                ShipArrangement2Computer(CellSingleComputer);
            }
            for (int i = 1; i <= 4; i++)
            {
                FieldArrangement(CellSingleComputer, playerName2);
                ShipArrangement1Computer(CellSingleComputer);
            }

            int win;
            do
            {
                SinglePlayerMod();
                win = CheckWin(CellSingleComputerShow);
                if (win == 20)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            if (CellSinglePlayer[i, j] == 1)
                            {
                                CellSinglePlayerShow[i, j] = CellSinglePlayer[i, j];
                            }

                        }
                    }
                    PlayerWin(playerName, CellSinglePlayerShow, CellSingleComputerShow);
                    break;
                }
                SingleComputerMod();
                win = CheckWin(CellSinglePlayerShow);
                if (win == 20)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            if (CellSingleComputer[i, j] == 1)
                            {
                                CellSingleComputerShow[i, j] = CellSingleComputer[i, j];
                            }

                        }
                    }
                    PlayerWin(playerName2, CellSinglePlayerShow, CellSingleComputerShow);
                    break;
                }
            }
            while (win != 20);

        }

        //Game double: calls functions(Name, Arrangement, FirstPlayerDoubleMod, SecondPlayerDoubleMod, Check win
        static void GameDoubleMod()
        {
            playerName = Name("First Player name: ");
            FieldArrangement(CellSinglePlayer, playerName);
            ShipArrangement4(CellSinglePlayer);
            for (int i = 1; i <= 2; i++)
            {
                FieldArrangement(CellSinglePlayer, playerName);
                ShipArrangement3(CellSinglePlayer);
            }
            for (int i = 1; i <= 3; i++)
            {
                FieldArrangement(CellSinglePlayer, playerName);
                ShipArrangement2(CellSinglePlayer);
            }
            for (int i = 1; i <= 4; i++)
            {
                FieldArrangement(CellSinglePlayer, playerName);
                ShipArrangement1(CellSinglePlayer);
            }
            FieldArrangement(CellSinglePlayer, playerName);
            Console.WriteLine();
            Console.WriteLine(" This is your field");
            Console.WriteLine(" Press any key to continue");
            Console.ReadKey();

            playerName2 = Name("Second Player name: ");
            FieldArrangement(CellSinglePlayer_2, playerName2);
            ShipArrangement4(CellSinglePlayer_2);
            for (int i = 1; i <= 2; i++)
            {
                FieldArrangement(CellSinglePlayer_2, playerName2);
                ShipArrangement3(CellSinglePlayer_2);
            }
            for (int i = 1; i <= 3; i++)
            {
                FieldArrangement(CellSinglePlayer_2, playerName2);
                ShipArrangement2(CellSinglePlayer_2);
            }
            for (int i = 1; i <= 4; i++)
            {
                FieldArrangement(CellSinglePlayer_2, playerName2);
                ShipArrangement1(CellSinglePlayer_2);
            }
            FieldArrangement(CellSinglePlayer_2, playerName2);
            Console.WriteLine();
            Console.WriteLine(" This is your field");
            Console.WriteLine(" Press any key to continue");
            Console.ReadKey();
            int win;
            do
            {
                FirstPlayerDoubleMod();
                win = CheckWin(CellSinglePlayer_2Show);
                if (win == 20)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            if (CellSinglePlayer[i, j] == 1)
                            {
                                CellSinglePlayerShow[i, j] = CellSinglePlayer[i, j];
                            }

                        }
                    }
                    PlayerWin(playerName, CellSinglePlayerShow, CellSinglePlayer_2Show);
                    break;
                }
                SecondPlayerDoubleMod();
                win = CheckWin(CellSinglePlayerShow);
                if (win == 20)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            if (CellSinglePlayer[i, j] == 1)
                            {
                                CellSinglePlayer_2Show[i, j] = CellSinglePlayer_2[i, j];
                            }

                        }
                    }
                    PlayerWin(playerName2, CellSinglePlayerShow, CellSinglePlayer_2Show);
                    break;
                }
            }
            while (win != 20);
        }

        //Write Top
        static void Top(string text)
        {
            Console.Clear();
            Console.Title = "Lode";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("///////////////////////////  LODE  ///////////////////////////");
            Console.WriteLine("______________________________________________________________");
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine("______________________________________________________________");
            Console.WriteLine();
        }

        //Ask for name
        static string Name(string text)
        {
            string name;
            Top("The game will start soon");
            Console.WriteLine(text);
            name = Console.ReadLine();
            return name;
        }

        //Draw fields for game
        static void Field(int[,] Cell, int[,] Cell2) //Funkcija risuet pole
        {
            Top("Game is coming");
            Console.WriteLine("\t* {0} *\t\t      * {1} *", playerName, playerName2);
            Console.WriteLine("    a b c d e f g h i j\t\t    a b c d e f g h i j");
            int i, j;
            for (i = 1; i < 11; i++)
            {
                Console.Write(" " + i.ToString().PadLeft(2));
                for (j = 1; j < 11; j++)
                {
                    CellStatusShow(Cell, i, j);
                }
                Console.Write("\t\t");
                Console.Write(" " + i.ToString().PadLeft(2));
                for (j = 1; j < 11; j++)
                {
                    CellStatusShow(Cell2, i, j);
                }
                Console.WriteLine();
            }
        }

        //Draw field for arrangement 
        static void FieldArrangement(int[,] field, string name)//risuet odno pole dlea rasstanovki
        {
            Top("Place the ships");
            Console.WriteLine("\t* {0} *", name);
            Console.WriteLine("    a b c d e f g h i j");
            int i, j;
            for (i = 1; i < 11; i++)
            {
                Console.Write(" " + i.ToString().PadLeft(2));
                for (j = 1; j < 11; j++)
                {
                    CellStatusShow(field, i, j);
                }
                Console.WriteLine();
            }
        }

        //Draw cells
        static void CellStatusShow(int[,] status, int i, int j)//nastraivaet risunok dlea kazdoi jacejki
        {
            switch (status[i, j])
            {
                case 0:
                    Console.Write(("O").ToString().PadLeft(2));
                    break;
                case 1:
                    Console.Write(("X").ToString().PadLeft(2));
                    break;
                case 2:
                    Console.Write(("/").ToString().PadLeft(2));
                    break;
                default:
                    break;
            }
        }

        //Initializes variables  by " 0 "
        static void CellFree(int[,] cell) //Funkcija nastraivart pustyje jacejki
        {
            int i, j;
            for (i = 0; i < 12; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    cell[i, j] = 0;
                }
            }
        }

        //Next 4 Funktions for Ship Arrangement for people
        static void ShipArrangement1(int[,] cell)//rasstavliaet odnopalubnije korabli
        {
            int line, column, status;
            do
            {
                line = status = column = 0;
                column = CellColumnInput("\"X\"-Ship.\nEnter the Column:");
                line = CellLineInput("Enter the Line:");
                if ((status = CellCheck(cell, line, column)) == 1)
                {
                    CellOccupied(cell, line, column);
                    cell[line, column] = 1;
                }
                else { Console.WriteLine("Cell Occupied"); }
            } while (status == 0);
        }
        static void ShipArrangement2(int[,] cell)
        {
            int line, column, status;
            char direction;
            do
            {
                status = 0;
                column = CellColumnInput("\"XX\"-Ship.\nEnter the Column:");
                line = CellLineInput("Enter the Line:");
                if ((status = CellCheck(cell, line, column)) == 1)
                {
                    status = 0;
                    DirectionChoice();
                    direction = char.ToLower(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    switch (direction)
                    {
                        case 'w':

                            if (line > 1)
                            {
                                if ((status = CellCheck(cell, line - 1, column)) == 1)
                                {
                                    CellOccupied(cell, line, column);
                                    CellOccupied(cell, line - 1, column);
                                    cell[line, column] = 1;
                                    cell[line - 1, column] = 1;
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        case 's':
                            if (line < 10)
                            {
                                if ((status = CellCheck(cell, line + 1, column)) == 1)
                                {
                                    CellOccupied(cell, line, column);
                                    CellOccupied(cell, line + 1, column);
                                    cell[line, column] = 1;
                                    cell[line + 1, column] = 1;
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        case 'a':
                            if (column > 1)
                            {
                                if ((status = CellCheck(cell, line, column - 1)) == 1)
                                {
                                    CellOccupied(cell, line, column);
                                    CellOccupied(cell, line, column - 1);
                                    cell[line, column] = 1;
                                    cell[line, column - 1] = 1;
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        case 'd':
                            if (column < 10)
                            {
                                if ((status = CellCheck(cell, line, column + 1)) == 1)
                                {
                                    CellOccupied(cell, line, column);
                                    CellOccupied(cell, line, column + 1);
                                    cell[line, column] = 1;
                                    cell[line, column + 1] = 1;
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        default:
                            Write("Error");
                            break;
                    }
                }
            } while (status == 0);
        }
        static void ShipArrangement3(int[,] cell)
        {
            int line, column, status;
            char direction;
            do
            {
                line = status = column = 0;
                column = CellColumnInput("\"XXX\"-Ship.\nEnter the Column:");
                line = CellLineInput("Enter the Line:");
                if ((status = CellCheck(cell, line, column)) == 1)
                {
                    status = 0;
                    DirectionChoice();
                    direction = char.ToLower(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    switch (direction)
                    {
                        case 'w':
                            if (line > 2)
                            {
                                if ((status = CellCheck(cell, line - 1, column)) == 1)
                                {
                                    if ((status = CellCheck(cell, line - 2, column)) == 1)
                                    {
                                        CellOccupied(cell, line, column);
                                        CellOccupied(cell, line - 1, column);
                                        CellOccupied(cell, line - 2, column);
                                        cell[line, column] = 1;
                                        cell[line - 1, column] = 1;
                                        cell[line - 2, column] = 1;
                                    }
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        case 's':
                            if (line < 9)
                            {
                                if ((status = CellCheck(cell, line + 1, column)) == 1)
                                {
                                    if ((status = CellCheck(cell, line + 2, column)) == 1)
                                    {
                                        CellOccupied(cell, line, column);
                                        CellOccupied(cell, line + 1, column);
                                        CellOccupied(cell, line + 2, column);
                                        cell[line, column] = 1;
                                        cell[line + 1, column] = 1;
                                        cell[line + 2, column] = 1;
                                    }
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        case 'a':
                            if (column > 2)
                            {
                                if ((status = CellCheck(cell, line, column - 1)) == 1)
                                {
                                    if ((status = CellCheck(cell, line, column - 2)) == 1)
                                    {
                                        CellOccupied(cell, line, column);
                                        CellOccupied(cell, line, column - 1);
                                        CellOccupied(cell, line, column - 2);
                                        cell[line, column] = 1;
                                        cell[line, column - 1] = 1;
                                        cell[line, column - 2] = 1;
                                    }
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        case 'd':
                            if (column < 9)
                            {
                                if ((status = CellCheck(cell, line, column + 1)) == 1)
                                {
                                    if ((status = CellCheck(cell, line, column + 2)) == 1)
                                    {
                                        CellOccupied(cell, line, column);
                                        CellOccupied(cell, line, column + 1);
                                        CellOccupied(cell, line, column + 2);
                                        cell[line, column] = 1;
                                        cell[line, column + 1] = 1;
                                        cell[line, column + 2] = 1;
                                    }
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        default:
                            Write("Error");
                            break;
                    }
                }
            } while (status == 0);
        }
        static void ShipArrangement4(int[,] cell)
        {
            int line, column, status;
            char direction;
            do
            {
                line = status = column = 0;
                column = CellColumnInput("\"XXXX\"-Ship.\nEnter the Column:");
                line = CellLineInput("Enter the Line:");
                if ((status = CellCheck(cell, line, column)) == 1)
                {
                    status = 0;
                    DirectionChoice();
                    direction = char.ToLower(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    switch (direction)
                    {
                        case 'w':
                            if (line > 3)
                            {
                                if ((status = CellCheck(cell, line - 1, column)) == 1)
                                {
                                    if ((status = CellCheck(cell, line - 2, column)) == 1)
                                    {
                                        if ((status = CellCheck(cell, line - 3, column)) == 1)
                                        {
                                            CellOccupied(cell, line, column);
                                            CellOccupied(cell, line - 1, column);
                                            CellOccupied(cell, line - 2, column);
                                            CellOccupied(cell, line - 3, column);
                                            cell[line, column] = 1;
                                            cell[line - 1, column] = 1;
                                            cell[line - 2, column] = 1;
                                            cell[line - 3, column] = 1;
                                        }
                                    }
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        case 's':
                            if (line < 8)
                            {
                                if ((status = CellCheck(cell, line + 1, column)) == 1)
                                {
                                    if ((status = CellCheck(cell, line + 2, column)) == 1)
                                    {
                                        if ((status = CellCheck(cell, line + 3, column)) == 1)
                                        {
                                            CellOccupied(cell, line, column);
                                            CellOccupied(cell, line + 1, column);
                                            CellOccupied(cell, line + 2, column);
                                            CellOccupied(cell, line + 3, column);
                                            cell[line, column] = 1;
                                            cell[line + 1, column] = 1;
                                            cell[line + 2, column] = 1;
                                            cell[line + 3, column] = 1;
                                        }
                                    }
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        case 'a':
                            if (column > 3)
                            {
                                if ((status = CellCheck(cell, line, column - 1)) == 1)
                                {
                                    if ((status = CellCheck(cell, line, column - 2)) == 1)
                                    {
                                        if ((status = CellCheck(cell, line, column - 3)) == 1)
                                        {
                                            CellOccupied(cell, line, column);
                                            CellOccupied(cell, line, column - 1);
                                            CellOccupied(cell, line, column - 2);
                                            CellOccupied(cell, line, column - 3);
                                            cell[line, column] = 1;
                                            cell[line, column - 1] = 1;
                                            cell[line, column - 2] = 1;
                                            cell[line, column - 3] = 1;
                                        }
                                    }
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        case 'd':
                            if (column < 8)
                            {
                                if ((status = CellCheck(cell, line, column + 1)) == 1)
                                {
                                    if ((status = CellCheck(cell, line, column + 2)) == 1)
                                    {
                                        if ((status = CellCheck(cell, line, column + 3)) == 1)
                                        {
                                            CellOccupied(cell, line, column);
                                            CellOccupied(cell, line, column + 1);
                                            CellOccupied(cell, line, column + 2);
                                            CellOccupied(cell, line, column + 3);
                                            cell[line, column] = 1;
                                            cell[line, column + 1] = 1;
                                            cell[line, column + 2] = 1;
                                            cell[line, column + 3] = 1;
                                        }
                                    }
                                }
                                else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            }
                            else Console.WriteLine("I think you don't know the rules of the game. Try again!");
                            break;
                        default:
                            Write("Error");
                            break;
                    }
                }
            } while (status == 0);
        }

        //Next 4 Functions for Ship Arrangement for computer
        static void ShipArrangement1Computer(int[,] cell)
        {
            Random rand = new Random();
            int line, column, status;
            do
            {
                line = status = column = 0;
                column = rand.Next(1, 10);
                line = rand.Next(1, 10);
                if ((status = CellCheck(cell, line, column)) == 1)
                {
                    CellOccupied(cell, line, column);
                    cell[line, column] = 1;
                }
            } while (status == 0);
        }
        static void ShipArrangement2Computer(int[,] cell)
        {
            Random rand = new Random();
            int line, column, status, direction;
            do
            {
                status = 0;
                column = rand.Next(1, 10);
                line = rand.Next(1, 10);
                if ((status = CellCheck(cell, line, column)) == 1)
                {
                    status = 0;
                    direction = rand.Next(1, 4);
                    switch (direction)
                    {
                        case 1:

                            if (line > 1)
                            {
                                if ((status = CellCheck(cell, line - 1, column)) == 1)
                                {
                                    CellOccupied(cell, line, column);
                                    CellOccupied(cell, line - 1, column);
                                    cell[line, column] = 1;
                                    cell[line - 1, column] = 1;
                                }
                            }
                            break;
                        case 2:
                            if (line < 10)
                            {
                                if ((status = CellCheck(cell, line + 1, column)) == 1)
                                {
                                    CellOccupied(cell, line, column);
                                    CellOccupied(cell, line + 1, column);
                                    cell[line, column] = 1;
                                    cell[line + 1, column] = 1;
                                }
                            }
                            break;
                        case 3:
                            if (column > 1)
                            {
                                if ((status = CellCheck(cell, line, column - 1)) == 1)
                                {
                                    CellOccupied(cell, line, column);
                                    CellOccupied(cell, line, column - 1);
                                    cell[line, column] = 1;
                                    cell[line, column - 1] = 1;
                                }
                            }
                            break;
                        case 4:
                            if (column < 10)
                            {
                                if ((status = CellCheck(cell, line, column + 1)) == 1)
                                {
                                    CellOccupied(cell, line, column);
                                    CellOccupied(cell, line, column + 1);
                                    cell[line, column] = 1;
                                    cell[line, column + 1] = 1;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            } while (status == 0);
        }
        static void ShipArrangement3Computer(int[,] cell)
        {
            Random rand = new Random();
            int line, column, status, direction;
            do
            {
                line = status = column = 0;
                column = rand.Next(1, 10);
                line = rand.Next(1, 10);
                if ((status = CellCheck(cell, line, column)) == 1)
                {
                    status = 0;
                    direction = rand.Next(1, 4);
                    Console.WriteLine();
                    switch (direction)
                    {
                        case 1:
                            if (line > 2)
                            {
                                if ((status = CellCheck(cell, line - 1, column)) == 1)
                                {
                                    if ((status = CellCheck(cell, line - 2, column)) == 1)
                                    {
                                        CellOccupied(cell, line, column);
                                        CellOccupied(cell, line - 1, column);
                                        CellOccupied(cell, line - 2, column);
                                        cell[line, column] = 1;
                                        cell[line - 1, column] = 1;
                                        cell[line - 2, column] = 1;
                                    }
                                }
                            }
                            break;
                        case 2:
                            if (line < 9)
                            {
                                if ((status = CellCheck(cell, line + 1, column)) == 1)
                                {
                                    if ((status = CellCheck(cell, line + 2, column)) == 1)
                                    {
                                        CellOccupied(cell, line, column);
                                        CellOccupied(cell, line + 1, column);
                                        CellOccupied(cell, line + 2, column);
                                        cell[line, column] = 1;
                                        cell[line + 1, column] = 1;
                                        cell[line + 2, column] = 1;
                                    }
                                }
                            }
                            break;
                        case 3:
                            if (column > 2)
                            {
                                if ((status = CellCheck(cell, line, column - 1)) == 1)
                                {
                                    if ((status = CellCheck(cell, line, column - 2)) == 1)
                                    {
                                        CellOccupied(cell, line, column);
                                        CellOccupied(cell, line, column - 1);
                                        CellOccupied(cell, line, column - 2);
                                        cell[line, column] = 1;
                                        cell[line, column - 1] = 1;
                                        cell[line, column - 2] = 1;
                                    }
                                }
                            }
                            break;
                        case 4:
                            if (column < 9)
                            {
                                if ((status = CellCheck(cell, line, column + 1)) == 1)
                                {
                                    if ((status = CellCheck(cell, line, column + 2)) == 1)
                                    {
                                        CellOccupied(cell, line, column);
                                        CellOccupied(cell, line, column + 1);
                                        CellOccupied(cell, line, column + 2);
                                        cell[line, column] = 1;
                                        cell[line, column + 1] = 1;
                                        cell[line, column + 2] = 1;
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            } while (status == 0);
        }
        static void ShipArrangement4Computer(int[,] cell)
        {
            Random rand = new Random();
            int line, column, status, direction;
            do
            {
                line = status = column = 0;
                column = rand.Next(1, 10);
                line = rand.Next(1, 10);
                if ((status = CellCheck(cell, line, column)) == 1)
                {
                    status = 0;
                    direction = rand.Next(1, 4);
                    Console.WriteLine();
                    switch (direction)
                    {
                        case 1:
                            if (line > 3)
                            {
                                if ((status = CellCheck(cell, line - 1, column)) == 1)
                                {
                                    if ((status = CellCheck(cell, line - 2, column)) == 1)
                                    {
                                        if ((status = CellCheck(cell, line - 3, column)) == 1)
                                        {
                                            CellOccupied(cell, line, column);
                                            CellOccupied(cell, line - 1, column);
                                            CellOccupied(cell, line - 2, column);
                                            CellOccupied(cell, line - 3, column);
                                            cell[line, column] = 1;
                                            cell[line - 1, column] = 1;
                                            cell[line - 2, column] = 1;
                                            cell[line - 3, column] = 1;
                                        }
                                    }
                                }
                            }
                            break;
                        case 2:
                            if (line < 8)
                            {
                                if ((status = CellCheck(cell, line + 1, column)) == 1)
                                {
                                    if ((status = CellCheck(cell, line + 2, column)) == 1)
                                    {
                                        if ((status = CellCheck(cell, line + 3, column)) == 1)
                                        {
                                            CellOccupied(cell, line, column);
                                            CellOccupied(cell, line + 1, column);
                                            CellOccupied(cell, line + 2, column);
                                            CellOccupied(cell, line + 3, column);
                                            cell[line, column] = 1;
                                            cell[line + 1, column] = 1;
                                            cell[line + 2, column] = 1;
                                            cell[line + 3, column] = 1;
                                        }
                                    }
                                }
                            }
                            break;
                        case 3:
                            if (column > 3)
                            {
                                if ((status = CellCheck(cell, line, column - 1)) == 1)
                                {
                                    if ((status = CellCheck(cell, line, column - 2)) == 1)
                                    {
                                        if ((status = CellCheck(cell, line, column - 3)) == 1)
                                        {
                                            CellOccupied(cell, line, column);
                                            CellOccupied(cell, line, column - 1);
                                            CellOccupied(cell, line, column - 2);
                                            CellOccupied(cell, line, column - 3);
                                            cell[line, column] = 1;
                                            cell[line, column - 1] = 1;
                                            cell[line, column - 2] = 1;
                                            cell[line, column - 3] = 1;
                                        }
                                    }
                                }
                            }
                            break;
                        case 4:
                            if (column < 8)
                            {
                                if ((status = CellCheck(cell, line, column + 1)) == 1)
                                {
                                    if ((status = CellCheck(cell, line, column + 2)) == 1)
                                    {
                                        if ((status = CellCheck(cell, line, column + 3)) == 1)
                                        {
                                            CellOccupied(cell, line, column);
                                            CellOccupied(cell, line, column + 1);
                                            CellOccupied(cell, line, column + 2);
                                            CellOccupied(cell, line, column + 3);
                                            cell[line, column] = 1;
                                            cell[line, column + 1] = 1;
                                            cell[line, column + 2] = 1;
                                            cell[line, column + 3] = 1;
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            } while (status == 0);
        }

        //Ask for column a-j
        static int CellColumnInput(string text)
        {
            int b = 0;
            do
            {
                Write(text);
                char column = char.ToLower(Console.ReadKey().KeyChar);
                switch (column)
                {
                    case 'a':
                        b = 1;
                        break;
                    case 'b':
                        b = 2;
                        break;
                    case 'c':
                        b = 3;
                        break;
                    case 'd':
                        b = 4;
                        break;
                    case 'e':
                        b = 5;
                        break;
                    case 'f':
                        b = 6;
                        break;
                    case 'g':
                        b = 7;
                        break;
                    case 'h':
                        b = 8;
                        break;
                    case 'i':
                        b = 9;
                        break;
                    case 'j':
                        b = 10;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Sintex error, try again!");
                        break;
                }
            } while (b == 0);
            return b;
        }

        //Ask for direction 
        static void DirectionChoice()
        {
            Console.WriteLine("Сhoose ship direction");
            Console.WriteLine("Up    (W)");
            Console.WriteLine("Down  (S)");
            Console.WriteLine("Left  (A)");
            Console.WriteLine("Right (D)");
        }

        //Asc for line 1-10
        static int CellLineInput(string text2)
        {
            int line;
            Console.WriteLine();
            do
            {
                Write(text2);
                if (!int.TryParse(Console.ReadLine(), out line))
                {
                    Console.WriteLine("Sintex error, try again!");
                    continue;
                }
                if (line < 1 || line > 10)
                    Console.WriteLine("Sintex error, try again!");
            } while (line < 1 || line > 10);
            return line;
        }

        //Asks the player to shoot the cell
        static void FirstPlayerDoubleMod()
        {
            int column, line, status = 0, shoot = 0;
            do
            {
                do
                {
                    Top("First player shoots");
                    Field(CellSinglePlayerShow, CellSinglePlayer_2Show);
                    Console.WriteLine("{0} shoots", playerName);
                    column = CellColumnInput("Enter the Column: ");
                    line = CellLineInput("Enter the Line: ");
                    if (CellSinglePlayer_2Show[line, column] == 0)
                    {
                        if (CellSinglePlayer_2[line, column] != 1)
                        {
                            CellSinglePlayer_2Show[line, column] = 2;
                            shoot = 1;
                        }

                        if (CellSinglePlayer_2[line, column] == 1)
                        {

                            CellSinglePlayer_2[line, column] = 3;
                            CellSinglePlayer_2Show[line, column] = 1;
                        }
                        status = 1;
                    }
                    else
                    {
                        Console.WriteLine("You already shot this place");
                        Console.WriteLine("Try again");
                        Console.ReadKey();
                    }
                } while (status == 0);

                int c = 0;
                for (int i = 1; i <= 10; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        if (CellSinglePlayer_2[i, j] == 3)
                        {
                            if (CellSinglePlayer_2[i - 1, j] == 1 || CellSinglePlayer_2[i + 1, j] == 1)
                            {
                                c = 1;
                            }
                            if (CellSinglePlayer_2[i, j - 1] == 1 || CellSinglePlayer_2[i, j + 1] == 1)
                            {
                                c = 1;
                            }
                        }

                    }
                }

                if (c == 0)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            if (CellSinglePlayer_2[i, j] == 3)
                            {
                                for (int a = -1; a <= 1; a++)
                                {
                                    for (int b = -1; b <= 1; b++)
                                    {
                                        if (CellSinglePlayer_2Show[i + a, j + b] != 1)
                                        {
                                            CellSinglePlayer_2Show[i + a, j + b] = 2;
                                        }
                                    }
                                }
                                CellSinglePlayer_2[i, j] = 1;
                                CellSinglePlayer_2Show[i, j] = 1;
                            }
                        }
                    }
                }
                int win;
                win = CheckWin(CellSinglePlayer_2Show);
                if (win == 20)
                {
                    break;
                }
            }
            while (shoot == 0);
        }

        //Asks the First player to shoot the cell
        static void SecondPlayerDoubleMod()
        {
            int column, line, status = 0, shoot = 0;
            do
            {
                do
                {
                    Top("Second player shoots");
                    Field(CellSinglePlayerShow, CellSinglePlayer_2Show);
                    Console.WriteLine("{0} shoots", playerName2);
                    column = CellColumnInput("Enter the Column: ");
                    line = CellLineInput("Enter the Line: ");
                    if (CellSinglePlayerShow[line, column] == 0)
                    {
                        if (CellSinglePlayer[line, column] != 1)
                        {
                            CellSinglePlayerShow[line, column] = 2;
                            shoot = 1;
                        }

                        if (CellSinglePlayer[line, column] == 1)
                        {

                            CellSinglePlayer[line, column] = 3;
                            CellSinglePlayerShow[line, column] = 1;
                        }
                        status = 1;
                    }
                    else
                    {
                        Console.WriteLine("You already shot this place");
                        Console.WriteLine("Try again");
                        Console.ReadKey();
                    }
                } while (status == 0);

                int c = 0;
                for (int i = 1; i <= 10; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        if (CellSinglePlayer[i, j] == 3)
                        {
                            if (CellSinglePlayer[i - 1, j] == 1 || CellSinglePlayer[i + 1, j] == 1)
                            {
                                c = 1;
                            }
                            if (CellSinglePlayer[i, j - 1] == 1 || CellSinglePlayer[i, j + 1] == 1)
                            {
                                c = 1;
                            }
                        }

                    }
                }

                if (c == 0)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            if (CellSinglePlayer[i, j] == 3)
                            {
                                for (int a = -1; a <= 1; a++)
                                {
                                    for (int b = -1; b <= 1; b++)
                                    {
                                        if (CellSinglePlayerShow[i + a, j + b] != 1)
                                        {
                                            CellSinglePlayerShow[i + a, j + b] = 2;
                                        }
                                    }
                                }
                                CellSinglePlayer[i, j] = 1;
                                CellSinglePlayerShow[i, j] = 1;
                            }
                        }
                    }
                }
                int win;
                win = CheckWin(CellSinglePlayerShow);
                if (win == 20)
                {
                    break;
                }
            }
            while (shoot == 0);
        }

        //Asks the player to shoot the cell
        static void SinglePlayerMod()
        {
            int column, line, status = 0, shoot = 0;
            do
            {
                do
                {
                    Top("First player shoots");
                    Field(CellSinglePlayerShow, CellSingleComputerShow);
                    Console.WriteLine("{0} shoots", playerName);
                    column = CellColumnInput("Enter the Column: ");
                    line = CellLineInput("Enter the Line: ");
                    if (CellSingleComputerShow[line, column] == 0)
                    {
                        if (CellSingleComputer[line, column] != 1)
                        {
                            CellSingleComputerShow[line, column] = 2;
                            shoot = 1;
                        }

                        if (CellSingleComputer[line, column] == 1)
                        {

                            CellSingleComputer[line, column] = 3;
                            CellSingleComputerShow[line, column] = 1;
                        }
                        status = 1;
                    }
                    else
                    {
                        Console.WriteLine("You already shot this place");
                        Console.WriteLine("Try again");
                        Console.ReadKey();
                    }
                } while (status == 0);

                int c = 0;
                for (int i = 1; i <= 10; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        if (CellSingleComputer[i, j] == 3)
                        {
                            if (CellSingleComputer[i - 1, j] == 1 || CellSingleComputer[i + 1, j] == 1)
                            {
                                c = 1;
                            }
                            if (CellSingleComputer[i, j - 1] == 1 || CellSingleComputer[i, j + 1] == 1)
                            {
                                c = 1;
                            }
                        }

                    }
                }

                if (c == 0)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            if (CellSingleComputer[i, j] == 3)
                            {
                                for (int a = -1; a <= 1; a++)
                                {
                                    for (int b = -1; b <= 1; b++)
                                    {
                                        if (CellSingleComputerShow[i + a, j + b] != 1)
                                        {
                                            CellSingleComputerShow[i + a, j + b] = 2;
                                        }
                                    }
                                }
                                CellSingleComputer[i, j] = 1;
                                CellSingleComputerShow[i, j] = 1;
                            }
                        }
                    }
                }
                int win;
                win = CheckWin(CellSingleComputerShow);
                if (win == 20)
                {
                    break;
                }
            }
            while (shoot == 0);
        }

        //Bot shoots
        static void SingleComputerMod()
        {
            Random rand = new Random();
            int column, line, status = 0, shoot = 0;
            do
            {
                do
                {
                    column = rand.Next(1, 10);
                    line = rand.Next(1, 10);
                    if (CellSinglePlayerShow[line, column] == 0)
                    {
                        if (CellSinglePlayer[line, column] != 1)
                        {
                            CellSinglePlayerShow[line, column] = 2;
                            shoot = 1;
                        }

                        if (CellSinglePlayer[line, column] == 1)
                        {

                            CellSinglePlayer[line, column] = 3;
                            CellSinglePlayerShow[line, column] = 1;
                        }
                        status = 1;
                    }
                } while (status == 0);

                int c = 0;
                for (int i = 1; i <= 10; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        if (CellSinglePlayer[i, j] == 3)
                        {
                            if (CellSinglePlayer[i - 1, j] == 1 || CellSinglePlayer[i + 1, j] == 1)
                            {
                                c = 1;
                            }
                            if (CellSinglePlayer[i, j - 1] == 1 || CellSinglePlayer[i, j + 1] == 1)
                            {
                                c = 1;
                            }
                        }

                    }
                }

                if (c == 0)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            if (CellSinglePlayer[i, j] == 3)
                            {
                                for (int a = -1; a <= 1; a++)
                                {
                                    for (int b = -1; b <= 1; b++)
                                    {
                                        if (CellSinglePlayerShow[i + a, j + b] != 1)
                                        {
                                            CellSinglePlayerShow[i + a, j + b] = 2;
                                        }
                                    }
                                }
                                CellSinglePlayer[i, j] = 1;
                                CellSinglePlayerShow[i, j] = 1;
                            }
                        }
                    }
                }
                int win;
                win = CheckWin(CellSinglePlayerShow);
                if (win == 20)
                {
                    break;
                }
            }
            while (shoot == 0);
        }

        //Reduction function(Console.Write)
        static void Write(string text)
        {
            Console.Write(text);
        }

        //Check if somebody win
        static int CheckWin(int[,] cell)
        {
            int win = 0;
            foreach (int a in cell)
            {
                if (a == 1)
                {
                    win++;
                }
            }
            return win;
        }

        //Write, that somebody wom
        static void PlayerWin(string a, int[,] b, int[,] c)
        {
            Field(b, c);
            Write("The end!");
            Console.WriteLine("\n{0} Win)", a);
            Write("Press \"Enter\" to continue");
            Console.ReadKey();
        }

        //Check cell, if it is free
        static int CellCheck(int[,] cell, int a, int b)
        {
            int status = 0;
            if ((cell[a, b] != 1 && cell[a + 1, b] != 1) && cell[a - 1, b] != 1)
            {
                if ((cell[a, b - 1] != 1 && cell[a + 1, b - 1] != 1) && cell[a - 1, b - 1] != 1)
                {
                    if ((cell[a, b + 1] != 1 && cell[a + 1, b + 1] != 1) && cell[a - 1, b + 1] != 1)
                    {
                        status = 1;
                    }
                    else Console.WriteLine("Error");
                }
                else Console.WriteLine("Error");
            }
            else Console.WriteLine("Error");
            return status;
        }

        //Makes cells occuoied
        static void CellOccupied(int[,] cell, int a, int b)
        {
            b -= 2;
            a -= 2;
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    cell[a + i, b + j] = 2;
                }
            }
        }

        //Choice(new game or exit)
        static void Main(string[] args)
        {
            char choice;
            do
            {
                Top("Welcome to Lode");
                Console.WriteLine("New Game (N)");
                Console.WriteLine("Exit (V)");
                choice = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                switch (choice)
                {
                    case 'n':
                        GameModChoice();
                        break;

                    case 'v':
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Sintex error, press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            } while (choice != 'v');
        }
    }
}