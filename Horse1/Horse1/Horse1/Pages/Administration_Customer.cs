using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Horse1.Global;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports.Model;
using NUnit.Core;
using static NUnit.Core.NUnitFramework;

namespace Horse1.Pages
{
    public class Administration_Customer
    {

        internal Administration_Customer()
        {
            PageFactory.InitElements(Driver.driver, this);

        }
        
       

        #region declaring Web Elements
        // Administration
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/div/ul/li[5]/a")]
        private IWebElement AdminLink { get; set; }

        // Customers
        [FindsBy(How = How.LinkText, Using = "Customers")]
        private IWebElement CustLink { get; set; }

        // Create New
        [FindsBy(How = How.LinkText, Using = "Create New")]
        private IWebElement CreateNewBtn { get; set; }

        // Name
        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement CustNameTB { get; set; }

        // Edit Contact
        [FindsBy(How = How.Id, Using = "EditContactButton")]
        private IWebElement EditContactBtn { get; set; }

        // FirstName
        [FindsBy(How = How.XPath, Using = "//input[@id='FirstName']")]
        private IWebElement FirstName { get; set; }

        //// FirstNameout
        ////[FindsBy(How = How.XPath, Using = ".//*[@id='contactDetailWindow_wnd_title']")]
        //[FindsBy(How = How.Id, Using = "FirstName")]
        //private IWebElement FirstNameOut { get; set; }

        // LastName
        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement LastName { get; set; }

        // PreferredName
        [FindsBy(How = How.Id, Using = "PreferedName")]
        private IWebElement PreferredNameTB { get; set; }

        // Phone
        [FindsBy(How = How.Id, Using = "Phone")]
        private IWebElement PhoneTB { get; set; }

        // Mobile
        [FindsBy(How = How.Id, Using = "Mobile")]
        private IWebElement MobileTB { get; set; }

        // Email
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement EmailTB { get; set; }

        // Fax
        [FindsBy(How = How.Id, Using = "Fax")]
        private IWebElement FaxTB { get; set; }

        // Street
        [FindsBy(How = How.Id, Using = "Street")]
        private IWebElement StreetTB { get; set; }

        // City
        [FindsBy(How = How.Id, Using = "City")]
        private IWebElement CityTB { get; set; }

        // Postcode
        [FindsBy(How = How.Id, Using = "Postcode")]
        private IWebElement PostcodeTB { get; set; }

        // Country
        [FindsBy(How = How.Id, Using = "Country")]
        private IWebElement CountryTB { get; set; }

        // Save Contact
        [FindsBy(How = How.Id, Using = "submitButton")]
        private IWebElement SaveContactBtn { get; set; }

        // Exit Edit Contact
        [FindsBy(How = How.XPath, Using = "html/body/div[6]/div[1]/div/a/span")]
        private IWebElement ExitEditContactBtn { get; set; }

        // Same as Above
        [FindsBy(How = How.Id, Using = "IsSameContact")]
        private IWebElement IsSameContactBtn { get; set; }

        // GST
        [FindsBy(How = How.Id, Using = "GST")]
        private IWebElement GstTB { get; set; }

        // Save
        [FindsBy(How = How.Id, Using = "submitButton")]
        private IWebElement SaveBtn { get; set; }
        [FindsBy(How=How.XPath, Using = "html/body/div[4]/form/div/div[4]/div/button")]
        private IWebElement EditBillingBtn { get; set; }

        #region Buttons on Customers Page

