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
<<<<<<< HEAD
            Cards card = pile.PickCard();
=======

>>>>>>> 466674e7b2b77e7aff00ef51b73896230fa995b2
        }
    }
}
