using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


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

// Create a new Time record

// Navigate to Time and Material page
IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
administrationDropdown.Click();

IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
tmOption.Click();
Thread.Sleep(1000);

// Click on Create New button
IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
createNewButton.Click();
Thread.Sleep(1000);

// Select Time option from TypeCode dropdown list
IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
typeCodeDropdown.Click();
Thread.Sleep(1000);

IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]")); 
timeOption.Click();


// Input code into Code textbox
IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
codeTextbox.SendKeys("SaarahFeb2023");

// Input description into Description textbox
IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
descriptionTextbox.SendKeys("SaarahFeb2023");

// Input Price per Unit into price per unit textbox
IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
priceTextbox.SendKeys("65");

// Click on save button
IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
saveButton.Click();
Thread.Sleep(2000);

// Check if new Time record has been created
IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")); 
goToLastPageButton.Click();
Thread.Sleep(2000);

IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

if (newCode.Text == "SaarahFeb2023")
{
Console.WriteLine("New Time record created successful!");
}
else
{
    Console.WriteLine("Record hasn't been created!");
}

// Click on new Time record Edit Button 
IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
editButton.Click();

// Input edited Description into Description textbox
IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
editDescriptionTextbox.Clear();
editDescriptionTextbox.SendKeys("Edited by Saarah");

// Click on save button 
IWebElement saveButtonOnEditPage = driver.FindElement(By.Id("SaveButton"));
saveButtonOnEditPage.Click();
Thread.Sleep(2000);

// Check if new Time record Description has been edited
IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPageButton1.Click();

IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

if (editedDescription.Text == "Edited by Saarah")
{
    Console.WriteLine("Edited Time record successfully!");
}
else
{
    Console.WriteLine("Unable to Edit record!");
}

// Delete edited Time record
IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
deleteButton.Click();

// Click OK on Delete Confirmation Popup 
IAlert deleteConfirmation = driver.SwitchTo().Alert();
deleteConfirmation.Accept();

Console.WriteLine("Deleted edited Time record!");

