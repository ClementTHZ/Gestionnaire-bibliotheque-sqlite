using System.Data;
using System.Reflection;
using Microsoft.Data.Sqlite;

public class BookServices
{
    public static void GetAllBooks()
    {
        var books = GetDataTable("SELECT * FROM books ORDER BY quantity ASC");
        foreach (DataRow book in books.Rows)
        {
            var bookQuantity = Convert.ToInt32(book["quantity"]);
            switch (bookQuantity)
            {
                case 0:
                    System.Console.WriteLine("");
                    System.Console.WriteLine($"{book["id"]} - {book["title"]} / Autheur : {book["author"]} (En rupture)");
                    break;
                case < 2:
                    System.Console.WriteLine("");
                    System.Console.WriteLine($"{book["id"]} - {book["title"]} / Autheur : {book["author"]} (Plus que {book["quantity"]} exemplaire en stock)");
                    break;
                case > 2:
                    System.Console.WriteLine("");
                    System.Console.WriteLine($"{book["id"]} - {book["title"]} / Autheur : {book["author"]} (En stock)");

                    break;
            }
        }
    }

    public static void GetAllBooksOnStock()
    {
        var books = GetDataTable("SELECT * FROM books WHERE quantity > 0 ORDER BY quantity ASC");
        foreach (DataRow book in books.Rows)
        {
            var bookQuantity = Convert.ToInt32(book["quantity"]);
            if (bookQuantity < 2)
            {
                System.Console.WriteLine("");
                System.Console.WriteLine($"{book["id"]} - {book["title"]} / Autheur : {book["author"]} (Plus que {book["quantity"]} exemplaire en stock)");
            }
            else
            {
                System.Console.WriteLine("");
                System.Console.WriteLine($"{book["id"]} - {book["title"]} / Autheur : {book["author"]} (En stock)");
            }
        }
    }

    public static void GetBookById(int id)
    {
        var books = GetDataTable("SELECT * FROM books WHERE id = @id", new Dictionary<string, object> { ["@id"] = id });
        foreach (DataRow book in books.Rows)
        {
            System.Console.WriteLine($"---------------------------------------------------------------");
            System.Console.WriteLine($"{book["id"]} - {book["title"]} ({book["author"]})");
            System.Console.WriteLine($"");
            System.Console.WriteLine($"Description : {book["description"]}");
            System.Console.WriteLine($"");
            System.Console.WriteLine($"---------------------------------------------------------------");
            System.Console.WriteLine($"Quantité : {book["quantity"]}");
            System.Console.WriteLine($"---------------------------------------------------------------");
        }
    }

    public static void CreateBook(string title, string description, string author) // TODO Gérer la modification quantité si ID book existe déjà
    {
        var book = new Book(title, description, author);
        try
        {
            ExecuteQuery("INSERT INTO books (title, description, author) VALUES (@title, @description, @author)", new Dictionary<string, object> { ["@title"] = book.Title, ["@description"] = book.Description, ["@author"] = book.Author });
            System.Console.WriteLine("✅ Le livre à été crée avec succès");
        }
        catch (System.Exception err)
        {
            System.Console.WriteLine(err.Message);
            throw;
        }
    }

    public static void AddBook(int id, int quantity)
    {
        try
        {
            ExecuteQuery("UPDATE books SET quantity = quantity + @quantity WHERE id = @id", new Dictionary<string, object> { ["@quantity"] = quantity, ["@id"] = id });
            var books = GetDataTable("SELECT * FROM books WHERE id = @id", new Dictionary<string, object> { ["@id"] = id });
            foreach (DataRow book in books.Rows)
            {
                System.Console.WriteLine($"✅ Nouveau stock : {book["quantity"]} ");
            }
        }
        catch (System.Exception err)
        {
            System.Console.WriteLine(err.Message);
            throw;
        }
    }

    public static void DeleteBook(int id)
    {
        ExecuteQuery("DELETE FROM books WHERE id = @id", new Dictionary<string, object> { ["@id"] = id });
        try
        {
            System.Console.WriteLine("✅ Le livre à été supprimé avec succès");
        }
        catch (System.Exception err)
        {
            System.Console.WriteLine(err.Message);
            throw;
        }
    }

    private static void ExecuteQuery(string sql, Dictionary<string, object> parameters)
    {
        var dbfile = @"DataSource=C:\Users\ClémentTHOREZ\Documents\C#\Projet-C#\SQLITE-Gestionnaire-bibliothèque\db\gestionnaire-bibliotheque.db";
        using (var dbConnection = new SqliteConnection(dbfile))
        {
            dbConnection.Open();
            using (var command = dbConnection.CreateCommand())
            {
                command.CommandText = sql;
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
                command.ExecuteNonQuery();
            }
        }
    }

    private static DataTable GetDataTable(string sql, Dictionary<string, object>? parameters = null)
    {
        var dbfile = @"DataSource=C:\Users\ClémentTHOREZ\Documents\C#\Projet-C#\SQLITE-Gestionnaire-bibliothèque\db\gestionnaire-bibliotheque.db";
        using (var dbConnection = new SqliteConnection(dbfile))
        {
            dbConnection.Open();
            using (var command = dbConnection.CreateCommand())
            {
                command.CommandText = sql;
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
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