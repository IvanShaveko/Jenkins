using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp.BaseEntities
{
    public class Driver
    {
        public static IWebDriver Instance { get; private set; }
        
        private Driver()
        {

            Instance = new ChromeDriver();
            Instance.Manage().Window.Maximize();
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public static IWebDriver GetDriver()
        {
            if (Instance == null)
            {
                new Driver();
            }

            return Instance;
        }
        
        public void Quit()
        {
            Instance.Quit();
            Instance = null;
        }
    }
}