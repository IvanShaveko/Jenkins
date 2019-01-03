using System;
using System.Threading;
using AirlinesTestingApp.BaseEntities;
using AirlinesTestingApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AirlinesTestingApp.Tests
{
    [TestFixture]
    public class HomePageTestsV2
    {
        private IWebDriver driver;
        private HomePage page;

        [OneTimeSetUp]
        public void Start()
        {
            driver = Driver.GetDriver();
            page = new HomePage(driver);
            page.Open();
            Thread.Sleep(5000);
        }

        [OneTimeTearDown]
        public void End()
        {
            page.Quit();
        }

        [Test]
        public void OneCanFindTicketsFromMinskToMoscow()
        {
            page.InitFrom("Minsk");
            page.InitTo("Moscow");
            Assert.IsTrue(page.ResultsFound());
        }

        [Test]
        public void OneCantFindTicketsFromMinskToDenver()
        {
            page.InitFrom("Minsk");
            page.InitTo("Denver");
            Assert.IsFalse(page.ResultsFound());
        }

        [Test]
        public void OneCanSpecifyBackDateWhenOneWayNotSelected()
        {
            page.ClickOneWay();
            Assert.IsTrue(page.IsReturnDateVisible());
        }

        [Test]
        public void OneCantSpecifyBackDateWhenOneWaSelected()
        {
            Assert.IsTrue(page.IsReturnDateVisible());
        }

        [Test]
        public void OneCanLogin()
        {
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
            Assert.AreEqual(expected: "ИВАН", actual: page.UserName.ToUpper());
            Assert.IsTrue(page.Authorized);
            page.ClickLogoutButton();
        }

        [Test]
        public void OneCanLogout()
        {
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
}