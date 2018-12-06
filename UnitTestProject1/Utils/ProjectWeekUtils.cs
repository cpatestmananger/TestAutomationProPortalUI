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
    public static class ProjectWeekUtils
    {
        public static void selectButton(RemoteWebDriver driver, String type)

        {
            IWebElement webPart = driver.FindElement(By.CssSelector("project-week[webpart='part']"));
            var buttons = webPart.FindElements(By.CssSelector("button"));            
            foreach (IWebElement button in buttons)
            {
                IWebElement textElement = button.FindElement(By.CssSelector("label"));
                if (textElement.Text == type)
                {
                    textElement.Click();
                    break;
                }
            }
        }

        public static void setProject(RemoteWebDriver driver, String name)

        {
            IWebElement projectInput = driver.FindElement(By.CssSelector("input[type='tel'][aria-label='Project'][role='combobox'][required='required']"));
            projectInput.SendKeys(name);
            Thread.Sleep(1000);
            projectInput.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);
            projectInput.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }

        public static void setActivity(RemoteWebDriver driver, String activity)

        {
            IWebElement projectInput = driver.FindElement(By.CssSelector("input[type='tel'][aria-label='Activity'][role='combobox'][required='required']"));
            projectInput.SendKeys(activity);
            Thread.Sleep(1000);
            projectInput.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);
            projectInput.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }


        public static void setTimeType(RemoteWebDriver driver, String activity)
        {
            IWebElement projectInput = driver.FindElement(By.CssSelector("input[type='tel'][aria-label='Time type'][role='combobox'][required='required']"));
            projectInput.SendKeys(activity);
            Thread.Sleep(1000);
            projectInput.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);
            projectInput.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }

        public static void setHoursByDay(RemoteWebDriver driver, String hours, String day)
        {
            var tabItems = driver.FindElements(By.CssSelector("md-tab-item"));

            foreach (IWebElement tabItem in tabItems)
            {                
                if (tabItem.Text == (day.ToUpper()))
                {
                    IWebElement inputText = tabItem.FindElement(By.CssSelector("input[type='text']"));
                    inputText.Clear();
                    inputText.SendKeys(hours);
                    break;
                }
            }

        }

        public static void clickSaveButton(RemoteWebDriver driver)
        {
            IWebElement projectInput = driver.FindElement(By.CssSelector("button[class='md-raised btn-primary md-button md-ink-ripple']"));
            projectInput.Click();
        }

        public static void selectRegistrationByProject(RemoteWebDriver driver, String project)
        {
            
            var columnsContent = driver.FindElements(By.CssSelector("div[class='columnContentLeft']"));
            foreach (IWebElement column in columnsContent)
            {
                IWebElement textElement = column.FindElement(By.CssSelector("div"));
                if (textElement.Text == project)
                {
                    textElement.Click();
                    break;
                }
            }
        }

        public static void confirmDelete(RemoteWebDriver driver)
        {
            IWebElement dialogContents = driver.FindElement(By.CssSelector("md-dialog[class='mi-dialog delete-project-registration-dialog _md md-transition-in loading-complete']"));
            var buttons = dialogContents.FindElements(By.CssSelector("button[type='button']"));
            foreach (IWebElement button in buttons)
            {               
                if (button.Text.ToLower() == "delete")
                {
                    button.Click();
                    break;
                }
            }

        }

    }
}
