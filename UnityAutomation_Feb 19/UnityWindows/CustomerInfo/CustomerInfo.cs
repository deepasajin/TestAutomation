using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows.CustomerInfo
{
    [Binding]
    public class CustomerInfo
    {
        IWebElement stars;
        IWebElement triangle;
        IWebElement coverageDetails;
        IWebElement other;
        public CustomerInfo()
        {
            stars = Global.driver.FindElementById("pb_0");
            coverageDetails = Global.driver.FindElementById("RegistrationBookCover");
            other = Global.driver.FindElementById("SupplierProblemOther");

            


        }

        [Then(@"in Customer Info window select '(.*)' stars in the information")]
        public void ThenInCustomerInfoWindowSelectStarsInTheInformation(int count)
        {
            stars.Click();
        }
        [Then(@"in Customer Info window provide the value '(.*)' in the field '(.*)'")]
        public void ThenInCustomerInfoWindowProvideTheValueInTheField(string value, string inputField)
        {
            try
            {
                switch (inputField.ToLower())
                {

                    case "coveragedetails":
                        new ControlHelper().EnterTheValueToTextField(coverageDetails, value);
                        break;
                    case "other":
                        new ControlHelper().EnterTheValueToTextField(other, value);
                        break;

                    default:
                        break;


                }
            }
            catch (Exception e)
            {

            }
        }


    }
}
