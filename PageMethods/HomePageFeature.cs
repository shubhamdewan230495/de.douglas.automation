using OpenQA.Selenium;

namespace de.douglas.automation.PageMethods
{
    public class HomePageFeature
    {
        private readonly IWebDriver _driver;
        public IWebElement ConsentFormModal => _driver.FindElement(By.Id("usercentrics-root"));
        public IWebElement ParfumOption => _driver.FindElement(By.XPath("//a[text()='PARFUM']"));
        public By CookieConsentAllowAllButton => By.CssSelector("button[data-testid='uc-accept-all-button']");
        public HomePageFeature(IWebDriver driver)
        {
            _driver = driver;
        }
        public void ClickAllowAllOnConsentModal()
        {  
            var shadowRoot = ConsentFormModal.GetShadowRoot();
            var allowAllButton = shadowRoot.FindElement(CookieConsentAllowAllButton);
            allowAllButton.Click();
        }
        public void ClickParfumOption()
        {
            ParfumOption.Click();
        }
    }
}
