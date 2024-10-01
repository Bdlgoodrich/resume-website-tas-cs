using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTest;

public class BasicTests
{
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

    [Test]

    public void VerifyTitle()
    {
        HomePage home = new(driver);
        Assert.That(home.GetTitle(), Is.EqualTo(home.title));
    }



    [Test]

    public void VerifyHeroImage()
    {

    }

    [Test]

    public void VerifyHeroGitHubLink()
    {

    }

    public void VerifyHeroEmailLink()
    {

    }
}