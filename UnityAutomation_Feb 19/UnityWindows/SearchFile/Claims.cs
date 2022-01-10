using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows.SearchFile
{
    [Binding]

    public class Claims
    {
        IWebElement resultTable;
        IWebElement endCustomerLastName;
        IWebElement endCustomerFirstName;
        IWebElement compField;
        IWebElement progressiveField;
        IWebElement branchField;

        public Claims()
        {
            endCustomerLastName = Global.driver.FindElementById("sle_surname_ric");
            endCustomerFirstName = Global.driver.FindElementById("sle_name_ric");
            //compField = Global.driver.FindElementById("sle_sin_comp");
            //progressiveField = Global.driver.FindElementById("sle_sin_progressivo");
            //branchField = Global.driver.FindElementById("sle_sin_ramo");
        }

        [Then(@"in Claims tab click on '(.*)' value in the column '(.*)' in search result table")]
        public void ThenInClaimsTabClickOnValueInTheColumnInSearchResultTable(string value, string columnName)
        {
            resultTable = Global.driver.FindElementById("dataGridViewSearchResult");
            new DataGridHandler().FindAndClickOnCellUsingColumnnameAndValue(value, columnName, resultTable);
        }

        [Then(@"in Claims tab enter the value '(.*)' in the field '(.*)'")]
        public void ThenInClaimsTabEnterTheValueInTheField(string value, string fieldName)
        {
           try
            {
                switch (fieldName.ToLower())
                {
                    case "endcustomerlastname":
                        new ControlHelper().EnterTheValueToTextField(endCustomerLastName, value);
                        break;
                    case "endcustomerfirstname":
                        new ControlHelper().EnterTheValueToTextField(endCustomerFirstName, value);
                        break;
                    case "comp":
                        new ControlHelper().EnterTheValueToTextField(compField, value);
                        break;
                    case "progressive":
                        new ControlHelper().EnterTheValueToTextField(progressiveField, value);
                        break;
                    case "branch":
                        new ControlHelper().EnterTheValueToTextField(branchField, value);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to enter the value in  " + fieldName + " due to exception " + e.Message);
            }
        }

        [Then(@"in Claims tab verify if the values in the column '(.*)' contains '(.*)'")]
        public void ThenInClaimsTabVerifyIfTheValuesInTheColumnContains(string columnName, string value)
        { 
            resultTable = Global.driver.FindElementById("dataGridViewSearchResult");
            new DataGridHandler().VerifyAllValuesUsingColumnAndValue(value, columnName, resultTable);
        }

        //[Then(@"in Search window click on the '(.*)' tab")]
        //public void ThenInSearchWindowClickOnTheCountryTab(string tabName)
        //{
        //    IWebElement mainTab = Global.driver.FindElementById("tabControlSearch");
        //    try
        //    {
        //        Global.driver.FindElementByName(tabName).Click();
        //        new ReportHelper().WriteLog("Pass", "Successfully clicked on the Search Tab " + tabName);
        //    }
        //    catch (Exception e)
        //    {
        //        new ReportHelper().WriteLog("Fail", "Unable to click on tab  " + tabName + " due to exception " + e.Message);
        //    }
        //}
    }
}
