using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V119.Overlay;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;
using static PageObjectModel.PageObjectMethodWrapper;

namespace PageObjectModel
{
    public class LoggedInPage : IPageObjectModel
    {
        /// <summary>
        /// Inits Logged in page class instance properties and checks if page was loaded.
        /// </summary>
        /// <param name="driver"></param>
        public LoggedInPage(IWebDriver driver) : this(driver, PageObject.PageLoaded.Check)
        {
        }
        /// <summary>
        /// Inits Logged in page class instance properties and checks if page was loaded.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="checkPageLoaded"></param>
        public LoggedInPage(IWebDriver driver, PageObject.PageLoaded checkPageLoaded)
        {
            Make_Appointment_Text = driver.FindElement(By.CssSelector("h2"));
            Facility_Dropdown = driver.FindElement(By.Id("combo_facility"));
            Hospital_readmission_CheckBox = driver.FindElement(By.Id("chk_hospotal_readmission"));
            //Healthcare_Program_Radiobuttons = driver.FindElements(By.XPath("//section[@id='appointment']/div/div/form/div[3]/div//input[@type='radio' and @name='programs']"));
            Healthcare_Program_Radiobuttons = driver.FindElements(By.XPath("//input[@type='radio' and @name='programs']"));
            Visit_Date_Input = driver.FindElement(By.XPath("//input[@id='txt_visit_date']"));
            Visit_Comment_Text = driver.FindElement(By.Id("txt_comment"));
            Book_Appointment_Button = driver.FindElement(By.Id("btn-book-appointment"));
            if (checkPageLoaded == PageObject.PageLoaded.Check)
            {
                ConfirmPageIsLoaded();
            }
        }
        private IWebElement Make_Appointment_Text { get; set; }
        private IWebElement Facility_Dropdown { get; set; }
        private IWebElement Hospital_readmission_CheckBox { get; set; }
        private ReadOnlyCollection<IWebElement> Healthcare_Program_Radiobuttons {  get; set; }
        private IWebElement Visit_Date_Input { get; set; }
        private IWebElement Visit_Comment_Text { get; set; }
        private IWebElement Book_Appointment_Button {  get; set; }
        public const string Make_Appointment_Text_Expected = "Make Appointment";
        public readonly struct Facility_Dropdown_Values
        {
            public const string Tokyo = "Tokyo CURA Healthcare Center";
            public const string Hongkong = "Hongkong CURA Healthcare Center";
            public const string Seoul = "Seoul CURA Healthcare Center";
        };
        public readonly struct Healthcare_Program_Radiobutton_Id
        {
            public const string Medicare = "radio_program_medicare";
            public const string Medicaid = "radio_program_medicaid";
            public const string None = "radio_program_none";
        }
        public void ConfirmPageIsLoaded()
        {
            Assert.That(Get_Make_Appointment_Text(), Is.EqualTo(Make_Appointment_Text_Expected), "Make Appointment");
        }
        /// <summary>
        /// Gets title of Make Appointment form.
        /// </summary>
        /// <returns>Title as <see cref="string"/>.</returns>
        public string? Get_Make_Appointment_Text()
        {
            PageObjectMethodWrapper MethodWrapper = new();
            return (MethodWrapper.StaleExceptionCatcher(() =>
            {
                return Make_Appointment_Text.Text;
            }) as string);
        }
        /// <summary>
        /// Gets title of Facility dropdown list.
        /// </summary>
        /// <returns>Title as <see cref="string"/>.</returns>
        public string? Get_Facility_Dropdown_Text()
        {
            PageObjectMethodWrapper MethodWrapper = new();
            return (MethodWrapper.StaleExceptionCatcher(() =>
            {
                return Facility_Dropdown.Text;
            }) as string);
        }
        /// <summary>
        /// Sets Facility dropdown by text.
        /// </summary>
        /// <param name="text"></param>
        public void Set_Facility_Dropdown(string text)
        {
            PageObjectMethodWrapper MethodWrapper = new();
            PageObjectCallback Callback = delegate ()
            {
                SelectElement Facility_Dropdown_Select = new(Facility_Dropdown);
                Facility_Dropdown_Select.SelectByText(text);
                return null;
            };
            MethodWrapper.StaleExceptionCatcher(Callback);
        }
        /// <summary>
        /// Sets Facility by index.
        /// </summary>
        /// <param name="index"></param>
        public void Set_Facility_Dropdown(int index)
        {
            PageObjectMethodWrapper MethodWrapper = new();
            PageObjectCallback Callback = delegate ()
            {
                SelectElement Facility_Dropdown_Select = new(Facility_Dropdown);
                Facility_Dropdown_Select.SelectByIndex(index);
                return null;
            };
            MethodWrapper.StaleExceptionCatcher(Callback);
        }
        /// <summary>
        /// Gets text of actually selected value from Facility dropdown.
        /// </summary>
        /// <returns>Text of selected option in dropdown list as <see cref="string"/>.</returns>
        public string? Get_Selected_Facility_Dropdown_Text()
        {
            PageObjectMethodWrapper MethodWrapper = new();
            PageObjectCallback Callback = delegate ()
            {
                SelectElement Facility_Dropdown_Select = new(Facility_Dropdown);
                return Facility_Dropdown_Select.SelectedOption.Text;
            };
            return (MethodWrapper.StaleExceptionCatcher(Callback) as string);
        }
        /// <summary>
        /// Sets Hospital readmission checkbox.
        /// False - not checked, True - checked.
        /// </summary>
        /// <param name="Set_CheckBox"></param>
        public void Set_Hospital_readmission_CheckBox(bool Set_CheckBox)
        {
            PageObjectMethodWrapper MethodWrapper = new();
            PageObjectCallback Callback = delegate ()
            {
                bool CheckBox_Status = Hospital_readmission_CheckBox.Selected;
                if (CheckBox_Status != Set_CheckBox)
                {
                    Hospital_readmission_CheckBox.Click();
                }
                return null;
            };
            MethodWrapper.StaleExceptionCatcher(Callback);
        }
        public string? Get_Healthcare_Program_Selected_Name()
        {
            PageObjectMethodWrapper MethodWrapper = new();
            PageObjectCallback Callback = delegate ()
            {
                for (int i = 0; i < Healthcare_Program_Radiobuttons.Count; i++)
                {
                    if (Healthcare_Program_Radiobuttons[i].Selected == true)
                    {
                        return Healthcare_Program_Radiobuttons[i].GetAttribute("name");
                    }
                }
                return null;
            };
            return (MethodWrapper.StaleExceptionCatcher(Callback) as string);
        }
        public string? Get_Healthcare_Program_Selected_Id()
        {
            PageObjectMethodWrapper MethodWrapper = new();
            PageObjectCallback Callback = delegate ()
            {
                for (int i = 0; i < Healthcare_Program_Radiobuttons.Count; i++)
                {
                    if (Healthcare_Program_Radiobuttons[i].Selected == true)
                    {
                        return Healthcare_Program_Radiobuttons[i].GetAttribute("id");
                    }
                }
                return null;
            };
            return (MethodWrapper.StaleExceptionCatcher(Callback) as string);
        }
        public void Set_Healthcare_Program_RadioButton_By_Id(string Healthcare_Program)
        {
            PageObjectMethodWrapper MethodWrapper = new();
            PageObjectCallback Callback = delegate ()
            {
                for (int i = 0; i < Healthcare_Program_Radiobuttons.Count; i++)
                {
                    if (Healthcare_Program_Radiobuttons[i].GetAttribute("id") == Healthcare_Program)
                    {
                        Healthcare_Program_Radiobuttons[i].Click();
                        return null;
                    }
                }
                return null;
            };
            MethodWrapper.StaleExceptionCatcher(Callback);
        }
        public void Set_Visit_Date(DateTime Date)
        {
            PageObjectMethodWrapper MethodWrapper = new();
            PageObjectCallback Callback = delegate ()
            {
                string Visit_Date = Date.Date.Day.ToString("D2") + "/" + Date.Date.Month.ToString("D2") + "/" + Date.Date.Year.ToString("D4");
                Visit_Date_Input.SendKeys(Visit_Date);
                return null;
            };
            MethodWrapper.StaleExceptionCatcher(Callback);
        }
        public void Set_Visit_Comment_Text(string Comment)
        {
            PageObjectMethodWrapper MethodWrapper = new();
            MethodWrapper.StaleExceptionCatcher(() =>
            {
                Visit_Comment_Text.SendKeys(Comment);
                return null;
            });
        }
        public void Click_Book_Appointment_Button()
        {
            PageObjectMethodWrapper MethodWrapper = new();
            MethodWrapper.StaleExceptionCatcher(() =>
            {
                Book_Appointment_Button.Click();
                return null;
            });
        }
    }
}
