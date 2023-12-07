using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Project.PageObject
{
    internal class HomePage
    {

        IWebDriver driver;
        public HomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }


        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'courses')]")]
        private IWebElement? CourseTab { get; set; }

       

        public IWebElement GetCourseSelect(string courseId)
        {
            return driver.FindElement(By.XPath("(//h2[@class='wp-block-heading'])[" + courseId + "]"));
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'contact')]")]
        private IWebElement? ContactTab { get; set; }

        public void CourseTabFunction()
        {
            CourseTab?.Click();
        }

        public CourseEnrollPage CourseSelectionFunction(string courseId)
        {
            GetCourseSelect(courseId)?.Click();

            return new CourseEnrollPage(driver);
        }


        public ContactPage ContactTabFunction()
        {
            ContactTab?.Click();

            return new ContactPage(driver);
        }
    }
}
