using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace TicketsAutoTest
{
    public class HomePage : IDisposable
    {
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            // Initialize the ChromeDriver
            driver = new ChromeDriver();
        }

        [Test]
        public void OpenHomePage()
        {
            // Navigate to the home page
            driver.Navigate().GoToUrl("https://ghticketdemo.azurewebsites.net/");

            // Assert that the title is correct
            Assert.AreEqual("Home Page - TicketManagement", driver.Title);
        }

        [Test]
        public void CheckStatusDropdownValues()
        {
            // Navigate to the Create Ticket page
            driver.Navigate().GoToUrl("https://ghticketdemo.azurewebsites.net/Tickets/Create");

            // Find the status dropdown element
            var statusDropdown = driver.FindElement(By.Id("Status"));

            // Click on the dropdown to open it
            statusDropdown.Click();

            // Find all the options in the dropdown
            var options = statusDropdown.FindElements(By.TagName("option")).Select(option => option.Text).ToList();

            // Expected values in the status dropdown
            var expectedValues = new List<string> { "Open", "In Progress", "Closed" };

            // Assert that the dropdown contains the expected values
            CollectionAssert.AreEquivalent(expectedValues, options);
        }
        [Test]
        public void CreateNewTicket()
        {
            // Navigate to the Create Ticket page
            driver.Navigate().GoToUrl("https://ghticketdemo.azurewebsites.net/Tickets/Create");

            // Find and fill in the Title field
            var titleField = driver.FindElement(By.Id("Title"));
            titleField.SendKeys("Test Ticket");

            // Find and fill in the Description field
            var descriptionField = driver.FindElement(By.Id("Description"));
            descriptionField.SendKeys("This is a test ticket created by Selenium.");

            // Find and select a value from the Status dropdown
            var statusDropdown = driver.FindElement(By.Id("Status"));
            var statusOption = statusDropdown.FindElement(By.XPath("//option[. = 'Open']"));
            statusOption.Click();

            // Find and select a value from the Priority dropdown
            var priorityDropdown = driver.FindElement(By.Id("Priority"));
            var priorityOption = priorityDropdown.FindElement(By.XPath("//option[. = 'High']"));
            priorityOption.Click();

            // Find and click the Submit button
            var submitButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();

            // Optionally, you can add assertions to verify the ticket was created successfully
            // For example, check if the page redirects to the ticket list or shows a success message
            var successMessage = driver.FindElement(By.CssSelector(".alert-success"));
            Assert.IsNotNull(successMessage, "Ticket was not created successfully.");
        }       


        [TearDown]
        public void Teardown()
        {
            // Dispose the driver
            driver.Dispose();
        }

        public void Dispose()
        {
            driver?.Dispose();
        }
    }
}
