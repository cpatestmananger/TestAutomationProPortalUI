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

namespace TestProPortal2
{
    [TestClass]
    public class TestChangePassword
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
        public void TestUpdateAndRevertPassword()
        {

            PortalUtils.Login(driver, "autom", "1234");            

            PortalUtils.openChangePasswordDialog(driver);

            PortalUtils.setActualPassword(driver, "1234");

            PortalUtils.setNewPassword(driver, "4321");

            PortalUtils.setConfirmationPassword(driver, "4321");

            PortalUtils.confirmPasswordChange(driver);

            Thread.Sleep(5000);
            
            //PortalUtils.Logout(driver);

            //PortalUtils.Login(driver, "mark1", "4321");

            PortalUtils.openChangePasswordDialog(driver);

            PortalUtils.setActualPassword(driver, "4321");

            PortalUtils.setNewPassword(driver, "1234");

            PortalUtils.setConfirmationPassword(driver, "1234");

            PortalUtils.confirmPasswordChange(driver);

            Thread.Sleep(5000);

            PortalUtils.Logout(driver);

        }

        
 

        [TestCleanup()]
        public void testCleanUp()
        {
            driver.Quit();
        }

    }

}
