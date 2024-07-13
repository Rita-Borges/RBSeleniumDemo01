using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

namespace SeleniumDemoT01
{
    public class T02AddRemoveElements : BaseTest
    {
        [Test]
        public void AddOneElementAndRemoveIt()
        {
            //  XPath expression
            var linkAddOrRemoveElements = Driver.FindElement(By.XPath("//ul/li/a[text()='Add/Remove Elements']"));
            linkAddOrRemoveElements.Click();

            // Wait for the page to load
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); // Increase timeout to ensure page load
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='content']/h3[text()='Add/Remove Elements']"))); 

            // Check for the presence of "Add Element" button specific to the Add/Remove Elements page
            var addElementButton = Driver.FindElement(By.XPath("//button[text()='Add Element']"));
            Assert.IsNotNull(addElementButton, "Add Element button is not present on the Add/Remove Elements page.");

            // Click the "Add Element" button to add a new element
            addElementButton.Click();

            // Validate the new element is added
            var addedElement = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("added-manually")));
            Assert.IsNotNull(addedElement, "Added element is not present on the page.");

            // Optionally, remove the element and verify it is removed
            var deleteButton = addedElement.FindElement(By.XPath("//button[text()='Delete']"));
            deleteButton.Click();

            // Validate the element is removed
            wait.Until(ExpectedConditions.StalenessOf(addedElement));
            Assert.Throws<NoSuchElementException>(() => Driver.FindElement(By.ClassName("added-manually")));
        }
    }
}