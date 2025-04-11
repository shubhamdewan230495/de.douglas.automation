# de.douglas.automation
## Overview

This is a C# SpecFlow-based UI automation framework designed for testing douglas web application. The project leverages SpecFlow for BDD (Behavior-Driven Development), Selenium WebDriver for browser interaction, and follows the Page Object Model (POM) to promote code reusability and maintainability. Allure is used for reporting purpose.

## Project Structure

de.douglas.automation/ │ ├── Features/ # Contains Gherkin feature files describing test scenarios │ └── FilterVerification.feature │ ├── Hooks/ # Holds SpecFlow hook methods for setup/teardown events │ └── Hooks.cs │ ├── PageMethods/ # Contains logic implementations for page level common funtions │ ├── HomePageFeature.cs │ └── ParfumPageFeature.cs │ ├── PageObjects/ # Contains Page Object Model classes to encapsulate web elements and actions │ ├── HomePage.cs │ └── ParfumPage.cs │ ├── StepDefinitions/ # Step bindings that connect Gherkin steps to code │ ├── FiltersStepDefination.cs │ └── LandingPageDefination.cs │ ├── Support/ # Utility classes for browser management, config reading, and shared logic │ ├── BrowserFactory.cs │ ├── ConfigReader.cs │ └── Utils.cs │ ├── allureConfig.json # Configuration file for Allure test report generation ├── allureConfig.Template.json ├── appsettings.json # JSON config file for environment-specific test settings ├── ImplicitUsings.cs # Implicit using directives for simplified code ├── specflow.json # SpecFlow framework configuration settings └── README.md # Project documentation

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SpecFlow for Visual Studio](https://marketplace.visualstudio.com/items?itemName=SpecFlowTeam.SpecFlowForVisualStudio)
- [Dependencies to install from Nuget Manager] - Selenium Support, Chromedriver, EdgeDriver, Allure-Specflow, Configration Manager]

### Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/shubhamdewan230495/de.douglas.automation.git
    cd de.douglas.automation
    ```

2. Restore dependencies:
    ```bash
    dotnet restore
    ```

3. Build the project:
    ```bash
    dotnet build
    ```

---

## Running Tests

To execute tests using the default configuration:

```bash
dotnet test
```

```
for execution we can build in Visual studio and execute the code using Test Explorer too
```