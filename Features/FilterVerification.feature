Feature: Parfum Tab Filters Verification

Scenario: Verification of filters on the parfum tab
    Given I navigate to the home page
    And I click "Allow All" on the consent modal
    When I go to the parfum tab
    And I select "<Produktart>" from the "Produktart" dropdown
    And I select "<FürWen>" from the "Für Wen" dropdown
    And I select "<GeschenkFur>" from the "Geschenk für" dropdown
    Then I should see the filters "<Produktart>","<FürWen>" and "<GeschenkFur>" are applied and product list is appearing
    Then I reset the filters

    Examples:
            | Produktart | FürWen   | GeschenkFur |
            | Parfum     | Unisex   | Geburtstag  |
            | Duftset    | Männlich | Ostern   |

Scenario: Verification of reset filter functionality on the parfum tab
    Given I navigate to the home page
    And I click "Allow All" on the consent modal
    When I go to the parfum tab
    And I select "<Produktart>" from the "Produktart" dropdown
    Then I should see the filter "<Produktart>" is applied and product list is appearing
    Then I reset the filters
    And Validate no filter should be applied now

    Examples:
            | Produktart |
            | Parfum     |