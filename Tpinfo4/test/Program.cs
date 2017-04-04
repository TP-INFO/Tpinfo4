using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Teste aligement
            //Colonnes
            for (int i = 0; i <= 2; i++)
            {
                if ((TabMorp[i, 0] == TabMorp[i, 1]) && (TabMorp[i, 1] == TabMorp[i, 2]) && (TabMorp[i, 1] != '='))
                {
                    Console.WriteLine("GAGNE !!!!!");
                    break;
                }
            }
            //Lignes
            for (int j = 0; j <= 2; j++)
            {
                if ((TabMorp[j, 0] == TabMorp[j, 1]) && (TabMorp[j, 1] == TabMorp[j, 2]) && (TabMorp[j, 1] != '='))
                {
                    Console.WriteLine("GAGNE !!!!!");
                    break;
                }
            }

            int k = 0;
            if ((TabMorp[k, 0] == TabMorp[k + 1, 1]) && (TabMorp[k + 1, 1] == TabMorp[k + 2, 2]) && (TabMorp[k + 1, 1] != '='))
            {
                Console.WriteLine("GAGNE !!!!!");
                break;
            }
            int l = 2;
            if ((TabMorp[0, l] == TabMorp[1, l - 1]) && (TabMorp[1, l - 1] == TabMorp[2, l - 2]) && (TabMorp[1, l - 2] != '='))
            {
                Console.WriteLine("GAGNE !!!!!");
                break;
            }
        }
        // méthode gagné monJeton.
       // Teste aligement Joueur
                //Colonnes
                for (int i = 0; i <= 2; i++)
                {
                    if ((TabMorp[i, 0] == monJeton) && (TabMorp[i, 1] == monJeton) && (TabMorp[i, 2] == monJeton))
                    {
                        Console.WriteLine("GAGNE !!!!!");
                        break;
                    }
}
                //Lignes
                for (int j = 0; j <= 2; j++)
                {
                    if ((TabMorp[0, j] == monJeton) && (TabMorp[1, j] == monJeton) && (TabMorp[2, j] == monJeton))
                    {
                        Console.WriteLine("GAGNE !!!!!");
                        break;
                    }
                }
                // Diagonale négative
                int k = 0;
                if ((TabMorp[k, 0] == monJeton) && (TabMorp[k + 1, 1] == monJeton) && (TabMorp[k + 2, 2] == monJeton))
                {
                    Console.WriteLine("GAGNE !!!!!");
                    break;
                }
                //Diagonale positive
                int l = 2;
                if ((TabMorp[l, 0] == monJeton) && (TabMorp[l - 1, 1] == monJeton) && (TabMorp[l - 2, 2] == monJeton))
                {
                    Console.WriteLine("GAGNE !!!!!");
                    break;
                }
    
    }
}
