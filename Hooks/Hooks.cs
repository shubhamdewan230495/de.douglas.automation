using Allure.Commons;
using de.douglas.automation.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace de.douglas.automation.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string browserName = ConfigReader.GetSetting("browser");
            _driver = BrowserFactory.InitiateDriver(browserName);
            _scenarioContext["driver"] = _driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }
    }
}
