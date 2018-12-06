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
    public class TestProjectReports
    {

        private string localbaseURL = "http://10.45.10.28:8082";
        private string testingbaseURL = "http://10.145.80.223:8082/";
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
            Thread.Sleep(1000);
        }

        [TestMethod]
        [TestCategory("Nightly")]
        public void ExecuteProjectActivityRegistrations()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Project Activity registrations automated execution");

           // WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/08/2015 00:00");

            WizardUtils.setPeriodEnd(driver, "30/08/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Theodore Hooks");

            WizardUtils.setProjectFilter(driver, "Project 00");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "9, Theodore Hooks", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }

        
        [TestMethod]
        public void ExecuteProjectActivityExtraInformation()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityExtraInformation(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Project Activity extra information automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "1/8/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "31/8/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "William Hazel");

            WizardUtils.setProjectFilter(driver, "ProReport Project");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "46012, TEST: ProReport", 120);

            PortalUtils.saveReport(driver);           

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }

        /* No data 
        [TestMethod]
        public void ExecuteProjectActivityRegistrationsIncludingBudget()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrationsIncludingBudget(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Project Activity registrations including budget automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Ole Heinsen");

            WizardUtils.setProjectFilter(driver, "Project 00");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "00, General - CC/R&D", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        /* Deprecated code starts here
                
        [TestMethod]
        public void ExecuteProjectProjektAktivitetsiRDCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomProjektAktivitetsiRD(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Custom Projekt Aktivitets i RD automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            //WizardUtils.setAccountFilter(driver, "Account filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "128, Elisabeth", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteProjectSBAHoursPerEmpCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomSBAHoursPerEmp(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Custom SBA - Hours per emp automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            //WizardUtils.setAccountFilter(driver, "Account filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "128, Elisabeth", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteProjectProjectActivityRegistrationsRDCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomProjectActivityRegistrationsRD(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Project Activity registrations - RD Custom");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            WizardUtils.clickNextPeriod(driver);            

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitRunButtonIsNotVisible(driver);

            PortalUtils.clickRefreshButton(driver);

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomProjectActivityRegistrationsRD(driver);

            String LastReport = PortalUtils.lastReportName(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteProjektAktivitetsiRDEMPTimetypeRepCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectProjektAktivitetsiRDEMPTimetypeCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - ProjektAktivitetsi RDEMP Timetype Custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            //WizardUtils.setAccountFilter(driver, "Account filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "128, Elisabeth", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteProjectActivityRegistrationsMFACustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectProjectActivityRegistrationsMFACustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - PExecute Project Activity Registrations MFA Custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            //WizardUtils.setAccountFilter(driver, "Account filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "40241, Implementering", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteProjectCSVProjectActivityRegistrationsConsCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectProjectCSVProjectActivityRegistrationsCons(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - CSV Project Activity Registrations Cons Custom Automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitRunButtonIsNotVisible(driver);

            PortalUtils.clickRefreshButton(driver);

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomProjectActivityRegistrationsRD(driver);

            String LastReport = PortalUtils.lastReportName(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }

        
        [TestMethod]
        public void ExecuteProjektAktivitetsiRDEMPTimetypeCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectProjektAktivitetsiRDEMPTimetype(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Projekt Aktivitets i RD EMP Timetype Custom Automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitRunButtonIsNotVisible(driver);

            PortalUtils.clickRefreshButton(driver);

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomProjectActivityRegistrationsRD(driver);

            String LastReport = PortalUtils.lastReportName(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteProjektAktivitetsregistreringeriRDCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectProjektAktivitetsregistreringeriRD(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Projekt Aktivitets registreringer i RD Custom Automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.selectExportFormat(driver, "CSV");

            WizardUtils.setReportName(driver, "Projekt AktivitetsregistreringeriRDCustom.csv");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitRunButtonIsNotVisible(driver);

            PortalUtils.clickRefreshButton(driver);

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectProjektAktivitetsregistreringeriRD(driver);

            String LastReport = PortalUtils.lastReportName(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }
        

          
        [TestMethod]
        public void ExecuteProjectActivityregistrationsCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectProjectActivityregistrationsCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Project Activity registrations Custom automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            //WizardUtils.setAccountFilter(driver, "Account filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "44441, Sitestudy", 180);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }



        [TestMethod]
        public void ExecuteSBAProjektAktivitetsiRDCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectSBAProjektAktivitetsiRDCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - SBA Projekt Aktivitetsi RD automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/2/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            //WizardUtils.setAccountFilter(driver, "Account filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "Account", 180);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecutesbProjectActivityregistrationsCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectsbProjectActivityregistrationsCustom(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - sb Project Activity registrations automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/2/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            //WizardUtils.setAccountFilter(driver, "Account filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "Account", 180);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }




        [TestMethod]
        public void ExecuteProjectProjectActivityRegistrationsConsCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomProjectActivityRegistrationsCons(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Custom Project Activity Registrations Cons automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            //WizardUtils.setAccountFilter(driver, "Account filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "44441, Sitestudy", 180);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteProjectProjectActivityRegistrationsCons2Custom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomProjectActivityRegistrationsCons2(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Custom Project Activity Registrations Cons 2 automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitRunButtonIsNotVisible(driver);

            PortalUtils.clickRefreshButton(driver);

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomProjectActivityRegistrationsCons2(driver);

            String LastReport = PortalUtils.lastReportName(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }
        

        [TestMethod]
        public void ExecuteProjectSBAHoursPerProjectCustom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomSBAHoursPerProject(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Custom SBA - Hours per project automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            //WizardUtils.setAccountFilter(driver, "Account filter");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "44441, Sitestudy", 180);

            PortalUtils.saveReport(driver);

            PortalUtils.clickOKConfirmation(driver);

            PortalUtils.closeProjectReportMenu(driver);

            PortalUtils.Logout(driver);

        }


        [TestMethod]
        public void ExecuteProjectSBAHoursPerProject2Custom()
        {

            PortalUtils.Login(driver, "mark1", "1234");

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomSBAHoursPerProject2(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Project report - Custom SBA - Hours per project 2 automated execution");

            WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2016 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/5/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Employee Elisabeth Stewart");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitRunButtonIsNotVisible(driver);

            PortalUtils.clickRefreshButton(driver);

            PortalUtils.openProjectReportMenu(driver);

            PortalUtils.selectProjectActivityRegistrations(driver);

            PortalUtils.selectCustomSBAHoursPerProject2(driver);

            String LastReport = PortalUtils.lastReportName(driver);

            PortalUtils.closeProjectReportMenu(driver);

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
