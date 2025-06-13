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

    private readonly By carousel = By.Id("code-projects");
    private readonly By carouselButtons = By.ClassName("owl-dot");
    private readonly By carouselItems = By.ClassName("owl-item");
    private readonly By activeItems = By.CssSelector(".owl-item.active");
    private readonly By cloneItems = By.CssSelector(".owl-item.cloned");
    
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
        Thread.Sleep(200);
    }

    public void ClickAboutLinkedInLink()
    {
        driver.FindElement(aboutLinkedInLink).Click();
    }



    public int GetButtonCount()
    {
        return driver.FindElements(carouselButtons).Count;
    }

    public int GetCarouselItemCount()
    {
        return (driver.FindElements(carouselItems).Count-driver.FindElements(cloneItems).Count);
    }
    
    public int GetDisplayedCarouselItemCount()
    {
        int displayedItems = 0;
        WaitForElementToBeVisible(activeItems);
        var allActiveItems = driver.FindElements(activeItems);

        foreach (var item in allActiveItems)
        {
            try
            {
                if (item.Displayed)
                {
                    displayedItems++;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return displayedItems;
    }

    public int GetExpectedDisplayedCarouselItemCount(int buttonCount)
    {
        return (int)Math.Ceiling((decimal)expectedCarouselItemCount / buttonCount);
    }

    public void ClickCarouselButtonByIndex (int index){
        driver.FindElements(carouselButtons)[index].Click();
        WaitForElementToBeVisible(activeItems);
    }
    
}