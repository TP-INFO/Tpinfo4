using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tpinfo4
{
	static class Jouer
	{
		public static void JouerPartie()
		{
			// modification de l'input pour eviter exception error dans méthode Gameplat (thanks to Mohammed)
			Console.Write("Choisissez {0} ou {1}:", 'X', 'O');
			string userinput = Console.ReadLine();

			if (userinput == "X")
			{
				//Console.WriteLine("Vous avez tapez {0}", a);
				GamePlay(userinput[0]);

			}
			else if (userinput == "O")
			{
				//Console.WriteLine("Vous avez tapez {0}", b);
				GamePlay(userinput[0]);
			}
			else
			{
				Console.WriteLine("Invalid input ");
				System.Environment.Exit(0);
			}
		}

		/// <summary>
		/// méthode établissant les coups des joueurs
		/// </summary>
		/// <param name="z"></param>
		private static void GamePlay(char z)
		{
			char[,] matrice = new char[4, 4];
			int nbreCoup = 0;
			bool rejouer = true;
			int PlaceDispo = 9;

			while (rejouer)
			{
				//entrée d'une combinaison par le USER pour placer un pion

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

					// pour éviter rejouer sur case déjà occupée (donc != 0)
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

				#region Victoires USER

				// horizontale
				if (((matrice[1, 1] == 'X') && (matrice[1, 2] == 'X') && (matrice[1, 3] == 'X')) || ((matrice[2, 1] == 'X') && (matrice[2, 2] == 'X') && (matrice[2, 3] == 'X')))
				{
					Console.WriteLine("Vous avez gagné en {0} coups", nbreCoup + 1);
					rejouer = false;
					break;
				}
				else if ((matrice[3, 1] == 'X') && (matrice[3, 2] == 'X') && (matrice[3, 3] == 'X'))
				{
					Console.WriteLine("Vous avez gagné en {0} coups", nbreCoup + 1);
					rejouer = false;
					break;
				}
				// verticale
				if (((matrice[1, 1] == 'X') && (matrice[2, 1] == 'X') && (matrice[3, 1] == 'X')) || ((matrice[1, 2] == 'X') && (matrice[2, 2] == 'X') && (matrice[3, 2] == 'X')))
				{
					Console.WriteLine("Vous avez gagné en {0} coups", nbreCoup + 1);
					rejouer = false;
					break;
				}
				else if ((matrice[1, 3] == 'X') && (matrice[2, 3] == 'X') && (matrice[3, 3] == 'X'))
				{
					Console.WriteLine("Vous avez gagné en {0} coups", nbreCoup + 1);
					rejouer = false;
					break;
				}

				// diagonale
				else if ((matrice[1, 1] == 'X') && (matrice[2, 2] == 'X') && (matrice[3, 3] == 'X') || (matrice[1, 1] == 'X') && (matrice[2, 2] == 'X') && (matrice[3, 3] == 'X'))
				{
					Console.WriteLine("Vous avez gagné en {0} coups", nbreCoup + 1);
					rejouer = false;
					break;
				}

				#endregion


				#region Victoires CPC
				// horizontale
				if (((matrice[1, 1] == 'O') && (matrice[1, 2] == 'O') && (matrice[1, 3] == 'O')) || ((matrice[2, 1] == 'O') && (matrice[2, 2] == 'O') && (matrice[2, 3] == 'O')))
				{
					Console.WriteLine("CPC a gagné en {0} coups", nbreCoup + 1);
					rejouer = false;
					break;
				}
				else if ((matrice[3, 1] == 'O') && (matrice[3, 2] == 'O') && (matrice[3, 3] == 'O'))
				{
					Console.WriteLine("CPC a gagné en {0} coups", nbreCoup + 1);
					rejouer = false;
					break;
				}
				// verticale
				if (((matrice[1, 1] == 'O') && (matrice[2, 1] == 'O') && (matrice[3, 1] == 'O')) || ((matrice[1, 2] == 'O') && (matrice[2, 2] == 'O') && (matrice[3, 2] == 'O')))
				{
					Console.WriteLine("CPC a gagné en {0} coups", nbreCoup + 1);
					rejouer = false;
					break;
				}
				else if ((matrice[1, 3] == 'O') && (matrice[2, 3] == 'O') && (matrice[3, 3] == 'O'))
				{
					Console.WriteLine("CPC a gagné en {0} coups", nbreCoup + 1);
					rejouer = false;
					break;
				}

				// diagonale
				else if ((matrice[1, 1] == 'O') && (matrice[2, 2] == 'O') && (matrice[3, 3] == 'O') || (matrice[1, 1] == 'O') && (matrice[2, 2] == 'O') && (matrice[3, 3] == 'O'))
				{
					Console.WriteLine("CPC a gagné en {0} coups", nbreCoup + 1);
					rejouer = false;
					break;
				}

				#endregion
				nbreCoup++;
				Console.WriteLine($"Nbre de coup : {nbreCoup}");

				#region Match nul
				// cas match nul
				if (PlaceDispo == 0)
				{
					Console.WriteLine("Match nul!");
					break;
				}
				#endregion
			}


			Console.WriteLine("Voulez-vous rejouer?");



		}
	}
}
