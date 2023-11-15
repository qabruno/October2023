using NUnit.Framework;
using October2023.Pages;
using October2023.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace October2023.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);
        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // Home page object initialization and deifinition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new time record")]
        public void WhenICreateANewTimeRecord()
        {
            // TM Page object initialization and definition
            TMPage tmPageObject = new TMPage();
            tmPageObject.Create_TimeRecord(driver);
        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tmPageObject = new TMPage();

            string newCode = tmPageObject.GetCode(driver);
            string newDescription = tmPageObject.GetDescription(driver);
            string newPrice = tmPageObject.GetPrice(driver);

            Assert.That(newCode == "October2023", "New code and expected code do not match.");
            Assert.That(newDescription == "October2023", "New description and expected description do not match.");
            Assert.That(newPrice == "$12.00", "New price and expected price do not match.");
        }
    }
}
