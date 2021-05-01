using System;
using System.Collections.Generic;

namespace TrickTakingGameSimplified
{
    public class Game
    {
        private int HandSize { get; set; }
        private Deck Deck { get; set; }
        private Hand PlayersHand { get; set; }
        private Hand ComputersHand { get; set; }
        private int PlayersScore { get; set; }
        private int ComputersScore { get; set; }

        public Game(int handSize)
        {
            HandSize = handSize;
            InitGame();
        }

        private void InitGame()
        {
            Deck = new Deck();
            Deck.Shuffle();
            PlayersHand = new Hand(Deck.DrawTopN(HandSize));
            ComputersHand = new Hand(Deck.DrawTopN(HandSize));

            Console.WriteLine($"The size of the hands: {HandSize}");
            Console.WriteLine($"{Deck.Size()} cards left in the deck.");
            Console.WriteLine("");
        }

        public void Play()
        {
            while (Deck.Size() != 0 || PlayersHand.Size() != 0)
            {
                if (PlayersHand.Size() == 0)
                {
                    GetNewHands();
                }

                Card playerSelectCard = PlayerSelectCard();
                Card computerSelectCard = ComputerSelectCard();


                WhoWon(playerSelectCard, computerSelectCard);
                Console.WriteLine($"Total score so far, player: {PlayersScore} points, AI: {ComputersScore} points");
            }
        }

        private Card PlayerSelectCard()
        {
            PlayersHand.Print();

            Console.WriteLine("Please select num the card:");
            int selectedCard = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            return PlayersHand.DrawCard(selectedCard);
        }

        private Card ComputerSelectCard()
        {
            Random rnd = new Random();
            int r = rnd.Next(0, ComputersHand.Size());

            return ComputersHand.DrawCard(r);
        }

        private void GetNewHands()
        {
            if (Deck.Size() >= (HandSize * 2))
            {
                PlayersHand = new Hand(Deck.DrawRandomN(HandSize));
                ComputersHand = new Hand(Deck.DrawRandomN(HandSize));
                Console.WriteLine($"The size of the hands: {HandSize}");
            }
            else
            {
                int newHandSize = Deck.Size() / 2;

                PlayersHand = new Hand(Deck.DrawRandomN(newHandSize));
                ComputersHand = new Hand(Deck.DrawRandomN(newHandSize));
            }


            Console.WriteLine($"{Deck.Size()} cards left in the deck.");
            Console.WriteLine("");
        }

        private void WhoWon(Card playerCard, Card computerCard)
        {
            Console.WriteLine($"The player chose {playerCard.Print()}");
            Console.WriteLine("");
            Console.WriteLine($"The AI chose {computerCard.Print()}");
            Console.WriteLine("");

            if (computerCard.Suit != playerCard.Suit)
            {
                PlayersScore++;
                Console.WriteLine("AI picked  a card  with different  suit! One point  for the player");
            }
            else
            {
                if (playerCard.Rank > computerCard.Rank)
                {
                    PlayersScore++;
                    Console.WriteLine("Player scored one point!");
                }
                else
                {
                    ComputersScore++;
                    Console.WriteLine("AI scored one point!");
                }
            }
        }

        public string PrintResult()
        {
            return $"Player's score: {PlayersScore}, AI score: {ComputersScore}";
        }
    }
}