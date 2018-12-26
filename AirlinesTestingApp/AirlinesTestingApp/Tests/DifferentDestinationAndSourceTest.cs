using System.Threading;
using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlinesTestingApp
{
    [TestClass]
    public class ArrivalDateValidationTest 
    {
        private HomePage _homePage;
        private const string ErrorMessage = "MESSAGE D'ERREUR\r\nVous devez choisir une date " +
            "/ heure de départ, comprise entre ^DATA(START_RANGE_NUM), à partir de maintenant" +
            ", et ^DATA(END_RANGE_NUM).";

        [TestMethod]
        public void CheckArrivalDateGreaterOrEqualLeavingDate()
        {
            OpenHomePage();

            Thread.Sleep(5000);
            
            FillInBookingFormSetIncorrectArrivalDateAndSubmit();

            AssertErrorsVisible();
        }

        private void OpenHomePage()
        {
            _homePage = new HomePage();
            _homePage.OpenHomePage();
            _homePage.CloseAds();
        }

        private void FillInBookingFormSetIncorrectArrivalDateAndSubmit()
        {
            _homePage.FillInBookingForm();
            _homePage.GetLeavingTicketDate().Clear();
            _homePage.SetDateTime(_homePage.GetLeavingTicketDate(), "11/11/2011");
            _homePage.SubmitBookingForm();
        }

        private void AssertErrorsVisible()
        {
            var messageText = _homePage.GetErrorMessages().Text;
            Assert.AreEqual(ErrorMessage, messageText);
        }
    }
}