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
        Navbar navbar = new(driver);

        home.ScrollToCarousel();

    }

}