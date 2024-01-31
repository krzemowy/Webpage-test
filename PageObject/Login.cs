using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PageObjectModel.PageObject
{
    public class LoginPage
    {
        public LoginPage(IWebDriver driver)
        { 
            Username_Input = driver.FindElement(By.Id("txt-username"));
            Password_Input = driver.FindElement(By.Id("txt-password"));
            Login_Button = driver.FindElement(By.Id("btn-login"));
            //LoginPageHeader_Text = driver.FindElement(By.CssSelector("h2"));
            LoginPageHeader_Text = driver.FindElement(By.XPath("//section[@id='login']/div/div/div/h2"));
            LoginPageTitle_Text = driver.FindElement(By.CssSelector(".lead"));
        }
        private IWebElement Username_Input { get; set; }
        private IWebElement Password_Input { get; set; }
        private IWebElement Login_Button { get; set; }
        private IWebElement LoginPageHeader_Text { get; set; }
        private IWebElement LoginPageTitle_Text { get; set; }
        public void Login(string User, string Password)
        {
            Username_Input.SendKeys(User);
            Password_Input.SendKeys(Password);
            Login_Button.Click();
        }
        public void Login()
        {
            Login("John Doe", "ThisIsNotAPassword");
        }

        public string LoginPageHeader()
        {
            return LoginPageHeader_Text.Text;
        }
        public string LoginPageTitle()
        {
            return LoginPageTitle_Text.Text;
        }
    }
}
