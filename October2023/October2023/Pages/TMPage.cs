using October2023.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October2023.Pages
{
    public class TMPage
    {
        public void Create_TimeRecord(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"container\"]/p/a", 5);

            // Click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            // Select "Time" from typecode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            // Enter code into code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("October2023");

            // Enter description into description textbox
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("October2023Description");

            // Enter price into price per unit textbox
            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("12");

            // Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(4000);

            // Check if new record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "October2023")
            {
                Console.WriteLine("New record has been created successfully.");
            }
            else
            {
                Console.WriteLine("Record has not been created.");
            }

        }

        public void Edit_TimeRecord(IWebDriver driver)
        {
            // code that edits time record
        }

        public void Delete_TimeRecord(IWebDriver driver) 
        {
            // code that deletes time record
        }
    }
}
