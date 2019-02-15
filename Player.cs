//Dale Cutshall, Linh Dang
//CS 305, Spring 2019


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
     /// <summary>
    /// Class includes the player name and ID 
    /// </summary>
    
    [Serializable]
    public class Player
    {

        public String playerName;
        public int playerID = 1;
        public Player()
        {
        }
        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }
        public int PlayerID
        {
            get
            {
                return playerID;
            }
            set
            {
                playerID = value;
            }
        }



    }
}
