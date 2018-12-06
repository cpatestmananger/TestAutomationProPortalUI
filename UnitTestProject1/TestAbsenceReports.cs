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
    public class TestAbsenceReports
    {
        private string localbaseURL = "http://localhost:8082";
        private string stagingbaseURL = "http://10.145.80.224:8082/";
       // private string localbaseURL = "http://10.45.10.28:8082";

        private RemoteWebDriver driver;
 
        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void TestInit()
        {
            // Browser setup part
            driver = new ChromeDriver(@"D:\chromedriver_win32");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            // Navigation to Login Page
            //driver.Navigate().GoToUrl(this.testingbaseURL);            
            driver.Navigate().GoToUrl(this.localbaseURL);
            
            //driver.Navigate().Refresh();
            Thread.Sleep(1000);
        }


        [TestMethod]
        [TestCategory("Nightly")]
        public void ExecuteAbsenceTotalOnMonths()
        {
            // Perform Login
            PortalUtils.Login(driver,"autom","1234");
            //PortalUtils.Login(driver, "mfa", "mfa1");

            // Set user role
            PortalUtils.setUserRole(driver);

            // Open Absence Report Menu
            PortalUtils.openAbsenceReportMenu(driver);

            // Select Absence Total on Months Report
            PortalUtils.selectAbsenceTotalOnMonthsReport(driver);

            Thread.Sleep(1000);

            // Run report
            PortalUtils.runReportButton(driver);

            // Set Description
            WizardUtils.setDescription(driver, "Absence Report - Absence total on Months automated execution");

            // Set Expiry date and click Next
           // WizardUtils.setExpiryDate(driver, "31/12/2017");
            WizardUtils.clickNextExpiry(driver);

            // Set periods from and to and click Next
            WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
            WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

            // Set use period values
            WizardUtils.setPeriodValuesSwitch(driver);

            // Click next
            WizardUtils.clickNextPeriod(driver);

            // Pick up the predefined filter
            WizardUtils.setEmployeeFilter(driver, "Brandon Griffith");

            Thread.Sleep(1000);

            WizardUtils.clickNextPeriod(driver);

           // WizardUtils.setAbsenceReasonFilter(driver, "Work from home");   

            // Run report
            WizardUtils.clickRunFilter(driver);
            
            // Expect for the report text to pop-up 

            // This is for Mark-Latest Server
            //PortalUtils.waitForTextInReport(driver, "1, Administration", 120);

            // This is for Wirtek Devel
            PortalUtils.waitForTextInReport(driver, "03, Work at home", 120);

            // Save report
            PortalUtils.saveReport(driver);

            // Click OK
            //PortalUtils.clickOKConfirmation(driver);

            // Close report viewer menu
            PortalUtils.closeReportViewer(driver);

            // Close Absence Report Menu
            PortalUtils.closeAbsenceReportMenu(driver);

            // Perform logout
            PortalUtils.Logout(driver);
           
        }

     

        [TestMethod]
        public void ExecuteAbsenceRulesOnTotals120Days()
        {
            // Perform Login
            PortalUtils.Login(driver, "autom", "1234");

            // Set user role
            PortalUtils.setUserRole(driver);

            // Open Absence Report Menu
            PortalUtils.openAbsenceReportMenu(driver);

            // Select Absence Rules On Totals 120 Days
            PortalUtils.selectAbsenceRulesOnTotals120Days(driver);

            // Run report
            PortalUtils.runReportButton(driver);

            // Set Description
            WizardUtils.setDescription(driver, "Absence Report - Absence Rules On Totals 120 Days automated execution");

            // Set Expiry date and click Next
            //WizardUtils.setExpiryDate(driver, "31/12/2017");
            WizardUtils.clickNextExpiry(driver);

            // Set periods from and to and click Next
            WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
            WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

            // Set use period values
            WizardUtils.setPeriodValuesSwitch(driver);

            // Click next
            WizardUtils.clickNextPeriod(driver);

            // Pick up the predefined filter
            WizardUtils.setEmployeeFilter(driver, "Brandon Griffith");
            //WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

            WizardUtils.clickNextPeriod(driver);

            // Run report
            WizardUtils.clickRunFilter(driver);

            // Expect for the report text to pop-up
            PortalUtils.waitForTextInReport(driver, "13, CC", 120);

            // Save report
            PortalUtils.saveReport(driver);
            // Click OK
            // PortalUtils.clickOKConfirmation(driver);
            // Close Absence Report Menu
            PortalUtils.closeAbsenceReportMenu(driver);
            // Perform logout
            PortalUtils.Logout(driver);
        }
        
        

        [TestMethod]
        public void ExecuteAbsenceHigherThan14Days()
        {
            // Perform Login
            PortalUtils.Login(driver, "autom", "1234");
            //PortalUtils.Login(driver, "mfa", "mfa1");

            // Set user role
            PortalUtils.setUserRole(driver);

            // Open Absence Report Menu
            PortalUtils.openAbsenceReportMenu(driver);

            // Select Execute Absence Higher Than 14 Days menu  
            PortalUtils.selectAbsenceHigherThan14Days(driver);

            // Run report
            PortalUtils.runReportButton(driver);

            // Set Description
            WizardUtils.setDescription(driver, "Absence Report - Absence Higher Than 14 Days automated execution");

            // Set Expiry date and click Next
            //WizardUtils.setExpiryDate(driver, "31/12/2017");
            WizardUtils.clickNextExpiry(driver);

            // Set periods from and to and click Next
            WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
            WizardUtils.setPeriodEnd(driver, "30/12/2016 11:59 PM");

            // Set use period values
            //WizardUtils.setPeriodValuesSwitch(driver);

            // Click next
            WizardUtils.clickNextPeriod(driver);

            // Pick up the predefined filter
            
            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
            //WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

            WizardUtils.clickNextPeriod(driver);

            // Run report
            WizardUtils.clickRunFilter(driver);

            // Expect for the report text to pop-up
            PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

            // Save report
            PortalUtils.saveReport(driver);
            // Click OK
            //PortalUtils.clickOKConfirmation(driver);
            // Close Absence Report Menu
            PortalUtils.closeAbsenceReportMenu(driver);
            // Perform logout
            PortalUtils.Logout(driver);
        }

               

        [TestMethod] 
        public void ExecuteAbsenceDepartmentDayAbsenceTotalOnMonths()
        {
            // Perform Login
            PortalUtils.Login(driver, "autom", "1234");
            //PortalUtils.Login(driver, "mfa", "mfa1");

            // Set user role
            PortalUtils.setUserRole(driver);

            // Open Absence Report Menu
            PortalUtils.openAbsenceReportMenu(driver);
            // Open Department Day Absence Total On Months
            PortalUtils.selectDepartmentDayAbsenceTotalOnMonths(driver);

            // Run report
            PortalUtils.runReportButton(driver);

            // Set Description
            WizardUtils.setDescription(driver, "Absence Report - Department Day Absence Total On Months Automation Execution");

            // Set Expiry date and click Next
            //WizardUtils.setExpiryDate(driver, "31/12/2017");
            WizardUtils.clickNextExpiry(driver);

            // Set periods from and to and click Next
            WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
            WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

            // Set use period values
            WizardUtils.setPeriodValuesSwitch(driver);

            // Click next
            WizardUtils.clickNextPeriod(driver);

            // Pick up the predefined filter
            WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
            WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

            // Run report
            WizardUtils.clickRunFilter(driver);

            // Expect for the report text to pop-up
            PortalUtils.waitForTextInReport(driver, "03, Work at home", 120);

            // Save report
            PortalUtils.saveReport(driver);
            // Click OK
            // PortalUtils.clickOKConfirmation(driver);
            // Close Absence Report Menu
            PortalUtils.closeAbsenceReportMenu(driver);
            // Perform logout
            PortalUtils.Logout(driver);
        }

        

       [TestMethod]
       public void ExecuteAbsenceEmployeeAllDayAbsenceTotalOnWeeks()
       {
           // Perform Login
           PortalUtils.Login(driver, "autom", "1234");
            //PortalUtils.Login(driver, "mfa", "mfa1");

            // Set user role
           PortalUtils.setUserRole(driver);


            // Open Absence Report Menu
           PortalUtils.openAbsenceReportMenu(driver);
           // Open Employee All Day Absence Total On Weeks report
           PortalUtils.selectEmployeeAllDayAbsenceTotalOnWeeks(driver);

           // Run report
           PortalUtils.runReportButton(driver);

           // Set Description
           WizardUtils.setDescription(driver, "Absence Report - Employee All Day Absence Total On Weeks automated execution");

           // Set Expiry date and click Next
           //WizardUtils.setExpiryDate(driver, "31/12/2017");
           WizardUtils.clickNextExpiry(driver);

           // Set periods from and to and click Next
           WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
           WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

           // Set use period values
           WizardUtils.setPeriodValuesSwitch(driver);

           // Click next
           WizardUtils.clickNextPeriod(driver);

           // Pick up the predefined filter
           WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
           WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

           // Run report
           WizardUtils.clickRunFilter(driver);

           // Expect for the report text to pop-up
           PortalUtils.waitForTextInReport(driver, "03, Work at home", 120);

           // Save report
           PortalUtils.saveReport(driver);
           // Click OK
           // PortalUtils.clickOKConfirmation(driver);
           // Close Absence Report Menu
           PortalUtils.closeAbsenceReportMenu(driver);
           // Perform logout
           PortalUtils.Logout(driver);
       }

       
       [TestMethod]
       public void ExecuteAbsenceOnWeekdays()
       {
           // Perform Login
           PortalUtils.Login(driver, "autom", "1234");
           //PortalUtils.Login(driver, "mfa", "mfa1");

           // Set user role
           PortalUtils.setUserRole(driver);

           // Open Absence Report Menu
           PortalUtils.openAbsenceReportMenu(driver);
           // Open Absence on Weekdays
           PortalUtils.selectAbsenceOnWeekdays(driver);

           // Run report
           PortalUtils.runReportButton(driver);

           // Set Description
           WizardUtils.setDescription(driver, "Absence Report - Absence On Week days automated execution");

           // Set Expiry date and click Next
           //WizardUtils.setExpiryDate(driver, "31/12/2017");
           WizardUtils.clickNextExpiry(driver);

           // Set periods from and to and click Next
           WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
           WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

           // Set use period values
           WizardUtils.setPeriodValuesSwitch(driver);

           // Click next
           WizardUtils.clickNextPeriod(driver);

           // Pick up the predefined filter
           WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
           WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

           // Run report
           WizardUtils.clickRunFilter(driver);

           // Expect for the report text to pop-up
           PortalUtils.waitForTextInReport(driver, "03, Work at home", 120);

           // Save report
           PortalUtils.saveReport(driver);
           // Click OK
           // PortalUtils.clickOKConfirmation(driver);
           // Close Absence Report Menu
           PortalUtils.closeAbsenceReportMenu(driver);
           // Perform logout
           PortalUtils.Logout(driver);
       }

       

      [TestMethod]
      public void ExecuteAbsenceBradfordFactor()
      {
          // Perform Login
          PortalUtils.Login(driver, "autom", "1234");
            //PortalUtils.Login(driver, "mfa", "mfa1");

            // Set user role
            PortalUtils.setUserRole(driver);

            // Open Absence Report Menu
            PortalUtils.openAbsenceReportMenu(driver);
          // Open Bradford factor
          PortalUtils.selectBradfordFactor(driver);

          // Run report
          PortalUtils.runReportButton(driver);

          // Set Description
          WizardUtils.setDescription(driver, "Absence Report - Bradford factor automated execution");

          // Set Expiry date and click Next
          /// WizardUtils.setExpiryDate(driver, "31/12/2017");
          WizardUtils.clickNextExpiry(driver);

          // Set periods from and to and click Next
          WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
          WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

          // Set use period values
          WizardUtils.setPeriodValuesSwitch(driver);

          // Click next
          WizardUtils.clickNextPeriod(driver);

          // Pick up the predefined filter
          WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
          WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

          // Run report
          WizardUtils.clickRunFilter(driver);

          // Expect for the report text to pop-up
          PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

          // Save report
          PortalUtils.saveReport(driver);
          // Click OK
          // PortalUtils.clickOKConfirmation(driver);
          // Close Absence Report Menu
          // PortalUtils.closeAbsenceReportMenu(driver);
          // Perform logout
          PortalUtils.Logout(driver);
      }

     

     [TestMethod]
     public void ExecuteAbsenceAllDayAbsence()
     {
         // Perform Login
         PortalUtils.Login(driver, "autom", "1234");
            //PortalUtils.Login(driver, "mfa", "mfa1");

         // Set user role
         PortalUtils.setUserRole(driver);

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open All Day Absence Menu
         PortalUtils.selectAllDayAbsence(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - All day absence automated execution");

         // Set Expiry date and click Next
         //WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
         WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         //PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }


        
       

        [TestMethod]
     public void ExecuteAbsencePartDayAbsence()
     {
         // Perform Login
         PortalUtils.Login(driver, "autom", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Set user role
         PortalUtils.setUserRole(driver);

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Part Day Absence Menu
         PortalUtils.selectPartDayAbsence(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Part day absence automated execution");

         // Set Expiry date and click Next
         // WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
         WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         // PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }
        
       
        

     [TestMethod]
     public void ExecuteAbsencePercentInHoursAccount()
     {
         // Perform Login
         PortalUtils.Login(driver, "autom", "1234");
         // PortalUtils.Login(driver, "mfa", "mfa1");
         // Set user role
         PortalUtils.setUserRole(driver);

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Absence Percent In Hours Account Menu
         PortalUtils.selectAbsencePercentInHoursAccount(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Absence percent in hours Account automation execution");

         // Set Expiry date and click Next
         //WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
         WizardUtils.setAccountFilter(driver, "Holiday held");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "1, Administration", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         // PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }

       

     [TestMethod]
     public void ExecuteAbsencePercentInDaysReason()
     {
         // Perform Login
         PortalUtils.Login(driver, "autom", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");
         // Set user role
         PortalUtils.setUserRole(driver);

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Absence Percent In Days Reason Menu
         PortalUtils.selectAbsencePercentInDaysReason(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Absence percent in days reason automated execution");

         // Set Expiry date and click Next
         // WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
         WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         // PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }

       
       

     [TestMethod]
     public void ExecuteAbsenceEmployeeAbsenceTotalOnWeeks()
     {
         // Perform Login
         PortalUtils.Login(driver, "autom", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

        // Set user role
         PortalUtils.setUserRole(driver);

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Employee Absence Total on weeks Menu
         PortalUtils.selectEmployeeAbsenceTotalOnWeeks(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Employee Absence Total On Weeks automated execution");

         // Set Expiry date and click Next
         //WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
         WizardUtils.setAccountFilter(driver, "Holiday held");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         //PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }

     /*deprecated code starts here (custom reports)

     [TestMethod]
     [Ignore]
     // Not supported
     public void ExecuteAverageAbsenceOnEmployeesPerDepartment()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Average Absence On Employees Per Department
         PortalUtils.selectAverageAbsenceOnEmployeesPerDepartment(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Average Absence On Employees Per Department Automated Execution");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Home department");
         WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "13, CC", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }


     [TestMethod]
     [Ignore]
     // Not supported
     public void ExecutePlannedAbsence()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Planned Absence
         PortalUtils.selectPlannedAbsence(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Planned Absence report");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Home department");
         WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "13, CC", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }



     [TestMethod]
     public void ExecuteAbsenceHigherThan14DaysCustom()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);

         // Select Execute Absence Higher Than 14 Days menu  
         PortalUtils.selectAbsenceHigherThan14Days(driver);

         // Select Execute Absence Higher custom Than 14 Days menu  
         PortalUtils.selectAbsenceHigherThan14DayCustom(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Absence Higher Than 14 Days custom automated execution");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Employee Kenneth Corbin");
         //WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "76, Kenneth Corbin", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }


     [TestMethod]
     [Ignore]
     // Bug found
     public void ExecuteAbsenceAllDayAbsenceCustom()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open All Day Absence Menu
         PortalUtils.selectAllDayAbsence(driver);
         // Open All Day Absence custom Menu
         PortalUtils.selectAllDayAbsenceCustom(driver);
         // Run report
         PortalUtils.runReportButton(driver);
         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - All day absence custom");
         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");

         WizardUtils.clickNextExpiry(driver);
         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");

         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");
         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);
         // Click next
         WizardUtils.clickNextPeriod(driver);
         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Home department");

         WizardUtils.setAbsenceReasonFilter(driver, "Work from home");
         // Click next
         WizardUtils.clickNextPeriod(driver);

         WizardUtils.clickRunFilter(driver);

         PortalUtils.waitRunButtonIsNotVisible(driver);

         PortalUtils.clickRefreshButton(driver);

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open All Day Absence Menu
         PortalUtils.selectAllDayAbsence(driver);
         // Open All Day Absence custom Menu
         PortalUtils.selectAllDayAbsenceCustom(driver);

         String LastReport = PortalUtils.lastReportName(driver);

         PortalUtils.closePeriodReportMenu(driver);

         PortalUtils.Logout(driver);          
     }


     [TestMethod]
     public void ExecuteAbsenceTotalOnMonthsTotaltfraværCustom()         
     {
         // Perform Login
         PortalUtils.Login(driver,"mark1","1234");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);

         // Select Absence Total on Months Report
         PortalUtils.selectAbsenceTotalOnMonthsReport(driver);

         // select Totalt fravær Custom
         PortalUtils.selectTotaltfraværCustom(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Totalt fravær Custom automated execution");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Home department");
         WizardUtils.setAbsenceReasonFilter(driver, "03, Work at home");   

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "04, Illness", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);

     }


     [TestMethod]
     public void ExecuteAbsenceBradfordFactorCustom()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Bradford factor 
         PortalUtils.selectBradfordFactor(driver);            
         // Open Bradford factor custom
         PortalUtils.selectBradfordFactorCustom(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Bradford factor custom automated execution");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Home department");
         WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "13, CC", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }


     [TestMethod]
     public void ExecuteAbsencePercentInDaysReasonCustom()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Absence Percent In Days Reason Menu
         PortalUtils.selectAbsencePercentInDaysReason(driver);
         // Open Absence Percent In Days Reason Menu custom
         PortalUtils.selectAbsencePercentInDaysReasonCustom(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Absence percent in days reason custom automated execution");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);
         // Click next
         WizardUtils.clickNextPeriod(driver);
         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Home department");

         WizardUtils.setAbsenceReasonFilter(driver, "Work from home");
         // Click next
         WizardUtils.clickNextPeriod(driver);
         // Run report
         WizardUtils.clickRunFilter(driver);

         PortalUtils.waitRunButtonIsNotVisible(driver);

         PortalUtils.clickRefreshButton(driver);
         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Absence Percent In Days Reason Menu
         PortalUtils.selectAbsencePercentInDaysReason(driver);
         // Open Absence Percent In Days Reason Menu custom
         PortalUtils.selectAbsencePercentInDaysReasonCustom(driver);

         String LastReport = PortalUtils.lastReportName(driver);

         PortalUtils.closePeriodReportMenu(driver);

         PortalUtils.Logout(driver);
     }


     [TestMethod]
     public void ExecuteAbsencePercentInDaysReasonCustom2()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Absence Percent In Days Reason Menu
         PortalUtils.selectAbsencePercentInDaysReason(driver);
         // Open Absence Percent In Days Reason Menu Custom 2
         PortalUtils.selectAbsencePercentInDaysReasonCustom2(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Absence percent in days reason custom 2 automated execution");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Home department");
         WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "1003, Elisabeth Turner", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }


     [TestMethod]
     public void ExecuteAbsencePercentInDaysReasonCustom3()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Absence Percent In Days Reason Menu
         PortalUtils.selectAbsencePercentInDaysReason(driver);
         // Open Absence Percent In Days Reasox`n Menu Custom 3
         PortalUtils.selectAbsencePercentInDaysReasonCustom3(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Absence percent in days reason custom 3 automated execution");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Home department");
         WizardUtils.setAbsenceReasonFilter(driver, "Work from home");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "1003, Elisabeth Turner", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }



     [TestMethod]
     public void ExecuteAbsencePercentInHoursAccountCustom()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Absence Percent In Hours Account Menu
         PortalUtils.selectAbsencePercentInHoursAccount(driver);
         // Open Absence Percent In Hours Account Menu custom
         PortalUtils.selectAbsencePercentInHoursAccountCustom(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Absence percent in hours Account Custom automation execution");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
         WizardUtils.setAccountFilter(driver, "Holiday account");

         WizardUtils.clickNextPeriod(driver);
         // Run report
         WizardUtils.clickRunFilter(driver);

         PortalUtils.waitRunButtonIsNotVisible(driver);

         PortalUtils.clickRefreshButton(driver);
         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Absence Percent In Hours Account Menu
         PortalUtils.selectAbsencePercentInHoursAccount(driver);

         PortalUtils.selectAbsencePercentInHoursAccountCustom(driver);

         String LastReport = PortalUtils.lastReportName(driver);

         PortalUtils.closePeriodReportMenu(driver);

         PortalUtils.Logout(driver);
     }


     [TestMethod]
     public void ExecuteAbsencePercentInHoursAccountCustom2()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Absence Percent In Hours Account Menu
         PortalUtils.selectAbsencePercentInHoursAccount(driver);

         PortalUtils.selectAbsencePercentInHoursAccountCustom2(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Absence percent in hours Account custom 2 automation execution");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
         WizardUtils.setAccountFilter(driver, "Holiday account");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }


     [TestMethod]
     public void ExecuteAbsencePercentInHoursAccountCustom3()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Absence Percent In Hours Account Menu
         PortalUtils.selectAbsencePercentInHoursAccount(driver);

         PortalUtils.selectAbsencePercentInHoursAccountCustom3(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Absence percent in hours Account custom 3 automation execution");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
         WizardUtils.setAccountFilter(driver, "Holiday account");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "0040, Holiday held", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }


     [TestMethod]
     public void ExecuteAbsencePercentInHoursAccountCustom4()
     {
         // Perform Login
         PortalUtils.Login(driver, "mark1", "1234");
         //PortalUtils.Login(driver, "mfa", "mfa1");

         // Open Absence Report Menu
         PortalUtils.openAbsenceReportMenu(driver);
         // Open Absence Percent In Hours Account Menu
         PortalUtils.selectAbsencePercentInHoursAccount(driver);

         PortalUtils.selectAbsencePercentInHoursAccountCustom4(driver);

         // Run report
         PortalUtils.runReportButton(driver);

         // Set Description
         WizardUtils.setDescription(driver, "Absence Report - Absence percent in hours Account custom 4 automation execution");

         // Set Expiry date and click Next
         WizardUtils.setExpiryDate(driver, "31/12/2017");
         WizardUtils.clickNextExpiry(driver);

         // Set periods from and to and click Next
         WizardUtils.setPeriodStart(driver, "1/1/2016 12:00 AM");
         WizardUtils.setPeriodEnd(driver, "28/9/2016 11:59 PM");

         // Set use period values
         WizardUtils.setPeriodValuesSwitch(driver);

         // Click next
         WizardUtils.clickNextPeriod(driver);

         // Pick up the predefined filter
         WizardUtils.setEmployeeFilter(driver, "Traci Reynolds");
         WizardUtils.setAccountFilter(driver, "Holiday account");

         // Run report
         WizardUtils.clickRunFilter(driver);

         // Expect for the report text to pop-up
         PortalUtils.waitForTextInReport(driver, "126, Traci Reynolds", 120);

         // Save report
         PortalUtils.saveReport(driver);
         // Click OK
         PortalUtils.clickOKConfirmation(driver);
         // Close Absence Report Menu
         PortalUtils.closeAbsenceReportMenu(driver);
         // Perform logout
         PortalUtils.Logout(driver);
     }

     */

        [TestCleanup()]
        public void testCleanUp()
        {
            driver.Quit();
        }
    }
}

