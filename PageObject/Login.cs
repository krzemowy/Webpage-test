using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using static PageObjectModel.PageObject;
using static PageObjectModel.PageObjectMethodWrapper;

namespace PageObjectModel
{
    public class LoginPage : IPageObjectModel
    {
        /// <summary>
        /// Inits Login page class instance properties and checks if page was loaded.
        /// </summary>
        /// <param name="driver"></param>
        public LoginPage(IWebDriver driver) : this(driver, PageObject.PageLoaded.Check)
        {
        }
        /// <summary>
        /// Inits Login page class instance properties and checks if page was loaded.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="checkPageLoaded"></param>
        public LoginPage(IWebDriver driver, PageObject.PageLoaded checkPageLoaded)
        {
            Username_Input = driver.FindElement(By.Id("txt-username"));
            Password_Input = driver.FindElement(By.Id("txt-password"));
            Login_Button = driver.FindElement(By.Id("btn-login"));
            //LoginPageHeader_Text = driver.FindElement(By.CssSelector("h2"));
            LoginPageHeader_Text = driver.FindElement(By.XPath("//section[@id='login']/div/div/div/h2"));
            LoginPageTitle_Text = driver.FindElement(By.CssSelector(".lead"));
            if (checkPageLoaded == PageObject.PageLoaded.Check)
            {
                ConfirmPageIsLoaded();
            }
        }
        private IWebElement Username_Input { get; set; }
        private IWebElement Password_Input { get; set; }
        private IWebElement Login_Button { get; set; }
        private IWebElement LoginPageHeader_Text { get; set; }
        private IWebElement LoginPageTitle_Text { get; set; }


        public const string LoginPageHeader_Text_Expected = "Login";
        public const string LoginPageTitle_Text_Expected = "Please login to make appointment.";
        public const string Default_User = "John Doe";
        public const string Default_Password = "ThisIsNotAPassword";
        public void ConfirmPageIsLoaded()
        {
            //verify if opened page is correct one by checking texts of two objects
            Assert.That(Get_LoginPageHeader_Text(), Is.EqualTo(LoginPageHeader_Text_Expected), "Login page header");
            Assert.That(Get_LoginPageTitle_Text(), Is.EqualTo(LoginPageTitle_Text_Expected), "Login page title");
        }
        /// <summary>
        /// Do logging in.
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Password"></param>
        public void Login(string User, string Password)
        {
            PageObjectMethodWrapper MethodWrapper = new();
            PageObjectCallback Callback = delegate ()
            {
                Username_Input.SendKeys(User);
                Password_Input.SendKeys(Password);
                Login_Button.Click();
                return null;
            };
            MethodWrapper.StaleExceptionCatcher(Callback);
        }
        /// <summary>
        /// Do logging in using default user("John Doe") and password("ThisIsNotAPassword")
        /// </summary>
        public void Login()
        {
            Login(Default_User, Default_Password);
        }
        /// <summary>
        /// Returns a login page header.
        /// </summary>
        /// <returns> Page header as <see cref="string"/>.</returns>
        public string? Get_LoginPageHeader_Text()
        {
            PageObjectMethodWrapper MethodWrapper = new();
            return (MethodWrapper.StaleExceptionCatcher(() =>
            {
                return LoginPageHeader_Text.Text;
            }) as string);
        }
        /// <summary>
        /// Returns a login page title.
        /// </summary>
        /// <returns> Page title as <see cref="string"/>.</returns>
        public string? Get_LoginPageTitle_Text()
        {
            PageObjectMethodWrapper MethodWrapper = new();
            return (MethodWrapper.StaleExceptionCatcher(() =>
            {
                return LoginPageTitle_Text.Text;
            }) as string);
        }
    }
}
