using TechTalk.SpecFlow;
using UITestProject.Pages;
using Xunit.Abstractions;

namespace UITestProject.Steps
{
    [Binding]
    public class AddRemoveElementsStepDefinitions : IClassFixture<WebDriverFixture>
    {
        private readonly ITestOutputHelper outputHelper;
        private readonly HomePage homePage;
        private readonly AddRemoveElementsPage addRemoveElementsPage;

        public AddRemoveElementsStepDefinitions(WebDriverFixture webDriverFixture, ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
            var driver = webDriverFixture.ChromeDriver;
            this.homePage = new HomePage(driver);
            this.addRemoveElementsPage = new AddRemoveElementsPage(driver);
        }

        [Given("I opened Add Remove Elements Page")]
        public void IOpenedAddRemoveElementsPage()
        {
            outputHelper.WriteLine("iOpenedAddRemoveElementsPage");

            homePage.Open();
            homePage.AddRemoveElementsLink.Click();
        }

        [Given("I click Add Elements button")]
        [When("I click Add Elements button")]
        public void IClickAddElementsButton()
        {
            outputHelper.WriteLine("iClickAddElementsButton");

            addRemoveElementsPage.AddElementButton.Click();
            addRemoveElementsPage.WaitForDeleteButton();
        }

        [Then("New Delete button appears on page")]
        public void NewDeleteButtonAppearsOnPage()
        {
            Assert.True(addRemoveElementsPage.DeleteButtons.Count == 1);
        }

        [When(@"I click on Delete button")]
        public void WhenIClickOnDeleteButton()
        {
            addRemoveElementsPage.DeleteButtons[0].Click();
            addRemoveElementsPage.WaitForDeleteButtonCount(0);
        }

        [Then(@"Delete button disappears")]
        public void ThenDeleteButtonDisappears()
        {
            Assert.True(addRemoveElementsPage.DeleteButtons.Count == 0);
        }
    }
}
