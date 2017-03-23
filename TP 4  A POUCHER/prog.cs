using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication176
{
    class Program
    {
        static void Main(string[] args)
        {
            // j'ai instancié deux salarié (sale2, et sale 1 ) 
            Salarie sale1 = new Salarie("ali", 700, 1001, 34, 34080);
            Salarie sale2 = new Salarie("karim ", 650, 100001, 34, 3052);
            //  // j'ai instancié deux commerciale  (com, et com1 ) 
            Commerciale com = new Commerciale("corine ", 3000.00, 31112, 34, 34080, 3033.00, 20);
            Commerciale com1 = new Commerciale("leboeuf", 3020.00, 313312, 14, 34080, 3023.00, 10);

            // test 1 =TEST CALCULE SALAIRE POUR UN SALARIE 
            Console.WriteLine("---TEST CALCULE SALAIRE POUR UN SALARIE ---");
            Console.WriteLine(sale1.Calculesalire());

            //test 2 = test calcule salaire pour un commerciale
            Console.WriteLine("test calcule salaire pour un commerciale -----" );
            Console.WriteLine(com.Calculesalire());

            //test 3 =test  Equal pour salairié 
            Console.WriteLine("---test  Equal pour salairié  ----");
            Console.WriteLine("les salarié " + sale1.Nom + " et " + sale2.Nom + "sont ils egaux ? = " + sale1.Equals(sale2));

            //test 4 = test equal pour deux commerciale 
            Console.WriteLine("-------test equal pour deux commerciale " );
            Console.WriteLine(com.Equals(com1));

            //test 5 = test tostringt pour salarié 
            Console.WriteLine("-------test tostringt pour salarié -------");
            Console.WriteLine(sale1.ToString());

            //test 6 = test tostring pour commerciale
            Console.WriteLine("-------test tostring pour commerciale -----");
            Console.WriteLine(com.ToString());








        

    
      
            
        

        }


    }
}
