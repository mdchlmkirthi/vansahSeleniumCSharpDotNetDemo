using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.Json.Nodes;
using Vansah;

namespace VansahSeleniumCSharpDemo
{
    enum Result
    {
        PASSED = 2,
        FAILED = 1
     }

    enum TestStep
    {
        Step_1 = 1,
        Step_2 = 2,
        Step_3 = 3,
        Step_4 = 4

    }
    public class Tests
    {
        //Required
        public IWebDriver driver;  // Required if screenshot is needed

        //Required
        private VansahNode testExecute;

        //Optional if IssueKey is provided
        private string testFolderID = "cb1a7eb2-6499-11ed-8e52-5658ef8eadd5"; //TestFolder ID to which test Execution is to be perform

        //Optional if TestFolder ID is provided
        private string issueKey = "DEMO-1"; //IssueKey to which test Execution is to be perform

        //Optional 
        private string sprintName = "VAN Sprint 1"; //Sprint Name for current sprint for which test execution is to be perform

        //Optional
        private string releaseName = "v1"; //Release Name linked with the current sprint and to the test case.

        //Optional
        private string environment = "UAT"; //Environment Name to which test execution of a test case is to be perform

        //Required
        private static string testCase = "DEMO-C1";

        [SetUp]
        public void Setup()
        {
           driver = new ChromeDriver("D:\\VSCode\\VansahSeleniumCSharpDemo\\bin\\Debug\\net6.0");
          
            //Provide TestFolder ID , JIRA Issue
            testExecute = new VansahNode();
            testExecute.SetJIRA_ISSUE_KEY(issueKey);
            //Set Environment Test Property
            testExecute.SetENVIRONMENT_NAME(environment);
        }

        [Test]
        public void Test1()
        {
            //Test Case started 
            //Creating Test Run Identifer
            //Running Test Case for an Issue
            testExecute.AddTestRunFromJiraIssue(testCase);
            
            //System.out.println("Test Steps Count " + testExecute.testStepCount(testCase));
            driver.Url = "https://vansah.com";
            driver.Manage().Window.Maximize();
            

            //System.out.print(Screenshot.TRUE.takeScreenshot);

            //testExecute test step #1 , User should be able to open the vansah.com
          
            if (driver.Url.Equals("https://vansah.com/"))
           {

                //0 = N/A, 1 = FAILED, 2 = PASSED, 3 = UNTESTED
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
              testExecute.AddTestLog((int)Result.PASSED, "As expected, Url is opened", (int)TestStep.Step_1, false, driver);

            }
            else
            {

                //0 = N/A, 1 = FAILED, 2 = PASSED, 3 = UNTESTED
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
               testExecute.AddTestLog((int)Result.FAILED, "URL not Found", (int)TestStep.Step_1,false , driver);
            }
            //testExecute test step #2 , Title of the page should matched with "Vansah | Jira Test Management App"
            if (driver.Title.Equals("Vansah | Jira Test Management App"))
            {

                //0 = N/A, 1 = FAILED, 2 = PASSED, 3 = UNTESTED
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog((int)Result.PASSED, "As expected, title is matched", (int)TestStep.Step_2, true, driver);

            }
            else
            {
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog((int)Result.FAILED, "Title is not matched", (int)TestStep.Step_2, true, driver);
            }




            // Store the current window handle


            string winHandleBefore = driver.CurrentWindowHandle;

            //Clicking on TRY NOW button
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"slider-7-slide-8-layer-10\"]"));
            element.Click();

            // Perform the click operation that opens new window

            // Switch to new window opened
            var newWindowHandle = driver.WindowHandles[1];
            Assert.IsTrue(!string.IsNullOrEmpty(newWindowHandle));
            driver.SwitchTo().Window(newWindowHandle);
            // Perform the actions on new window

            // Continue with original browser (first window)

            //testExecute test step #3 , URL of new window"
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // wait.Until(ExpectedConditions.UrlToBe("https://marketplace.atlassian.com/apps/1224250/vansah-test-management-for-jira?tab=overview&hosting=cloud"));


            if (driver.Url.Equals("https://marketplace.atlassian.com/apps/1224250/vansah-test-management-for-jira?tab=overview&hosting=cloud/"))
            {

                //0 = N/A, 1 = FAILED, 2 = PASSED, 3 = UNTESTED
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog((int)Result.PASSED, "As expected, url is matched", (int)TestStep.Step_3, true, driver);

            }
            else
            {

                //0 = N/A, 1 = FAILED, 2 = PASSED, 3 = UNTESTED
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog((int)Result.FAILED, "Url is not matched", (int)TestStep.Step_3, true, driver);
            }

        }
    }
}