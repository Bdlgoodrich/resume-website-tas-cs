using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTest.Tests
{
    [TestFixture]
    public class BaseTest
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        protected new IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        protected IWebDriver StartDriverHeaded(string browserVersion = "stable")
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments([
                "--disable-popup-blocking", "--disable-notifications", "--disable-search-engine-choice-screen",
                "--disable-features=OptimizationGuideModelDownloading,OptimizationHintsFetching,OptimizationTargetPrediction,OptimizationHints",
            ]);
            return driver = new ChromeDriver(chromeOptions);
        }
        
        protected IWebDriver StartDriver(string browserVersion = "stable")
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments([
                "--disable-popup-blocking", "--disable-notifications", "--disable-search-engine-choice-screen",
                "--disable-features=OptimizationGuideModelDownloading,OptimizationHintsFetching,OptimizationTargetPrediction,OptimizationHints",
                "--headless=new"
            ]);
            return driver = new ChromeDriver(chromeOptions);
        }
    }
}