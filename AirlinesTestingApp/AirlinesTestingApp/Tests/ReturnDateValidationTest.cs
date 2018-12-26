using System.Threading;
using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlinesTestingApp.Tests
{
    [TestClass]
    public class ReturnDateValidationTest 
    {
        private HomePage _homePage;
        private const string ErrorMessage = "MESSAGE D'ERREUR\r\nVous devez choisir une date " +
            "/ heure de départ, comprise entre ^DATA(START_RANGE_NUM), à partir de maintenant" +
            ", et ^DATA(END_RANGE_NUM).";

        [TestMethod]
        public void CheckReturnDateGreaterOrEqualLeavingDate()
        {
            OpenHomePage();

            Thread.Sleep(15000);

            FillInBookingFormSetIncorrectReturnDateAndSubmit();

            AssertErrorsVisible();
        }

        private void OpenHomePage()
        {
            var homePage = new HomePage();
            homePage.OpenHomePage();
            homePage.CloseAds();
            this._homePage = homePage;
        }

        private void FillInBookingFormSetIncorrectReturnDateAndSubmit()
        {
            _homePage.FillInBookingForm();
            _homePage.GetReturnTicketDate().Clear();
            _homePage.SetDateTime(_homePage.GetReturnTicketDate(), "11/11/2011");
            _homePage.SubmitBookingForm();
        }

        private void AssertErrorsVisible()
        {
            var messageText = _homePage.GetErrorMessages().Text;
            Assert.AreEqual(ErrorMessage, messageText);
        }
    }
}