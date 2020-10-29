using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    public class Piles
    {
        public List<Cards> Deck = new List<Cards>();
        public Piles()
        {

        }

        public Cards PickCard()
        {
            var card = Deck[Deck.Count-1];
            Deck.RemoveAt(Deck.Count - 1);
            return card;
        }
        public void Shuffle()
        {
            // pour trier chaque carte grace a une chaine de character Guid.NewGuid ...
            Deck = Deck.OrderBy(c => Guid.NewGuid()).ToList(); 
        }
    }
}
