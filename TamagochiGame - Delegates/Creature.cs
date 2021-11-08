using System;


namespace TamagochiGame___Delegates
{
    class Creature
    {
        public string Name { get; set; }
        string[] wishes = { "feed", "walk", "sleep", "be treated", "play" };

        public Creature(string text) { Name = text; }
        public void Creature_wish(int key)
        {
            Console.WriteLine($"Your creature {Name} wants to {wishes[key]}.\n");
        }
     }
}
