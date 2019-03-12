using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Hunter_Battle_Set
{
    class Program
    {
        static List<Battle_Set> _sets = new List<Battle_Set>();

        // Application entry point

        static void Main(string[] args)
        {
            UI.DisplayWelcome();

            int option = 0;
            while ((option = Menu.Prompt()) != 3)
            {
                if (option == 1)
                    AddSet();
                else if (option == 2)
                    DisplaySetList();
            }

        }

        // Displays the list of battle sets.
        static void DisplaySetList()
        {
            Console.WriteLine("Sets");
            Console.WriteLine("----------");
            _sets.ForEach((set) => Console.WriteLine(set));
            Console.WriteLine();
        }

        // Prompts user for set items and adds new set.
        static void AddSet()
        {
            bool done = false;
            do
            {
                string helmet = UI.Prompt("What's the helmet you want to use? ");
                string armor = UI.Prompt("What's the armor you want to use? ");

                _sets.Add(new Battle_Set { Helmet = helmet, Armor = armor });
                done = UI.Prompt("Add another item? (y/n) ").ToLower() != "y";

            } while (!done);
        }

    }
}
