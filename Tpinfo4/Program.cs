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
            char continu = 'O';
            int nombreParties = 0;
            int partiesGagneesJoueur = 0, partiesGagneesOrdi = 0;
            Console.WriteLine("Veuillez indiquer votre premier jeton : 'x' ou 'o'!");
            char premierJetonJoueur = Convert.ToChar(Console.ReadLine()), jetonOrdi;
            while (continu == 'O')
            {
                nombreParties++;
                char jetonJoueur = JetonJoueur(nombreParties, premierJetonJoueur);
                char[,] morpion = new char[3, 3];
                Console.WriteLine("---------------");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        morpion[i, j] = '0';
                        Console.Write("| {0} |", morpion[i, j]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("---------------");
                }
                Console.WriteLine();
                if(jetonJoueur=='o')
                {
                    jetonOrdi = 'x';
                }
                else
                {
                    jetonOrdi = 'o';
                }
                int abscisse = -1, ordonnee = -1,  coups=0;
                bool gagne = false;
                string joueurGagnant = null, joueurDebutant=JoueurDebutant(nombreParties);
                while (!gagne)
                {
                    if ((coups % 2 == 0 && joueurDebutant=="joueur") || (coups % 2 ==1 && joueurDebutant=="ordi"))
                    {
                        Console.WriteLine("Rentrez la ligne (vers le bas) puis la colonne (vers la droite) de votre prochain pion!");
                        abscisse = Convert.ToInt32(Console.ReadLine());
                        ordonnee = Convert.ToInt32(Console.ReadLine());

                        while (!PlacementPossible(abscisse, ordonnee, morpion))
                        {
                            int[] placementPion = PlacementJoueur(abscisse, ordonnee);
                            abscisse = placementPion[0];
                            ordonnee = placementPion[1];
                        }
                        morpion = MorpionModifie(abscisse, ordonnee, morpion, jetonJoueur);
                        coups++;
                        Console.WriteLine("---------------");
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                Console.Write("| {0} |", morpion[i, j]);
                            }
                            Console.WriteLine();
                            Console.WriteLine("---------------");
                        }
                        Console.WriteLine();
                        gagne = Gagne(morpion);
                    }
                    else if ((coups%2==1 && joueurDebutant == "joueur") || (coups%2==0 && joueurDebutant == "ordi"))
                    {
                        int[] placementOrdi = PlacementOrdi();
                        abscisse = placementOrdi[0];
                        ordonnee = placementOrdi[1];
                        while (!PlacementPossible(abscisse, ordonnee, morpion))
                        {
                            placementOrdi = PlacementOrdi();
                            abscisse = placementOrdi[0];
                            ordonnee = placementOrdi[1];
                        }
                        morpion = MorpionModifie(abscisse, ordonnee, morpion, jetonOrdi);
                        coups++;
                        Console.WriteLine("---------------");
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                Console.Write("| {0} |", morpion[i, j]);
                            }
                            Console.WriteLine();
                            Console.WriteLine("---------------");
                        }
                        gagne = Gagne(morpion);
                    }
                }
                joueurGagnant = JoueurGagnant(coups, nombreParties);
                if (joueurGagnant == "joueur")
                {
                    partiesGagneesJoueur++;
                    Console.WriteLine("Joueur a gagné {0} parties et ordi {1} parties", partiesGagneesJoueur, partiesGagneesOrdi);
                    Console.WriteLine("Voulez-vous jouer une autre partie? (O/N)");
                    continu = Convert.ToChar(Console.ReadLine());

                }
                else if (joueurGagnant == "ordi")
                {
                    partiesGagneesOrdi++;
                    Console.WriteLine("Joueur a gagné {0} parties et ordi {1} parties", partiesGagneesJoueur, partiesGagneesOrdi);
                    Console.WriteLine("Voulez-vous jouer une autre partie? (O/N)");
                    continu = Convert.ToChar(Console.ReadLine());

                }
            }

        }

        /// <summary>
        /// Méthode renvoyant le tableau des coordonnées du placement de l'ordinateur
        /// </summary>
        /// <returns></returns>
        static int[] PlacementOrdi()
        {
            Random random1 = new Random();
            int abscisse = random1.Next(3);
            Random random2 = new Random();
            int ordonnee = random2.Next(3);
            int[] placement =  {abscisse, ordonnee};
            return placement;
        }

        /// <summary>
        /// Méthode renvoyant un tableau contenant les coordonnees du placement du joueur
        /// </summary>
        /// <param name="abscisse"></param>
        /// <param name="ordonnee"></param>
        /// <returns></returns>
        static int[] PlacementJoueur(int abscisse, int ordonnee)
        {
            int[] placement = { abscisse, ordonnee };
            if ((abscisse < 0 || abscisse > 2) && (ordonnee < 0 || ordonnee > 2))
            {
                Console.WriteLine("Veuillez rentrer une abscisse et une ordonnee correcte");
                abscisse = Convert.ToInt32(Console.ReadLine());
                ordonnee = Convert.ToInt32(Console.ReadLine());
                placement = PlacementJoueur(abscisse, ordonnee);
                return placement;
            }
            else
            {
                
                return placement;
            }
        }

        /// <summary>
        /// Méthode renvoyant le morpion modifié après coup
        /// </summary>
        /// <param name="abscisse"></param>
        /// <param name="ordonnee"></param>
        /// <param name="morpion"></param>
        /// <param name="jeton"></param>
        /// <returns></returns>
        static char[,] MorpionModifie (int abscisse, int ordonnee, char[,] morpion, char jeton)
        {
            morpion[abscisse, ordonnee] = jeton;
            return morpion;
        }

        /// <summary>
        /// Méthode statique renvoyant true si le placement est possible (case non occupée par un jeton) ou false si non
        /// </summary>
        /// <param name="abscisse"></param>
        /// <param name="ordonnee"></param>
        /// <param name="morpion"></param>
        /// <returns></returns>
        static bool PlacementPossible (int abscisse, int ordonnee, char[,] morpion)
        {
            if (morpion[abscisse, ordonnee]=='0')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Méthode statique renvoyant un booléen : true si un joueur a gagné, false si le jeu continue
        /// </summary>
        /// <param name="morpion"></param>
        /// <returns></returns>
        static bool Gagne (char[,] morpion)
        {
            bool gagne = false;

            //On détermine si une ligne est gagnante
            for (int i = 0; i < 3; i++)
            {
                if (morpion[i, 0] == morpion[i, 1] && morpion[i, 1] == morpion[i, 2] && morpion[i,1]!='0')
                {
                    gagne = true;
                }
            }

            //On détermine si une colonne est gagnante
            for (int j = 0; j < 3; j++)
            {
                if (morpion[0, j] == morpion[1, j] && morpion[1, j] == morpion[2, j] && morpion[1, j] != '0')
                {
                    gagne = true;
                }
            }

            //On détermine si une diagonale est gagnante
            if ((morpion[0,0]==morpion[1,1] && morpion[1,1]==morpion[2,2]) || (morpion[2, 0] == morpion[1, 1] && morpion[1, 1] == morpion[0, 2]) && morpion[1,1]!='0')
            {
                gagne = true;
            }

            return gagne;
        }

        /// <summary>
        /// Méthode statique renvoyant un string indiquant le gagnant de la partie
        /// </summary>
        /// <param name="nombreCoups"></param>
        /// <param name="nombreParties"></param>
        /// <returns></returns>
        static string JoueurGagnant(int nombreCoups, int nombreParties)
        {
            string joueurGagnant = "ordi";
            if((nombreParties%2==1 && nombreCoups%2==1)||(nombreParties % 2 == 0 && nombreCoups % 2 == 0))
            {
                joueurGagnant = "joueur";
            }
            return joueurGagnant;
        }
        
        /// <summary>
        /// Méthode statique déterminant le jeton du joueur pour la partie en cours
        /// </summary>
        /// <param name="nombreParties"></param>
        /// <param name="premierJeton"></param>
        /// <returns></returns>
        static char JetonJoueur (int nombreParties, char premierJeton)
        {
            char jetonJoueur;
            if (nombreParties%2==1)
            {
                jetonJoueur = premierJeton;
            }
            else if (nombreParties%2==0 && premierJeton=='o')
            {
                jetonJoueur = 'x';
            }
            else
            {
                jetonJoueur = 'o';
            }
            return jetonJoueur;
        }

        /// <summary>
        /// Méthode statique renvoyant un string qui indique le joueur débutant en fonction du nombre de parties
        /// </summary>
        /// <param name="nombreParties"></param>
        /// <returns></returns>
        static string JoueurDebutant(int nombreParties)
        {
            string joueurDebutant;
            if (nombreParties%2==1)
            {
                joueurDebutant = "joueur";
            }
            else
            {
                joueurDebutant = "ordi";
            }
            return joueurDebutant;
        }
    }
}
