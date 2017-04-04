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
            string resultat = "null";
            short scoreJoueur = 0;
            short scoreOrdinateur = 0;

            AfficherTableau(TabMorp);

            // Choix du jeton.
            Console.WriteLine("Sélectionnez votre jeton : 'x' ou 'o'");
            char jeton = Convert.ToChar(Console.ReadLine());


            switch (jeton)
            {
                case 'x':
                    monJeton = jeton;
                    ordinateurJeton = 'o';
                    Console.WriteLine("La partie commence !");
                    break;
                case 'o':
                    monJeton = jeton;
                    ordinateurJeton = 'x';
                    Console.WriteLine("La partie commence !");
                    break;
                default:
                    break;
            }

            Console.WriteLine("Tapez o pour commencer. Une autre touche laissera l'ordinateur débuter");
            char joueurCommence = Convert.ToChar(Console.ReadLine());
            // Placement des jetons par le joueur et l'ordinateur.... pour l'instant.
            bool gagne = false;
            while (true)               
            {
                if (joueurCommence == 'o')
                {
                    TourJoueur(TabMorp, monJeton);
                    TestLigneJoueur(TabMorp, monJeton, ref resultat);
                    if (resultat == "gagne")
                    {
                        scoreJoueur++;
                        Console.WriteLine("Vous : "+scoreJoueur+ " La machine : " +scoreOrdinateur);
                        Console.WriteLine("Voulez-vous recommencer ? ");
                        break;
                    }
                    TourOrdinateur(TabMorp, ordinateurJeton);
                    TestLigneOrdinateur(TabMorp, ordinateurJeton, ref resultat);
                    if (resultat == "perdu")
                    {
                        scoreOrdinateur++;
                        Console.WriteLine("Vous : " + scoreJoueur + " La machine : " + scoreOrdinateur);
                        Console.WriteLine("Voulez-vous recommencer ? ");
                        break;
                    }
                }
                else
                {
                    TourOrdinateur(TabMorp, ordinateurJeton);
                    TestLigneOrdinateur(TabMorp, ordinateurJeton, ref resultat);
                    if (resultat == "perdu")
                    {
                        scoreOrdinateur++;
                        Console.WriteLine("Vous : " + scoreJoueur + " La machine : " + scoreOrdinateur);
                        Console.WriteLine("Voulez-vous recommencer ? ");
                        break;
                    }
                    TourJoueur(TabMorp, monJeton);
                    TestLigneJoueur(TabMorp, monJeton, ref resultat);
                    if (resultat == "gagne")
                    {
                        scoreJoueur++;
                        Console.WriteLine("Vous : " + scoreJoueur + " La machine : " + scoreOrdinateur);
                        Console.WriteLine("Voulez-vous recommencer ? ");
                        break;
                    }
                 }                       
            } 
        }

        /// <summary>
        /// Affiche le plateau de jeu qui se rempli au fur et à mesure du jeu.
        /// </summary>
        /// <param name="TabMorp"></param>
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
        /// <summary>
        /// Tour de jeu du joueur.
        /// Teste l'emplacement d'une case avant de jouer.
        /// </summary>
        /// <param name="TabMorp"></param>
        /// <param name="monJeton"></param>
        static void TourJoueur(char[,] TabMorp, char monJeton)
        {
            do
            {
                Console.WriteLine("Placez votre jeton (Coordonnées entre 0,0 et 2,2");
                Console.WriteLine();
                short placementA = Convert.ToInt16(Console.ReadLine());
                short placementO = Convert.ToInt16(Console.ReadLine());
                if (TabMorp[placementA, placementO] == '=')
                {
                    TabMorp[placementA, placementO] = monJeton;
                    Console.WriteLine("Votre tour");
                    AfficherTableau(TabMorp);
                    break;
                }
                else
                {
                    Console.WriteLine("Cette case est déjà occupée, rejouez.");

                }
            } while (true);
        }

        /// <summary>
        /// Tour de jeu de l'ordinateur.
        /// Test si un emplacement est pris avant de joueur.
        /// </summary>
        /// <param name="TabMorp"></param>
        /// <param name="ordinateurJeton"></param>
        private static void TourOrdinateur(char[,] TabMorp, char ordinateurJeton)
        {
            do
            {
                Random rdn = new Random();
                int placementOrdiA = rdn.Next(0, 3);
                int placementOrdiB = rdn.Next(0, 3);
                if (TabMorp[placementOrdiA, placementOrdiB] == '=')
                {
                    TabMorp[placementOrdiA, placementOrdiB] = ordinateurJeton;
                    Console.WriteLine("Tour de l'ordinateur");
                    AfficherTableau(TabMorp);
                    break;
                }
            } while (true);
        }


        /// <summary>
        /// Test d'alignement pour l'ordinateur.
        /// Selon les lignes, les colonnes et les diagonales.
        /// Si l'ordinateur gagne, il affichera PERDU !!!!.
        /// </summary>
        /// <param name="TabMorp"></param>
        /// <param name="ordinateurJeton"></param>
        /// <param name="gagne"></param>
        private static void TestLigneOrdinateur(char[,] TabMorp, char ordinateurJeton, ref string resultat)
        {
            // Teste aligement ordinateur
            //Lignes
            for (int i = 0; i <= 2; i++)
            {
                if ((TabMorp[i, 0] == ordinateurJeton) && (TabMorp[i, 1] == ordinateurJeton) && (TabMorp[i, 2] == ordinateurJeton))
                {
                    Console.WriteLine("PERDU !!!!!");
                    resultat = "perdu";
                    

                }
            }
            //Colonnes
            for (int j = 0; j <= 2; j++)
            {
                if ((TabMorp[0, j] == ordinateurJeton) && (TabMorp[1, j] == ordinateurJeton) && (TabMorp[2, j] == ordinateurJeton))
                {
                    Console.WriteLine("PERDU !!!!!");
                    resultat = "perdu";
                }
            }
            // Diagonale négative
            int k = 0;
            if ((TabMorp[k, 0] == ordinateurJeton) && (TabMorp[k + 1, 1] == ordinateurJeton) && (TabMorp[k + 2, 2] == ordinateurJeton))
            {
                Console.WriteLine("PERDU !!!!!");
                resultat = "perdu";
            }
            //Diagonale positive
            int l = 2;
            if ((TabMorp[l, 0] == ordinateurJeton) && (TabMorp[l - 1, 1] == ordinateurJeton) && (TabMorp[l - 2, 2] == ordinateurJeton))
            {
                Console.WriteLine("PERDU !!!!!");
                resultat = "perdu";
            }
        }
               

        /// <summary>
        /// Test d'alignement pour le joueur.
        /// Selon les lignes, les colonnes et les diagonales.
        /// Si le joueur gagne, il affichera GAGNE !!!!.
        /// </summary>
        /// <param name="TabMorp"></param>
        /// <param name="monJeton"></param>
        /// <param name="gagne"></param>
        private static void TestLigneJoueur(char[,] TabMorp, char monJeton, ref string resultat)
        {
            // Teste aligement Joueur
            //Lignes
            for (int i = 0; i <= 2; i++)
            {
                if ((TabMorp[i, 0] == monJeton) && (TabMorp[i, 1] == monJeton) && (TabMorp[i, 2] == monJeton))
                {
                    Console.WriteLine("GAGNE !!!!!");
                    resultat = "gagne";

                }
            }
            //Colonnes
            for (int j = 0; j <= 2; j++)
            {
                if ((TabMorp[0, j] == monJeton) && (TabMorp[1, j] == monJeton) && (TabMorp[2, j] == monJeton))
                {
                    Console.WriteLine("GAGNE !!!!!");
                    resultat = "gagne";

                }
            }
            // Diagonale négative
            int k = 0;
            if ((TabMorp[k, 0] == monJeton) && (TabMorp[k + 1, 1] == monJeton) && (TabMorp[k + 2, 2] == monJeton))
            {
                Console.WriteLine("GAGNE !!!!!");
                resultat = "gagne";
            }
            //Diagonale positive
            int l = 2;
            if ((TabMorp[l, 0] == monJeton) && (TabMorp[l - 1, 1] == monJeton) && (TabMorp[l - 2, 2] == monJeton))
            {
                Console.WriteLine("GAGNE !!!!!");
                resultat = "gagne";
            }
        }
        

    }
        
    
 }
       




