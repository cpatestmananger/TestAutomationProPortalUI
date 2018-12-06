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
    public class TestAccountBalanceWebPart
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
            Thread.Sleep(1000);
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
        }
/*
        [TestMethod]     
        public void TestForClockedInEmployees()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setEmployeeRole(driver);        
            
            PortalUtils.openLeftSideMenu(driver);

            PortalUtils.selectMenuTab(driver,1);

            Thread.Sleep(1000);

            PortalUtils.closeLeftSideMenu(driver);

            Thread.Sleep(1000);

            AccountBalanceUtils.selectPeriodType(driver, 1);

            Thread.Sleep(1000);

           

            AccountBalanceUtils.checkBalance(driver, "5.00");

            Thread.Sleep(1000);

            PortalUtils.Logout(driver);            
        }*/

        [TestMethod]
        public void TestCurrentOpenPeriod()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openLeftSideMenu(driver);

            PortalUtils.selectMenuTab(driver, 1);

            Thread.Sleep(1000);

            PortalUtils.closeLeftSideMenu(driver);

            Thread.Sleep(1000);

            AccountBalanceUtils.selectPeriodType(driver, 0);

            Thread.Sleep(1000);

           

            AccountBalanceUtils.checkBalance(driver, "5.00");

            Thread.Sleep(1000);

            PortalUtils.Logout(driver);
        }

        [TestMethod]
        public void TestLatestClosedPeriod()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openLeftSideMenu(driver);

            Thread.Sleep(1000);

            PortalUtils.selectMenuTab(driver, 1);

            Thread.Sleep(1000);

            PortalUtils.closeLeftSideMenu(driver);

            Thread.Sleep(1000);

            AccountBalanceUtils.selectPeriodType(driver, 2);

            Thread.Sleep(1000);

            

            AccountBalanceUtils.checkBalance(driver, "5.00");

            Thread.Sleep(5000);

            PortalUtils.Logout(driver);
        }

        [TestMethod]
        public void TestCurrentAndFuturePeriod()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openLeftSideMenu(driver);

            Thread.Sleep(1000);

            PortalUtils.selectMenuTab(driver, 1);

            Thread.Sleep(1000);

            PortalUtils.closeLeftSideMenu(driver);

            Thread.Sleep(1000);

            AccountBalanceUtils.selectPeriodType(driver, 3);

            Thread.Sleep(1000);            

            AccountBalanceUtils.checkBalance(driver, "5.00");

            Thread.Sleep(1000);

            PortalUtils.Logout(driver);
        }


        [TestCleanup()]
        public void testCleanUp()
        {
            driver.Quit();
        }

    }

}