        //Edit Button on Customers Page
        [FindsBy(How= How.XPath, Using = "html/body/div[4]/div/div/div[2]/table/tbody/tr[2]/td[4]/a[1]")] 
        private IWebElement Editbtn_Cust_page { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div/div/div[2]/table/tbody/tr[4]/td[4]/a[1]")]
        private IWebElement Deletebtn_Cust_page { get; set; }

        #endregion

        #endregion

        #region Create Customer Valid

        internal void CreateCustomerValid()
        {
            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Customer");

            // Go to Admin > Customer
            Driver.wait(2);
            AdminLink.Click();
            CustLink.Click();
            Driver.wait(2);

            // Create Customer
            CreateNewBtn.Click();
            Driver.wait(2);
            CustNameTB.Clear();
            CustNameTB.SendKeys(ExcelLib.ReadData(2, "Name"));

            // Edit Contact
            EditContactBtn.Click();


            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.Parse("10"));
            IWebElement element = wait.Until(
                ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("FirstName"))
            ).FirstOrDefault();

            element.SendKeys("test");

            //FirstNameTB.Click();
            //FirstNameTB.SendKeys("Myfirst");
            ////           FirstNameTB.SendKeys(ExcelLib.ReadData(2, "FirstName"));
            //            LastNameTB.Clear();
            //            LastNameTB.SendKeys(ExcelLib.ReadData(2, "LastName"));
            //            PreferredNameTB.Clear();
            //            PreferredNameTB.SendKeys(ExcelLib.ReadData(2, "PreferredName"));
            //            PhoneTB.Clear();
            //            PhoneTB.SendKeys(ExcelLib.ReadData(2, "Phone"));
            //            MobileTB.Clear();
            //            MobileTB.SendKeys(ExcelLib.ReadData(2, "Mobile"));
            //            EmailTB.Clear();
            //            EmailTB.SendKeys(ExcelLib.ReadData(2, "Email"));
            //            FaxTB.Clear();
            //            FaxTB.SendKeys(ExcelLib.ReadData(2, "Fax"));
            //            StreetTB.Clear();
            //            StreetTB.SendKeys(ExcelLib.ReadData(2, "Street"));
            //            CityTB.Clear();
            //            CityTB.SendKeys(ExcelLib.ReadData(2, "City"));
            //            CountryTB.Clear();
            //            CountryTB.SendKeys(ExcelLib.ReadData(2, "Country"));
            SaveContactBtn.Click();

            //ExitEditContactBtn.Click();
            Driver.wait(10);

            // Billing Contact
            IsSameContactBtn.Click();

            //GST
            GstTB.Clear();
            GstTB.SendKeys(ExcelLib.ReadData(2, "GST"));

            // Save Customer
            SaveBtn.Click();
            Driver.wait(10);

        }

        #endregion

        #region MyCustomException Handles for error messages for Mandatory Text fields
        public class MyCustomException : Exception
        {
            public void FNameException()
            {
                Console.WriteLine("Incorrect Message");
            }
            public void LNameException()
            {
                Console.WriteLine("Incorrect Message");
            }

            public void PhnException()
            {
                Console.WriteLine("Incorrect Message");
            }

            public void EmailException()
            {
                Console.WriteLine("Incorrect Message");
            }

            public void StreetNameException()
            {
                Console.WriteLine("Incorrect Message");
            }

            public void CityNameException()
            {
                Console.WriteLine("Incorrect Message");
            }

            public void PCodeException()
            {
                Console.WriteLine("Incorrect Message");
            }
            public void CntryNameException()
            {
                Console.WriteLine("Incorrect Message");
            }
            public void VerifyPhnTxtFldLgthException()
            {
                Console.WriteLine("No error message displayed");
            }
            public void VerifyPhnTxtFldLgthException1()
            {
                Console.WriteLine("No error message displayed");
            }
        }

        #endregion

        public void ClearAllFieldsOnEditContactForm()
        {
            //Clearing Existing data from all mandatory fields
            FirstName.Clear();
            LastName.Clear();
            PreferredNameTB.Clear();
            PhoneTB.Clear();
            MobileTB.Clear();
            EmailTB.Clear();
            FaxTB.Clear();
            EmailTB.Clear();
            StreetTB.Clear();
            CityTB.Clear();
            PostcodeTB.Clear();
            CountryTB.Clear();

        }

