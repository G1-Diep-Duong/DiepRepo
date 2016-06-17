﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using DiepProject.PageObjects;
using System;
using System.Diagnostics;

namespace DiepProject.Common
{
    public static class IWebElementExtension
    {
        public static IWebElement iwebelement;
        public static bool acceptNextAlert = true;

        public static void Highlight(this IWebElement context, int duration = 2)
        {
            var rc = (RemoteWebElement)context;
            var driver = (IJavaScriptExecutor)rc.WrappedDriver;
            string script = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: #ff0000""; ";
            driver.ExecuteScript(script, rc);
            Thread.Sleep(1000 * duration);
            string clear = @"arguments[0].style.cssText = ""border-width: 0px; border-style: solid; border-color: #ff0000""; ";
            driver.ExecuteScript(clear, rc);
        }

        public static void Blink(this IWebElement context, int times = 1)
        {
            int loop = 0;
            var rc = (RemoteWebElement)context;
            var driver = (IJavaScriptExecutor)rc.WrappedDriver;
            string script1 = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: #ff0000""; ";
            string script2 = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: #00ff00""; ";
            string clear = @"arguments[0].style.cssText = ""border-width: 0px; border-style: solid; border-color: #ff0000""; ";
            do
            {
                driver.ExecuteScript(script2, rc);
                Thread.Sleep(250);
                driver.ExecuteScript(script1, rc);
                Thread.Sleep(250);
                loop++;
            } while (loop < times);
            driver.ExecuteScript(clear, rc);
        }
        /// <summary>
        /// Selects the by value.
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <param name="value">The value.</param>
        /// <author>Diep Duong</author>
        /// <datetime>6/3/2016 - 08:47</datetime>
        public static void SelectByValue(this IWebElement webElement, string value)
        {
            SelectElement SelectedCbo = new SelectElement(webElement);
            SelectedCbo.SelectByValue(value);
            webElement.Click();
            webElement.Click();
        }

        /// <summary>
        /// Selects the by text.
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <param name="text">The text.</param>
        /// <author>Diep Duong</author>
        /// <datetime>6/3/2016 - 08:47</datetime>
        public static void SelectByText(this IWebElement webElement, string text)
        {         
            SelectElement SelectedCbo = new SelectElement(webElement);
            SelectedCbo.SelectByText(text);
            webElement.Click();
            webElement.Click();
        }

        /// <summary>
        /// Selects the index of the by.
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <param name="index">The index.</param>
        /// <author>Diep Duong</author>
        /// <datetime>6/3/2016 - 08:47</datetime>
        public static void SelectByIndex(this IWebElement webElement, int index)
        {
            SelectElement SelectedCbo = new SelectElement(webElement);
            SelectedCbo.SelectByIndex(index);
        }

        public static void Set(this IWebElement element, string value, bool clearFirst = true)
        {
            if (clearFirst) element.Clear();
            element.SendKeys(value);
        }

        /// <summary>
        /// Gets the selected text.
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/5/2016 - 21:39</datetime>
        public static string GetSelectedText(this IWebElement webElement)
        {
            SelectElement SelectedCbo = new SelectElement(webElement);
            return SelectedCbo.SelectedOption.Text;
        }

        /// <summary>
        /// Checks the specified value.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <author>Diep Duong</author>
        /// <datetime>6/5/2016 - 12:01</datetime>
        public static void Check(this IWebElement element, bool value = true)
        {
            Console.WriteLine("[checkbox id:{0}] is checked {1}", element.GetAttribute("id"), (value ? "On" : "Off"));
            if (element.Selected != value) element.Click();
        }

        public static void MoveMouse(this IWebElement element, IWebDriver webDriver)
        {
            Actions action = new Actions(webDriver);
            action.MoveToElement(element).Perform();
        }

        /// <summary>
        /// Waits for control.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="webElement">The web element.</param>
        /// <param name="timeout">The timeout.</param>
        /// <author>Diep Duong</author>
        /// <datetime>6/3/2016 - 09:18</datetime>
        public static void WaitForControl(this IWebElement webElement, IWebDriver webDriver, int timeout)
        {
            GeneralPage generalPage = new GeneralPage(webDriver);
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => webElement.Enabled);
        }

        /// <summary>
        /// Gets the table rows.
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/6/2016 - 05:17</datetime>
        public static int GetTableRows(this IWebElement webElement)
        {
            return webElement.FindElements(By.TagName("tr")).Count;
        }

