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
    public static class RegistrationUtils
    {
        public static void pushTransactionListKey(RemoteWebDriver driver)
        {
            IWebElement TransactionListButton = driver.FindElementByCssSelector("button[type='button'][aria-label='Print dialogue']");
            //*[@id="main-content"]/div/ui-view/features-orchestration/md-grid-list/md-grid-tile/figure/webpart-frame/md-card/md-card-content/content/registration/md-content/keyboard-prompt/div/div[7]/button
            TransactionListButton.Click();
            Thread.Sleep(2000);  
        }

        public static void enterPinTransactionList(RemoteWebDriver driver, String PIN)
        {
            IWebElement PinField = driver.FindElementByCssSelector("input[name='inputText'][type='password'][ng-model='vm.inputText']");
            PinField.SendKeys(PIN);
            
            IWebElement OKButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/registration/md-content/standard-input-prompt/div/md-toolbar/button[2]");
            OKButton.Click();

            Thread.Sleep(2000); 
        }

        public static void selectReportTypeTransactionList(RemoteWebDriver driver, String text)
        {
            IWebElement SearchField = driver.FindElementByCssSelector("input[name='searchValue'][ng-model='vm.searchValue']");
            SearchField.SendKeys(text);
            Thread.Sleep(1000);

            IWebElement OKButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/registration/md-content/select-list-by-id-prompt/div/md-toolbar/button[2]"); 
            OKButton.Click();
            Thread.Sleep(1000);

        }

        public static void enterFirstDateTransactionList(RemoteWebDriver driver, String date)
        {
            /* IWebElement firstDate = driver.FindElementByCssSelector("input[name='searchValue'][ng-model='vm.searchValue']");
            firstDate.SendKeys(date);
            Thread.Sleep(1000);*/


            IWebElement OKButton = driver.FindElementByCssSelector("button[type='button'][aria-label='OK']");
            OKButton.Click();

            Thread.Sleep(1000);
        }

       

        public static void enterLastDateTransactionList(RemoteWebDriver driver, String date)
        {
            /*   IWebElement firstDate = driver.FindElementByCssSelector("input[name='searchValue'][ng-model='vm.searchValue']");
               firstDate.SendKeys(date);
               Thread.Sleep(1000);*/

            IWebElement OKButton = driver.FindElementByCssSelector("button[type='button'][aria-label='OK']");
            OKButton.Click();
            Thread.Sleep(1000);
        }

        public static bool CheckFileDownloaded(string filename)
        {
            bool exist = false;
            string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = System.IO.Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }
    }
}
