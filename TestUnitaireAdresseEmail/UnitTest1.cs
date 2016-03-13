using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdresseEmail;

namespace TestUnitaireAdresseEmail
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {

            Assert.IsTrue(Program.EmailValide("une@adresse.com"));//j'appelle ma méthode bool pour tester l'adresse e-mail

        }

        [TestMethod]
        public void TestMethod2()
        {

            Assert.IsTrue(Program.EmailValide("u.n@adresse.com"));

        }

        [TestMethod]
        public void TestMethod3()
        {

            Assert.IsTrue(Program.EmailValide("u1@adresse.com"));

        }

        [TestMethod]
        public void TestMethod4()
        {

            Assert.IsTrue(Program.EmailValide("u_a@adresse.com"));

        }

        [TestMethod]
        public void TestMethod5()
        {

            Assert.IsTrue(Program.EmailValide("u-a@ad.com"));

        }

        [TestMethod]
        public void TestMethod6()
        {

            Assert.IsTrue(Program.EmailValide("u-20@ad.co"));

        }

        [TestMethod]
        public void TestMethod7()
        {

            Assert.IsTrue(Program.EmailValide("u2_2a@adresse.co"));

        }
    }
}