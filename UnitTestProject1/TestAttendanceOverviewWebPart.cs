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
    public class TestAttendanceOverviewWebPart
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
        
        [TestMethod]     
        public void TestClockedInEmployees()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setEmployeeRole(driver);        
            
            PortalUtils.openLeftSideMenu(driver);

            Thread.Sleep(1000);

            PortalUtils.selectMenuTab(driver, 1);

            Thread.Sleep(1000);

            PortalUtils.closeLeftSideMenu(driver);

            Thread.Sleep(1000);

            AttendanceOverviewUtils.selectStatus(driver, 1);

            Thread.Sleep(3000);

            AttendanceOverviewUtils.checkActualStatus(driver, "Present");           

            PortalUtils.Logout(driver);            
        }

        [TestMethod]
        public void TestNotClockedInEmployees()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setEmployeeRole(driver);

            PortalUtils.openLeftSideMenu(driver);

            Thread.Sleep(1000);

            PortalUtils.selectMenuTab(driver, 1);

            Thread.Sleep(1000);

            PortalUtils.closeLeftSideMenu(driver);

            Thread.Sleep(1000);

            AttendanceOverviewUtils.selectStatus(driver, 2);

            Thread.Sleep(3000);

            AttendanceOverviewUtils.checkActualStatus(driver, "Not clocked-in");

            PortalUtils.Logout(driver);
        }

        [TestMethod]
        public void TestAbsentEmployees()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setEmployeeRole(driver);

            PortalUtils.openLeftSideMenu(driver);

            Thread.Sleep(1000);

            PortalUtils.selectMenuTab(driver, 1);

            Thread.Sleep(1000);

            PortalUtils.closeLeftSideMenu(driver);

            Thread.Sleep(1000);

            AttendanceOverviewUtils.selectStatus(driver, 4);

            Thread.Sleep(3000);

            AttendanceOverviewUtils.checkActualStatus(driver, "Absent");

            PortalUtils.Logout(driver);
        }

        [TestMethod]
        public void TestMissingEmployees()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setEmployeeRole(driver);

            PortalUtils.openLeftSideMenu(driver);

            Thread.Sleep(1000);

            PortalUtils.selectMenuTab(driver, 1);

            Thread.Sleep(1000);

            PortalUtils.closeLeftSideMenu(driver);

            Thread.Sleep(1000);

            AttendanceOverviewUtils.selectStatus(driver, 5);

            Thread.Sleep(3000);

            AttendanceOverviewUtils.checkActualStatus(driver, "Not clocked-in");

            PortalUtils.Logout(driver);
        }





        [TestCleanup()]
        public void testCleanUp()
        {
            driver.Quit();
        }

    }

}
