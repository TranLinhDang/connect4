using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using Connect4;
using System.Text.RegularExpressions;

namespace Connect4
{
    class Program
    {
        //path to saved serialized data
        const string saveFileName = "Connect4Save.xml";
        static void Main(string[] args)
        {
            string input, fn;
            Player playerOne = null;
            Player playerTwo = null;
            Board board = null;
            
            //added to retrieve saved game
            if (File.Exists(saveFileName))
            {
                Console.Write("Do you want to resume an old game? (Y/N)");
                input = Console.ReadLine();
                if (input[0] == 'y' || input[0] == 'Y')

                {
                    Stream saveFile = File.OpenRead(saveFileName);
                    SoapFormatter deserializer = new SoapFormatter();
                    try
                    {
                        board = (Board)(deserializer.Deserialize(saveFile));
                        playerOne = (Player)(deserializer.Deserialize(saveFile));
                        playerTwo = (Player)(deserializer.Deserialize(saveFile));
                    }
                    catch(Exception e)
                    {
                        Console.Write("Failed Deserialize");
                    }
                    saveFile.Close();
                }
                File.Delete(saveFileName);
            }
            //game not restored so start a new one
            if(board == null)
            {
                board = new Board();
                Console.Write("Enter file name:");
                fn = Console.ReadLine();
                StreamReader inputFile = new StreamReader(fn);


                string line = inputFile.ReadLine();
                string[] inputNum = Regex.Split(line, @"\D+");
                for (int i = 0; i < inputNum.Length; i++)
                {
                    board.rows = Int32.Parse(inputNum[0]);
                    board.columns = Int32.Parse(inputNum[1]);

                }

            }

           
            if (playerOne == null || playerTwo == null)
            {
                playerOne = new Player();
                playerTwo = new Player();
                Console.WriteLine("Player One please enter your name: ");
                playerOne.playerName = Console.ReadLine();
                playerOne.playerID = 1;
                Console.WriteLine("Player Two please enter your name: ");
                playerTwo.playerName = Console.ReadLine();
                playerTwo.playerID = 2;
            }
            

            int dropChoice;
            bool count, again;           
            again = true;
            board.displayBoard();

            while (again == true)
            {
                Console.WriteLine(playerOne.playerName + "'s Turn ");
                Console.WriteLine("Pick a column from 1 to " + board.columns + " or Enter '0' to save the game and stop: ");
                dropChoice = Convert.ToInt32(Console.ReadLine());
                if (dropChoice == 0)
                {
                    Stream saveFile = File.Create(saveFileName);
                    SoapFormatter serializer = new SoapFormatter();
                    try
                    {
                        serializer.Serialize(saveFile, board);
                        serializer.Serialize(saveFile, playerOne);
                        serializer.Serialize(saveFile, playerTwo);

                        Console.WriteLine("Game saved. Thanks for playing");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Failed Serialize" + e.Message);

                    }
                    saveFile.Close();
                    return;
                }
                board.dropDisc(playerOne, dropChoice);
                board.displayBoard();

                count = board.checkfour(playerOne);
                if (count == true)
                {
                    Console.Write("WINNER! player " + playerOne.playerName + " WIN a game\n");
                    Console.Write("Do you want to play again?\n");
                    again = board.PlayAgain();
                    if (again == false)
                    {
                        break;
                    }
                    break;
                }


                Console.WriteLine(playerTwo.playerName + "'s Turn ");
                Console.WriteLine("Pick a column from 1 to " + board.columns + " or Enter '0' to save the game and stop: ");
                dropChoice = Convert.ToInt32(Console.ReadLine());
                if (dropChoice == 0)
                {
                    Stream saveFile = File.Create(saveFileName);
                    SoapFormatter serializer = new SoapFormatter();
                    try
                    {
                        serializer.Serialize(saveFile, board);
                        serializer.Serialize(saveFile, playerOne);
                        serializer.Serialize(saveFile, playerTwo);
                        Console.WriteLine("Game saved. Thanks for playing");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Failed Serialize" + e.Message);

                    }
                    saveFile.Close();
                    return;
                }
                board.dropDisc(playerTwo, dropChoice);
                board.displayBoard();
                count = board.checkfour(playerTwo);

                if (count == true)
                {
                    Console.Write("WINNER! player " + playerTwo.playerName + " Win a game\n");
                    Console.Write("Do you want to play again?\n");
                    again = board.PlayAgain();
                    if (again == false)
                    {
                        break;
                    }
                }

            } 
        }

    }
}

