using System.Runtime.ConstrainedExecution;
using OpenQA.Selenium;

namespace NUnitTest;

public class CarouselTests: BaseTest
{
    private IWebDriver driver;
    
    [SetUp]
    public void Setup()
    {
        driver = StartDriver();
        HomePage home = new(driver);
        home.GoToUrl();
        driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    [Test]
    public void ShouldContainExpectedItemCount()
    {
        HomePage home = new(driver);
        home.ScrollToCarousel();
        Assert.That(home.GetCarouselItemCount(), Is.EqualTo(home.ExpectedCarouselItemCount));

    }
    
    [Test]
    public void ShouldContainExpectedCarouselItemCountPerPage()
    {
        HomePage home = new(driver);
        home.ScrollToCarousel();
        int buttonCount = home.GetButtonCount();
        for (int i = 0; i < (buttonCount); i++)
        {
            home.ClickCarouselButtonByIndex(i);
            Assert.That(home.GetDisplayedCarouselItemCount(),Is.EqualTo(home.GetExpectedDisplayedCarouselItemCount(buttonCount)));
        }
        
    }

}