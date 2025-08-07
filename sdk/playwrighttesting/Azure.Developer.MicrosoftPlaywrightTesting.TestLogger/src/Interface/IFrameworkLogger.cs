// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface
{
    /// <summary>
    /// Sets up logging for the TestLogger package.
    /// </summary>
    public interface IFrameworkLogger
    {
        /// <summary>
        /// Log informational message.
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);
        /// <summary>
        /// Log debug messages.
        /// </summary>
        /// <param name="message"></param>
        void Debug(string message);
        /// <summary>
        /// Log warnming messages.
        /// </summary>
        /// <param name="message"></param>
        void Warning(string message);
        /// <summary>
        /// Log error messages.
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);
    }
}
