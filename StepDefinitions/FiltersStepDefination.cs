using de.douglas.automation.PageObjects;
using de.douglas.automation.PageMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using de.douglas.automation.Support;

namespace de.douglas.automation.StepDefinitions
{
    [Binding]
    public class FiltersStepDefination
    {
        private readonly IWebDriver _driver;
        private ParfumPageFeature _parfumPageFeature;
        private Utils _utils;
        private readonly ScenarioContext _scenarioContext;

        // Constructor modified to get WebDriver from ScenarioContext
        public FiltersStepDefination(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["driver"];
            _parfumPageFeature = new ParfumPageFeature(_driver);
            _utils = new Utils(_driver, 20);
            _scenarioContext = scenarioContext;
        }

        [When(@"I select ""(.*)"" from the ""(.*)"" dropdown")]
        public void WhenISelectFromTheDropdown(string valueToSelect, string dropdownName)
        {
            _parfumPageFeature.SelectOptionFromDropdown(dropdownName, valueToSelect);
        }

        [Then(@"I should see the filters ""([^""]*)"",""([^""]*)"" and ""([^""]*)"" are applied and product list is appearing")]
        public void ThenIShouldSeeTheFiltersAndAreAppliedAndProductListIsAppearing(string parfum, string unisex, string geburtstag)
        {
            _utils.WaitUntilPresenceOfElement(ParfumPage.ResetFilterButton);
            var filtersSelected = _parfumPageFeature.GetSelectedFiltersText();
            Assert.IsTrue(filtersSelected.Contains(parfum));
            Assert.IsTrue(filtersSelected.Contains(unisex));
            Assert.IsTrue(filtersSelected.Contains(geburtstag));
            Assert.IsTrue(filtersSelected.Count == 3);
            var products = _parfumPageFeature.GetListOfAllProducts();
            Assert.IsTrue(products.Any(), "No products found for the selected filters.");

        }
        [Then(@"I should see the filter ""([^""]*)"" is applied and product list is appearing")]
        public void ThenIShouldSeeTheFilterIsAppliedAndProductListIsAppearing(string parfum)
        {
            _utils.WaitUntilPresenceOfElement(ParfumPage.ResetFilterButton);
            var filtersSelected = _parfumPageFeature.GetSelectedFiltersText();
            Assert.IsTrue(filtersSelected.Contains(parfum));
            Assert.IsTrue(filtersSelected.Count == 1);
            var products = _parfumPageFeature.GetListOfAllProducts();
            Assert.IsTrue(products.Any(), "No products found for the selected filters.");
        }


        [Then(@"I reset the filters")]
        public void ThenIResetTheFilters()
        {
            _parfumPageFeature.ResetFilters();
        }

        [Then(@"Validate no filter should be applied now")]
        public void ThenValidateNoFilterShouldBeAppliedNow()
        {
            _utils.WaitUntilVisibilityOfElement(ParfumPage.parfumHeader);
            var filtersSelected = _parfumPageFeature.GetSelectedFiltersText();
            Assert.IsTrue(filtersSelected.Count == 0);
        }

    }
}
