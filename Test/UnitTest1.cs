using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using PageObjectModel.PageObject;
using Webpage_test.PageObject;

namespace Webpage_test.Test
{
    public class Tests
    {
        private IWebDriver seleDriver;
        public MainPage? MainPage { get; set; }
        public LoginPage? LoginPage { get; set; }
        public LoggedInPage? LoggedInPage { get; set;}
        [SetUp]
        public void Setup()
        {
            seleDriver = new FirefoxDriver
            {
                Url = "https://katalon-demo-cura.herokuapp.com/"
            };
        }

        [Test]
        public void TC_Login()
        {
            MainPage = new(seleDriver);
            MainPage.EnterLoginPage();
            LoginPage = new(seleDriver);
            Assert.That(LoginPage.LoginPageHeader(), Is.EqualTo("Login"), "Login page header");
            Assert.That(LoginPage.LoginPageTitle(), Is.EqualTo("Please login to make appointment."), "Login page title");
            LoginPage.Login();
            LoggedInPage = new(seleDriver);
            Assert.That(LoggedInPage.Make_Appointment_Title(), Is.EqualTo("Make Appointment"), "Make Appointment");
        }

        [TearDown]
        public void TearDown()
        {
            seleDriver.Close();
        }
    }
}