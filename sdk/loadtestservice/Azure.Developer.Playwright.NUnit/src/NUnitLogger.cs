// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.Developer.Playwright.NUnit;

internal class NUnitLogger : ILogger
{
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }
        if (formatter == null)
        {
            throw new ArgumentNullException(nameof(formatter));
        }
        string message = formatter(state, exception);
        if (exception != null)
        {
            message += $"\nException: {exception}";
        }
        Log(logLevel, message);
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    IDisposable? ILogger.BeginScope<TState>(TState state)
    {
        return NullScope.Instance;
    }

    private static void Log(LogLevel level, string message)
    {
        System.IO.TextWriter writer = level == LogLevel.Error || level == LogLevel.Warning || level == LogLevel.Critical ? Console.Error : Console.Out;
        writer.WriteLine($"{DateTime.Now} [{level}]: {message}");

        if (level == LogLevel.Debug)
        {
            TestContext.WriteLine($"[AzurePlaywright-NUnit]: {message}");
        }
        else if (level == LogLevel.Error || level == LogLevel.Critical)
        {
            TestContext.Error.WriteLine($"[AzurePlaywright-NUnit]: {message}");
        }
        else
        {
            TestContext.Progress.WriteLine($"[AzurePlaywright-NUnit]: {message}");
        }
    }
};

internal class NullScope : IDisposable
{
    public static readonly NullScope Instance = new();

    private NullScope() { }

    public void Dispose()
    {
        // No operation
    }
}
