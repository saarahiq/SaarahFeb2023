using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SaarahFeb2023.Pages;
using SaarahFeb2023.Utilities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TechTalk.SpecFlow;

namespace SaarahFeb2023.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver 
    {
        // Page Objects initialization
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();


        [Given(@"I logged into tunrup portal successfully")]
        public void GivenILoggedIntoTunrupPortalSuccessfully()
        {
            // Open chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            loginPageObj.LoginActions(driver);

        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // TM page object initilalization and definition
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new time and material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            tmPageObj.CreateTM(driver);
        }

        [Then(@"The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            string newCode = tmPageObj.GetCode(driver);
            string newDescription = tmPageObj.GetDescription(driver);
            string newPrice = tmPageObj.GetPrice(driver);

            Assert.That(newCode == "SaarahFeb2023", "Actual code and expected code do not match.");
            Assert.That(newDescription == "Feb2023", "Actual description and expected description do not match.");
            Assert.That(newPrice == "65", "Actual price and expected price do not match.");
        }
        [When(@"I update '([^']*)' on an existing time and material record")]
        public void WhenIUpdateOnAnExistingTimeAndMaterialRecord(string description)
        {
            tmPageObj.EditTM(driver, description);
        }

        [Then(@"The record should have the updated '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string description)
        {

        }

    }
}
