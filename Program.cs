using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morpion_vendredi
  class Program
    {
        static void Main(string[] args)


        {

            int b; // afficher le premier nombre aletoire x ou o 
            int i = 0; //  compteur des ligne
            int j = 0;// compteur des colone 
            int l; // ligne choisit par l'ordi 
            int c; // colone  choisit par lordi 
            //char[,] Morpion = new char[3, 3]; // matrice du morpion 
            char choix = 'x'; // choix de l'utulisateur (lorsque c'est lui qui choisit ) 
            char jetonutulisateur = 'o';
            char jetonordinateur = 'x';
            bool bingo = false;
            //int placerestant = 9; 


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
         // donner un tour a chacun 
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            int parti = 0;           // variable parti qui s'incremente de 1 a chaque tour  pour  determiner si la partie est paire ou impaire 
            do
            {
                int placerestant = 9;    // place restant permet d'arreter le jeu si il reste plus de case vide 
                char[,] Morpion = new char[3, 3]; // matrice du morpion 
                if (parti % 2 == 0)    // si la partie est paire 

                {
                    ee: try

                    {
                        do
                        {
                            Console.WriteLine(" vous choisissez x ou o ");
                            choix = Convert.ToChar(Console.ReadLine());
                        }

                        while (choix != 'x' && choix != 'o');
                    }
                    catch (Exception e) 

                    {
                        Console.WriteLine(e.Message);
                        goto ee;
                    }

                    jetonutulisateur = choix;

                    if (jetonutulisateur == 'x')
                    {
                        jetonordinateur = 'o';
                    }
                   else { jetonordinateur = 'o' ;  jetonutulisateur = 'x';  }

                    Console.WriteLine("l'utulisateur : moi je choisit de jouer en {0} ", jetonutulisateur);
                    Console.WriteLine("l'ordinateur : Ok ! moi je prend les  {0} alors..mais la prochaine fois c'est moi qui choisit ", jetonordinateur);
                    Console.WriteLine("");

                }

                else
                {
                    Console.WriteLine("ordinateur : nouvelle parti!!  c'est moi qui commence !  ");

                    do
                    {
                        Random alea = new Random();    
                        b = alea.Next(110, 122);               // un systeme aleatoire permet de choisir x ou o  en passant par leur codes ascii 
                    }

                    while (b != 111 && b != 120);

                    char jeuordi = Convert.ToChar(b);

                    if (jeuordi == 'x')
                    {
                        jetonutulisateur = 'o';                     // les jeton doivent etre differents
                    }
                    if (jeuordi == 'o')
                    {
                        jetonutulisateur = 'x';
                    }
                    Console.WriteLine("********************************************************");
                    Console.WriteLine("ordinateur : je choisi de jouer les  {0} ", jeuordi);
                    Console.WriteLine("utulisateur : d'accord ! je prend les alors {0} ", jetonutulisateur);

                    jeuordi = jetonordinateur; 

                    ///// chacun a choisi c'est jeton /////////////////////////////////////////////
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // l'utulisteur choisi une position pour sont jeton (methode choix de position ) 
                if (placerestant > 0)
                {
                    do
                    {
                        ll: try
                        {
                            Console.WriteLine("choisissez la position de votre jeton ");

                            Console.WriteLine("ligne= ");
                            i = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("colone= ");
                            j = Convert.ToInt32(Console.ReadLine());

                            if (Morpion[i, j] != 'x' && Morpion[i, j] != 'o')
                            {
                                Morpion[i, j] = jetonutulisateur;
                                placerestant--;
                             
                            }

                            else
                            {
                                Console.WriteLine("ordinateur :  ah non ! mais cette case est deja occupé ");
                                goto ll;
                            }



                            for (i = 0; i < 3; i++)
                            {
                                for (j = 0; j < 3; j++)
                                {
                                    Console.Write("{0}", Morpion[i, j]);
                                }
                                Console.WriteLine();
                            }
                        }
                        catch (Exception k)
                        {

                            Console.WriteLine(k.Message);
                            goto ll;
                        }




                        //////////////// c'est a l'odi de placer sont jeton ////////////////

                        if (placerestant > 0)
                        {
                            dd: do
                            {


                                Random lig = new Random();
                                Random col = new Random();

                                c = lig.Next(0, 3);
                                l = col.Next(0, 3);

                            }

                            while (l != 0 && l != 1 && l != 2 && c != 0 && c != 1 && c != 2);

                            if (Morpion[l, c] != 'x' && Morpion[l, c] != 'o')
                            {
                                Morpion[l, c] = jetonordinateur;
                                placerestant--;

                                
                            }

                            else
                            {
                                goto dd;
                            }
                        }
                        else
                        {
                            Console.WriteLine("match null ");
                            break;
                        }


                        Console.WriteLine(" ordinateur : Ok! bien joué moi je joue les position :");
                        Console.WriteLine("");
                        Console.WriteLine(" la colone {0} et la ligne {1}  ", c, l);



                        for (i = 0; i < 3; i++)
                        {
                            for (j = 0; j < 3; j++)
                            {
                                Console.Write("{0}", Morpion[i, j]);
                            }
                            Console.WriteLine();
                        }

                        for (i = 0; i < 3; i++)
                        {

                            if (Morpion[i, 0] == Morpion[i, 1] && Morpion[i, 1] == Morpion[i, 2] && Morpion[i, 1] == 'o')
                            {
                                bingo = true;
                                Console.WriteLine("ok !! c'est une ligne ");
                                break;
                            }

                            if (Morpion[i, 0] == Morpion[i, 1] && Morpion[i, 1] == Morpion[i, 2] && Morpion[i, 1] == 'x')
                            {
                                bingo = true;
                                Console.WriteLine("ok !! c'est une ligne ");
                            }

                            if (Morpion[0, i] == Morpion[1, i] && Morpion[1, i] == Morpion[2, i] && Morpion[0, i] == 'o')
                            {
                                bingo = true;
                                Console.WriteLine("ok !! c'est une ligne ");
                            }

                            if (Morpion[0, i] == Morpion[1, i] && Morpion[1, i] == Morpion[2, i] && Morpion[0, i] == 'x')
                            {
                                bingo = true;
                                Console.WriteLine("ok !! c'est une ligne ");
                            }

                            if (Morpion[0, 0] == Morpion[1, 1] && Morpion[1, 1] == Morpion[2, 2] && Morpion[1, 1] == 'x')
                            {
                                bingo = true;
                                Console.WriteLine("ok !! c'est une ligne ");
                            }
                            if
                                    (Morpion[0, 2] == Morpion[1, 1] && Morpion[1, 1] == Morpion[2, 0] && Morpion[1, 1] == 'o')
                            {
                                bingo = true;
                                Console.WriteLine("ok !! c'est une ligne ");
                            }

                        }
                    }
                    while (bingo == false);
                    parti++;
                }
                else
                {
                    Console.WriteLine("match null" );
                    break; 
                }
            } 

            while (parti < 5);
        }

    }
}
