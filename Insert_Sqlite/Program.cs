using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Insert_Sqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = System.IO.File.ReadAllText("C:/Workspace/Data/data_stock_fake.cs");
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, Stock>>>>(content);

            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "C:/Users/DATTQ/Downloads/sqlitestudio-3.3.3/SQLiteStudio/stock_db.db";

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                /*using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();

                    foreach (var a in dictionary)
                    {
                        foreach (var b in dictionary[a.Key])
                        {
                            foreach (var c in dictionary[a.Key][b.Key])
                            {
                                insertCmd.CommandText = "INSERT INTO stock VALUES('" + c.Value.Code + "','" + c.Value.Price + "','" + c.Value.Quantity + "')";
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                }*/

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM stock";

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var code = reader.GetString(0);
                        var price = reader.GetDouble(1);
                        var quantity = reader.GetInt32(2);

                        Console.WriteLine(code+","+price+","+quantity);
                    }
                }
            }
        }
    }
}
