// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;
using Azure.Core.Shared;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// A type used to forward log messages from Azure SDK <see cref="EventSource"/> to <see cref="ILoggerFactory"/>.
    /// </summary>
    public sealed class AzureEventSourceLogForwarder: IDisposable
    {
        private readonly ILoggerFactory _loggerFactory;

        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private readonly Func<EventSourceEvent, Exception, string> _formatMessage = FormatMessage;

        private AzureEventSourceListener _listener;

        /// <summary>
        /// Initializes a new instance of <see cref="AzureComponentFactory"/> using a provided <see cref="ILoggerFactory"/>.
        /// </summary>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> to forward messages to.</param>
        public AzureEventSourceLogForwarder(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        /// <summary>
        /// Initiates the log forwarding from the Azure SDK event sources to a provided <see cref="ILoggerFactory"/>, call <see cref="Dispose"/> to stop forwarding.
        /// </summary>
        public void Start()
        {
            _listener ??= new AzureEventSourceListener(LogEvent, EventLevel.Verbose);
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

        private static string FormatMessage(EventSourceEvent eventSourceEvent, Exception _) => eventSourceEvent.Format();
    }
}
