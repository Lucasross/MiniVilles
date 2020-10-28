using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    public abstract class Cards
    {
        public int activationValue { get; protected set; }
        public Colors color { get; protected set; }
        public int cardCost;
        public int givenCoin;

        public Cards(int activationValue, Colors color, int cardCost, int givenCoin)
        {
            this.activationValue = activationValue;
            this.color = color;
            this.cardCost = cardCost;
            this.givenCoin = givenCoin;
        }
        public abstract int CardEffect(Player player);
    }
}
