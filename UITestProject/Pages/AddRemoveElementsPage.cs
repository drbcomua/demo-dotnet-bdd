using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestProject.Pages
{
    public class AddRemoveElementsPage : AbstractPage
    {
        public AddRemoveElementsPage(IWebDriver driver) : base(driver) { }

        public IWebElement AddElementButton => driver.FindElement(By.XPath("//*[@id=\"content\"]/div/button"));
        public ReadOnlyCollection<IWebElement> DeleteButtons => driver.FindElements(By.CssSelector(".added-manually"));

        public void WaitForDeleteButton()
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElement(By.CssSelector(".added-manually")));
        }

        public void WaitForDeleteButtonCount(int num)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElements(By.CssSelector(".added-manually")).Count == num);
        }
    }
}
