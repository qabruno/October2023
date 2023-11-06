using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//Open Chrome browser
IWebDriver driver = new ChromeDriver(); //instance of a browser
driver.Manage().Window.Maximize();

//Launch TurnUp portal and navigate to the website login page
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");

//Identify username textbox and enter valid username
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

//Identify password textbox and enter valid password
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

//Identify login button and click on the button
IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginButton.Click();

//Check if user logged in successfully
IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

if (helloHari.Text == "Hello hari!")
{
    Console.WriteLine("User has logged in successfully");
}
else
{
    Console.WriteLine("User hasn't been logged in.");
}