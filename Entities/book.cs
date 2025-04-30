public class Book
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public int Quantity { get; set; }
    public Book(string title, string description, string author)
    {
        Title = title;
        Description = description;
        Author = author;
        Quantity = 0;
    }
}