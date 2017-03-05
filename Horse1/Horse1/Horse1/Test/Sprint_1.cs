using Horse1.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse1.Test
{
    class Sprint_1
    {
        [TestFixture]
        [Category("Sprint_1")]
        class Sprint_1_Administration : Base
        {
            // Add a new user in the Account Managment
            //[Test]
            //public void Navigate_to_EmployeesPage()
            //{
            //    // creates a toggle for the given test, adds all log events under it    
            //    test = extent.StartTest("Add Customer using Valid Data");//, "Getting the values from excel");// Creating an instance
            //    var Employees_obj = new Administration_Employees();
            //    Employees_obj.NavigateToEmployeesPage();
            //    Employees_obj.Edit_Contact_Window();

            //  }

            [Test]
            public void Admin_Cust_EdtRecord_Wth_NullData()
            {
                test = extent.StartTest("Edit Customer Contact data with Null data");
                var editCustData_obj = new Administration_Customer();
                editCustData_obj.EditContactWithNullData();
              
            }

            [Test]
            public void Admin_Cust_EdtRecord_Wth_InvalidData()
            {
                test = extent.StartTest("Edit Customer Contact data with Invalid data in Mandatory Textfields");
                var editCustInvalData_obj = new Administration_Customer();
                editCustInvalData_obj.EditContactWithInvalidData("EditContact");
               
            }

            [Test]
            public void Admin_Cust_Save_EditRecord_Wthout_Changes()
            {
                test = extent.StartTest("Click Edit button on Admin>Customer page and save without making any changes");
                var save_wthout_change_obj = new Administration_Customer();
                save_wthout_change_obj.ClicknSave_Wthout_Changes();
            }

            [Test]
            public void Verify_Max_Min_Lth_Phn_Field()
            {
                test = extent.StartTest("Click Edit button on Admin>Verify Minimum & Maximum lenght for Phone Textfield");
                var verify_Phn_Txtfld_lgth_obj = new Administration_Customer();
                verify_Phn_Txtfld_lgth_obj.Verify_Max_Lth_Phn_Fld("EditContact");
            }
            [Test]
            public void Save_Edit_Contact_wth_Valid_Data()
            {
                test = extent.StartTest("Click Edit button on Admin>Customer page and save with Valid Data in all Mandatory fields");
                var Save_Edit_Contact_obj = new Administration_Customer();
                Save_Edit_Contact_obj.SaveEditContactwithValidData("EditContact");

            }
            [Test]
            public void Admin_Cust_Edt_EditBillingRecord_Wth_InvalidData()
            {
                test = extent.StartTest("Click Edit Button on Admin>Customers - Edit Billing Contact data with Invalid data in Mandatory Textfields");
                var edit_billing_obj = new Administration_Customer();
                edit_billing_obj.EditBillingRecWithInvalidData();
            }

            [Test]
            public void EditBilling_Vrfy_lgth_Phonetxtfld()
            {
                test = extent.StartTest(" Admin>Customers>click Edit Button>EditBilling Contact button:  Verify Minimum & Maximum lenght for Phone Textfield on Edit Billing Contact window");
                var verify_Phn_Txtfld_lgth_obj = new Administration_Customer();
                verify_Phn_Txtfld_lgth_obj.Verify_Max_Lth_Phn_Fld_EditBilling();
                
            }
            [Test]
            public void EditBilling_Save_With_ValidData()
            {
                test = extent.StartTest("Navigate to Admin>Customers>Click Edit> Click Edit Billing Contact : Save with Valid Data in all Mandatory fields");
                var Save_Edit_Contact_obj = new Administration_Customer();
                Save_Edit_Contact_obj.EditBilling_Save_Wth_ValidData();

            }

            [Test]
            public void Create_Employee_Wth_ValidData()
            {
                test = extent.StartTest("Test Start: Create New Employees Record with valid data in all mandatory fields");
                var Save_Wth_Vld_Data_obj = new Administration_Employees();
                Save_Wth_Vld_Data_obj.AbleToCreateNewEmployeeWth_ValidData();
            }

            [Test]
            public void Create_Employee_Wth_InvalidData()
            {
                test = extent.StartTest("Test Start: Create New Employees Record with Invalid data in all mandatory fields");
                var Save_Wth_Invalid_Data_obj = new Administration_Employees();
                Save_Wth_Invalid_Data_obj.CreateEmployee_Wth_InvalidData();
            }
       
            [Test]
            public void Create_Employee_Wth_NullData()
            {
                test = extent.StartTest("Test Start: Create New Employees Record with Null data in all mandatory fields");
                var Save_Wth_Null_Data_obj = new Administration_Employees();
                Save_Wth_Null_Data_obj.Create_Employee_Wth_NullData();
            }

            [Test]
            public void Create_Employee_Verify_Max_Lgth()
            {
                test = extent.StartTest("Test Start: Verify Min & Max characters length of Name & UserName Fields on Create Employees Page");
                var Verify_Lngth_obj = new Administration_Employees();
                Verify_Lngth_obj.Verify_Max_Lngth();
            }

            [Test]
            public void Create_Employee_Choose_Frm_VehicleDrpDwn()
            {
                test = extent.StartTest("Test Start: Check if user is able to select Vehicle from Drop Down list");
                var Choose_Frm_DrpDwn = new Administration_Employees();
                Choose_Frm_DrpDwn.Create_Employee_Choose_Frm_VehicleDrpDwn();
             
            }

            [Test]
            public void Create_Employee_Choose_Frm_GroupList()
            {
                test = extent.StartTest("Test Start: Check if user is able to select select and remove from Group list");
                var Choose_Frm_GroupList = new Administration_Employees();
                Choose_Frm_GroupList.Create_Employee_Choose_Frm_GroupList();
         

            }
        }
    }
}
