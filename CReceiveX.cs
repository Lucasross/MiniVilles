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
        public CReceiveX(int activationValue, Colors color, string name, int gain, int cost) : 
                    base(activationValue, color, name, gain, cost, string.Format("Recevez {0} pièce.", gain))
        {
        }

        public override int CardEffect(Player player)
        {
            Console.Write("L'effet \"{0}\" est activé.", Info.Effect);
            return Info.Gain;
        }
    }
}
