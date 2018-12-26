using AirlinesTestingApp.BaseEntities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AirlinesTestingApp.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private const string Url = "https://www.aircaraibes.com/";
        private readonly List<By> _errorsXPaths = new List<By>()
        {
            By.XPath("//*[@id='ac-com-booking-amadeus-booking-homepage']/div[2]/ul/li[1]"),
            By.XPath("//*[@id='ac-com-booking-amadeus-booking-homepage']/div[2]/ul/li[2]"),
            By.XPath("//*[@id='ac-com-booking-amadeus-booking-homepage']/div[2]/ul/li[3]"),
            By.XPath("//*[@id='ac-com-booking-amadeus-booking-homepage']/div[2]/ul/li[4]")
        };

        public HomePage()
        {
            _driver = Driver.GetDriverInstance();
        }

        private void SelectDeparture()
        {
            var placeToLeave = new SelectElement(_driver.FindElement(By.Id("edit-b-location-1")));
            placeToLeave.SelectByIndex(1);
        }

        private void ChooseValueOfSelectTag(By selector, int index)
        {
            var selectElement = new SelectElement(_driver.FindElement(selector));
            selectElement.SelectByIndex(index);
        }

        private void CloseDatePicker()
        {
            _driver.FindElement(By.ClassName("ui-datepicker__close")).Click();
        }   

        public void OpenHomePage()
        {
            GoToUrl(Url);
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void CloseAds()
        {
            _driver.FindElement(By.ClassName("optanon-alert-box-close")).Click();
            Thread.Sleep(1000);
        }

        public void SelectOneWayTicket()
        {
            _driver.FindElement(By.Id("departure-only")).Click();
        }

        public IWebElement GetReturnTicketDate()
        {
            return _driver.FindElement(By.Id("edit-b-date-2-booking-0"));
        }

        public IWebElement GetLeavingTicketDate()
        {
            return _driver.FindElement(By.Id("edit-b-date-1-booking-0"));
        }

        public IWebElement GetReturnTicketProximity()
        {
            return _driver.FindElement(By.Id("uniform-edit-date-range-value-2"));
        }

        public void FillInBookingForm()
        {
            ChooseValueOfSelectTag(By.Id("edit-b-location-1"), 1);
            ChooseValueOfSelectTag(By.Id("edit-b-location-2"), 12);

            SetDateTime(_driver.FindElement(By.Id("edit-b-date-1-booking-0")), DateTime.Now.ToString("dd'/'MM'/'yyyy"));
            SetDateTime(GetReturnTicketDate(), DateTime.Now.ToString("dd'/'MM'/'yyyy"));
        }

        public IWebElement SetDepartureAndReturnElement()
        {
            var selectElement = new SelectElement(_driver.FindElement(By.Id("edit-b-location-1")));
            selectElement.SelectByIndex(1);
            return selectElement.SelectedOption;
        }

        public SelectElement GetArrivalAirportOptions()
        {
            return new SelectElement(_driver.FindElement(By.Id("edit-b-location-2")));
        }

        public void SetDateTime(IWebElement el, string value)
        {
            el.SendKeys(value);
            CloseDatePicker();
        }

        public IWebElement GetElement(By selector)
        {
            return _driver.FindElement(selector);
        }

        public void SubmitBookingForm()
        {
            _driver.FindElement(By.CssSelector("#edit-submit-booking-home")).Click();
        }

        public IWebElement GetErrorMessages()
        {
            return _driver.FindElement(By.ClassName("messages"));
        }

        public List<IWebElement> GetErrorsElements()
        {
            List<IWebElement> resultElements = new List<IWebElement>();
            foreach (var errorsXPath in _errorsXPaths)
            {
                resultElements.Add(_driver.FindElement(errorsXPath));
            }
            return resultElements;
        }
    }
}   