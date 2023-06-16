using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Vansah;

namespace VansahSeleniumCSharpDemo
{

    public class Tests
    {
        //Required
        public IWebDriver driver;  // Required if screenshot is needed

        //Required
        private VansahNode testExecute;

        //Optional if IssueKey is provided
        private string testFolderID = "b97fe80b-0b6a-11ee-8e52-5658ef8eadd5"; //TestFolder ID to which test Execution is to be perform

        //Optional if TestFolder ID is provided
        private string issueKey = "Test-1"; //IssueKey to which test Execution is to be perform

        //Optional 
        private string sprintName = "TEST Sprint 1"; //Sprint Name for current sprint for which test execution is to be perform

        //Optional
        //private string releaseName = "v1"; //Release Name linked with the current sprint and to the test case.

        //Optional
        private string environment = "UAT"; //Environment Name to which test execution of a test case is to be perform

        //Required
        private static string testCase = "Test-C1";

        [SetUp]
        public void Setup()
        {
            
            //Create Instance
            testExecute = new VansahNode();

            //Provide your JIRA Issue Key
            testExecute.SetJira_Issue_Key(issueKey);

            //Provide your TestFolder ID
            testExecute.SetTestFolders_Id(testFolderID);

            //Set Environment Test Property
            testExecute.SetEnvironment_Name(environment);

            //Set Sprint Name
            testExecute.SetSprint_Name(sprintName);
        }

        [Test]
        public void Test1() //Running Test Case for an Issue
        {
            //Instance of ChromeDriver
            driver = new ChromeDriver(System.IO.Directory.GetCurrentDirectory());

            //Test Case started 
            //Creating Test Run Identifer and Running Test Case for an Issue
            testExecute.AddTestRunFromJiraIssue(testCase);

            //System.out.println("Test Steps Count " + testExecute.testStepCount(testCase));
            driver.Url = "https://selenium.vansah.io/";
            driver.Manage().Window.Maximize();


            //System.out.print(Screenshot.TRUE.takeScreenshot);

            //testExecute test step #1 , User should be able to open the vansah.com

            if (driver.Url.Equals("https://selenium.vansah.io/"))
            {

                //n/a, failed, passed, untested
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("passed", "As expected, Url is opened", 1, true, driver);


            }
            else
            {

                //n/a, failed, passed, untested
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("failed", "URL not Found", 1, true, driver);

            }


            //Clicking on TRY NOW button
            IWebElement element = driver.FindElement(By.XPath("//*[text()='Try Now']"));
            element.Click();


            //testExecute test step #2 , URL of MarketPlace"

            if (driver.Url.Equals("https://marketplace.atlassian.com/apps/1224250/vansah-test-management-for-jira?tab=overview&hosting=cloud/"))
            {

                //n/a, failed, passed, untested
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("PASSED", "As expected, url is matched", 2, true, driver);


            }
            else
            {

                //n/a, failed, passed, untested
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("FAILED", "Url is not matched", 2, true, driver);

            }
            //testExecute.RemoveTestLog();
            //testExecute.RemoveTestRun();
            driver.Quit();

        }
        [Test]
        public void Test2() //Running Test Case for TestFolder
        {   
            //Instance of ChromeDriver
            driver = new ChromeDriver(System.IO.Directory.GetCurrentDirectory());

            //Test Case started 
            //Creating Test Run Identifer and Running Test Case for an TestFolder
            testExecute.AddTestRunFromTestFolder(testCase);

            //System.out.println("Test Steps Count " + testExecute.testStepCount(testCase));
            driver.Url = "https://selenium.vansah.io/";
            driver.Manage().Window.Maximize();


            //System.out.print(Screenshot.TRUE.takeScreenshot);

            //testExecute test step #1 , User should be able to open the vansah.com

            if (driver.Url.Equals("https://selenium.vansah.io/"))
            {

                //n/a, failed, passed, untested
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("passed", "As expected, Url is opened", 1, true, driver);


            }
            else
            {

                //n/a, failed, passed, untested
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("failed", "URL not Found", 1, true, driver);

            }


            //Clicking on TRY NOW button
            IWebElement element = driver.FindElement(By.XPath("//*[text()='Try Now']"));
            element.Click();


            //testExecute test step #2 , URL of MarketPlace"

            if (driver.Url.Equals("https://marketplace.atlassian.com/apps/1224250/vansah-test-management-for-jira?tab=overview&hosting=cloud/"))
            {

                //n/a, failed, passed, untested
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("PASSED", "As expected, url is matched", 2, true, driver);


            }
            else
            {

                //n/a, failed, passed, untested
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog("FAILED", "Url is not matched", 2, true, driver);

            }
            //testExecute.RemoveTestLog();
            //testExecute.RemoveTestRun();
            driver.Quit();

        }
        [Test]
        public void Test3() //Adding Quick Test for a TestCase From an Issue
        {

            testExecute.AddQuickTestFromJiraIssue(testCase, "n/a");



        }
        [Test]
        public void Test4() //Adding Quick Test for a TestCase From a TestFolder
        {

            testExecute.AddQuickTestFromTestFolders(testCase, "untested");



        }
    }
    }
