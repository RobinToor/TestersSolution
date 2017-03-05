using Horse1.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Horse1.Pages
{
    class Administration_Employees
    {
        internal Administration_Employees()
        {
            PageFactory.InitElements(Driver.driver, this);

        }

        #region declaring_WebElement

        #region Create_New_Page_WebElements
        //Click on Administration Link
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/ul/li[5]/a")]
        private IWebElement Administration_link { get; set; }

        //Click on Employees Link
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a")]
        private IWebElement Employee_Link { get; set; }

        //Click on Create_New_Button
        [FindsBy(How = How.XPath, Using = "//*[@id=\"container\"]/p/a")]
        private IWebElement Create_New_btn { get; set; }

        //Click Name textbox on Create_New_Button page
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/form/div/div[1]/div/input")]
        private IWebElement Name { get; set; }

        //Click Username textbox on reate_New_Button page
        [FindsBy(How = How.XPath, Using = "//*[@id=\"Username\"]")]
        private IWebElement Username { get; set; }

        //Click on Edit_Contact Button
        [FindsBy(How = How.XPath, Using = "//*[@id=\"EditContactButton\"]")]
        private IWebElement Edit_Contact { get; set; }

        //click on Password textbox
        [FindsBy(How = How.XPath, Using = "//*[@id=\"Password\"]")]
        private IWebElement Password { get; set; }

        //click on RetypePassword textbox
        [FindsBy(How = How.XPath, Using = " //*[@id=\"RetypePassword\"]")]
        private IWebElement RetypePassword { get; set; }

        //Click on IsAdmin CheckBox
        [FindsBy(How = How.Id, Using = "IsAdmin")]
        private IWebElement IsAdmin { get; set; }

        //CLick on Vehicle Dropdown list
        [FindsBy(How = How.XPath, Using = "//*[@id=\"UserEditForm\"]/div/div[7]/div/span[1]/span/span/span")]
        private IWebElement Vehicle { get; set; }

        //Click on Group MultiSelect List
        [FindsBy(How = How.XPath, Using = "//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]")]
        private IWebElement Group { get; set; }

        //Click on Save Button on Employee details page
        [FindsBy(How = How.XPath, Using = "//*[@id=\"SaveButton\"]")]
        private IWebElement Save_btn { get; set; }

        //Click on Back_to_List link
        [FindsBy(How = How.XPath, Using = "//*[@id=\"container\"]/div/a")]
        private IWebElement Back_to_list { get; set; }

        #endregion

        #region EditContact_Popup_WebElements
        /*======================================================*/

        //WebElements on Edit Contact Popup Window

        //click on FirstName textbox
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'FirstName')]")]
        private IWebElement FirstName { get; set; }

        //Click on LastName Textbox
        [FindsBy(How = How.XPath, Using = "//*[@id=\"LastName\"]")]
        private IWebElement LastName { get; set; }

        //Click on PreferedName
        [FindsBy(How = How.XPath, Using = "//*[@id=\"PreferedName\"]")]
        private IWebElement PreferedName { get; set; }

        //click on Phone textbox
        [FindsBy(How = How.XPath, Using = "//*[@id=\"Phone\"]")]
        private IWebElement Phone { get; set; }

        //click on Mobile textbox
        [FindsBy(How = How.XPath, Using = "//*[@id=\"Mobile\"]")]
        private IWebElement Mobile { get; set; }

        //click on Email Textbox
        [FindsBy(How = How.XPath, Using = "//*[@id=\"email\"]")]
        private IWebElement Email { get; set; }

        //click on Fax textbox
        [FindsBy(How = How.XPath, Using = "//*[@id=\"Fax\"]")]
        private IWebElement Fax { get; set; }

        //click on Street Textbox
        [FindsBy(How = How.XPath, Using = "//*[@id=\"Street\"]")]
        private IWebElement Street { get; set; }

        //click on City Textbox
        [FindsBy(How = How.XPath, Using = "//*[@id=\"City\"]")]
        private IWebElement City { get; set; }

        //Click on Postcode Textbox
        [FindsBy(How = How.XPath, Using = "//*[@id=\"Postcode\"]")]
        private IWebElement Postcode { get; set; }

        //Click on Country Textbox
        [FindsBy(How = How.XPath, Using = "//*[@id=\"Country\"]")]
        private IWebElement Country { get; set; }

        // Click on Save Contact button
        [FindsBy(How = How.XPath, Using = "//*[@id=\"submitButton\"]")]
        private IWebElement Save_Contact_btn { get; set; }

        // Click on Cross button on top right corner
        [FindsBy(How = How.XPath, Using = "/html/body/div[8]/div[1]/div/a/span")]
        private IWebElement Cross_btn { get; set; }
        #endregion

        #region Edit_button_Webelement
        //Click on Edit button on Admin>Employees page
        [FindsBy(How = How.XPath, Using = "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[1]/td[3]/a[1]")]
        private IWebElement Edit_btn { get; set; }
        #endregion

        #region Delete_button_Webelement

        //Click on Delete button on Admin>Employees page
        [FindsBy(How = How.XPath, Using = "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[1]/td[3]/a[2]")]
        private IWebElement Delete_btn { get; set; }
        #endregion

        #endregion

        //Method created to Navigate to Employees Page
        public void NavigateToEmployeesPage()
        {

            Administration_link.Click();
            Employee_Link.Click();
            Create_New_btn.Click();

        }

        #region Save Valid date in Edit Contact Popup
        //Method created for saving data in Edit Contact window
        public void SaveEditContactwithValidData()
        {
            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Employees");

            Driver.wait(2);
            // ClearAllFieldsOnEditContactForm();

            FirstName.SendKeys(ExcelLib.ReadData(10, "FirstName"));
            LastName.SendKeys(ExcelLib.ReadData(10, "LastName"));
            Phone.SendKeys(ExcelLib.ReadData(10, "Phone"));
            Email.SendKeys(ExcelLib.ReadData(10, "Email"));
            Street.SendKeys(ExcelLib.ReadData(10, "Street"));
            City.SendKeys(ExcelLib.ReadData(10, "City"));
            Postcode.SendKeys(ExcelLib.ReadData(10, "Post"));
            Country.SendKeys(ExcelLib.ReadData(10, "Country"));

            Driver.wait(2);


            try
            {  // Check if User is able to save
                Save_Contact_btn.Click();
                Driver.driver.SwitchTo().ParentFrame();
                Driver.wait(2);
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Save button clicked succesfully on Edit Contact Popup Window");
            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Unable to save Contact details on Edit Contact Popup Window");
            }
            try
            {
                //Check is Edit client window closes and control switches back to Create  New Employee Page
                IWebElement x = Driver.driver.FindElement(By.XPath("html/body/div[4]/h2"));
                string Page_title = x.Text;
                Console.WriteLine(Page_title);
                Assert.AreEqual("Employee Details", Page_title);
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Sucessully switched back to Page with EMPLOYEE DETAILS title");

            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Failed to navigate back to Page with EMPLOYEE DETAILS title ");
            }
            try
            {
                //Check if Edit contact/ Edit Billing Contact textfield is disabled and loaded with contact details



                // for Edit Contact Textfield
                IWebElement j = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[3]/div/input"));
                bool Txtbox_status = j.Enabled;
                Console.WriteLine(Txtbox_status);
                //string val = j.GetAttribute("value");
                //Console.WriteLine(j);

                Assert.AreEqual("False", Convert.ToString(Txtbox_status));
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Pass: Edit contact Textbox is disabled as it is populated by contact details");


            }
            catch (Exception e)
            {

                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Fail: Edit contact Textbox is still enabled and blank");
            }

        }
        #endregion

        public void Search_For_Record(string Input)
        {
            Driver.wait(2);
            Driver.driver.SwitchTo().DefaultContent();
            //IWebElement DrpDwn = Driver.driver.FindElement(By.XPath("html/body/div[4]/div/div/div[4]/span[1]/span/span/span[1]"));
            //DrpDwn.Click();
            //Driver.wait(2);
            //Driver.driver.FindElement(By.XPath("html/body/div[5]/div/ul/li[2]")).Click();
          
            Thread.Sleep(2000);

            //Declaring some  variables for For loop
            int j = 10; //Items per page
            int x;      //  Loop for pages
            int i = 0;
            string expected_val = null;  //   For Username we will be looking for ( From Excel)
            string actual_val = null;    //   For actual Username we will be getting from list

            bool next_Page = false;   

            for (x = 1; x <=10 ; x++) // for navigating through pages
            {
                for (i = 1; i <= j; i++)  // for items per page
                {
                    IWebElement Username = Driver.driver.FindElement(By.XPath("html/body/div[4]/div/div/div[3]/table/tbody/tr[" + i + "]/td[2]"));
                    expected_val = Username.Text;
                    // variable for Next Page button
                    next_Page = Driver.driver.FindElement(By.XPath("html/body/div[4]/div/div/div[4]/a[3]/span")).Enabled;

                   // Switch to read either valid or Invalid data for search record
                    switch (Input)
                    {
                        case"Valid":
                            actual_val = ExcelLib.ReadData(10, "UserName");
                            break;
                        case "Invalid":
                            actual_val = ExcelLib.ReadData(2, "UserName");
                            break;
                    }

                   
                    // just for fun 
                    Console.WriteLine(expected_val);

                    if (expected_val == actual_val)
                    {
                        Console.WriteLine("perfect Match", expected_val);
                        Console.WriteLine(next_Page);
                        //goto Out;
                        Console.WriteLine("Match hase been found");

                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Employees details have been added successfully");
                      
                        // if values match then break the Inner loop
                        break;
                    }

                    if (i== j) // click next page button only  when control is at the last record in the list
                    {
                        
                        Driver.driver.FindElement(By.XPath("html/body/div[4]/div/div/div[4]/a[3]/span")).Click();
                        Driver.wait(3);
                    }
                }

                if (expected_val == actual_val)
                {
                   // if values match then break the outer loop
                    break;
                }

            }
           // Out:
            //Console.WriteLine("Match hase been found");
            //Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Employees details have been added successfully");
        }

        #region Testcase-1  Create Employee with Valid Data
        public void AbleToCreateNewEmployeeWth_ValidData()
        {

            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Employees");
            NavigateToEmployeesPage();

            Driver.wait(2);

            Name.SendKeys(ExcelLib.ReadData(10, "Name"));

            Username.SendKeys(ExcelLib.ReadData(10, "UserName"));

            Edit_Contact.Click();

            Driver.driver.SwitchTo().Frame(Driver.driver.FindElement(By.TagName("iframe")));
            SaveEditContactwithValidData();

            Driver.wait(2);
            Driver.driver.SwitchTo().ParentFrame();

            Password.SendKeys(ExcelLib.ReadData(10, "Password"));

            RetypePassword.SendKeys(ExcelLib.ReadData(10, "Confirm Password"));
            Driver.wait(2);

            if (!IsAdmin.Selected)
            {
                Thread.Sleep(3000);
                IsAdmin.Click();
            }

            Save_btn.Click();
            Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Save button clicked after entering valid data");

            IWebElement title = Driver.driver.FindElement(By.XPath("html/body/div[4]/h2"));
            string page_title = title.Text;

            try
            {
                string URL = Driver.driver.Url;
                Console.WriteLine(URL);
                Assert.AreSame("http://52.65.131.15/User", URL);
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "User Navigated back to Administration>Employees Page");
            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Still on Create New Employee Page, Should navigate back to Administration>Employees Page");
                Back_to_list.Click();
            }

            try
            {
                Search_For_Record("Valid");
              
            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Employees details are not found in the list. Test Failed");
            }
        }

        #endregion

        #region Testcase-2 Create Employee with Invalid Data
        public void CreateEmployee_Wth_InvalidData()
        {

            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Employees");
            NavigateToEmployeesPage();

            Driver.wait(2);

            Name.SendKeys(ExcelLib.ReadData(2, "Name"));

            Username.SendKeys(ExcelLib.ReadData(2, "UserName"));

            Password.SendKeys(ExcelLib.ReadData(2, "Password"));

            RetypePassword.SendKeys(ExcelLib.ReadData(2, "Confirm Password"));
            Driver.wait(2);

            if (!IsAdmin.Selected)
            {
                Thread.Sleep(3000);
                IsAdmin.Click();
            }

            Save_btn.Click();

            // To check is user is still on the same page.
            try
            {
                IWebElement title = Driver.driver.FindElement(By.XPath("html/body/div[4]/h2"));
                string page_title = title.Text;
                Console.WriteLine(page_title);
                Assert.AreEqual("Employee Details", page_title);
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Still on Create new Employee Page, Details not added");

            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Navigated to a different page");
            }

            // To check if user is getting any error message on entering Invalid data
            try
            {
                IWebElement element = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[1]/div/span/span"));
                bool visible = element.Displayed;
                string actual_err = element.Text;
                string expected_err = ExcelLib.ReadData(2, "Error_messages");
                try
                {
                    if (visible == true)
                    {
                        Assert.AreEqual(expected_err, actual_err);
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Name Field: Correct error message displayed");
                    }
                }
                catch (Exception e)
                {
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Name Field: Incorrect error message displayed");
                }


            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Name Field: Error message missing");
            }

            // Validate error message for UserName Textfield
            try
            {
                IWebElement element = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[2]/div/span/span"));
                bool visible = element.Displayed;
                string actual_err = element.Text;
                string expected_err = ExcelLib.ReadData(3, "Error_messages");
                try
                {
                    if (visible == true)
                    {
                        Assert.AreEqual(expected_err, actual_err);
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "UserName Field: Correct error message displayed");
                    }
                }
                catch (Exception e)
                {
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "UserName Field: Incorrect error message displayed");
                }


            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "UserName Field: Error message missing");
            }


            // Validate error message for Password Textfield
            try
            {
                IWebElement element = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[4]/div/span/span"));
                bool visible = element.Displayed;
                string actual_err = element.Text;
                string expected_err = ExcelLib.ReadData(4, "Error_messages");
                try
                {
                    if (visible == true)
                    {
                        Assert.AreEqual(expected_err, actual_err);
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Password Field: Correct error message displayed");
                    }
                }
                catch (Exception e)
                {
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Password Field: Incorrect error message displayed");
                }


            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Password Field: Error message missing");
            }

            // Calling Search method to verify if invalid record  is created
            try
            {
                Search_For_Record("Invalid");
            }
            catch
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Invalid data Record Not Created");
            }
        }
            #endregion

 #region Testcase-3 Create Employee with Null Data

            public void Create_Employee_Wth_NullData()
        {

            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Employees");
            NavigateToEmployeesPage();
            Driver.wait(2);
            Save_btn.Click();

            // To check is user is still on the same page.
            try
            {
                IWebElement title = Driver.driver.FindElement(By.XPath("html/body/div[4]/h2"));
                string page_title = title.Text;
                Console.WriteLine(page_title);
                Assert.AreEqual("Employee Details", page_title);
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Still on Create new Employee Page, Details not added");

            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Navigated to a different page");
            }

            // To check if user is getting any error message on entering Invalid data
            try
            {
                IWebElement element = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[1]/div/span/span"));
                bool visible = element.Displayed;
                string actual_err = element.Text;
                string expected_err = ExcelLib.ReadData(2, "Null_data_error");
                try
                {
                    if (visible == true)
                    {
                        Assert.AreEqual(expected_err, actual_err);
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Name Field: Correct error message displayed");
                    }
                }
                catch (Exception e)
                {
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Name Field: Incorrect error message displayed");
                }


            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Name Field: Error message missing");
            }

            // Validate error message for UserName Textfield
            try
            {
                IWebElement element = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[2]/div/span/span"));
                bool visible = element.Displayed;
                string actual_err = element.Text;
                string expected_err = ExcelLib.ReadData(3, "Null_data_error");
                try
                {
                    if (visible == true)
                    {
                        Assert.AreEqual(expected_err, actual_err);
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "UserName Field: Correct error message displayed");
                    }
                }
                catch (Exception e)
                {
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "UserName Field: Incorrect error message displayed");
                }


            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "UserName Field: Error message missing");
            }


            // Validate error message for Password Textfield
            try
            {
                IWebElement element = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[4]/div/span/span"));
                bool visible = element.Displayed;
                string actual_err = element.Text;
                string expected_err = ExcelLib.ReadData(4, "Null_data_error");
                try
                {
                    if (visible == true)
                    {
                        Assert.AreEqual(expected_err, actual_err);
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Password Field: Correct error message displayed");
                    }
                }
                catch (Exception e)
                {
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Password Field: Incorrect error message displayed");
                }


            }
            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Password Field: Error message missing");
            }

        }

        #endregion

 #region Testcase-4 Verify Max characters length of textfields

        public void Verify_Max_Lngth()
        {
            ExcelLib.PopulateInCollection(Test.Base.ExcelPath, "Employees");
            int Name_length = 0;
            int Uname_length = 0;
            NavigateToEmployeesPage();

            try
            {
                string name = ExcelLib.ReadData(5, "Name");
                Name.SendKeys(name);
                string uname = ExcelLib.ReadData(5, "UserName");
                Username.SendKeys(uname);
                Name_length = name.Length;
                Uname_length = uname.Length;


                Driver.wait(2);
                Save_btn.Click();

                try
                {
                    if (Name_length > 30)
                    {
                        IWebElement Name_Err_Element = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[1]/div/span/span"));
                        bool IsErrorDisplayed = Name_Err_Element.Displayed;
                        string Actual_err_msge = Name_Err_Element.Text;
                        string Expctd_err_msge = ExcelLib.ReadData(2, "Verify_Lgth_err");
                        if (IsErrorDisplayed == true)
                        {

                            if (Actual_err_msge == Expctd_err_msge)
                            {
                                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Name should be in between 1-30 alphabetical characters");
                                Console.WriteLine("Name should be  in between 1-30 alphabetical characters");

                            }
                            else
                            {
                                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Incorrect Error message. It should be \"Name should be  in between 1-30 alphabetical characters\"");
                                Console.WriteLine("Name should be  in between 1-30 alphabetical characters");
                            }

                        }

                    }

                    else
                    {
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Name textfield accepts only 1-30 alphabetical characters");
                        Console.WriteLine("Test Pass");
                    }

                }


                catch (Exception e)
                {
                    string length = "No. of characters used is " + Convert.ToString(Name_length) + ".";
                    Console.WriteLine("Name characters Length is: {0}, No error message displayed", Name_length);
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                      "Test Fail : Name is longer than Maximum length, No error message displayed", length);


                }

                try
                {
                    if (Uname_length > 30)
                    {
                        IWebElement Uname_Err_Element = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[2]/div/span/span"));
                        bool IsErrorDisplayed = Uname_Err_Element.Displayed;
                        string Actual_err_msge = Uname_Err_Element.Text;
                        string Expctd_err_msge = ExcelLib.ReadData(3, "Verify_Lgth_err");
                        if (IsErrorDisplayed == true)
                        {

                            if (Actual_err_msge == Expctd_err_msge)
                            {
                                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, UserName should be in between 1-30 alphabetical characters");
                                Console.WriteLine("UserName should be  in between 1-30 alphabetical characters");

                            }
                            else
                            {
                                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Incorrect Error message. It should be \"UserName should be  in between 1-30 alphabetical characters\"");
                                Console.WriteLine("UserName should be  in between 1-30 alphabetical characters");
                            }

                        }

                    }

                    else
                    {
                        Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "UserName textfield accepts only 1-30 alphabetical characters");
                        Console.WriteLine("Test Pass");
                    }

                }


                catch (Exception e)
                {
                    string length = "No. of characters used is " + Convert.ToString(Uname_length) + ".";
                    Console.WriteLine("UserName characters Length is: {0}, No error message displayed", Uname_length);
                    Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail,
                      "Test Fail : UserName is longer than Maximum length, No error message displayed", length);


                }
            }
            catch(Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " Test failed due to unknown reasons. Please check defined variables and Webelements");
            }
                
        }

        #endregion


 #region Testcase-5 Check if user is able to select Vehicle from Drop Down list
        public void Create_Employee_Choose_Frm_VehicleDrpDwn()
        {
            NavigateToEmployeesPage();

           try
            {
                //Vehicle.Click();
                IWebElement Vehicles = Driver.driver.FindElement(By.Name("VehicleId_input"));
                SelectElement selectelements = new SelectElement(Vehicles);
                IList<IWebElement> options = selectelements.Options;
                int count = selectelements.Options.Count;
                Console.WriteLine(count);


            }

            catch (Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed: Unable to select vehicle from DropDown List. No data available in the List.");
            }

        }

        #endregion

 #region TEstcase-6 Check if user is able to select Group/Groups from GroupList and able to remove the selected Group
        public void Create_Employee_Choose_Frm_GroupList()
        {
            // Called method to Navigate to Create New Employee page
            NavigateToEmployeesPage();

            Driver.wait(2);

            //Checkif User is able to Type in Group Field
            try
            {
                Group.SendKeys("Tess");
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " Test Failed: User is able to type in Group field.");
            }
            catch(Exception e)
            {
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, " Test Passed: User is not able to type in Group field.");
            }


            Driver.wait(2);
            int i =0;   // for loop
            string[] value = new string[4]; // string array to save selected Groups from Group List
            string grp_selected = null;     // to get the value /text of selected Group fromList

            try
            {
                for (i = 1; i <= 3; i++) // Loop to select Multiple Groups from List
                {
                    Thread.Sleep(1000);
                    Group.Click();
                    Thread.Sleep(500);
                    // Below is the Locator and Path for Group from List to be selected
                    IWebElement Option = Driver.driver.FindElement(By.XPath("html/body/div[5]/div/ul/li[" + i + "]"));
                    value[i] = Option.Text;  // saving Group name in array
                    Option.Click();
                    Console.Write("Option Selected is :{0}", value[i]);

                }
                grp_selected = Group.Text;
                Console.Write(grp_selected);
                //COmparing  expexcted and actual result
                Assert.AreEqual("nulldelete\r\nnulldelete\r\nddelete", grp_selected);
                //Log in report
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, 
                    "Test Passed: User is able to select Multiple Groups.", grp_selected);

            }
            catch(Exception e )
            {
                //Log in report
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed: Unable to select Multiple Groups.", grp_selected);
            }


            //SelectElement Elements = new SelectElement(Driver.driver.FindElement(By.Id("groupList")));
            //IList<IWebElement> options = Elements.Options;
            //Console.WriteLine(options.Count);
            try
            {
                IWebElement remove_grp1 = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[8]/div/div/div[1]/ul/li[1]/span[2]"));
                IWebElement remove_grp2 = Driver.driver.FindElement(By.XPath("html/body/div[4]/form/div/div[8]/div/div/div[1]/ul/li[2]/span[2]"));
                remove_grp1.Click();  // Removing selected Groups from Group field
                remove_grp2.Click();
                grp_selected = Group.Text;
                Console.Write(grp_selected);
                Assert.AreEqual("ddelete", grp_selected);  // comparing expected and actual result
                //Log in report
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, 
                    "Test Passed: User is able to remove selected Groups from List.");
            }
            catch(Exception e)
            {
                //Log in report
                Test.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed: User is unable to remove selected Groups from List.");
            }
            

        }  
        
        #endregion
    }



}


