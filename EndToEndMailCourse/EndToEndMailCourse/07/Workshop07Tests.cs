using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace EndToEndMailCourse._07
{
    [TestFixture]
    public class Workshop07Tests
    {
        private string testUrl = "https://suvroc.github.io/selenium-mail-course/07/workshop.html";

        [Test]
        public void ShouldSelectAnswers()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);

            var companySelectElement = driver.FindElement(By.Id("companySelect"));
            var carSelectElement = driver.FindElement(By.Id("carSelect"));

            #region TEST CODE
        
            var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var bmwSelector = new SelectElement(companySelectElement);
 
            bmwSelector.SelectByValue("bmw");

            var carSelector = new SelectElement(waiter.Until(ExpectedConditions.ElementToBeClickable(carSelectElement)));

            carSelector.SelectByValue("sedan");

            waiter.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("tridots")));
            #endregion

            Assert.AreEqual(driver.FindElements(By.ClassName("list-group-item")).Count(), 6);


            driver.Quit();
        }
    }
}
