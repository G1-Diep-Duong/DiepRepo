using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Support;
using System.Diagnostics;
using DiepProject.PageObjects;


namespace DiepProject.Common
{
    public static class CommonMethods
    {
        public static IWebDriver WebDriver;

        public static string CreateRandomString(int length)
        {
            Thread.Sleep(1000);
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string CreateRandomEmail(string emaildomain)
        {
            return CreateRandomString(15) + "@" + emaildomain;
        }

        public static bool IsElementPresent(IWebDriver webDriver, By by)
        {
            try
            {
                webDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Clicks the specified iwebelement.
        /// </summary>
        /// <param name="iwebelement">The iwebelement.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/4/2016 - 15:35</datetime>
      

        /// <summary>
        /// Converts the date time to string.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/7/2016 - 00:18</datetime>
        public static string ConvertDateTimeToString(DateTime dt)
        {
            return dt.Month.ToString() + '-' + dt.Day.ToString() + '-' + dt.Year.ToString() + '-' + dt.Hour.ToString() +'-' + dt.Minute.ToString() +'-' + dt.Second.ToString()+ '-' + dt.Millisecond.ToString();
        }

        public static DateTime ConvertStringToDateTime(string str)
        {
            string[] words = str.Split('/');
            DateTime dt = new DateTime(int.Parse(words[2]), int.Parse(words[0]), int.Parse(words[1]));
            return dt;
        }


        /// <summary>
        /// Gets the combobox selected value.
        /// </summary>
        /// <param name="combobox">The combobox.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/6/2016 - 02:25</datetime>
        

        /// <summary>
        /// Randoms the string.
        /// </summary>
        /// <returns></returns>
        /// <author>Binh Le</author>
        /// <datetime>6/6/2016 - 11:41 PM</datetime>
        public static string RandomString()
        {
            string Random = DateTime.Now.ToString("ddMMMyyHHmmssfff");
            return Random;
        }
             


        /// <summary>
        /// xes the path contain generate.
        /// </summary>
        /// <param name="tagname">The tagname.</param>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/2/2016 - 22:33</datetime>
        public static string XPathContainGenerate(string tagname, string str)
        {
            //Use it while the xPath has space characters 
            string xPath = "//" + tagname;
            string[] words = str.Split(' ');
            foreach (string word in words)
            {
                xPath = xPath + "[contains(.,'" + word + "')]";
            }
            return xPath;
        }
    




    }
}
