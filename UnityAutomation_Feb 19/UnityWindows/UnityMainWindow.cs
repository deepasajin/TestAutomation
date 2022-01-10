using Google.Protobuf.WellKnownTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using Winium.Elements.Desktop.Extensions;
using WiniumPOC.CommonFunctions;
using WiniumPOC.Repositories;
using WiniumPOC.Utilities;
using Keys = OpenQA.Selenium.Keys;

namespace WiniumPOC.UnityWindows
{
    [Binding]
    public class UnityMainWindow
    {
        IWebElement menuBar;
        IWebElement toolBar;
        IWebElement mainWindow;
        IWebElement closeWin;
        IWebElement minimizeWin;
        IWebElement maxWin;
        IWebElement buttonElement;

        public UnityMainWindow()
        {

            menuBar = Global.driver.FindElementById("menuMain");
            toolBar = Global.driver.FindElementById("toolMain");
            mainWindow = Global.driver.FindElementByXPath("/*[@AutomationId='w_main']");
            closeWin = Global.driver.FindElementById("Close");

        }
        [Then(@"in Unity main window click on '(.*)' submenu from '(.*)' main menu")]
        [Then(@"in Unity main window with file opened click on '(.*)' submenu from '(.*)' main menu")]        
        public void ThenInUnityMainWidnowClickOnSubmenuFromMainMenu(string subMenuName, string mainMenuName)
        {
            try
            {
                bool flag = false;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> menuChildren = menuBar.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in menuChildren)
                {
                    var menuName = e.GetAttribute("Name");                    
                    if (menuName.ToLower().Equals(mainMenuName.ToLower()))
                    {
                        e.Click();
                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> submenuChildren = e.FindElements(By.XPath("./child::*"));
                        foreach (IWebElement ele in submenuChildren)
                        {
                            var submenuName = ele.GetAttribute("Name");
                            if (submenuName != null)
                            {
                                if (submenuName.ToLower().Equals(subMenuName.ToLower()))
                                {
                                    ele.Click();
                                    flag = true;
                                    new ReportHelper().WriteLog("Pass", "Successfully clicked on the submenu  " + subMenuName + " in the main menu " + mainMenuName);
                                    break;
                                }
                            }
                        }

                    }
                }
                if(!flag)
                {
                    new ReportHelper().WriteLog("Fail", "Unable to find the submenu  " + subMenuName + " in the main menu " + mainMenuName);
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to  click on the submenu  " + subMenuName + " in the main menu " + mainMenuName+ "due to exception : "+e.Message);
            }

        }

