using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse1.Global
{
    class Login
    {
        // Initializing the web elements 
        internal Login()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        // Finding the Username Field
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div/div/section/form/div[1]/div/input")]
        private IWebElement Username { get; set; }

        // Finding the Password Field
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div/div/section/form/div[2]/div/input")]
        private IWebElement PassWord { get; set; }

        // Finding the Login Button
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div/div/section/form/div[3]/input[1]")]
        private IWebElement loginButton { get; set; }
        
        internal void LoginSuccessfull()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Login");
            // Navigating to Login page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "url"));
            // Sending the username 
            Username.SendKeys(ExcelLib.ReadData(2, "Username"));
            // Sending the password
            PassWord.SendKeys(ExcelLib.ReadData(2, "Password"));
            // Clicking on the login button
            loginButton.Click();
        }
    

    }
}
