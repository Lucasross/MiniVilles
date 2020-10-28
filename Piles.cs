using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    class Piles
    {
        public List<Cards> Deck;
        public Piles(List<Cards> ListCardsBuildingPiles)
        {
           foreach(Cards card in ListCardsBuildingPiles)
            {
                Deck.Add(card);
            }
        }

        public Cards PickCard()
        {
            Cards PickedCard = Deck[Deck.Count-1];
            Deck.RemoveAt(Deck.Count - 1);
            return PickedCard;
        }
        public void Shuffle()
        {
            Deck = Deck.OrderBy(c => Guid.NewGuid()).ToList(); 
            // pour trier chaque carte grace a un chaine de character Guid.NewGuid ...
        }



    }
}
