﻿using System;
using OpenQA.Selenium;
using DiepProject.Common;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace DiepProject.PageObjects
{
    public class GeneralPage
    {

        protected IWebDriver webDriver;

        #region Locators



        #endregion

        #region Elements




        #endregion

        #region Methods

        public GeneralPage(IWebDriver _webDriver)
        {
            this.webDriver = _webDriver;
        }

        public GeneralPage()
        {
        }

        /// <summary>
        /// Finds the element.
        /// </summary>
        /// <param name="by">The by.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/2/2016 - 04:07</datetime>
        public IWebElement FindElement(By by, long timeout = Constant.DefaultTimeout)
        {
            IWebElement webElement = null;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (timeout > 0)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
                    wait.Until(ExpectedConditions.ElementExists(by));
                    webElement = webDriver.FindElement(by);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                    if (ex is StaleElementReferenceException || ex is NullReferenceException || ex is WebDriverTimeoutException || ex is ArgumentNullException || ex is WebDriverException)
                    {
                        timeout = timeout - stopWatch.ElapsedMilliseconds / 1000;
                        webElement = FindElement(by, timeout);
                    }
                }
            }

            if (webElement != null) Console.WriteLine("Element <{0}> is found in {1} milliseconds!", by.ToString(), stopWatch.ElapsedMilliseconds);
            else if (stopWatch.ElapsedMilliseconds > 0)
            { Console.WriteLine("Element <{0}> is NOT found in {1} milliseconds!", by.ToString(), stopWatch.ElapsedMilliseconds); }

            stopWatch.Stop();
            return webElement;
        }

        #endregion
    }
}
