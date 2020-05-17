using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBanque
{
    public class Banque
    {
        private List<Client> clients;
        private List<Comptebancaire> comptebancaires;
        private List<CompteEpargne> compteEpargnes;
        private List<CompteCourant> compteCourants;
        private List<Succursale> succursales;
        private string nom_banque;

        public Banque(string nom_banque)
        {
            this.Clients = new List<Client>();
            this.Comptebancaires = new List<Comptebancaire>();
            this.CompteCourants = new List<CompteCourant>();
            this.CompteEpargnes = new List<CompteEpargne>();
            this.Succursales = new List<Succursale>();
            this.Nom_banque = nom_banque;
        }

        /// <summary>
        /// Creation de succursale
        /// </summary>
        /// <param name="succursale"></param>
        public void CreerSuccursale(Succursale succursale)
        {
            Succursales.Add(succursale);
        }

        public bool RetirerSuccursale(uint noSuccursale)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Les accesseurs
        /// </summary>
        public List<Client> Clients { get => clients; set => clients = value; }
        public List<Comptebancaire> Comptebancaires { get => comptebancaires; set => comptebancaires = value; }
        public List<CompteEpargne> CompteEpargnes { get => compteEpargnes; set => compteEpargnes = value; }
        public List<CompteCourant> CompteCourants { get => compteCourants; set => compteCourants = value; }
        public List<Succursale> Succursales { get => succursales; set => succursales = value; }
        public string Nom_banque { get => nom_banque; set => nom_banque = value; }
    }
}
