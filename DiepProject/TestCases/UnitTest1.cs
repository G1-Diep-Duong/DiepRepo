using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiepProject.TestCases;
using DiepProject.PageObjects;
using DiepProject.DataObjects;

namespace DiepProject
{
    [TestClass]
    public class UnitTest1 : Testbase
    {
        [TestMethod]
        public void TC01()
        {
            Account account = new Account("0966007995", "123456");
            MainPage mainPage = new MainPage(webDriver).Open();
            mainPage.GotoLoginPage().Login(account.Phone,account.Password).SpaUsername.Click();
        }

    }
}
