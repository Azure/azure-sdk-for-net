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
    private readonly ILoggerFactory _loggerFactory;

    private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

    private readonly Func<EventSourceEvent, Exception?, string> _formatMessage = FormatMessage;

    private ClientModelEventListener? _listener;

    public LogForwarder(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }

    public void Start()
    {
        _listener ??= new ClientModelEventListener((e, s) => LogEvent(e), EventLevel.Verbose);
    }

    private void LogEvent(EventWrittenEventArgs eventData)
    {
        if (_loggerFactory == null)
        {
            return;
        }

        var logger = _loggers.GetOrAdd(eventData.EventSource.Name, name => _loggerFactory.CreateLogger(ToLoggerName(name)));
        logger.Log(MapLevel(eventData.Level), new EventId(eventData.EventId, eventData.EventName), new EventSourceEvent(eventData), null, _formatMessage);
    }

    private static string ToLoggerName(string name)
    {
        return name.Replace('-', '.');
    }

    /// <inheritdoc />
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
