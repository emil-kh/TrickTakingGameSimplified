using System;
using System.Collections.Generic;

namespace TrickTakingGameSimplified
{
    public class Hand
    {
        private List<Card> Cards { get; set; }

        public Hand(List<Card> cards)
        {
            Cards = cards;
        }

        public void Print()
        {
            Console.WriteLine("_______________________");
            for (int i = 0; i < Cards.Count; i++)
            {
                Console.WriteLine($"Num:{i}  ({Cards[i].Print()})");
            }

            Console.WriteLine("_______________________");
        }

        public Card DrawCard(int index)
        {
            Card selectedCard = Cards[index];
            Cards.RemoveAt(index);

            return selectedCard;
        }

        public int Size()
        {
            return Cards.Count;
        }
    }
}