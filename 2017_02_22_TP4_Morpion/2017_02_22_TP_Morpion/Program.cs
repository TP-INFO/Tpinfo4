using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_02_22_TP_Morpion
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] morpion = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    morpion[i, j] = '0';
                    Console.Write("{0} | ", morpion[i,j]);
                }
                Console.WriteLine();
                Console.WriteLine("-----------");
            }
            Console.WriteLine("Veuillez indiquer 'x' ou 'o' svp!");
            char jeton = Convert.ToChar(Console.ReadLine());
            int nombreParties = 1;
            int abscisse = -1, ordonnee = -1;
            while (abscisse < 0 || abscisse > 2 || ordonnee < 0 || ordonnee > 2)
            {
                Console.WriteLine("Quelle sera la position de votre 'jeton' : abscisse puis ordonnee?");
                abscisse = Convert.ToInt32(Console.ReadLine());
                ordonnee = Convert.ToInt32(Console.ReadLine());
            }
            morpion[abscisse, ordonnee] = jeton;



            if (nombreParties%2==0)
            {
                jeton = 'o';

            }
        }

        static  int mouvementOrdi (int abscisse, int ordonnee)
        {
            
        }
    }
}
