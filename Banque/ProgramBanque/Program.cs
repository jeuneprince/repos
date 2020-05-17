using System;
using ClassBanque;
using System.Collections.Generic;
using System.Text;

namespace ProgramBanque
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassBanque.Banque banqueSouley = new Banque("RBC");
            ClassBanque.Succursale succursale1 = new Succursale("Victoriaville_rbc", "", banqueSouley);
            banqueSouley.CreerSuccursale(succursale1);
            ClassBanque.Succursale succursale2 = new Succursale("Montreal_rbc", "", banqueSouley);
            banqueSouley.CreerSuccursale(succursale2);
            ClassBanque.Client client1 = new Client("Soumare Souleymane");

            //Le client 1 ouvre un compte courant(compte 0) à la succursale 1 avec 2.000.000
            succursale1.AjouterUnCompteCourant(client1, 2000000);

            //Le clientt 1 consulte son compte courant(compte 0)
            client1.Consulter(client1.CompteCourants[0]);

            //Le client 1 ouvre un compte epargne(compte 1) à la succursale 2 avec 3.000.000
            succursale2.AjouterUnCompteEpargne(client1, 3000000);

            //Le clientt 1 consulte son compte epargne(compte 1)
            client1.Consulter(client1.CompteEpargnes[0]);


            //Client 1 fait un depot de 1.000.000 à la succursale 1 sur son compte courant (compte 0)
            succursale1.FaireDepotCourant(client1.CompteCourants[0].Numero_compte, 1000000, client1.Nom_client);

            //Le clientt 1 consulte son compte courant(compte 0)
            client1.Consulter(client1.CompteCourants[0]);

            //Client 1 fait un retrait de 2.000.000 à la succursale 2 sur son compte epargne(compte 1)
            succursale2.FaireRetraitEpargne(client1.CompteEpargnes[0].Numero_compte, 2000000, client1);



            //La succursale 2 fait un depot de 500.000 sur le compte epargne(compte 1) du client 1
            succursale2.FaireDepotEpargne(client1.CompteEpargnes[0].Numero_compte, 500000, succursale2.Nom);

            //Le clientt 1 consulte son compte epargne(compte 1)
            client1.Consulter(client1.CompteEpargnes[0]);

            //Console.WriteLine(banqueSouley.Comptebancaires.Count);
            //Console.WriteLine(banqueSouley.Clients.Count);
            //Console.WriteLine(banqueSouley.Succursales.Count);
            //Console.ReadLine();
            //Console.ReadKey();
        }
    }
}
