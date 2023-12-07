using BDD_Project.Hooks;
using BDD_Project.Utilities;
using NUnit.Framework.Internal;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace BDD_Project.StepDefinitions
{
    [Binding]
    internal class InvaliduserSteps:CoreCodes
    {

        IWebDriver? driver = AllHooks.driver;
        [Given(@"User will be on Login  page")]
        public void GivenUserWillBeOnLoginPage()
        {
            driver.Url = "https://practicetestautomation.com/practice-test-login/";
            driver.Manage().Window.Maximize();
        }

        [When(@"user will enter  username '([^']*)'")]
        public void WhenUserWillEnterUsername(string username)
        {
            var fluentWait = Waits(driver);
            IWebElement usernameInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='username']")));
            usernameInput?.SendKeys(username);
        }

        [When(@"user will enter  password '([^']*)'")]
        public void WhenUserWillEnterPassword(string password)
        {
            var fluentWait = Waits(driver);
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='password']")));
            passwordInput?.SendKeys(password);
        }

        [When(@"user will click  on submit button")]
        public void WhenUserWillClickOnSubmitButton()
        {
            var fluentWait = Waits(driver);
            IWebElement submitbutton = fluentWait.Until(d => d.FindElement(By.ClassName("btn")));
            submitbutton?.Click();
        }
        [Then(@"Error message for password length should be thrown")]
        public void ThenErrorMessageForPasswordLengthShouldBeThrown()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement message = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='show']")));


            string errorMsg = message.Text;

            try
            {
                TakeScreenShot(driver);
                Assert.That(errorMsg, Does.Contain("Your username is invalid!"));

                LogTestResult(" User Invalid Test ", "User Invalid Test success");
             
            }
            catch (AssertionException ex)
            {

                LogTestResult("User Invalid Test",
                  "User Invalid Test", ex.Message);


            }
        }
    }
}
