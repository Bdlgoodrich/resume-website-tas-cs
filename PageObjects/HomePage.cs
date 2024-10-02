using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class HomePage : Utilities
{
    public HomePage(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }

    //Expected website text content
    readonly String url = "https://resume-website-brianna-goodrichs-projects.vercel.app/";
    public readonly String title = "Brianna's Resume";

    //WebElement By locators
    private readonly By heroTitle = By.TagName("h1");
    private readonly By aboutEmailLink = By.Id("aboutEmailLink");
    private readonly By aboutLinkedInLink = By.Id("aboutLinkedInLink");

    private readonly By carousel = By.Id("carousel");

    public void GoToUrl()
    {
        driver.Url = url;
    }

    public String GetTitle()
    {
        return driver.Title;
    }

    public void ScrollToHero()
    {
        ScrollToByElement(heroTitle);
    }

    public void ScrollToCarousel()
    {
        ScrollToByElement(carousel);
    }


}