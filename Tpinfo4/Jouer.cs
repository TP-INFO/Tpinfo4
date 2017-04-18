using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo4
{
	public class Jouer
	{

		static bool _userFirst = true;
		public static bool jouerCoupSuivant { get; set; }
		public static int nbreCoup { get; set; }

		public static void ChoisirJeton()
		{
			string userInput = "null";
			char _userInput = '0';
			char joueurCPC = '0';
			int countAquiLeTour = 2;  // boucle compteur décide 1er joueur selon pair/impair

			if (_userFirst) // si pair alors USER joue en 1er
			{
				do  // boucle de validation input 
				{
					Console.Write("Choisissez {0} ou {1}:", 'X', 'O');  // choix du jeton par USER
					userInput = Console.ReadLine().ToUpper();

					if (userInput == "X" || userInput == "O")
					{
						break;
					}
					else
					{
						Console.WriteLine("Tapez X ou O!");
					}
				} while (userInput != "X" || userInput != "O");
			}
			else
			{
				Random jetoncpc = new Random();  // tirage aléatoire du jeton par CPC
				int jetonCPC = jetoncpc.Next(1);
				if (jetonCPC == 0)
				{
					joueurCPC = 'X';
					Console.WriteLine("Le CPC joue avec X ");
					Console.WriteLine("Vous jouez avec O");
					_userInput = 'O';
				}
				else
				{
					joueurCPC = 'O';
					Console.WriteLine("Le CPC joue  avec O ");
					Console.WriteLine("Vous jouez avec X");
					_userInput = 'X';
				}
			}
			countAquiLeTour++;
			if (_userFirst)
			{
				DebuterAvecJoueur(userInput[0], joueurCPC);     // appel de la méthode Gameplay avec passage en parametre du jeton
			}
			else
			{
				DebuterAvecCPC(_userInput, joueurCPC);
			}

			DemanderRejouer();
		}

		public static void DebuterAvecJoueur(char userInputChar, char joueurCPC)
		{
			bool nouveauJeu = true;
			while (nouveauJeu)
			{
				char[,] matrice = new char[4, 4];
				nbreCoup = 0;
				jouerCoupSuivant = true;
				int PlaceDispo = 9;     // nbre de places dispo pour jouer à réduire à chaque coup

				#region Jouer Coup Suivant

				while (jouerCoupSuivant)        // boucle    de coup suivant
				{
					#region User joue

					//////////	entrée des input ligne/colonne par le USER pour placer son pion
					JouerAvecUser(userInputChar, matrice, PlaceDispo);
					#endregion


					#region CPC joue

					///////////////// CPC joue

					JouerAvecCPC(joueurCPC, matrice, PlaceDispo);

					#endregion

					AfficherMatrice(matrice);

					//calcul cas de victoire


					#region // Victoires USER
					CalculerVictoireUser(matrice);
					#endregion

					#region Victoires CPC
					CalculerVictoireCPC(matrice);

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
				#endregion

				DemanderRejouer();
			}
		}

		public static void DebuterAvecCPC(char userInputChar, char joueurCPC)
		{
			bool nouveauJeu = true;
			while (nouveauJeu)
			{
				char[,] matrice = new char[4, 4];
				nbreCoup = 0;
				jouerCoupSuivant = true;
				int PlaceDispo = 9;     // nbre de places dispo pour jouer à réduire à chaque coup

				#region Jouer Coup Suivant

				while (jouerCoupSuivant)        // boucle de coup suivant
				{

					#region CPC joue

					///////////////// CPC joue

					JouerAvecCPC(joueurCPC, matrice, PlaceDispo);

					#endregion

					AfficherMatrice(matrice);

					#region User joue

					//////////	entrée des input ligne/colonne par le USER pour placer son pion
					JouerAvecUser(userInputChar, matrice, PlaceDispo);
					#endregion

					AfficherMatrice(matrice);

					//calcul cas de victoire


					#region // Victoires USER
					CalculerVictoireUser(matrice);
					#endregion

					#region Victoires CPC
					CalculerVictoireCPC(matrice);

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
				#endregion

				DemanderRejouer();
			}
		}

		private static void JouerAvecUser(char userInputChar, char[,] matrice, int PlaceDispo)
		{
			if (PlaceDispo > 0)
			{
				// input ligne
				string input = "null";
				int chiffre1 = 0;
				bool repeat = true;
				do
				{
					try
					{
						do
						{
							Console.Write("Ligne > Entrez un chiffre entre 1 et 3: ");
							input = Console.ReadLine();
							chiffre1 = Convert.ToInt32(input);
							repeat = false;
						} while (chiffre1 < 1 || chiffre1 > 3);

					}
					catch (Exception)
					{
						Console.WriteLine("Rentrez un chiffre uniquement!!");
					}
				} while (repeat);


				//input colonne
				string input2 = "null";
				int chiffre2 = 0;
				bool repeat2 = true;
				do
				{
					try
					{
						do
						{
							Console.Write("Colonne > Entrez un chiffre entre 1 et 3: ");
							input2 = Console.ReadLine();
							chiffre2 = Convert.ToInt32(input2);
							repeat2 = false;
						} while (chiffre2 < 1 || chiffre2 > 3);
					}
					catch (Exception)
					{
						Console.WriteLine("Rentrez un chiffre uniquement!!");

					}
				} while (repeat2);


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
				matrice[chiffre1, chiffre2] = userInputChar;
				PlaceDispo--;
			}
			
		}

		private static void JouerAvecCPC(char joueurCPC, char[,] matrice, int PlaceDispo)
		{


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
				matrice[k, m] = joueurCPC;
				PlaceDispo--;
			}

		}

		private static void AfficherMatrice(char[,] matrice)
		{
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
		}

		private static void CalculerVictoireUser(char[,] matrice)
		{
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
		}

		private static void CalculerVictoireCPC(char[,] matrice)
		{
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
		}

		private static void DemanderRejouer()
		{
			// demande si nouvelle partie
			Console.WriteLine("Voulez-vous rejouer? O - encore / N - fin :");
			string nouvellePartie = Console.ReadLine().ToUpper();

			// boucle de test: jouer oui ou non by bool input
			bool inputTest2 = false; // correct input test en boucle
			while (!inputTest2)
			{
				if (nouvellePartie[0] == 'O')
				{
					Console.WriteLine("Alors on inverse qui commence!");

					inputTest2 = true;
					_userFirst = !_userFirst;
					ChoisirJeton();
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

		}

		private static void AfficherResultat(string gagnant)
		{
			Console.WriteLine("{0} gagne en {1} coups", gagnant, nbreCoup + 1);
			jouerCoupSuivant = false;
		}
	}
}
