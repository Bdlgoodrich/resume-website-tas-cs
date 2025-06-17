using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTest;

public class BasicTests : BaseTest
{
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

    [SetUp]
    public void Setup()
    {
        driver = StartDriver();
        HomePage home = new(driver);
        home.GoToUrl();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    [Test]
    public void PageTitleShouldBeExpectedTitle()
    {
        HomePage home = new(driver);
        Assert.That(home.GetTitle(), Is.EqualTo(home.ExpectedTitle));
    }

    [Test]
    public void HeroTitleShouldBeExpectedTitle()
    {
        HomePage home = new(driver);
        Assert.That(home.GetHeroTitle(), Is.EqualTo(home.ExpectedHeroTitle));
    }
    
    [Test]
    public void AboutLinkedInLinkShouldOpenNewTabWithLinkedIn()
    {
        HomePage home = new(driver);
        home.ClickAboutLinkedInLink();
        home.SwitchToNewWindow("LinkedIn");
        Assert.That(driver.Title,Contains.Substring("LinkedIn"));
    }
    
    [Test]
    public void AboutGitHubLinkShouldOpenNewTabWithGitHub()
    {
        HomePage home = new(driver);
        home.ClickAboutGitHubLink();
        home.SwitchToNewWindow(home.ExpectedGitHubTitle);
        Assert.That(driver.Title,Is.EqualTo(home.ExpectedGitHubTitle));
    }
    
    [Test]
    public void ContactLinkedInLinkShouldOpenNewTabWithLinkedIn()
    {
        HomePage home = new(driver);
        home.ClickContactLinkedInLink();
        home.SwitchToNewWindow("LinkedIn");
        Assert.That(driver.Title, Contains.Substring("LinkedIn"));
    }

    //TODO assess email verification
    [Test]
    public void ContactEmilLinkShouldOpenEmailDialogBox ()
    {
        HomePage home = new(driver);
        home.ClickContactEmailLink();
    }
}