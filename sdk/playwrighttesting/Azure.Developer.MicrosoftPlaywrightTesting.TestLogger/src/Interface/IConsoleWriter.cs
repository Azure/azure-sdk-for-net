// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface
{
    internal interface IConsoleWriter
    {
        void WriteLine(string? message = null);
        void WriteError(string? message = null);
    }
}
