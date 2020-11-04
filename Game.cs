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

        public int MaxCoin;
        public bool Difficulty;


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
            AskMaxCoin();
            AskDifficulty();
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
            if (Difficulty == false)
            {
                if (playerA.Coins >= MaxCoin)
                {
                    return playerA;
                }
                else
                {
                    return playerB;
                }
            }
            else
            {
                bool red = false;
                bool green = false;
                bool blue = false;
                foreach (Cards a in playerA.cards)
                {
                    if (a.Info.Color == Colors.BLUE)
                    {
                        blue = true;
                    }
                    else if (a.Info.Color == Colors.GREEN)
                    {
                        green = true;
                    }
                    else if (a.Info.Color == Colors.RED)
                    {
                        red = true;
                    }
                }
                bool Bred = false;
                bool Bgreen = false;
                bool Bblue = false;
                foreach (Cards b in playerB.cards)
                {
                    if (b.Info.Color == Colors.BLUE)
                    {
                        Bblue = true;
                    }
                    else if (b.Info.Color == Colors.GREEN)
                    {
                        Bgreen = true;
                    }
                    else if (b.Info.Color == Colors.RED)
                    {
                        Bred = true;
                    }
                }

                if (red == true && blue == true && green == true&& playerA.Coins >= MaxCoin)
                {
                    return playerA;
                }
                else
                {
                    return playerB;
                }



            }

        }

        /// <summary>
        /// Vérifie si le jeu est terminé
        /// </summary>
        /// <returns>Vrai si la partie doit se terminer</returns>
        private bool EndGame()
        {
            if (Difficulty == false)
            {
                return playerA.Coins >= MaxCoin || playerB.Coins >= MaxCoin;
            }
            else
            {
                bool red =false;
                bool green =false;
                bool blue =false;
                foreach (Cards a in playerA.cards)
                {
                    if(a.Info.Color==Colors.BLUE)
                    {
                        blue = true;
                    }
                    else if (a.Info.Color == Colors.GREEN)
                    {
                        green = true;
                    }
                    else if (a.Info.Color == Colors.RED)
                    {
                        red = true;
                    }
                }
                bool Bred = false;
                bool Bgreen = false;
                bool Bblue = false;
                foreach (Cards b in playerB.cards)
                {
                    if (b.Info.Color == Colors.BLUE)
                    {
                        Bblue = true;
                    }
                    else if (b.Info.Color == Colors.GREEN)
                    {
                        Bgreen = true;
                    }
                    else if (b.Info.Color == Colors.RED)
                    {
                        Bred = true;
                    }
                }
                if (red == true && blue == true && green == true|| Bred ==true && Bblue == true && Bgreen == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }



        }
        public int AskMaxCoin()
        {
            AskMaxCoin:
            MaxCoin = 0;
            Console.WriteLine("Choissisez votre nombre de Coin Max Ecrivez 10 , 20 ou 30 ");
            MaxCoin = Convert.ToInt32(Console.ReadLine());
            if (MaxCoin == 10 || MaxCoin ==20||MaxCoin == 30)
            {
                return MaxCoin;
            }
            else
            {
                Console.WriteLine("ERREUR La Valeur saisie n'est pas correct");
                goto AskMaxCoin;
            }
        }
        public void AskDifficulty()
        {
            NewChoise:
            String choix;
            Console.WriteLine("Voulez vous une difficultez plus elever ? OUI ou NON ");
            Console.WriteLine("Permet de finir la partie quand le joeur a obtenue le nombre de coin max mais egalement une carte de chaque");
            Console.WriteLine(" OUI ou NON ");
            choix = Console.ReadLine();
            if (choix == "OUI")
            {
                Difficulty = true;
            }
            else if (choix =="NON")
            {
                Difficulty = false;
            }
            else
            {
                Console.WriteLine("ERREUR La Valeur saisie n'est pas correct");
                goto NewChoise;
            }
        }
    }
}
