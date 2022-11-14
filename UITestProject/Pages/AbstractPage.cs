using OpenQA.Selenium;

namespace UITestProject.Pages
{
    public abstract class AbstractPage
    {
        public readonly IWebDriver driver;

        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
