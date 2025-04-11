using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium;

namespace de.douglas.automation.Support
{
    public class BrowserFactory
    {
        private static IWebDriver _driver;
        public static IWebDriver InitiateDriver(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                case "edge":
                    _driver = new EdgeDriver();
                    break;
                case "safari":
                    _driver = new SafariDriver();
                    break;
                default:
                    throw new Exception("Browser " + browserName + " not supported");
            }

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _driver.Manage().Window.Maximize();
            return _driver;
        }
    }
}
