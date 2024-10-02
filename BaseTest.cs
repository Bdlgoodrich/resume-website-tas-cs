using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTest
{
    [TestFixture]
    public class BaseTest
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        protected IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        protected IWebDriver StartDriver(string browserVersion = "stable")
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments([
                "--disable-popup-blocking"
                , "--disable-notifications"
                , "--disable-search-engine-choice-screen"
                , "--disable-features=OptimizationGuideModelDownloading,OptimizationHintsFetching,OptimizationTargetPrediction,OptimizationHints"
                //, "--headless=new"
                ]);
            return driver = new ChromeDriver(chromeOptions);
        }

        // [SetUp]
        // public void Setup()

        // {
        //     driver = StartDriver();

        //     HomePage home = new(driver);
        //     home.GoToUrl();
        // }

        // [TearDown]

        // public void TearDown()

        // {
        //     driver.Quit();
        // }
    }
}