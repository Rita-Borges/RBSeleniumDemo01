using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace SeleniumDemoT01;

public class Tests
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/"); 
        _driver.Manage().Window.Maximize();
    }

    [Test]
    public void Test1()
    {
        var linkElement = _driver.FindElement(By.XPath("//ul/li/a[text()='A/B Testing']"));      
        var actualTitle = linkElement.Text;
        var expectedTitle = "A/B Testing";
         
        Assert.That(actualTitle, Is.EqualTo(expectedTitle));
    }

    [TearDown]
    public void CleanUp()
    {
        _driver.Quit();   
    }
}