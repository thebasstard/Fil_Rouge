**La solution contient plusieurs projets distincts :**

* Une vérification d'adresse e-mail en format console.

* Les tests unitaires de cette adressse e-mail.

* Une application WinForm comportant plusieurs fenêtres.

* Le pattern DAO permettant d'utliser les tables de la base SQL, en fonction des requêtes de l'application WinForm.


1. Pour la vérification de l'e-mail, j'ai utilisé une expression régulière.

J'ai également utilisé des boucles afin d'indiquer à l'utilisateur d'où venait son erreur dans la<chaîne de caractère.

Cette vérification a oété créée dans une méthode booléenne.


2. Les tests unitaires appellent ma méthode booléenne et renvoient l'information **'true'** si la chaîne de caractère correspond.

 

3. L'application WinForm permet à un utilisateur (un commercial) de l'utiliser pour afficher, ajouter, supprimer ou modifier des informations de la base SQL.


4. Le pattern DAO permet d'appeler des tables dans ma base SQL en créant plusieurs classes dans le projet. 

Celà permet de gérer des requêtes qui sont plus facilement appelées dans ma solution.




