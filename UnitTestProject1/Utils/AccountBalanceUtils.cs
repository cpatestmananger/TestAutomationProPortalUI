using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Threading;
using System.IO;

namespace ProPortal.Utils
{
    public static class AccountBalanceUtils
    {
        public static void selectPeriodType(RemoteWebDriver driver, int position)
        {
            IWebElement comboElement = driver.FindElementByCssSelector("md-input-container[class='md-input-has-value']");
                                                                                                                                    
            comboElement.Click();
            Thread.Sleep(2000);

            IWebElement menuElement = driver.FindElement(By.CssSelector("div[role=presentation][class='md-select-menu-container md-active md-clickable'][aria-hidden=false][role=presentation]"));

            var first = menuElement.FindElements(By.XPath(".//md-select-menu"));

            IWebElement second = first[0];

            var third = second.FindElements(By.CssSelector("md-option"));

            IWebElement element = third[position];

            element.Click();

            //element.Click();

            Thread.Sleep(2000);
        }

        public static void selectEmployee(RemoteWebDriver driver, int position)
        {

            IWebElement comboElement = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile/figure/webpart-frame/md-card/md-card-content/content/account-balance/div/div/custom-grid/div/md-toolbar/grid-filter/employee-selector");
            
            comboElement.Click();

            Thread.Sleep(1000);

            IWebElement menuElement = driver.FindElement(By.CssSelector("div[role=presentation][class='md-select-menu-container employee-select-dropdown md-active md-clickable'][aria-hidden=false][role=presentation]"));
                                                                                                       
             var first = menuElement.FindElements(By.XPath(".//md-select-menu"));

             IWebElement second = first[0];

             var third = second.FindElements(By.CssSelector("md-option"));

             IWebElement element = third[position];

             element.Click();             

            Thread.Sleep(2000);
        }

        public static void checkBalance(RemoteWebDriver driver, string balance)
        {
            bool found = false;
            IWebElement tableElement = driver.FindElement(By.CssSelector("table[role='grid'][data-role='selectable'][class='k-selectable']"));

            var cells = tableElement.FindElements(By.CssSelector("td[role='gridcell'][class='align-right']"));
            Thread.Sleep(1000);
            foreach (IWebElement cell in cells)
            {
                IWebElement textElement = cell.FindElement(By.XPath(".//*"));

                if (textElement.Text == balance)
                {
                    found = true;
                    textElement.Click();
                    break;
                }
            }
            Assert.AreEqual(found, true);
        }
    }
}
