using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

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

            SqlConnection sqlconn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Owner\source\repos\Monster Hunter Battle Set\Monster Hunter Battle Set\Database1.mdf';Integrated Security=True");
            sqlconn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT Helmet, Armor, Weapon, Shield, 'Total Power' FROM [Battle_Set]", sqlconn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT Helmet, Armor, Weapon, Shield, TotalPower  FROM [Battle_Set]", sqlconn);
            DataSet ds = new DataSet();

            da.Fill(ds);

            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.GetString(0) + " and " + reader.GetString(1) + " and " + reader.GetString(2) + " and " + reader.GetString(3) + " with " + reader.GetSqlValue(4));
            //}
            //reader.Close();
            sqlconn.Close();

            foreach(DataRow reader in ds.Tables[0].Rows)
            {
                Console.WriteLine(reader["Helmet"] + " and " + reader["Armor"] + " and " + reader["Weapon"] + " and " + reader["Shield"] + " with " + reader["TotalPower"]);
            }

            //if (Debugger.IsAttached)
            //{
            //    Console.ReadLine();
            //}

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
                string weapon = UI.Prompt("What's the weapon you want to use? ");
                string shield = UI.Prompt("What's the shield you want to use? ");

                _sets.Add(new Battle_Set { Helmet = helmet, Armor = armor, Weapon = weapon, Shield = shield });
                done = UI.Prompt("Add another item? (y/n) ").ToLower() != "y";

            } while (!done);
        }

    }
}
