using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Repositories;
using WiniumPOC.Utilities;

namespace WiniumPOC.UnityWindows
{
    [Binding]

    public class ActionSummary
    {
        IWebElement searchButton;
        IWebElement openButton;
        IWebElement detailButton;
        IWebElement summaryPage;
        IWebElement closeListButton;

        public ActionSummary()
        {
            searchButton = Global.driver.FindElementById("cb_ricerca");
            openButton = Global.driver.FindElementById("cb_esegui");
            detailButton = Global.driver.FindElementById("cb_dettaglio");
            closeListButton = Global.driver.FindElementById("cb_close");
        }

        [Then(@"in Action Summary window click '(.*)' button")]
        public void ThenInActionSummaryWindowClickButton(string buttonName)
        {
            try
            {
                switch (buttonName.ToLower())
                {

                    case "search":
                        new ControlHelper().ClickOnElement(searchButton);
                        break;
                    case "open":
                        new ControlHelper().ClickOnElement(openButton);
                        break;
                    case "detail":
                        new ControlHelper().ClickOnElement(detailButton);
                        break;
                    case "close list":
                        new ControlHelper().ClickOnElement(closeListButton);
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

        [Then(@"in Action Summary window select row with value '(.*)' in '(.*)' and value '(.*)' in '(.*)'")]
        public void ThenInActionSummaryWindowSelectRowWithValueInAndValueIn(string value1, string field1, string value2, string field2)
        {
            try
            {
                IWebElement listView = Global.driver.FindElementById("listView1");
                bool flag2 = false;
                bool flag1 = false;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listViewActionBlocks = listView.FindElements(By.XPath("./child::*"));
                foreach (IWebElement ele in listViewActionBlocks)
                {
                    var blockName = ele.GetAttribute("Name");
                    if (blockName.Equals(""))
                    {
                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> actionBlockRows = ele.FindElements(By.XPath("./child::*"));
                        int count = actionBlockRows.Count();

                        if (count != 0 && (flag1 != true || flag2 != true))
                        {
                            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> actionBlockRowChildren = actionBlockRows[0].FindElements(By.XPath("./child::*"));
                            foreach (IWebElement cell in actionBlockRowChildren)
                            {
                                var actualValue = cell.GetAttribute("Name");
                                if (!flag1)
                                {
                                    if (actualValue.ToLower().Trim().Equals(value1.ToLower().Trim()))
                                    {
                                        cell.Click();
                                        flag1 = true;
                                        new ReportHelper().WriteLog("Pass", "Found a row with cell value: " + value1);
                                    }
                                }
                                if (!flag2)
                                {
                                    if (actualValue.ToLower().Trim().Equals(value2.ToLower().Trim()))
                                    {
                                        cell.Click();
                                        flag2 = true;
                                        new ReportHelper().WriteLog("Pass", "Found row with cell value: " + value2);
                                    }
                                }
                            }
                        }
                    }
                }
                if (!flag1 && !flag2)
                {
                    new ReportHelper().WriteLog("Fail", "Could not find a row with cell values : " + value1 + " and  " + value2);
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to select a row in Action Summary window with value " + value1 + " and value " + value2 + " due to exception " + e.Message);
            }

        }

        [Then(@"in Action Summary window verify all the actions listed are of '(.*)' '(.*)'")]
        //[Then(@"in Action Summary window verify all the actions listed are of Operator '(.*)'")]
        //[Then(@"in Action Summary window verify all the actions listed are of Department '(.*)'")]
        public void ThenInActionSummaryWindowVerifyAllTheActionsListedAreOfDepartment(string fieldName,string expectedValue)
        {
            try
            {
                IWebElement listView = Global.driver.FindElementById("lv_Action");
                bool flag = true;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listViewActionBlocks = listView.FindElements(By.XPath("./child::*"));
                int count = 0;
                foreach (IWebElement e in listViewActionBlocks)
                    {
                        var name = e.GetAttribute("Name");
                        if ((name.Equals("")) && (count <10)&&(flag))
                        {
                            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> actionBlockRows = e.FindElements(By.XPath("./child::*"));

                            foreach (IWebElement ele in actionBlockRows)
                            {
                                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> actionBlockRowChildren = ele.FindElements(By.XPath("./child::*"));
                                var actualValue = actionBlockRowChildren[1].GetAttribute("Name");
                                if (!(actualValue.Equals(expectedValue)))
                                {
                                    flag = false;
                                    new ReportHelper().WriteLog("Fail", "All actions listed are not of " +fieldName+ " " + expectedValue + " by which the actions are filtered");
                                }
                                count++;
                                break;
                             }

                        }
                        else if ((count >=10) || (flag == false))
                            break;
                }
                if (flag)
                {
                    new ReportHelper().WriteLog("Pass", "All actions are of " + fieldName + " " + expectedValue);
                }     
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to verify Actions based on " + fieldName + " " + expectedValue);
            }
        }

        [Then(@"in Action Summary window verify all the actions listed as per current date in format '(.*)'")]
        public void ThenInActionSummaryWindowVerifyAllTheActionsListedAsPerCurrentDateInFormat(string dateFormat)
        {
            try
            {
                
                IWebElement listView = Global.driver.FindElementById("lv_Action");
                bool flag = true;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listViewActionBlocks = listView.FindElements(By.XPath("./child::*"));
                if (listViewActionBlocks.Count==0)
                {
                    new ReportHelper().WriteLog("Pass", "No actions created on current date");
                }
                else
                {
                    int count = 0;
                    //string currentdate = GenericMethods.GetCurrentDate();
                    //var dt = DateTime.ParseExact(currentDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string expectedCurrentDate = GenericMethods.GetCurrentDateInParticularFormat(dateFormat);

                    foreach (IWebElement e in listViewActionBlocks)
                    {
                        var name = e.GetAttribute("Name");
                        if ((name.Equals("")) && (count < 10) && (flag))
                        {
                            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> actionBlockRows = e.FindElements(By.XPath("./child::*"));

                            foreach (IWebElement ele in actionBlockRows)
                            {
                                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> actionBlockRowChildren = ele.FindElements(By.XPath("./child::*"));
                                var actualDateAndTime = actionBlockRowChildren[2].GetAttribute("Name");
                                var actualDate = GenericMethods.SplitDateFromDateAndTime(actualDateAndTime);
                                if (!(actualDate.Equals(expectedCurrentDate)))
                                {
                                    flag = false;
                                    new ReportHelper().WriteLog("Fail", "All actions listed are not as per current date");
                                }
                                count++;
                                break;
                            }

                        }
                        else if ((count >= 10) || (flag == false))
                            break;
                    }
                    if (flag)
                    {
                        new ReportHelper().WriteLog("Pass", "All actions displayed are of current date ");
                    }
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to verify Actions based on current date ");
            }
        }
    }
}


       