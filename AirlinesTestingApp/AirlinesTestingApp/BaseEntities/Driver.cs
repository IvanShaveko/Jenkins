using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp.BaseEntities
{
    public class Driver
    {
        public static IWebDriver Instance { get; private set; }

        /*private static readonly Lazy<MyChromeDriver> lazy =
            new Lazy<MyChromeDriver>(() => new MyChromeDriver());
           */
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

        /*public static MyChromeDriver GetDriver() => lazy.Value;
        */
        public void Quit()
        {
            Instance.Quit();
            Instance = null;
        }
    }
}