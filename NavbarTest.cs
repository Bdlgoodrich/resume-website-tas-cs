using OpenQA.Selenium;

namespace NUnitTest;

public class NavbarTests : BaseTest
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
    public void NavbarShouldBeHiddenUponPageLoad()
    {
        HomePage home = new(driver);
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

    public static String[] NavbarButtons = { "Title", "Intro", "AboutMe", "CodeProjects", "FAQ", "Contact" };
    
    [TestCaseSource(nameof(NavbarButtons))]
    public void NavbarButtonsShouldScrollToCorrectLocations(String button)
    {
        HomePage home = new(driver);
        Navbar navbar = new(driver);
        home.ScrollToHero();
        navbar.ClickNavbarLinkByName(button);
        Assert.That(navbar.FetchCurrentPosition(),Is.EqualTo(navbar.FetchNavbarLinkExpectedLocation(button)),
            "The " + button + " Navbar link did not navigate to expected location.");
    }
}