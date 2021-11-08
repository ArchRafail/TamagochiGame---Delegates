using System;

namespace TamagochiGame___Delegates
{
    class Tamagochi
    {
        Creature creature;
        Random random = new Random();

        public delegate void Wishes(int key);

        bool CheckLength(char[] answer) => answer.Length == 1;

        bool CheckChar(char[] answer) => (answer[0] > 48 || answer[0] < 54);

        int Menu()
        {
            Console.WriteLine($"Dear user, help your {creature.Name} with its request.");
            Console.WriteLine("What do you want to do? Pick up the correct action.");
            Console.WriteLine("1. To feed the creature.");
            Console.WriteLine("2. To walk with him/her.");
            Console.WriteLine("3. To put your favorite to bed.");
            Console.WriteLine("4. To make a treat to your pet.");
            Console.WriteLine("5. To play with creature.");
            Console.WriteLine("Give the answer here -> ");
            char[] answer_char = Console.ReadLine().ToCharArray();
            int answer = 0;
            if (CheckLength(answer_char) && CheckChar(answer_char))
                answer = Convert.ToInt32(answer_char[0]-48);
            Console.WriteLine();
            return answer;
        }

        string Name()
        {
            string name;
            Console.WriteLine("Dear user, please fill the name of creature.");
            name = Console.ReadLine();
            try
            {
                if (name == "" || name == " ")
                    throw new NullException();
            }
            catch (NullException ne)
            {
                Console.WriteLine(ne.Message);
                Console.WriteLine("The program will assign a name \"No name\" for the creature.\n\n");
                name = "No name";
            }
            Console.WriteLine();
            return name;
        }

        public Tamagochi()
        {
            creature = new Creature(Name());
        }

        public string getName() => creature.Name;

        public bool RunLife()
        {
            DateTime StartLife = DateTime.Now;
            int strong = -1, repeater = 0, temp = -1;
            bool key = false;
            Wishes wish = new Wishes(creature.Creature_wish);
            while (true)
            {
                if (!key)
                {
                    do {
                        strong = random.Next(0, 4);
                    } while (strong == temp);
                    wish(strong);
                }
                else
                {
                    if (repeater < 3 && strong != 3)
                        wish(strong);
                    else
                    {
                        wish(strong = 3);
                    }
                }
                if ((Menu() - 1) == strong)
                {
                    key = false;
                    temp = strong;
                }
                else
                {
                    key = true;
                    repeater++;
                }
                if (strong == 3 && key == true)
                    break;
                TimeSpan CheckTime = DateTime.Now.Subtract(StartLife);
                if (CheckTime.Minutes >= 1)
                    return false;
            }
            return true;
        
        }
    }
}