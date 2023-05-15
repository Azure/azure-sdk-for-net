// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Helpers
{
    public class XunitLogger : ILogger
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly string _categoryName;
        private readonly string _callerMethodName;

        public XunitLogger(ITestOutputHelper testOutputHelper, string categoryName, string callerMethodName)
        {
            _testOutputHelper = testOutputHelper;
            _categoryName = categoryName;
            _callerMethodName = callerMethodName;
        }

        public IDisposable BeginScope<TState>(TState state)
            => NoopDisposable.Instance;

        public bool IsEnabled(LogLevel logLevel)
            => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            try
            {
                _testOutputHelper.WriteLine($"{_categoryName} [{eventId}] {formatter(state, exception)}");
                if (exception != null)
                {
                    _testOutputHelper.WriteLine(exception.ToString());
                }
            }
            catch (InvalidOperationException e) when (e.Message == "There is no currently active test.")
            {
                throw new InvalidOperationException($"{_callerMethodName} is no longer an active test.", e.InnerException);
            }
        }

        private class NoopDisposable : IDisposable
        {
            public static NoopDisposable Instance = new NoopDisposable();
            public void Dispose()
            { }
        }
    }
}
