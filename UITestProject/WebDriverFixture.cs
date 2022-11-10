using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UITestProject
{
    public sealed class WebDriverFixture : IDisposable
    {
        public ChromeDriver ChromeDriver { get; private set; }
        public WebDriverFixture()
        {
            var driver = new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver = new ChromeDriver(driver);
        }

        public void Dispose()
        {
            ChromeDriver.Quit();
            ChromeDriver.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
