using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo4
{
    class Program
    {
        static void Main(string[] args)
        {

            JouerMorpion();
        }

        /// <summary>
        /// Méthode constituée d'autres méthodes.
        /// </summary>
        public static void JouerMorpion()
        {
            // instanciation du plateau de jeu et affectation des cases avec le char ' '.
            char[,] TabMorp = new char[3, 3];
            for (int i = 0; i < TabMorp.GetLength(0); i++)
            {
                for (int j = 0; j < TabMorp.GetLength(1); j++)
                {
                    TabMorp[i, j] = '=';
                }
            }
            char monJeton = 'x';
            char ordinateurJeton = '0';
            short nbParties = 0;

            AfficherTableau(TabMorp);

            // Choix du jeton.
            Console.WriteLine("Sélectionnez votre jeton : 'x' ou 'o'");
            char jeton = Convert.ToChar(Console.ReadLine());


            switch (jeton)
            {
                case 'x':
                    monJeton = jeton;
                    ordinateurJeton = 'o';
                    break;
                case 'o':
                    monJeton = jeton;
                    ordinateurJeton = 'x';
                    break;
                default:
                    break;
            }
            // Placement des jetons par le joueur et l'ordinateur.... pour l'instant.
            do
            {
                Console.WriteLine("Placez votre jeton (Coordonnées entre 0,0 et 2,2");
                Console.WriteLine();
                short placementA = Convert.ToInt16(Console.ReadLine());
                short placementO = Convert.ToInt16(Console.ReadLine());
                if (TabMorp[placementA, placementO] == '=')
                {
                    TabMorp[placementA, placementO] = monJeton;
                    AfficherTableau(TabMorp);
                }
                else
                {
                    Console.WriteLine("Cette case est déjà occupée, rejouez.");
                }
                // ** TODO le test de la ligne - Méthode à placer.
                Random rdn = new Random();
                int placementOrdiA = rdn.Next(0, 2);
                int placementOrdiB = rdn.Next(0, 2);
                if (TabMorp[placementOrdiA, placementOrdiB] == '=')
                {
                    TabMorp[placementOrdiA, placementOrdiB] = ordinateurJeton;
                    AfficherTableau(TabMorp);
                }

            } while (true);
        }


            public static void AfficherTableau(char[,] TabMorp)
            {
                for (int i = 0; i < TabMorp.GetLength(0); i++)
                {
                    for (int j = 0; j < TabMorp.GetLength(1); j++)
                    {

                        Console.Write(TabMorp[i, j]);
                    }
                    Console.WriteLine();
                }
            }

        }
        
    
    }
       




