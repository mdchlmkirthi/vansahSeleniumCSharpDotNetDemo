using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Vansah;

namespace VansahSeleniumCSharpDemo
{

    public class Tests
    {

        //******************************************* Required ********************************************************************//
        public IWebDriver driver;
        private VansahNode testExecute;
        private static string testCase;
        private string issueKey;

        //******************************************* Test Properties - Optional **************************************************//
        private string sprintName;
        private string releaseName;
        private string environment;

   

        [SetUp]
        public void Setup()
        {

            //******************************* Create Instance for VansahNode *******************************************************//
            testExecute = new VansahNode();

        }

        [Test]
        //***************************** Adding Quick Test for a TestCase From an Issue  *********************************************//
        public void VAN_C15() 
        {

            //*********************************  Assigning Values to Variables ********************************************************//
            testCase     = "VAN-C15";
            issueKey     = "VAN-5";
            environment  = "UAT";

            //*********************************** Setting Asset & Test Properties **************************************************//
            testExecute.SetJira_Issue_Key(issueKey);
            testExecute.SetEnvironment_Name(environment);

            //********************************** Function For Add Quick Test From Jira Issue **************************************//
            testExecute.AddQuickTestFromJiraIssue(testCase, "failed");

        }


        [Test]
        //***************************** Adding Quick Test for a TestCase From an Issue and Remove Test run  ***********************//
        public void VAN_C17() 
        {
            //********************************* Assigning Values to Variables *****************************************************//
            testCase     = "VAN-C17";
            issueKey     = "VAN-5";
            environment  = "UAT";

            //*********************************** Setting Asset & Test Properties ************************************************//
            testExecute.SetJira_Issue_Key(issueKey);
            testExecute.SetEnvironment_Name(environment);

            //********************************** Function To Add Quick Test From Jira Issue **************************************//
            testExecute.AddQuickTestFromJiraIssue(testCase, "passed");

            //********************************** Function To Remove Current Test Run *********************************************//
            testExecute.RemoveTestRun();

        }

        [Test]
        //***************************** Sample TestCase - Validating Selenium Vansah Webpage  *************************************//
        //***************************** Adding TestRun, Adding TestLog, Update TestLog  *******************************************//
        public void VAN_C23() 
        {

            //*************************** Creating Instance for ChromeDriver ******************************************************//
            driver = new ChromeDriver(System.IO.Directory.GetCurrentDirectory());

            //********************************* Assigning Values to Variables ******************************************************//
            testCase    = "VAN-C23";
            issueKey    = "VAN-5";
            environment = "UAT";

            //*********************************** Setting Asset & Test Properties *************************************************//
            testExecute.SetJira_Issue_Key(issueKey);
            testExecute.SetEnvironment_Name(environment);

            //**************************Function For Adding Test run from Jira Issue *********************************************//
            testExecute.AddTestRunFromJiraIssue(testCase);

            //************************* Test Case Started, Validating Selenium Vansah Webpage ***********************************//
            driver.Url = "https://selenium.vansah.io/";
            driver.Manage().Window.Maximize();


            //*********************Test step #1, Check whether User able to open the vansah.com ********************************//
            //************************************ Function to Add Test Log  ***************************************************//
            if (driver.Url.Equals("https://selenium.vansah.io/"))
            {
                //ResultName - n/a, failed, passed, untested
                //Add logs for each step function(ResultName, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("passed", "As expected, Url is opened", 1, true, driver);

            }
            else
            {
                //ResultName - n/a, failed, passed, untested
                //Add logs for each step function(ResultName, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("failed", "URL not Found", 1, true, driver);

            }


            //**************************** Clicking on TRY NOW button ***************************************************************//
            IWebElement element = driver.FindElement(By.XPath("//*[text()='Try Now']"));
            element.Click();


            //************************* Test step #2 , Validating URL of MarketPlace ***********************************************//
            if (driver.Url.Equals("https://marketplace.atlassian.com/apps/1224250/vansah-test-management-for-jira?tab=overview&hosting=cloud"))
            {
                //ResultName - n/a, failed, passed, untested
                //Add logs for each step function(ResultName, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("passed", "As expected, url is matched", 2, true, driver);
            }
            else
            {
                //ResultName - n/a, failed, passed, untested
                //Add logs for each step function(ResultName, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("failed", "Url is not matched", 2, true, driver);

            }

            //************************** Function to Update Current/Last Test Log ************************************************//
             testExecute.UpdateTestLog("N/A", "Step Not in Scope", false, driver);
           
            //**************************** Terminating the driver instance ********************************************************//
             driver.Quit();

        }

    }
    }
