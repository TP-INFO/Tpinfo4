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
			foreach (string arg in args)
			{
				if (args.Length >= 1)
				{
					switch (arg)
					{
						case "jouer":
							// appel de la méthode Jouer
							Jouer.JouerPartie();
								break;
						default:
							Console.WriteLine("Tapez la commande \"jouer\" pour commencer une partie.");
								break;
					}	
				}
			}
        }
    }
}
