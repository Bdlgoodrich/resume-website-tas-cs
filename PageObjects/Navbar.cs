using OpenQA.Selenium;

namespace NUnitTest.PageObjects;

public class Navbar : Utilities
{
    public Navbar(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }

    //WebElement By locators
    private readonly By navbar = By.Id("navbar");
    private readonly By navbarResumeLink = By.Id("navbarResumeLink");

    private By ConvertToBy(string name)
    {
        return By.Id("navbar" + name + "Link");
    }

    public bool NavbarIsVisible()
    {
        return driver.FindElement(navbar).Displayed;
    }

    public void ClickNavbarLinkByName(string name)
    {
        By link = ConvertToBy(name);
        WaitForElementToBeClickable(link);
        driver.FindElement(link).Click();
        Thread.Sleep(1000);
    }

    public void ClickNavbarResumeLink()
    {
        driver.FindElement(navbarResumeLink).Click();
    }

    public double FetchNavbarLinkExpectedLocation(string name)
    {
        if (name == "Title") return 0;
        By link = ConvertToBy(name);
        return FetchElementPosition(link);
    }
}