       //d List<string> windowList = new ArraySegment<string>();
        public void NavigateToEditContactForm()
        {
            //click Admin link from Dashboard
            AdminLink.Click();

            //Click Customers link
            CustLink.Click();
            Driver.wait(3);

            //Click Edit button on Customers Page 
            Editbtn_Cust_page.Click();

            //Pass control to IFrame (Edit Customer details) or Edit Client 
            Driver.driver.SwitchTo().Frame(Driver.driver.FindElement(By.TagName("iframe")));

            Driver.wait(2);


            //Click Edit Contact btn on  Edit Customers Page 
            EditContactBtn.Click();

            //Pass control to IFrame with title Edit Contact
            Driver.driver.SwitchTo().Frame(Driver.driver.FindElement(By.TagName("iframe")));

            Driver.wait(2);
        }

        public void NavigateToEditBillingForm()
        {
            //click Admin link from Dashboard
            AdminLink.Click();

            //Click Customers link
            CustLink.Click();
            Driver.wait(3);

            //Click Edit button on Customers Page 
            Editbtn_Cust_page.Click();

            //Pass control to IFrame (Edit Customer details) or Edit Client 
            Driver.driver.SwitchTo().Frame(Driver.driver.FindElement(By.TagName("iframe")));

            Driver.wait(2);

            //Check if IsSame Checkbox selected. If yes then uncheck it to enable Edit Billing ContactButton

            if (IsSameContactBtn.Selected)
            {
                IsSameContactBtn.Click();
            }

            //Click Edit Billing Contact btn on  Edit Customers Page 
            EditBillingBtn.Click();

            //Pass control to IFrame with title Edit Contact
            Driver.driver.SwitchTo().Frame(Driver.driver.FindElement(By.TagName("iframe")));

            Driver.wait(2);
        }

 #region  TestCase-1 Save Edit Contact Form with Null Data

