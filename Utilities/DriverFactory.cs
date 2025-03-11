using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SauceDemoTests.Utilities
{
    /// <summary>
    /// The class is responsible for creating and configuring WebDriver instances.
    /// </summary>
    public static class DriverFactory
    { 
        /// <summary>
        /// Creates and returns a new instance of Firefox WebDriver with specified options.
        /// </summary>
        /// <returns>An initialized IWebDriver instance for Firefox.</returns>
        public static IWebDriver GetDriver()
        {
            // Configure Firefox options
            var options = new FirefoxOptions();
            options.AddArgument("--start-maximized"); // Starts the browser in maximized mode

            // Set the path to geckodriver executable located in the Drivers folder
            string driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers");
            
            // Initialize and return the Firefox driver
            return new FirefoxDriver(driverPath, options);
        }
    }
}