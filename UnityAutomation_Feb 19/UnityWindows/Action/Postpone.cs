using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows.Action
{
    [Binding]
    public class Postpone
    {
        IWebElement fileID;
        IWebElement day;
        IWebElement time;
        IWebElement spinner;
        IWebElement postponeReason;
        IWebElement priority;
        IWebElement receiver;
        IWebElement postponeButton;

        public Postpone()
        {
            fileID = Global.driver.FindElementById("st_dossier_id");
            day = Global.driver.FindElementById("em_scadenza");
            time = Global.driver.FindElementById("em_orascadenza");
            postponeReason = Global.driver.FindElementById("mle_motivo");
            priority = Global.driver.FindElementById("cb_priority");
            receiver = Global.driver.FindElementById("uo_tv_utente1");
            postponeButton = Global.driver.FindElementById("cb_esegui");
        }
        [Then(@"in Action postpone window verify if field '(.*)' is having value '(.*)'")]
        public void ThenInActionPostponeWindowVerifyIfFieldIsHavingValue(string fieldName, string value)
        {
            try
            {
                string getValue = "";
                switch (fieldName.ToLower())
                {
                    case "file":
                        getValue = new ControlHelper().GetTheValueOfTextField(fileID);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);
                        break;
                    case "day":
                        getValue = new ControlHelper().GetTheValueOfTextField(day);
                        new ControlHelper().TextFieldVerifyValue(getValue, value);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to  fetch value in   " + fieldName + "due to exception : " + e.Message);
            }
        }

        [Then(@"in Action postpone window '(.*)' the '(.*)' by '(.*)'")]
        public void ThenInActionPostponeWindowTheBy(string action, string fieldName, int count)
        {
            try
            {
                bool flag = false;
                if(fieldName.ToLower().Equals("day"))
                {
                    spinner = day.FindElement(By.XPath("./child::*"));
                }
                else if(fieldName.ToLower().Equals("time"))
                {
                    spinner = time.FindElement(By.XPath("./child::*"));
                }
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> buttonChild = spinner.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in buttonChild)
                {
                    if (!flag)
                    {
                        var buttonName = e.GetAttribute("Name");
                        if (action.ToLower().Equals("postpone"))                            
                        {
                            if (buttonName.ToLower().Equals("forward"))
                            {
                                for (int i= 0;i<=count;i++ )
                                {
                                    e.Click();                                    
                                }
                                new ReportHelper().WriteLog("Pass", "Sucessfully Postponded the "+fieldName);
                                flag = true;
                                break;
                            }
                        }
                        else if(action.ToLower().Equals("prepone"))
                        {
                            if (buttonName.ToLower().Equals("backward"))
                            {
                                for (int i = 0; i <= count; i++)
                                {
                                    e.Click();
                                }
                                new ReportHelper().WriteLog("Pass", "Sucessfully Preponed the " + fieldName);
                                flag = true;
                                break;
                            }
                        }                       
                    }
                }
                if (!flag)
                {
                    new ReportHelper().WriteLog("Fail", "Please check the values provided. Could not perform any action");
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to "+action+ "the "+fieldName+"  due to exception : " + e.Message);
            }
        }

        [Then(@"in Action postpone window insert '(.*)' in '(.*)'")]
        public void ThenInActionPostponeWindowInsertIn(string value, string fieldName)
        {
            try
            {
                switch (fieldName.ToLower())
                {

                    case "receiver":
                        new ControlHelper().SelectValueFromTree(receiver, value);  
                        break;
                    case "priority":
                        new ControlHelper().EditTypeComboboxSelectItem(priority, value);
                        break;
                    case "reason":
                        new ControlHelper().EnterTheValueToTextField(postponeReason, value);
                        break;
                        
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to insert value " + value + " due to exception " + e.Message);
            }
        }

        [Then(@"in Action postpone window click '(.*)' button")]
        public void ThenInActionPostponeWindowClickButton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {

                    case "postpone":
                        new ControlHelper().ClickOnElement(postponeButton);
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
