using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    class IaRandom : Player
    {
        public IaRandom(string name) : base(name)
        {
        }

        /// <summary>
        /// Gestion de l'achat chez une ia en mode aléatoire
        /// Se réfère a la classe parente : Player
        /// </summary>
        public override void BuyCard()
        {
            throw new NotImplementedException();
        }
    }
}
