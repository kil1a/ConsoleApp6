using ConsoleApp6;
using Microsoft.Data.Sqlite;
using Microsoft.Data.SqlClient;
Constans C = new Constans();
//Console.WriteLine("Hello, World!");
File.Create(path:Constans.DatabaseFile).Close();
using (SqliteConnection databaseConnection = new SqliteConnection(Constans.DatabaseConnectionString))
{
        databaseConnection.Open();
        using (var command = databaseConnection.CreateCommand())
        {

            while (true)
            {
            Console.WriteLine("Меню\n1.Создать таблицы sqlite\n2.Заполнить таблицы sqlite\n3.Заполнить таблицы Mysql\n4.Нажмите Enter что бы выйти");
            int num = Convert.ToInt32(Console.ReadLine());

                switch (num)
                {
                    case 1:
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "CREATE TABLE Brent (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT , Name Text(50), Number INT, Data DATE);" +
                                          "CREATE TABLE Gold (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT , Name Text(50), Number INT, Data DATE);" +
                                          "CREATE TABLE RTS (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Name Text(50), Number INT, Data DATE);";
                    command.ExecuteNonQuery();
                    break;
                    case 2:
                        command.CommandText = C.SetTableSqlite();
                        command.ExecuteNonQuery();
                        break;
                    case 3:
                    using (SqlConnection databaseMyConnection = new SqlConnection(C.connectionString))
                    {
                        databaseMyConnection.Open();
                        using (var Mycommand = databaseMyConnection.CreateCommand())
                        {

                            Mycommand.CommandText = C.SetTableMysql();
                            Mycommand.ExecuteNonQuery();
                        }
                        databaseMyConnection.Close();
                    }
                        break;
                    case 4:
                        break;


                }
            }

        }
    databaseConnection.Close();
}