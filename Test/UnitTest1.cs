using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using PageObjectModel;

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
            //create Main page class instance
            MainPage = new(seleDriver);
            //create Main page class instance and check if page was loaded correctly
            //MainPage = new(seleDriver, PageObject.PageLoaded.Check);
            //(MainPage as IPageObjectModel).ConfirmPageIsLoaded();
            MainPage.ConfirmPageIsLoaded();
            //enter Login page
            MainPage.EnterLoginPage();
            //create Login page class instance
            LoginPage = new(seleDriver);
            //do logging using default user&password
            LoginPage.Login();
            //LoginPage.Get_LoginPageTitle_Text();
            LoggedInPage = new(seleDriver);
            //fill visit booking form
            LoggedInPage.Set_Facility_Dropdown(LoggedInPage.Facility_Dropdown_Values.Seoul);
            LoggedInPage.Set_Hospital_readmission_CheckBox(false);
            LoggedInPage.Set_Healthcare_Program_RadioButton_By_Id(LoggedInPage.Healthcare_Program_Radiobutton_Id.Medicaid);
            LoggedInPage.Set_Visit_Date(DateTime.Parse("01-02-2024"));
            LoggedInPage.Set_Visit_Comment_Text("There is no comment at all.");
            LoggedInPage.Click_Book_Appointment_Button();
        }

        [TearDown]
        public void TearDown()
        {
            seleDriver.Close();
        }
    }
}