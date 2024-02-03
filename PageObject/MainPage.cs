using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel
{
    public class MainPage : IPageObjectModel
    {
        /// <summary>
        /// Inits Main page class instance properties and checks if page was loaded.
        /// </summary>
        /// <param name="driver"></param>
        public MainPage(IWebDriver driver) : this(driver, PageObject.PageLoaded.Check)
        {
        }
        /// <summary>
        /// Inits Main page class instance properties and checks if page was loaded.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="checkPageLoaded"></param>
        public MainPage(IWebDriver driver, PageObject.PageLoaded checkPageLoaded)
        {
            Make_Appointment_Button = driver.FindElement(By.Id("btn-make-appointment"));
            if (checkPageLoaded == PageObject.PageLoaded.Check)
            {
                ConfirmPageIsLoaded();
            }
        }
        //private IWebDriver driver;
        private IWebElement Make_Appointment_Button { get; set; }
        /// <summary>
        /// Enter login page by clicking "Make Appointment" button.
        /// </summary>
        public void EnterLoginPage()
        {
            PageObjectMethodWrapper MethodWrapper = new();
            MethodWrapper.StaleExceptionCatcher(() =>
            {
                Make_Appointment_Button.Click();
                return null;
            });
        }
        public void ConfirmPageIsLoaded()
        {
            
        }
    }
}
