using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using UITestProject.Pages;
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

            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.AddRemoveElementsLink.Click();

            outputHelper.WriteLine("- first click");
            var addRemoveElementsPage = new AddRemoveElementsPage(driver);
            addRemoveElementsPage.AddElementButton.Click();
            addRemoveElementsPage.WaitForDeleteButton();

            Assert.True(addRemoveElementsPage.DeleteButtons.Count == 1);

            outputHelper.WriteLine("- second click");
            addRemoveElementsPage.AddElementButton.Click();
            addRemoveElementsPage.WaitForDeleteButtonCount(2);

            Assert.True(addRemoveElementsPage.DeleteButtons.Count == 2);

            outputHelper.WriteLine("- second delete click");
            addRemoveElementsPage.DeleteButtons[1].Click();
            addRemoveElementsPage.WaitForDeleteButtonCount(1);

            Assert.True(addRemoveElementsPage.DeleteButtons.Count == 1);
        }
    }
}