using System;
using OpenQA.Selenium;
using DiepProject.Common;
using OpenQA.Selenium.Support.UI;

namespace DiepProject.PageObjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <author>Diep Duong</author>
    /// <datetime>6/8/2016 - 19:47</datetime>
    /// <seealso cref="Group1Project.PageObjects.GeneralPage" />
    class LoginPage : GeneralPage
    {
        private IWebDriver driver;
        
        #region Locators

        static readonly By _txtUsername = By.XPath("//input[@type='text']");
        static readonly By _txtPassword = By.XPath("//input[@type='password']");
        static readonly By _btnLogin = By.XPath("//button[@type='submit']");

        #endregion

        #region Elements
       
        public IWebElement TxtUsername
        {
            get { return FindElement(_txtUsername, Constant.DefaultTimeout); }
        }

        public IWebElement TxtPassword
        {
            get { return FindElement(_txtPassword, Constant.DefaultTimeout); }
        }

        public IWebElement BtnLogin
        {
            get { return FindElement(_btnLogin, Constant.DefaultTimeout); }
        }

        #endregion

        #region Methods

        public LoginPage(IWebDriver webDriver)
            : base(webDriver)
        {
            this.driver = webDriver;
        }       

        public MainPage Login(string username, string password)
        {
            TxtUsername.Set(username);
            TxtPassword.Set(password);
            BtnLogin.Click();
            return new MainPage(webDriver);
        }


       
        #endregion
    }
}
