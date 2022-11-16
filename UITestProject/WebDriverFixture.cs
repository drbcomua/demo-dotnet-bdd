﻿using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UITestProject
{
    public sealed class WebDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }
        public WebDriverFixture()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            FirefoxOptions options = new();
            options.AddArguments("--headless");
            Driver = new FirefoxDriver(options);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
