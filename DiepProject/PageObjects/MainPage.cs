using DiepProject.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiepProject.PageObjects
{
    class MainPage : GeneralPage
    {
        private IWebDriver driver;

        #region Locators

        static readonly By _spaUsername = By.XPath("//span[@class='text_user_name']");
        static readonly By _lnkDangNhap = By.XPath("//span[@class='sprite_sunny_common_black_reg_icon']");



        #endregion

        #region Elements
        public IWebElement LnkDangNhap
        {
            get { return FindElement(_lnkDangNhap, Constant.DefaultTimeout); }
        }
        public IWebElement SpaUsername
        {
            get { return FindElement(_spaUsername, Constant.DefaultTimeout); }
        }


        #endregion

        #region Methods

        public MainPage(IWebDriver webDriver)
            : base(webDriver)
        {
            this.driver = webDriver;
        }

        public MainPage Open()
        {
            webDriver.Navigate().GoToUrl(Constant.LoginPageURL);
            return this;
        }

        public LoginPage GotoLoginPage()
        {
            LnkDangNhap.Click();
            return new LoginPage(webDriver);
        }

        #endregion

    }
}
