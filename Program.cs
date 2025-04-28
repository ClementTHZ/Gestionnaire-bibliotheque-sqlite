var menuSelection = "";
var readResult = "";

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
            while (menuSelection != "5")
            {
                Console.WriteLine("========== Gestion des livres ==========");
                Console.WriteLine("1- Ajouter un livre");
                Console.WriteLine("2- Supprimer un livre");
                Console.WriteLine("3- Lister les livres");
                Console.WriteLine("4- Lister les livres disponibles");
                Console.WriteLine("5- Retour au menu principal");
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
                        break;

                    case "2": // Supprimer un livre
                        break;

                    case "3": // Lister les livres
                        break;

                    case "4": // Lister les livres disponibles
                        break;

                    default:
                        break;
                }
            }
            break;

        case "2": // gestion des utilisateurs
            Console.Clear();
            while (menuSelection != "4")
            {
                Console.WriteLine("========== Gestion des utilisateurs ==========");
                Console.WriteLine("1- Ajouter un utilisateur");
                Console.WriteLine("2- Supprimer un utilisateur");
                Console.WriteLine("3- Lister les utilisateurs");
                Console.WriteLine("4- Retour au menu principal");
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
                        break;

                    case "2": // Supprimer un utilisateur
                        break;

                    case "3": // Lister les utilisateurs
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



