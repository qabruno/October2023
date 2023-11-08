using October2023.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        //Open Chrome browser
        IWebDriver driver = new ChromeDriver(); //instance of a browser

        // Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        // Home page object initialization and deifinition
        HomePage homePageObj = new HomePage();
        homePageObj.GoToTMPage(driver);

        // TM Page object initialization and definition
        TMPage tmPageObject = new TMPage();
        tmPageObject.Create_TimeRecord(driver);

        // Edit TM
        tmPageObject.Edit_TimeRecord(driver);

        // Delete TM
        tmPageObject.Delete_TimeRecord(driver);
    }
}