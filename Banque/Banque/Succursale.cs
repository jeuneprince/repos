using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ClassBanque
{
    public class Succursale
    {
        private string nom;
        private string adresse;
        private Banque banque;


        /// <summary>
        /// LEs constructeurs
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="adresse"></param>
        public Succursale(string nom, string adresse, Banque banque)
        {
            this.Nom = nom;
            this.Adresse = adresse;
            this.Banque = banque;
        }

        /// <summary>
        /// Permet d'ajouter un client s'il n'existe pas et un compte courant s'il n'existe pas aussi avec un numero fourni en aleatoire
        /// </summary>
        /// <param name="client"></param>
        /// <param name="montantBase"></param>
        public void AjouterUnCompteCourant(Client client, int montantBase)
        {
            uint numero_compte = 1;
            CompteCourant compteCourant = new CompteCourant(numero_compte++.ToString("D3"), montantBase, -500);
            if (ExisteCompteCourant(compteCourant.Numero_compte) == null)
            {
                client.AjouterCompteCourant(compteCourant);
                compteCourant.Proprietaire_du_compte=client;
                Debug.WriteLine("Le client " + client.Nom_client + " vient d'ouvrir un compte n°: " + compteCourant.Numero_compte + " à l agence" + this.Nom);
            }
            else
                Debug.WriteLine("Ce numero de compte est deja occupé");
        }


        /// <summary>
        /// Permet d'ajouter un client s'il n'existe pas et un compte epargne s'il n'existe pas aussi avec un numero fourni en aleatoire
        /// </summary>
        /// <param name="client"></param>
        /// <param name="montantBase"></param>
        public void AjouterUnCompteEpargne(Client client, int montantBase)
        {
            uint numero_compte = 1;
            CompteEpargne compteEpargne = new CompteEpargne(numero_compte++.ToString("D3"), montantBase);
            if (ExisteCompteEpargne(compteEpargne.Numero_compte) == null)
            {
                client.AjouterCompteEpargne(compteEpargne);
                compteEpargne.Proprietaire_du_compte=client;
                Debug.WriteLine("Le client " + client.Nom_client + " vient d'ouvrir un compte n°: " + compteEpargne.Numero_compte + " à l agence" + this.Nom);
            }
            else
                Debug.WriteLine("Ce numero de compte est deja occupé");

        }
        /// <summary>
        /// On verifie si le compte existe vraiment puis on le supprime
        /// </summary>
        /// <param name="compteBancaire"></param>
        public void RetirerCompteCourant(String noCompteBancaire)
        {
            if (ExisteCompteCourant(noCompteBancaire) != null)
            {
                ExisteCompteCourant(noCompteBancaire).Proprietaire_du_compte.CompteCourants.Remove(ExisteCompteCourant(noCompteBancaire));
                this.Banque.CompteCourants.Remove(ExisteCompteCourant(noCompteBancaire));
                this.Banque.Comptebancaires.Remove(ExisteCompteCourant(noCompteBancaire));
            }
            else
                Debug.WriteLine("Ce numero de compte n'existe pas");
        }

        public void RetirerCompteEpargne(String noCompteBancaire)
        {
            if (ExisteCompteEpargne(noCompteBancaire) != null)
            {
                ExisteCompteEpargne(noCompteBancaire).Proprietaire_du_compte.CompteEpargnes.Remove(ExisteCompteEpargne(noCompteBancaire));
                this.Banque.CompteEpargnes.Remove(ExisteCompteEpargne(noCompteBancaire));
                this.Banque.Comptebancaires.Remove(ExisteCompteEpargne(noCompteBancaire));
            }
            else
                Debug.WriteLine("Ce numero de compte n'existe pas");
        }

        /// <summary>
        /// Verifie l'existence du compte avant de faire un depot d'argent
        /// </summary>
        /// <param name="compteBancaire"></param>
        /// <param name="montant"></param>
        /// <param name="nom"></param>
        public void FaireDepotCourant(String noCompteBancaire, int montant, String nom)
        {

            if (ExisteCompteCourant(noCompteBancaire) != null)
            {
                ExisteCompteCourant(noCompteBancaire).Deposer(montant, nom);
            }
        }

        public void FaireDepotEpargne(String noCompteBancaire, int montant, String nom)
        {

            if (ExisteCompteEpargne(noCompteBancaire) != null)
            {
                ExisteCompteEpargne(noCompteBancaire).Deposer(montant, nom);
            }
        }
        /// <summary>
        /// Verifie l'existence du compte avant de faire un retrait d'argent
        /// </summary>
        /// <param name="compteBancaire"></param>
        /// <param name="montant"></param>
        /// <param name="client"></param>
        public void FaireRetraitCourant(String noCompteBancaire, int montant, Client client)
        {
            if (ExisteCompteCourant(noCompteBancaire) != null)
            {
                client.RetirerCourant(ExisteCompteCourant(noCompteBancaire), montant);

            }
        }

        public void FaireRetraitEpargne(String noCompteBancaire, int montant, Client client)
        {
            if (ExisteCompteEpargne(noCompteBancaire) != null)
            {
                client.RetirerEpargne(ExisteCompteEpargne(noCompteBancaire), montant);

            }
        }


        /// <summary>
        /// Test pour verifier l'existence d'un compte
        /// </summary>
        /// <param name="compteBancaire"></param>
        /// <returns></returns>
        public CompteCourant ExisteCompteCourant(String noCompteBancaire)
        {
            for (int i = 0; i < Banque.CompteCourants.Count; i++)
            {

                if (noCompteBancaire.Equals(Banque.CompteCourants[i].Numero_compte))
                    return Banque.CompteCourants[i];
            }
            return null;
        }

        public CompteEpargne ExisteCompteEpargne(String noCompteBancaire)
        {
            for (int i = 0; i < Banque.CompteEpargnes.Count; i++)
            {

                if (noCompteBancaire.Equals(Banque.CompteEpargnes[i].Numero_compte))
                    return Banque.CompteEpargnes[i];
            }
            return null;
        }
        /// <summary>
        /// Les accesseurs
        /// </summary>

        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public Banque Banque { get => banque; set => banque = value; }

    }
}
