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
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void TimeSetUp()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            // Home page object initialization and deifinition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [Test]
        public void CreateTime_Test()
        {
            // TM Page object initialization and definition
            TMPage tmPageObject = new TMPage();
            tmPageObject.Create_TimeRecord(driver);
        }

        [Test]
        public void EditTime_Test()
        {
            TMPage tmPageObject = new TMPage();
            // Edit TM
            tmPageObject.Edit_TimeRecord(driver);
        }

        [Test]
        public void DeleteTime_Test() 
        {
            TMPage tmPageObject = new TMPage();
            // Delete TM
            tmPageObject.Delete_TimeRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
