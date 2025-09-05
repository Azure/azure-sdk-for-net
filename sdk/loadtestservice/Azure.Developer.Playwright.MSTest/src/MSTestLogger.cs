// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azure.Developer.Playwright.MSTest;

internal class MSTestLogger : ILogger
{
    private readonly TestContext _testContext;

    public MSTestLogger(TestContext testContext)
    {
        _testContext = testContext ?? throw new ArgumentNullException(nameof(testContext));
    }

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

    public bool IsEnabled(LogLevel logLevel) => true;

    IDisposable? ILogger.BeginScope<TState>(TState state) => NullScope.Instance;

    private void Log(LogLevel level, string message)
    {
        System.IO.TextWriter writer = level == LogLevel.Error || level == LogLevel.Warning || level == LogLevel.Critical
            ? Console.Error
            : Console.Out;

        writer.WriteLine($"{DateTime.Now} [{level}]: {message}");

        _testContext.WriteLine($"[AzurePlaywright-MSTest]: {message}");
    }
}

internal class NullScope : IDisposable
{
    public static readonly NullScope Instance = new();

    private NullScope() { }

    public void Dispose() { }
}
