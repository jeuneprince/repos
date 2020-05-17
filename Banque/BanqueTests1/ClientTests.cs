using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassBanque;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBanque.Tests
{
    [TestClass()]
    public class ClientTests
    {

        Client client = new Client("Simon");
        CompteCourant comptecourant = new CompteCourant("Simon", 458, -500);
        public void init()
        {
            client.DeposerCourant(comptecourant, 2, "Simon");
        }
        [TestMethod()]
        public void DeposerCourantTest()
        {
            init();

            Assert.AreEqual(460, comptecourant.Solde);
        }

    }
}