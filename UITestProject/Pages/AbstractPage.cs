using OpenQA.Selenium;

namespace UITestProject.Pages
{
    public abstract class AbstractPage
    {
        public readonly IWebDriver driver;

        public AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
