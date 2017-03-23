using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication176
{
    class Salarie
    {/// <summary>
     ///  declarer les attributs 
     /// </summary>
        protected int matricule;
        protected int categorie;
        protected int service;
        protected string nom;
        protected double salaire;

        public int Matricule
        {
            get { return matricule; }
            set { matricule = value; }

        }
        public int Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }
        public int Service
        {
            get { return service; }
            set { service = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public double Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }
        /// <summary>
        /// constructeur de la classe salarié 
        /// </summary>
        /// <param name="lenom"></Nom salarié >
        /// <param name="lesalire"></salaire du salarié >
        /// <param name="lamatricule"></matricule salarié >
        /// <param name="leservice"></service du salrié >
        /// <param name="lacategorie"></categorie du salarié >
        /// 
        public Salarie(string lenom, double lesalire, int lamatricule, int leservice, int lacategorie)
        {
            Categorie = lacategorie;
            Matricule = matricule;
            Service = leservice;
            Nom = lenom;
            Salaire = lesalire;
        }
   

    public virtual string Calculesalire()
        {


            return $" le salaire de {nom} est de {salaire}"; 

        }
        public override string ToString()
        {
            return Nom + ',' + Matricule + ',' + Service + ',' + Salaire + ',' + Categorie;
        }

        public override bool Equals(object obj)

        {
            return (obj is Salarie) && (Nom == ((Salarie)obj).Nom) && (Matricule == ((Salarie)obj).Matricule);
        }

    }
}
