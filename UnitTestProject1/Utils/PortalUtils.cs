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
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;


namespace TestProReportIII.Utils
{
    public static class PortalUtils
    {
        public static void Login(RemoteWebDriver driver, String user, String pass)
        {
            // Login 
            IWebElement userName = driver.FindElementByXPath("//*[@id='input_0']");
            userName.SendKeys(user);
            Thread.Sleep(1000);
            IWebElement password = driver.FindElementByXPath(" //*[@id='input_1']");
            password.SendKeys(pass);
            var wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait1.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='shell']/md-content/div/md-whiteframe/md-content/form/md-input-container[3]/button")));
            IWebElement buttonLogin = driver.FindElementByXPath("//*[@id='shell']/md-content/div/md-whiteframe/md-content/form/md-input-container[3]/button");
            Thread.Sleep(2000);
            buttonLogin.Click();
            // Wait for homepage to be loaded
            IWait<IWebDriver> wait2 = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait2.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void Logout(RemoteWebDriver driver)
        {
            IWebElement userMenuButton = driver.FindElementByXPath("//*[@id='shell']/md-content/div/section/top-nav/md-toolbar/div/div[3]/md-menu/button/ng-md-icon");
                                                                    
            userMenuButton.Click();
            Thread.Sleep(1000);

            //IWebElement menuElements = driver.FindElementByCssSelector(".settings-menu.layout-align-start-start.layout-column");
            IWebElement menuElement = driver.FindElementByCssSelector("md-menu-content[role=menu][class=settings-menu]");

            var menuItems = menuElement.FindElements(By.TagName("md-menu-item"));
            IWebElement logoutMenuLink = menuItems[2];

            logoutMenuLink.Click();

            Thread.Sleep(1000);
        }

        public static void setUserRole(RemoteWebDriver driver)
        {
            IWebElement userMenuButton = driver.FindElementByXPath("//*[@id='shell']/md-content/div/section/top-nav/md-toolbar/div/div[3]/md-menu/button/ng-md-icon");
            userMenuButton.Click();
            Thread.Sleep(1000);

            //IWebElement menuElements = driver.FindElementByCssSelector(".settings-menu.layout-align-start-start.layout-column");
            IWebElement menuElement = driver.FindElementByCssSelector("md-menu-content[role=menu][class=settings-menu]");

            var menuItems = menuElement.FindElements(By.TagName("md-menu-item"));
            IWebElement userMenuLink = menuItems[4];

            userMenuLink.Click();

            Thread.Sleep(1000);   
        }

        public static void setEmployeeRole(RemoteWebDriver driver)
        {
            IWebElement userMenuButton = driver.FindElementByXPath(" //*[@id='shell']/md-content/div/section/top-nav/md-toolbar/div/div[3]/md-menu/button/ng-md-icon");
                                                                                            
            userMenuButton.Click();
            Thread.Sleep(1000);

            //IWebElement menuElements = driver.FindElementByCssSelector(".settings-menu.layout-align-start-start.layout-column");
            IWebElement menuElement = driver.FindElementByCssSelector("md-menu-content[role=menu][class=settings-menu]");

            var menuItems = menuElement.FindElements(By.TagName("md-menu-item"));
            IWebElement userMenuLink = menuItems[3];

            userMenuLink.Click();

            Thread.Sleep(1000);
        }


        public static void openChangePasswordDialog(RemoteWebDriver driver)
        {
            IWebElement userMenuButton = driver.FindElementByXPath("//*[@id='shell']/md-content/div/section/top-nav/md-toolbar/div/div[3]/md-menu/button/ng-md-icon");
            
            userMenuButton.Click();
            Thread.Sleep(1000);

            //IWebElement menuElements = driver.FindElementByCssSelector(".settings-menu.layout-align-start-start.layout-column");
            IWebElement menuElement = driver.FindElementByCssSelector("md-menu-content[role=menu][class=settings-menu]");

            var menuItems = menuElement.FindElements(By.TagName("md-menu-item"));
            IWebElement userMenuLink = menuItems[1];

            userMenuLink.Click();

            Thread.Sleep(1000);
        }

        public static void closeReportViewer(RemoteWebDriver driver)
        {
            IWebElement closeButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/reporting-content/report-viewer/md-toolbar/div/button[6]");
            IWait<IWebDriver> wait3 = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait3.Until(ExpectedConditions.ElementToBeClickable(closeButton));
            closeButton.Click();
        }

        public static void openAbsenceReportMenu(RemoteWebDriver driver)
        {
            // Open Absence Report Menu
            IWebElement AbsenceReportSelector = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/md-list-item/div/button");            
            AbsenceReportSelector.Click();
        }

        public static void closeAbsenceReportMenu(RemoteWebDriver driver)
        {
            // Close Absence Report Menu
            IWebElement AbsenceReportSelector = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/md-list-item/div/button");
            AbsenceReportSelector.Click();
        }

        public static void openBalanceReportMenu(RemoteWebDriver driver)
        {   
            // Open Balance Report Menu
            IWebElement BalanceSelector = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[4]/md-list-item/div/button");
            BalanceSelector.Click();
        }

        public static void closeBalanceReportMenu(RemoteWebDriver driver)
        {
            // Close Balance Report Menu
            IWebElement BalanceSelector = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[4]/md-list-item/div/button");
            BalanceSelector.Click();
        }

