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

		private static void GamePlay(char z)
		{

			char[,] matrice = new char[4, 4];

			// entrée d'une combinaison par le USER pour placer un pion
			Console.WriteLine("Entrez une combinaison (ex: 32):");
			Console.ReadLine();
			if (Console.ReadLine() == "32")
			{
			matrice[3, 2] = z;
			}


			// CPC joue
			for (int i = 0; i < matrice.GetLength(0); i++)
			{
				for (int j = 0; j < matrice.GetLength(1); j++)
				{
					Random rnd = new Random(3);
					i = rnd.Next(3);
					j = rnd.Next(3);
					matrice[i, j] = 'O';
				

				}
			}
	

			// affichage de l matrice
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
					matrice[1, 0] = 'A';
					matrice[2, 0] = 'B';
					matrice[3, 0] = 'C';

				
					Console.Write(matrice[i, j]);
				}
				Console.WriteLine();
			}
		}
	}
}
