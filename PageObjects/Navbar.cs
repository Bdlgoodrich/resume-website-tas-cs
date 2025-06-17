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
    private readonly By navbarResumeLink = By.Id("navbarResumeLink");
    public By ConvertToBy(String name)
    {
        return By.Id("navbar" + name + "Link");
    }
    
    public Boolean NavbarIsVisible()
    {
        return driver.FindElement(navbar).Displayed;
    }

    public void ClickNavbarLinkByName(String name)
    {
        driver.FindElement(ConvertToBy(name)).Click();
        Thread.Sleep(1000);
    }
    
    public void ClickNavbarResumeLink()
    {
        driver.FindElement(navbarResumeLink).Click();
    }

    public double FetchNavbarLinkExpectedLocation(String name)
    {
        if (name == "Title") return 0;
        By link = ConvertToBy(name);    
        return FetchElementPosition(link);
    }
    
}