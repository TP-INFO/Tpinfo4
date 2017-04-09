using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo4
{
	public class Jouer
	{
		public static void ChoisirJeton()
		{
			while (true)  // boucle de traitement erreur de frappe
			{
				Console.Write("Choisissez {0} ou {1}:", 'X', 'O');
				string userInput = Console.ReadLine().ToUpper();

				if (userInput == "X" || userInput == "O")
				{
					GamePlay(userInput[0]);     // appel de la méthode Gameplay avec passage en parametre du jeton
				}
				else
				{
					Console.WriteLine("Tapez X ou O!");
				}
			}
		}

		/// <summary>
		/// méthode établissant les coups des joueurs
		/// </summary>
		/// <param name="z"></param>
		/// 

		public static bool jouerCoupSuivant { get; set; }
		public static int nbreCoup { get; set; }

		public static void GamePlay(char z)
		{
			bool nouveauJeu = true;
			while (nouveauJeu)
			{

				char[,] matrice = new char[4, 4];
				nbreCoup = 0;
				jouerCoupSuivant = true;
				int PlaceDispo = 9;     // nbre de places dispo pour jouer à réduire à chaque coup

				while (jouerCoupSuivant)        // boucle de coup suivant
				{
					#region User joue

					//////////	entrée des input ligne/colonne par le USER pour placer son pion
					if (PlaceDispo > 0)
					{
						// input ligne

						Console.Write("Ligne > Entrez un chiffre entre 1 et 3: ");
						string input = Console.ReadLine();
						int chiffre1 = Convert.ToInt32(input);

						//input colonne
						Console.Write("Colonne > Entrez un chiffre entre 1 et 3: ");
						string input2 = Console.ReadLine();
						int chiffre2 = Convert.ToInt32(input2);

						// pour éviter de rejouer sur une case déjà occupée (donc != 0)
						while (matrice[chiffre1, chiffre2] != 0)
						{
							Console.WriteLine("Cette case est déjà prise!");

							// input ligne
							Console.Write("Ligne > Entrez un chiffre entre 1 et 3: ");
							input = Console.ReadLine();
							chiffre1 = Convert.ToInt32(input);

							// input colonne
							Console.Write("Colonne > Entrez un chiffre entre 1 et 3: ");
							input2 = Console.ReadLine();
							chiffre2 = Convert.ToInt32(input2);
						}
						matrice[chiffre1, chiffre2] = 'X';
						PlaceDispo--;
					}
					#endregion


					#region CPC joue

					///////////////// CPC joue

					Random rnd = new Random();
					int k = rnd.Next(1, 4);
					int m = rnd.Next(1, 4);

					if (PlaceDispo > 0)
					{
						while (matrice[k, m] != 0)
						{
							k = rnd.Next(1, 4);
							m = rnd.Next(1, 4);
						}
						matrice[k, m] = 'O';
						PlaceDispo--;
					}
					#endregion

					// affichage de la matrice
					for (int i = 0; i < matrice.GetLength(0); i++)
					{
						for (int j = 0; j < matrice.GetLength(1); j++)
						{
							//matrice[i, j] = z;
							matrice[0, 0] = '_';
							matrice[0, 1] = '1';
							matrice[0, 2] = '2';
							matrice[0, 3] = '3';

							matrice[0, 0] = '_';
							matrice[1, 0] = '1';
							matrice[2, 0] = '2';
							matrice[3, 0] = '3';
							Console.Write(matrice[i, j]);
						}
						Console.WriteLine();
					}

					//calcul cas de victoire


					#region // Victoires USER
					/////////////////////////////// VICTOIRES USER
					// victoirez horizontalez
					if (((matrice[1, 1] == 'X') && (matrice[1, 2] == 'X') && (matrice[1, 3] == 'X')) || ((matrice[2, 1] == 'X') && (matrice[2, 2] == 'X') && (matrice[2, 3] == 'X')) || ((matrice[3, 1] == 'X') && (matrice[3, 2] == 'X') && (matrice[3, 3] == 'X')))
					{
						string gagnant = "USER";
						AfficherResultat(gagnant);
					}
					// victoires verticales
					else if (((matrice[1, 1] == 'X') && (matrice[2, 1] == 'X') && (matrice[3, 1] == 'X')) || ((matrice[1, 2] == 'X') && (matrice[2, 2] == 'X') && (matrice[3, 2] == 'X')) || ((matrice[1, 3] == 'X') && (matrice[2, 3] == 'X') && (matrice[3, 3] == 'X')))
					{
						string gagnant = "USER";
						AfficherResultat(gagnant);
					}
					// victoires en diagonale
					else if ((matrice[1, 1] == 'X') && (matrice[2, 2] == 'X') && (matrice[3, 3] == 'X') || (matrice[1, 3] == 'X') && (matrice[2, 2] == 'X') && (matrice[3, 1] == 'X'))
					{
						string gagnant = "USER";
						AfficherResultat(gagnant);
					}
					#endregion

					#region Victoires CPC
					//////////////////////////////////// VICTOIRES CPC
					// horizontales
					if (((matrice[1, 1] == 'O') && (matrice[1, 2] == 'O') && (matrice[1, 3] == 'O')) || ((matrice[2, 1] == 'O') && (matrice[2, 2] == 'O') && (matrice[2, 3] == 'O')) || ((matrice[3, 1] == 'O') && (matrice[3, 2] == 'O') && (matrice[3, 3] == 'O')))
					{
						string gagnant = "CPC";
						AfficherResultat(gagnant);
					}
					// verticales
					if (((matrice[1, 1] == 'O') && (matrice[2, 1] == 'O') && (matrice[3, 1] == 'O')) || ((matrice[1, 2] == 'O') && (matrice[2, 2] == 'O') && (matrice[3, 2] == 'O')) || ((matrice[1, 3] == 'O') && (matrice[2, 3] == 'O') && (matrice[3, 3] == 'O')))
					{
						string gagnant = "CPC";
						AfficherResultat(gagnant);
					}

					// diagonales
					else if ((matrice[1, 1] == 'O') && (matrice[2, 2] == 'O') && (matrice[3, 3] == 'O') || (matrice[1, 3] == 'O') && (matrice[2, 2] == 'O') && (matrice[3, 1] == 'O'))
					{
						string gagnant = "CPC";
						AfficherResultat(gagnant);
					}

					#endregion
					nbreCoup++;

					#region Match nul
					// cas match nul
					if (PlaceDispo == 0)
					{
						Console.WriteLine("Match nul!");
						break;
					}
					#endregion
				}

				// demande si nouvelle partie
				Console.WriteLine("Voulez-vous rejouer? O - encore / N - fin :");
				string nouvellePartie = Console.ReadLine().ToUpper();

				// boucle de test: jouer oui ou non by bool input
				bool inputTest2 = false; // correct input test en boucle
				while (!inputTest2)
				{
					if (nouvellePartie[0] == 'O')
					{
						Console.WriteLine("Alors c'est moi qui commence");
						inputTest2 = true;
					}
					else if (nouvellePartie[0] == 'N')  // si non alors exit du programme
					{
						Console.WriteLine("A la prochaine fois!");
						Console.Read();
						System.Environment.Exit(0);
					}
					else
					{
						Console.WriteLine("Tapez O pour oui, ou N pour non!");
						inputTest2 = false;  // redemande correct input
					}
				}
				nouveauJeu = true;  // novelle partie OK
			}
		}


		/// <summary>
		/// Méthode affichage du gagnant
		/// </summary>
		/// <param name="gagnant"></param>
		public static void AfficherResultat(string gagnant)
		{
			Console.WriteLine("{0} gagne en {1} coups", gagnant, nbreCoup + 1);
			jouerCoupSuivant = false;
		}
	}
}
