using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winium.Elements.Desktop.Extensions;
using WiniumPOC.Utilities;
using Keys = System.Windows.Forms.Keys;

namespace WiniumPOC.CommonFunctions
{
   public class ControlHelper
    {
        
        public void CheckIfWindowIsLoaded(string windowName)
        {
            try
            {
                if (Global.driver.FindElementByName(windowName).Displayed)
                {
                    new ReportHelper().WriteLog("Pass", "Window '" + windowName + "' is loaded successfully.");
                }
                else
                {
                    new ReportHelper().WriteLog("Fail", "Expected window is not loaded.");
                }
            }
            catch(Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Expected window is not loaded.. Exception: "+e.Message);
            }

        }
        public void WaitForWindowToLoad()
        {
            //Global.driver.Manage().Timeouts().ImplicitlyWait; 
                
        }

        #region TextField
        public void EnterTheValueToTextField(IWebElement element, string TextToEnter)
        {
            try
            {

                //element.SendKeys(Keys.Control + "a");
                element.SendKeys(TextToEnter);
                new ReportHelper().WriteLog("Pass", "Entered the value: " + TextToEnter);
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Failed to enter the value: " + TextToEnter +" Exception is " +e.Message);
            }
        }
        public string GetTheValueOfTextField(IWebElement element)
        {
                string str_objectname = string.Empty;
                str_objectname = ((element.Text) ?? string.Empty).ToString();
                return str_objectname;
        }
        public void TextFieldVerifyValue(string actualVale, string requiredValue)
        {
            if (actualVale.ToLower().Trim().Equals(requiredValue.ToLower().Trim()))
            {
                new ReportHelper().WriteLog("Pass", "Expected and actual values are same: " + actualVale);
            }
            else
            {
                new ReportHelper().WriteLog("Fail", "Expected and actual values are not same. Actual value is : " +  actualVale+ "  Expected value is : " +requiredValue);
            }
        }

        #endregion
        public void ClickOnElement(IWebElement element)
        {
            try
            {
                Actions action = new Actions(Global.driver);
                action.MoveToElement(element);
                action.Perform();
                element.Click();
                new ReportHelper().WriteLog("Pass", "Successfully clicked on the element ");
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Failed to click on the element. Exception messasge: " + e.Message);
            }

        }

        public void HoverOnElement(IWebElement element, string elementName)
        {
            try
            {
                Actions action = new Actions(Global.driver);
                action.MoveToElement(element).Perform();
                System.Threading.Thread.Sleep(2000);
                new ReportHelper().WriteLog("pass", "Successfully hovered on the element: " + elementName);
            }
            catch (Exception e)
            {
               new ReportHelper().WriteLog("Fail", "Failed to hover the element: " + elementName + ". Exception message is: " + e.Message);
            }
        }

