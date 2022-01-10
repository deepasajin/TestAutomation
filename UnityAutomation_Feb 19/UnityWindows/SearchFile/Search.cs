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

    public class Search
    {

        public IWebElement resultTable;
        public IWebElement searchButton;
        public IWebElement okButton;
        public IWebElement cancelButton;
        public IWebElement printButton;
        public IWebElement endCustomerTab;
        public IWebElement claimsTab;
        public IWebElement dateTimePicker;
        public IWebElement mergeCheckbox;

        public Search()
        {
            searchButton = Global.driver.FindElementById("cb_ricerca");
            okButton = Global.driver.FindElementById("cb_ok");
            cancelButton = Global.driver.FindElementById("cb_close");
            printButton = Global.driver.FindElementById("cb_print");
            mergeCheckbox = Global.driver.FindElementByName("Include this tab in merged search");
            //endCustomerTab = Global.driver.FindElementByName("End Customer");
            //claimsTab = Global.driver.FindElementByName("Claims");
            //dateTimePicker = Global.driver.FindElementById("em_DateFrom");

        }

        #region Country
        [Then(@"in Country tab click on '(.*)' value in the column '(.*)' in search result table")]
        public void ThenInClaimsTabClickOnValueInTheColumnInSearchResultTable(string value, string columnName)
        {
            resultTable = Global.driver.FindElementById("dataGridViewSearchResult");
            new DataGridHandler().FindAndClickOnCellUsingColumnnameAndValue(value, columnName, resultTable);
        }

        [Then(@"in Search window enter the value '(.*)' in the field '(.*)'")]
        public void ThenInSearchWindowEnterTheValueInTheField(string value, string fieldName)
        {
            IWebElement endCustomerLastName = Global.driver.FindElementById("sle_surname_ric");
            IWebElement endCustomerFirstName = Global.driver.FindElementById("sle_name_ric");
            IWebElement fromInterval = Global.driver.FindElementById("em_danumero");
            IWebElement toInterval = Global.driver.FindElementById("em_anumero");
           
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
                    case "frominterval":
                        new ControlHelper().EnterTheValueToTextField(fromInterval, value);
                        break;
                    case "tointerval":
                        new ControlHelper().EnterTheValueToTextField(toInterval, value);
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
        #endregion

        [Then(@"in Search window click on '(.*)' checkbox")]
        [Then(@"in Search window click on '(.*)' button")]
        public void ThenInSearchWindowClickOnButton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {

                    case "search":
                        new ControlHelper().ClickOnElement(searchButton);
                        break;
                    case "ok":
                        new ControlHelper().ClickOnElement(okButton);
                        break;
                    case "cancel":
                        new ControlHelper().ClickOnElement(cancelButton);
                        break;
                    case "print":
                        new ControlHelper().ClickOnElement(printButton);
                        break;
                    case "include this tab in merged search":
                        new ControlHelper().ClickOnElement(mergeCheckbox);
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

        [Then(@"in File Management window click on '(.*)' tab")]
        [Then(@"in Search window click on '(.*)' tab")]
        public void ThenInSearchWindowClickOnTab(string tabName)
        {
            try
            {
                Global.driver.FindElementByName(tabName).Click();
                new ReportHelper().WriteLog("Pass", "Successfully clicked on the Search Tab "+tabName);
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on tab  " + tabName + " due to exception " + e.Message);
            }
        }

        [Then(@"in window select date '(.*)'")]
        public void ThenInWindowSelectDate(string date)
        {
            IWebElement ToName = Global.driver.FindElementByName("Creation date");
            IWebElement ToID = Global.driver.FindElementById("em_dataapertura");
            //IWebElement datePicker = Global.driver.FindElementById("em_DateFrom");
            ToID.Click();
            ToID.ToListBox();
            var comb = ToID.ToComboBox();
            comb.Expand();
        
        }

        #region Country
        //[Then(@"in Search window click on the '(.*)' tab")]
        //public void ThenInSearchWindowClickOnTheCountryTab(string tabName)
        //{
        //    IWebElement mainTab = Global.driver.FindElementById("tabControlSearch");
        //    try
        //    {
        //        //System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> maintabChildren = mainTab.FindElements(By.XPath("./child::*"));
        //        //foreach (IWebElement e in maintabChildren)
        //        //{
        //        //    var tabname = e.GetAttribute("Name");
        //        //    if (tabname.ToLower().Equals(tabName.ToLower()))
        //        //        e.Click();
        //        //}
        //        Global.driver.FindElementByName(tabName).Click();
        //        new ReportHelper().WriteLog("Pass", "Successfully clicked on the Search Tab " + tabName);
        //    }
        //    catch (Exception e)
        //    {
        //        new ReportHelper().WriteLog("Fail", "Unable to click on tab  " + tabName + " due to exception " + e.Message);
        //    }
        //}

        [Then(@"in Country tab enter value '(.*)' in the field '(.*)'")]
        public void ThenInCountryTabEnterValueInTheField(string value, string fieldName)
        { 
            try
            {
                IWebElement lastName = Global.driver.FindElementById("sle_surname_ric");
                IWebElement firstName = Global.driver.FindElementById("sle_name_ric");

                switch (fieldName.ToLower())
                {

                    case "lastname":
                        new ControlHelper().EnterTheValueToTextField(lastName, value);
                        break;
                    case "firstname":
                        new ControlHelper().EnterTheValueToTextField(firstName, value);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to enter value in the field " + fieldName + " due to exception " + e.Message);
            }

        }
        [Then(@"in Country tab select value '(.*)' from the Country dropdown")]
        public void ThenInCountryTabSelectValueFromTheCountryDropdown(string value)
        {
            IWebElement countryDropdown = Global.driver.FindElementById("ddlb_nazione");
            try
            { 
              new ControlHelper().ComboboxSelectItem(countryDropdown, value);
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to select value " + value + "from dropdown due to exception " + e.Message);
            }
        }
        #endregion
        
    }
}

