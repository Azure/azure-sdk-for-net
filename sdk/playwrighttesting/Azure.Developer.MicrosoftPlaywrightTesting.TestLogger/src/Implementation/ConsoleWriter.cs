// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation
{
    internal class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string? message = null)
        {
            Console.WriteLine(message);
        }

        public void WriteError(string? message = null)
        {
            Console.Error.WriteLine(message);
        }
    }
}
