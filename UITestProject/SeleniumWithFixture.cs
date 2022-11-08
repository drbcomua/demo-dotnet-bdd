using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Abstractions;

namespace UITestProject
{
    public class SeleniumWithFixture : IClassFixture<WebDriverFixture>
    {
        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper outputHelper;

        public SeleniumWithFixture(WebDriverFixture webDriverFixture, ITestOutputHelper outputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.outputHelper = outputHelper;
        }

        [Fact]
        public void AddRemoveElementsTest()
        {
            var driver = webDriverFixture.ChromeDriver;
            outputHelper.WriteLine("FillDataTest");
            driver
                .Navigate()
                .GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");

            outputHelper.WriteLine("- first click");
            var addElementButton = driver.FindElement(By.XPath("//*[@id=\"content\"]/div/button"));
            addElementButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.CssSelector(".added-manually")));

            var elements = driver.FindElements(By.CssSelector(".added-manually"));
            Assert.True(elements.Count == 1);

            outputHelper.WriteLine("- second click");
            addElementButton.Click();

            wait.Until(e => e.FindElements(By.CssSelector(".added-manually")).Count > 1);

            elements = driver.FindElements(By.CssSelector(".added-manually"));
            Assert.True(elements.Count == 2);

            var secondDeleteButton = driver.FindElement(By.XPath("//*[@id=\"elements\"]/button[2]"));
            outputHelper.WriteLine("- second delete click");
            secondDeleteButton.Click();

            wait.Until(e => e.FindElements(By.CssSelector(".added-manually")).Count < 2);

            elements = driver.FindElements(By.CssSelector(".added-manually"));
            Assert.True(elements.Count == 1);
        }
    }
}