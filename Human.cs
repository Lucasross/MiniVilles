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
            int cost = card.cardCost;
            int coins = this.Coins;
            Console.Write("Vous avez actuellement {0}, et la carte coûte {1}.", coins, cost);
            if (coins < cost)
            {
                Console.WriteLine("Vous ne pouvez pas l'acheter.");
            }
            else
            {
                Console.WriteLine("Souhaitez vous l'acheter ?");
                Console.WriteLine("1 - Oui");
                Console.WriteLine("2 - Non");
                Console.WriteLine("Tapez le numéro devant votre choix, et pas autre chose !");
                int choice = int.Parse(Console.ReadLine());
                while (choice != 1 && choice != 2)
                {
                    Console.WriteLine("1 - Oui");
                    Console.WriteLine("2 - Non");
                    choice = int.Parse(Console.ReadLine());
                }
                if (choice == 1)
                {

                }
            }
        }
    }
}
