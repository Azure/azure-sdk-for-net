// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Tests.TestFramework;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace ClientModel.Tests;

public class TestLogger : ILogger
{
    private LogLevel _logLevel;
    private readonly ConcurrentQueue<LoggerEvent> _logs = new();

    public TestLogger(LogLevel logLevel)
    {
        _logLevel = logLevel;
        Name = "<Will be set by the logger factory>";
    }

    public IEnumerable<LoggerEvent> Logs => _logs;

    public string Name { get; set; }

    public IDisposable BeginScope<TState>(TState state)
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

    public LoggerEvent SingleEventById(int id, Func<LoggerEvent, bool>? filter = default)
    {
        return EventsById(id).Single(filter ?? (_ => true));
    }

    public IEnumerable<LoggerEvent> EventsById(int id)
    {
        return _logs.Where(e => e.EventId.Id == id);
    }
}
