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

    public class NewAction
    {
        IWebElement standardActionCombobox;
        IWebElement priorityCombobox;
        IWebElement remarkEdit;
        IWebElement deadlineEdit;
        IWebElement finishButton;
        IWebElement nextButton;
        IWebElement actionSection;
        IWebElement actionSection1;
        IWebElement actionSection2;

        public NewAction()
        {
            standardActionCombobox = Global.driver.FindElementById("ddlb_stdact_1");
            actionSection1 = Global.driver.FindElementById("uo_new_action1");
            actionSection2 = Global.driver.FindElementById("uo_new_action2");
            
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> action2Children = actionSection2.FindElements(By.XPath("./child::*"));
            priorityCombobox = Global.driver.FindElementById("cbActionPriority");
            remarkEdit = Global.driver.FindElementById("rtbNotes");
            deadlineEdit = Global.driver.FindElementById("deadline_dt");
            finishButton= Global.driver.FindElementById("cb_finish");
            nextButton = Global.driver.FindElementById("cb_next");
            
        }

        [Then(@"in New Action window select the drop down value '(.*)' in the field '(.*)'")]
        public void ThenInNewActionWindowSelectTheDropDownValueInTheField(string value, string fieldName)
        {
            try
            { 
                switch (fieldName.ToLower())
                {

                    case "standard action":
                        new ControlHelper().EditTypeComboboxSelectItem(standardActionCombobox, value);
                        break;
                    case "priority":
                        new ControlHelper().EditTypeComboboxSelectItem(priorityCombobox, value);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to select value " + value + " due to exception " + e.Message);
            }
        }
        [Then(@"in New Action window enter the value '(.*)' in the field '(.*)'")]
        public void ThenInNewActionWindowEnterTheValueInTheField(string value, string fieldName)
        {
            try
            {
                switch (fieldName.ToLower())
                {

                    case "remark":                        
                        new ControlHelper().EnterTheValueToTextField(remarkEdit, value);
                        break;
                    case "deadline":
                        new ControlHelper().EnterTheValueToTextField(deadlineEdit, value);
                        break;                    
                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to enter value on field " + fieldName + " due to exception " + e.Message);
            }
        }
        [Then(@"in New Action window click '(.*)' button")]
        public void ThenInNewActionWindowClickButton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {

                    case "finish":
                        new ControlHelper().ClickOnElement(finishButton);
                        break;
                    case "next":
                        new ControlHelper().ClickOnElement(nextButton);
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
        [Then(@"in New Action window select the value '(.*)' from Receiver panel")]
        public void ThenInNewActionWindowSelectTheValueFromReceiverPanel(string value)
        {
            Global.driver.FindElementByName(value).Click();
            new ReportHelper().WriteLog("Pass", "Successfully clicked on the Receiver " +value);
        }
        [Then(@"in New Action window insert value '(.*)' in the field '(.*)' in the action '(.*)'")]
        public void ThenInNewActionWindowInsertValueInTheFieldInTheAction(string value, string fieldName, string section)
        {
            try
            {
                bool flag = false;
                if (flag != true)
                {
                    if (section.ToLower().Equals("section1"))
                    {
                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> action1Children = actionSection1.FindElements(By.XPath("./child::*"));
                        foreach (IWebElement ele in action1Children)
                        {
                            if (flag != true)
                            {
                            
                            var actionChildID = ele.GetAttribute("AutomationId");
                                if (actionChildID != null)
                                {
                                    switch (fieldName.ToLower())
                                    {
                                        case "standard action":
                                            if (actionChildID.Equals("ddlb_stdact_1"))
                                            {
                                                new ControlHelper().EditTypeComboboxSelectItem(ele, value);
                                                flag = true;
                                            }
                                            break;
                                        case "priority":
                                            if (actionChildID.Equals("cbActionPriority"))
                                            {
                                                new ControlHelper().EditTypeComboboxSelectItem(ele, value);
                                                flag = true;
                                            }
                                            break;
                                        case "remark":
                                            if (actionChildID.Equals("rtbNotes"))
                                            {
                                                new ControlHelper().EnterTheValueToTextField(ele, value);
                                                flag = true;
                                            }
                                            break;
                                        case "deadline":
                                            if (actionChildID.Equals("deadline_dt"))
                                            {
                                                new ControlHelper().EditTypeComboboxSelectItem(ele, value);
                                                flag = true;
                                            }
                                            break;
                                        case "receiver":
                                            if (actionChildID.Equals("uo_tv_utente1"))
                                            {
                                                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> receiverChildren = ele.FindElements(By.XPath("./child::*"));
                                                if (flag != true)
                                                {
                                                    foreach (IWebElement child in receiverChildren)
                                                    {
                                                        if (flag != true)
                                                        {
                                                            var receiverName = child.GetAttribute("Name");
                                                            if (receiverName != null)
                                                            {
                                                                if (receiverName.Equals(value))
                                                                {
                                                                    new ControlHelper().ClickOnElement(child);
                                                                    flag = true;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }

                            }
                        }
                    }
                    else if (section.ToLower().Equals("section2"))
                    {
                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> action2Children = actionSection2.FindElements(By.XPath("./child::*"));
                        foreach (IWebElement ele in action2Children)
                        {
                            if (flag != true)
                            {
                                var actionChildID = ele.GetAttribute("AutomationId");
                                if (actionChildID != null)
                                {
                                    switch (fieldName.ToLower())
                                    {
                                        case "standard action":
                                            if (actionChildID.Equals("ddlb_stdact_1"))
                                            {
                                                new ControlHelper().EditTypeComboboxSelectItem(ele, value);
                                                flag = true;
                                            }
                                            break;
                                        case "priority":
                                            if (actionChildID.Equals("cbActionPriority"))
                                            {
                                                new ControlHelper().EditTypeComboboxSelectItem(ele, value);
                                                flag = true;
                                            }
                                            break;
                                        case "remark":
                                            if (actionChildID.Equals("rtbNotes"))
                                            {
                                                new ControlHelper().EnterTheValueToTextField(ele, value);
                                                flag = true;
                                            }
                                            break;
                                        case "deadline":
                                            if (actionChildID.Equals("deadline_dt"))
                                            {
                                                new ControlHelper().EditTypeComboboxSelectItem(ele, value);
                                                flag = true;
                                            }
                                            break;
                                        case "receiver":
                                            if (actionChildID.Equals("uo_tv_utente1"))
                                            {
                                                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> receiverChildren = ele.FindElements(By.XPath("./child::*"));
                                                if (flag != true)
                                                {
                                                    foreach (IWebElement child in receiverChildren)
                                                    {
                                                        if (flag != true)
                                                        {
                                                            var receiverName = child.GetAttribute("Name");
                                                            if (receiverName != null)
                                                            {
                                                                if (receiverName.Equals(value))
                                                                {
                                                                    new ControlHelper().ClickOnElement(child);
                                                                    flag = true;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        new ReportHelper().WriteLog("Fail", "Please verify the section on which Action to be craeted");
                    }

                }
            }
            catch(Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Could not create action due to exception : "+e.Message);
            }
        }
    }
}
