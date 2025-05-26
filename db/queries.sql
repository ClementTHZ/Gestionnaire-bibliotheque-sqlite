DROP TABLE books; 
DROP TABLE users; 
DROP TABLE emprunts; 

CREATE TABLE books (
    id INTEGER PRIMARY KEY,
    title TEXT UNIQUE, 
    description TEXT, 
    author TEXT, 
    quantity INTEGER  DEFAULT 0,
    picture TEXT
);

CREATE TABLE users (
    id INTEGER PRIMARY KEY,
    firstname TEXT, 
    lastname TEXT, 
    age INTEGER
);

CREATE TABLE emprunts (
    id INTEGER PRIMARY KEY,
    userid INTEGER,
    bookid INTEGER, 
    created_at DATETIME DEFAULT '2025-04-29'
);

INSERT INTO books (title, description, author, picture) 
VALUES
('Le mystère de la chambre jaune', 'Une enquête pleine de rebondissements dans un vieux manoir', 'Gaston Leroux', 'https://covers.openlibrary.org/b/id/8221256-L.jpg'),
('L''île perdue', 'Un groupe d’amis découvre une île pleine de secrets', 'Marie Fontaine', 'https://covers.openlibrary.org/b/id/10557683-L.jpg'),
('La revanche du chat', 'Un chat très malin décide de reprendre le contrôle de sa maison', 'Luc Morel', 'https://covers.openlibrary.org/b/id/10909253-L.jpg'),
('L''ombre du passé', 'Un détective est hanté par une vieille affaire jamais résolue', 'Claire Duval', 'https://covers.openlibrary.org/b/id/12627625-L.jpg'),
('Les étoiles filantes', 'Une romance sous les étoiles dans une petite ville du sud', 'Emma Renaud', 'https://covers.openlibrary.org/b/id/10344451-L.jpg'),
('Voyage au centre de la classe', 'Un prof excentrique emmène ses élèves dans une aventure scientifique', 'Thomas Codi', 'https://covers.openlibrary.org/b/id/11730582-L.jpg'),
('La forêt interdite', 'Une légende dit que personne n’est jamais revenu de cette forêt', 'Julie Bernard', 'https://covers.openlibrary.org/b/id/10292559-L.jpg'),
('Le dernier dragon', 'Un jeune berger découvre qu’il est le dernier d’une lignée de chasseurs de dragons', 'Éric Marceau', 'https://covers.openlibrary.org/b/id/10523915-L.jpg'),
('Le piano magique', 'Chaque note jouée change un élément du monde réel', 'Nathalie Roche', 'https://covers.openlibrary.org/b/id/10030547-L.jpg'),
('Les chroniques de l''imaginaire', 'Une bibliothèque secrète où tous les livres prennent vie', 'Antoine Delcourt', 'https://covers.openlibrary.org/b/id/10401964-L.jpg'),
('Une journée sans fin', 'Un homme revit la même journée encore et encore', 'Patrick Leblanc', 'https://covers.openlibrary.org/b/id/8281997-L.jpg'),
('Carnet de route', 'Les pensées d’un voyageur solitaire à travers l’Asie', 'Sandrine Petit', 'https://covers.openlibrary.org/b/id/9588805-L.jpg'),
('L''enfant des tempêtes', 'Un orphelin découvre qu’il peut contrôler le vent', 'Jean Durand', 'https://covers.openlibrary.org/b/id/10404667-L.jpg'),
('La maison aux 100 portes', 'Chaque porte mène vers un monde différent', 'Claire Girard', 'https://covers.openlibrary.org/b/id/10535390-L.jpg'),
('Sous les pavés, la plage', 'Un récit entre utopie et réalité dans une société futuriste', 'Loïc Brisson', 'https://covers.openlibrary.org/b/id/12610404-L.jpg'),
('Rires en cascade', 'Une compilation d’histoires drôles et absurdes', 'Thomas Codi', 'https://covers.openlibrary.org/b/id/10791192-L.jpg'),
('Le cirque des ombres', 'Un cirque étrange apparaît chaque nuit, puis disparaît à l’aube', 'Camille Faure', 'https://covers.openlibrary.org/b/id/10821534-L.jpg'),
('Zéphyr et les voleurs de nuages', 'Une aventure aérienne dans un monde flottant', 'Léo Vasseur', 'https://covers.openlibrary.org/b/id/12631517-L.jpg'),
('Les secrets de mon grand-père', 'Un jeune garçon découvre un passé insoupçonné dans un vieux journal', 'Isabelle Fournier', 'https://covers.openlibrary.org/b/id/10473356-L.jpg'),
('Les robots ne pleurent pas', 'Une histoire émotive entre un enfant et un robot obsolète', 'Damien Leclerc', 'https://covers.openlibrary.org/b/id/10827051-L.jpg');

INSERT INTO users (firstname, lastname, age)
VALUES
('Jean', 'Dupont', 32),
('Léa', 'Martin', 28),
('Luc', 'D''Angelo', 45),
('Chloé', 'Durand', 22),
('Émile', 'Lemoine', 39),
('Zoé', 'Morel', 26),
('Thomas', 'Roux', 31),
('Anaïs', 'Petit', 24),
('Nicolas', 'Bernard', 36),
('Camille', 'Faure', 30),
('Hugo', 'Renard', 27),
('Élise', 'Noël', 34),
('Mathieu', 'Garcin', 41),
('Sarah', 'D''Hiver', 29),
('Jules', 'Charpentier', 38),
('Léna', 'Barbier', 21),
('Clément', 'Perrin', 33),
('Inès', 'Girard', 25),
('Léo', 'Marchand', 37),
('Manon', 'Benoît', 23); 