        public static void selectAbsenceTotalOnMonthsReport(RemoteWebDriver driver)
        {
            // Select Absence Total on Months Report
            IWebElement AbsenceTotalOnMonthsLink = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[3]/md-list-item/div/button");                                                                              
            IWait<IWebDriver> wait3 = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait3.Until(ExpectedConditions.ElementToBeClickable(AbsenceTotalOnMonthsLink));
            AbsenceTotalOnMonthsLink.Click();
        }

        public static void selectBalancesOnDepartments(RemoteWebDriver driver)
        {
            // Select Absence Total on Months Report
            IWebElement AbsenceTotalOnMonthsLink = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[4]/div/repeat-list/md-list/div[1]/md-list-item/div/button");
            IWait<IWebDriver> wait3 = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait3.Until(ExpectedConditions.ElementToBeClickable(AbsenceTotalOnMonthsLink));
            AbsenceTotalOnMonthsLink.Click();
        }

        public static void runReportButton(RemoteWebDriver driver)
        {
            // Click the Run button when it becomes clickable
            IWebElement RunButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[1]/reporting-toolbar/md-toolbar/div/button[2]");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(RunButton));
            RunButton.Click();
            Thread.Sleep(1000);
        }

        public static void openJobReportMenu(RemoteWebDriver driver)
        {
            // Open Job Report Menu
            IWebElement JobReportSelector = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/md-list-item/div/button");
            JobReportSelector.Click();
        }

        public static void openPeriodReportMenu(RemoteWebDriver driver)
        {
            // Open Period Report Menu
            IWebElement PeriodReportSelector = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/md-list-item/div/button");                                                                          
            PeriodReportSelector.Click();
        }

        public static void selectBalancesOnPeriod(RemoteWebDriver driver)
        {
            IWebElement balanceOnEmployessButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[4]/div/repeat-list/md-list/div[3]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(balanceOnEmployessButton));
            balanceOnEmployessButton.Click();
            Thread.Sleep(1000);
        }

