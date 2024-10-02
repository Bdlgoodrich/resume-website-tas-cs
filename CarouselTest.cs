using System.Runtime.ConstrainedExecution;
using OpenQA.Selenium;

namespace NUnitTest;

public class CarouselTests
{
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private readonly IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

    [Test]
    public void VerifyCarousel()
    {
        HomePage home = new(driver);
        home.ScrollToCarousel();

        int buttonCount = home.GetButtonCount();
        int expectedActiveCarouselItems = home.GetExpectedActiveCarouselItemCount();
        int expectedLastCarouselItemsCount = home.GetExpectedLastCarouselItemCount();

        for(int i = 0; i < buttonCount-1; i++){
            home.ClickCarouselButton(i);
             Assert.That(home.GetActiveCarouselItemCount(), Is.EqualTo(expectedActiveCarouselItems));
        }
        home.ClickCarouselButton(buttonCount);
        Assert.That(home.GetActiveCarouselItemCount(), Is.EqualTo(expectedLastCarouselItemsCount));

    }

}