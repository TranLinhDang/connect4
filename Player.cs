using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
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
