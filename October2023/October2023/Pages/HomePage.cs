using October2023.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October2023.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            // Navigate to Time & Material module
            IWebElement administrationOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationOption.Click();

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);

            IWebElement timeAndMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeAndMaterial.Click();
        }

        public void GoToEmployeePage(IWebDriver driver)
        {

        }
    }
}
