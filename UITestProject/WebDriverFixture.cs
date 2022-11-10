using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

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
