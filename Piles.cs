using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniVilles
{
    public class Piles
    {
        public List<Cards> pile = new List<Cards>();
        public Piles()
        {
            AddCards(3, new CReceiveX(1, Colors.BLUE, "Champ de blé", 1, 1));
            AddCards(4, new CReceiveX(1, Colors.BLUE, "Ferme", 1, 2));
            AddCards(4, new CReceiveX(2, Colors.GREEN, "Boulangerie", 2, 1));
            AddCards(4, new CReceiveDie(3, Colors.RED, "Café", 1, 2));
            AddCards(3, new CReceiveX(4, Colors.GREEN, "Supérette", 3, 2));
            AddCards(4, new CReceiveX(5, Colors.BLUE, "Forêt", 1, 2));
            AddCards(4, new CReceiveDie(5, Colors.RED, "Restaurant", 2, 4));
            AddCards(2, new CReceiveX(6, Colors.BLUE, "Stade", 4, 6));
            //two dice
            AddCards(2, new CReceiveX(7, Colors.BLUE, "Cinéma", 4, 3));
            AddCards(2, new CReceiveX(8, Colors.BLUE, "Usine", 3, 1));
            AddCards(2, new CReceiveDie(9, Colors.RED, "Foire", 3, 1));
            AddCards(2, new CReceiveX(10, Colors.GREEN, "Piscine", 5, 4));
            AddCards(2, new CReceiveX(11, Colors.GREEN, "Centre commercial", 6, 4));
            AddCards(1, new CReceiveDie(12, Colors.RED, "Boite de nuit", 5, 3));
            AddCards(1, new CReceiveX(12, Colors.GREEN, "Festival", 10, 6));
            AddCards(1, new CReceiveX(12, Colors.BLUE, "Musée des sciences", 8, 5));

            Shuffle();
        }

        private void AddCards(int numbers, Cards card)
        {
            for (int i = 0; i < numbers; i++)
            {
                pile.Add(card);
            }
        }

        public Cards PickCard()
        {
            var card = pile[pile.Count-1];
            pile.RemoveAt(pile.Count - 1);
            return card;
        }

        public void ReplaceCard(Cards card)
        {
            pile.Insert(0, card);
        }

        public void Shuffle()
        {
            // pour trier chaque carte grace a une chaine de character Guid.NewGuid ...
            pile = pile.OrderBy(c => Guid.NewGuid()).ToList(); 
        }

        public override string ToString()
        {
            string str = string.Format("Pile ({0}): \n", pile.Count);
            pile.ForEach(c => str += c + "\n");
            return str;
        }
    }
}
