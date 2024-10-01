using OpenQA.Selenium;

namespace NUnitTest;

public class NavbarTests
{
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private readonly IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

    [Test]
    public void VerifyNavbarAppearance()
    {
        HomePage home = new(driver);
        Navbar navbar = new(driver);

        Assert.That(navbar.NavbarIsVisible, Is.False);
        home.ScrollToHero();
        Assert.That(navbar.NavbarIsVisible, Is.True);
    }

    [Test]
    public void VerifyNavbarNavigations()
    {
        HomePage home = new(driver);
        Navbar navbar = new(driver);

        
    }
}