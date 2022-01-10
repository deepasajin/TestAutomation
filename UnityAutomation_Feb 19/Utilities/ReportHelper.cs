using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;

namespace WiniumPOC.Utilities
{

    public class ReportHelper
    {
        public static ExtentReports extentReports;
        public static ExtentTest extentTests;
        public static string TestRunDirectory;
        private readonly ScenarioContext scenarioContext;
        
        public ReportHelper()
        {

        }
        public ReportHelper(ScenarioContext scenariContext)
        {
            this.scenarioContext = scenariContext;
        }
        public static void startLog(string reportLocation)
        {
            if (extentReports == null)
            {
                extentReports = new ExtentReports(reportLocation, true);
            }
        }
        public void GenerateReport(string reportLocation)
        {
            try
            {
                if (!Directory.Exists(reportLocation))
                {
                    Directory.CreateDirectory(reportLocation);
                }
            }
            catch (Exception e)
            {

                WriteLog("Fail", "Unable to craete report directory: " + reportLocation);
            }
            TestRunDirectory = reportLocation + "\\TestRun";
            if(!Directory.Exists(TestRunDirectory))
            {
                Directory.CreateDirectory(TestRunDirectory);

            }
            string reportPath = TestRunDirectory + "/ExtentReports" + GenericMethods.DateandTimeToString()+".html";
            extentReports = new ExtentReports(reportPath, false);
            extentReports.LoadConfig(reportLocation);
            reportPath = reportPath.Replace(@"\\", @"\");
            reportPath = Regex.Replace(reportPath, "/", "");
            System.IO.File.WriteAllText( reportLocation + "\\HTMLReportPath.txt", reportPath);

        }
        public void WriteLog(string stepStatus, string message)
        {
            LogStatus status = LogStatus.Unknown;
           
            switch (stepStatus.ToLower())
            {
                case "info":
                    status = LogStatus.Info;
                    break;
                case "pass":
                    status = LogStatus.Pass;
                    break;
                case "fail":
                    status = LogStatus.Fail;
                    break;
                default:
                    break;
            }
            extentTests.Log(status, message);
        }

        public void StartExtentTest(string testName, string description)
        {
            extentTests = extentReports.StartTest(testName, description);
            //WriteLog("Info", "Scenario Execution Started: " + testName);
            //WriteLog("Info", "Scenario Execution Started: " + scenarioContext.ScenarioInfo.Title);

        }
        public static void EndTest(ExtentTest test)
        {
            extentReports.EndTest(test);
        }

        public static void Flush()
        {
            extentReports.Flush();
        }
        
        
    }
}
