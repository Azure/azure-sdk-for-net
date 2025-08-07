// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation
{
    internal class CloudRunErrorParser : ICloudRunErrorParser
    {
        internal List<string> InformationalMessages { get; private set; } = new();
        private List<string> ProcessedErrorMessageKeys { get; set; } = new();
        private readonly ILogger _logger;
        private readonly IConsoleWriter _consoleWriter;
        public CloudRunErrorParser(ILogger? logger = null, IConsoleWriter? consoleWriter = null)
        {
            _logger = logger ?? new Logger();
            _consoleWriter = consoleWriter ?? new ConsoleWriter();
        }

        public bool TryPushMessageAndKey(string? message, string? key)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(message))
            {
                return false;
            }
            if (ProcessedErrorMessageKeys.Contains(key!))
            {
                return false;
            }
            _logger.Info($"Adding message with key: {key}");

            ProcessedErrorMessageKeys.Add(key!);
            InformationalMessages.Add(message!);
            return true;
        }

        public void PushMessage(string message)
        {
            InformationalMessages.Add(message);
        }

        public void DisplayMessages()
        {
            if (InformationalMessages.Count > 0)
                _consoleWriter.WriteLine();
            int index = 1;
            foreach (string message in InformationalMessages)
            {
                _consoleWriter.WriteLine($"{index++}) {message}");
            }
        }

        public void PrintErrorToConsole(string message)
        {
            _consoleWriter.WriteError(message);
        }

        public void HandleScalableRunErrorMessage(string? message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            foreach (TestResultError testResultErrorObj in TestResultErrorConstants.ErrorConstants)
            {
                if (testResultErrorObj.Pattern.IsMatch(message))
                {
                    TryPushMessageAndKey(testResultErrorObj.Message, testResultErrorObj.Key);
                }
            }
        }
    }
}