        public void EditContactWithNullData()
        {
            // Test case ID --  TC_001_23

            /*On Administration> Customers > Edit > Edit Contact window popup, check if user is able to save contact by 
              clicking "Save Contact" button using null data in mandatory fields*/

            //Calling method to Navigate to Edit COntact Popup Window
            NavigateToEditContactForm();

            //Calling method to clear all fields on Edit Contact Form
            ClearAllFieldsOnEditContactForm();
           
            Driver.wait(2);

            //Click Save  button
            SaveContactBtn.Click();
            Driver.wait(2);
 
            // Error messages for all Mandatory fields
            string FName = "The FirstName field is required.";
            string LName = "The LastName field is required.";
            string Email_add = "The Email address is required.";
            string Phn = "The Phone field is required.;Phone number should be digit only";
            string Street = "The Street field is required";
            string Cty = "The City field is requierd";
            string Pcode = "The Postcode is required";
            string Cntry = "The Country field is required";
 
            // Next part is written to validate if the appropriate error messages are dispalyed on saving textfields with Null Data
             
            #region Validate FirstName field
            try
            {
                bool FstName_error_msg = Driver.driver.FindElement(By.CssSelector
                    ("#ContactEditForm > div > div:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(1) > div > span > span")).Displayed;

                string val = Driver.driver.FindElement(By.CssSelector
                    ("#ContactEditForm > div > div:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(1) > div > span > span")).Text;

                if (FstName_error_msg == true && FName == val)
                {
                    Console.WriteLine("Value is {0}:{1}", FstName_error_msg, val);

                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Correct error msge displayed");

                }
                else
                {
                    throw new MyCustomException();
                }

            }
            catch (MyCustomException e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Fname not right ");
                Console.WriteLine("jhasdjhk");
                e.FNameException();
            }

            #endregion

            #region Validate LastName field
            try
            {
                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/div[1]/table/tbody/tr[1]/td[2]/div/span/span"));
                bool LstName_err_msg = j.Displayed;
                string val = j.Text;

                if (LstName_err_msg == true && LName == val)
                {
                    Console.WriteLine("Value is {0}:{1}", LstName_err_msg, val);

                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Correct error msge displayed");

                }
                else
                {
                    throw new MyCustomException();
                }

            }
            catch (MyCustomException e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Lname not right ");
                Console.WriteLine("Hello");
                e.LNameException();
            }

            #endregion

            #region Validate Phone field
            try
            {
                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/div[2]/table/tbody/tr[1]/td[1]/div/span/span"));
                bool Phone_err_msg = j.Displayed;
                string val = j.Text;

                if (Phone_err_msg == true)
                {
                    if (Phn == val)
                    {
                        Console.WriteLine("Value is {0}:{1}", Phone_err_msg, val);

                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Correct error msge displayed");
                    }
                    else
                    {
                        throw new MyCustomException();
                    }

                }
            }
            catch (MyCustomException e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Phone no. is missing ");
                e.PhnException();
            }

            #endregion

            #region Validate Email Add field
            try
            {
                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/div[2]/table/tbody/tr[2]/td[1]/div/span/span"));
                bool Email_err_msg = j.Displayed;
                string val = j.Text;

                if (Email_err_msg == true)
                {
                    if (Email_add == val)
                    {
                        Console.WriteLine("Value is {0}:{1}", Email_err_msg, val);

                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Correct error msge displayed");
                    }

                    else
                    {
                        throw new MyCustomException();
                    }

                }


            }
            catch (MyCustomException e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Incorrect error message for Email Address field ");
                e.EmailException();
            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error message for Email Address field is missing ");
            }
            #endregion

            #region Validate Street field
            try
            {

                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/table/tbody/tr[1]/td[1]/div/span/span"));
                bool Street_err_msg = j.Displayed;
                string val = j.Text;

                if (Street_err_msg == true)
                {
                    if (Street == val)
                    {
                        Console.WriteLine("Value is {0}:{1}", Street_err_msg, val);

                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Correct error msge displayed");
                    }

                    else
                    {
                        throw new MyCustomException();
                    }

                }
            }
            catch (MyCustomException e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " Incorrect error message for Street field ");
                e.StreetNameException();
            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error message for Street field is missing ");

            }
            #endregion

