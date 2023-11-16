using NUnit.Framework;
using October2023.Pages;
using October2023.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October2023.Tests
{
    [Parallelizable]
    [TestFixture]
    public class Employee_Tests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        EmployeesPage employeesPageObj = new EmployeesPage();

        [SetUp]
        public void EmployeeSetUp()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            
            loginPageObj.LoginActions(driver);

            // Home page object initialization and deifinition
            
            homePageObj.GoToEmployeePage(driver);
        }

        [Test]
        public void Create_Employee_Test()
        {
            
            employeesPageObj.Create_Employee();
        }

        [Test]
        public void Edit_Employee_Test()
        {
            employeesPageObj.Edit_Employee();
        }

        [Test]
        public void Delete_Employee_Test()
        {
            employeesPageObj.Delete_Employee();
        }

        [TearDown]
        public void Closing()
        {
            driver.Quit();
        }
    }
}
