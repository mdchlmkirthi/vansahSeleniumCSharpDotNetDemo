using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
        private static IWebDriver driver;  // Required if screenshot is needed

        //Required
        private VansahNode testExecute;

        //Optional if IssueKey is provided
        private static String testFolderID = "1ba1372f-54ed-11ed-8e52-5658ef8eadd5"; //TestFolder ID to which test Execution is to be perform

        //Optional if TestFolder ID is provided
        private static String issueKey = "VAN-1"; //IssueKey to which test Execution is to be perform

        //Optional 
        private static String sprintName = "VAN Sprint 1"; //Sprint Name for current sprint for which test execution is to be perform

        //Optional
        private static String releaseName = "v1"; //Release Name linked with the current sprint and to the test case.

        //Optional
        private static String environment = "SYS"; //Environment Name to which test execution of a test case is to be perform

        //Required
        private static String testCase = "VAN-C3";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("D:\\VSCode\\VansahSeleniumCSharpDemo\\bin\\Debug\\net6.0");
            driver.Manage().Window.Maximize();
            //Provide TestFolder ID , JIRA Issue, Sprint Key, Sprint Release and Environment
            testExecute = new VansahNode(testFolderID, issueKey, sprintName, releaseName, environment);
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
           
            if (driver.Url.Equals("https://vansah.com//"))
            {

                //0 = N/A, 1 = FAILED, 2 = PASSED, 3 = UNTESTED
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog((int)Result.PASSED, "As expected, Url is opened", (int)TestStep.Step_1, true, driver);

            }
            else
            {

                //0 = N/A, 1 = FAILED, 2 = PASSED, 3 = UNTESTED
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
                testExecute.AddTestLog((int)Result.FAILED, "URL not Found", (int)TestStep.Step_1,true , driver);
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
           

            String winHandleBefore = driver.CurrentWindowHandle;

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
                testExecute.AddTestLog((int)Result.PASSED, "As expected, url is matched", (int)TestStep.Step_3,true, driver);

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