using OpenQA.Selenium;
using SauceDemoTests.Pages;
using SauceDemoTests.Utilities;

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
            _driver = DriverFactory.GetDriver();
            _loginPage = new LoginPage(_driver);
        }

        /// <summary>
        /// Tests a successful login with valid credentials.
        /// </summary>
        [Fact]
        public void SuccessfulLoginTest()
        {
            // Arrange: Navigate to the login page
            _loginPage.NavigateTo();

            // Act: Perform login with valid credentials
            _loginPage.Login("standard_user", "secret_sauce");

            // Assert: Verify the URL redirects to the inventory page
            Assert.Equal("https://www.saucedemo.com/v1/inventory.html", _driver.Url);
        }

        /// <summary>
        /// Tests a failed login with invalid credentials and checks for an error message.
        /// </summary>
        [Fact]
        public void FailedLoginTest()
        {
        _loginPage.NavigateTo();
        _loginPage.Login("locked_out_user", "secret_sauce");
        Assert.True(_loginPage.IsErrorMessageDisplayed(), "Error message should be displayed for invalid login.");
        }

        /// <summary>
        /// Cleans up resources by closing the WebDriver after each test.
        /// </summary>
         public void Dispose()
        {
            // Close the browser and release resources
            _driver.Quit();
        }
    }
}