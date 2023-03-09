using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SaarahFeb2023.Pages;
using SaarahFeb2023.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaarahFeb2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Employee_Tests : CommonDriver
    {
        // Page objects initilaization
        EmployeePage employeePageObj = new EmployeePage();
        HomePage homePageObj = new HomePage();


        [Test, Order(1), Description("Check if user is able to Create Employee record with valid data")]
        public void CreateEmployeeTest()
        {
        homePageObj.GoToEmployeesPage(driver);
        employeePageObj.CreateEmployee(driver);
        } 

        [Test, Order(2), Description("Check if user is able to Edit an existing record with valid data")]
        public void EditEmployeeTest()
        {
        homePageObj.GoToEmployeesPage(driver);
        employeePageObj.EditEmployee(driver);
        }

        [Test, Order(3), Description("Check if user is able to Delete an existing Employee record")]
        public void DeleteEmployeeTest()
        {
        homePageObj.GoToEmployeesPage(driver);
        employeePageObj.DeleteEmployee(driver);
        }

        [TearDown]
        public void ClosingSteps()
        {
            driver.Quit();
        }

    }
}
