using October2023.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October2023.Pages
{
    public class LoginPage
    {
        public void LoginActions(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();

            //Launch TurnUp portal and navigate to the website login page
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");
            Thread.Sleep(6000);
            Wait.WaitToExist(driver, "Id", "UserName", 8);

            //Identify username textbox and enter valid username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            //Identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            //Identify login button and click on the button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
        }
    }
}
