using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NUnitTest.PageObjects;

public class Utilities
{
    public IWebDriver driver;

    public Utilities(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void ScrollToElement(By element)
    {
        WaitForElementToExist(element);
        var js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(element));
        Thread.Sleep(1000);
    }

    public void WaitForElementToBeVisible(By element)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(d => driver.FindElement(element).Displayed);
    }

    public void WaitForElementToExist(By element)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.ElementExists(element));
    }

    public void WaitForElementToBeClickable(By element)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
    }

    public void WaitForNewPageToLoad(string title)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.TitleContains(title));
    }

    public void SwitchToNewWindow(string title)
    {
        IList<string> windowHandles = new List<string>(driver.WindowHandles);
        if (windowHandles.Count > 1)
        {
            driver.SwitchTo().Window(windowHandles[1]);
        }
        else Assert.Fail("No new window found");

        WaitForNewPageToLoad(title);
    }

    //returns String of broken link names and response codes OR "No broken Links."
    // public String LinksUnbroken(IReadOnlyList<IWebElement> links)
    // {

    //     Boolean linksUnbroken = true;
    //     System.Text.StringBuilder brokenLinks = new();
    //     foreach (WebElement link in links)
    //     {
    //         String url = link.GetDomAttribute("href");
    //         HttpURLConnection conn = (HttpURLConnection)new URI(url).toURL().openConnection();
    //         conn.setRequestMethod("HEAD");
    //         conn.connect();
    //         int respCode = conn.getResponseCode();
    //         if (conn.getResponseCode() < 400)
    //         {
    //             linksUnbroken = false;
    //             brokenLinks.Append("The link with Text").Append(link.GetAttribute("text")).Append(" is broken with code").Append(respCode).Append(". ");
    //         }
    //     }
    //     if (linksUnbroken) brokenLinks.Append("No broken links.");
    //     return brokenLinks.ToString();
    // }

    public double FetchElementPosition(By element)
    {
        ScrollToElement(element);
        return FetchCurrentPosition();
    }

    public double FetchCurrentPosition()
    {
        var js = (IJavaScriptExecutor)driver;
        string position = js.ExecuteScript("return window.pageYOffset;").ToString() ?? "0";
        double result = double.Parse(position);
        return Math.Floor(result);
    }
}