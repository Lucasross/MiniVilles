using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    public struct CardsInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivationValue { get; set; }
        public Colors Color { get; set; }
        public int Cost { get; set; }
        public int Gain { get; set; }
    }

    public abstract class Cards
    {
        public CardsInfo Info { get; protected set; }

        public Cards(int activationValue, Colors color, int cost, int givenCoin)
        {
            Info = new CardsInfo()
            {
                ActivationValue = activationValue,
                Color = color,
                Cost = cost,
                Gain = givenCoin,
            };
        }
        public abstract int CardEffect(Player player);
    }
}
