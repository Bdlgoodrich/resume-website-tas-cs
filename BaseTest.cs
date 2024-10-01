using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        protected void StartDriver(string browserVersion = "stable")
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments([
                "--disable-popup-blocking",
                "--disable-notifications",
                "--disable-search-engine-choice-screen",
                "--disable-features=OptimizationGuideModelDownloading,OptimizationHintsFetching,OptimizationTargetPrediction,OptimizationHints",
                "--headless=new"]);
            driver = new ChromeDriver(chromeOptions);
        }

    }
}