**La solution contient plusieurs projets distincts :**

* Une v�rification d'adresse e-mail en format console.

* Les tests unitaires de cette adressse e-mail.

* Une application WinForm comportant plusieurs fen�tres.

* Le pattern DAO permettant d'utliser les tables de la base SQL, en fonction des requ�tes de l'application WinForm.


1. Pour la v�rification de l'e-mail, j'ai utilis� une expression r�guli�re.

J'ai �galement utilis� des boucles afin d'indiquer � l'utilisateur d'o� venait son erreur dans la<cha�ne de caract�re.

Cette v�rification a o�t� cr��e dans une m�thode bool�enne.


2. Les tests unitaires appellent ma m�thode bool�enne et renvoient l'information **'true'** si la cha�ne de caract�re correspond.

 

3. L'application WinForm permet � un utilisateur (un commercial) de l'utiliser pour afficher, ajouter, supprimer ou modifier des informations de la base SQL.


4. Le pattern DAO permet d'appeler des tables dans ma base SQL en cr�ant plusieurs classes dans le projet. 

Cel� permet de g�rer des requ�tes qui sont plus facilement appel�es dans ma solution.




