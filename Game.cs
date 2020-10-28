using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVilles
{
    public class Game
    {
        private Die die;
        private Piles piles;
        private Player playerA;
        private Player playerB;

        public Game()
        {
            die = new Die();
            piles = new Piles();

            playerA = new Human("Human");
            playerB = new IaRandom("Computer");

            RunGame();
        }

        private void RunGame()
        {
            do
            {
                TurnOf(playerA, playerB);
                TurnOf(playerB, playerA);
            } while (!EndGame());

            DisplayWinner(GetWinner());
        }

        private void TurnOf(Player player, Player opponent)
        {
            int dieFace = die.Throw();
            opponent.ApplyCardEffect(new List<Colors> { Colors.RED, Colors.BLUE }, dieFace);
            player.ApplyCardEffect(new List<Colors> { Colors.GREEN, Colors.BLUE }, dieFace);
            player.BuyCard();
        }

        /// <summary>
        /// Affiche le gagnant
        /// </summary>
        /// <param name="player"></param>
        private void DisplayWinner(Player player)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Récupère le gagnant
        /// </summary>
        /// <param name="player"></param>
        private Player GetWinner()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Vérifie si le jeu est terminé
        /// </summary>
        /// <returns>Vrai si la partie doit se terminer</returns>
        private bool EndGame()
        {
            throw new NotImplementedException();    
        }
    }
}
