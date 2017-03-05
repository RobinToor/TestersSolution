using Horse1.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SimpleBrowser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse1.Pages
{
    class Administration_TnM
    {
        internal  Administration_TnM(){

            PageFactory.InitElements(Driver.driver, this);
        }

        #region Declaring WebElement 

       [FindsBy(How =How.XPath , Using = "//a[contains(.,'Administration ')]")]
        private IWebElement Admin_link { get; set; }
         
        [FindsBy(How = How.XPath, Using = "//a[@href='/TimeMaterial']")]
        private IWebElement TimenMat_link { get; set; }

        [FindsBy (How = How.XPath, Using = "html/body/div[4]/div/div/div[3]/table/tbody/tr[1]/td[5]/a[1]")]
        private IWebElement Edit_btn { get; set; }

        [FindsBy (How= How.CssSelector , Using = "span.k-icon.k-i-arrow-s")]
        private IWebElement TypeCode { get; set; }

        [FindsBy (How = How.Id, Using = "Code")]
        private IWebElement Code { get; set;}

        [FindsBy(How = How.Id, Using = "Description")]
        private IWebElement Description { get; set; }

        [FindsBy(How = How.Id , Using = "Price")]
        private IWebElement Price { get; set; }

        [FindsBy(How= How.Id , Using = "SaveButton")]
        private  IWebElement SaveButton { get; set; }

        #endregion

        #region Testcase-1 
        public void VerifyEditTextfieldsOnTimenMaterial()
        {
            Admin_link.Click();
            TimenMat_link.Click();
            Driver.wait(2);
            Edit_btn.Click();

        }

    }
}
