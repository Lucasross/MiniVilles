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
        public string Effect { get; set; }
    }

    public abstract class Cards
    {
        public CardsInfo Info { get; protected set; }

        public Cards(int activationValue, Colors color, string name, int Gain, int cost, string effect)
        {
            Info = new CardsInfo()
            {
                Name = name,
                ActivationValue = activationValue,
                Color = color,
                Cost = cost,
                Gain = Gain,
                Effect = effect,
            };
        }
        public abstract int CardEffect(Player opponent);

        public override string ToString()
        {
            return string.Format("[{0}] {1} - {2} : {3} - {4}", Info.ActivationValue, Info.Color, Info.Name, Info.Effect, Info.Cost);
        }
    }
}
