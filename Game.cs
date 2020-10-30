using System;
using System.Collections.Generic;

namespace MiniVilles
{
    public class Game
    {
        private List<Die> dies = new List<Die>();
        private Piles deck;
        private Player playerA;
        private Player playerB;

        public Game()
        {
            dies.AddRange(new List<Die>() { new Die("mignon"), new Die("colérique") });
            deck = new Piles();
            playerA = new Human("Humain");
            playerB = new IaWithALittleBrain("Jeremy");

            RunGame();
        }

        private void RunGame()
        {
            do
            {
                TurnOf(playerA, playerB);
                AskEndTurn(false);
                TurnOf(playerB, playerA);
                ResultTurn();
                AskEndTurn(true);
            } while (!EndGame());

            DisplayWinner(GetWinner());
            Console.ReadKey();
        }

        private void AskEndTurn(bool clear)
        {
            Console.WriteLine("Passez au tour suivant ?");
            Console.ReadKey();
            if(clear) Console.Clear();
        }

        private void ResultTurn()
        {
            Console.WriteLine("#########################################");
            Console.WriteLine(playerA);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(playerB);
            Console.WriteLine("#########################################");
        }

        private void TurnOf(Player player, Player opponent)
        {
            ThrowDies();
            ApplyAllEffects(player, opponent);
            CanBuyNewCard(player);
        }

        private void ThrowDies()
        {
            dies.ForEach(d => d.Throw());
        }

        private void CanBuyNewCard(Player player)
        {
            if (deck.pile.Count > 0)
                player.BuyCard(deck);
            else
                Console.WriteLine("/!\\ La pile de cartes est vide /!\\");
        }

        private void ApplyAllEffects(Player player, Player opponent)
        {
            Console.WriteLine("########## EFFETS ##########");
            foreach(Die die in dies)
            {
                Console.WriteLine("-- Effets du dé {0}. ({1}) --", die.name, die.Face);
                opponent.ApplyCardEffect(new List<Colors> { Colors.RED, Colors.BLUE }, die.Face, player);
                player.ApplyCardEffect(new List<Colors> { Colors.GREEN, Colors.BLUE }, die.Face, opponent);
            }

            int dieSum = 0;
            dies.ForEach(d => dieSum += d.Face);
            Console.WriteLine("-- Effets de la somme des dés. ({0}) --", dieSum);
            opponent.ApplyCardEffect(new List<Colors> { Colors.RED, Colors.BLUE }, dieSum, player);
            player.ApplyCardEffect(new List<Colors> { Colors.GREEN, Colors.BLUE }, dieSum, opponent);



            Console.WriteLine("########## END EFFECTS ##########");
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
            return playerA.Coins >= 20 || playerB.Coins >= 20;
        }
    }
}
