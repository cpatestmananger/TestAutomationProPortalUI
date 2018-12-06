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

namespace TestProReportIII.Utils
{
    public static class WizardUtils     
    {
        public static void setExpiryDate(RemoteWebDriver driver, String date)
        {
            IWebElement ExpiryDateClass = driver.FindElementByCssSelector(".k-picker-wrap.k-state-default");
            ExpiryDateClass.Click();
            IWebElement ExpiryDateField = ExpiryDateClass.FindElement(By.XPath(".//input"));
            ExpiryDateField.Clear();
            ExpiryDateField.SendKeys(date);
        }

        public static void clickNextExpiry(RemoteWebDriver driver)
        {
            IWebElement NextButton = driver.FindElementByCssSelector(".md-raised.md-button.ng-scope.md-ink-ripple");
            NextButton.Click();
            Thread.Sleep(1000);
        }

        public static void setPeriodStart(RemoteWebDriver driver, String period)
        {        
            IWebElement fromDateField = driver.FindElementByCssSelector("input[name='periodFrom']");
            fromDateField.Clear();
            fromDateField.SendKeys(period);
        }

        public static void setPeriodEnd(RemoteWebDriver driver, String period)
        {
            IWebElement toDate = driver.FindElementByCssSelector("input[name='periodTo']");
            toDate.Clear();
            toDate.SendKeys(period);
        }

        public static void setDescription(RemoteWebDriver driver, String description)
        {
            IWebElement descriptionField = driver.FindElementByCssSelector("input[name='description']");
            descriptionField.Clear();
            descriptionField.SendKeys(description);
        }


        public static void clickNextPeriod(RemoteWebDriver driver)
        {
            var buttons = driver.FindElementsByCssSelector(".md-raised.md-button.ng-scope.md-ink-ripple");
            foreach (IWebElement button in buttons)
            {
                if (button.Text == "NEXT") button.Click();
            }
        }

        public static void setPeriodValuesSwitch(RemoteWebDriver driver)
        {
            IWebElement spans = driver.FindElementByXPath("//span[contains(text(),'Use timequeue changes')]");
            spans.Click();
        }

        public static void setEmployeeFilter(RemoteWebDriver driver, String filterValue)
        {
            Thread.Sleep(1000);
            var spans = driver.FindElementsByCssSelector(".md-tab.ng-scope.ng-isolate-scope.md-ink-ripple");

            foreach (IWebElement span in spans)
            {
                if (span.Text == "EMPLOYEE") span.Click();
            }

            Thread.Sleep(1000);
            var searchFields = driver.FindElementsByCssSelector("input[type='search']");
            Thread.Sleep(1000);
            foreach (IWebElement searchField in searchFields)
            {
                if ((searchField.Displayed == true) && (searchField.Enabled == true))
                {
                    searchField.SendKeys(filterValue);
                    searchField.SendKeys(Keys.ArrowUp);
                    Thread.Sleep(1000);
                    searchField.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                }
            }
        }

        public static void setAbsenceReasonFilter(RemoteWebDriver driver, String filterValue)
        {
            var spans = driver.FindElementsByCssSelector(".md-tab.ng-scope.ng-isolate-scope.md-ink-ripple");
            foreach (IWebElement span in spans)
            {
                if (span.Text == "ABSENCE REASON") span.Click();
            }
            Thread.Sleep(1000);
            var searchFields = driver.FindElementsByCssSelector("input[type='search']");
            Thread.Sleep(1000);
            foreach (IWebElement searchField in searchFields)
            {
                if ((searchField.Displayed == true) && (searchField.Enabled == true))
                {
                    searchField.SendKeys(filterValue);
                    searchField.SendKeys(Keys.ArrowUp);
                    Thread.Sleep(1000);
                    searchField.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                }
            }
        }

        public static void setOrderFilter(RemoteWebDriver driver, String filterValue)
        {
            var spans = driver.FindElementsByCssSelector(".md-tab.ng-scope.ng-isolate-scope.md-ink-ripple");
            foreach (IWebElement span in spans)
            {
                if (span.Text == "ORDER/OPERATION") span.Click();
            }
            Thread.Sleep(1000);
            var searchFields = driver.FindElementsByCssSelector("input[type='search']");
            Thread.Sleep(1000);
            foreach (IWebElement searchField in searchFields)
            {
                if ((searchField.Displayed == true) && (searchField.Enabled == true))
                {
                    searchField.SendKeys(filterValue);
                    searchField.SendKeys(Keys.ArrowUp);
                    Thread.Sleep(1000);
                    searchField.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                }
            }
        }


