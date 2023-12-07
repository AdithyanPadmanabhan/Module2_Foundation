using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Project.PageObject
{
    internal class ContactPage
    {



        IWebDriver driver;
        public ContactPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//input[@id='wpforms-161-field_0']")]
        private IWebElement? FirstNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='wpforms-161-field_0-last']")]
        private IWebElement? LastNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='wpforms-161-field_1']")]
        private IWebElement? EmailInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//textarea[@id='wpforms-161-field_2']")]
        private IWebElement? CommentInput { get; set; }

        [FindsBy(How = How.Id, Using = "wpforms-submit-161")]
        private IWebElement? SubmitButton { get; set; }


        public void ContactDetailsFunction(string firstname,string lastname,string email,string comment)
        {
            FirstNameInput?.SendKeys(firstname);
            LastNameInput?.SendKeys(lastname);
            EmailInput?.SendKeys(email);
            CommentInput?.SendKeys(comment);
            SubmitButton?.Click();

        }



    }
}
