// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Extensions.Azure.Tests
{
    public class LogForwarderTests
    {
        [TestCase(EventLevel.LogAlways, LogLevel.Information)]
        [TestCase(EventLevel.Critical, LogLevel.Critical)]
        [TestCase(EventLevel.Error, LogLevel.Error)]
        [TestCase(EventLevel.Informational, LogLevel.Information)]
        [TestCase(EventLevel.Verbose, LogLevel.Debug)]
        [TestCase(EventLevel.Warning, LogLevel.Warning)]
        public void MapsLevelsCorrectly(EventLevel eventLevel, LogLevel logLevel)
        {
            var loggerFactory = new MockLoggerFactory();
            using (var forwarder = new AzureEventSourceLogForwarder(loggerFactory))
            {
                forwarder.Start();
                typeof(TestSource).GetMethod(eventLevel.ToString(), BindingFlags.Instance | BindingFlags.Public).Invoke(TestSource.Log, Array.Empty<object>());
            }

            var logs = loggerFactory.Loggers["Test.source"].Logs;
            Assert.AreEqual(1, logs.Count);
            Assert.AreEqual(logLevel, logs[0].level);
        }

        [Test]
        public void WorksWithNullLoggerFactory()
        {
            using var forwarder = new AzureEventSourceLogForwarder( null);
            forwarder.Start();
            TestSource.Log.Informational();
        }

        [Test]
        public void CanDisposeNonStarted()
        {
            var forwarder = new AzureEventSourceLogForwarder( null);
            forwarder.Dispose();
        }

        public class MockLogger : ILogger
        {
            public string CategoryName { get; }

            public List<(LogLevel level, EventId eventId, string message)> Logs { get; } =
                new List<(LogLevel level, EventId eventId, string message)>();

            public MockLogger(string categoryName)
            {
                CategoryName = categoryName;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                lock (Logs)
                {
                    Logs.Add((logLevel, eventId, formatter(state, exception)));
                }
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }

        public class MockLoggerFactory : ILoggerFactory
        {
            public Dictionary<string, MockLogger> Loggers = new Dictionary<string, MockLogger>();

            public void Dispose()
            {
            }

            public ILogger CreateLogger(string categoryName)
            {
                lock (Loggers)
                {
                    if (!Loggers.TryGetValue(categoryName, out var logger))
                    {
                        logger = Loggers[categoryName] = new MockLogger(categoryName);
                    }

                    return logger;
                }
            }

            public void AddProvider(ILoggerProvider provider)
            {
            }
        }

        private class TestSource : EventSource
        {
            internal static TestSource Log { get; } = new TestSource();

            private TestSource() : base("Test-source", EventSourceSettings.Default, "AzureEventSource", "true")
            {
            }

            [Event(1, Message = "LogAlways", Level = EventLevel.LogAlways)]
            public void LogAlways()
            {
                WriteEvent(1);
            }

            [Event(2, Message = "Critical", Level = EventLevel.Critical)]
            public void Critical()
            {
                WriteEvent(2);
            }

            [Event(3, Message = "Error", Level = EventLevel.Error)]
            public void Error()
            {
                WriteEvent(3);
            }

            [Event(4, Message = "Informational", Level = EventLevel.Informational)]
            public void Informational()
            {
                WriteEvent(4);
            }

            [Event(5, Message = "Verbose", Level = EventLevel.Verbose)]
            public void Verbose()
            {
                WriteEvent(5);
            }

            [Event(6, Message = "Warning", Level = EventLevel.Warning)]
            public void Warning()
            {
                WriteEvent(6);
            }
        }
    }
}
