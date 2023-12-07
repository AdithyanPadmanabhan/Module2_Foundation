using BDD_Project.Hooks;
using BDD_Project.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace BDD_Project.StepDefinitions
{
    [Binding]
    internal class CourseSelectionSteps: CoreCodes
    {

        IWebDriver? driver = AllHooks.driver;

        [Given(@"User will be on Login page")]
        public void GivenUserWillBeOnLoginPage()
        {
            driver.Url = "https://practicetestautomation.com/practice-test-login/";
            driver.Manage().Window.Maximize();
        }

        [When(@"user will enter username '([^']*)'")]
        public void WhenUserWillEnterUsername(string username)
        {
            var fluentWait = Waits(driver);
            IWebElement usernameInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='username']")));
            usernameInput?.SendKeys(username);
            

        }

        [When(@"user will enter password '([^']*)'")]
        public void WhenUserWillEnterPassword(string password)
        {
            var fluentWait = Waits(driver);
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='password']")));
            passwordInput?.SendKeys(password);
        }

        [When(@"user will click on submit button")]
        public void WhenUserWillClickOnSubmitButton()
        {
            var fluentWait = Waits(driver);
            IWebElement submitbutton = fluentWait.Until(d => d.FindElement(By.ClassName("btn")));
            submitbutton?.Click();
        }

        [Then(@"user will be redirected to Homepage")]
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

        [When(@"User will click on course tab")]
        public void WhenUserWillClickOnCourseTab()
        {
            var fluentWait = Waits(driver);
            IWebElement courseTab = fluentWait.Until(d => d.FindElement(By.XPath("//a[contains(@href,'courses')]")));
            courseTab?.Click();

        }

        [When(@"User selects a '([^']*)'")]
        public void WhenUserSelectsA(string courseId)
        {
           
            var fluentWait = Waits(driver);
            IWebElement courseTab = fluentWait.Until(d => d.FindElement(By.XPath("(//h2[@class='wp-block-heading'])[" + courseId + "]"))); 
            courseTab?.Click();

        }

        [Then(@"user will be redirected to course page")]
       public void ThenUserWillBeRedirectedToCoursePage()
        {

            Assert.That(driver.Title.Contains("selenium"));
        }
        [When(@"user click on enroll button")]
        public void WhenUserClickOnEnrollButton()
        {

            CoreCodes.ScrollIntoView(driver, driver.FindElement(By.XPath("//div[contains(text(),' $36 every 6 month')]")));
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then(@"user will be on payment page")]
        public void ThenUserWillBeOnPaymentPage()
        {
            Assert.That(driver.Url.Contains("secure"));
        }



    }
}
