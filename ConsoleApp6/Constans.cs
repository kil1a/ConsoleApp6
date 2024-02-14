using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Data.SqlClient;
using ConsoleApp6;

namespace ConsoleApp6
{
    internal class Constans
    {
        public const string DatabaseFile = "InvestFond.sqlite";
        public const string DatabaseConnectionString = "Data Source=" + DatabaseFile;
        public const string DatabaseServer = "sqlsrv";
        public const string DatabaseName = "InvestFond";
        public const string DatabaseUser = "admin";
        public const string DatabasePassword = "123";
        public string connectionString = $"Server= {DatabaseServer};Database= {DatabaseName} ;Uid= {DatabaseUser} ;Pwd={DatabasePassword}; TrustServerCertificate=True;";
        public string SetTableSqlite()
        {
            SqliteConnection sqliteConnection = new SqliteConnection(DatabaseConnectionString);
            using var command = sqliteConnection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            Console.WriteLine("Какую таблицу хотите заполнить?");
            string nameTable = Console.ReadLine();
            Console.WriteLine($"name {nameTable}:");
            string name = Console.ReadLine();
            Console.WriteLine($"number {nameTable}:");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"date {nameTable}(xx-xx-xxxx):");
            string dates = Console.ReadLine();
            return $"INSERT INTO {nameTable}(Name, Number, Data) VALUES ( '{name}', {num}, '{dates}')";
        }
        public string SetTableMysql()
        {

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;

            Console.WriteLine("Какую таблицу хотите заполнить?");
            string nameTable = Console.ReadLine();
            Console.WriteLine($"name {nameTable}:");
            string name = Console.ReadLine();
            Console.WriteLine($"number {nameTable}:");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"date {nameTable} (xx-xx-xxxx):");
            string dates = Console.ReadLine();

            return $"INSERT INTO {nameTable}(Name, Number, Data) VALUES ( '{name}', {num}, '{dates}')";
        }
  


    }


}
