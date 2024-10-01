    using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Navbar : Utilities
{
    public Navbar(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }
    
        //WebElement By locators
    private readonly By navbar = By.Id("navBar");    
    
    //Navbar locators by hand, also built method to get all navbar links
    private readonly By navbarTitleLink = By.Id("navbarTitleLink");
    private readonly By navbarIntroLink = By.Id("navbarIntroLink");
    private readonly By navbarAboutMeLink = By.Id("navbarAboutMeLink");
    private readonly By navbarCodeSamplesLink = By.Id("navbarCodeSamplesLink");
    private readonly By navbarFAQLink = By.Id("navbarFAQLink");
    private readonly By navbarContactLink = By.Id("navbarContactLink");
    private readonly By navbarResumeLink = By.Id("navbarResumeLink");

    public Boolean NavbarIsVisible()
    {
        return driver.FindElement(navbar).Displayed;
    }

    public void ClickNavbarTitleLink()
    {
        driver.FindElement(navbarTitleLink).Click();
    }
    public void ClickNavbarIntroLink()
    {
        driver.FindElement(navbarIntroLink).Click();
    }
    public void ClickNavbarAboutMeLink()
    {
        driver.FindElement(navbarAboutMeLink).Click();
    }
    public void ClickNavbarCodeSamplesLinkLink()
    {
        driver.FindElement(navbarCodeSamplesLink).Click();
    }
    public void ClickNavbarFAQLink()
    {
        driver.FindElement(navbarFAQLink).Click();
    }
    public void ClickNavbarContactLink()
    {
        driver.FindElement(navbarContactLink).Click();
    }
    public void ClickNavbarResumeLink()
    {
        driver.FindElement(navbarResumeLink).Click();
    }

    //alternate to individual navbar locators
    public IReadOnlyList<IWebElement> FetchNavbarLinks()
    {
        return driver.FindElements(By.CssSelector("a[id*='navbar'], a[id*='Link"));
    }

    public List<Double> FetchNavbarLinkScrollExpectedLocations()
    {
        IReadOnlyList<IWebElement> navbarLinks = FetchNavbarLinks();
        List<Double> elementLocations = new(navbarLinks.Count);
        foreach (IWebElement link in navbarLinks)
        {
            ScrollToElement(link);
            elementLocations.Add(FetchElementPosition(link));
        }
        return elementLocations;
    }

    public List<Double> FetchNavbarLinkScrollLocations()
    {
        var navbarLinks = FetchNavbarLinks();
        List<Double> elementLocations = new(navbarLinks.Count);
        foreach (WebElement link in navbarLinks.Cast<WebElement>())
        {
            link.Click();
            elementLocations.Add(FetchElementPosition(link));
        }
        return elementLocations;
    }
}