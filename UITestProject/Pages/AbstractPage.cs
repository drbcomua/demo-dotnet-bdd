using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
