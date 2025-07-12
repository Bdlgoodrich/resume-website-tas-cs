using NUnitTest.PageObjects;

namespace NUnitTest.Tests;

public class DropdownTests : BaseTest
{
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
    public void AllOptionsShouldBeClosedUponPageLoad()
    {
        
    }

    [Test]
    public void EachDropdownOptionShouldOpenWhenClickedAndCloseWhenClickedAgain()
    {
        HomePage home = new(driver);
        home.ScrollToCarousel();
    }

    [Test]
    public void FirstDropdownOptionShouldOpenWhenClicked()
    {
        
    }
}