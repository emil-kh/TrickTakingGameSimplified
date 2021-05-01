namespace TrickTakingGameSimplified
{
    public class Card
    {
        public int Rank { get; set; }
        public string Suit { get; set; }

        public Card(int rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public string Print()
        {
            return $"{Rank} of {Suit}s";
        }
    }
}