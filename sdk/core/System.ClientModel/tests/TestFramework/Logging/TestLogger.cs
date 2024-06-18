// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ClientModel.Tests;

public class TestLogger : ILogger
{
    private LogLevel _logLevel;
    private string _name;

    public TestLogger(string name, LogLevel logLevel)
    {
        _logLevel = logLevel;
        _name = name;
    }

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
        if (!IsEnabled(logLevel))
        {
            var arguments = GetProperties(state);
            TestLoggingEventSource.Log.LogMessage(logLevel, _name, eventId.Id, eventId.Name, exception, arguments);
        }
    }

    private static KeyValuePair<string, string?>[] GetProperties(object? state)
    {
        if (state is IReadOnlyList<KeyValuePair<string, object?>> keyValuePairs)
        {
            var arguments = new KeyValuePair<string, string?>[keyValuePairs.Count];
            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                KeyValuePair<string, object?> keyValuePair = keyValuePairs[i];
                arguments[i] = new KeyValuePair<string, string?>(keyValuePair.Key, keyValuePair.Value?.ToString());
            }
            return arguments;
        }

        return Array.Empty<KeyValuePair<string, string?>>();
    }
}
