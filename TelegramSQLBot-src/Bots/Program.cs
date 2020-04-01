//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SQLite;
//using System.IO;

//namespace SQL_Project
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            if (!File.Exists(@"C:\Folder\MY_DATABASE.db"))
//            {
//                SQLiteConnection.CreateFile(@"C:\Folder\MY_DATABASE.db");
//                Console.WriteLine("DATABASE WAS CREATED");
//            }
//            else
//            {
//                Console.WriteLine("DATABASE EXISTS");
//            }

//            SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Folder\MY_DATABASE.db; Version = 3;");
//            connect.Open();

//            SQLiteCommand commandSQL;
//            commandSQL = new SQLiteCommand("CREATE TABLE IF NOT EXISTS \"Employees\"" + " (\"id\" INTEGER PRIMARY KEY AUTOINCREMENT, \"name\" TEXT, \"info\" TEXT)", connect);
//            commandSQL.ExecuteNonQuery();

//            commandSQL = new SQLiteCommand("INSERT INTO \"Employees\" (name, info) VALUES (\'B\', \'SOTRUDNIK2\')", connect);
//            commandSQL.ExecuteNonQuery();

//            commandSQL = new SQLiteCommand("SELECT * FROM \"Employees\"", connect);
//            SQLiteDataReader reader = commandSQL.ExecuteReader();
//            while (reader.Read())
//            {
//                if(command == "select")
//                    Console.WriteLine("ID  " + reader["description"] + "  NAME " + reader["examples"] + " INFO " + reader["syntacsis"]);
//            }
//            reader.Close();

//            connect.Close();
//            Console.ReadLine();
//        }
//    }
//}
