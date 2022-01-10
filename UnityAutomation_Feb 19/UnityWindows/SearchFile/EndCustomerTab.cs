using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows.SearchFile
{
    [Binding]
    public class EndCustomerTab
    {

        public IWebElement lastName;
        public IWebElement firstName;
        public IWebElement chassis;
        public IWebElement licensePlate;
        public IWebElement policyNumber;
        public IWebElement DOB;
        public IWebElement title;
        public IWebElement phone;
        public IWebElement searchButton;
        public IWebElement resultTable;


        public EndCustomerTab()
        {

            lastName = Global.driver.FindElementById("sle_surname");
            firstName = Global.driver.FindElementById("sle_name");
            chassis = Global.driver.FindElementById("sle_chassisnumber");
            licensePlate = Global.driver.FindElementById("sle_targa");
            policyNumber = Global.driver.FindElementById("sle_policynumber");
            DOB = Global.driver.FindElementById("em_birthdate");
            title = Global.driver.FindElementById("ddlb_title");
            phone = Global.driver.FindElementById("sle_phonenumber");
            searchButton = Global.driver.FindElementById("cb_search");
        }
        #region EndCustomer
        [Then(@"in End Customer tab enter value '(.*)' in the field '(.*)'")]
        public void ThenInEndCustomerTabEnterValueInTheField(string value, string fieldName)
        {
            try
            {
                switch (fieldName.ToLower())
                {

                    case "lastname":
                        new ControlHelper().EnterTheValueToTextField(lastName, value);
                        break;
                    case "firstname":
                        new ControlHelper().EnterTheValueToTextField(firstName, value);
                        break;
                    case "licenceplate":
                        new ControlHelper().EnterTheValueToTextField(licensePlate, value);
                        break;
                    case "chassisnumber":
                        new ControlHelper().EnterTheValueToTextField(chassis, value);
                        break;
                    case "policynumber":
                        new ControlHelper().EnterTheValueToTextField(policyNumber, value);
                        break;
                    case "title":
                        new ControlHelper().EditTypeComboboxSelectItem(title, value);
                        break;
                    case "dob":
                        new ControlHelper().EnterTheValueToTextField(DOB, value);
                        break;
                    case "phone":
                        new ControlHelper().EnterTheValueToTextField(phone, value);
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
        [Then(@"in End Customer tab click on '(.*)' value in search result table")]
        public void ThenInEndCustomerTabClickOnValueInSearchResultTable(string valueToClick)
        {
            try
            {
                resultTable = Global.driver.FindElementById("DataGridViewEndCustomer");
                new DataGridHandler().FindAndClickOnCellUsingValue(valueToClick, resultTable);
            }
            catch(Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Could not retreive serach result due to exception : " + e.Message);
            }
        }

        [Then(@"in End Customer tab click '(.*)' button")]
        public void ThenInEndCustomerTabClickButton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {

                    case "search":
                        new ControlHelper().ClickOnElement(searchButton);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on button  " + buttonName + " due to exception " + e.Message);
            }
        }

        [Then(@"in End Customer tab verify '(.*)' file is already available for end customer")]
        public void ThenInEndCustomerTabVerifyFileIsAlreadyAvailableForEndCustomer(string existingFileID)
        {
            try
            {
                IWebElement existingFile = Global.driver.FindElementById("tv_dossier");
                bool flag = false;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> dossierChildren = existingFile.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in dossierChildren)
                {
                    var fileID = e.GetAttribute("Name");
                    if (fileID.ToLower().Contains(existingFileID.ToLower()))
                    {
                        e.Click();
                        new ReportHelper().WriteLog("Pass", "File with ID " + existingFileID + " is avaialble for end customer ");
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    new ReportHelper().WriteLog("Fail", "File with ID " + existingFileID + " is not avaialble for end customer ");
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to  find file ID details due to exception : " + e.Message);
            }
        }

        #endregion 
    }
}
