using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    [Serializable]
    public class Board
    {
        public int rows;
        public int columns;
        public int win = 4;
        public int[,] board;
        public Board()
        {
            board = new int[100, 100];
        }

        public void dropDisc(Player currentPlayer, int dropChoice)
        {
            int length = rows;
            int turn = 0;
            do
            {
                if (board[length, dropChoice] != 1 && board[length, dropChoice] != 2)
                {
                    board[length, dropChoice] = currentPlayer.playerID;
                    turn = 1;
            }
                else
                    length -=1;
            } while (turn != 1);

        }

        public void displayBoard()
        {

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    if (board[i, j] != 1 && board[i, j] != 2)
                        board[i, j] = 0;
                    Console.Write(board[i, j]);
                    Console.Write(" ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public int Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;
            }
        }
        public int Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
            }
        }

        public bool PlayAgain()
        {
            String again;
            again = Console.ReadLine();
            
            if (again[0] == 'y' || again[0] =='Y')
            {
                for (int i = 1; i <= rows; i++)
                {
                    for (int j = 1; j <= columns; j++)
                    { 
                            board[i, j] = 0;
                        Console.Write(board[i, j]);
                        Console.Write(" ");

                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                return true;
            }
            return false;
        }

        public bool checkfour(Player currentplayer) 
        {
            //horizontalCheck
            for(int j = 0; j < rows-3; j++)
            {
                for(int i = 0; i < columns; i++)
                {

                    if (board[i, j] == currentplayer.playerID &&
                        board[i, j + 1] == currentplayer.playerID &&
                        board[i, j + 2] == currentplayer.playerID &&
                        board[i, j + 3] == currentplayer.playerID)
                    {
                        return true;
                    }
                }
            }
            //vertical check
            for(int i =0; i < columns - 3; i++)
            {
                for(int j =0; j < rows; j++)
                {
                    if(board[i, j] == currentplayer.playerID &&
                        board[i + 1, j] == currentplayer.playerID &&
                        board[i + 2, j] == currentplayer.playerID &&
                        board[i + 3, j] == currentplayer.playerID)
                    {
                        return true;
                    }
                }
            }
            for(int i =3; i <columns; i++)
            {
                for(int j = 0; i < rows - 3; j++)
                {
                    if(board[i, j] == currentplayer.playerID &&
                        board[i - 1, j + 1] == currentplayer.playerID &&
                        board[i - 2, j + 2] == currentplayer.playerID &&
                        board[i - 3, j + 3] == currentplayer.playerID)
                    {
                        return true;
                    }
                }
            }
            for(int i =3; i < columns; i++)
            {
                for(int j = 3; j < rows; j++)
                {
                    if(board[i, j] == currentplayer.playerID &&
                        board[i - 1, j - 1] == currentplayer.playerID &&
                        board[i - 2, j - 2] == currentplayer.playerID &&
                        board[i - 3, j - 3] == currentplayer.playerID)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
       
    }
}
