using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Repositories;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows
{
    [Binding]

    public class Option
    {
        IWebElement showDefault;
        IWebElement okButton;
        IWebElement closeButton;
        IWebElement customShowActions;
        IWebElement departmentCheckbox;
        IWebElement departmentDropdown;
        IWebElement operatorCheckbox;
        IWebElement operatorDropdown;


        public Option()
        {
            showDefault = Global.driver.FindElementById("rb_default");
            okButton = Global.driver.FindElementById("cb_ok");
            closeButton = Global.driver.FindElementById("cb_close");
            //customShowActions = Global.driver.FindElementById("rb_custom");
            customShowActions = Global.driver.FindElementByName("Custom show actions");
            departmentCheckbox = Global.driver.FindElementById("cbx_reparto");
            operatorCheckbox = Global.driver.FindElementById("cbx_operatore");
            departmentDropdown = Global.driver.FindElementById("ddlb_reparto");
            operatorDropdown = Global.driver.FindElementById("ddlb_operatore");
        }
        [Then(@"in Options window select radio button '(.*)'")]
        public void ThenInOptionsWindowSelectRadioButton(string selectOption)
        {
            try
            {
                switch (selectOption.ToLower())
                {

                    case "show today actions":
                        Global.driver.FindElementById("TitleBar").Click();
                        new ControlHelper().ClickOnElement(showDefault);
                        break;
                    case "custom show actions":
                        new ControlHelper().ClickOnElement(customShowActions);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on option " + selectOption + " due to exception " + e.Message);
            }
        }
        //[Then(@"check if '(.*)' window is opened")]
        //public void ThenCheckIfWindowIsOpened(string windowName)
        //{
        //    new ControlHelper().CheckIfWindowIsLoaded(windowName);
        //}


        [Then(@"in Options window click '(.*)' button")]
        public void ThenInOptionsWindowClickButton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {

                    case "ok":
                        new ControlHelper().ClickOnElement(okButton);
                        break;
                    case "close":
                        new ControlHelper().ClickOnElement(closeButton);
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

        [Then(@"in Options window click on '(.*)' checkbox")]
        public void ThenInOptionsWindowClickOnCheckbox(string fieldName)
        {
            try
            {
                switch (fieldName.ToLower())
                {

                    case "department":
                        new ControlHelper().ClickOnElement(departmentCheckbox);
                        break;
                    case "operator":
                        new ControlHelper().ClickOnElement(operatorCheckbox);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on checkbox " + fieldName + " due to exception " + e.Message);
            }
           
        }

        [Then(@"in Options window select value '(.*)' from the '(.*)' dropdown")]
        public void ThenInOptionsWindowSelectValueFromTheDropdown(string value, string fieldName)
        {
            try
            {
                switch (fieldName.ToLower())
                {
                    case "department":
                        new ControlHelper().ComboboxSelectItem(departmentDropdown, value);
                        break;
                    case "operator":
                        new ControlHelper().ComboboxSelectItem(operatorDropdown, value);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to select value " + value + " due to exception " + e.Message);
            }
        }

    }
}
