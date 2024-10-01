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

    public void ActionClick(WebElement element)
    {
        ScrollToElement(element);
        new Actions(driver).MoveToElement(element).Click(element).Build().Perform();
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

    public void ScrollToElement(WebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", element);

    }

        public void ScrollToByElement(By element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(element));

    }

    public void ScrollToTop()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        js.ExecuteScript("window.scrollTop");
    }

    public void ScrollToBottom()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
    }

    public void WaitForElementVisible(WebElement element)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(d => element.Displayed);
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

    public double fetchElementPosition(WebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        ScrollToElement(element);
        return (double)js.ExecuteScript("return window.pageYOffset;");
    }
}