using System;
using System.IO;

namespace SauceDemoTests.Utilities
{
    /// <summary>
    /// Simple utility class for logging test execution details to a file.
    /// </summary>
    public static class Logger
    {
        // Dynamic path to log.txt in the output directory (e.g., SauceDemoTests/bin/Debug/net8.0)
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");

        /// <summary>
        /// Writes a message to the log file with a timestamp.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"[{timestamp}] {message}";

            // Append the message to log.txt
            File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
        }
    }
}