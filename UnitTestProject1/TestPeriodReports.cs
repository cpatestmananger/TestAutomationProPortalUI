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
    public class TestPeriodReports
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
            //driver.Navigate().GoToUrl(this.localbaseURL);
            //driver.Navigate().GoToUrl(this.stagingbaseURL);
            driver.Navigate().GoToUrl(this.localbaseURL);
            Thread.Sleep(1000);
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
        }

        [TestMethod]
        [TestCategory("Nightly")]
        public void ExecuteRateOfStaffTurnOver()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectRateOfStaffTurnOver(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - RateOfStaffTurnOver automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2015 00:00");

            WizardUtils.setPeriodEnd(driver, "30/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            //WizardUtils.setEmployeeFilter(driver, "Theodore Hooks");           

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "106, Kevin Rowe", 120);

            PortalUtils.saveReport(driver);            

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }

        
        [TestMethod]
        public void ExecuteAccountRegistration()
        {
            
            PortalUtils.Login(driver,"autom","1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectAccountRegistration(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Account Registration automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/8/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday held");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);                   
            
            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);
       
        }

       
        [TestMethod]
        public void ExecuteAccountRegistrationGroupedByAccounts()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectAccountRegistrationGroupedByAccounts(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Account Registration grouped by accounts automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/8/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "28/09/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday held");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);

            //PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteReasonRegistrations()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectReasonRegistrations(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Reason registration automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);

            //PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }

       
        

        [TestMethod]
        public void ExecuteAccountTotalsPerDepartment()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectAccountTotalsPerDepartment(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Account totals per department automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday held");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "Holiday held", 120);

            PortalUtils.saveReport(driver);

           // PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }

        

        [TestMethod]
        public void ExecuteTerminalRegistrations()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectTerminalRegistrations(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Terminal filters automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setTerminalFilter(driver, "Terminal Filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "4040, Romania", 120);

            PortalUtils.saveReport(driver);

            //PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteAccountTotalPerMonth()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectAccountTotalPerMonth(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Account totals per Month automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday held");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "0040, Holiday held", 120);

            PortalUtils.saveReport(driver);

            //PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }
        

        [TestMethod]
        public void ExecuteTotalAccountsGroupedOnWeekDays()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectTotalAccountsGroupedOnWeekdays(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Account accounts grouped on weekdays automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            //WizardUtils.setAccountFilter(driver, "Holiday account");            

            WizardUtils.setTerminalFilter(driver, "Terminal filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "0040, Holiday held", 120);

            PortalUtils.saveReport(driver);

            //PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteWorkingTimeDirective11HourRule()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectWorkingTimeDirective11HourRule(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Working time directive 11 hour rule automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            //WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);

            //PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteCrosstabByEmployeeByDates()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectCrosstabByEmployeeByDates(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Crosstab by employee dates automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday held");

            //WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci, Reynolds", 120);

            PortalUtils.saveReport(driver);

            //PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteWorkingTimeDirective48HoursAWeek()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectWorkingTimeDirective48HoursAWeek(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Working Time Directive 48 hours a week");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);

            //PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteWorkingTimeDirective8HoursPerDay()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectWorkingTimeDirective8HoursPerDay(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Working Time Directive 8 hours per day - automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.clickNextPeriod(driver);

            //WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);

            //PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteAML()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openPeriodReportMenu(driver);            

            PortalUtils.selectAML(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - AML Automated execution");

            //izardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);

            //PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }

        /* Deprecated code starts here

        [TestMethod]
        public void ExecuteRateOfStaffTurnOverCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectRateOfStaffTurnOver(driver);

            PortalUtils.selectRateOfStaffTurnOverCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Rate Of Staff Turn Over custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/8/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "31/8/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Randy Rowe");

            //WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "309, Randy Rowe", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteAccountRegistrationCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectAccountRegistration(driver);

            PortalUtils.selectAccountRegistrationCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Account Registration Custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/8/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }
        

        [TestMethod]
        public void ExecuteAccountRegistrationCustom2()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectAccountRegistration(driver);

            PortalUtils.selectAccountRegistrationCustom2(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Account Registration Custom 2 automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/8/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitRunButtonIsNotVisible(driver);

            PortalUtils.clickRefreshButton(driver);

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectAccountRegistration(driver);

            PortalUtils.selectAccountRegistrationCustom2(driver);

            String LastReport = PortalUtils.lastReportName(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteAccountRegistrationCustom3()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectAccountRegistration(driver);

            PortalUtils.selectAccountRegistrationCustom3(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Account Registration Custom 3 automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/8/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "0040, Holiday held", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteKontoregistreringFerieCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectAccountRegistration(driver);

            PortalUtils.selectKontoregistreringFerie(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Kontoregistrering Ferie automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/8/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "0040, Holiday held", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteKontototalerCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectAccountTotalsPerDepartment(driver);

            PortalUtils.selectKontototalerCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Kontototaler automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/8/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteAccountTotalPerMonthCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectAccountTotalPerMonth(driver);

            PortalUtils.selectAccountTotalPerMonthCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Account totals per Month custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "0040, Holiday held", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteWorkingTimeDirective11HourRuleCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectWorkingTimeDirective11HourRule(driver);

            PortalUtils.selectWorkingTimeDirective11HourRuleCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Working time directive 11 hour rule Custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Traci Reynolds");

            //WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteWorkingTimeDirective11HourRuleCustom2()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectWorkingTimeDirective11HourRule(driver);

            PortalUtils.selectWorkingTimeDirective11HourRuleCustom2(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Working time directive 11 hour rule Custom 2 automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Traci Reynolds");

            //WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "1, Administration", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteKontoværdierCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectCrosstabByEmployeeByDates(driver);

            PortalUtils.selectKontoværdierCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Execute Kontoværdier Custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "Traci Reynolds", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        }

        [TestMethod]
        public void ExecuteKilometerregnskabCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openPeriodReportMenu(driver);

            PortalUtils.selectCrosstabByEmployeeByDates(driver);

            PortalUtils.selectKilometerregnskabCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Period report - Execute eKilometerregnskab Custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Traci Reynolds");

            WizardUtils.setAccountFilter(driver, "Holiday account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "0040, Holiday held", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closePeriodReportMenu(driver);

            PortalUtils.Logout(driver);

        } 
        
        Deprecated code ends here
              
        */

        [TestCleanup()] 
        public void testCleanUp()
        {
            driver.Quit();
        }
    }
}
