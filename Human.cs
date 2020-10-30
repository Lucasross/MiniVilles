using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    class Human : Player
    {
        public Human(string name) : base(name)
        {
        }

        /// <summary>
        /// Affiche et demande dans la console au joueur
        /// Et se base sur les instructions de la classe parent : Player
        /// </summary>
        public override void BuyCard(Piles pile)
        {
            Cards card = pile.PickCard();
            int cost = card.Info.Cost;
            int coins = Coins;
            Console.WriteLine("Vous piochez la carte : " + card);
            Console.WriteLine("Vous avez actuellement {0} coins, et la carte coûte {1}.", coins, cost);

            if (coins < cost)
            {
                Console.WriteLine("Vous ne pouvez pas l'acheter, vous êtes trop pauvre.");
                return;
            }

            Console.WriteLine("Souhaitez vous l'acheter ?");
            Console.WriteLine("1 - Oui");
            Console.WriteLine("2 - Non");
            string answer = Console.ReadLine().ToLower();

            bool success;
            do
            {
                success = true;
                switch (answer)
                {
                    case "1":
                    case "oui":
                        BuyCardProcess(pile, card);
                        break;
                    case "2":
                    case "non":
                        Console.WriteLine("Ok je la remets dans le paquet.");
                        pile.ReplaceCard(card);
                        break;
                    default:
                        success = false;
                        break;
                }
            } while (!success);
        }

        private void BuyCardProcess(Piles pile, Cards card)
        {
            cards.Add(card);
            Coins -= card.Info.Cost;
            Console.WriteLine("Il vous reste {0} coins.", Coins);
        }
    }
}
