using BDD_Project.Hooks;
using BDD_Project.Utilities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace BDD_Project.StepDefinitions
{
    [Binding]
    internal class ContactDetailsSteps :CoreCodes
    {
        IWebDriver? driver = AllHooks.driver;

     
        [Given(@"User will be on Login   page")]
        public void GivenUserWillBeOnLoginPage()
        {
            driver.Url = "https://practicetestautomation.com/practice-test-login/";
            driver.Manage().Window.Maximize();
        }


        [When(@"user will enter  username  '([^']*)'")]
        public void WhenUserWillEnterUsername(string username)
        {
            var fluentWait = Waits(driver);
            IWebElement usernameInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='username']")));
            usernameInput?.SendKeys(username);
        }

        [When(@"user will enter  password  '([^']*)'")]
        public void WhenUserWillEnterPassword(string password)
        {
            var fluentWait = Waits(driver);
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='password']")));
            passwordInput?.SendKeys(password);
        }


        [When(@"user will click  on submit  button")]
        public void WhenUserWillClickOnSubmitButton()
        {
            var fluentWait = Waits(driver);
            IWebElement submitbutton = fluentWait.Until(d => d.FindElement(By.ClassName("btn")));
            submitbutton?.Click();
        }

        [Then(@"user will be  redirected to Homepage")]
        public void ThenUserWillBeRedirectedToHomepage()
        {
            TakeScreenShot(driver);
            try
            {


                Assert.That(driver.Url.Contains("successfully"));
                LogTestResult("User login Test ", "User login success");


            }
            catch (AssertionException ex)
            {

                LogTestResult("User login Test",
                  "User login failed", ex.Message);

            }
        }

        [When(@"User will click on contact tab")]
        public void WhenUserWillClickOnContactTab()
        {
            var fluentWait = Waits(driver);
            IWebElement contactTab = fluentWait.Until(d => d.FindElement(By.XPath("//a[contains(@href,'contact')]")));
            contactTab?.Click();
        }

        [Then(@"user will be on contact details page")]
        public void ThenUserWillBeOnContactDetailsPage()
        {
            Assert.That(driver.Url.Contains("contact"));
        }

        [When(@"user will enter firstname '([^']*)'")]
        public void WhenUserWillEnterFirstname(string firstname)
        {
            var fluentWait = Waits(driver);
            IWebElement firstnameInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='wpforms-161-field_0']")));
            firstnameInput?.SendKeys(firstname);
        }

        [When(@"user will enter lastname '([^']*)'")]
        public void WhenUserWillEnterLastname(string lastname)
        {
            var fluentWait = Waits(driver);
            IWebElement lastnameInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='wpforms-161-field_0-last']")));
            lastnameInput?.SendKeys(lastname);
        }

        [When(@"user will enter  email'([^']*)'")]
        public void WhenUserWillEnterEmail(string email)
        {
            var fluentWait = Waits(driver);
            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='wpforms-161-field_1']")));
            emailInput?.SendKeys(email);
        }

        [When(@"user will enter Comments <'([^']*)'")]
        public void WhenUserWillEnterComments(string comments)
        {
            var fluentWait = Waits(driver);
            IWebElement commentInput = fluentWait.Until(d => d.FindElement(By.XPath("//textarea[@id='wpforms-161-field_2']")));
            commentInput?.SendKeys(comments);
        }

        [When(@"user will click on submit form")]
        public void WhenUserWillClickOnSubmitForm()
        {
            var fluentWait = Waits(driver);
            IWebElement submitbutton = fluentWait.Until(d => d.FindElement(By.Id("wpforms-submit-161")));
            submitbutton?.Click();
        }

        [Then(@"user will redirected to contactpage")]
        public void ThenUserWillRedirectedToContactPage()
        {
            TakeScreenShot(driver);
            try
            {

                Assert.That(driver.Url.Contains("contact"));

                LogTestResult(" Contact Details Test ", "Contact Details Test success");
            }

            catch (AssertionException ex)
            {

                LogTestResult("Contact Details  Test",
                      "Contact Details   failed", ex.Message);

            }
        }

    }
}
