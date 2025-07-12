using NUnitTest.PageObjects;
using OpenQA.Selenium;

namespace NUnitTest.Tests;

public class NavbarTests : BaseTest
{
    private new IWebDriver driver;

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
    public void NavbarShouldBeHiddenUponPageLoad()
    {
        Navbar navbar = new(driver);
        Assert.That(navbar.NavbarIsVisible, Is.False);
    }

    [Test]
    public void NavbarShouldBeVisibleUponScroll()
    {
        HomePage home = new(driver);
        Navbar navbar = new(driver);
        home.ScrollToHero();
        Assert.That(navbar.NavbarIsVisible, Is.True);
    }

    [Test]
    public void NavbarResumeLinkShouldOpenResumeInNewTab()
    {
        HomePage home = new(driver);
        Navbar navbar = new(driver);
        home.ScrollToHero();
        navbar.ClickNavbarResumeLink();
        
    }
}