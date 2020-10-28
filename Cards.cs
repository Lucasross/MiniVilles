using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    public enum Colors { Red,Green,Blue};
    public abstract class Cards
    {
        protected int activationValue;
        protected string color;
        protected int cardCost;
        protected int givenCoin;

        public Cards(int activationValue, string color, int cardCost, int givenCoin)
        {
            this.activationValue = activationValue;
            this.color = color;
            this.cardCost = cardCost;
            this.givenCoin = givenCoin;
        }

        public abstract int CardEffect(Player player);
    }
}
