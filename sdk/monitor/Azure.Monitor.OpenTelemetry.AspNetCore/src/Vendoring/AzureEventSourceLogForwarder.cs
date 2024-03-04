// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;
using Azure.Core.Shared;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    internal sealed class AzureEventSourceLogForwarder : IHostedService
    {
        internal static readonly AzureEventSourceLogForwarder Noop = new AzureEventSourceLogForwarder();
        private readonly ILoggerFactory _loggerFactory;

        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private readonly Func<EventSourceEvent, Exception, string> _formatMessage = FormatMessage;

        private AzureEventSourceListener _listener;

        private AzureEventSourceLogForwarder()
        {
            _loggerFactory = null;
            _listener = null;
        }

        public AzureEventSourceLogForwarder(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        private void LogEvent(EventWrittenEventArgs eventData)
        {
            var logger = _loggers.GetOrAdd(eventData.EventSource.Name, name => _loggerFactory!.CreateLogger(ToLoggerName(name)));
            logger.Log(MapLevel(eventData.Level), new EventId(eventData.EventId, eventData.EventName), new EventSourceEvent(eventData), null, _formatMessage);
        }

        private static string ToLoggerName(string name)
        {
            return name.Replace('-', '.');
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

        private static string FormatMessage(EventSourceEvent eventSourceEvent, Exception exception)
        {
            return EventSourceEventFormatting.Format(eventSourceEvent.EventData);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (_loggerFactory != null)
            {
                _listener ??= new AzureEventSourceListener((e, s) => LogEvent(e), EventLevel.Verbose);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _listener?.Dispose();
            return Task.CompletedTask;
        }

        private readonly struct EventSourceEvent : IReadOnlyList<KeyValuePair<string, object>>
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
