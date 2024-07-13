using OpenQA.Selenium;

namespace SeleniumDemoT01;

public class Tests : BaseTest
{
    [Test]
    public void AbTesting()
    {
        //basic 
        var linkElement = Driver.FindElement(By.XPath("//ul/li/a[text()='A/B Testing']"));      
        var actualTitle = linkElement.Text;
        var expectedTitle = "A/B Testing";
        Assert.That(actualTitle, Is.EqualTo(expectedTitle));
    }
}