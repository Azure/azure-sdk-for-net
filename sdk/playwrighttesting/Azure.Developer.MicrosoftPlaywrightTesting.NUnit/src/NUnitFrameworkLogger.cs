// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using NUnit.Framework;

namespace Azure.Developer.MicrosoftPlaywrightTesting.NUnit
{
    internal class NUnitFrameworkLogger : IFrameworkLogger
    {
        public void Debug(string message)
        {
            TestContext.WriteLine($"[MPT-NUnit]: {message}");
        }

        public void Error(string message)
        {
            TestContext.Error.WriteLine($"[MPT-NUnit]: {message}");
        }

        public void Info(string message)
        {
            TestContext.Progress.WriteLine($"[MPT-NUnit]: {message}");
        }

        public void Warning(string message)
        {
            TestContext.Progress.WriteLine($"[MPT-NUnit]: {message}");
        }
    }
}
