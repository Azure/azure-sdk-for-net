// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation
{
    internal class VSTestFrameworkLogger : IFrameworkLogger
    {
        private readonly ILogger _logger;
        public VSTestFrameworkLogger(ILogger? logger = null)
        {
            _logger = logger ?? new Logger();
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warning(message);
        }
    }
}
