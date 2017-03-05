using Horse1.Global;
using Horse1.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Horse1.Test
{
   
    //[TestFixture]
    public  abstract class Base
    {

        #region To access Path from resource file

        public static int Browser = Int32.Parse(HorseResource.Browser);
        public static String ExcelPath = HorseResource.ExcelPath;
        public static string ScreenshotPath = HorseResource.ScreenShotPath;
        public static string ReportPath = HorseResource.ReportPath;
        //#endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;

             
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {
                case 1:
                    Driver.driver = new FirefoxDriver();
                    break;
                case 2:
                    Driver.driver = new ChromeDriver();
                    break;

            }
            if(HorseResource.IsLogin=="true")
            {
                Login loginobj = new Login();
                loginobj.LoginSuccessfull();
            }
        else
            {
                Register obj = new Register();
                obj.Navigateregister();
            }

            extent = new ExtentReports(ReportPath, true, DisplayOrder.NewestFirst);
            extent.LoadConfig(HorseResource.ReportXMLPath);
        }

            
             [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :           
            Driver.driver.Close();
        }
        #endregion
    }
}

#endregion