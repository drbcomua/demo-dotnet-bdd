using OpenQA.Selenium;

namespace UITestProject.Pages
{
    public class HomePage : AbstractPage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public IWebElement AddRemoveElementsLink => driver.FindElement(By.LinkText("Add/Remove Elements"));

        public void Open()
        {
            driver
                .Navigate()
                .GoToUrl("https://the-internet.herokuapp.com/");
        }
    }
}
