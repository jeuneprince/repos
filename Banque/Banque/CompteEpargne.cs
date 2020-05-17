using System;
using System.Collections.Generic;
using System.Text;


namespace ClassBanque
{
    public class CompteEpargne : Comptebancaire
    {

        private double taux = 3;
        /// <summary>
        /// Les constructeurs
        /// </summary>
        /// <param name="numero_compte"></param>
        /// <param name="solde"></param>
        public CompteEpargne(string numero_compte, double solde) : base(numero_compte, solde)
        {
        }
        /// <summary>
        /// Calcul d'interet
        /// </summary>
        public override double CalculerInteret()
        {
            return (Solde * taux) / 100;
        }
        /// <summary>
        /// Calcul de frais lors d'un retrait pendant que le compte est en bourse
        /// </summary>
        /// <returns></returns>
        public override double CalculerFrais()
        {
            return base.Solde* 0.01;
        }

        public void Deposer(int montant)
        {
            base.Deposer(montant, "deposant");
        }

        public void RetirerCompteEpargne(double montant)
        {
            base.Retirer(CalculerFrais());
            base.Retirer(montant);
        }
    }

}