        public static void setWorkcenterFilter(RemoteWebDriver driver, String filterValue)
        {
            var spans = driver.FindElementsByCssSelector(".md-tab.ng-scope.ng-isolate-scope.md-ink-ripple");
            foreach (IWebElement span in spans)
            {
                if (span.Text == "WORKCENTER") span.Click();
            }
            Thread.Sleep(1000);
            var searchFields = driver.FindElementsByCssSelector("input[type='search']");
            Thread.Sleep(1000);
            foreach (IWebElement searchField in searchFields)
            {
                if ((searchField.Displayed == true) && (searchField.Enabled == true))
                {
                    searchField.SendKeys(filterValue);
                    searchField.SendKeys(Keys.ArrowUp);
                    Thread.Sleep(1000);
                    searchField.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                }
            }
        }


        public static void setAccountFilter(RemoteWebDriver driver, String filterValue)
        {
            var spans = driver.FindElementsByCssSelector(".md-tab.ng-scope.ng-isolate-scope.md-ink-ripple");
            foreach (IWebElement span in spans)
            {
                if (span.Text == "ACCOUNT") span.Click();
            }
            Thread.Sleep(1000);
            var searchFields = driver.FindElementsByCssSelector("input[type='search']");
            Thread.Sleep(1000);
            foreach (IWebElement searchField in searchFields)
            {
                if ((searchField.Displayed == true) && (searchField.Enabled == true))
                {
                    searchField.SendKeys(filterValue);
                    searchField.SendKeys(Keys.ArrowUp);
                    Thread.Sleep(2000);
                    searchField.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                }
            }
        }

        public static void setProjectFilter(RemoteWebDriver driver, String filterValue)
        {
            var spans = driver.FindElementsByCssSelector(".md-tab.ng-scope.ng-isolate-scope.md-ink-ripple");
            foreach (IWebElement span in spans)
            {
                if (span.Text == "PROJECT") span.Click();
            }
            Thread.Sleep(1000);
            var searchFields = driver.FindElementsByCssSelector("input[type='search']");
            Thread.Sleep(1000);
            foreach (IWebElement searchField in searchFields)
            {
                if ((searchField.Displayed == true) && (searchField.Enabled == true))
                {
                    searchField.SendKeys(filterValue);
                    searchField.SendKeys(Keys.ArrowUp);
                    Thread.Sleep(1000);
                    searchField.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                }
            }
        }

        public static void setTerminalFilter(RemoteWebDriver driver, String filterValue)
        {
            var spans = driver.FindElementsByCssSelector(".md-tab.ng-scope.ng-isolate-scope.md-ink-ripple");
            foreach (IWebElement span in spans)
            {
                if (span.Text == "TERMINAL") span.Click();
            }
            Thread.Sleep(1000);
            var searchFields = driver.FindElementsByCssSelector("input[type='search']");
            Thread.Sleep(1000);
            foreach (IWebElement searchField in searchFields)
            {
                if ((searchField.Displayed == true) && (searchField.Enabled == true))
                {
                    searchField.SendKeys(filterValue);
                    searchField.SendKeys(Keys.ArrowUp);
                    Thread.Sleep(1000);
                    searchField.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                }
            }
        }

        public static void clickRunFilter(RemoteWebDriver driver)
        {
           
            IWebElement RunButton2 = driver.FindElementByCssSelector("button[ng-click='vm.runReport()']");
            RunButton2.Click();
        }

        public static void selectExportFormat(RemoteWebDriver driver, String format)
        {
            IWebElement formatSelector = driver.FindElementByCssSelector("md-select[ng-model='vm.export.format']");
            formatSelector.Click();
            Thread.Sleep(2000);
            if (format == "CSV") {
                IWebElement CSVSelector = driver.FindElementByCssSelector("md-option[ng-value='901']");
                CSVSelector.Click();
                Thread.Sleep(2000);
            }
        }

        public static void setReportName(RemoteWebDriver driver, String reportName)
        {
            IWebElement nameField = driver.FindElementByCssSelector("input[name='exportSaveTo']");
            nameField.SendKeys(reportName);
            Thread.Sleep(1000);            
        }
    }
}

