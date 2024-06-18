// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Microsoft.Extensions.Logging;

namespace ClientModel.Tests;

[EventSource(Name = "ClientModel.Tests.TestLoggingEventSource")]
public class TestLoggingEventSource : EventSource
{
    public static readonly TestLoggingEventSource Log = new();

    private TestLoggingEventSource() : base(EventSourceSettings.EtwSelfDescribingEventFormat)
    {
    }

    internal void LogMessage(LogLevel level, string loggerName, int eventId, string? eventName, Exception? exception, IEnumerable<KeyValuePair<string, string?>> arguments)
    {
        if (IsEnabled())
        {
            WriteEvent(eventId, level, loggerName, eventName, exception, arguments);
        }
    }
}
