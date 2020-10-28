using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    class CReceiveDie : Cards
    {
        public CReceiveDie(int activationValue, string color, int cardCost, int givenCoin) : base(activationValue, color, cardCost, givenCoin)
        {
        }

        public override int CardEffect(Player target)
        {
            returnn - 1;
        }
    }
}
