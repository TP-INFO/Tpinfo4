using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication176
{
    class Commerciale:Salarie
    {
        private double chiffreaffaire;
        private int commisiion; 
        public double Chiffre

        {
            get { return chiffreaffaire;  }
            set { chiffreaffaire = value;  }
        }

        public int Commission
        {
            get { return commisiion; }
            set { commisiion = value;  }

        }
        /// <summary>
        /// constructeur de la classe commerciale 
        /// </summary>
        /// <param name="lenom"></le nom du commercial >
        /// <param name="lesalire"></salaire du commerciale>
        /// <param name="lamatricule"></matricule salarié >
        /// <param name="leservice"></service du salarié
        /// <param name="lacategorie"></categorie>
        /// <param name="lechiffreaffaire"></chiffre>
        /// <param name="lacomission"></Comission >
        /// 

        public Commerciale (string lenom, double lesalire, int lamatricule, int leservice, int lacategorie, double lechiffreaffaire , int lacomission ):base(lenom ,lesalire,lamatricule,leservice,lacategorie)
        {
            Chiffre = lechiffreaffaire;
            Commission = lacomission;
        }

        /// <summary>
        /// calcule de salaire du commerciale (methode ecraser a partir de la classe calcule salaire ) 
        /// </summary>
        /// <returns></returns>
        public override string Calculesalire()
        {
            double nouveausalaire = base.salaire *(1+(Convert.ToDouble(commisiion))/100 ) ;
            return $" l'ancien salaire est de {base.salaire} et le nouveau salaire est de {nouveausalaire} "; 
        }
        /// <summary>
        /// methode equal()  permet de comarer deux commerciale 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>

        public override bool Equals(object obj)
        {
             return (obj is Commerciale) && (Nom == ((Commerciale)obj).Nom) && (Matricule == ((Commerciale)obj).Matricule);
        }

    }
    }

