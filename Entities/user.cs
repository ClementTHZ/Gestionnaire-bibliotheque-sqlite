public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Age { get; set; }
    public User(string firstName, string lastName, string age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}