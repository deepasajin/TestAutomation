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
    public class Recourse
    {

        public IWebElement noRadioButton;
        public IWebElement yesRadioButton;
        public IWebElement fileType;

        public Recourse()
        {
            //noRadioButton = Global.driver.FindElementById("optManageNo");
            //yesRadioButton = Global.driver.FindElementById("optManageYes");
            fileType = Global.driver.FindElementById("ddlb_tipodox");
        }

        [Then(@"in Recourse tab select '(.*)' in Manage radio button")]
        public void ThenInRecourseTabSelectInManageRadioButton(string radioButton)
        {
            try
            {
                switch (radioButton.ToLower())
                {
                    case "no":
                        new ControlHelper().ClickOnElement(noRadioButton);
                        break;
                    case "yes":
                        new ControlHelper().ClickOnElement(yesRadioButton);
                        break;
                    default:
                        break;

                }
            }
            catch(Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on radio button " + radioButton + " due to exception " + e.Message);
            }
        }
        [Then(@"in Recourse tab select file type '(.*)'")]
        public void ThenInRecourseTabSelectFileType(string valueToSelect)
        {
            new ControlHelper().EditTypeComboboxSelectItem(fileType, valueToSelect);
        }
        [Then(@"in Recourse search result click on '(.*)' value in '(.*)' column")]
        public void ThenInRecourseSearchResultClickOnValueInColumn(string value, string columnName)
        {
            IWebElement resultGrid = Global.driver.FindElementById("dataGridViewSearchResult");
            new DataGridHandler().FindAndClickOnCellUsingColumnnameAndValue(value, columnName, resultGrid);
        }
    }
}
