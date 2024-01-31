using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Webpage_test.PageObject
{
    public class LoggedInPage
    {
        public LoggedInPage(IWebDriver driver)
        {
            Make_Appointment_Text = driver.FindElement(By.CssSelector("h2"));
            Facility_Dropdown = driver.FindElement(By.Id("combo_facility"));
        }
        private IWebElement Make_Appointment_Text {  get; set; }
        private IWebElement Facility_Dropdown { get; set; }
        public string Make_Appointment_Title()
        {
            return Make_Appointment_Text.Text;
        }
        public string Facility_Dropdown_Title()
        {
            return Facility_Dropdown.Text;
        }
    }
}
