// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;

internal enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error
}

internal class Logger : ILogger
{
    internal static string? SdkLogLevel => Environment.GetEnvironmentVariable(Constants.s_pLAYWRIGHT_SERVICE_DEBUG);

#pragma warning disable CA1822 // Mark members as static
    private void Log(LogLevel level, string message)
#pragma warning restore CA1822 // Mark members as static
    {
        if (Enum.TryParse(SdkLogLevel, out LogLevel configuredLevel) && level >= configuredLevel)
        {
            System.IO.TextWriter writer = level == LogLevel.Error || level == LogLevel.Warning ? Console.Error : Console.Out;
            writer.WriteLine($"{DateTime.Now} [{level}]: {message}");
        }
    }

    public void Debug(string message)
    {
        Log(LogLevel.Debug, message);
    }

    public void Error(string message)
    {
        Log(LogLevel.Error, message);
    }

    public void Info(string message)
    {
        Log(LogLevel.Info, message);
    }

    public void Warning(string message)
    {
        Log(LogLevel.Warning, message);
    }
};
