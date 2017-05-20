using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Login
{
    class Program
    {
        private MySqlDataReader reader;
        private MySqlConnection connection;
        private MySqlCommand cmd;
        //private MySqlCommand cmd1;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Open a connection to MySql DataBase
        public void Initialize()
        {
            server = "localhost";
            database = "c1608l";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public void Login()
        {
            Initialize();
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            cmd = connection.CreateCommand();
            cmd.CommandText = "select * from admins where username= '" + username + "' and password='" + password + "' and status = 1";
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                connection.Close();
                MainMenu();
            }
            else
            {
                Console.WriteLine("Admin doesn't exist ..");
                Console.ReadKey();
            }
        }
        public void MainMenu()
        {
            int choice;
            Console.WriteLine("--------------Menu-----------");
            Console.WriteLine("1.");
            Console.WriteLine("2.");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Login();
        }
    }
}
