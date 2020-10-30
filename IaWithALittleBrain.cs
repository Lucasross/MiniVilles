using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    class IaWithALittleBrain : Player
    {
        public IaWithALittleBrain(string name) : base(name)
        {
        }

        /// <summary>
        /// Gestion de l'achat chez une ia en mode aléatoire
        /// Se réfère a la classe parente : Player
        /// </summary>
        public override void BuyCard(Piles pile)
        {
            Cards card = pile.PickCard();

            Console.WriteLine("{0} pioche la carte : {1}", Name, card);
            Console.WriteLine("{0} a actuellement {1} coins, et la carte coûte {2}.",Name, Coins, card.Info.Cost);

            if (card.Info.Cost > Coins)
            {
                Console.WriteLine("{0} n'a pas assez d'argent.", Name);
                return;
            }

            if(WantToBuyCard(card))
            {
                Console.WriteLine("{0} achète la carte.", Name);
                Coins -= card.Info.Cost;
                cards.Add(card);
            } else
            {
                Console.WriteLine("{0} n'achète pas la carte.", Name);
                pile.ReplaceCard(card);
            }
        }

        private bool WantToBuyCard(Cards card)
        {
            int activationValue = card.Info.ActivationValue;

            if (Coins >= 15)
                return false;

            if (Coins <= 5 && cards.Count <= 6)
                return true;

            if (card.Info.Color == Colors.BLUE)
                return true;

            return cards.Find(c => c.Info.ActivationValue == activationValue) == null;
        }
    }
}
