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
        private HomePage _homePage;
        private SelectElement _arrivalAirports;
        private IWebElement _departureAirport;

        [TestMethod]
        public void CheckDifferentSourceAndDestination()
        {
            OpenHomePage();

            Thread.Sleep(10000);

            SetSourceAirport();

            AssertNoSourceAirportInDestinationDropdown();
        }

        private void OpenHomePage()
        {
            _homePage = new HomePage();
            _homePage.OpenHomePage();
        }

        private void SetSourceAirport()
        {
            _departureAirport = _homePage.SetDepartureAndReturnElement();
            _arrivalAirports = _homePage.GetArrivalAirportOptions();
        }

        private void AssertNoSourceAirportInDestinationDropdown()
        {
            var arrivalOptions = _arrivalAirports.Options;
            var existsDepartureValueInArrival = arrivalOptions.Any(i => i.Text.Equals(_departureAirport.Text));
            Assert.AreEqual(true, existsDepartureValueInArrival);
        }
    }
}