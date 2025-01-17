﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    public abstract class Player
    {
        private int _coins;
        public int Coins {
            get
            {
                return _coins;
            }
            set
            {
                _coins = value;
            }
        }

        public string Name { get; private set; } = string.Empty;

        public List<Cards> cards = new List<Cards>();

        public Player(string name)
        {
            Name = name;
            Coins = 3;
        }

        /// <summary>
        /// Gère la fonction des joueurs a acheter des cartes.
        /// Si la carte est achetée alors on l'enleve du paquets pour la mettre dans la liste du joueur
        /// sinon on la remets a l'index 0 de la pile
        /// </summary>
        public abstract void BuyCard(Piles pile);


        /// <summary>
        /// Renvoi le score du joueur
        /// </summary>
        /// <returns>Le score du joueur</returns>
        public int Score()
        {
            int ScoreCoin = _coins;
            return ScoreCoin; 
        }

        /// <summary>
        /// Applique les effets des cartes qui ont la couleur et le numéro d'activation correspondant
        /// </summary>
        /// <param name="lists">Couleurs à activer</param>
        /// <param name="dieFace">Numéro d'activation</param>
        public void ApplyCardEffect(List<Colors> lists, int dieFace, Player opponent)
        {            
            foreach(Cards card in cards)
            {
                if (lists.Contains(card.Info.Color)&& card.Info.ActivationValue == dieFace)
                {
                    int gainCoin = card.CardEffect(opponent);
                    Coins += gainCoin;
                    Console.WriteLine(" {0} remporte {1} pièces.", Name, gainCoin);
                }
            }
        }

        public override string ToString()
        {
            string str = string.Format("{0} possède {1} coins et {2} cartes :\n", Name, Coins, cards.Count);
            cards.ForEach(c => str += c + "\n");
            return str;
        }
    }
}
