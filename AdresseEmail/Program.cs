using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdresseEmail
{
    public class Program
    {
        public static bool EmailValide(string eMail)
        {

            while (eMail == "")//<redemander une adresse eMail tant que le champ est vide/>
            {

                Console.WriteLine("\nL'adresse eMail est vide");
                return false;
                Console.WriteLine("\nVeuillez entrer une adresse eMail");
                eMail = Console.ReadLine();
                

            }

            Regex ReMail = new Regex(@"^[0-9a-zA-Z]+[-_.]?[0-9a-zA-Z]+@[a-zA-Z]{2,}\.[a-zA-Z]{2,}$");

            while (!ReMail.IsMatch(eMail))
            {

                int position_arobase = eMail.IndexOf("@");//<position de l'arobase dans l'adresse eMail/>
                int position_point = eMail.IndexOf(".");//<position du point dans l'adresse eMail/>                

                if (position_point == -1)
                {
                    Console.WriteLine("\nIl n'y a pas de point");
                    return false;
                }


                if (position_arobase == -1)
                {
                    Console.WriteLine("\nIl n'y a pas d'arobase");
                    return false;
                }

                else
                {

                    if (position_arobase < 2)
                    {

                        Console.WriteLine("\nL'erreur se trouve avant l'arobase");
                        return false;
                    }

                    if ((position_point - position_arobase) <= 2)
                    {

                        if (position_point > position_arobase)
                        {

                            Console.WriteLine("\nL'erreur se trouve entre l'arobase et le point");
                            return false;
                        }

                        else
                        {

                            Console.WriteLine("\nVeuillez vérifier la position du point");
                            return false;
                        } 

                    }

                    if ((eMail.Length - position_point) <= 2)
                    {
                        Console.WriteLine("\nL'erreur se trouve apres le point");
                        return false;
                    }
                }

                Console.WriteLine("\nEntrez une adresse e-mail");
                eMail = Console.ReadLine();

            }

            if (ReMail.IsMatch(eMail))
            {

                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nOK");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nAppuyez sur la touche ''Entrée'' pour sortir");
                return true;
            }

            return Regex.IsMatch(eMail, @"^[0-9a-zA-Z]+[-_.]?[0-9a-zA-Z]+@[a-zA-Z]{2,}\.[a-zA-Z]{2,}$");//retour de ma fonction

        }

        static void Main(string[] args)
        {
            //variable
            string eMail;//<l'email à taper/>

            //<saisie utilisateur/>          
            Console.WriteLine("\nVeuillez entrer une adresse eMail");
            eMail = Console.ReadLine();
            EmailValide(eMail);//<appel de ma methode/>

            //affichage
            Console.ReadLine();
        }
    }
}

