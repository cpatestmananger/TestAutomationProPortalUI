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


namespace TestProReportIII
{
    [TestClass]
    public class TestExpenseReports
    {

        private string testingbaseURL = "http://10.145.80.223:8082/";
        private string localbaseURL = "http://localhost:8082";
        private string stagingbaseURL = "http://10.145.80.224:8082/";
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
            driver.Navigate().GoToUrl(this.localbaseURL);
        }


        [TestMethod]
        [TestCategory("Nightly")]
        public void ExecuteExpenseMileageRegistrations()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openExpenseReportMenu(driver);

            PortalUtils.selectMileageRegistrations(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Expense report - Mileage registration automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Diedra Frazier");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickRunFilter(driver);

            //WizardUtils.setAccountFilter(driver, "Albertslund");

            PortalUtils.waitForTextInReport(driver, "39869713", 180);

            PortalUtils.saveReport(driver);           

            PortalUtils.closeExpenseReportMenu(driver);

            PortalUtils.Logout(driver);
 
        }

        /* Deprecated code starts here

        [TestMethod]
        public void ExecuteExpenseMileageRegistrationsCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openExpenseReportMenu(driver);

            PortalUtils.selectMileageRegistrations(driver);

            PortalUtils.selectMileageRegistrationsCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Expense report - Mileage registration custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            //  WizardUtils.setAccountFilter(driver, "Account filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "39869713", 180);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteExpenseMileageRegistrationsCustom2()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openExpenseReportMenu(driver);

            PortalUtils.selectMileageRegistrations(driver);

            PortalUtils.selectMileageRegistrationsCustom2(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Expense report - Mileage registration custom2 automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            //  WizardUtils.setAccountFilter(driver, "Account filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "Elisabeth Stewart", 180);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteExpenseMileageRegistrationsCustom3()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openExpenseReportMenu(driver);

            PortalUtils.selectMileageRegistrations(driver);

            PortalUtils.selectMileageRegistrationsCustom3(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Expense report - Mileage registration custom 3 automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/8/2016 12:00 AM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitRunButtonIsNotVisible(driver);

            PortalUtils.clickRefreshButton(driver);

            PortalUtils.openExpenseReportMenu(driver);

            PortalUtils.selectMileageRegistrations(driver);

            PortalUtils.selectMileageRegistrationsCustom3(driver);

            String LastReport = PortalUtils.lastReportName(driver);            

            PortalUtils.Logout(driver);


        }

            Deprecated code stops here
        */

       [TestCleanup()] 
        public void testCleanUp()
        {
            driver.Quit();
        }
    }
}
