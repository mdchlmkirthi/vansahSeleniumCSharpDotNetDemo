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
        private String testFolderID = "cb1a7eb2-6499-11ed-8e52-5658ef8eadd5"; //TestFolder ID to which test Execution is to be perform

        //Optional if TestFolder ID is provided
        private String issueKey = "DEMO-1"; //IssueKey to which test Execution is to be perform

        //Optional 
        private String sprintName = "VAN Sprint 1"; //Sprint Name for current sprint for which test execution is to be perform

        //Optional
        private String releaseName = "v1"; //Release Name linked with the current sprint and to the test case.

        //Optional
        private String environment = "UAT"; //Environment Name to which test execution of a test case is to be perform

        //Required
        private static String testCase = "DEMO-C1";

        [SetUp]
        public void Setup()
        {
           // driver = new ChromeDriver("D:\\VSCode\\VansahSeleniumCSharpDemo\\bin\\Debug\\net6.0");
          
            //Provide TestFolder ID , JIRA Issue
            testExecute = new VansahNode(testFolderID, issueKey);
            //Set Environment Test Property
            testExecute.SetENVIRONMENT_NAME(environment);
        }

        [Test]
        public void Test1()
        {
            //Test Case started 
            //Creating Test Run Identifer
            //Running Test Case for an Issue
            testExecute.AddQuickTestFromTestFolders(testCase,1);
            
            //System.out.println("Test Steps Count " + testExecute.testStepCount(testCase));
           // driver.Url = "https://vansah.com";
           // driver.Manage().Window.Maximize();
            

            //System.out.print(Screenshot.TRUE.takeScreenshot);

            //testExecute test step #1 , User should be able to open the vansah.com
          
           // if (driver.Url.Equals("https://vansah.com/"))
            //{

                //0 = N/A, 1 = FAILED, 2 = PASSED, 3 = UNTESTED
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
             //   testExecute.AddTestLog((int)Result.PASSED, "As expected, Url is opened", (int)TestStep.Step_1, false, driver);

           // }
           // else
           // {

                //0 = N/A, 1 = FAILED, 2 = PASSED, 3 = UNTESTED
                //Add logs for each step function(ResultID, AcutalResultComment, TestStepID, screenshotTrueorFalse, chromedriver/OtherBroswerdriver);
            //    testExecute.AddTestLog((int)Result.FAILED, "URL not Found", (int)TestStep.Step_1,false , driver);
           // }
            
        }
    }
}