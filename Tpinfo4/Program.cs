using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo4
{
    class Program
    {
        static int[] score = new int[2];
        static void Main(string[] args)
        {
            Console.WriteLine("Début du jeu !");
            Console.WriteLine("Jouer en premier (O/N) ?");
            string reponse = Console.ReadLine();
            bool p = true;

            if (reponse == "O") p = true;
            else p = false;

            bool encore = true;

            while (encore == true)
            {
                string[] joueurs = joueurXO(p);
                jeu(joueurs[0], joueurs[1], p);
                Console.WriteLine("Jouer encore ? (O/N)");
                reponse = Console.ReadLine();
                if (reponse == "O")
                {
                    encore = true;
                    p = !p;
                }
                else break;
            }

        }

        static void jeu(string XO, string cXO, bool p)

        {
            string[,] grille = new string[3, 3];
            bool[] win = new bool[2];
            int k;

            // On remplit la grille vide.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grille[i, j] == null)
                    {
                        grille[i, j] = "-";
                    }
                }
            }

            //Lance la partie 
            do
            {

                if (p == true)
                {
                    coupj1(XO, grille);
                    affichageJeu(grille);
                    k = nbCoups(grille);
                    if (k == 9)
                    {
                        win = victoire(grille, XO, cXO);
                        break;
                    }
                    coupj2(cXO, grille);
                    affichageJeu(grille);
                }
                else
                {
                    coupj2(cXO, grille);
                    affichageJeu(grille);
                    k = nbCoups(grille);
                    if (k == 9)
                    {
                        win = victoire(grille, XO, cXO);
                        break;
                    }
                    coupj1(XO, grille);
                    affichageJeu(grille);
                }

                // test si victoire

                win = victoire(grille, XO, cXO);
                if (win[0] == true)
                {
                    affichageJeu(grille);
                    Console.WriteLine("Joueur 1 gagne la partie");
                    break;
                }
                if (win[1] == true)
                {
                    affichageJeu(grille);
                    Console.WriteLine("Joueur 2 gagne la partie");
                    break;
                }

                //test si la grille est complète ou non
                k = nbCoups(grille);

            }
            while (k < 9);

            //incrémentation du score
            score = scorePoints(win, score);
            Console.WriteLine("Le joueur 1 à {0} point(s)", score[0]);
            Console.WriteLine("Le joueur 2 à {0} point(s)", score[1]);
        }

        static void coupj1(string XO, string[,] grille)

        {
            bool valid = true;
            int x = 0, y = 0;

            do
            {

                Console.WriteLine("Où jouer le coup (0-2)(0-2)");
                x = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());
                if (grille[x, y] == "X" || grille[x, y] == "O")
                {
                    Console.WriteLine("Ce coup a déjà été joué.");
                    valid = false;
                }
                else
                {
                    grille[x, y] = XO;
                    break;
                }

            } while (valid == false);

        }

        static void coupj2(string cXO, string[,] grille)
        {
            bool valid = false;
            Random rand = new Random();
            int x = 0, y = 0;
            do
            {

                x = rand.Next(3);
                y = rand.Next(3);
                if (grille[x, y] == "X" || grille[x, y] == "O")
                {
                    valid = false;
                }
                else
                {
                    grille[x, y] = cXO;
                    valid = true;
                }
            } while (valid == false);

        }

        static bool[] victoire(string[,] grille, string XO, string cXO)
        {

            int compteur1 = 0, compteur2 = 0;
            bool p1win = false, p2win = false;
            //test sur les lignes
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grille[i, j] == XO) compteur1++;
                    else if (grille[i, j] == cXO) compteur2++;


                }
                if (compteur1 == 3)
                {
                    p1win = true;
                    break;
                }
                else if (compteur2 == 3)
                {
                    p2win = true;
                    break;
                }
                compteur1 = 0;
                compteur2 = 0;
            }

            //test sur les colonnes
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grille[j, i] == XO) compteur1++;
                    else if (grille[j, i] == cXO) compteur2++;


                }
                if (compteur1 == 3)
                {
                    p1win = true;
                    break;
                }
                else if (compteur2 == 3)
                {
                    p2win = true;
                    break;
                }
                compteur1 = 0;
                compteur2 = 0;
            }

            compteur1 = 0;
            compteur2 = 0;

            //test en diagonales
            for (int i = 0; i < 3; i++)
            {
                if (grille[i, i] == XO) compteur1++;
                else if (grille[i, i] == cXO) compteur2++;

                if (compteur1 == 3)
                {
                    p1win = true;
                }
                else if (compteur2 == 3)
                {
                    p2win = true;
                }
            }

            compteur1 = 0;
            compteur2 = 0;

            for (int i = 0; i < 3; i++)
            {

                if (grille[i, 2 - i] == XO) compteur1++;
                else if (grille[i, 2 - i] == cXO) compteur2++;

                if (compteur1 == 3)
                {
                    p1win = true;
                }
                else if (compteur2 == 3)
                {
                    p2win = true;
                }
            }

            bool[] victoire = { p1win, p2win };
            return victoire;


        }

        static int[] scorePoints(bool[] win, int[] score)
        {

            if (win[0] == true) score[0]++;
            else if (win[1] == true) score[1]++;
            return score;
        }

        static void affichageJeu(string[,] grille)
        {
            Console.WriteLine("***");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}", grille[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("***");
        }

        static string[] joueurXO(bool p)
        {
            //Si le joueur joue en premier : demande si joue avec X ou O. Si l'ordinateur joue en premier il prend au hasard X ou O.
            Random rand = new Random();
            int x = 0;
            string XO, cXO;

            if (p == true)
            {
                Console.WriteLine("Jouer avec X ou O");
                XO = Console.ReadLine();
                if (XO == "X") cXO = "O";
                else cXO = "X";
            }
            else
            {
                x = rand.Next(2);
                if (x == 0)
                {
                    cXO = "X";
                    XO = "O";
                }
                else
                {
                    cXO = "O";
                    XO = "X";
                }
            }

            string[] joueurs = { XO, cXO };
            return joueurs;

        }

        static int nbCoups(string[,] grille)
        {
            int k = 0;
            foreach (var item in grille)
            {
                if (item != "-")
                {
                    k++;
                }
            }
            return k;
        }
    }
}