        /// <summary>
        /// Gets the table columns.
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/6/2016 - 05:18</datetime>
        public static int GetTableColumns(this IWebElement webElement)
        {
            return (webElement.FindElements(By.TagName("td")).Count / webElement.FindElements(By.TagName("tr")).Count);
        }
        /// <summary>
        /// Determines whether [is item exists] [the specified item].
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/6/2016 - 06:04</datetime>
        public static bool IsItemExists(this IWebElement webElement, string item)
        {
            bool flag = false;

            SelectElement selectElement = new SelectElement(webElement);
            int count = selectElement.Options.Count;
            for (int i = 0; i < count; i++)
            {
                if (selectElement.Options[i].Text == item)
                {
                    flag = true;
                    break;
                }

            }
            return flag;
        }
        public static bool Click(IWebElement iwebelement)
        {
            try
            {
                iwebelement.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// Waits for control.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="by">The by.</param>
        /// <param name="timeout">The timeout.</param>
        /// <author>Diep Duong</author>
        /// <datetime>6/2/2016 - 22:43</datetime>
        public static IWebElement WaitForControl(IWebDriver webDriver, By by, int timeout)
        {
            IWebElement webElement = null;
            Stopwatch sW = new Stopwatch();
            sW.Start();
            GeneralPage generalPage = new GeneralPage(webDriver);
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => webElement = generalPage.FindElement(by, timeout));
            Console.WriteLine("Already waiting for control <{0}> in {1} milliseconds!", by.ToString(), sW.ElapsedMilliseconds);
            sW.Stop();
            return webElement;
        }

        /// <summary>
        /// Waits for control clickable.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="by">The by.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/9/2016 - 00:25</datetime>
        public static IWebElement WaitForControlClickable(IWebDriver webDriver, By by, int timeout = Constant.DefaultTimeout)
        {
            Stopwatch sW = new Stopwatch();
            sW.Start();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => ExpectedConditions.ElementIsVisible(by));
            wait.Until(d => ExpectedConditions.ElementToBeClickable(by));

            Console.WriteLine("Already waiting for control <{0}> clickable in {1} milliseconds!", by.ToString(), sW.ElapsedMilliseconds);
            sW.Stop();
            GeneralPage generalPage = new GeneralPage(webDriver);
            return generalPage.FindElement(by);
        }

        /// <summary>
        /// Waits for control disappear.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="by">The by.</param>
        /// <param name="timeout">The timeout.</param>
        /// <author>Diep Duong</author>
        /// <datetime>6/6/2016 - 02:26</datetime>
        public static void WaitForControlDisappear(IWebDriver webDriver, By by, int timeout)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            bool flag = CommonMethods.IsElementPresent(webDriver, by);

            while (flag && timeout > 0)
            {
                Thread.Sleep(1000);
                flag = CommonMethods.IsElementPresent(webDriver, by);
                timeout = timeout - 1;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("Wait for <{0}> disappears in {1} milliseconds!", by.ToString(), ts.Milliseconds);

        }

        public static bool WaitForControlEnable(IWebDriver webDriver, By by, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            return wait.Until(d => webDriver.FindElement(by).Enabled);
        }

        /// <summary>
        /// Waits for control displayed.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="by">The by.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/4/2016 - 16:56</datetime>
        public static bool WaitForControlDisplayed(IWebDriver webDriver, By by, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            return wait.Until(d => webDriver.FindElement(by).Displayed);
        }


        public static void WaitForControlEnable(IWebDriver webDriver, IWebElement webelement, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => webelement.Enabled);
        }
        public static string GetComboboxSelectedValue(IWebElement combobox)
        {
            SelectElement SelectedCbo = new SelectElement(combobox);
            return SelectedCbo.SelectedOption.Text;
        }

        public static bool IsAlertPresent(IWebDriver WebDriver)
        {
            try
            {
                WebDriver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Closes the alert and get its text.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <returns></returns>
        /// <author>Diep Duong</author>
        /// <datetime>6/2/2016 - 22:33</datetime>
        public static string CloseAlertAndGetItsText(IWebDriver webDriver)
        {
            try
            {
                IAlert alert = webDriver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        public static void WaitUntilControlDisappear(IWebDriver webDriver, string tag, string property, string value)
        {
            bool check = CommonMethods.IsElementPresent(webDriver, By.XPath("//" + tag + "[" + property + "='" + value + "']"));
            if (check == true)
            {
                Thread.Sleep(1000);
            }
        }

    }



}
