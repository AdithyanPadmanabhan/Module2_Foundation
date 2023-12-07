using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Project.PageObject
{
    internal class CourseEnrollPage
    {

        IWebDriver driver;
        public CourseEnrollPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }


    

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement? EnrollButton { get; set; }
       


        public void EnrollFunction()
        {

           CoreCodes.ScrollIntoView(driver, driver.FindElement(By.XPath("//div[contains(text(),' $36 every 6 month')]")));
          

            EnrollButton?.Click();

        }
    }
}
