// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Internal;

internal class LogForwarder
{
    private readonly ILogger _logger;

    private readonly Func<EventSourceEvent, Exception?, string> _formatMessage = FormatMessage;

    private ClientModelEventListener? _listener;

    public LogForwarder(ILogger logger)
    {
        _logger = logger;
    }

    public void Start()
    {
        _listener ??= new ClientModelEventListener((e, s) => LogEvent(e));
    }

    private void LogEvent(EventWrittenEventArgs eventData)
    {
        if (_logger == null)
        {
            return;
        }
        _logger.Log(MapLevel(eventData.Level), new EventId(eventData.EventId, eventData.EventName), new EventSourceEvent(eventData), null, _formatMessage);
    }

    public void Dispose()
    {
        _listener?.Dispose();
    }

    private static LogLevel MapLevel(EventLevel level)
    {
        switch (level)
        {
            case EventLevel.Critical:
                return LogLevel.Critical;
            case EventLevel.Error:
                return LogLevel.Error;
            case EventLevel.Informational:
                return LogLevel.Information;
            case EventLevel.Verbose:
                return LogLevel.Debug;
            case EventLevel.Warning:
                return LogLevel.Warning;
            case EventLevel.LogAlways:
                return LogLevel.Information;
            default:
                throw new ArgumentOutOfRangeException(nameof(level), level, null);
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

    private static string FormatMessage(EventSourceEvent eventSourceEvent, Exception? _) => eventSourceEvent.Format();
}
