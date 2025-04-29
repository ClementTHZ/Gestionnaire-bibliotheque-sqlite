var menuSelection = "";
var readResult = "";
int id = 0;

while (menuSelection != "6")
{
    Console.Clear();
    Console.WriteLine("========== MENU PRINCIPALE ==========");
    Console.WriteLine("1- Gérer les livres");
    Console.WriteLine("2- Gérer les lecteurs");
    Console.WriteLine("3- Emprunter un livre"); // Demander en console ID user et ID livre à emprunter
    Console.WriteLine("4- Rendre un livre"); // Demander en console ID emprunt
    Console.WriteLine("5- Afficher les emprunts");
    Console.WriteLine("6- Quitter");
    Console.WriteLine("=====================================");
    Console.WriteLine("> Votre choix :");
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult;
    }

    switch (menuSelection)
    {
        case "1": // Gestion des livres
            Console.Clear();
            while (menuSelection != "6")
            {
                Console.WriteLine("========== Gestion des livres ==========");
                Console.WriteLine("1- Ajouter un livre");
                Console.WriteLine("2- Supprimer un livre");
                Console.WriteLine("3- Lister les livres");
                Console.WriteLine("4- Lister les livres disponibles");
                Console.WriteLine("5- Afficher les détails d'un livre");
                Console.WriteLine("6- Retour au menu principal");
                Console.WriteLine("========================================");
                Console.WriteLine("> Votre choix :");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    menuSelection = readResult;
                }
                switch (menuSelection)
                {
                    case "1": // Ajouter un livre
                        string title = "";
                        string description = "";
                        string author = "";

                        System.Console.WriteLine("> Saisissez le titre du livre :");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            title = readResult.Trim().ToLower();
                        }
                        System.Console.WriteLine("> Saisissez la description du livre :");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            description = readResult.Trim().ToLower();
                        }
                        System.Console.WriteLine("> Saisissez l'auteur du livre :");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            author = readResult.Trim().ToLower();
                        }
                        BookServices.CreateBook(title, description, author);
                        break;

                    case "2": // Supprimer un livre
                        break;

                    case "3": // Lister les livres
                        BookServices.GetAllBooks();
                        break;

                    case "4": // Lister les livres disponibles
                        break;

                    case "5": // Afficher les détails d'un livre
                        BookServices.GetAllBooks();
                        System.Console.WriteLine("> Votre choix (ID):");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            id = int.Parse(readResult);
                        }
                        BookServices.GetBookById(id);
                        break;

                    default:
                        break;
                }
            }
            break;

        case "2": // gestion des utilisateurs
            Console.Clear();
            while (menuSelection != "5")
            {
                Console.WriteLine("========== Gestion des utilisateurs ==========");
                Console.WriteLine("1- Ajouter un utilisateur");
                Console.WriteLine("2- Supprimer un utilisateur");
                Console.WriteLine("3- Lister les utilisateurs");
                Console.WriteLine("4- Afficher un utilisateur");
                Console.WriteLine("5- Retour au menu principal");
                Console.WriteLine("==============================================");
                Console.WriteLine("> Votre choix :");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    menuSelection = readResult;
                }
                switch (menuSelection)
                {
                    case "1": // Ajouter un utilisateur
                        string firstName = "";
                        string lastName = "";
                        string age = "";

                        System.Console.WriteLine("> Saisissez le prénom de l'utilisateur :");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            firstName = readResult.Trim().ToLower();
                        }
                        System.Console.WriteLine("> Saisissez le nom de l'utilisateur :");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            lastName = readResult.Trim().ToLower();
                        }
                        System.Console.WriteLine("> Saisissez l'âge de l'utilisateur :");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            age = readResult.Trim().ToLower();
                        }
                        UserServices.CreateUser(firstName, lastName, age);
                        break;

                    case "2": // Supprimer un utilisateur
                        UserServices.GetAllUsers();
                        System.Console.WriteLine("> Votre choix (ID):");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            id = int.Parse(readResult);
                        }
                        UserServices.DeleteUser(id);
                        break;

                    case "3": // Lister les utilisateurs
                        UserServices.GetAllUsers();
                        break;

                    case "4": // Afficher un utilisateur
                        UserServices.GetAllUsers();
                        System.Console.WriteLine("> Votre choix (ID):");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            id = int.Parse(readResult);
                        }
                        UserServices.GetUserById(id);
                        break;

                    default:
                        break;
                }
            }
            break;

        case "3": // Emprunter un livre
            break;

        case "4": // Rendre un livre
            break;

        case "5": // Afficher les emprunts
            break;

        default:
            break;
    }
}
Console.Clear();



