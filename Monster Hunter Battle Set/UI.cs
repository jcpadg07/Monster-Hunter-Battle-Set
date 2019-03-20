using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Hunter_Battle_Set
{
    class UI
    {
        // Displays the welcome text.
        internal static void DisplayWelcome()
        {
            Console.WriteLine("<><><><><><> Battle Set Maker <><><><><><><><>");
            Console.WriteLine("______________________________________________");
            Console.WriteLine("                                              ");
            Console.WriteLine("     Create your own battle sets offline      ");
            Console.WriteLine("______________________________________________");
            Console.WriteLine("                                              ");
            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><>");
            Console.WriteLine("                                              ");
        }

        // Prompts the user to provide an option.

        internal static string Prompt(string message)
        {
            Console.Write(message);
            string userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput.Trim();
        }

    }
}
