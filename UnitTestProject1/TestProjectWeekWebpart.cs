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
    public class TestProjectWeekWebpart
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
        public void TestAddRegistration()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setEmployeeRole(driver);        
            
            PortalUtils.openLeftSideMenu(driver);

            PortalUtils.selectMenuTab(driver,2);

            Thread.Sleep(2000);

            PortalUtils.closeLeftSideMenu(driver);

            Thread.Sleep(1000);

            ProjectWeekUtils.selectButton(driver, "Add");

            Thread.Sleep(1000);

            ProjectWeekUtils.setProject(driver, "0001");

            ProjectWeekUtils.setActivity(driver, "001");

            ProjectWeekUtils.setTimeType(driver, "Normal");

            ProjectWeekUtils.setHoursByDay(driver, "8:00", "Monday");

            ProjectWeekUtils.clickSaveButton(driver);

            Thread.Sleep(1000);

            ProjectWeekUtils.selectRegistrationByProject(driver, "Dimension Project");

            ProjectWeekUtils.selectButton(driver, "Delete");

            Thread.Sleep(2000);

            ProjectWeekUtils.confirmDelete(driver);

            Thread.Sleep(1000);

            PortalUtils.Logout(driver);

                                      
        }

        [TestMethod]
        public void TestDeleteMultipleRegistrations()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setEmployeeRole(driver);

            PortalUtils.openLeftSideMenu(driver);

            PortalUtils.selectMenuTab(driver, 2);

            Thread.Sleep(2000);

            PortalUtils.closeLeftSideMenu(driver);

            Thread.Sleep(1000);

            ProjectWeekUtils.selectButton(driver, "Add");

            Thread.Sleep(1000);

            ProjectWeekUtils.setProject(driver, "0001");

            ProjectWeekUtils.setActivity(driver, "001");

            ProjectWeekUtils.setTimeType(driver, "Normal");

            ProjectWeekUtils.setHoursByDay(driver, "8:00", "Monday");

            ProjectWeekUtils.clickSaveButton(driver);

            Thread.Sleep(1000);

            ProjectWeekUtils.selectButton(driver, "Add");

            Thread.Sleep(1000);

            ProjectWeekUtils.setProject(driver, "00");

            ProjectWeekUtils.setActivity(driver, "PRIT");

            ProjectWeekUtils.setTimeType(driver, "Normal");

            ProjectWeekUtils.setHoursByDay(driver, "8:00", "Tuesday");

            ProjectWeekUtils.clickSaveButton(driver);

            Thread.Sleep(1000);

            ProjectWeekUtils.selectButton(driver, "Add");

            Thread.Sleep(1000);

            ProjectWeekUtils.setProject(driver, "0002");

            ProjectWeekUtils.setActivity(driver, "03");

            ProjectWeekUtils.setTimeType(driver, "Normal");

            ProjectWeekUtils.setHoursByDay(driver, "8:00", "Wednesday");

            ProjectWeekUtils.clickSaveButton(driver);

            Thread.Sleep(1000);

            ProjectWeekUtils.selectRegistrationByProject(driver, "Dimension Project");

            Thread.Sleep(1000);

            ProjectWeekUtils.selectButton(driver, "Delete");

            Thread.Sleep(1000);

            ProjectWeekUtils.confirmDelete(driver);

            Thread.Sleep(2000);

            ProjectWeekUtils.selectRegistrationByProject(driver, "Project for ProReport");

            Thread.Sleep(1000);

            ProjectWeekUtils.selectButton(driver, "Delete");

            Thread.Sleep(1000);

            ProjectWeekUtils.confirmDelete(driver);

            Thread.Sleep(1000);

            ProjectWeekUtils.selectRegistrationByProject(driver, "General - CC/R&D");

            Thread.Sleep(1000);

            ProjectWeekUtils.selectButton(driver, "Delete");

            Thread.Sleep(1000);

            ProjectWeekUtils.confirmDelete(driver);

            Thread.Sleep(2000);

            PortalUtils.Logout(driver);

        }

        [TestMethod]
        public void TestUpdateRegistration()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setEmployeeRole(driver);

            PortalUtils.openLeftSideMenu(driver);

            PortalUtils.selectMenuTab(driver, 2);

            Thread.Sleep(2000);

            PortalUtils.closeLeftSideMenu(driver);

            Thread.Sleep(1000);

            ProjectWeekUtils.selectButton(driver, "Add");

            Thread.Sleep(1000);

            ProjectWeekUtils.setProject(driver, "0001");

            ProjectWeekUtils.setActivity(driver, "001");

            ProjectWeekUtils.setTimeType(driver, "Normal");

            ProjectWeekUtils.setHoursByDay(driver, "8:00", "Monday");

            ProjectWeekUtils.clickSaveButton(driver);

            Thread.Sleep(2000);

            ProjectWeekUtils.selectRegistrationByProject(driver, "Dimension Project");

            Thread.Sleep(2000);

            ProjectWeekUtils.selectButton(driver, "Edit");

            Thread.Sleep(2000);

            ProjectWeekUtils.setHoursByDay(driver, "9:00", "Monday");

            Thread.Sleep(2000);

            ProjectWeekUtils.clickSaveButton(driver);

            Thread.Sleep(2000);

            ProjectWeekUtils.selectRegistrationByProject(driver, "Dimension Project");

            Thread.Sleep(2000);

            ProjectWeekUtils.selectButton(driver, "Delete");

            Thread.Sleep(2000);

            ProjectWeekUtils.confirmDelete(driver);

            Thread.Sleep(2000);

            PortalUtils.Logout(driver);


            Thread.Sleep(1000);

        }

        [TestCleanup()]
        public void testCleanUp()
        {
            driver.Quit();
        }

    }

}
