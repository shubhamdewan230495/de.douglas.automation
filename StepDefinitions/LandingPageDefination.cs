using de.douglas.automation.PageMethods;
using OpenQA.Selenium;
using de.douglas.automation.Hooks;
using de.douglas.automation.Support;

namespace de.douglas.automation.StepDefinitions
{
    [Binding]
    public class LandingPageDefination
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private HomePageFeature _homePageFeature;
        private ParfumPageFeature _parfumPageFeature;
        private Utils _utils;

        public LandingPageDefination(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)scenarioContext["driver"];
            _homePageFeature = new HomePageFeature(_driver);
            _parfumPageFeature = new ParfumPageFeature(_driver);
            _utils = new Utils(_driver, 20);
        }

        [Given(@"I navigate to the home page")]
        public void GivenINavigateToTheHomePage()
        {
            _utils.LoadUrl(ConfigReader.GetSetting("applicationUrl"));
        }

        [Given(@"I click ""(.*)"" on the consent modal")]
        public void GivenIClickOnTheConsentModal(string buttonText)
        {
            _homePageFeature.ClickAllowAllOnConsentModal();
        }

        [When(@"I go to the parfum tab")]
        public void WhenIGoToTheParfumTab()
        {
            _homePageFeature.ClickParfumOption();
        }
    }
}
