using NUnit.Framework;
using October2023.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using October2023.Utilities;

namespace October2023.Tests
{
    [Parallelizable]
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObject = new TMPage();

        [SetUp]
        public void TimeSetUp()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            
            loginPageObj.LoginActions(driver);

            // Home page object initialization and deifinition
            
            homePageObj.GoToTMPage(driver);
        }

        [Test, Order (1), Description ("This test is creating a new Time record")]
        public void CreateTime_Test()
        {
            // TM Page object initialization and definition
            
            tmPageObject.Create_TimeRecord(driver);
        }
        
        [Test, Order (2), Description ("This test is editing an existing Time record")]
        public void EditTime_Test()
        {

            tmPageObject.Edit_TimeRecord(driver, "anything", "two", "three");
        }

        [Test, Order (3), Description ("This test is deleting an existing Time record")]
        public void DeleteTime_Test() 
        {
            tmPageObject.Delete_TimeRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
