// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Tests.TestFramework;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace ClientModel.Tests;

public class TestLogger : ILogger
{
    private LogLevel _logLevel;
    private readonly ConcurrentQueue<LoggerEvent> _logs = new();

    public TestLogger(LogLevel logLevel, string name)
    {
        _logLevel = logLevel;
        Name = name;
    }

    public IEnumerable<LoggerEvent> Logs => _logs;

    public string Name { get; set; }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        throw new NotImplementedException();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel >= _logLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (IsEnabled(logLevel))
        {
            IReadOnlyList<KeyValuePair<string, object?>> arguments = state as IReadOnlyList<KeyValuePair<string, object?>> ?? new List<KeyValuePair<string, object?>>();
            var loggerEvent = new LoggerEvent(logLevel, formatter(state, exception), exception, eventId, arguments);
            _logs.Enqueue(loggerEvent);
        }
    }

    public LoggerEvent GetAndValidateSingleEvent(int eventId, string expectedEventName, LogLevel expectedEventLevel)
    {
        LoggerEvent log = SingleEventById(eventId);
        Assert.AreEqual(expectedEventName, log.EventId.Name);
        Assert.AreEqual(expectedEventLevel, log.LogLevel);
        string requestId = log.GetValueFromArguments<string>("requestId");
        Assert.That(string.IsNullOrEmpty(requestId), Is.False);
        return log;
    }

    public LoggerEvent SingleEventById(int eventId, Func<LoggerEvent, bool>? filter = default)
    {
        return EventsById(eventId).Single(filter ?? (_ => true));
    }

    public void ValidateNumberOfEventsById(int eventId, int expectedNumEvents)
    {
        Assert.AreEqual(expectedNumEvents, EventsById(eventId).Count());
    }

    public IEnumerable<LoggerEvent> EventsById(int eventId)
    {
        return _logs.Where(e => e.EventId.Id == eventId);
    }

    public void AssertNoContentLogged()
    {
        CollectionAssert.IsEmpty(EventsById(2)); // RequestContentEvent
        CollectionAssert.IsEmpty(EventsById(17)); // RequestContentTextEvent

        CollectionAssert.IsEmpty(EventsById(6)); // ResponseContentEvent
        CollectionAssert.IsEmpty(EventsById(13)); // ResponseContentTextEvent
        CollectionAssert.IsEmpty(EventsById(11)); // ResponseContentBlockEvent
        CollectionAssert.IsEmpty(EventsById(15)); // ResponseContentTextBlockEvent

        CollectionAssert.IsEmpty(EventsById(9)); // ErrorResponseContentEvent
        CollectionAssert.IsEmpty(EventsById(14)); // ErrorResponseContentTextEvent
        CollectionAssert.IsEmpty(EventsById(12)); // ErrorResponseContentBlockEvent
        CollectionAssert.IsEmpty(EventsById(16)); // ErrorResponseContentTextBlockEvent
    }
}
