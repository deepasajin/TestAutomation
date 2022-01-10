using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiniumPOC.Utilities
{
    public class Global
    {
        public static WiniumDriver driver { get; set; }
        public static DesktopOptions options { get; set; }
        public static WiniumDriverService driverService { get; set; }
        public static IKeyboard keyboardAction { get; set; }

        //internal class driver
        //{
        //    internal class FindElementById
        //    {
        //    }
        //}
    }
}
