using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    
    public  class Login
    {
               
        public Login()
        {

        }
        [Given(@"Enter username and password and launch Unity application")]
            public void GivenEnterUsernameAndPasswordAndLaunchUnityApplication()
            {
                
                Console.WriteLine("Opened Unity Application");
                //new ControlHelper().CheckIfWindowIsLoaded("Login");
                IWebElement userName = Global.driver.FindElementById("txt_username");
                IWebElement password = Global.driver.FindElementById("txt_password");
                IWebElement okButton = Global.driver.FindElementById("cb_ok");
                IWebElement cancelButton = Global.driver.FindElementById("cb_cancel");
                new ControlHelper().EnterTheValueToTextField(userName, ConfigFile.userName);
                new ControlHelper().EnterTheValueToTextField(password, ConfigFile.password);
                new ControlHelper().ClickOnElement(okButton);
                Thread.Sleep(80000);
    
        }

        [Given(@"Launch the Unity Application")]
        public void GivenLaunchTheUnityApplication()
        {
            Global.driver = new WiniumDriver(@"C:\Temp", Global.options);
            //Thread.Sleep(60000);
            GivenEnterUsernameAndPasswordAndLaunchUnityApplication();
           
        }


    }
}
