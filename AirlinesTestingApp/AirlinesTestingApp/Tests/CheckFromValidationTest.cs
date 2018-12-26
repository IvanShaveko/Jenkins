using System.Collections.Generic;
using System.Threading;
using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlinesTestingApp.Tests
{
    [TestClass]
    public class CheckFromValidationTest 
    {
        private HomePage _homePage;
        private readonly List<string> _errorsMessageList = new List<string>
        {
            "Veuillez sélectionner une date de départ",
            "Veuillez sélectionner une date retour",
            "Veuillez sélectionner un départ",
            "Veuillez sélectionner une arrivée"
        };

        [TestMethod]
        public void CheckFormValidation()
        {
            OpenHomePage();
         
            Thread.Sleep(10000);

            SubmitBookingForm();

            AssertErrorsVisible();
        }

        private void OpenHomePage()
        {
            _homePage = new HomePage();
            _homePage.OpenHomePage();
            _homePage.CloseAds();
        }

        private void SubmitBookingForm()
        {
            _homePage.SubmitBookingForm();
        }

        private void AssertErrorsVisible()
        {
            var errorsListElements = _homePage.GetErrorsElements();
            int i = 0;
            foreach (var errorsListElement in errorsListElements)
            {
                Assert.AreEqual(_errorsMessageList[i], errorsListElement.Text);
                i++;
            }
        }
    }
}