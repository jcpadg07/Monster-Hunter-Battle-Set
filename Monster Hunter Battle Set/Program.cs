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
            
        }

        // Prompts user for set items and adds new set.
        static void AddSet()
        {
            
        }

    }
}
