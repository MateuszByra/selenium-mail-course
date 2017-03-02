using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace EndToEndMailCourse._03
{
    [TestFixture]
    public class Workshop03Tests
    {
        private string testUrl = "https://suvroc.github.io/selenium-mail-course/03/workshop.html";

        [Test]
        public void ShouldCheckSelectedBookName()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);
   
            IWebElement book = null;

            #region TEST CODE
            book = driver.FindElement(By.CssSelector("body div.books > ul.list-group > li.book.selected > h4"));
            #endregion

            Assert.NotNull(book);
            Assert.AreEqual(book.TagName, "h4");
            Assert.AreEqual(book.Text, "MORT");

            driver.Quit();
        }

        [Test]
        public void ShouldCheckNumberOfBooks()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);

            IReadOnlyCollection<IWebElement> books = null;

            #region TEST CODE
            books = driver.FindElementsByCssSelector("body div.books > ul.list-group > li.book");
            #endregion

            Assert.NotNull(books);
            Assert.AreEqual(books.Count, 6);
            Assert.IsTrue(books.All(x => x.TagName == "li"));
            driver.Quit();
        }

        [Test]
        public void ShouldCheckLinksDomain()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);

            IReadOnlyCollection<IWebElement> links = null;

            #region TEST CODE
            //links = driver.FindElements(By.CssSelector("body div.books > ul.list-group > li a"));
            links = driver.FindElements(By.XPath("/html/body/div/div[2]/div/div/ul/li/h4/a"));
            #endregion

            Assert.NotNull(links);
            Assert.AreEqual(links.Count, 6);
            Assert.IsTrue(links.All(x => x.TagName == "a"));
            Assert.IsTrue(links.All(x => x.GetAttribute("href").StartsWith("https://www.terrypratchettbooks.com")));

            driver.Quit();
        }
    }
}