        public static void selectDepartmentEmployeeEfficiency(RemoteWebDriver driver)
        {
            IWebElement DepartmentEmployeeEfficiencyButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/div/repeat-list/md-list/div[1]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(DepartmentEmployeeEfficiencyButton));
            DepartmentEmployeeEfficiencyButton.Click();
            Thread.Sleep(1000);
        }

        public static void closeJobReportMenu(RemoteWebDriver driver)
        {
            // Open Job Report Menu
            IWebElement JobReportSelector = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/md-list-item/div/button");
            JobReportSelector.Click();
        }

        public static void selectAccountRegistration(RemoteWebDriver driver)
        {
            IWebElement AccountRegistrationButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[2]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountRegistrationButton));
            AccountRegistrationButton.Click();
            Thread.Sleep(1000);
        }

        public static void closePeriodReportMenu(RemoteWebDriver driver)
        {
            // Close Period Report Menu
            IWebElement PeriodReportSelector = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/md-list-item/div/button");
            PeriodReportSelector.Click();
        }
        
        public static void openProjectReportMenu(RemoteWebDriver driver)
        {
            // Open Project Report Menu
            IWebElement ProjectReportSelector = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[7]/md-list-item/div/button");
            ProjectReportSelector.Click();
        }

        public static void selectProjectActivityRegistrations(RemoteWebDriver driver)
        {
            // Select Project Activity Registrations
            IWebElement ProjectActivityRegistrationsButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjectActivityRegistrationsButton));
            ProjectActivityRegistrationsButton.Click();
            Thread.Sleep(1000);
        }

        public static void closeProjectReportMenu(RemoteWebDriver driver)
        {
            // Open Project Report Menu
            IWebElement ProjectReportSelector = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[7]/md-list-item/div/button");
            ProjectReportSelector.Click();
        }

        public static void waitForTextInReport(RemoteWebDriver driver, String text, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement reportTitle = wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[contains(text(), '"+text+"')]")));
            Thread.Sleep(1000);
        }

        public static void saveReport(RemoteWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement SaveButton = wait.Until<IWebElement>(d => d.FindElement(By.CssSelector("button[ng-click='vm.saveReport()']")));
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[ng-click='vm.saveReport()']")));
            SaveButton.Click();
            Thread.Sleep(1000);

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement SaveButtonPopup = wait3.Until<IWebElement>(d => d.FindElement(By.CssSelector("button[ng-click='vm.save()']")));
            SaveButtonPopup.Click();
            Thread.Sleep(1000);

        }

        public static void clickOKConfirmation(RemoteWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement OkButton = wait.Until<IWebElement>(d => d.FindElement(By.CssSelector("button[ng-click='dialog.hide()']")));
            OkButton.Click();
            Thread.Sleep(1000);
        }

        public static void selectProjectActivityExtraInformation(RemoteWebDriver driver)
        {
            // Select Project Activity Extra Information
            IWebElement ProjectActivityExtraInformationButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[2]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjectActivityExtraInformationButton));
            ProjectActivityExtraInformationButton.Click();
            Thread.Sleep(1000);
        }

        public static void selectProjectActivityRegistrationsIncludingBudget(RemoteWebDriver driver)
        {
            // select Project Activity Including Budget
            IWebElement ProjectActivityIncludingBudgetButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[3]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjectActivityIncludingBudgetButton));
            ProjectActivityIncludingBudgetButton.Click();
            Thread.Sleep(1000);
        }

        public static void selectRateOfStaffTurnOver(RemoteWebDriver driver)
        {
            // select RateOfStaff report
            IWebElement RateOfstaffButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[1]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(RateOfstaffButton));
            RateOfstaffButton.Click();
            Thread.Sleep(1000);
        }

        public static void selectEfficiencyPerEmployee(RemoteWebDriver driver)
        {
            // select EfficiencyPerEmployeeBudget report
            IWebElement EfficiencyPerEmployeeBudgetButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/div/repeat-list/md-list/div[2]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(EfficiencyPerEmployeeBudgetButton));
            EfficiencyPerEmployeeBudgetButton.Click();
            Thread.Sleep(1000);
        }

        public static void selectAccountRegistrationGroupedByAccounts(RemoteWebDriver driver)
        {
            // select EfficiencyPerEmployeeBudget report
            IWebElement AccountRegistrationGroupedByAccountsButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[4]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountRegistrationGroupedByAccountsButton));
            AccountRegistrationGroupedByAccountsButton.Click();
            Thread.Sleep(1000);
        }

        public static void selectAccountTotalsPerDepartment(RemoteWebDriver driver)
        {
            // select EfficiencyPerEmployeeBudget report
            IWebElement AccountTotalsPerDepartmentButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[5]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountTotalsPerDepartmentButton));
            AccountTotalsPerDepartmentButton.Click();
            Thread.Sleep(1000);

        }

        public static void selectReasonRegistrations(RemoteWebDriver driver)
        {
            // select reason registrations report
            IWebElement ReasonRegistrationButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[3]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ReasonRegistrationButton));
            ReasonRegistrationButton.Click();
            Thread.Sleep(1000);
        }

        public static void selectTerminalRegistrations(RemoteWebDriver driver)
        {

            // select Terminal Registrations report
            IWebElement TerminalRegistrationsButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[6]/md-list-item/div/button");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(TerminalRegistrationsButton));
            TerminalRegistrationsButton.Click();
            Thread.Sleep(1000);
        }

        public static void selectAccountTotalPerMonth(RemoteWebDriver driver)
        {
            IWebElement AccountTotalPerMonthButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[7]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AccountTotalPerMonthButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountTotalPerMonthButton));
            AccountTotalPerMonthButton.Click();
        }

        public static void selectTotalAccountsGroupedOnWeekdays(RemoteWebDriver driver)
        {
            IWebElement TotalAccountsGroupedOnWeekdaysButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[8]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(TotalAccountsGroupedOnWeekdaysButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(TotalAccountsGroupedOnWeekdaysButton));
            TotalAccountsGroupedOnWeekdaysButton.Click();
        }

        public static void selectWorkingTimeDirective11HourRule(RemoteWebDriver driver)
        {
            IWebElement WorkingTimeDirective11hourRuleButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[9]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(WorkingTimeDirective11hourRuleButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(WorkingTimeDirective11hourRuleButton));
            WorkingTimeDirective11hourRuleButton.Click();
        }

        public static void selectCrosstabByEmployeeByDates(RemoteWebDriver driver)
        {
            IWebElement CrosstabByEmployeeByDatesButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[10]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(CrosstabByEmployeeByDatesButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(CrosstabByEmployeeByDatesButton));
            CrosstabByEmployeeByDatesButton.Click();
        }

        public static void selectWorkingTimeDirective48HoursAWeek(RemoteWebDriver driver)
        {
            IWebElement WorkingTimeDirective48HoursAWeekButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[11]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(WorkingTimeDirective48HoursAWeekButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(WorkingTimeDirective48HoursAWeekButton));
            WorkingTimeDirective48HoursAWeekButton.Click();
        }

        public static void selectWorkingTimeDirective8HoursPerDay(RemoteWebDriver driver)
        {
            IWebElement WorkingTimeDirective8HoursPerDayButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[12]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(WorkingTimeDirective8HoursPerDayButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(WorkingTimeDirective8HoursPerDayButton));
            WorkingTimeDirective8HoursPerDayButton.Click();
        }

        public static void selectAML(RemoteWebDriver driver)
        {
            IWebElement AMLButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[13]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AMLButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AMLButton));
            AMLButton.Click();
        }

        public static void selectEfficiencyPerOrder(RemoteWebDriver driver)
        {
            IWebElement EfficiencyPerOrderButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/div/repeat-list/md-list/div[3]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(EfficiencyPerOrderButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(EfficiencyPerOrderButton));
            EfficiencyPerOrderButton.Click();
        }

        public static void selectBalanceOnEmployees(RemoteWebDriver driver)
        {
            IWebElement BalanceOnEmployeesButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[4]/div/repeat-list/md-list/div[2]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(BalanceOnEmployeesButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(BalanceOnEmployeesButton));
            BalanceOnEmployeesButton.Click();
        }

        public static void selectBalanceOnEmployeesCrosstab(RemoteWebDriver driver)
        {
            IWebElement BalanceOnEmployeesCrosstabButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[4]/div/repeat-list/md-list/div[4]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(BalanceOnEmployeesCrosstabButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(BalanceOnEmployeesCrosstabButton));
            BalanceOnEmployeesCrosstabButton.Click();
        }

        public static void selectAbsenceRulesOnTotals120Days(RemoteWebDriver driver)
        {
            IWebElement AbsenceRulesOnTotals120DaysButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[1]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsenceRulesOnTotals120DaysButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsenceRulesOnTotals120DaysButton));
            AbsenceRulesOnTotals120DaysButton.Click();
        }

        public static void selectAbsenceHigherThan14Days(RemoteWebDriver driver)
        {
            IWebElement AbsenceHigherThan14DaysButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[2]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsenceHigherThan14DaysButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsenceHigherThan14DaysButton));
            AbsenceHigherThan14DaysButton.Click();
        }

        public static void selectDepartmentDayAbsenceTotalOnMonths(RemoteWebDriver driver)
        {
            IWebElement DepartmentDayAbsenceTotalOnMonths = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[3]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(DepartmentDayAbsenceTotalOnMonths);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(DepartmentDayAbsenceTotalOnMonths));
            DepartmentDayAbsenceTotalOnMonths.Click();
        }

        public static void selectEmployeeAllDayAbsenceTotalOnWeeks(RemoteWebDriver driver)
        {
            IWebElement EmployeeAllDayAbsenceTotalOnWeeksButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[5]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(EmployeeAllDayAbsenceTotalOnWeeksButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(EmployeeAllDayAbsenceTotalOnWeeksButton));
            EmployeeAllDayAbsenceTotalOnWeeksButton.Click();
        }

        public static void selectAbsenceOnWeekdays(RemoteWebDriver driver)
        {
            IWebElement AbsenceOnWeekdaysButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[6]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsenceOnWeekdaysButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsenceOnWeekdaysButton));
            AbsenceOnWeekdaysButton.Click();        
        }

        public static void selectBradfordFactor(RemoteWebDriver driver)
        {
            IWebElement BradfordFactorButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[7]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(BradfordFactorButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(BradfordFactorButton));
            BradfordFactorButton.Click(); 
        }

        public static void selectAllDayAbsence(RemoteWebDriver driver)
        {
            IWebElement AllDayAbsenceButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[8]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AllDayAbsenceButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AllDayAbsenceButton));
            AllDayAbsenceButton.Click(); 
        }

        public static void selectPartDayAbsence(RemoteWebDriver driver)
        {
            IWebElement PartDayAbsenceButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[9]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(PartDayAbsenceButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(PartDayAbsenceButton));
            PartDayAbsenceButton.Click(); 
        }

        public static void selectAbsencePercentInDaysReason(RemoteWebDriver driver)
        {
            IWebElement AbsencePercentInDaysReasonButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[10]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsencePercentInDaysReasonButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsencePercentInDaysReasonButton));
            AbsencePercentInDaysReasonButton.Click(); 
        }

        public static void selectAbsencePercentInHoursAccount(RemoteWebDriver driver)
        {
            IWebElement AbsencePercentInHoursButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[11]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsencePercentInHoursButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsencePercentInHoursButton));
            AbsencePercentInHoursButton.Click(); 
        }

        public static void selectEmployeeAbsenceTotalOnWeeks(RemoteWebDriver driver)
        {
            IWebElement EmployeeAbsenceTotalOnWeeksButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[12]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(EmployeeAbsenceTotalOnWeeksButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(EmployeeAbsenceTotalOnWeeksButton));
            EmployeeAbsenceTotalOnWeeksButton.Click(); 

        }

        public static void selectAverageAbsenceOnEmployeesPerDepartment(RemoteWebDriver driver)
        {
            IWebElement AverageAbsenceOnEmployeesPerDepartmentButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[13]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AverageAbsenceOnEmployeesPerDepartmentButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AverageAbsenceOnEmployeesPerDepartmentButton));
            AverageAbsenceOnEmployeesPerDepartmentButton.Click(); 
        }

        public static void selectPlannedAbsence(RemoteWebDriver driver)
        {
            IWebElement AverageAbsenceOnEmployeesPerDepartmentButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[14]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AverageAbsenceOnEmployeesPerDepartmentButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AverageAbsenceOnEmployeesPerDepartmentButton));
            AverageAbsenceOnEmployeesPerDepartmentButton.Click(); 
        }

        public static void selectAccountWorkcenterOrder(RemoteWebDriver driver)
        {
            IWebElement AccountWorkcenterOrderButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/div/repeat-list/md-list/div[4]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AccountWorkcenterOrderButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountWorkcenterOrderButton));
            AccountWorkcenterOrderButton.Click(); 
        }

        public static void selectJobOrderQuantity(RemoteWebDriver driver)
        {
            IWebElement JobOrderQuantityButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/div/repeat-list/md-list/div[5]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(JobOrderQuantityButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(JobOrderQuantityButton));
            JobOrderQuantityButton.Click();
        }

        public static void selectGoodsOrder(RemoteWebDriver driver)
        {
            IWebElement GoodsOrderButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/div/repeat-list/md-list/div[6]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(GoodsOrderButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(GoodsOrderButton));
            GoodsOrderButton.Click();
        }

        public static void selectWorkcenterEfficiency(RemoteWebDriver driver)
        {
            IWebElement WorkcenterEfficiencyButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/div/repeat-list/md-list/div[7]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(WorkcenterEfficiencyButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(WorkcenterEfficiencyButton));
            WorkcenterEfficiencyButton.Click();
        }

        public static void selectEmployeeHours(RemoteWebDriver driver)
        {
            IWebElement EmployeeHoursButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/div/repeat-list/md-list/div[8]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(EmployeeHoursButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(EmployeeHoursButton));
            EmployeeHoursButton.Click();
        }

        public static void selectJobCost(RemoteWebDriver driver)
        {
            IWebElement JobCostButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/div/repeat-list/md-list/div[9]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(JobCostButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(JobCostButton));
            JobCostButton.Click();
        }

        public static void selectJobRegistration(RemoteWebDriver driver)
        {
            IWebElement JobRegistrationButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[5]/div/repeat-list/md-list/div[11]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(JobRegistrationButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(JobRegistrationButton));
            JobRegistrationButton.Click();
        }

        public static void selectCustomProjektAktivitetsiRD(RemoteWebDriver driver)
        {
            IWebElement ProjektAktivitetsiRDButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[1]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProjektAktivitetsiRDButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjektAktivitetsiRDButton));
            ProjektAktivitetsiRDButton.Click();
        }

        public static void selectCustomSBAHoursPerEmp(RemoteWebDriver driver)
        {
            IWebElement CustomSBAHoursPerEmpButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[2]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(CustomSBAHoursPerEmpButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(CustomSBAHoursPerEmpButton));
            CustomSBAHoursPerEmpButton.Click();
        }

        public static void selectCustomProjectActivityRegistrationsRD(RemoteWebDriver driver)
        {
            IWebElement CustomProjectActivityRegistrationsRDButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[3]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(CustomProjectActivityRegistrationsRDButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(CustomProjectActivityRegistrationsRDButton));
            CustomProjectActivityRegistrationsRDButton.Click();
        }


        public static void waitRunButtonIsNotVisible(RemoteWebDriver driver)
        {           
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("button[ng-click='vm.runReport()")));
        }

        public static void clickRefreshButton(RemoteWebDriver driver)
        {
            // Click the refresh button when it becomes clickable
            IWebElement RefreshButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[1]/reporting-toolbar/md-toolbar/div/button[1]");
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(RefreshButton));
            RefreshButton.Click();
            Thread.Sleep(1000);
        }

        public static String lastReportName(RemoteWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement table = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/reporting-content/div/div/custom-grid/div[1]/div/div[2]/table/tbody");
            Thread.Sleep(2000);
            IWebElement last = table.FindElement(By.CssSelector("tr:last-child"));
            return last.Text;
        }

        public static void selectCustomSBAHoursPerProject(RemoteWebDriver driver)
        {
            IWebElement CustomSBAHoursPerProjectButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[14]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(CustomSBAHoursPerProjectButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(CustomSBAHoursPerProjectButton));
            CustomSBAHoursPerProjectButton.Click();
        }

        public static void selectCustomSBAHoursPerProject2(RemoteWebDriver driver)
        {
            IWebElement CustomSBAHoursPerProjectButton2 = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[15]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(CustomSBAHoursPerProjectButton2);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(CustomSBAHoursPerProjectButton2));
            CustomSBAHoursPerProjectButton2.Click();
        }

        public static void selectCustomProjectActivityRegistrationsCons(RemoteWebDriver driver)
        {
            IWebElement CustomProjectActivityRegistrationsConsButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[10]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(CustomProjectActivityRegistrationsConsButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(CustomProjectActivityRegistrationsConsButton));
            CustomProjectActivityRegistrationsConsButton.Click();
        }

        public static void selectCustomProjectActivityRegistrationsCons2(RemoteWebDriver driver)
        {
            IWebElement CustomProjectActivityRegistrationsCons2Button = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[11]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(CustomProjectActivityRegistrationsCons2Button);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(CustomProjectActivityRegistrationsCons2Button));
            CustomProjectActivityRegistrationsCons2Button.Click();
        }

        public static void selectRateOfStaffTurnOverCustom(RemoteWebDriver driver)
        {
            IWebElement RateOfStaffTurnOverCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(RateOfStaffTurnOverCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(RateOfStaffTurnOverCustomButton));
            RateOfStaffTurnOverCustomButton.Click();
        }

        public static void selectAccountRegistrationCustom(RemoteWebDriver driver)
        {
            IWebElement AccountRegistrationCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[2]/repeat-list/md-list/div[1]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AccountRegistrationCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountRegistrationCustomButton));
            AccountRegistrationCustomButton.Click();
        }

        public static void selectAccountRegistrationCustom2(RemoteWebDriver driver)
        {
            IWebElement AccountRegistrationCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[2]/repeat-list/md-list/div[2]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AccountRegistrationCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountRegistrationCustomButton));
            AccountRegistrationCustomButton.Click();
        }

        public static void selectAccountRegistrationCustom3(RemoteWebDriver driver)
        {
            IWebElement AccountRegistrationCustom3Button = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[2]/repeat-list/md-list/div[3]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AccountRegistrationCustom3Button);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountRegistrationCustom3Button));
            AccountRegistrationCustom3Button.Click();
        }

        public static void selectKontoregistreringFerie(RemoteWebDriver driver)
        {
            IWebElement KontoregistreringFerieButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[2]/repeat-list/md-list/div[4]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(KontoregistreringFerieButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(KontoregistreringFerieButton));
            KontoregistreringFerieButton.Click();
        }

        public static void selectKontototalerCustom(RemoteWebDriver driver)
        {
            IWebElement KontototalerCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[5]/repeat-list/md-list/div/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(KontototalerCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(KontototalerCustomButton));
            KontototalerCustomButton.Click();
        }

        public static void selectAccountTotalPerMonthCustom(RemoteWebDriver driver)
        {
            IWebElement AccountTotalPerMonthCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[7]/repeat-list/md-list/div/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AccountTotalPerMonthCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountTotalPerMonthCustomButton));
            AccountTotalPerMonthCustomButton.Click();
        }

        public static void selectWorkingTimeDirective11HourRuleCustom(RemoteWebDriver driver)
        {
            IWebElement AccountTotalPerMonthCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[9]/repeat-list/md-list/div[1]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AccountTotalPerMonthCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountTotalPerMonthCustomButton));
            AccountTotalPerMonthCustomButton.Click();
        }

        public static void selectWorkingTimeDirective11HourRuleCustom2(RemoteWebDriver driver)
        {
            IWebElement AccountTotalPerMonthCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[9]/repeat-list/md-list/div[2]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AccountTotalPerMonthCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountTotalPerMonthCustomButton));
            AccountTotalPerMonthCustomButton.Click();
        }

        public static void selectKontoværdierCustom(RemoteWebDriver driver)
        {
            IWebElement KontoværdierCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[10]/repeat-list/md-list/div[1]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(KontoværdierCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(KontoværdierCustomButton));
            KontoværdierCustomButton.Click();
        }

        public static void selectKilometerregnskabCustom(RemoteWebDriver driver)
        {
            IWebElement KilometerregnskabCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[6]/div/repeat-list/md-list/div[10]/repeat-list/md-list/div[2]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(KilometerregnskabCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(KilometerregnskabCustomButton));
            KilometerregnskabCustomButton.Click();
        }

        public static void selectAbsenceHigherThan14DayCustom(RemoteWebDriver driver)
        {
            IWebElement AbsenceHigherThan14DayCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[2]/repeat-list/md-list/div/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsenceHigherThan14DayCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsenceHigherThan14DayCustomButton));
            AbsenceHigherThan14DayCustomButton.Click();
        }

        public static void selectAllDayAbsenceCustom(RemoteWebDriver driver)
        {
            IWebElement AllDayAbsenceCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[8]/repeat-list/md-list/div/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AllDayAbsenceCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AllDayAbsenceCustomButton));
            AllDayAbsenceCustomButton.Click();
        }

        public static void selectTotaltfraværCustom(RemoteWebDriver driver)
        {
            IWebElement AllDayAbsenceCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[3]/repeat-list/md-list/div/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AllDayAbsenceCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AllDayAbsenceCustomButton));
            AllDayAbsenceCustomButton.Click();
        }

        public static void selectBradfordFactorCustom(RemoteWebDriver driver)
        {
            IWebElement BradfordFactorCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[7]/repeat-list/md-list/div/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(BradfordFactorCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(BradfordFactorCustomButton));
            BradfordFactorCustomButton.Click();
        }

        public static void selectAbsencePercentInDaysReasonCustom(RemoteWebDriver driver)
        {
            IWebElement AbsencePercentInDaysReasonCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[10]/repeat-list/md-list/div[1]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsencePercentInDaysReasonCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsencePercentInDaysReasonCustomButton));
            AbsencePercentInDaysReasonCustomButton.Click();
        }

        public static void selectAbsencePercentInDaysReasonCustom2(RemoteWebDriver driver)
        {
            IWebElement AbsencePercentInDaysReasonCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[10]/repeat-list/md-list/div[2]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsencePercentInDaysReasonCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsencePercentInDaysReasonCustomButton));
            AbsencePercentInDaysReasonCustomButton.Click();
        }

        public static void selectAbsencePercentInDaysReasonCustom3(RemoteWebDriver driver)
        {
            IWebElement AbsencePercentInDaysReasonCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[10]/repeat-list/md-list/div[3]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsencePercentInDaysReasonCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsencePercentInDaysReasonCustomButton));
            AbsencePercentInDaysReasonCustomButton.Click();
        }

        public static void  selectAbsencePercentInHoursAccountCustom(RemoteWebDriver driver)
        {
            IWebElement AbsencePercentInHoursAccountCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[11]/repeat-list/md-list/div[1]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsencePercentInHoursAccountCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsencePercentInHoursAccountCustomButton));
            AbsencePercentInHoursAccountCustomButton.Click();
        }


        public static void selectAbsencePercentInHoursAccountCustom2(RemoteWebDriver driver)
        {
            IWebElement AbsencePercentInHoursAccountCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[11]/repeat-list/md-list/div[2]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsencePercentInHoursAccountCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsencePercentInHoursAccountCustomButton));
            AbsencePercentInHoursAccountCustomButton.Click();
        }


        public static void selectAbsencePercentInHoursAccountCustom3(RemoteWebDriver driver)
        {
            IWebElement AbsencePercentInHoursAccountCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[11]/repeat-list/md-list/div[3]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsencePercentInHoursAccountCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsencePercentInHoursAccountCustomButton));
            AbsencePercentInHoursAccountCustomButton.Click();
        }


        public static void selectAbsencePercentInHoursAccountCustom4(RemoteWebDriver driver)
        {
            IWebElement AbsencePercentInHoursAccountCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[3]/div/repeat-list/md-list/div[11]/repeat-list/md-list/div[4]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(AbsencePercentInHoursAccountCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(AbsencePercentInHoursAccountCustomButton));
            AbsencePercentInHoursAccountCustomButton.Click();
        }


        public static void selectBalanceOnEmployeesCrosstabCustom2(RemoteWebDriver driver)
        {
            IWebElement BalanceOnEmployeesCrosstabCustom2Button = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[4]/div/repeat-list/md-list/div[4]/repeat-list/md-list/div[2]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(BalanceOnEmployeesCrosstabCustom2Button);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(BalanceOnEmployeesCrosstabCustom2Button));
            BalanceOnEmployeesCrosstabCustom2Button.Click();
        }

        public static void selectBalanceOnEmployeesCrosstabCustom(RemoteWebDriver driver)
        {
            IWebElement BalanceOnEmployeesCrosstabCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[4]/div/repeat-list/md-list/div[4]/repeat-list/md-list/div[1]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(BalanceOnEmployeesCrosstabCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(BalanceOnEmployeesCrosstabCustomButton));
            BalanceOnEmployeesCrosstabCustomButton.Click();
        }

        public static void selectBalancesOnPeriodCustom(RemoteWebDriver driver)
        {
            IWebElement BalancesOnPeriodCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[4]/div/repeat-list/md-list/div[3]/repeat-list/md-list/div/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(BalancesOnPeriodCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(BalancesOnPeriodCustomButton));
            BalancesOnPeriodCustomButton.Click();
        }

        public static void selectBalanceOnEmployeesCustom(RemoteWebDriver driver)
        {
            IWebElement BalanceOnEmployeesCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[4]/div/repeat-list/md-list/div[2]/repeat-list/md-list/div[1]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(BalanceOnEmployeesCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(BalanceOnEmployeesCustomButton));
            BalanceOnEmployeesCustomButton.Click();
        }

        public static void selectBalanceOnEmployeesCustom2(RemoteWebDriver driver)
        {
            IWebElement BalanceOnEmployeesCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[4]/div/repeat-list/md-list/div[2]/repeat-list/md-list/div[2]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(BalanceOnEmployeesCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(BalanceOnEmployeesCustomButton));
            BalanceOnEmployeesCustomButton.Click();
        }

        public static void selectBalancesOnDepartmentsCustom(RemoteWebDriver driver)
        {
            IWebElement BalancesOnDepartmentsCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[4]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(BalancesOnDepartmentsCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(BalancesOnDepartmentsCustomButton));
            BalancesOnDepartmentsCustomButton.Click();
        }

        public static void selectProjektAktivitetsiRDEMPTimetypeCustom(RemoteWebDriver driver)
        {
            IWebElement ProjektAktivitetsiRDEMPTimetypeButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[4]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProjektAktivitetsiRDEMPTimetypeButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjektAktivitetsiRDEMPTimetypeButton));
            ProjektAktivitetsiRDEMPTimetypeButton.Click();
        }

        public static void selectProjectActivityRegistrationsMFACustom(RemoteWebDriver driver)
        {
            IWebElement ProjectActivityRegistrationsMFACustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[5]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProjectActivityRegistrationsMFACustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjectActivityRegistrationsMFACustomButton));
            ProjectActivityRegistrationsMFACustomButton.Click();
        }

        public static void selectProjectCSVProjectActivityRegistrationsCons(RemoteWebDriver driver)
        {
            IWebElement ProjectCSVProjectActivityRegistrationsConsButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[6]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProjectCSVProjectActivityRegistrationsConsButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjectCSVProjectActivityRegistrationsConsButton));
            ProjectCSVProjectActivityRegistrationsConsButton.Click();
        }

        public static void openExpenseReportMenu(RemoteWebDriver driver)
        {
            // Expense Report Menu
            IWebElement ExpenseReportSelector = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[8]/md-list-item/div/button");
            ExpenseReportSelector.Click();
        }

        public static void closeExpenseReportMenu(RemoteWebDriver driver)
        {
            openExpenseReportMenu(driver);
        }

        public static void selectMileageRegistrations(RemoteWebDriver driver)
        {
            IWebElement MileageRegistrationsButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-card-content/content/reporting/div/div[2]/div/reporting-navbar/md-list[8]/div/repeat-list/md-list/div/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(MileageRegistrationsButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(MileageRegistrationsButton));
            MileageRegistrationsButton.Click();
        }

        public static void selectMileageRegistrationsCustom(RemoteWebDriver driver)
        {
            IWebElement MileageRegistrationsButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[8]/div/repeat-list/md-list/div/repeat-list/md-list/div[1]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(MileageRegistrationsButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(MileageRegistrationsButton));
            MileageRegistrationsButton.Click();
        }

        public static void selectMileageRegistrationsCustom2(RemoteWebDriver driver)
        {
            IWebElement MileageRegistrationsButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[8]/div/repeat-list/md-list/div/repeat-list/md-list/div[2]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(MileageRegistrationsButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(MileageRegistrationsButton));
            MileageRegistrationsButton.Click();
        }

        public static void selectMileageRegistrationsCustom3(RemoteWebDriver driver)
        {
            IWebElement MileageRegistrationsButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[8]/div/repeat-list/md-list/div/repeat-list/md-list/div[3]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(MileageRegistrationsButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(MileageRegistrationsButton));
            MileageRegistrationsButton.Click();
        }

        public static void selectProjektAktivitetsiRDEMPTimetype(RemoteWebDriver driver)
        {
            IWebElement ProjektAktivitetsiRDEMPTimetypeButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[7]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProjektAktivitetsiRDEMPTimetypeButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjektAktivitetsiRDEMPTimetypeButton));
            ProjektAktivitetsiRDEMPTimetypeButton.Click();
        }

        public static void selectProjektAktivitetsregistreringeriRD(RemoteWebDriver driver)
        {
            IWebElement ProjektAktivitetsregistreringeriRDButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[8]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProjektAktivitetsregistreringeriRDButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjektAktivitetsregistreringeriRDButton));
            ProjektAktivitetsregistreringeriRDButton.Click();
        }

        public static void selectProjectActivityregistrationsCustom(RemoteWebDriver driver)
        {
            IWebElement ProjectActivityregistrationsCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[9]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProjectActivityregistrationsCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjectActivityregistrationsCustomButton));
            ProjectActivityregistrationsCustomButton.Click();
        }

        public static void selectSBAProjektAktivitetsiRDCustom(RemoteWebDriver driver)
        {
            IWebElement ProjectActivityregistrationsCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[12]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProjectActivityregistrationsCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjectActivityregistrationsCustomButton));
            ProjectActivityregistrationsCustomButton.Click();
        }



        public static void selectsbProjectActivityregistrationsCustom(RemoteWebDriver driver)
        {
            IWebElement ProjectActivityregistrationsCustomButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-card/md-card-content/div/reporting/div/div[2]/div/reporting-navbar/md-list[7]/div/repeat-list/md-list/div[1]/repeat-list/md-list/div[13]/md-list-item/div/button");
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProjectActivityregistrationsCustomButton);
            actions.Perform();
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(ExpectedConditions.ElementToBeClickable(ProjectActivityregistrationsCustomButton));
            ProjectActivityregistrationsCustomButton.Click();
        }

        public static void setActualPassword(RemoteWebDriver driver, String password)
        {
            IWebElement ActualPasswordField = driver.FindElementByCssSelector("input[type='password'][name='password']");
            ActualPasswordField.SendKeys(password);
        }

        public static void setNewPassword(RemoteWebDriver driver, String newPassword)
        {
            IWebElement ActualPasswordField = driver.FindElementByCssSelector("input[type='password'][name='newPassword']");
            ActualPasswordField.SendKeys(newPassword);
        }

        public static void setConfirmationPassword(RemoteWebDriver driver, String confirmPassword)
        {
            IWebElement ActualPasswordField = driver.FindElementByCssSelector("input[type='password'][name='confirmNewPassword']");
            ActualPasswordField.SendKeys(confirmPassword);
        }

        public static void confirmPasswordChange(RemoteWebDriver driver)
        {
            IWebElement ConfirmButton = driver.FindElementByCssSelector("button[type='button'][ng-click='vm.ok()']");
            ConfirmButton.Click();
        }

        public static void editWebPartPropertiesRegistration(RemoteWebDriver driver)
        {
            IWebElement EditSettingsButton = driver.FindElementByXPath("//*[@id='main-content']/div/ui-view/features-orchestration/md-grid-list/md-grid-tile[1]/figure/webpart-frame/md-card/md-toolbar/div/md-menu/button");
            EditSettingsButton.Click();
            Thread.Sleep(2000);
            var EditButtons = driver.FindElementsByCssSelector("ng-md-icon[icon='settings'][class='ng-scope']");           
            IWebElement t2 = EditButtons[1];           
            t2.Click();
            Thread.Sleep(2000);
        }

        public static void setTerminalRegistration(RemoteWebDriver driver, String terminal)
        {
            IWebElement terminalField = driver.FindElementByCssSelector("input[name='attribute_Terminal'][type='number']");
            terminalField.Clear();
            terminalField.SendKeys(terminal);
        }

        public static void savePropertiesRegistration(RemoteWebDriver driver)
        {
            IWebElement saveButton = driver.FindElementByCssSelector("button[type='button'][ng-click='vm.ok()']");
            saveButton.Click();
        }

        public static void openLeftSideMenu(RemoteWebDriver driver)
        {
            IWebElement menuButton = driver.FindElementByXPath("//*[@id='shell']/md-content/div/section/top-nav/md-toolbar/div/div[1]");
            menuButton.Click();
            Thread.Sleep(1000);
        }

        public static void selectMenuTab(RemoteWebDriver driver, int position)
        {
            IWebElement menuElement = driver.FindElementByXPath("//*[@id='shell']/md-content/div/md-sidenav/sidebar-left/md-content/md-list");
                                                                       
            var menuItems = menuElement.FindElements(By.TagName("md-list-item"));

            IWebElement userMenuLink = menuItems[position];

            userMenuLink.Click();

            Thread.Sleep(2000);
        }

        public static void closeLeftSideMenu(RemoteWebDriver driver)
        {
            IWebElement menuButton = driver.FindElementByXPath("//*[@id='shell']/md-content/div/section/top-nav/md-toolbar/div/div[1]");
            menuButton.Click();
            Thread.Sleep(1000);
        }

    }
}
