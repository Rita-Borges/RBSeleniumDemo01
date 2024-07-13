using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemoT01;

public class BaseTest
{
    protected IWebDriver Driver;

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/"); 
        Driver.Manage().Window.Maximize();
    }
    [TearDown]
    public void CleanUp()
    {
        Driver.Close();   
    }
}