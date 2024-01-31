using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.PageObject
{
    public class MainPage
    {
        public MainPage(IWebDriver driver)
        {
            //this.driver = driver;
            Make_Appointment_Button = driver.FindElement(By.Id("btn-make-appointment"));
        }
        //private IWebDriver driver;
        private IWebElement Make_Appointment_Button { get; set; }
        public void EnterLoginPage()
        {
            Make_Appointment_Button.Click();
        }
    }
}
