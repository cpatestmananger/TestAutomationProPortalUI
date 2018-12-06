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
using TestProReportIII.Utils;
using ProPortal.Utils;


namespace TestProPortal2
{
    [TestClass]
    public class TestRegistrationWebPart
    {

        private string localbaseURL = "http://localhost:8082";
        private string testingbaseURL = "http://10.145.80.223:8082/";
        private RemoteWebDriver driver;
        private string browser;
        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void TestInit()
        {
            // Browser setup part
            driver = new ChromeDriver(@"D:\chromedriver_win32");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            // Navigation to Login Page
            //driver.Navigate().GoToUrl(this.localbaseURL);
            //driver.Navigate().GoToUrl(this.stagingbaseURL);
            driver.Navigate().GoToUrl(this.localbaseURL);
            //Thread.Sleep(1000);
            //driver.Navigate().Refresh();
            Thread.Sleep(1000);
        }

        [TestMethod]     
        public void TestWebPartProperties()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setEmployeeRole(driver);        
            
            PortalUtils.editWebPartPropertiesRegistration(driver);

            PortalUtils.setTerminalRegistration(driver,"4040");

            PortalUtils.savePropertiesRegistration(driver);

            Thread.Sleep(5000);

            PortalUtils.Logout(driver);

        }
        

        [TestMethod]
       
        public void TestTransactionList()
        {
            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setEmployeeRole(driver);

            RegistrationUtils.pushTransactionListKey(driver);

            RegistrationUtils.enterPinTransactionList(driver, "1234");

            RegistrationUtils.selectReportTypeTransactionList(driver, "Transaction list report");

            RegistrationUtils.enterFirstDateTransactionList(driver, "13-06-2017");

            RegistrationUtils.enterLastDateTransactionList(driver, "20-06-2017");

            Thread.Sleep(5000);

            Assert.IsTrue(RegistrationUtils.CheckFileDownloaded("Transaction_List"));

            PortalUtils.Logout(driver);
        }

        
 

        [TestCleanup()]
        public void testCleanUp()
        {
            driver.Quit();
        }

    }

}
