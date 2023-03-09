﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaarahFeb2023.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
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
            descriptionTextbox.SendKeys("Feb2023");

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
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
           
            Assert.That(newCode.Text == "SaarahFeb2023", "Actual code and expected code do not match.");
            Assert.That(newDescription.Text == "Feb2023", "Actual description and expected description do not match.");
            
            //if (newCode.Text == "SaarahFeb2023")
            //{
            //    Assert.Pass("New Time record created successful!");
            //}
            //else
            //{
            //    Assert.Fail("Record hasn't been created!");
            //}
        }

        public void EditTM(IWebDriver driver)
        {
            // Click on new Time record Edit Button and make changes
            Thread.Sleep(2000);
            IWebElement goToLastButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastButton.Click();

            IWebElement recordToBeEdited = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (recordToBeEdited.Text == "SaarahFeb2023")
            {

                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();

            }
            else
            {
                Assert.Fail("Record to be edited not found");
            }

            // Clear Description textbox and Input edited Description into textbox
            IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
            editDescriptionTextbox.Clear();
            editDescriptionTextbox.SendKeys("Edited by Saarah");

            // Click on save button 
            IWebElement saveButtonOnEditPage = driver.FindElement(By.Id("SaveButton"));
            saveButtonOnEditPage.Click();
            Thread.Sleep(2000);

            // Go to Last Page Button
            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton1.Click();
            Thread.Sleep(1000);

            // Identify Row that has been edited
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

            Assert.That(editedDescription.Text == "Edited by Saarah", "Record hasn't been edited.");
        }

        public void DeleteTM(IWebDriver driver)
        {
            // Code for Delete TM
            // Identify and Click on Last Page Button
            IWebElement goToLastButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastButton.Click();
            Thread.Sleep(1000);

            // Find the last record to be deleted
            IWebElement recordToBeDeleted = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (recordToBeDeleted.Text == "SaarahFeb2023")
            {

                // Finf anc Click on Delete button for edited Time record
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(2000);

            }
            else
            {
                Assert.Fail("Record to be deleted not found.");
            }

            // Click OK on Delete Confirmation Popup 
            IAlert deleteConfirmation = driver.SwitchTo().Alert();
            deleteConfirmation.Accept();
            Thread.Sleep(2000);

            IWebElement latestLastRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(latestLastRow.Text != "SaarahFeb2023", "Record hasn't been deleted");

        }
    }
}