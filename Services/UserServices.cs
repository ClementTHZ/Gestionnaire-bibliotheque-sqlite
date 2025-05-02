using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

public class UserServices
{
    public static void GetAllUsers()
    {
        var users = GetDataTable("SELECT * FROM users");

        foreach (DataRow user in users.Rows)
        {
            System.Console.WriteLine($"{user["id"]} - {user["firstName"]} {user["lastName"]} - {user["age"]}");
        }
        /*  Sans utiliser la méthode privée :
        // using (var db = new SqliteConnection(dbfile))
        // {
        //     db.Open();
        //     using (var command = db.CreateCommand())
        //     {
        //         command.CommandText = "SELECT * FROM users";
        //         using (var reader = command.ExecuteReader())
        //         {
        //             while (reader.Read())
        //             {
        //                 System.Console.WriteLine($"{reader.GetString(0)} - {reader.GetString(1)} {reader.GetString(2)} - {reader.GetString(3)} ans");
        //             }
        //         }
        //     }
        // }
        */
    }

    public static void GetUserById(int id)
    {
        var users = GetDataTable("SELECT * FROM users WHERE id = @id", new Dictionary<string, object> { ["@id"] = id });
        foreach (DataRow user in users.Rows)
        {
            System.Console.WriteLine($"{user["firstName"]} {user["lastName"]} - {user["age"]} ans");
        }
    }

    public static void CreateUser(string firstName, string lastName, string age)
    {
        ExecuteNonQuery("INSERT INTO users (firstname, lastname, age) VALUES (@firstname, @lastname, @age)", new Dictionary<string, object> { ["@firstname"] = firstName, ["@lastname"] = lastName, ["@age"] = age });
        try
        {
            System.Console.WriteLine("✅ L'utilisateur à été crée avec succès");
        }
        catch (System.Exception err)
        {
            System.Console.WriteLine(err.Message);
            throw;
        }
        /* Sans utiliser la méthode privée :
        string dbfile = @"DataSource=C:\Users\ClémentTHOREZ\Documents\C#\Projet-C#\SQLITE-Gestionnaire-bibliothèque\db\gestionnaire-bibliotheque.db";
        var user = new User(firstName, lastName, age);

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
        */
    }

    public static void DeleteUser(int id)
    {
        ExecuteNonQuery("DELETE FROM users WHERE id = @id", new Dictionary<string, object> { ["@id"] = id });
        try
        {
            System.Console.WriteLine("✅ L'utilisateur à été supprimé avec succès");
        }
        catch (System.Exception err)
        {
            System.Console.WriteLine(err.Message);
            throw;
        }

        /* Sans utiliser la méthode privée :
        // using (var db = new SqliteConnection(dbfile))
        // {
        //     db.Open();
        //     using (var command = db.CreateCommand())
        //     {
        //         command.CommandText = $"DELETE FROM users WHERE id = {id}";
        //         try
        //         {
        //             command.ExecuteNonQuery();
        //             System.Console.WriteLine("✅ L'utilisateur à été supprimé avec succès");

        //         }
        //         catch (System.Exception err)
        //         {
        //             System.Console.WriteLine(err.Message);
        //             throw;
        //         }
        //     }
        // }
        */
    }

    private static void ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
    // --> Pour écrire dans la base de donnée
    {
        string dbfile = @"DataSource=C:\Users\ClémentTHOREZ\Documents\C#\Projet-C#\SQLITE-Gestionnaire-bibliothèque\db\gestionnaire-bibliotheque.db";
        using (var db = new SqliteConnection(dbfile))
        {
            db.Open();
            using (var command = db.CreateCommand())
            {
                command.CommandText = sql;
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                command.ExecuteNonQuery();
            }
        }
    }

    private static DataTable GetDataTable(string sql, Dictionary<string, object>? parameters = null)
    // --> Pour Lire dans la base de donnée
    {
        string dbfile = @"DataSource=C:\Users\ClémentTHOREZ\Documents\C#\Projet-C#\SQLITE-Gestionnaire-bibliothèque\db\gestionnaire-bibliotheque.db";
        using (var db = new SqliteConnection(dbfile))
        {
            db.Open();
            using (var command = db.CreateCommand())
            {
                command.CommandText = sql;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }
                using (var reader = command.ExecuteReader())
                {
                    var table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
    }
}