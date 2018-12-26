using System.Linq;
using System.Threading;
using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AirlinesTestingApp.Tests
{
    [TestClass]
    public class DifferentDestinationAndSourceTest
    {
        private HomePage homePage;
        private SelectElement arrivalAirports;
        private IWebElement departureAirport;

        [TestMethod]
        public void CheckDifferentSourceAndDestination()
        {
            _1_OpenHomePage();

            Thread.Sleep(5000);

            _2_SetSourceAirport();

            _3_AssertNoSourceAirportInDestinationDropdown();
        }

        private void _1_OpenHomePage()
        {
            homePage = new HomePage();
            homePage.OpenHomePage();
        }

        private void _2_SetSourceAirport()
        {
            departureAirport = homePage.SetDepartureAndReturnElement();
            arrivalAirports = homePage.GetArrivalAirportOptions();
        }

        private void _3_AssertNoSourceAirportInDestinationDropdown()
        {
            var arrivalOptions = arrivalAirports.Options;
            var existsDepartureValueInArrival = arrivalOptions.Any(i => i.Text.Equals(departureAirport.Text));
            Assert.AreEqual(true, existsDepartureValueInArrival);
        }
    }
}