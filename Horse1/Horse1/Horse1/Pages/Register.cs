using Horse1.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse1.Pages
{
    public class Register
    {
        internal Register()
        {
            PageFactory.InitElements(Driver.driver, this);

        }
        //Click on Register Link
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/div/ul[2]/li[1]/a")]
        private IWebElement RegisterLink { get; set; }
        //click on UsernameField
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/form/div[3]/div/input")]
        private IWebElement Username { get; set; }
        //click on Password
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/form/div[3]/div/input")]
        private IWebElement Password { get; set; }
        //click on ConfirmPassword
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/form/div[4]/div/input")]
        private IWebElement ConfirmPassword { get; set; }
        //Click on Regitser Button
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/form/div[4]/div/input")]
        private IWebElement Registerbutton { get; set; }
        public void Navigateregister()
        {
            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Register");
            // Navigating to Login page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "url"));
        }
        public void Commonsteps()
        {
            RegisterLink.Click();
        }

        internal void register()
        {
            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Register");
            Commonsteps();
            
            Driver.wait(2);

            Username.SendKeys(ExcelLib.ReadData(2, "Username"));

            Driver.wait(2);
            Password.SendKeys(ExcelLib.ReadData(2, "Password"));
            ConfirmPassword.SendKeys(ExcelLib.ReadData(2, "ConfirmPassword"));
            Registerbutton.Click();
        }
    }
}
