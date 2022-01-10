using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace WiniumPOC.Utilities
{
    [Binding]
    public class DataGridHandler
    {

        public DataGridHandler()
        {
          
        
        }

        public void FindAndClickOnCellUsingColumnnameAndValue(string value, string columnName, IWebElement gridElemenet)
        {
            try
            {
                bool flag = false;              
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> resultChildren = gridElemenet.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in resultChildren)
                {
                    var rowName = e.GetAttribute("Name");
                    if (rowName != null && rowName.Contains("Row "))
                    {
                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> rowChildren = e.FindElements(By.XPath("./child::*"));
                        int count = rowChildren.Count();
                        if (count != 0)
                        {
                            foreach (IWebElement cell in rowChildren)
                            {
                                if (!flag)
                                {
                                    var cellName = cell.GetAttribute("Name");
                                    if (cellName.ToLower().Contains(columnName.ToLower()))
                                    {
                                        var cellValue = cell.Text;
                                        if (cellValue.ToLower().Trim().Equals(value.ToLower().Trim()))
                                        {
                                            cell.Click();
                                            flag = true;
                                            new ReportHelper().WriteLog("Pass", "Successfully clicked on cell with value  " + value + " in the columnn " + columnName + " in serach result");
                                            break;
                                        }

                                    }
                                }
                            }
                        }

                    }
                }
                if (!flag)
                {
                    new ReportHelper().WriteLog("Fail", "Unable to find the row with value " + value + " in the columnn " + columnName + " in serach result");
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on cell due to exception  " +e.Message);
            }
        }

        //This is used for End Customer search file as there is no header in Search result
        public void FindAndClickOnCellUsingValue(string value, IWebElement gridElemenet)
        {
            try
            {
                bool flag = false;
                if (flag != true)
                {
                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> resultChildren = gridElemenet.FindElements(By.XPath("./child::*"));
                    foreach (IWebElement e in resultChildren)
                    {
                        var rowName = e.GetAttribute("Name");
                        if (rowName != null && rowName.Contains("Row "))
                        {
                            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> rowChildren = e.FindElements(By.XPath("./child::*"));
                            int count = rowChildren.Count();
                            if (count != 0 && flag!=true)
                            {
                                foreach (IWebElement cell in rowChildren)
                                {
                                    var cellValue = cell.Text;
                                    if (cellValue.ToLower().Trim().Equals(value.ToLower().Trim()))
                                    {
                                        cell.Click();
                                        flag = true;
                                        new ReportHelper().WriteLog("Pass", "Successfully clicked on cell with value  " + value + " in serach result");
                                        break;
                                    }

                                }
                            }
                        }

                    }
                }
                if (!flag)
                {
                    new ReportHelper().WriteLog("Fail", "Unable to find the row with value " + value + " in serach result");
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on cell due to exception  " + e.Message);
            }
        }
        public void FindAndClickOnRowWithTwoValue(string value1, string value2, IWebElement gridElemenet)
        {
            try
            {
                bool flag2 = false;
                bool flag1 = false;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> resultChildren = gridElemenet.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in resultChildren)
                {
                    var rowName = e.GetAttribute("Name");
                    if (rowName != null && rowName.Contains("Row "))
                    {
                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> rowChildren = e.FindElements(By.XPath("./child::*"));
                        int count = rowChildren.Count();
                        if (count != 0 && (flag1 != true || flag2 != true))
                        {
                            foreach (IWebElement cell in rowChildren)
                            {
                                var cellValue = cell.Text;
                                if (!flag1)
                                {
                                    if (cellValue.ToLower().Trim().Equals(value1.ToLower().Trim()))
                                    {
                                        cell.Click();
                                        flag1 = true;
                                        new ReportHelper().WriteLog("Pass", "Found a row ith cell value: " + value1);
                                    }
                                }
                                if (!flag2)
                                {
                                    if (cellValue.ToLower().Trim().Equals(value2.ToLower().Trim()))
                                    {
                                        cell.Click();
                                        flag2 = true;
                                        new ReportHelper().WriteLog("Pass", "Found a row ith cell value: " + value2);
                                    }
                                }


                            }
                        }
                    }

                }
                if (!flag1 && !flag2)
                {
                    new ReportHelper().WriteLog("Fail", "Could not find a row ith cell values : " + value1 + " and  " + value2);
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on cell due to exception  " + e.Message);
            }
        }

        public void VerifyDataGridNotNull(IWebElement gridElemenet)
        {
            
            try
            {
                bool flag = false;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> resultChildren = gridElemenet.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in resultChildren)
                {
                    if (!flag)
                    {
                        var rowName = e.GetAttribute("Name");
                        if (rowName != null && rowName.Contains("Row "))
                        {
                            new ReportHelper().WriteLog("Pass", "Verified search result is not null.");
                            flag = true;
                            break;
                        }
                    }
                }
                if(!flag)
                {
                    new ReportHelper().WriteLog("Fail", "Search Result is empty. Please select new search criteria.");
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Could not verify search result due to exception  " + e.Message);
            }
        }

        public void VerifyAllValuesUsingColumnnameAndValue(string value, string columnName, IWebElement gridElemenet)
        {
            try
            {
                bool flag = true;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> resultChildren = gridElemenet.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in resultChildren)
                {
                    if (flag)
                    {
                        var rowName = e.GetAttribute("Name");
                        if (rowName != null && rowName.Contains("Row "))
                        {
                            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> rowChildren = e.FindElements(By.XPath("./child::*"));
                            int count = rowChildren.Count();
                            if (count != 0)
                            {
                                foreach (IWebElement cell in rowChildren)
                                {
                                    if (flag)
                                    {
                                        var cellName = cell.GetAttribute("Name");
                                        if (cellName.ToLower().Contains(columnName.ToLower()))
                                        {
                                            var cellValue = cell.Text;
                                            if (!(cellValue.ToLower().Trim().Equals(value.ToLower().Trim())))
                                            {
                                                flag = false;
                                                new ReportHelper().WriteLog("Fail", "Column has a value which is not expected.Expected Value is : " + value + " Actual value is : " + cellValue);
                                                break;
                                            }

                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                if (flag)
                {
                    new ReportHelper().WriteLog("Pass", "Successfully validated all the values in the search result to be: " + value);
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to validate the values in search result due to exception  " + e.Message);
            }
        }

        //added by Sajna
        public void VerifyAllValuesUsingColumnAndValue(string value, string columnName, IWebElement gridElemenet)
        {
            try
            {
                bool flag = true;
                int counter = 0;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> resultChildren = gridElemenet.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in resultChildren)
                {
                    var rowName = e.GetAttribute("Name");
                    if (rowName != null && rowName.Contains("Row ") && flag && counter < 10)
                    {
                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> rowChildren = e.FindElements(By.XPath("./child::*"));
                        int count = rowChildren.Count();
                        if (count != 0)
                        {
                            foreach (IWebElement cell in rowChildren)
                            {
                                var cellName = cell.GetAttribute("Name");
                                if (cellName.ToLower().Contains(columnName.ToLower()))
                                {
                                    var cellValue = cell.Text;
                                    if (!((cellValue.ToLower().Trim()).Contains(value.ToLower().Trim())))
                                    {
                                        flag = false;
                                        new ReportHelper().WriteLog("Fail", "All values in the column " + columnName + " doesn't contain " + value);
                                    }
                                    counter++;
                                    break;
                                }
                            }
                        }
                    }
                    else if ((counter >= 10) || (flag == false))
                        break;
                }
                if (flag)
                {
                    new ReportHelper().WriteLog("Pass", "All values within the column " + columnName + " in serach result contains " + value + " for the first 10 rows");
                }

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to find value " + value + " in the column " + columnName + " due to exception  " + e.Message);
            }
        }
    }
}
