using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


// Open Chrome Browser

IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();

// Launch turnup portal
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

// Identify the username textbox and enter valid username
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

// Identify the password textbox and enter valid password
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

// Identify login button and click on it
IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginButton.Click();

// Check if user has successfully logged in
IWebElement Hellohari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

if(Hellohari.Text == "Hello hari!")
{
    Console.WriteLine("Logged in successfully!");
}
else
{
    Console.WriteLine("Login failed!");
}
