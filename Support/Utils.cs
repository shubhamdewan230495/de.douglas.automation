using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace de.douglas.automation.Support
{
    public class Utils
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public Utils(IWebDriver driver, int timeoutInSeconds)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        public void LoadUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public IWebElement GetElement(string locator)
        {
            try
            {
                By elementBy = GetElementBy(locator);
                IWebElement element = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementBy));
                return element;
            }
            catch (WebDriverTimeoutException)
            {
                throw new NoSuchElementException($"Element with locator '{locator}' not found within the specified timeout.");
            }
        }

        public List<IWebElement> GetElements(string locator)
        {
            By elementBy = GetElementBy(locator);
            return _driver.FindElements(elementBy).ToList();
        }

        public By GetElementBy(string locator)
        {
            if (locator.StartsWith("//"))
                return By.XPath(locator);
            else if (locator.StartsWith("#"))
                return By.Id(locator);
            else if (locator.StartsWith("."))
                return By.ClassName(locator);
            else if (locator.StartsWith("[") || char.IsLower(locator[0]))
                return By.CssSelector(locator);
            else
                throw new Exception("Locator not identified");
        }

        public void WaitUntilPresenceOfElement(string locator)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(GetElementBy(locator)));
        }

        public void WaitUntilVisibilityOfElement(string locator)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(GetElementBy(locator)));
        }

        public void ClickElement(string locator)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetElementBy(locator))).Click();
        }

        public bool CheckIfElementIsVisible(string locator)
        {
            return GetElement(locator).Displayed;
        }

        public void ScrollToElement(string locator)
        {
            IWebElement element = GetElement(locator);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void ClickUsingJavascript(string locator)
        {
            IWebElement element = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(GetElementBy(locator))).FirstOrDefault();
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
        }
        public void WaitForPageLoad(int timeoutInSeconds)
        {
            _wait.Until((wd) =>
                ((IJavaScriptExecutor)wd).ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        public void ScrollToFooter()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            long lastHeight = (long)js.ExecuteScript("return document.body.scrollHeight;");
            js.ExecuteScript("window.scrollBy(0, " + (lastHeight / 4) * 3 + ");");
        }

        public void MouseHover(string locator)
        {
            Actions actions = new Actions(_driver);
            IWebElement element = GetElement(locator);
            actions.MoveToElement(element).Perform();
        }
        public void WaitForFewSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
    }
}
