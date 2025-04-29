using System.Data;
using Microsoft.Data.Sqlite;

public class UserServices
{
    public static string dbfile = @"DataSource=C:\Users\ClémentTHOREZ\Documents\C#\Projet-C#\SQLITE-Gestionnaire-bibliothèque\db\gestionnaire-bibliotheque.db";
    public static void GetAllUsers()
    {
        using (var db = new SqliteConnection(dbfile))
        {
            db.Open();
            using (var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM users";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        System.Console.WriteLine($"{reader.GetString(0)} - {reader.GetString(1)} {reader.GetString(2)} - {reader.GetString(3)} ans");
                    }
                }
            }
        }
    }
    public static void GetUserById(int id) // TODO Refactoriser la méthode avec la méthodes privée DataTable
    {
        using (var db = new SqliteConnection(dbfile))
        {
            db.Open();
            using (var command = db.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM users WHERE id = {id}";
                using var reader = command.ExecuteReader();
                reader.Read();
                System.Console.WriteLine($"{reader.GetString(1)} {reader.GetString(2)}");
            }
        }
    }
    public static void CreateUser(string firstName, string lastName, string age) // TODO Refactoriser la méthode avec la méthodes privée ExecuteNonQuery()
    {
        var user = new User(firstName, lastName, age); // TODO FIX age en INT au lieu de string

        using (var db = new SqliteConnection(dbfile))
        {
            db.Open();
            using (var command = db.CreateCommand())
            {
                command.CommandText = $"INSERT INTO users (firstname, lastname, age) VALUES ('{firstName}', '{lastName}', '{age}')";
                try
                {
                    command.ExecuteNonQuery();
                    System.Console.WriteLine("✅ L'utilisateur à été crée avec succès");
                }
                catch (System.Exception err)
                {
                    System.Console.WriteLine(err.Message);
                    throw;
                }
            }
        }
    }
    public static void DeleteUser(int id) // TODO Refactoriser la méthode avec la méthodes privée ExecuteNonQuery()
    {
        using (var db = new SqliteConnection(dbfile))
        {
            db.Open();
            using (var command = db.CreateCommand())
            {
                command.CommandText = $"DELETE FROM users WHERE id = {id}";
                try
                {
                    command.ExecuteNonQuery();
                    System.Console.WriteLine("✅ L'utilisateur à été supprimé avec succès");

                }
                catch (System.Exception err)
                {
                    System.Console.WriteLine(err.Message);
                    throw;
                }
            }
        }
    }

    // --> Pour écrire dans la base de donnée (ExecuteNonQuery())
    // private static void ExecuteNonQuery(string sql)
    // {
    //     using (var db = new SqliteConnection(dbfile))
    //     {
    //         db.Open();
    //         using (var command = db.CreateCommand())
    //         {
    //             command.CommandText = sql;
    //             command.Parameters.AddWithValue("", "");
    //             command.ExecuteNonQuery();
    //         }
    //     }
    // }
    // --> Pour Lire dans la base de donnée (Reader())
}