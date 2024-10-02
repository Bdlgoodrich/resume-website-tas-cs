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
    public void VerifyTitle()
    {
        HomePage home = new(driver);
        Assert.That(home.GetTitle(), Is.EqualTo(home.expectedTitle));
    }

    [Test]
    public void VerifyHero()
    {
        HomePage home = new(driver);
        Assert.That(home.GetHeroTitle(), Is.EqualTo(home.expectedHeroTitle));

        //TODO assess email verification
    }

    [Test]
    public void VerifyAboutLinkedInLink()
    {
        HomePage home = new(driver);
        home.ClickAboutLinkedInLink();

    }

    [Test]
    public void VerifyAboutEmailLink()
    {

    }
}