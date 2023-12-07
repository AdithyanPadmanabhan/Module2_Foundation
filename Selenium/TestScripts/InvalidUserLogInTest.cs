using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium_Project.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using SeleniumExtras.WaitHelpers;

namespace Selenium_Project.TestScripts
{

    [TestFixture]
    internal class InvalidUserLogInTest :CoreCodes
    {

        [Test, Order(1)]
        [TestCase(" incorrectUser", "Password123")]
        public void InvalidLoginTest(string username, string password)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";


            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();


            UserLogIn userlogin = new(driver);
            userlogin.UserLoginFunction(username, password);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement message = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='show']")));

           
            string errorMsg = message.Text;

            try
            {
                TakeScreenShot();
                Assert.That(errorMsg, Does.Contain("Your username is invalid!"));

                LogTestResult(" User Invalid Test ", "User Invalid Test success");
                test = extent.CreateTest("User Invalid Test - Pass");
            }
            catch (AssertionException ex)
            {

                LogTestResult("User Invalid Test",
                  "User Invalid Test", ex.Message);


            }
        }

    }
}
