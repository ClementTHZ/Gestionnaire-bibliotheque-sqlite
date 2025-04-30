var menuSelection = "";
var readResult = "";
int id = 0;
int quantity = 0;
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
            while (menuSelection != "7")
            {
                Console.Clear();

                Console.WriteLine("========== Gestion des livres ==========");
                Console.WriteLine("1- Crée un nouveau livre");
                Console.WriteLine("2- Ajouter un livre");
                Console.WriteLine("3- Supprimer un livre");
                Console.WriteLine("4- Lister les livres");
                Console.WriteLine("5- Lister les livres disponibles");
                Console.WriteLine("6- Afficher les détails d'un livre");
                Console.WriteLine("7- Retour au menu principal");
                Console.WriteLine("========================================");
                Console.WriteLine("> Votre choix :");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    menuSelection = readResult;
                }
                switch (menuSelection)
                {
                    case "1": // Créer une référence de livre
                        string title = "";
                        string description = "";
                        string author = "";

                        Console.Clear();
                        System.Console.WriteLine("> Saisissez le titre du livre :");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) title = readResult.Trim().ToLower();

                        Console.Clear();
                        System.Console.WriteLine("> Saisissez la description du livre :");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) description = readResult.Trim().ToLower();

                        Console.Clear();
                        System.Console.WriteLine("> Saisissez l'auteur du livre :");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) author = readResult.Trim().ToLower();

                        Console.Clear();
                        BookServices.CreateBook(title, description, author);

                        // TODO Finir l'ajout du stock après la création
                        System.Console.WriteLine();
                        System.Console.WriteLine("> Ajouter du stock ?(y/n)");
                        Console.Write(">");
                        readResult = Console.ReadLine();
                        if ((readResult != null)) readResult.Trim().ToLower();
                        if (readResult == "Y")
                        {
                            System.Console.WriteLine("> Combien de livre voulez-vous ajouer ?");
                            System.Console.Write(">");
                            readResult = Console.ReadLine();
                            if (readResult != null) quantity = int.Parse(readResult.Trim());
                            BookServices.AddBook(id, quantity);
                        }

                        break;

                    case "2": // Ajouter un livre
                        Console.Clear();
                        BookServices.GetAllBooks();

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Votre choix (ID):");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) id = int.Parse(readResult.Trim());

                        Console.Clear();
                        System.Console.WriteLine("Indiquer le nombre de livre à ajouter :");
                        System.Console.WriteLine("> Votre choix (ID):");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) quantity = int.Parse(readResult.Trim());

                        Console.Clear();
                        BookServices.AddBook(id, quantity);

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Taper entrée pour continuer");
                        Console.Write(">");
                        Console.ReadLine();
                        break;

                    case "3": // Supprimer un livre

                        Console.Clear();
                        BookServices.GetAllBooks();

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Votre choix (ID):");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) id = int.Parse(readResult);

                        Console.Clear();
                        BookServices.DeleteBook(id);

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Taper entrée pour continuer");
                        Console.Write(">");
                        Console.ReadLine();
                        break;

                    case "4": // Lister les livres
                        Console.Clear();
                        BookServices.GetAllBooks();

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Taper entrée pour continuer");
                        Console.Write(">");
                        Console.ReadLine();
                        break;

                    case "5": // Lister les livres disponibles
                        Console.Clear();
                        BookServices.GetAllBooksOnStock();

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Taper entrée pour continuer");
                        Console.Write(">");
                        Console.ReadLine();
                        break;

                    case "6": // Afficher les détails d'un livre
                        Console.Clear();
                        BookServices.GetAllBooks();

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Votre choix (ID):");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) id = int.Parse(readResult);

                        Console.Clear();
                        BookServices.GetBookById(id);

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Taper entrée pour continuer");
                        Console.Write(">");
                        Console.ReadLine();
                        break;

                    default:
                        break;
                }
            }
            break;

        case "2": // Gestion des utilisateurs
            Console.Clear();
            while (menuSelection != "5")
            {
                Console.Clear();
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

                        Console.Clear();
                        System.Console.WriteLine("> Saisissez le prénom de l'utilisateur :");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) firstName = readResult.Trim().ToLower();

                        Console.Clear();
                        System.Console.WriteLine("> Saisissez le nom de l'utilisateur :");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) lastName = readResult.Trim().ToLower();

                        Console.Clear();
                        System.Console.WriteLine("> Saisissez l'âge de l'utilisateur :");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) age = readResult.Trim().ToLower();

                        Console.Clear();
                        UserServices.CreateUser(firstName, lastName, age);

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Taper entrée pour continuer");
                        Console.Write(">");
                        Console.ReadLine();
                        break;

                    case "2": // Supprimer un utilisateur
                        Console.Clear();
                        UserServices.GetAllUsers();

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Votre choix (ID):");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) id = int.Parse(readResult);

                        Console.Clear();
                        UserServices.DeleteUser(id);

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Taper entrée pour continuer");
                        Console.Write(">");
                        Console.ReadLine();
                        break;

                    case "3": // Lister les utilisateurs
                        Console.Clear();
                        UserServices.GetAllUsers();

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Taper entrée pour continuer");
                        Console.Write(">");
                        Console.ReadLine();
                        break;

                    case "4": // Afficher un utilisateur
                        Console.Clear();
                        UserServices.GetAllUsers();

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Votre choix (ID):");
                        System.Console.Write("> ");
                        readResult = Console.ReadLine();
                        if (readResult != null) id = int.Parse(readResult);

                        Console.Clear();
                        UserServices.GetUserById(id);

                        System.Console.WriteLine();
                        System.Console.WriteLine("> Taper entrée pour continuer");
                        Console.Write(">");
                        Console.ReadLine();
                        break;

                    default:
                        break;
                }
            }
            break;

        case "3": // Emprunter un livre
            int userId = 0;
            int bookId = 0;

            Console.Clear();
            UserServices.GetAllUsers();
            System.Console.WriteLine();
            System.Console.WriteLine("> Quel est l'utilisateur ?");
            System.Console.Write("> ");
            readResult = Console.ReadLine();
            if (readResult != null) userId = int.Parse(readResult);

            Console.Clear();
            BookServices.GetAllBooksOnStock();
            System.Console.WriteLine();
            System.Console.WriteLine("> Quel livre est emprunté (ID)");
            System.Console.Write("> ");
            readResult = Console.ReadLine();
            if (readResult != null) bookId = int.Parse(readResult);

            Console.Clear();
            EmpruntServices.CreateEmprunt(userId, bookId);
            break;

        case "4": // Rendre un livre
            Console.Clear();
            UserServices.GetAllUsers();

            System.Console.WriteLine();
            System.Console.WriteLine("> Quel est l'utilisateur ?");
            System.Console.Write("> ");
            readResult = Console.ReadLine();
            if (readResult != null) id = int.Parse(readResult);

            Console.Clear();
            EmpruntServices.GetAllEmpruntsByUserId(id);

            System.Console.WriteLine();
            System.Console.WriteLine("Indiquer le livre retourné (ID):");
            System.Console.Write("> ");
            readResult = Console.ReadLine();
            if (readResult != null) id = int.Parse(readResult);

            Console.Clear();
            EmpruntServices.ReturnEmprunt(id);

            break;

        case "5": // Afficher les emprunts
            Console.Clear();
            EmpruntServices.GetAllEmprunts();
            break;

        default:
            break;
    }
    System.Console.WriteLine();
    System.Console.WriteLine("Taper entrée pour continuer");
    System.Console.Write("> ");
    Console.ReadLine();
}
Console.Clear();



