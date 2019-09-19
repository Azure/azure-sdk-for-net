// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;
using Azure.Core.Shared;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.Azure
{
    internal class EventSourceLogForwarder: IDisposable
    {
        private readonly ILoggerFactory _loggerFactory;

        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private readonly Func<EventSourceEvent, Exception, string> _formatMessage = FormatMessage;

        private readonly AzureEventSourceListener _listener;

        public EventSourceLogForwarder(ILoggerFactory loggerFactory = null)
        {
            _loggerFactory = loggerFactory;
            _listener = new AzureEventSourceListener((e, s) => LogEvent(e), EventLevel.Verbose);
        }

        private void LogEvent(EventWrittenEventArgs eventData)
        {
            var logger = _loggers.GetOrAdd(eventData.EventSource.Name, name => _loggerFactory.CreateLogger(name));
            logger.Log(MapLevel(eventData.Level), new EventId(eventData.EventId, eventData.EventName), new EventSourceEvent(eventData), null, _formatMessage);
        }

        public void Dispose()
        {
            _listener.Dispose();
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }

        private static string FormatMessage(EventSourceEvent eventSourceEvent, Exception exception)
        {
            return EventSourceEventFormatting.Format(eventSourceEvent.EventData);
        }

        private struct EventSourceEvent: IReadOnlyList<KeyValuePair<string, object>>
        {
            public EventWrittenEventArgs EventData { get; }

            public EventSourceEvent(EventWrittenEventArgs eventData)
            {
                EventData = eventData;
            }

            public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
            {
                for (int i = 0; i < Count; i++)
                {
                    yield return new KeyValuePair<string, object>(EventData.PayloadNames[i], EventData.Payload[i]);
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public int Count => EventData.PayloadNames.Count;

            public KeyValuePair<string, object> this[int index] => new KeyValuePair<string, object>(EventData.PayloadNames[index], EventData.Payload[index]);
        }
    }
}
