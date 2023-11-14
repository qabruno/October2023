using NUnit.Framework;
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
            descriptionTextbox.SendKeys("October2023");

            // Enter price into price per unit textbox
            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("12");

            // Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(4000);

            // Check if new record has been created successfully
            try
            {
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                goToLastPageButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Go to last page button hasn't been found.", ex.Message);
            }
            

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(newCode.Text == "October2023", "New code and expected code do not match.");
            Assert.That(newTypeCode.Text == "T", "New TypeCode and expected TypeCode do not match.");
            Assert.That(newDescription.Text == "October2023", "New description and expected description do not match.");
            Assert.That(newPrice.Text == "$12.00", "New price and expected price do not match.");

        }
        public void Edit_TimeRecord(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton1.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 10);

            IWebElement recordCreated = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if(recordCreated.Text == "October2023")
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found.");
            }

            Wait.WaitToExist(driver, "Id", "Code", 10);


            //Edit code in the code text box
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("tanuEdit");


            //Edit discription in discription text box
            IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
            editDescriptionTextbox.Clear();
            editDescriptionTextbox.SendKeys("testEditDis");

            //Edit price per unit in price per unit textbox

            //Thread.Sleep(6000);

            IWebElement editPriceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            //editPriceTextbox.Clear();
            editPriceTextbox.SendKeys("200");

            //Thread.Sleep(6000);

            //Save edit data by clicking Save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();

            Thread.Sleep(6000);
            //Check if record has been edited sucessfully (change the xpath according to the record we created)

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);

            IWebElement goToLastPageButtonEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonEdit.Click();


            Wait.WaitToExist(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 10);

            IWebElement newEditCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(newEditCode.Text == "tanuEdit", "The record edit function is unsucussfull");

     

        }

        public void Delete_TimeRecord(IWebDriver driver)
        {
            //Delete record from Time and Material page

            Thread.Sleep(3000);
            IWebElement goToLastPageButtonEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonEdit.Click();

            IWebElement editedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if(editedRecord.Text == "tanuEdit")
            {
                Thread.Sleep(3000);
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
            }
            else
            {
                Assert.Fail("Record to be deleted has not been found.");
            }


            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(2000);

            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(deletedCode.Text != "tanuEdit", "Record has not been deleted.");


        }
    }
}
