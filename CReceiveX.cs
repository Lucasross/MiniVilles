using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniVilles
{
    public class CReceiveX : Cards
    {
        public CReceiveX(int activationValue, Colors color, int cardCost, int givenCoin) : 
                    base(activationValue, color, cardCost, givenCoin)
        {
        }

        public override int CardEffect(Player player)
        {
            return Info.Gain;
        }
    }
}
