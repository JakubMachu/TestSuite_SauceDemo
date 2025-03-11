# TestSuite_SauceDemo

Automated testing suite for the [SauceDemo](https://www.saucedemo.com/v1/) website using C#, Selenium WebDriver, and xUnit.

## Overview

This project demonstrates automated testing of the SauceDemo e-commerce site. It uses the Page Object Model (POM) for maintainability and includes logging to track test execution.

## Features

- **Login Tests:** Tests for successful and failed login scenarios.
- **Page Object Model:** Structured code for easy maintenance.
- **Logging:** Test execution details are logged to `log.txt` in the output directory (`bin/Debug/net8.0`).
- **Browser:** Runs on Firefox using GeckoDriver.
- *(Planned)* Screenshots on test failure (coming soon).

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Firefox browser installed
- Git (for cloning the repository)

## Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/JakubMachu/TestSuite_SauceDemo.git
   cd TestSuite_SauceDemo
