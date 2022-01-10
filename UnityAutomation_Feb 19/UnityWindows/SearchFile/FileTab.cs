using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Winium.Elements.Desktop.Extensions;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows.SearchFile
{
    [Binding]

    public class FileTab
    {
        public IWebElement codeRadiobutton;
        public IWebElement intervalRadiobutton;
        public IWebElement extClaimNumberRadiobutton;

        public FileTab()
        {
            //codeRadiobutton = Global.driver.FindElementById("rb_diretto");
            //intervalRadiobutton = Global.driver.FindElementById("ddlb_tipodox");
            //extClaimNumberRadiobutton = Global.driver.FindElementById("rb_externalclaimnr");
            //codeRadiobutton = Global.driver.FindElementByName("Code");
            //intervalRadiobutton = Global.driver.FindElementByName("Interval");
            //extClaimNumberRadiobutton = Global.driver.FindElementByName("External Claim Number");
        }

        [Then(@"in File tab click on '(.*)' radiobutton")]
        public void ThenInSearchWindowClickOnRadiobutton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {

                    case "code":
                        new ControlHelper().ClickOnElement(codeRadiobutton);
                        break;
                    case "interval":
                        new ControlHelper().ClickOnElement(intervalRadiobutton);
                        break;
                    case "externalclaimnumber":
                        new ControlHelper().ClickOnElement(extClaimNumberRadiobutton);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on button " + buttonName + " due to exception " + e.Message);
            }
        }
    }
}