using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UITestProject
{
    public sealed class WebDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }
        public WebDriverFixture()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new();
            options.AddArguments("--headless");
            Driver = new ChromeDriver(options);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
