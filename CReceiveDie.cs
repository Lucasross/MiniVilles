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
        public CReceiveDie(int activationValue, Colors color, string name, int gain, int cost)
                    : base(activationValue, color, name, gain, cost, string.Format("Recevez {0} pièce du joueur qui à lancé le dé", gain))
        {
        }

        public override int CardEffect(Player target)
        {
            Console.Write("L'effet \"{0}\" est activé.", Info.Effect);
            int stoleCoins = Info.Gain;
            if (target.Coins - Info.Gain < 0)
            {
                stoleCoins = (target.Coins - Info.Gain) + Info.Gain;
                target.Coins = 0;
            } else
            {
                target.Coins -= stoleCoins;
            }

            return stoleCoins;
        }
    }
}
