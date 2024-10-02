using OpenQA.Selenium;

public class HomePage : Utilities
{
    public HomePage(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }

    //Expected website text content
    readonly String url = "https://resume-website-brianna-goodrichs-projects.vercel.app/";
    public readonly String expectedTitle = "Brianna's Resume";
    public readonly String expectedHeroTitle = "Brianna Goodrich, aspiring Software Test Automation Engineer";
    public readonly String expectedEmail = "bdlgoodrich@gmail.com";
    public readonly String expectedLinkedInTitle = "Brianna Goodrich | LinkedIn";
    public readonly int expectedCarouselItemCount = 6;


    //WebElement By locators
    private readonly By heroTitle = By.TagName("h1");
    private readonly By aboutEmailLink = By.Id("aboutEmailLink");
    private readonly By aboutLinkedInLink = By.Id("aboutLinkedInLink");

    private static readonly By carousel = By.Id("code-samples");
    private readonly By carouselButtons = By.TagName("button");  //requires carousel.FindElement()
    private readonly By carouselItems = By.ClassName("owl-item");
    public readonly By activeItems = By.ClassName("active");  //requires carouselItems.FindElements() OR carouselButtons.FindElement()

    public void GoToUrl()
    {
        driver.Url = url;
    }

    public String GetTitle()
    {
        return driver.Title;
    }
    public String GetHeroTitle()
    {
        return driver.FindElement(heroTitle).Text;
    }


    public void ScrollToHero()
    {
        ScrollToByElement(heroTitle);
    }

    public void ScrollToCarousel()
    {
        ScrollToByElement(carousel);
    }

    public void ClickAboutLinkedInLink()
    {
        driver.FindElement(aboutLinkedInLink).Click();
    }



    public int GetButtonCount()
    {
        return driver.FindElements(carouselButtons).Count;
    }
    public int GetActiveCarouselItemCount()
    {
        return carouselItems.FindElements((ISearchContext)activeItems).Count;
    }

    public int GetExpectedActiveCarouselItemCount()
    {
        return (int)Math.Ceiling((decimal)(expectedCarouselItemCount / GetButtonCount()));
    }

    public int GetExpectedLastCarouselItemCount()
    {
        return expectedCarouselItemCount%GetButtonCount();
    }

    public IWebElement GetActiveButton()
    {
        return carouselButtons.FindElement((ISearchContext)activeItems);
    }

    public void ClickCarouselButton (int index){
        carousel.FindElements((ISearchContext)carouselButtons)[index].Click();
    }



}