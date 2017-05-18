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
			string userInput = "null";
			char joueurCPC = 'X';
			int countAquiLeTour = 0;
			bool ContinueraJouer = true;

			do
			{
				if ((countAquiLeTour % 2) == 0)
				{
					do  // boucle de validation input 
					{
						Console.Write("Choisissez {0} ou {1}:", 'X', 'O');
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

					if (userInput == "X")
					{
						joueurCPC = 'O';
					}
					else
					{
						joueurCPC = 'X';
					}
				}
				else
				{
					Random jetoncpc = new Random();
					int jetonCPC = jetoncpc.Next(2);
					if (jetonCPC == 0)
					{
						joueurCPC = 'X';
						userInput = "O";
						Console.WriteLine("Le CPC joue avec X ");
					}
					else
					{
						joueurCPC = 'O';
						userInput = "X";
						Console.WriteLine("Le CPC joue  avec O ");
					}
				}

				GamePlay(userInput[0], joueurCPC);     // appel de la méthode Gameplay avec passage en parametre du jeton

				// demande si nouvelle partie à jouer


				Console.WriteLine("Voulez-vous rejouer? O - encore / N - fin :");
				string nouvellePartie = Console.ReadLine().ToUpper();

				// boucle de test: jouer oui ou non by bool input
				bool inputTest2 = false; // correct input test en boucle
				countAquiLeTour++;
				while (!inputTest2)
				{
					if (nouvellePartie[0] == 'O')
					{
						if ((countAquiLeTour % 2) == 0)
						{
							Console.WriteLine("Alors c'est vous qui commencez!");
						}
						else
						{
							Console.WriteLine("Alors c'est moi qui commence!");
						}

						inputTest2 = true;
					}
					else if (nouvellePartie[0] == 'N')  // si non alors exit du programme
					{
						Console.WriteLine("Vous avez jouer {0} partie(s)", countAquiLeTour);
						Console.WriteLine("A la prochaine fois!");
						ContinueraJouer = false;
						break;
					}
					else
					{
						Console.WriteLine("Tapez O pour oui, ou N pour non!");
						inputTest2 = false;  // redemande correct input
					}
				}

			} while (ContinueraJouer);
			Console.WriteLine("Merci et au revoir.");
			Console.Read();


		}

		/// <summary>
		/// méthode établissant les coups des joueurs
		/// </summary>
		/// <param name="z"></param>
		/// 

		public static bool jouerCoupSuivant { get; set; }
		public static int nbreCoup { get; set; }

		public static void GamePlay(char userInputChar, char joueurCPC)
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
						//int chiffre1 = Convert.ToInt32(input);
						int chiffre1;

						while (!int.TryParse(input, out chiffre1))
						{
							Console.WriteLine("Tapez un CHIFFRE");
							input = Console.ReadLine();
						}

						//input colonne
						Console.Write("Colonne > Entrez un chiffre entre 1 et 3: ");
						string input2 = Console.ReadLine();
						int chiffre2;
						while (!int.TryParse(input2, out chiffre2))
						{
							Console.WriteLine("Tapez un CHIFFRE");
							input2 = Console.ReadLine();
						}

						// pour éviter de rejouer sur une case déjà occupée (donc != 0)
						while (matrice[chiffre1, chiffre2] != 0)
						{
							Console.WriteLine("Cette case est déjà prise!");

							// input ligne
							Console.Write("Ligne > Entrez un chiffre entre 1 et 3: ");
							input = Console.ReadLine();
							//chiffre1 = Convert.ToInt32(input);
							while (!int.TryParse(input, out chiffre1))
							{
								Console.WriteLine("Tapez un CHIFFRE");
								input = Console.ReadLine();
							}


							// input colonne
							Console.Write("Colonne > Entrez un chiffre entre 1 et 3: ");
							input2 = Console.ReadLine();
							//chiffre2 = Convert.ToInt32(input2);
							while (!int.TryParse(input2, out chiffre2))
							{
								Console.WriteLine("Tapez un CHIFFRE");
								input2 = Console.ReadLine();
							}
						}
						matrice[chiffre1, chiffre2] = userInputChar;
						PlaceDispo--;
					}

					else if (PlaceDispo < 1)
					{
						Console.WriteLine("Bien joué! C'est un match nul!");
						break;
					}


					#endregion


					#region CPC joue

					///////////////// CPC joue


					CPCjouer(joueurCPC, matrice, PlaceDispo);
					PlaceDispo--;

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
						if (userInputChar == 'X')
						{
							string gagnant = "USER";
							AfficherResultat(gagnant);
						}
						else
						{
							string gagnant = "CPC";
							AfficherResultat(gagnant);
						}
					}

					else if (((matrice[1, 1] == 'O') && (matrice[1, 2] == 'O') && (matrice[1, 3] == 'O')) || ((matrice[2, 1] == 'O') && (matrice[2, 2] == 'O') && (matrice[2, 3] == 'O')) || ((matrice[3, 1] == 'O') && (matrice[3, 2] == 'O') && (matrice[3, 3] == 'O')))
					{
						if (userInputChar == 'O')
						{
							string gagnant = "USER";
							AfficherResultat(gagnant);
						}
						else
						{
							string gagnant = "CPC";
							AfficherResultat(gagnant);
						}
					}

					// victoires verticales
					else if (((matrice[1, 1] == 'X') && (matrice[2, 1] == 'X') && (matrice[3, 1] == 'X')) || ((matrice[1, 2] == 'X') && (matrice[2, 2] == 'X') && (matrice[3, 2] == 'X')) || ((matrice[1, 3] == 'X') && (matrice[2, 3] == 'X') && (matrice[3, 3] == 'X')))
						if (userInputChar == 'X')
						{
							string gagnant = "USER";
							AfficherResultat(gagnant);
						}
						else
						{
							string gagnant = "CPC";
							AfficherResultat(gagnant);
						}

					else if (((matrice[1, 1] == 'O') && (matrice[2, 1] == 'O') && (matrice[3, 1] == 'O')) || ((matrice[1, 2] == 'O') && (matrice[2, 2] == 'O') && (matrice[3, 2] == 'O')) || ((matrice[1, 3] == 'O') && (matrice[2, 3] == 'O') && (matrice[3, 3] == 'O')))
						if (userInputChar == 'O')
						{
							string gagnant = "USER";
							AfficherResultat(gagnant);
						}
						else
						{
							string gagnant = "CPC";
							AfficherResultat(gagnant);
						}

					// victoires en diagonale
					else if ((matrice[1, 1] == 'X') && (matrice[2, 2] == 'X') && (matrice[3, 3] == 'X') || (matrice[1, 3] == 'X') && (matrice[2, 2] == 'X') && (matrice[3, 1] == 'X'))
						if (userInputChar == 'X')
						{
							string gagnant = "USER";
							AfficherResultat(gagnant);
						}
						else
						{
							string gagnant = "CPC";
							AfficherResultat(gagnant);
						}

					else if ((matrice[1, 1] == 'O') && (matrice[2, 2] == 'O') && (matrice[3, 3] == 'O') || (matrice[1, 3] == 'O') && (matrice[2, 2] == 'O') && (matrice[3, 1] == 'O'))
						if (userInputChar == 'O')
						{
							string gagnant = "USER";
							AfficherResultat(gagnant);
						}
						else
						{
							string gagnant = "CPC";
							AfficherResultat(gagnant);
						}
					#endregion
					nbreCoup++;

					//#region Match nul
					//// cas match nul
					//if (PlaceDispo < 1)
					//{
					//	Console.WriteLine("Match nul!");
					//	break;
					//}

					//else if (nbreCoup >= 9)
					//{
					//	Console.WriteLine("Match nul!");
					//	break;
					//}
					//#endregion
				}
				nouveauJeu = false;  // novelle partie OK
			}
		}

		private static void CPCjouer(char joueurCPC, char[,] matrice, int PlaceDispo)
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


		/// <summary>
		/// Méthode affichage du gagnant
		/// </summary>
		/// <param name="gagnant"></param>
		private static void AfficherResultat(string gagnant)
		{
			Console.WriteLine("{0} gagne en {1} coups", gagnant, nbreCoup + 1);
			jouerCoupSuivant = false;
		}
	}
}
