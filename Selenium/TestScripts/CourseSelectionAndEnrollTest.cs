
using MiniProject_JioMart.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_Project.PageObject;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Project.TestScripts
{

    [TestFixture]
    internal class CourseSelectionAndEnrollTest: CoreCodes
    {

        [Test, Order(1)]

        [Category("Regression Testing")]

        public void CourseSelectionAndEntrollTest()
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


            UserLogInPage userlogin = new(driver);
            string? excelFilePath = currDir + "/TestData/Input_Data.xlsx";
            string? sheetName = "PracticePage";

            List<InputData> excelDataList = ExcelUtils.ReadSearchDataExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {


                string? username = excelData?.Username;
                string? password = excelData?.Password;
                string? courseid = excelData?.CourseId;

               

                try
                {
                    var coursetab = userlogin.UserLoginFunction(username, password);
                    LogTestResult("user login Test ", "user login ");
                    test = extent.CreateTest("user login  Test - Pass");
                    coursetab.CourseTabFunction();



                    var enroll = coursetab.CourseSelectionFunction(courseid);

                    LogTestResult("Course selection Test ", "Course selection ");
                    test = extent.CreateTest("Course selection Test - Pass");

                    List<string> listwindow = driver.WindowHandles.ToList();
                    driver.SwitchTo().Window(listwindow[1]);
                    fluentWait.Until(d => enroll);

                    enroll.EnrollFunction();
                  



                    TakeScreenShot();
                   Assert.That(driver.Url.Contains("secure"));
                    LogTestResult("Course Selection and Enroll Test ", "Course Selection and Enroll");
                    test = extent.CreateTest("Course Selection and Enroll Test - Pass");


                }
                catch (AssertionException ex)
                {

                    LogTestResult("Course Selection and Enroll",
                      "Course Selection and Enroll", ex.Message);
                    test = extent.CreateTest("Course Selection and Enroll Test- Fail");
                   
                }
                Log.CloseAndFlush();





            }
        }

    }
}
