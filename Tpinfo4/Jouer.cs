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
			char a = 'x';
			char b = 'o';
			Console.Write("Choisissez {0} ou {1}:", a, b);
			if (Console.Read() == a)
			{
				//Console.WriteLine("Vous avez tapez {0}", a);
				GamePlay(a);

			}
			else if (Console.Read() == b)
			{
				//Console.WriteLine("Vous avez tapez {0}", b);
				GamePlay(b);
			}
			
		}

		/// <summary>
		/// méthode établissant les coups des joueurs
		/// </summary>
		/// <param name="z"></param>
		private static void GamePlay(char z)
		{
			char[,] matrice = new char[4, 4];
			int nbrepartie = 0;
			do
			{
			// entrée d'une combinaison par le USER pour placer un crois
			Console.WriteLine("Entrez une combinaison (ex: i0):");
			Console.ReadLine();
			if (Console.ReadLine() == "i0")
			{
			matrice[3, 2] = z;
			}

			// CPC joue
			Random rnd = new Random();
			int k = rnd.Next(1,3);
			int m = rnd.Next(1,3);
			matrice[k, m] = 'O';

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
					Console.Write(matrice[i,j]);
				}
				Console.WriteLine();
			}


				nbrepartie++;
			} while (nbrepartie < 4);
			
			//partie 2



		}
	}
}
