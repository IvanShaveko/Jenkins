using System.Threading;
using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlinesTestingApp.Tests
{
    [TestClass]
    public class OneWayTicketSelectingTest 
    {
            private HomePage _homePage;

            [TestMethod]
            public void SelectOneWayTicketAndAssertReturningDateDisabled()
            {
                OpenHomePageAndSelectOneWayTicket();

                Thread.Sleep(5000);

                AssertDisabledFields();
            }

        private void OpenHomePageAndSelectOneWayTicket()
        {
            var homePage = new HomePage();
            homePage.OpenHomePage();
            homePage.CloseAds();
            homePage.SelectOneWayTicket();
            this._homePage = homePage;
        }

        private void AssertDisabledFields()
        {
            AssertDateFieldDisabled();
            AssertProximityFieldDisabled();
        }

        private void AssertDateFieldDisabled()
        {
            var dateField = _homePage.GetReturnTicketDate();
            Assert.AreEqual(false, dateField.Enabled);
        }

        private void AssertProximityFieldDisabled()
        {
            var proximityField = _homePage.GetReturnTicketProximity();
            var classNames = proximityField.GetAttribute("className");
            Assert.AreEqual(true, classNames.Contains("disabled"));
        }
    }
}
