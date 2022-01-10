using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows.Action
{
    [Binding]

    public class ActionDetails
    {
        IWebElement fileNumber;
        IWebElement endCustomerName;
        IWebElement product;
        IWebElement department;
        IWebElement country;
        IWebElement closeButton;
        IWebElement deadline;
        IWebElement time;
        IWebElement actionDesc;

        public ActionDetails()
        {
            fileNumber = Global.driver.FindElementById("st_dossier_id");
            endCustomerName = Global.driver.FindElementById("st_assicurato");
            product = Global.driver.FindElementById("st_product");
            department = Global.driver.FindElementById("st_reparto");
            country = Global.driver.FindElementById("st_nazione");
            closeButton = Global.driver.FindElementById("cb_close");
            deadline = Global.driver.FindElementById("st_scadenza");
            time = Global.driver.FindElementById("st_ora");
            actionDesc = Global.driver.FindElementById("mle_testonota");
        }

        [Then(@"in Action Details window verify if the value is '(.*)' in the field '(.*)'")]
        public void ThenInActionDetailsWindowVerifyIfTheValueIsInTheField(string value, string fieldName)
        {
            try
            {
                string getValue = "";
                switch (fieldName.ToLower())
                {
                    case "file":
                        getValue = new ControlHelper().GetTheValueOfTextField(fileNumber);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);
                        break;
                    case "end customer":
                        getValue = new ControlHelper().GetTheValueOfTextField(endCustomerName);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);
                        break;
                    case "product":
                        getValue = new ControlHelper().GetTheValueOfTextField(product);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);
                        break;
                    case "department":
                        getValue = new ControlHelper().GetTheValueOfTextField(department);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);
                        break;
                    case "country":
                        getValue = new ControlHelper().GetTheValueOfTextField(country);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);
                        break;
                    case "deadline":
                        getValue = new ControlHelper().GetTheValueOfTextField(deadline);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);
                        break;
                    case "time":
                        getValue = new ControlHelper().GetTheValueOfTextField(time);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);
                        break;
                    case "action description":
                        getValue = new ControlHelper().GetTheValueOfTextField(actionDesc);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to  fetch value in   " + fieldName + "due to exception : " + e.Message);
            }
        }

        //[Then(@"in Product alert info window click '(.*)' button")]
        [Then(@"in Action Details window click '(.*)' button")]
        public void ThenInActionDetailsWindowClickButton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {
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

    }
}
