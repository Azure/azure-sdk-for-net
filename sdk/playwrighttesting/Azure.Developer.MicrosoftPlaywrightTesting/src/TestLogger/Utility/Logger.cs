// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility;

internal enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error
}

internal static class Logger
{
    public static void Log(bool enableConsoleLog, LogLevel level, string message)
    {
        if (enableConsoleLog)
        {
            Console.WriteLine($"{DateTime.Now} [{level}]: {message}");
        }
    }
}
