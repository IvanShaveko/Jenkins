/*using System;
using System.Threading;
using AirlinesTestingApp.BaseEntities;
using AirlinesTestingApp.Pages;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace AirlinesTestingApp.Tests
{
    [TestFixture]
    public class HomePageTests
    {
        [Test]
        public void OneCanFindTicketsFromMinskToMoscow()
        {
            var driver = Driver.GetDriver();

            var page = new HomePage(driver);
            page.Open();
            Thread.Sleep(5000);
            page.InitFrom("Minsk");
            page.InitTo("Moscow");
            Assert.IsTrue(page.ResultsFound());
        }

        [Test]
        public void OneCantFindTicketsFromMinskToDenver()
        {

            var driver = Driver.GetDriver();

            var page = new HomePage(driver);
            page.Open();
            Thread.Sleep(5000);
            page.InitFrom("Minsk");
            page.InitTo("Denver");
            Assert.IsFalse(page.ResultsFound());
        }

        [Test]
        public void OneCanSpecifyBackDateWhenOneWayNotSelected()
        {
            var driver = Driver.GetDriver();

            var page = new HomePage(driver);
            page.Open();
            Thread.Sleep(5000);
            page.ClickOneWay();
            Assert.IsTrue(page.IsReturnDateVisible());
        }

        [Test]
        public void OneCantSpecifyBackDateWhenOneWaSelected()
        {
            var driver = Driver.GetDriver();

            var page = new HomePage(driver);
            page.Open();
            Thread.Sleep(5000);
            Assert.IsFalse(page.IsReturnDateVisible());
        }

        [Test]
        public void OneCanLogin()
        {

            var driver = Driver.GetDriver();

            var page = new HomePage(driver);

            page.Open();

            try
            {
                page.ClickLogoutButton();
            }
            catch (Exception)
            {
            }

            page.ClickLoginButton();
            page.EnterLogin("shaveko.ivan@gmail.com");
            page.EnterPassword("102211Vano_");
            page.ClickLoginButton();
            Thread.Sleep(2000);
            Assert.AreEqual(expected: "ИВАН", actual: page.UserName.ToUpper());
            Assert.IsTrue(page.Authorized);
            page.ClickLogoutButton();
        }

        [Test]
        public void OneCanLogout()
        {
            var driver = Driver.GetDriver();

            var page = new HomePage(driver);
            page.Open();

            try
            {
                page.ClickLogoutButton();
            }
            catch (Exception)
            {
            }

            page.ClickLoginButton();
            page.EnterLogin("shaveko.ivan@gmail.com");
            page.EnterPassword("102211Vano_");
            page.ClickLoginButton();
            page.ClickLogoutButton();
            Assert.IsFalse(page.Authorized);
        }
    }
}*/