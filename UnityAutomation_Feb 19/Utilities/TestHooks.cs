using Microsoft.Extensions.Options;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Repositories;

namespace WiniumPOC.Utilities
{
    [Binding]
    public class TestHooks
    {
        private readonly ScenarioContext scenarioContext;
        public TestHooks(ScenarioContext scenariContext)
        {
            this.scenarioContext= scenariContext;
        }

        [BeforeTestRun]
        public static void Initialize()
        {
            Global.options = new DesktopOptions { ApplicationPath = ConfigFile.appPath };
            Global.options.ApplicationPath = ConfigFile.appPath;
            //Global.driver = new WiniumDriver(@"C:\Temp", Global.options);
            //Thread.Sleep(80000);
            ReportHelper.startLog(ConfigFile.reportLocation);
            new ReportHelper().GenerateReport(ConfigFile.reportLocation);

        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            var scenarioName = scenarioContext.ScenarioInfo.Title;
            var scenarioDescription = scenarioContext.ScenarioInfo.Description;
            new ReportHelper().StartExtentTest(scenarioName, scenarioDescription);

        }
        [BeforeStep]
        public void TestStep()
        {
            new ReportHelper().WriteLog("Info", "STEP EXECUTED :" + ScenarioStepContext.Current.StepInfo.Text);
        }
        
        [AfterScenario]
        public static void AfterScenario()
        {
            ReportHelper.EndTest(ReportHelper.extentTests);
        }
        [AfterTestRun]

        public static void Terminate()
        {
            ReportHelper.Flush();
            //new EmailNotification().SendEmail(ConfigFile.mailToRecipients, ConfigFile.mailCCRecipients, ConfigFile.subjectLine, "Yes", "");
                      
        }
        
        [TearDown]
        public void TestCleanup()
        {
            if (Global.driver != null)
            {
                Global.driver.Quit();
                Global.driver = null;
            }

        }

    }

}