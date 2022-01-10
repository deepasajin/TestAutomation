using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows
{
   [Binding]
    public class SupplierList
    {
        IWebElement closeButton;
    public SupplierList()
        {
            closeButton = Global.driver.FindElementById("cb_close");
        }
        [Then(@"in SupplierList window click on '(.*)' button")]
        public void ThenInSupplierListWindowClickOnButton(string buttonName)
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
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {

            }
        }

        [Then(@"in SupplierList window validate the value of grid")]
        public void ThenInSupplierListWindowValidateTheValueOfGrid()
        {
            //new DataGridHandler().GetGridValue();
        }


    }
}
