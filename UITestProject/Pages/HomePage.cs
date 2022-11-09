using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
