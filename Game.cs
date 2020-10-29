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

            List<Cards> cards = new List<Cards>()
            {
                new CReceiveX(3, Colors.BLUE, 2, 5),
                new CReceiveX(4, Colors.BLUE, 3, 6),
            };

            piles.Deck.AddRange(cards);

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
            opponent.ApplyCardEffect(new List<Colors> { Colors.RED, Colors.BLUE }, dieFace, player);
            player.ApplyCardEffect(new List<Colors> { Colors.GREEN, Colors.BLUE }, dieFace, opponent);
            player.BuyCard(piles);
        }

        /// <summary>
        /// Affiche le gagnant
        /// </summary>
        /// <param name="player"></param>
        private void DisplayWinner(Player player)
        {
            Console.WriteLine("And the winner is ... {0} !!! Congratulations !", player.Name);
        }

        /// <summary>
        /// Récupère le gagnant
        /// </summary>
        /// <param name="player"></param>
        private Player GetWinner()
        {
            if (playerA.Coins >= 20)
            {
                return playerA;
            }
            else
            {
                return playerB;
            }
        }

        /// <summary>
        /// Vérifie si le jeu est terminé
        /// </summary>
        /// <returns>Vrai si la partie doit se terminer</returns>
        private bool EndGame()
        {
            return (playerA.Coins >= 20 || playerB.Coins >= 20);
        }
    }
}