        [Then(@"in Unity main window click on '(.*)' icon in the toolbar")]
        [Then(@"in File Management window click on '(.*)' icon in the toolbar")]
        public void ThenInUnityMainWindowClickOnIconInTheToolbar(string iconName)
        {
            try
            {

                bool flag = false;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> iconChildren = toolBar.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in iconChildren)
                {
                    var iconbuttonName = e.GetAttribute("Name");
                    if(iconbuttonName!=null)
                    {
                        if (iconbuttonName.ToLower().Equals(iconName.ToLower()))
                        {                          
                            e.Click();
                            flag = true;
                            new ReportHelper().WriteLog("Pass", "Successfully clicked on the Icon :" + iconName);
                            break;
                        }
                    }
                    
                }
                if (!flag)
                {
                    new ReportHelper().WriteLog("Fail", "Unable to find the icon  " + iconName);
                }
            }

            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on the Icon  " + iconName+ " due to exception : " + e.Message);
                //new ReportHelper().WriteLog("Fail", "Unable to click on the Icon  " + iconName + " due to exception : " + e.StackTrace);
            }

        }

        [Then(@"in Unity main window click on '(.*)' flyout from '(.*)' submenu in the main menu '(.*)'")]
        public void ThenInUnityMainWindowClickOnFlyoutFromSubmenuInTheMainMenu(string flyoutName, string subMenuName, string mainMenuName)
        {
            try
            {
                bool flag = false;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> menuChildren = menuBar.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in menuChildren)
                {
                    var menuName = e.GetAttribute("Name");
                    if (menuName.ToLower().Equals(mainMenuName.ToLower()))
                    {
                        e.Click();
                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> submenuChildren = e.FindElements(By.XPath("./child::*"));
                        foreach (IWebElement ele in submenuChildren)
                        {
                            var submenuName = ele.GetAttribute("Name");
                            if (submenuName != null)
                            {
                                if (submenuName.ToLower().Equals(subMenuName.ToLower()))
                                {
                                    ele.Click();
                                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> flyoutChildren = ele.FindElements(By.XPath("./child::*"));
                                    foreach (IWebElement element in flyoutChildren)
                                    {
                                        var flyoutOption = element.GetAttribute("Name");
                                        if (flyoutOption.ToLower().Equals(flyoutName.ToLower()))
                                        {
                                            element.Click();
                                            flag = true;
                                            new ReportHelper().WriteLog("Pass", "Successfully clicked on the flyout  " + flyoutName + " in the main menu " + mainMenuName);
                                            break;
                                        }

                                    }
                                }
                            }
                        }

                    }
                }
                if(!flag)
                {
                    new ReportHelper().WriteLog("Fail", "Unable to find the flyout  " + flyoutName + " in the main menu " + mainMenuName );
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to  click on the flyout  " + flyoutName + " in the main menu " + mainMenuName + " due to exception : " + e.Message);
            }          

        }

        [Then(@"in Unity main window close the application")]
        public void ThenInUnityMainWindowCloseTheApplication()
        {
            new ControlHelper().ClickOnElement(closeWin);
        }
        [Then(@"in the pop-up window click '(.*)' for the message '(.*)'")]
        public void ThenInThePop_UpWindowClickForTheMessage(string buttonName, string message)
        {
                new ControlHelper().HandlePopupMessages(buttonName, message); 
        }

        //Added by Sajna
        [Then(@"in the '(.*)' pop-up window click '(.*)' for the message '(.*)'")]
        public void ThenInThePop_UpWindowClickForTheMessage(string windowName, string buttonName, string message)
        {
            new ControlHelper().HandlePopupMessagesUsingWindowName(buttonName, message,windowName);
        }


        [Then(@"wait for few mintues for manual step")]
        public void ThenWaitForFewMintuesForManualStep()
        {
            Thread.Sleep(25000);
        }

        [Then(@"in Unity main window verify menu option is in '(.*)'")]
        public void ThenInUnityMainWindowVerifyMenuOptionIsIn(string language)
        {
            try
            {
                bool flag = false;
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> menuChildren = menuBar.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in menuChildren)
                {
                    if (!flag)
                    {
                        var menuName = e.GetAttribute("Name");
                        if (language.ToLower().Equals("french"))
                        {
                            if (menuName.ToLower().Equals("dossier"))
                            {
                                new ReportHelper().WriteLog("Pass", "Menu option is sucessfully changed to French. File Menu option is now Dossier");
                                flag = true;
                                break;

                            }

                        }
                        else if (language.ToLower().Equals("thai"))
                        {
                            if (menuName.ToLower().Equals("dossier"))
                            {
                                new ReportHelper().WriteLog("Pass", "Menu option is sucessfully changed to Thai. File Menu option is now Dossier");
                                flag = true;
                                break;
                            }
                        }
                        else if (language.ToLower().Equals("english"))
                        {
                            if (menuName.ToLower().Equals("file"))
                            {
                                new ReportHelper().WriteLog("Pass", "Menu option is sucessfully changed to English. File Menu option is now dispalyed as File");
                                flag = true;
                                break;
                            }

                        }
                    }
                }
                if (!flag)
                {
                    new ReportHelper().WriteLog("Fail", "Menu option is not changed to " + language);
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to verify language translation due to exception : " + e.Message);
            }
        }

        [Then(@"in Unity main window verify tab option is in '(.*)'")]
        public void ThenInUnityMainWindowVerifyTabOptionIsIn(string language)
        {
            try
            {
                bool flag = false;
                IWebElement tabControl = Global.driver.FindElementById("tabCtrl");
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tabChildren = tabControl.FindElements(By.XPath("./child::*"));
                foreach (IWebElement e in tabChildren)
                {
                    if (!flag)
                    {
                        var menuName = e.GetAttribute("Name");
                        if (language.ToLower().Equals("french"))
                        {
                            if (menuName.ToLower().Equals("dossier"))
                            {
                                new ReportHelper().WriteLog("Pass", "Menu option is sucessfully changed to French. File Menu option is now Dossier");
                                flag = true;
                                break;

                            }
  
                        }
                        else if (language.ToLower().Equals("thai"))
                        {
                            if (menuName.ToLower().Equals("dossier"))
                            {
                                new ReportHelper().WriteLog("Pass", "Menu option is sucessfully changed to Thai. File Menu option is now Dossier");
                                flag = true;
                                break;
                            }     
                        }
                        else if (language.ToLower().Equals("english"))
                        {
                            if (menuName.ToLower().Equals("file"))
                            {
                                new ReportHelper().WriteLog("Pass", "Menu option is sucessfully changed to English. File Menu option is now dispalyed as File");
                                flag = true;
                                break;
                            }
   
                        }
                    }
                }
                if(!flag)
                {
                    new ReportHelper().WriteLog("Fail", "Menu option is not changed to " +language);
                }
            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to verify language translation due to exception : " + e.Message);
            }
        }


        [Then(@"check if '(.*)' window is opened")]
        public void ThenCheckIfWindowIsOpened(string windowName)
        {
            try
            {
                switch (windowName.ToLower())
                {

                    case "options":
                        Global.driver.FindElementById("w_opzioni").Click();
                        break;
                    default:
                        break;
                }
                new ControlHelper().CheckIfWindowIsLoaded(windowName);

            }
            catch (Exception e)
            {
                new ReportHelper().WriteLog("Fail", "Unable to click on window due to exception " + e.Message);
            }
            //Global.driver.FindElementByName(windowName).Click();
            //new ControlHelper().CheckIfWindowIsLoaded(windowName);
        }

    }
}

