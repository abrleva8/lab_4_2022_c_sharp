using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace lab_4 {
    public class DataBaseWorker {
        public static bool IsExists(int number, string conn="DefaultConnection") {
            SQLiteConnection sqLiteConnection = new SQLiteConnection(
                                                        ConfigurationManager.ConnectionStrings[conn].ConnectionString);
            sqLiteConnection.Open();
            SQLiteCommand command = sqLiteConnection.CreateCommand();
            command.CommandText = "SELECT number FROM accounts WHERE number = @number";
            command.Parameters.Add(new SQLiteParameter("@number", number));
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(dataTable);
            sqLiteConnection.Close();
            return dataTable.Rows.Count > 0;
        }

        public static void Edit(Account account, string conn="DefaultConnection") {
            SQLiteConnection sqLiteConnection = new SQLiteConnection(
                                                        ConfigurationManager.ConnectionStrings[conn].ConnectionString);
            sqLiteConnection.Open();
            SQLiteCommand command = sqLiteConnection.CreateCommand();
            command.CommandText = "UPDATE accounts SET number=@number, name=@name, surname=@surname," +
                                  "country=@country, money=@money, currency=@currency WHERE number=@number";
            command.Parameters.Add(new SQLiteParameter("@number", account.Number));
            command.Parameters.Add(new SQLiteParameter("@name", account.Name));
            command.Parameters.Add(new SQLiteParameter("@surname", account.Surname));
            command.Parameters.Add(new SQLiteParameter("@country", account.Country));
            command.Parameters.Add(new SQLiteParameter("@money", account.Money));
            command.Parameters.Add(new SQLiteParameter("@currency", account.Currency));
            command.ExecuteNonQuery();
            sqLiteConnection.Close();
        }

        public static void Add(Account account, string conn="DefaultConnection") {
            SQLiteConnection sqLiteConnection = new SQLiteConnection(
                ConfigurationManager.ConnectionStrings[conn].ConnectionString);
            sqLiteConnection.Open();
            SQLiteCommand command = sqLiteConnection.CreateCommand();
            command.CommandText = "INSERT into accounts (number,name,surname,country,money,currency)" +
                                  "values (@number, @name, @surname, @country, @money, @currency)";
            command.Parameters.Add(new SQLiteParameter("@number", account.Number));
            command.Parameters.Add(new SQLiteParameter("@name", account.Name));
            command.Parameters.Add(new SQLiteParameter("@surname", account.Surname));
            command.Parameters.Add(new SQLiteParameter("@country", account.Country));
            command.Parameters.Add(new SQLiteParameter("@money", account.Money));
            command.Parameters.Add(new SQLiteParameter("@currency", account.Currency));
            command.ExecuteNonQuery();
            sqLiteConnection.Close();
        }


        public static void Delete(int key, string conn="DefaultConnection") {
            SQLiteConnection sqLiteConnection = new SQLiteConnection(
                ConfigurationManager.ConnectionStrings[conn].ConnectionString);
            sqLiteConnection.Open();
            SQLiteCommand command = sqLiteConnection.CreateCommand();
            command.CommandText = "DELETE from accounts WHERE number=@key";
            command.Parameters.Add(new SQLiteParameter("@key", key));
            command.ExecuteNonQuery();
            sqLiteConnection.Close();
        }

        public static DataTable GetTable(string conn="DefaultConnection") {
            SQLiteConnection sqLiteConnection = new SQLiteConnection(
                ConfigurationManager.ConnectionStrings[conn].ConnectionString);
            sqLiteConnection.Open();
            SQLiteCommand command = sqLiteConnection.CreateCommand();
            command.CommandText = "SELECT* from accounts";
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(dataTable);
            sqLiteConnection.Close();
            return dataTable;
        }


    }
}
