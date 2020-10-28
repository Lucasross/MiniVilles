using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    public abstract class Player
    {
        private int _coins;
        public int Coins {
            get 
            {
                return _coins;
            } 
            set
            {
                _coins = value;
            } 
        }

        public List<Cards> cards = new List<Cards>();

        public Player()
        {

        }

        public Cards PickCard()
        {
            throw new NotImplementedException();
        }

        public int Score()
        {
            throw new NotImplementedException();
        }
    }
}
