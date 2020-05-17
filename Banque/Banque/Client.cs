using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBanque
{
    public class Client
    {
        private List<CompteEpargne> compteEpargnes;
        private List<CompteCourant> compteCourants;
        private string nom_client;
        private uint numero_compte = 1;


        /// <summary>
        /// Constructeurs
        /// </summary>
        /// <param name="nom_client"> le nom du client</param>
        public Client(string nom_client)
        {
            this.CompteCourants = new List<CompteCourant>();
            this.CompteEpargnes = new List<CompteEpargne>();
            this.Nom_client = nom_client;
        }


        /// <summary>
        /// Ajouter un nouveau compte
        /// </summary>
        /// <param name="comptebancaire"></param>
        public void AjouterCompteCourant(CompteCourant compteCourant)
        {
            this.CompteCourants.Add(compteCourant);
        }


        /// <summary>
        /// Ajouter un compte epargne
        /// </summary>
        /// <param name="compteEpargne"></param>
        public void AjouterCompteEpargne(CompteEpargne compteEpargne)
        {
            this.CompteEpargnes.Add(compteEpargne);
        }


        /// <summary>
        /// Rechercher un compte 
        /// </summary>
        /// <param name="numero_rechercher"></param>
        /// <returns></returns>
        public bool RechercherCompte(String numero_rechercher)
        {
            for (int i = 0; i < CompteCourants.Count; i++)
            {
                if (numero_rechercher.Equals(CompteCourants[i].Numero_compte))
                    return true;
            }

            for (int i = 0; i < CompteEpargnes.Count; i++)
            {
                if (numero_rechercher.Equals(CompteEpargnes[i].Numero_compte))
                    return true;
            }
            return false;
        }


        /// <summary>
        /// rechercher un compte courant et supprime quand on le trouve
        /// </summary>
        /// <param name="comptebancaire"></param>
        public void SupprimerCompteCourant(CompteCourant compteCourant)
        {
            if (RechercherCompte(compteCourant.Numero_compte))
            {
                this.CompteCourants.Remove(compteCourant);
            }
        }


        /// <summary>
        /// rechercher un compte epargne et supprime quand on le trouve
        /// </summary>
        /// <param name="comptebancaire"></param>
        public void SupprimerCompteEpargne(CompteEpargne compteEpargne)
        {
            if (RechercherCompte(compteEpargne.Numero_compte))
            {
                this.CompteEpargnes.Remove(compteEpargne);
            }
        }


        /// <summary>
        /// Depot d'argent dans le compte courant ou compte epargne
        /// </summary>
        /// <param name="montant"></param>
        /// <param name="numero_compte"></param>
        /// <param name="deposant">le nom du deposant</param>
        public void DeposerCourant(CompteCourant compteCourant, int montant, string deposant)
        {
            if (RechercherCompte(compteCourant.Numero_compte))
            {
                compteCourant.Deposer(montant, deposant);
            }
        }

        public void DeposerEpargne(CompteEpargne compteEpargne, int montant, string deposant)
        {
            if (RechercherCompte(compteEpargne.Numero_compte))
            {
                compteEpargne.Deposer(montant, deposant);
            }
        }
        /// <summary>
        /// Retirer l'argent du compte courant ou compte epargne
        /// </summary>
        /// <param name="comptebancaire"></param>
        /// <param name="montant"></param>
        
        public void RetirerCourant(CompteCourant compteCourant, int montant)
        {
            if (RechercherCompte(compteCourant.Numero_compte))
            {
                compteCourant.RetirerCompteCourant(montant);
            }
        }

        public void RetirerEpargne(CompteEpargne compteEpargne, int montant)
        {
            if (RechercherCompte(compteEpargne.Numero_compte))
            {
                compteEpargne.RetirerCompteEpargne(montant);
            }
        }
        public List<CompteEpargne> CompteEpargnes { get => compteEpargnes; set => compteEpargnes = value; }
        public List<CompteCourant> CompteCourants { get => compteCourants; set => compteCourants = value; }
        public string Nom_client { get => nom_client; set => nom_client = value; }
        public uint Numero_compte { get => numero_compte; set => numero_compte = value; }


        /// <summary>
        /// Consulter son compte
        /// </summary>
        /// <param name="comptebancaire"></param>
        /// <param name="montant"></param>
        /// <param name="deposant"></param>
        public void Consulter(Comptebancaire comptebancaire)
        {
            if (RechercherCompte(comptebancaire.Numero_compte))
            {
                comptebancaire.Consulter();
            }
        }
    }

}
