using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WiniumPOC.CommonFunctions
{
    public class GenericMethods
    {
        public GenericMethods()
        {
           
        }
        public static string DateandTimeToString()
        {
            var currentDateTime = DateTime.Now.ToString();
            currentDateTime = Regex.Replace(currentDateTime, @"\W+", "");
            currentDateTime.Replace(":", "").Replace(" ", "").Replace("/", "");
            return currentDateTime;
        }
        //by Sajna
        public static string GetCurrentDateInParticularFormat(string dateFormat)
        {
            string currentDate = DateTime.Now.ToString(dateFormat);
            string[] date = currentDate.Split(' ');
            currentDate = date[0];
            return currentDate;
        }
        //By Sajna
        public static string SplitDateFromDateAndTime(string dateToSplit)
        {
            string[] dateStringArray = dateToSplit.Split(' ');
            string date = dateStringArray[0];
            return date;
        }
        public static string GetCurrentDate()
        {
            string currentDate = DateTime.Now.ToString();
            string[] date = currentDate.Split(' ');
            currentDate = date[0];
            return currentDate;
        }
    }
}
