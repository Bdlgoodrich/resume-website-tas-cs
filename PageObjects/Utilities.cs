using System.Net.Http.Headers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class Utilities
{
    protected IWebDriver driver;

    public Utilities(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void ActionClick(By element)
    {
        ScrollToElement(element);
        IWebElement webElement = driver.FindElement(element);
        new Actions(driver).MoveToElement(webElement).Click(webElement).Build().Perform();
    }

    public void AcceptAlert()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

        //Store the alert text in a variable
        string text = alert.Text;

        //Press the OK button
        alert.Accept();
    }

    public void ScrollToElement(By element)
    {
        WaitForElementToExist(element);
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(element));
        Thread.Sleep(1000);
    }

    public void ScrollToTop()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        js.ExecuteScript("window.scrollTop");
        Thread.Sleep(1000);
    }

    public void ScrollToBottom()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        Thread.Sleep(1000);
    }

    public void WaitForElementToBeVisible(By element)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(d => driver.FindElement(element).Displayed);
    }

    public void WaitForElementToExist(By element)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.ElementExists(element));
    }

    public void WaitForElementToBeClickable(By element)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.ElementToBeClickable(element));        
    }

    public void WaitForNewPageToLoad(String title)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.TitleContains(title));
    }

    public void SwitchToNewWindow(String title)
    {
        IList<string> windowHandles = new List<string>(driver.WindowHandles);
        if (windowHandles.Count > 1) {driver.SwitchTo().Window(windowHandles[1]);}
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
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        string position = js.ExecuteScript("return window.pageYOffset;").ToString();
        double result = double.Parse(position);
        return Math.Floor(result);
        
    }
}