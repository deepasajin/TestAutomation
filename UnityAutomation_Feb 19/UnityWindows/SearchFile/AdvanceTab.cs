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

    public class AdvanceTab
    {

        public IWebElement criteriaButton;
        public IWebElement saveButton;
        public IWebElement criteriaCombobox;
        public IWebElement criteriaDisplay;

        public AdvanceTab()
        {

            criteriaButton = Global.driver.FindElementById("cb_criteri");
            saveButton = Global.driver.FindElementById("btn_saveCriteria");
            criteriaCombobox = Global.driver.FindElementById("cmb_criteria");
            criteriaDisplay = Global.driver.FindElementById("mle_criteri");

        }

        [Then(@"in Advance tab click '(.*)' button")]
        public void ThenInAdvanceTabClickButton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {

                    case "criteria":
                        new ControlHelper().ClickOnElement(criteriaButton);
                        break;
                    case "save":
                        new ControlHelper().ClickOnElement(saveButton);
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

        [Then(@"in Advance tab select criteria '(.*)'")]
        public void ThenInAdvanceTabSelectCriteria(string value)
        {
            IWebElement criteria = Global.driver.FindElementById("cmb_criteria");
            new ControlHelper().ComboboxSelectItem(criteria, value);
        }
        [Then(@"in Advance tab verify search criteria is '(.*)'")]
        public void ThenInAdvanceTabVerifySearchCriteriaIs(string value)
        {
            string criteriaDisplayed = criteriaDisplay.Text;
            if (criteriaDisplayed != null)
            {
                value = value.Replace("$", "'");
                value = value.Replace(" ", "").ToLower();
                criteriaDisplayed = criteriaDisplayed.Replace(" ", "").ToLower();               
                if (value.Equals(criteriaDisplayed))
                {
                    new ReportHelper().WriteLog("Pass", "Criteria displayed is as expected : " + value);
                }
                else
                {
                    new ReportHelper().WriteLog("Fail", "Expected criteria value did not match. Expected value : " + value + " Actual Value : " + criteriaDisplayed);
                }
            }
            else
            {
                new ReportHelper().WriteLog("Fail", " No criteria displayed in Advance tab.");
            }
        }
        [Then(@"in Advance search result click on '(.*)' value in '(.*)' column")]
        public void ThenInAdvanceSearchResultClickOnValueInColumn(string value, string columnName)
        {
            IWebElement resultGrid = Global.driver.FindElementById("dataGridViewAdvanceSearchResult");
            new DataGridHandler().FindAndClickOnCellUsingColumnnameAndValue(value,columnName,resultGrid);
        }


        #region AdvanceSearch
        [Then(@"in Advance search window select value '(.*)' in the field '(.*)'")]
        public void ThenInAdvanceSearchWindowSelectValueInTheField(string value, string fieldName)
        {
            IWebElement fieldCombobox = Global.driver.FindElementById("ddlb_campo");
            IWebElement confrontation = Global.driver.FindElementById("ddlb_operatore");           
            try
            {
                switch (fieldName.ToLower())
                {

                    case "field":
                        new ControlHelper().ComboboxSelectItemByIndex(fieldCombobox, value);
                        break;
                    case "confrontation":
                        new ControlHelper().EditTypeComboboxSelectItem(confrontation, value);
                        break;                    
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on field " + fieldName + " and select value " + value + " due to exception " + e.Message);
            }
        }
        [Then(@"in Advance search window enter value '(.*)' in the field '(.*)'")]
        public void ThenInAdvanceSearchWindowEnterValueInTheField(string value, string fieldName)
        {
            IWebElement valueEditField = Global.driver.FindElementById("sle_valore");
            try
            {
                switch (fieldName.ToLower())
                {

                    case "value":
                        new ControlHelper().EnterTheValueToTextField(valueEditField, value);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to enter value in field " + fieldName + " due to exception " + e.Message);
            }
        }
        [Then(@"in Advance search window click '(.*)' button")]
        public void ThenInAdvanceSearchWindowClickButton(string buttonName)
        {
            IWebElement addButton = Global.driver.FindElementById("pb_add");
            IWebElement delButton = Global.driver.FindElementById("pb_delete");
            IWebElement okButton = Global.driver.FindElementById("cb_ok");
            IWebElement cancelButton = Global.driver.FindElementById("cb_close");
            try
            {
                switch (buttonName.ToLower())
                {

                    case "add":
                        new ControlHelper().ClickOnElement(addButton);
                        break;
                    case "del":
                        new ControlHelper().ClickOnElement(delButton);
                        break;
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
        [Then(@"in Advance search window select '(.*)' radio button")]
        public void ThenInAdvanceSearchWindowSelectRadioButton(string radioButton)
        {
            IWebElement andRadioButton = Global.driver.FindElementById("rb_and");
            IWebElement orRadioButton = Global.driver.FindElementById("rb_or");
            try
            {
                switch (radioButton.ToLower())
                {

                    case "and":
                        new ControlHelper().ClickOnElement(andRadioButton);
                        break;
                    case "or":
                        new ControlHelper().ClickOnElement(orRadioButton);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to select radio button " + radioButton + " due to exception " + e.Message);
            }
        }
        #endregion

        #region SaveSearchCriteria
        [Then(@"in Save Serach Criteria window enter value '(.*)' in the field '(.*)'")]
        public void ThenInSaveSerachCriteriaWindowEnterValueInTheField(string value, string fieldName)
        {
            IWebElement nameEditField = Global.driver.FindElementById("tbx_criteriaName");
            try
            {
                switch (fieldName.ToLower())
                {

                    case "name":
                        new ControlHelper().EnterTheValueToTextField(nameEditField, value);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to enter value in field " + fieldName + " due to exception " + e.Message);
            }
        }
        [Then(@"in Save Serach Criteria window select value '(.*)' in Permissions radio button")]
        public void ThenInSaveSerachCriteriaWindowSelectValueInPermissionsRadioButton(string radioButton)
        {
            IWebElement privateRadioButton = Global.driver.FindElementById("rb_private");
            IWebElement deprtRadioButton = Global.driver.FindElementById("rb_department");
            IWebElement profileRadioButton = Global.driver.FindElementById("rb_profile");
            IWebElement publicRadioButton = Global.driver.FindElementById("rb_public");
            try
            {
                switch (radioButton.ToLower())
                {

                    case "private":
                        new ControlHelper().ClickOnElement(privateRadioButton);
                        break;
                    case "department":
                        new ControlHelper().ClickOnElement(deprtRadioButton);
                        break;
                    case "public":
                        new ControlHelper().ClickOnElement(publicRadioButton);
                        break;
                    case "profile":
                        new ControlHelper().ClickOnElement(profileRadioButton);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to select radio button " + radioButton + " due to exception " + e.Message);
            }
        }
        [Then(@"in Save Serach Criteria window select value '(.*)' in Department checkbox")]
        public void ThenInSaveSerachCriteriaWindowSelectValueInDepartmentCheckbox(string value)
        {
            try
            {
                Global.driver.FindElementByName(value).Click();
                new ReportHelper().WriteLog("Pass", "Successfully selected checkbox " + value + " in Departments");
            }
            catch(Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to select checkbox  " + value + " due to exception " + e.Message);
            }
        }
        [Then(@"in Save Serach Criteria window click '(.*)' button")]
        public void ThenInSaveSerachCriteriaWindowClickButton(string buttonName)
        {
            IWebElement saveButton = Global.driver.FindElementById("btn_save");
            IWebElement closeButton = Global.driver.FindElementById("cb_close");
            try
            {
                switch (buttonName.ToLower())
                {

                    case "save":
                        new ControlHelper().ClickOnElement(saveButton);
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
        #endregion
    }
}
