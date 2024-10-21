// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface
{
    internal interface ILogger
    {
        void Info(string message);
        void Debug(string message);
        void Warning(string message);
        void Error(string message);
    }
}
