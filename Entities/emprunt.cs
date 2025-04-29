public class Emprunt
{
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime Created_At { get; set; }
    public Emprunt(int userId, int bookId)
    {
        UserId = userId;
        BookId = bookId;
        Created_At = DateTime.Now;
    }
}