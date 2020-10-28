using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniVilles
{
    class CReceiveX : Cards
    {
        public CReceiveX(int activationValue, string color, int cardCost, int givenCoin) : base(activationValue, color, cardCost, givenCoin)
        {
        }

        public override int CardEffect(Player player)
        {
            return this.givenCoin;
        }
    }
}
