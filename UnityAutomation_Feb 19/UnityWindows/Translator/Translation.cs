using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows.Translator
{
    [Binding]
    public class Translation
    {

        IWebElement currentLanguage;
        IWebElement defaultLanguage;
        IWebElement language;
        IWebElement okButton;
        IWebElement cancelButton;

        public Translation()
        {
            currentLanguage = Global.driver.FindElementById("tb_currentLanguage");
            defaultLanguage = Global.driver.FindElementById("tb_defaultLanguages");
            language= Global.driver.FindElementById("ddl_language");
            okButton = Global.driver.FindElementById("cb_ok");
            cancelButton = Global.driver.FindElementById("cb_close");
        }
        [Then(@"in Translation window verify '(.*)' language is '(.*)'")]
        public void ThenInTranslationWindowVerifyLanguageIs(string fieldName, string value)
        {
            try
            {
                var getValue = "";
                switch(fieldName.ToLower())
                {
                    case "current":
                        getValue = new ControlHelper().GetTheValueOfTextField(currentLanguage);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);

                        break;
                    case "default":
                        getValue = new ControlHelper().GetTheValueOfTextField(currentLanguage);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);
                        break;
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to verify value due to exception " + e.Message);
            }
        }
        [Then(@"in Translation window select the new language as '(.*)'")]
        public void ThenInTranslationWindowSelectTheNewLanguageAs(string value)
        {
            new ControlHelper().ComboboxSelectItem(language, value);
        }
        [Then(@"in Translation window click '(.*)' button")]
        public void ThenInTranslationWindowClickButton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {

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



    }
}
