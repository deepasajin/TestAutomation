using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows.SearchFile
{
    [Binding]

    public class Country
    {
        public IWebElement countryDropdown;
        
        public Country()
        {

            countryDropdown = Global.driver.FindElementById("cb_ricerca");
           
        }
    }
}
