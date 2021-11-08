using System;

namespace TamagochiGame___Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dear user, welcome to tamagochi game.");
            Console.WriteLine("Here you will have your own creature.");
            Console.WriteLine("Be careful, it wants eat, sleep and etc.");
            Console.WriteLine("If you fail the request 3 times, your creature will get sick.");
            Console.WriteLine("If you forget to treat your creature, it will dead.\n");
            Tamagochi tamagochi = new Tamagochi();
            if (tamagochi.RunLife())
                Console.WriteLine($"The life of creature {tamagochi.getName()} is finished.\n");
            else
                Console.WriteLine("Everything is OK, but the time for playing game is finished\n");
        }
    }
}
