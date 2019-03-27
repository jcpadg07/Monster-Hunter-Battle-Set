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
        //private static string connectionString = ""; 
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
            Console.WriteLine("                     Sets                     ");
            Console.WriteLine("______________________________________________");

            //Opens connection to Local SQL DB
            //Reads all data from the Battle Set table and displays it

            SqlConnection sqlconn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True");
            //sqlconn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT Helmet, Armor, Weapon, Shield, TotalPower FROM [Battle_Set]", sqlconn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT Helmet, Armor, Weapon, Shield, TotalPower  FROM [Battle_Set]", sqlconn);
            DataSet ds = new DataSet();

            da.Fill(ds);

            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.GetString(0) + " and " + reader.GetString(1) + " and " + reader.GetString(2) + " and " + reader.GetString(3) + " with " + reader.GetInt32(4));
            //}
            //reader.Close();
            //sqlconn.Close();

            //foreach (DataRow reader in ds.Tables[0].Rows)
            //{
            //    Console.WriteLine(reader["Helmet"] + " and " + reader["Armor"] + " and " + reader["Weapon"] + " and " + reader["Shield"] + " with " + reader["TotalPower"] + " total points.");
            //}

            //UNSURE
            foreach (DataRow reader in ds.Tables[0].Rows)
            {
                string helmet = reader["Helmet"] as string;
                string armor = reader["Armor"] as string;
                string weapon = reader["Weapon"] as string;
                string shield = reader["Shield"] as string;
                int totalpower = (int)reader["TotalPower"];

                Battle_Set battleset = new Battle_Set(helmet, armor, weapon, shield, totalpower);

                Console.WriteLine(battleset);
            }


            //foreach(Battle_Set set in _sets)
            //{
            //    Console.WriteLine(set.ToString());
            //}

            //if (Debugger.IsAttached)
            //{
            //    Console.ReadLine();
            //}

            //_sets.ForEach((set) => Console.WriteLine(set));

        }

        // Prompts user for set items and adds new set.
        static void AddSet()
        {

            bool done = false;
            do
            {
                
                string helmet = UI.Prompt("What's the name of the helmet you want to use? ");
                
                string armor = UI.Prompt("What's the name of the armor you want to use? ");
                
                string weapon = UI.Prompt("What's the name of the weapon you want to use? ");
                
                string shield = UI.Prompt("What's the name of the shield you want to use? ");
                
                int totalpower = int.Parse(UI.Prompt("What's the total power of these items? "));
                

                //_sets.Add(new Battle_Set { Helmet = helmet, Armor = armor, Weapon = weapon, Shield = shield, TotalPower = totalpower});
                done = UI.Prompt("Add another item? (y/n) ").ToLower() != "y";
                SqlConnection sqlconn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True");
                sqlconn.Open();
                SqlCommand querySaveBattleSet = new SqlCommand();
                querySaveBattleSet.CommandText = "SET IDENTITY_INSERT [Battle_Set] ON";
                querySaveBattleSet.Connection = sqlconn;
                querySaveBattleSet.CommandText = "INSERT into [Battle_Set](Helmet, Armor, Weapon, Shield, TotalPower) VALUES(@Helmet, @Armor, @Weapon, @Shield, @TotalPower)";
                querySaveBattleSet.Parameters.Add(new SqlParameter("@Helmet", helmet));
                querySaveBattleSet.Parameters.Add(new SqlParameter("@Armor", armor));
                querySaveBattleSet.Parameters.Add(new SqlParameter("@Weapon", weapon));
                querySaveBattleSet.Parameters.Add(new SqlParameter("@Shield", shield));
                querySaveBattleSet.Parameters.Add(new SqlParameter("@TotalPower", totalpower));
                querySaveBattleSet.ExecuteNonQuery();
                sqlconn.Close();
                

            } while (!done);
        }
    }
}
