// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.Azure
{
    internal class EventSourceLogForwarder: EventListener
    {
        private readonly Func<EventSource, bool> _filter;

        private readonly ILoggerFactory _loggerFactory;

        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private readonly List<EventSource> _eventSources = new List<EventSource>();

        private readonly Func<EventSourceEvent, Exception, string> _formatMessage = FormatMessage;

        public EventSourceLogForwarder(ILoggerFactory loggerFactory = null)
        {
            _filter = eventSource => eventSource.Name == "AzureSDK";
            _loggerFactory = loggerFactory;

            foreach (var eventSource in _eventSources)
            {
                OnEventSourceCreated(eventSource);
            }

            _eventSources.Clear();
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            base.OnEventSourceCreated(eventSource);

            if (_filter == null)
            {
                _eventSources.Add(eventSource);
            }
            else if (_filter(eventSource) && _loggerFactory != null)
            {
                var logger = _loggerFactory.CreateLogger(eventSource.Name);
                _loggers[eventSource.Name] = logger;
                EnableEvents(eventSource, EventLevel.Verbose);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (!_loggers.TryGetValue(eventData.EventSource.Name, out ILogger logger))
            {
                return;
            }

            logger.Log(MapLevel(eventData.Level), new EventId(eventData.EventId, eventData.EventName), new EventSourceEvent(eventData), null, _formatMessage);
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
            var eventData = eventSourceEvent.EventData;
            if (eventData.Message != null)
            {
                return string.Format(CultureInfo.InvariantCulture, eventData.Message, eventData.Payload);
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(eventData.EventName).Append(" ");

            foreach (var pair in eventSourceEvent)
            {
                stringBuilder.AppendLine();
                stringBuilder.Append(pair.Key).Append(" = ").Append(pair.Value);
            }

            return stringBuilder.ToString();
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
