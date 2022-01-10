using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows
{
    [Binding]
    public class SearchSupplier
    {
        IWebElement rbCountry;
        IWebElement rbCompTitle;
        IWebElement txtCompTitle;
        IWebElement buttonOK;

        public SearchSupplier()
        {
          
            rbCountry = Global.driver.FindElementById("rb_nazione");
            rbCompTitle = Global.driver.FindElementById("rb_ragione_sociale");           
            buttonOK = Global.driver.FindElementById("cb_ok");

        }  
        [Then(@"in SearchSupplier window select the search filter radio button '(.*)'")]
        public void ThenInSearchSupplierWindowSelectTheSearchFilterRadioButton(string radioButtonName)
        {
            try
            {
                switch (radioButtonName.ToLower())
                {
                    case "country":
                        new ControlHelper().ClickOnElement(rbCountry);
                        break;
                    case "companytitle":
                        new ControlHelper().ClickOnElement(rbCompTitle);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to  click on radio button  " + radioButtonName + "due to exception : " + e.Message);
            }
        }
        [Then(@"in SearchSupplier window input the value '(.*)' in the edit field for '(.*)'")]
        public void ThenInSearchSupplierWindowImputTheValueInTheEditFieldFor(string inputValue, string searchType)
        {
         
            try
            {
                switch (searchType.ToLower())
                {
                    
                    case "companytitle":
                        txtCompTitle = Global.driver.FindElementById("sle_ragione_sociale");
                        new ControlHelper().EnterTheValueToTextField(txtCompTitle, inputValue);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to input value in the field  " + searchType + "due to exception : " + e.Message);
            }
        }

        [Then(@"in SearchSupplier window click on '(.*)' button")]
        public void ThenInSearchSupplierWindowClickOnButton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {
                    case "ok":
                        new ControlHelper().ClickOnElement(buttonOK);
                        break;
                    
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on button  " + buttonName + "due to exception : " + e.Message);
            }
        }

    }
}
