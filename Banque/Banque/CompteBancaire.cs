using System;
using System.Diagnostics;

namespace ClassBanque
    {
        public abstract class Comptebancaire
        {
            private string numero_compte;
            private double solde;
            private Client proprietaire_du_compte;

        /// <summary>
        /// Les constructeurs
        /// </summary>
        /// <param name="numero_compte">Le numero du compte</param>
        /// <param name="solde">Le solde dans le compte</param>
        protected Comptebancaire(string numero_compte, double solde)
            {
                this.Numero_compte = numero_compte;
                this.Solde = solde;
            }
        /// <summary>
        /// La methode pour faire un depot d'argent dans le compte
        /// </summary>
        /// <param name="montant">Le montant total deposé</param>
        /// <param name="deposant">Le nom de celui qui fait le depot, car ça peut etre la banque, le salaire, le client lui meme etc</param>
        public virtual void Deposer(double montant, String deposant)
            {
                this.Solde += montant;
                Debug.WriteLine(deposant + " a fait un depot de " + montant + "sur votre compte : " + this.Numero_compte);
            }

        /// <summary>
        /// La methode pour faire un retrait d'argent du compte
        /// </summary>
        /// <param name="montant">montant retiré</param>
        public virtual void Retirer(double montant)
            {
                this.Solde -= montant;
                Debug.WriteLine(" a fait un retrait de " + montant + "sur votre compte : " + this.Numero_compte);
            }

        /// <summary>
        /// Pour consulter son solde
        /// </summary>
            public virtual void Consulter()
            {
                Debug.WriteLine("Votre montant est de " + this.Solde + "sur votre compte : " + this.Numero_compte);
            }

        public abstract double CalculerInteret();
        public abstract double CalculerFrais();
        /// <summary>
        /// Les accesseurs
        /// </summary>
        public string Numero_compte { get => numero_compte; set => numero_compte = value; }
        public double Solde { get => solde; set => solde = value; }
        public Client Proprietaire_du_compte { get => proprietaire_du_compte; set => proprietaire_du_compte = value; }

        /// <summary>
        /// Affichage
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            {
                return "------------------¬\n"
                    + this.Numero_compte + "\n" + this.Solde + "\n----------------------------";
            }
        }
    }

