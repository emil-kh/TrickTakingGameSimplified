using System;

namespace TrickTakingGameSimplified
{
    class Program
    {
        static void Main(string[] args)
        {
            //┌┬┐┬─┐┬┌─┐┬┌─  ┌┬┐┌─┐┬┌─┬┌┐┌┌─┐  ┌─┐┌─┐┌┬┐┌─┐  ┌┐ ┬ ┬  ╔═╗┌┬┐┬┬    ╦╔═
            // │ ├┬┘││  ├┴┐   │ ├─┤├┴┐│││││ ┬  │ ┬├─┤│││├┤   ├┴┐└┬┘  ║╣ │││││    ╠╩╗
            // ┴ ┴└─┴└─┘┴ ┴   ┴ ┴ ┴┴ ┴┴┘└┘└─┘  └─┘┴ ┴┴ ┴└─┘  └─┘ ┴   ╚═╝┴ ┴┴┴─┘  ╩ ╩
            Start();
        }

        private static void Start()
        {
            Console.WriteLine("Please select how many cards are drawn from the top of the shuffled deck");
            Console.WriteLine("NOTE: choose between 1 and 26");
            int handSize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            Game game = new Game(handSize);
            game.Play();

            Console.WriteLine("_______________________");
            Console.WriteLine($"End of the game {game.PrintResult()}");
        }
    }
}