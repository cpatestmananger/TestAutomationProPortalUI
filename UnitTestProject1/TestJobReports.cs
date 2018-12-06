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
    public class TestJobReports
    {
        
        private string localbaseURL = "http://localhost:8082";
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
        public void ExecuteJobDepartmentEmployeeEfficiency()
        {
            
            PortalUtils.Login(driver,"autom","1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openJobReportMenu(driver);

            PortalUtils.selectDepartmentEmployeeEfficiency(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Job report - Department employee efficiency automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "8/1/2015 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "8/1/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "Theodore Hooks");

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickRunFilter(driver);
                        
            PortalUtils.waitForTextInReport(driver, "9, Theodore Hooks", 120);

            PortalUtils.saveReport(driver);            

            PortalUtils.closeJobReportMenu(driver);

            PortalUtils.Logout(driver);
       
        }

        
        [TestMethod]
        public void ExecuteJobEfficiencyPerEmployee()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openJobReportMenu(driver);

            PortalUtils.selectEfficiencyPerEmployee(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Job report - Efficiency per employee automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/01/2016 00:00");

            WizardUtils.setPeriodEnd(driver, "31/12/2016 23:59");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setEmployeeFilter(driver, "William Hazel");

            WizardUtils.clickNextPeriod(driver);

            //WizardUtils.setAccountFilter(driver, "Holiday held");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "114, William Hazel", 120);

            PortalUtils.saveReport(driver);           

            PortalUtils.closeJobReportMenu(driver);

            PortalUtils.Logout(driver);

        }
        

        
        [TestMethod]
        public void ExecuteJobEfficiencyPerOrder()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openJobReportMenu(driver);

            PortalUtils.selectEfficiencyPerOrder(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Job report - Efficiency per order automated execution");

           //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "01/01/2008 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "10/6/2016 11:59 PM");

            //WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.clickNextPeriod(driver);

            //WizardUtils.setOrderFilter(driver, "Propc Order");

            //WizardUtils.setWorkcenterFilter(driver, "Workcenter propc");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "89456, SelfSerive", 120);

            PortalUtils.saveReport(driver);           

            PortalUtils.closeJobReportMenu(driver);

            PortalUtils.Logout(driver);

        }

       


        [TestMethod]
        public void ExecuteJobAccountWorkcenterOrder()
        {

            PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openJobReportMenu(driver);

            PortalUtils.selectAccountWorkcenterOrder(driver);

            PortalUtils.runReportButton(driver);

            WizardUtils.setDescription(driver, "Job report - Account Workcenter Order automated execution");

            //WizardUtils.setExpiryDate(driver, "31/12/2017");

            WizardUtils.clickNextExpiry(driver);

            WizardUtils.setPeriodStart(driver, "10/6/2008 12:00 AM");

            WizardUtils.setPeriodEnd(driver, "10/6/2016 11:59 PM");

            WizardUtils.setPeriodValuesSwitch(driver);

            WizardUtils.clickNextPeriod(driver);

            WizardUtils.setWorkcenterFilter(driver, "Workcenter dev");

            //WizardUtils.setAccountFilter(driver, "Filter multi account");

            WizardUtils.clickRunFilter(driver);

            PortalUtils.waitForTextInReport(driver, "JJ, Jobkonto", 120);

            PortalUtils.saveReport(driver);

            PortalUtils.closeJobReportMenu(driver);

            PortalUtils.Logout(driver);

        }

        


       [TestMethod]
       public void ExecuteJobOrderQuantity()
       {

           PortalUtils.Login(driver, "autom", "1234");

           PortalUtils.setUserRole(driver);

           PortalUtils.openJobReportMenu(driver);

           PortalUtils.selectJobOrderQuantity(driver);

           PortalUtils.runReportButton(driver);

           WizardUtils.setDescription(driver, "Job report - Order Quantity automated execution");

           //WizardUtils.setExpiryDate(driver, "31/12/2017");

           WizardUtils.clickNextExpiry(driver);

           WizardUtils.setPeriodStart(driver, "10/6/2008 12:00 AM");

           WizardUtils.setPeriodEnd(driver, "10/6/2016 11:59 PM");

           WizardUtils.setPeriodValuesSwitch(driver);

           WizardUtils.clickNextPeriod(driver);

           WizardUtils.setOrderFilter(driver, "Order 89456");

           WizardUtils.setWorkcenterFilter(driver, "Workcenter dev");

           WizardUtils.clickRunFilter(driver);

           PortalUtils.waitForTextInReport(driver, "89456, SelfSerive", 120);

           PortalUtils.saveReport(driver);           

           PortalUtils.closeJobReportMenu(driver);

           PortalUtils.Logout(driver);

       }
        


       [TestMethod]
       public void ExecuteJobGoodsOrder()
       {

           PortalUtils.Login(driver, "autom", "1234");

           PortalUtils.setUserRole(driver);

           PortalUtils.openJobReportMenu(driver);

           PortalUtils.selectGoodsOrder(driver);

           PortalUtils.runReportButton(driver);

           WizardUtils.setDescription(driver, "Job report - Job Goods Order automated execution");

           //WizardUtils.setExpiryDate(driver, "31/12/2017");

           WizardUtils.clickNextExpiry(driver);

           WizardUtils.setPeriodStart(driver, "10/6/2008 12:00 AM");

           WizardUtils.setPeriodEnd(driver, "10/6/2016 11:59 PM");

           WizardUtils.setPeriodValuesSwitch(driver);

           WizardUtils.clickNextPeriod(driver);

           WizardUtils.setOrderFilter(driver, "Order 89456");

           WizardUtils.setWorkcenterFilter(driver, "Workcenter dev");

           WizardUtils.clickRunFilter(driver);

           PortalUtils.waitForTextInReport(driver, "89456, SelfSerive", 120);

           PortalUtils.saveReport(driver);

           PortalUtils.closeJobReportMenu(driver);

           PortalUtils.Logout(driver);

       }



       [TestMethod]
       public void ExecuteJobWorkcenterEfficiency()
       {

           PortalUtils.Login(driver, "autom", "1234");

            PortalUtils.setUserRole(driver);

            PortalUtils.openJobReportMenu(driver);

           PortalUtils.selectWorkcenterEfficiency(driver);

           PortalUtils.runReportButton(driver);

           WizardUtils.setDescription(driver, "Job report - Workcenter efficiency automated execution");

           //WizardUtils.setExpiryDate(driver, "31/12/2017");

           WizardUtils.clickNextExpiry(driver);

           WizardUtils.setPeriodStart(driver, "10/6/2008 12:00 AM");

           WizardUtils.setPeriodEnd(driver, "10/6/2016 11:59 PM");

           WizardUtils.setPeriodValuesSwitch(driver);

           WizardUtils.clickNextPeriod(driver);

           WizardUtils.setWorkcenterFilter(driver, "Workcenter dev");
          
           WizardUtils.clickRunFilter(driver);

           PortalUtils.waitForTextInReport(driver, "89456, SelfSerive", 120);

           PortalUtils.saveReport(driver);           

           PortalUtils.closeJobReportMenu(driver);

           PortalUtils.Logout(driver);

       }


       


       [TestMethod]
       public void ExecuteJobEmployeeHours()
       {

           PortalUtils.Login(driver, "autom", "1234");

           PortalUtils.setUserRole(driver);

           PortalUtils.openJobReportMenu(driver);

           PortalUtils.selectEmployeeHours(driver);

           PortalUtils.runReportButton(driver);

           WizardUtils.setDescription(driver, "Job report - Employee Hours automated execution");

           //WizardUtils.setExpiryDate(driver, "31/12/2017");

           WizardUtils.clickNextExpiry(driver);

           WizardUtils.setPeriodStart(driver, "10/6/2008 12:00 AM");

           WizardUtils.setPeriodEnd(driver, "10/6/2016 11:59 PM");

           WizardUtils.setPeriodValuesSwitch(driver);

           WizardUtils.clickNextPeriod(driver);

           WizardUtils.setOrderFilter(driver, "Order 89456");

            WizardUtils.setWorkcenterFilter(driver, "Workcenter dev");

            WizardUtils.clickRunFilter(driver);

           PortalUtils.waitForTextInReport(driver, "89456, SelfSerive", 120);

           PortalUtils.saveReport(driver);         

           PortalUtils.closeJobReportMenu(driver);

           PortalUtils.Logout(driver);

       }



        /* Deprecated code starts here
      [TestMethod]
      [Ignore]
      // no data
        public void ExecuteJobCostReport()
      {

          PortalUtils.Login(driver, "mark1", "1234");

          PortalUtils.setUserRole(driver);

          PortalUtils.openJobReportMenu(driver);

          PortalUtils.selectJobCost(driver);

          PortalUtils.runReportButton(driver);

          WizardUtils.setDescription(driver, "Job report - Job Cost report automated execution");

          WizardUtils.setExpiryDate(driver, "31/12/2017");

          WizardUtils.clickNextExpiry(driver);

          WizardUtils.setPeriodStart(driver, "1/1/2000 12:00 AM");

          WizardUtils.setPeriodEnd(driver, "10/6/2016 11:59 PM");

          WizardUtils.setPeriodValuesSwitch(driver);

          WizardUtils.clickNextPeriod(driver);

          WizardUtils.setOrderFilter(driver, "Operation 10");

          WizardUtils.clickRunFilter(driver);

          PortalUtils.waitForTextInReport(driver, "89456, SelfSerive", 120);

          PortalUtils.saveReport(driver);        

          PortalUtils.closeJobReportMenu(driver);

          PortalUtils.Logout(driver);

      }


     [TestMethod]
     [Ignore]
     // no data
     public void ExecuteJobDeviation()
     {

         PortalUtils.Login(driver, "mark1", "1234");

         PortalUtils.openJobReportMenu(driver);

         PortalUtils.selectJobCost(driver);

         PortalUtils.runReportButton(driver);

         WizardUtils.setDescription(driver, "Job report - Job Deviation report automated execution");

         WizardUtils.setExpiryDate(driver, "31/12/2017");

         WizardUtils.clickNextExpiry(driver);

         WizardUtils.setPeriodStart(driver, "1/1/2000 12:00 AM");

         WizardUtils.setPeriodEnd(driver, "10/6/2016 11:59 PM");

         WizardUtils.setPeriodValuesSwitch(driver);

         WizardUtils.clickNextPeriod(driver);

         WizardUtils.setEmployeeFilter(driver, "Employee Kenneth Corbin");

         //WizardUtils.setAccountFilter(driver, "Filter multi account");

         WizardUtils.clickRunFilter(driver);

         PortalUtils.waitForTextInReport(driver, "89456, SelfSerive", 120);

         PortalUtils.saveReport(driver);

         PortalUtils.clickOKConfirmation(driver);

         PortalUtils.closeJobReportMenu(driver);

         PortalUtils.Logout(driver);

     }

            Deprecated code ends here
      */
       

     [TestMethod]        
     public void ExecuteJobRegistrations()
     {

         PortalUtils.Login(driver, "autom", "1234");

         PortalUtils.setUserRole(driver);

         PortalUtils.openJobReportMenu(driver);

         PortalUtils.selectJobRegistration(driver);

         PortalUtils.runReportButton(driver);

         WizardUtils.setDescription(driver, "Job report - Job Registration automated execution");

         //WizardUtils.setExpiryDate(driver, "31/12/2017");

         WizardUtils.clickNextExpiry(driver);

         WizardUtils.setPeriodStart(driver, "1/1/2000 12:00 AM");

         WizardUtils.setPeriodEnd(driver, "10/6/2016 11:59 PM");

         WizardUtils.setPeriodValuesSwitch(driver);

         WizardUtils.clickNextPeriod(driver);

         WizardUtils.setOrderFilter(driver, "Order 89456");

         WizardUtils.setWorkcenterFilter(driver, "Workcenter dev");

         WizardUtils.clickRunFilter(driver);

         PortalUtils.waitForTextInReport(driver, "89456, SelfSerive", 120);

         PortalUtils.saveReport(driver); 

         PortalUtils.closeJobReportMenu(driver);

         PortalUtils.Logout(driver);

     }

    

        [TestCleanup()] 
        public void testCleanUp()
        {
            driver.Quit();
        }
    }
}
