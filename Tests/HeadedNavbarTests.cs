using NUnitTest.PageObjects;
using OpenQA.Selenium;

namespace NUnitTest.Tests;

public class HeadedNavbarTests : BaseTest
{
    private new IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = StartDriverHeaded();
        HomePage home = new(driver);
        home.GoToUrl();
        driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    public static readonly string[] NavbarButtons = ["Title", "Intro", "AboutMe", "CodeProjects", "FAQ", "Contact"];

    [TestCaseSource(nameof(NavbarButtons))]
    public void NavbarButtonsShouldScrollToCorrectLocations(string button)
    {
        HomePage home = new(driver);
        Navbar navbar = new(driver);
        home.ScrollToHero();
        navbar.ClickNavbarLinkByName(button);
        Assert.That(navbar.FetchCurrentPosition(), Is.EqualTo(navbar.FetchNavbarLinkExpectedLocation(button)),
            $"The {button} Navbar link did not navigate to expected location.");
    }
    
    [Test]
    public void ShouldFail()
    {
        HomePage home = new(driver);
        Navbar navbar = new(driver);
        home.ScrollToHero();
        navbar.ClickNavbarLinkByName("AboutMe");
        Assert.That(navbar.FetchCurrentPosition(), Is.EqualTo(navbar.FetchNavbarLinkExpectedLocation("Contact")),
            $"This test intentionally failed to verify Navbar link test logic.");
    }
}