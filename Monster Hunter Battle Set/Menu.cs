using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Hunter_Battle_Set
{
    // Represents the application menu
    
    internal class Menu
    {
        static string[] _options = new string[]
        {
            "Add battle set",
            "View list of battle sets",
            "Quit"
        };

        // Display the menu options.
        static void Display()
        {
            for (int i = 0; i < _options.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {_options[i]}");
            }

        }

        //Displays the menu and prompts the user for which action to take.
        internal static int Prompt()
        {
            bool valid = false;
            int parsedOption = 0;
            string option = string.Empty;

            Display();
            do
            {
                option = UI.Prompt($"Please select an option (1-{_options.Length}): ");
                bool canParse = int.TryParse(option, out parsedOption);
                valid = canParse && parsedOption > 0 && parsedOption <= 3;

            }
            while (!valid);

            return parsedOption;
        }



    }

}