            #region Validate City field 
            try
            {

                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/table/tbody/tr[1]/td[2]/div/span/span"));
                bool City_err_msg = j.Displayed;
                string val = j.Text;

                if (City_err_msg == true)
                {
                    if (Cty == val)
                    {
                        Console.WriteLine("Value is {0}:{1}", City_err_msg, val);

                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Correct error msge displayed");
                    }

                    else
                    {
                        throw new MyCustomException();
                    }

                }
            }
            catch (MyCustomException e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " Incorrect error message for City field ");
                e.CityNameException();
            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error message for City field is missing ");

            }
            #endregion

            #region Validate Postcode field
            try
            {

                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/table/tbody/tr[2]/td[1]/div/span/span"));
                bool Pcode_err_msg = j.Displayed;
                string val = j.Text;

                if (Pcode_err_msg == true)
                {
                    if (Pcode == val)
                    {
                        Console.WriteLine("Value is {0}:{1}", Pcode_err_msg, val);

                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Correct error msge displayed");
                    }

                    else
                    {
                        throw new MyCustomException();
                    }

                }
            }
            catch (MyCustomException e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " Incorrect error message for PostCode field ");
                e.PCodeException();
            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error message for PostCode field is missing ");

            }

            #endregion

            #region Valdidate  Country field

            try
            {

                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/table/tbody/tr[2]/td[2]/div/span/span"));
                bool Country_err_msg = j.Displayed;
                string val = j.Text;

                if (Country_err_msg == true)
                {
                    if (Cntry == val)
                    {
                        Console.WriteLine("Value is {0}:{1}", Country_err_msg, val);

                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Correct error msge displayed");
                    }

                    else
                    {
                        throw new MyCustomException();
                    }

                }
            }
            catch (MyCustomException e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " Incorrect error message for Country field ");
                e.CntryNameException();
            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error message for Country field is missing ");

            }

            #endregion
        }
        #endregion



        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z]"))
        //    {
        //        MessageBox.Show("This textbox accepts only alphabetical characters");
        //        textBox1.Text.Remove(textBox1.Text.Length - 1);
        //    }
        //}
 #region Testcase-2 Save Edit Contact with Invalid Data
        public void EditContactWithInvalidData(string NavTo)
        {
            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Customer");
            //string navigateTo = NavTo;
            if(NavTo == "EditContact")
            {
                NavigateToEditContactForm();
            }
            else
            {
                NavigateToEditBillingForm();
            }
            ClearAllFieldsOnEditContactForm();

            FirstName.SendKeys(ExcelLib.ReadData(2, "FirstName"));
            LastName.SendKeys(ExcelLib.ReadData(2, "LastName"));
            PhoneTB.SendKeys(ExcelLib.ReadData(2, "Phone"));
            EmailTB.SendKeys(ExcelLib.ReadData(2, "Email"));
            StreetTB.SendKeys(ExcelLib.ReadData(2, "Street"));
            CityTB.SendKeys(ExcelLib.ReadData(2, "City"));
            PostcodeTB.SendKeys(ExcelLib.ReadData(2, "Post"));
            CountryTB.SendKeys(ExcelLib.ReadData(2, "Country"));

            Driver.wait(2);

            SaveContactBtn.Click();

            #region Validate FirstName Textfield with Invalid data
            try
            {
                //FirstName textfield with  Invalid data

                IWebElement Fname = Driver.driver.FindElement(By.CssSelector
                   ("#ContactEditForm > div > div:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(1) > div > span > span"));

                bool FstName_error_msg = Fname.Displayed;
                string msge = Fname.Text;
                string expected_err = ExcelLib.ReadData(2, "Invalid_err");
                // Assert.AreEqual("The FirstName accepts only alphabetical characters", msge);
                if (FstName_error_msg == true)
                {
                    if (msge == expected_err)
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "FirstName: Error diplayed for Invalid data is correct");
                    }
                    else
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is not correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " FirstName: Error diplayed for Invalid data is not correct");
                    }
                }

                //if (!System.Text.RegularExpressions.Regex.IsMatch(FirstName.Text, "^[a-zA-Z]"))
                //{
                //    MessageBox.Show("This textbox accepts only alphabetical characters");
                //    textBox1.Text.Remove(textBox1.Text.Length - 1);
                //}


            }
            catch ( Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "FirstName: Error message for Invalid data is missing");
            }

            #endregion

            #region Validate LastName Textfield with Invalid Data
            try
            {
                //LastName textfield with  Invalid data

                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/div[1]/table/tbody/tr[1]/td[2]/div/span/span"));
                bool LstName_err_msg = j.Displayed;
                string msge = j.Text;
                string expected_err = ExcelLib.ReadData(3, "Invalid_err");
                // Assert.AreEqual("The FirstName accepts only alphabetical characters", msge);
                if (LstName_err_msg == true)
                {
                    if (msge == expected_err)
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "LastName:  Error diplayed for Invalid data is correct");
                    }
                    else
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is not correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " LastName: Error diplayed for Invalid data is not correct");
                    }
                }

                //if (!System.Text.RegularExpressions.Regex.IsMatch(FirstName.Text, "^[a-zA-Z]"))
                //{
                //    MessageBox.Show("This textbox accepts only alphabetical characters");
                //    textBox1.Text.Remove(textBox1.Text.Length - 1);
                //}


            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "LastName: Error message for Invalid data is missing");
            }

            #endregion

            #region Validate Phone Textfield with Invalid data
            try
            {
                //Phone textfield with  Invalid data
                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/div[2]/table/tbody/tr[1]/td[1]/div/span/span"));
                bool Phone_err_msg = j.Displayed;
                string msge = j.Text;
                string expected_err = ExcelLib.ReadData(4, "Invalid_err");
                if (Phone_err_msg == true)
                {
                    if (msge == expected_err)
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Phone: Error diplayed for Invalid data is correct");
                    }
                    else
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is not correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Phone: Error diplayed for Invalid data is not correct");
                    }
                }

            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Phone: Error message for Invalid data is missing");
            }

