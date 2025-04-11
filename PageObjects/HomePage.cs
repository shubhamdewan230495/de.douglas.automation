using OpenQA.Selenium;
using System;
using SeleniumExtras.PageObjects;

namespace de.douglas.automation.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public IWebElement ConsentFormModal => _driver.FindElement(By.Id("usercentrics-root"));
        public IWebElement ParfumOption => _driver.FindElement(By.XPath("//a[text()='PARFUM']"));

        public static By CookieConsentAllowAllButton = By.CssSelector("[data-testid='uc-accept-all-button']");
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
