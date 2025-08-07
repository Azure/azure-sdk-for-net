// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Tests.TestFramework;

public class LoggerEvent
{
    public LoggerEvent(LogLevel logLevel,
                        string message,
                        Exception? exception,
                        EventId eventId,
                        IReadOnlyList<KeyValuePair<string, object?>> arguments)
    {
        LogLevel = logLevel;
        Message = message;
        Exception = exception;
        EventId = eventId;
        Arguments = arguments;
    }

    public LogLevel LogLevel { get; }
    public string Message { get; }
    public Exception? Exception { get; }
    public EventId EventId { get; }
    public IReadOnlyList<KeyValuePair<string, object?>> Arguments { get; }

    public T GetValueFromArguments<T>(string key)
    {
        var value = Arguments.Single(kvp => kvp.Key == key).Value;
        return (T)value!;
    }
}
