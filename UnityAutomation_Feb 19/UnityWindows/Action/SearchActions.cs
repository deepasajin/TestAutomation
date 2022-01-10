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

    public class SearchActions
    {
        IWebElement okButton;
        IWebElement cancelButton;
        IWebElement fileStatus;
        IWebElement fileStatusComboBox;
        IWebElement product;
        IWebElement productComboBox;
        IWebElement departments;
        IWebElement departmentsComboBox;
        IWebElement fileType;
        IWebElement fileTypeComboBox;


        public SearchActions()
        {
            okButton = Global.driver.FindElementById("cb_ok");
            cancelButton = Global.driver.FindElementById("cb_annulla");
            fileStatus= Global.driver.FindElementById("cbx_status");
            //fileStatusComboBox = Global.driver.FindElementById("1001");
            product = Global.driver.FindElementById("cbx_prodotto");
            productComboBox = Global.driver.FindElementById("ddlb_prodotto");
            departments = Global.driver.FindElementById("cbx_reparto");
            departmentsComboBox = Global.driver.FindElementById("lbox_reparto");
            fileType = Global.driver.FindElementById("cbx_avvenimento");
            fileTypeComboBox = Global.driver.FindElementById("ddlb_avvenimento");


        }

        [Then(@"in Search Action window click '(.*)' button")]
        public void ThenInSearchActionWindowClickButton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {

                    case "ok":
                        new ControlHelper().ClickOnElement(okButton);
                        break;
                    case "cancel":
                        new ControlHelper().ClickOnElement(cancelButton);
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

        [Then(@"in Search Action window click the filter option '(.*)' and select the drop down value '(.*)'")]
        public void ThenInSearchActionWindowClickTheFilterOptionAndSelectTheDropDownValue(string fieldName, string value)
        {
            try
            {
                switch (fieldName.ToLower())
                {

                    case "filestatus":
                        new ControlHelper().ClickOnElement(fileStatus);
                        new ControlHelper().EnterTheValueToTextField(fileStatusComboBox, value);
                        break;
                    case "product":
                        new ControlHelper().ClickOnElement(product);
                        new ControlHelper().ComboboxSelectItem(productComboBox, value);
                        break;
                    case "departments":
                        new ControlHelper().ClickOnElement(departments);
                        Global.driver.FindElementByName(value).Click();
                        break;
                    case "filetype":
                        new ControlHelper().ClickOnElement(fileType);
                        new ControlHelper().ComboboxSelectItem(fileTypeComboBox, value);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on field " + fieldName + " and select value " +value+ " due to exception " + e.Message);
            }
        }




    }
}
