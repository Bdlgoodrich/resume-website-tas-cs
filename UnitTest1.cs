using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTest;

public class Tests
{
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

    [SetUp]

    public void Setup()

    {

        string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        driver = new ChromeDriver(path + @"\drivers\");

        //If you want to Execute Tests on Firefox uncomment the below code

        // Specify Correct location of geckodriver.exe folder path. Ex: C:/Project/drivers

        //driver= new FirefoxDriver(path + @"\drivers\");

        HomePage home = new(driver);
        home.GoToUrl();

    }

    [Test]

    public void verifyTitle()
    {
        HomePage home = new(driver);
        Assert.That(home.GetTitle() == home.title, Is.True);
    }

    [Test]

    public void verifyNavbarPresense()
    {
        HomePage home = new(driver);
        Navbar navbar = new(driver);
        Assert.That(navbar.NavbarIsVisible, Is.False);
        home.ScrollToHero();
        Assert.That(navbar.NavbarIsVisible, Is.True);
    }

    [Test]

    public void verifyPricingPage()
    {

    }


    [TearDown]

    public void TearDown()

    {
        driver.Quit();
    }

}