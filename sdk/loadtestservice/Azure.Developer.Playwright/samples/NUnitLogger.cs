// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:NUnitLogger
using System;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

#if SNIPPET
internal class NUnitLogger(string? category = null, LogLevel minLevel = LogLevel.Information) : ILogger
{
    private readonly string? _category = category;
    private readonly LogLevel _minLevel = minLevel;

    public bool IsEnabled(LogLevel logLevel) => logLevel >= _minLevel;
    public IDisposable BeginScope<TState>(TState state) where TState : notnull => NullScope.Instance;
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;
        if (formatter == null) throw new ArgumentNullException(nameof(formatter));
        var msg = formatter(state, exception);
        if (exception != null) msg += "\n" + exception;

        var prefix = _category ?? "AzurePlaywright";

        try
        {
            string nunitLine = $"[{prefix}]: {msg}";
            if (logLevel == LogLevel.Debug)
                TestContext.Out.WriteLine(nunitLine);
            else if (logLevel == LogLevel.Error || logLevel == LogLevel.Critical)
                TestContext.Error.WriteLine(nunitLine);
            else
                TestContext.Progress.WriteLine(nunitLine);
        }
        catch
        {
            // Ignore if TestContext is unavailable (e.g., teardown race)
        }
    }

    private sealed class NullScope : IDisposable
    {
        public static readonly NullScope Instance = new();
        public void Dispose() { }
    }
}
#else
namespace Azure.Developer.Playwright.Samples
{
    internal class NUnitLogger : ILogger
    {
        private readonly string? _category;
        private readonly LogLevel _minLevel;

        public NUnitLogger(string? category = null, LogLevel minLevel = LogLevel.Information)
        {
            _category = category;
            _minLevel = minLevel;
        }

        public bool IsEnabled(LogLevel logLevel) => logLevel >= _minLevel;
        public IDisposable BeginScope<TState>(TState state) where TState : notnull => NullScope.Instance;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;
            if (formatter == null) throw new ArgumentNullException(nameof(formatter));
            var msg = formatter(state, exception);
            if (exception != null) msg += "\n" + exception;

            var prefix = _category ?? "AzurePlaywright";

            try
            {
                string nunitLine = $"[{prefix}]: {msg}";
                if (logLevel == LogLevel.Debug)
                    TestContext.Out.WriteLine(nunitLine);
                else if (logLevel == LogLevel.Error || logLevel == LogLevel.Critical)
                    TestContext.Error.WriteLine(nunitLine);
                else
                    TestContext.Progress.WriteLine(nunitLine);
            }
            catch
            {
                // Ignore if TestContext is unavailable (e.g., teardown race)
            }
        }

        private sealed class NullScope : IDisposable
        {
            public static readonly NullScope Instance = new();
            public void Dispose() { }
        }
    }
}
#endif
#endregion