#endregion

            #region Validate Email textfield with Invalid data
            try
            {
                //Email textfield with  Invalid data
                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/div[2]/table/tbody/tr[2]/td[1]/div/span/span"));
                bool Email_err_msg = j.Displayed;
                string msge = j.Text;
                string expected_err = ExcelLib.ReadData(5, "Invalid_err");
                if (Email_err_msg == true)
                {
                    if (msge == expected_err)
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Email: Error diplayed for Invalid data is correct");
                    }
                    else
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is not correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Email: Error diplayed for Invalid data is not correct");
                    }
                }

            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Email: Error message for Invalid data is missing");
            }

            #endregion

            #region Validate Street Textfield with Invalid data
            try
            {
                //Street textfield with  Invalid data
                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/table/tbody/tr[1]/td[1]/div/span/span"));
                bool Street_err_msg = j.Displayed;
                string msge = j.Text;
                string expected_err = ExcelLib.ReadData(6, "Invalid_err");
                if (Street_err_msg == true)
                {
                    if (msge == expected_err)
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Street: Error diplayed for Invalid data is correct");
                    }
                    else
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is not correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Street: Error diplayed for Invalid data is not correct");
                    }
                }

            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Street: Error message for Invalid data is missing");
            }
            #endregion

            #region Validate City Textfield with Invalid data
            try
            {
                //City textfield with  Invalid data
                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/table/tbody/tr[1]/td[2]/div/span/span"));
                bool City_err_msg = j.Displayed;
                string msge = j.Text;
                string expected_err = ExcelLib.ReadData(7, "Invalid_err");
                if (City_err_msg == true)
                {
                    if (msge == expected_err)
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "City: Error diplayed for Invalid data is correct");
                    }
                    else
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is not correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "City: Error diplayed for Invalid data is not correct");
                    }
                }

            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "City: Error message for Invalid data is missing");
            }
            #endregion

            #region Validate PostCode Textfield with Invalid data
            try
            {
                //PostCode textfield with  Invalid data
                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/table/tbody/tr[2]/td[1]/div/span/span"));
                bool Pcode_err_msg = j.Displayed;
                string msge = j.Text;

                string expected_err = ExcelLib.ReadData(8, "Invalid_err");
                if (Pcode_err_msg == true)
                {
                    if (msge == expected_err)
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "PostCode: Error diplayed for Invalid data is correct");
                    }
                    else
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is not correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "PostCode: Error diplayed for Invalid data is not correct");
                    }
                }

            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "PostCode: Error message for Invalid data is missing");
            }
            #endregion

            #region Validate Country Textfield with Invalid data
            try
            {
                //Country textfield with  Invalid data
                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/table/tbody/tr[2]/td[2]/div/span/span"));
                bool Country_err_msg = j.Displayed;
                string msge = j.Text;
                string expected_err = ExcelLib.ReadData(9, "Invalid_err");
                if (Country_err_msg == true)
                {
                    if (msge == expected_err)
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Country: Error diplayed for Invalid data is correct");
                    }
                    else
                    {
                        Console.WriteLine(" Error diplayed for Invalid data is not correct");
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Country: Error diplayed for Invalid data is not correct");
                    }
                }

            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Country: Error message for Invalid data is missing");
            }
            #endregion
        }

        #endregion

 #region Testcase-3 Save Edit Contact form without changing any data
        public void ClicknSave_Wthout_Changes()
        {

            //click Admin link from Dashboard
            AdminLink.Click();

            //Click Customers link
            CustLink.Click();
            Driver.wait(3);

            // Declaring variable to capture  the ID of record before editing
            int Id_For_Rec_bfore_save =Int32.Parse(Driver.driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[1]/td[1]")).Text);
            Console.WriteLine(Id_For_Rec_bfore_save);
            //Click Edit button on Customers Page 
            Editbtn_Cust_page.Click();

            //Pass control to IFrame (Edit Customer details) or Edit Client 
            Driver.driver.SwitchTo().Frame(Driver.driver.FindElement(By.TagName("iframe")));

            Driver.wait(2);

            SaveBtn.Click();

            Driver.driver.SwitchTo().DefaultContent();
            
            try
            {
                // Declaring variable to capture  the ID of record after clicking save with no changes made.
                int Id_For_Rec_aftr_save = Int32.Parse(Driver.driver.FindElement(By.XPath("html/body/div[4]/div/div/div[2]/table/tbody/tr[1]/td[1]")).Text);
                Console.WriteLine(Id_For_Rec_aftr_save);
                Assert.AreEqual(Id_For_Rec_bfore_save, Id_For_Rec_aftr_save);
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "User is able to save Curtomer record without editing the record");
            }
           catch( Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,"User is not able to save Curtomer record without editing the record");
            }

        }

 #endregion

 #region Testcase-4 Verify Maximum & Minimum Character length for Phone Textfield    
        public void Verify_Max_Lth_Phn_Fld(string NavTo)
        {

            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Customer");
            int Phn_no_lnght = 0;

            //string navigateTo = NavTo;
            if (NavTo == "EditContact")
            {
                NavigateToEditContactForm();
            }
            else
            {
                NavigateToEditBillingForm();
            }



            try
            {
                //IWebElement Title = Driver.driver.FindElement(By.Id("contactDetailWindow_wnd_title"));
                //bool StillOnCurrentFrame = true;
                //Console.WriteLine(Title.Text);
                //Thread.Sleep(1000);

                PhoneTB.Clear();
                Driver.wait(3);
                PhoneTB.SendKeys(ExcelLib.ReadData(6, "Phone"));
                Driver.wait(3);
                string x = ExcelLib.ReadData(6, "Phone");
                
                Phn_no_lnght = x.Length;
                Console.WriteLine("{0}", Phn_no_lnght);
                SaveContactBtn.Click();

                       

                if(Phn_no_lnght > 15 || Phn_no_lnght < 7)
                {
                    bool Error_Displayed = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/div[2]/table/tbody/tr[1]/td[1]/div/span/span")).Displayed;
                    string Actual_err_msge = Driver.driver.FindElement(By.XPath("html/body/div[1]/form/div/div[2]/table/tbody/tr[1]/td[1]/div/span/span")).Text;
                    string Expctd_err_msge = ExcelLib.ReadData(8, "Phone");
                    if (Error_Displayed == true)
                    {

                        if (Actual_err_msge == Expctd_err_msge)
                        {
                            Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Phone no. should be between 7-15 numeric characters");
                            Console.WriteLine("Phone no. should be between 7-15 numeric characters");

                        }
                        else
                        {
                            Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Incorrect Error message. It should be \"Phone no. should be between 7-15 numeric characters\"");
                            Console.WriteLine("Phone no. should be between 7-15 numeric characters");
                        }

                    }

                }
              
                else
                {
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Phone textfield only accepts and save data between 7-15 numeric characters");
                    Console.WriteLine("Test Pass");
                }


            }
            
          
            catch(Exception e)
            {
                if(NavTo == "EditContact")
                {
                    Console.WriteLine("No error message displayed");
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                       "Test Fail:  User is able to save Phone no.with less than 7 or more than 15 numeric charaters.  And No error message dispayed");

                }
                else
                {
                    string length = "No. of numeric characters used is " + Convert.ToString(Phn_no_lnght) +".";
                    
                    Console.WriteLine("Phone no. Length is: {0}, No error message displayed", Phn_no_lnght);
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                      "Test Fail : Phone no. Length is, No error message displayed",  length);

                }

            }
                       
        }

        #endregion

 #region Testcase-5 Save Edit Contact winndow with valid Data in all Mandatory fields
        public void SaveEditContactwithValidData(string NavTo)
        {
            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Customer");

            //string navigateTo = NavTo;
            if (NavTo == "EditContact")
            {
                NavigateToEditContactForm();
            }
            else
            {
                NavigateToEditBillingForm();
            }



            Driver.wait(2);
            ClearAllFieldsOnEditContactForm();

            FirstName.SendKeys(ExcelLib.ReadData(10,"FirstName"));
            LastName.SendKeys(ExcelLib.ReadData(10,"LastName"));
            PhoneTB.SendKeys(ExcelLib.ReadData(10,"Phone"));
            EmailTB.SendKeys(ExcelLib.ReadData(10 ,"Email"));
            StreetTB.SendKeys(ExcelLib.ReadData(10,"Street"));
            CityTB.SendKeys(ExcelLib.ReadData(10, "City"));
            PostcodeTB.SendKeys(ExcelLib.ReadData(10, "Post"));
            CountryTB.SendKeys(ExcelLib.ReadData(10, "Country"));

            Driver.wait(2);


            try
            {  // Check if User is able to save
                SaveContactBtn.Click();
                Driver.driver.SwitchTo().ParentFrame();
                Driver.wait(2);
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Save button clicked succesfully");
            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Unable to save contact details");
            }
            try
            {
                //Check is Edit client window closes and control switches back to Edit Client window
                IWebElement x = Driver.driver.FindElement(By.XPath("html/body/div[4]/h2"));
                string iframe_title = x.Text;
                Console.WriteLine(iframe_title);
                Assert.AreEqual("Customer", iframe_title);
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Sucessully switched back to the Edit Client iframe with CUSTOMER title");

            }
            catch(Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Switch back to Parent iframe(Edit Client) failed");
            }
            try
            {
                //Check if Edit contact/ Edit Billing Contact textfield is disabled and loaded with contact details

                if(NavTo == "EditContact")
                {
                    // for Edit Contact Textfield
                    IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[2]/div/input"));
                    bool Txtbox_status = j.Enabled;
                    Console.WriteLine(Txtbox_status);

                    Assert.AreEqual("False", Convert.ToString(Txtbox_status));
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Pass: Edit contact Textbox is disabled as it is populated by contact details");

                }
                else
                {

                    // for Edit Biling Contact Textfield
                    IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[4]/div/input"));
                    bool Txtbox_status = j.Enabled;
                    Console.WriteLine(Txtbox_status);

                    Assert.AreEqual("False", Convert.ToString(Txtbox_status));
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Pass: EditBilling Contact Textbox is disabled as it is populated by contact details");

                }

            }
            catch (Exception e)
            {

                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Fail: Edit contact Textbox is still enabled and blank");
            }

        }
        #endregion

 #region Test-6 Save EditBilling Contact window with Invalid Data in all Mandatory fields
        public void EditBillingRecWithInvalidData()
        {
            //Calling method 
            EditContactWithInvalidData("EditBilling");
        }
        #endregion

 #region Testcase-7 Verify Maximum & Minimum Character length for Phone Textfield on Edit Billing Contact Window
        public void Verify_Max_Lth_Phn_Fld_EditBilling()
        {
            Verify_Max_Lth_Phn_Fld("EditBilling");
        }
        #endregion

 #region Testcase-8 Save Edit Billing Contact  with valid data in all Mandatory fields
        public void EditBilling_Save_Wth_ValidData()
        {
            SaveEditContactwithValidData("EditBilling");
        }

 #endregion

    }
}