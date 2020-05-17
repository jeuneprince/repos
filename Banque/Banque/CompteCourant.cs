using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace ClassBanque
{
    public class CompteCourant : Comptebancaire
    {
        private double decouvert_autorise;

        /// <summary>
        /// Les constructeurs
        /// </summary>
        /// <param name="numero_compte"></param>
        /// <param name="solde"></param>
        /// <param name="decouvert_autorise">le decouvert autorisé qui est negatif</param>
        public CompteCourant(string numero_compte, double solde, double decouvert_autorise) : base(numero_compte, solde)
        {
            this.decouvert_autorise = decouvert_autorise;
        }

        /// <summary>
        /// Pour faire un retrait
        /// </summary>
        /// <param name="montant"></param>
        public void RetirerCompteCourant(double montant)
        {
            if (Autoriser(montant))
            {
                base.Retirer(montant);
            }
            else
            {
                Debug.WriteLine("Retrait impossible");
            }
        }

        /// <summary>
        /// Pour faire un depot
        /// </summary>
        /// <param name="montant"></param>
        public void DeposerCompteCourant(double montant)
        {
            base.Deposer(montant, "deposant");
        }


        /// <summary>
        /// Test pour voir si la condition avec le decouvert_autorise qui ne doit pas etre depassé est remplie
        /// </summary>
        /// <param name="montant"> montant de retrait</param>
        /// <returns></returns>
        public virtual bool Autoriser(double montant)
        {
            if (base.Solde - montant >= this.decouvert_autorise)
            {
                return true;
            }
            return false;
        }

        public override double CalculerInteret()
        {
            throw new NotImplementedException();
        }

        public override double CalculerFrais()
        {
            throw new NotImplementedException();
        }
    }

}
