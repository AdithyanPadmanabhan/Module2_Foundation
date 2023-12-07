using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium_Project.PageObject;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Project.TestScripts
{
    internal class ContactDetailsTest : CoreCodes
    {

        [Test, Order(1)]

        [Category("Regression Testing")]
        [TestCase("student","Password123","Amal","John","john@abc.com","hi")]

        public void ContactDetailTest(string username,string password,string firstname,string lastname,string email,string comment)
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

            try
            {
                UserLogInPage userlogin = new(driver);
                var contacttab = userlogin.UserLoginFunction(username, password);
                var contactdetail =fluentWait.Until(d=> contacttab.ContactTabFunction());
                contactdetail.ContactDetailsFunction(firstname, lastname, email, comment);

                Assert.That(driver.Url.Contains("contact"));

                LogTestResult(" Contact Details Test ", "Contact Details Test success");
              test = extent.CreateTest("Contact Details  Test - Pass");
            }
            catch (AssertionException ex)
            {

                LogTestResult("Contact Details  Test",
                      "Contact Details   failed", ex.Message);
               test.Fail("Contact Details   failed");
            }

            Log.CloseAndFlush();
        }
    }
}
