using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel
{
    public interface IPageObjectModel
    {
        /// <summary>
        /// Confirms page was loaded properly.
        /// </summary>
        void ConfirmPageIsLoaded();
    }
    public static class PageObject
    {
        public enum PageLoaded
        {
            DontCheck,
            Check
        }
    }
    public class PageObjectMethodWrapper
    {
        //public PageObjectMethodWrapper() { }
        //public delegate Object? PageObjectCallback(params Object?[] objects);
        public PageObjectMethodWrapper(IWebDriver? caller_driver)
        {
            driver = caller_driver;
        }
        public PageObjectMethodWrapper() : this(null)
        {
        }
        public delegate Object? PageObjectCallback();
        public IWebDriver? driver;
        public Object? StaleExceptionCatcher(PageObjectCallback callback)
        {
            Object? Object_To_Return = null;
            TimeSpan timeSpan = TimeSpan.Zero;
            if (driver != null) timeSpan = driver.Manage().Timeouts().ImplicitWait;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Object_To_Return = callback();
                    break;
                }
                catch (Exception e)
                {
                    if (e is StaleElementReferenceException Stale_Exception)
                    {
                        if (driver != null) driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            if (driver != null) driver.Manage().Timeouts().ImplicitWait = timeSpan;
            return Object_To_Return;
        }
    }
}
