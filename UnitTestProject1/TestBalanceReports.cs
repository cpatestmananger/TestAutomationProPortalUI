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
    public class TestBalanceReports
    {

        private string testingbaseURL = "http://10.145.80.223:8082/";
        private string stagingbaseURL = "http://10.145.80.224:8082/";
        private string localbaseURL = "http://10.45.10.28:8082";
       
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
        public void ExecuteBalanceOnDepartments()
        {
            PortalUtils.Login(driver,"autom","1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openBalanceReportMenu(driver);            

            PortalUtils.selectBalancesOnDepartments(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Balance Report - Balance on departments automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);
           
            WizardUtils.setEmployeeFilter(driver, "Theodore Hooks");

            WizardUtils.setAccountFilter(driver, "Holiday held");

            WizardUtils.clickRunFilter(driver);      


            // This is for MarkLatest
            //PortalUtils.waitForTextInReport(driver, "1, Administration", 120);

            // This is for Wirtek Devel
            PortalUtils.waitForTextInReport(driver, "11, Product / Development", 120);

            PortalUtils.saveReport(driver);           

            PortalUtils.closeBalanceReportMenu(driver);

            PortalUtils.Logout(driver);
       
        }

        

        [TestMethod]
        public void ExecuteBalanceOnPeriod()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openBalanceReportMenu(driver);

            PortalUtils.selectBalancesOnPeriod(driver);

            PortalUtils.runReportButton(driver);
            
            WizardUtils.setDescription(driver, "Balance on period automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);
            
            WizardUtils.setPeriodStart(driver, "1/9/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

            //WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);
            
            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday held");

            WizardUtils.clickRunFilter(driver);        

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);            

            PortalUtils.closeBalanceReportMenu(driver);

            PortalUtils.Logout(driver);


        }

        
        [TestMethod]
        public void ExecuteBalanceOnEmployees()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openBalanceReportMenu(driver);

            PortalUtils.selectBalanceOnEmployees(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Balance on employees automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);            

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday held");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);
           
            PortalUtils.closeBalanceReportMenu(driver);

            PortalUtils.Logout(driver);


        }

        
        [TestMethod]       
        public void ExecuteBalanceOnEmployeesCrosstab()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openBalanceReportMenu(driver);

            PortalUtils.selectBalanceOnEmployeesCrosstab(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Balance on employees crosstab automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday held");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);           

            PortalUtils.closeBalanceReportMenu(driver);

            PortalUtils.Logout(driver);

        }

        /* Deprecated code
        [TestMethod]
        public void ExecuteBalanceOnDepartmentsCustom()
        {
            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openBalanceReportMenu(driver);

            PortalUtils.selectBalancesOnDepartments(driver);

            PortalUtils.selectBalancesOnDepartmentsCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Balance Report - Balance on departments custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/9/2016 12:00 AM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Home department");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "13, CC", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeBalanceReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteBalanceOnEmployeesCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openBalanceReportMenu(driver);

            PortalUtils.selectBalanceOnEmployees(driver);

            PortalUtils.selectBalanceOnEmployeesCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Balance on employees custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);
            
            WizardUtils.setEmployeeFilter(driver, "Home department");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "13, CC", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeBalanceReportMenu(driver);

            PortalUtils.Logout(driver);


        }


        [TestMethod]
        public void ExecuteBalanceOnEmployeesCustom2()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openBalanceReportMenu(driver);

            PortalUtils.selectBalanceOnEmployees(driver);

            PortalUtils.selectBalanceOnEmployeesCustom2(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Balance on employees custom 2 automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/9/2016 12:00 AM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Home department");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "13, CC", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeBalanceReportMenu(driver);

            PortalUtils.Logout(driver);


        }


        [TestMethod]
        public void ExecuteBalanceOnPeriodCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openBalanceReportMenu(driver);

            PortalUtils.selectBalancesOnPeriod(driver);

            PortalUtils.selectBalancesOnPeriodCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Balance on period custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/9/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Home department");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "13, CC", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeBalanceReportMenu(driver);

            PortalUtils.Logout(driver);


        }


        [TestMethod]
        public void ExecuteBalanceOnEmployeesCrosstabCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openBalanceReportMenu(driver);

            PortalUtils.selectBalanceOnEmployeesCrosstab(driver);

            PortalUtils.selectBalanceOnEmployeesCrosstabCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Balance on employees crosstab custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);
           
            WizardUtils.setPeriodStart(driver, "1/9/2016 12:00 AM");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Home department");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "13, CC", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeBalanceReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteBalanceOnEmployeesCrosstabCustom2()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openBalanceReportMenu(driver);

            PortalUtils.selectBalanceOnEmployeesCrosstab(driver);

            PortalUtils.selectBalanceOnEmployeesCrosstabCustom2(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Balance on employees crosstab custom 2 automated execution");

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

            PortalUtils.openBalanceReportMenu(driver);

            PortalUtils.selectBalanceOnEmployeesCrosstab(driver);

            PortalUtils.selectBalanceOnEmployeesCrosstabCustom2(driver);

            String LastReport = PortalUtils.lastReportName(driver);

            PortalUtils.closeBalanceReportMenu(driver);

            PortalUtils.Logout(driver);


        }

        End of deprecated code
        */

        [TestCleanup()] 
        public void testCleanUp()
        {
            driver.Quit();
        }
    }
}

