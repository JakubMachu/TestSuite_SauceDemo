using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests.Pages
{
    /// <summary>
    /// Represents the login page of the SauceDemo website using the Page Object Model.
    /// </summary>
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://www.saucedemo.com/v1/";

        // Locators for web elements on the login page
        private By UsernameField => By.Id("user-name");
        private By PasswordField => By.Id("password");
        private By LoginButton => By.Id("login-button");
        private By ErrorMessage => By.CssSelector("h3[data-test='error']");

        /// <summary>
        /// Initializes a new instance of the LoginPage class.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to interact with the page.</param>
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Navigates to the SauceDemo login page URL.
        /// </summary>
        public void NavigateTo()
        {
            // Load the login page in the browser
            _driver.Navigate().GoToUrl(_url);
        }

        /// <summary>
        /// Performs a login attempt with the provided username and password.
        /// </summary>
        /// <param name="username">The username to enter.</param>
        /// <param name="password">The password to enter.</param>
        public void Login(string username, string password)
        {
            // Wait up to 10 seconds for the username field to be visible before interacting
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
             wait.Until(d => d.FindElement(UsernameField).Displayed);

             // Enter the provided username and password, then submit the login form
            _driver.FindElement(UsernameField).SendKeys(username);
            _driver.FindElement(PasswordField).SendKeys(password);
            _driver.FindElement(LoginButton).Click();
        }   

        /// <summary>
        /// Checks if the error message is displayed after a failed login attempt.
        /// </summary>
        /// <returns>True if the error message is visible, false otherwise.</returns>
        public bool IsErrorMessageDisplayed()
        {
            // Wait up to 5 seconds for the error message to appear
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(d => d.FindElement(ErrorMessage).Displayed); // Return true if error message is visible
        }
    }
}