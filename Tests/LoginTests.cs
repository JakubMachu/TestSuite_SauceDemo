using OpenQA.Selenium;
using SauceDemoTests.Pages;
using SauceDemoTests.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace SauceDemoTests.Tests
{
    /// <summary>
    /// Test class containing login-related test cases for the SauceDemo website.
    /// </summary>
    public class LoginTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;

        /// <summary>
        /// Initializes a new instance of the LoginTests class, setting up the WebDriver and LoginPage.
        /// </summary>
        public LoginTests()
        {
            // Set up the WebDriver and create an instance of the LoginPage
            Logger.Log("Starting test session");
            _driver = DriverFactory.GetDriver();
            _loginPage = new LoginPage(_driver);
        }

        /// <summary>
        /// Tests a successful login with valid credentials.
        /// </summary>
        [Fact]
        public void SuccessfulLoginTest()
        {
            Logger.Log("Running SuccessfulLoginTest");
            _loginPage.NavigateTo();                                                   // Arrange: Navigate to the login page
            Logger.Log("1) Navigated to login page");
            _loginPage.Login("standard_user", "secret_sauce");                         // Act: Perform login with valid credentials
            Logger.Log("2) Login attempted with valid credentials");
            Assert.Equal("https://www.saucedemo.com/v1/inventory.html", _driver.Url);  // Assert: Verify the URL redirects to the inventory page
            Logger.Log("3) SuccessfulLoginTest passed");
        }

        /// <summary>
        /// Tests a failed login with invalid credentials and checks for an error message.
        /// </summary>
        [Fact]
        public void FailedLoginTest()
        {
            Logger.Log("1) Running FailedLoginTest");
            _loginPage.NavigateTo();
            Logger.Log("2) Navigated to login page");
            _loginPage.Login("locked_out_user", "secret_sauce");
            Logger.Log("3) Login attempted with invalid credentials");
            Assert.True(_loginPage.IsErrorMessageDisplayed(), "Error message should be displayed for invalid login.");
            Logger.Log("4) FailedLoginTest passed");
        }

        /// <summary>
        /// Cleans up resources by closing the WebDriver after each test.
        /// </summary>
         public void Dispose()
        {
            Logger.Log("Close the browser and release resources");
            _driver.Quit();
        }
    }
}