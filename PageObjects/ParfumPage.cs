using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.douglas.automation.PageObjects
{
    public class ParfumPage
    {
        private readonly IWebDriver _driver;
        public static string ParfumPageHeader = "//h1[text()='Parfüm & Düfte']";
        public static string ApplicationMainLogo = "[data-testid='tenant-logo-link']";
        public static string ResetFilterButton = "//button[text()='Alle Filter löschen']";
        public static string MoreFiltersButton = "//button[text()='Mehr Filter anzeigen']";
        public static string ProductInfoAllCards ="//div[@class='product-info']//div[contains(@class,'top-brand')]";
        public static String selectedFilterByClassName = "//button[contains(@class,'selected-facets__value')]";
        public static String parfumHeader = "//h1[text()='Parfüm & Düfte']";
        public static string DropDownByName(string dropdownName)
        {
            return $"//div[text()='{dropdownName}']/span";
        }

        public static string DropDownOptionByName(string optionName)
        {
            return $"//div[text()='{optionName}']/../preceding-sibling::span/span";
        }
        public ParfumPage(IWebDriver driver)
        {
            _driver = driver;
        }

    }
}