        public void HandlePopupMessages(string buttonName, string message)
        {
            try
            {
                bool flag = false;
                IWebElement alertWinMessage = Global.driver.FindElementById("65535");
                IWebElement alertWin = Global.driver.FindElementByName("Unity");
                var alertMessage = alertWinMessage.GetAttribute("Name");
                if (alertMessage.ToLower().Contains(message.ToLower()))
                {
                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> alertWinChildren = alertWin.FindElements(By.XPath("./child::*"));
                    foreach (IWebElement e in alertWinChildren)
                    {
                        var childName = e.GetAttribute("Name");
                        if (childName.ToLower().Equals(buttonName.ToLower()))
                        {
                            e.Click();
                            flag = true;
                            new ReportHelper().WriteLog("Pass", "Successfully clicked on button  " + buttonName);
                            break;
                        }
                    }
                }
                if(!flag)
                {
                    new ReportHelper().WriteLog("Fail", "Could not find a pop up window with the message :" + message + " or button "+buttonName+ " not available in the pop-up");
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Failed to click on the element. Exception messasge: " + e.Message);
            }

        }

        //addedBySajna(Above function can be written as this, so that it can be applied for any popup window)
        public void HandlePopupMessagesUsingWindowName(string buttonName, string message, string windowName)
        {
            try
            {
                bool flag = false;
                IWebElement alertWinMessage = Global.driver.FindElementById("65535");
                IWebElement alertWin = Global.driver.FindElementByName(windowName);
                var alertMessage = alertWinMessage.GetAttribute("Name");
                if (alertMessage.ToLower().Contains(message.ToLower()))
                {
                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> alertWinChildren = alertWin.FindElements(By.XPath("./child::*"));
                    foreach (IWebElement e in alertWinChildren)
                    {
                        var childName = e.GetAttribute("Name");
                        if (childName.ToLower().Equals(buttonName.ToLower()))
                        {
                            e.Click();
                            flag = true;
                            new ReportHelper().WriteLog("Pass", "Successfully clicked on button  " + buttonName);
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    new ReportHelper().WriteLog("Fail", "Could not find a pop up window with the message :" + message + " or button " + buttonName + " not available in the pop-up");
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Failed to click on the element. Exception messasge: " + e.Message);
            }

        }

        #region combobox
        public void ComboboxSelectItem(IWebElement element, string valueToSelect)
        {

            var comb = element.ToComboBox();
            comb.Expand();            
            Thread.Sleep(1000);
            Global.driver.FindElementByName(valueToSelect).Click();
            new ReportHelper().WriteLog("Pass", "Successfully selected value "+valueToSelect+" from the combobox");
        }
        public void ComboboxSelectItemByIndex(IWebElement element, string valueToSelect)
        {

            try
            {
                bool flag = false;
                var comb = element.ToComboBox();
                comb.Expand();
                IWebElement listID = Global.driver.FindElementById("1000");
                //IWebElement scrollBarID = Global.driver.FindElementById("NonClientVerticalScrollBar");

                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listChildren = listID.FindElements(By.XPath("./child::*"));
                if (listChildren.Count > 0)
                {
                    foreach (IWebElement child in listChildren)
                    {
                        if (!flag)
                        {
                            var listName = child.GetAttribute("Name");
                            if (listName.Equals(valueToSelect))
                            {
                                Global.driver.FindElementByName(valueToSelect).Click();                              
                                new ReportHelper().WriteLog("Pass", "Successfully selected value " + valueToSelect + " from the combobox");
                                flag = true;
                            }
                        }
                    }
                }
                if(!flag)
                {
                    new ReportHelper().WriteLog("Pass", "Could not find value " + valueToSelect + " in the combobox");
                }
            }
            catch(Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to selecte value " + valueToSelect + " from the combobox due to exception : "+e.Message);
            }
          
        }

        public void EditTypeComboboxSelectItem(IWebElement element, string valueToSelect)
        {
            try
            {
                bool flag = false;
                if (flag != true)
                {
                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> comboboxChildren = element.FindElements(By.XPath("./child::*"));
                    foreach (IWebElement e in comboboxChildren)
                    {
                        var childName = e.GetAttribute("Name");
                        if (childName.ToLower().Equals("open"))
                        {
                            e.Click();
                            var s = new Stopwatch();
                            s.Start();
                            Global.driver.FindElementByName(valueToSelect).Click();
                            new ReportHelper().WriteLog("Pass", "Successfully selected value " + valueToSelect + " from the combobox");
                            flag = true;
                            break;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to select value " + valueToSelect + " due to exception : " + e.Message);
            }
        }

        public string GetComboBoxSelectedItem(IWebElement element)
        {
            string str_objectname = string.Empty;
            str_objectname = ((element.Text) ?? string.Empty).ToString();
            return str_objectname;
        }
        public void VerifyComboBoxSelectedItemValue(string actualVale, string requiredValue)
        {
            if (actualVale.ToLower().Trim().Equals(requiredValue.ToLower().Trim()))
            {
                new ReportHelper().WriteLog("Pass", "Expected and actual values are same: " + actualVale);
            }
            else
            {
                new ReportHelper().WriteLog("Fail", "Expected and actual values are not same. Actual value is : " + actualVale + "  Expected value is : " + requiredValue);
            }
        }
        #endregion

        public void SelectValueFromTree(IWebElement element, string valueToSelect)
        {
            bool flag = false;
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> treeChildren = element.FindElements(By.XPath("./child::*"));
            if (flag != true)
            {
                foreach (IWebElement child in treeChildren)
                {
                    if (flag != true)
                    {
                        var valueName = child.GetAttribute("Name");
                        if (valueName != null)
                        {
                            if (valueName.Equals(valueToSelect))
                            {
                                ClickOnElement(child);
                                flag = true;
                                break;
                            }
                        }
                    }
                }
            }
        }
        public void SelectSubValueFromTree(IWebElement element, string mainValue, string subValue)
        {
            bool flag = false;
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> treeChildren = element.FindElements(By.XPath("./child::*"));
            if (flag != true)
            {
                foreach (IWebElement child in treeChildren)
                {
                    if (flag != true)
                    {
                        var valueName = child.GetAttribute("Name");
                        if (valueName != null)
                        {
                            if (valueName.Equals(mainValue))
                            {
                                Actions action = new Actions(Global.driver);
                                action.DoubleClick(child).Perform();
                                if(Global.driver.FindElementByName(subValue).Displayed)
                                {
                                    Global.driver.FindElementByName(subValue).Click();
                                    new ReportHelper().WriteLog("Pass", "Successfully clicked on the value " +subValue);
                                }
                                else
                                {
                                    new ReportHelper().WriteLog("Fail", "Could not find a value " + subValue);
                                }
                                flag = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void VerifyCheckboxStatusAndSelect(IWebElement element, string status)
        {
            bool checkboxStatus = element.Selected;
            if(status.ToLower().Equals("check"))
            {
                if(checkboxStatus)
                {
                    new ReportHelper().WriteLog("Pass", "Checkbox is already selected");
                }
                else
                {
                    element.Click();
                    new ReportHelper().WriteLog("Pass", "Checkbox is selected successfully");
                }
            }
            if (status.ToLower().Equals("uncheck"))
            {
                if (checkboxStatus)
                {
                    element.Click();
                    new ReportHelper().WriteLog("Pass", "Checkbox is unchecked successfully");
                }
                else
                {
                    new ReportHelper().WriteLog("Pass", "Checkbox is alreday unselected");
                }
            }
        }

        public void VerifyIfFieldIsEnabled(IWebElement element, string status)
        {
            bool enabledStatus = element.Enabled;           
            if (enabledStatus && status.ToLower().Equals("enabled"))
            {
                new ReportHelper().WriteLog("Pass", "The field is Enabled as expected.");
            }
            else if(enabledStatus && status.ToLower().Equals("disabled"))
            {
                new ReportHelper().WriteLog("Fail", "The field needs to be disbaled.");
            }
            else if(!enabledStatus && status.ToLower().Equals("enabled"))
            {
                new ReportHelper().WriteLog("Fail", "The field needs to be enabled.");
            }
            else if (!enabledStatus && status.ToLower().Equals("disbaled"))
            {
                new ReportHelper().WriteLog("Pass", "The field is Disabled as expected.");
            }
        }
           
   }
}
