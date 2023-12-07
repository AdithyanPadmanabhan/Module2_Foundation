using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Project.PageObject
{
    internal class UserLogIn
    {

        IWebDriver driver;
        public UserLogIn(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }


        [FindsBy(How = How.XPath, Using = "//input[@id='username']")]
        private IWebElement? UserNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        private IWebElement? PassWordInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn")]
        private IWebElement? SubmitButton { get; set; }
       

        public HomePage UserLoginFunction(string username, string password)
        {
            UserNameInput?.SendKeys(username);
            PassWordInput?.SendKeys(password);
            SubmitButton?.Click();
            return new HomePage(driver);


        }
    }
}
