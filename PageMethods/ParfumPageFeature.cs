using de.douglas.automation.PageObjects;
using de.douglas.automation.Support;
using OpenQA.Selenium;
using System.Xml.Linq;

namespace de.douglas.automation.PageMethods
{
    public class ParfumPageFeature
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private ParfumPage _parfumPage;
        private Utils _utils;
        private const int TIMEOUT_IN_SECONDS = 30;

        public ParfumPageFeature(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver);
            _parfumPage = new ParfumPage(_driver);
            _utils = new Utils(_driver, TIMEOUT_IN_SECONDS);
        }

        public void OpenDropdownByName(string dropdownName)
        {
            if (!_utils.CheckIfElementIsVisible(ParfumPage.DropDownByName(dropdownName)))
            {
                _utils.ScrollToElement(ParfumPage.DropDownByName(dropdownName));
            }

            try
            {
                _utils.ClickElement(ParfumPage.DropDownByName(dropdownName));
            }
            catch (ElementClickInterceptedException)
            {
                _utils.ClickUsingJavascript(ParfumPage.DropDownByName(dropdownName));
            }
        }

        public void SelectOption(string optionName)
        {
            _utils.ClickUsingJavascript(ParfumPage.DropDownOptionByName(optionName));
        }

        public void SelectOptionFromDropdown(string dropdownName, string valueToSelect)
        {
            _utils.WaitForFewSeconds(5);
            if (_utils.GetElements(ParfumPage.MoreFiltersButton).Any())
            {
                _utils.ClickUsingJavascript(ParfumPage.MoreFiltersButton);
            }

            OpenDropdownByName(dropdownName);
            SelectOption(valueToSelect);
            _utils.WaitForPageLoad(TIMEOUT_IN_SECONDS);
            _utils.WaitUntilPresenceOfElement(ParfumPage.ApplicationMainLogo);
        }

        public void ResetFilters()
        {
            _utils.WaitUntilPresenceOfElement(ParfumPage.ResetFilterButton);

            if (!_utils.CheckIfElementIsVisible(ParfumPage.ResetFilterButton))
            {
                _utils.ScrollToElement(ParfumPage.ResetFilterButton);
            }

            _utils.ClickUsingJavascript(ParfumPage.ResetFilterButton);
        }

        public List<string> GetListOfAllProducts()
        {
            _utils.WaitUntilPresenceOfElement(ParfumPage.ProductInfoAllCards);
            List<string> products = new List<string>();

            _utils.ScrollToFooter();

            var elements = _utils.GetElements(ParfumPage.ProductInfoAllCards);
            foreach (var element in elements)
            {
                products.Add(element.Text);
            }

            return products;
        }

        public List<string> GetSelectedFiltersText() {
            List<string> selectedFilters = new List<string>();
            var elements = _utils.GetElements(ParfumPage.selectedFilterByClassName);
            foreach (var element in elements)
            {
                selectedFilters.Add(element.Text);
            }

            return selectedFilters;
        }

    }
}
