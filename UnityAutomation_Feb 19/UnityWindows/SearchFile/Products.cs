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
    public class Products
    {

        public IWebElement searchField;
        public IWebElement searchFieldID;
        public IWebElement statusCombobox;
        public IWebElement productList;

        public Products()
        {
            //productList = Global.driver.FindElementById("clb_products");
            ////productList = Global.driver.FindElementByName("Date To");
            //searchField = Global.driver.FindElementByName("Search");
            searchFieldID = Global.driver.FindElementById("tb_ProductFilter");            
            //statusCombobox = Global.driver.FindElementByName("Product Status");
            //IWebElement statusComboboxID = Global.driver.FindElementById("cb_ProductStatus");

        }
        [Then(@"in Products tab enter value '(.*)' in product search field")]
    public void ThenInProductsTabEnterValueInProductSearchField(string value)
    {
            new ControlHelper().EnterTheValueToTextField(searchField, value);
    }
        [Then(@"in Products tab select value '(.*)' in product status")]
        public void ThenInProductsTabSelectValueInProductStatus(string value)
        {
            new ControlHelper().ComboboxSelectItem(statusCombobox, value);
        }
        [Then(@"in Products tab select the product '(.*)'")]
        public void ThenInProductsTabSelectTheProduct(string value)
        {
            try
            {
                Global.driver.FindElementByName(value).Click();
                new ReportHelper().WriteLog("Pass", "Successfully clicked on product " + value);
            }
            catch(Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on product " + value + " due to exception " + e.Message);
            }
        }




        ////Trials with Parents 
        ///
        [Then(@"in Products tab in parent enter value '(.*)' in product '(.*)' field")]
        public void ThenInProductsTabInParentEnterValueInProductField(string value, string field)
        {
            IWebElement tab = Global.driver.FindElementById("tabPageProducts");
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> menuChildren = tab.FindElements(By.XPath("./child::*"));
            foreach (IWebElement e in menuChildren)
            {
                var menuName = e.GetAttribute("Name");
                if (menuName.ToLower().Equals(field.ToLower()))
                {
                    e.Click();
                    new ControlHelper().EnterTheValueToTextField(e, value);
                    
                }

                }

            }


    }
}
