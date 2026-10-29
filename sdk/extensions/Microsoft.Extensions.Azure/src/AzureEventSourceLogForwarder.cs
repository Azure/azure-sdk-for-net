// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using Azure.Core.Shared;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// A type used to forward log messages from Azure SDK <see cref="EventSource"/> to <see cref="ILoggerFactory"/>.
    /// </summary>
    public sealed class AzureEventSourceLogForwarder: IDisposable
    {
        private readonly ILoggerFactory _loggerFactory;

        private readonly IOptionsMonitor<LoggerFilterOptions> _filterOptions;

        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private readonly Func<EventSourceEvent, Exception, string> _formatMessage = FormatMessage;

        private readonly Func<string, ILogger> _createLogger;

        private readonly bool _canNarrowLevels;

        private LogForwarderEventListener _listener;

        private IDisposable _filterOptionsRegistration;

        /// <summary>
        /// Initializes a new instance of <see cref="AzureComponentFactory"/> using a provided <see cref="ILoggerFactory"/>.
        /// </summary>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> to forward messages to.</param>
        public AzureEventSourceLogForwarder(ILoggerFactory loggerFactory)
            : this(loggerFactory, null)
        {
        }

        internal AzureEventSourceLogForwarder(ILoggerFactory loggerFactory, IOptionsMonitor<LoggerFilterOptions> filterOptions)
        {
            _loggerFactory = loggerFactory;
            _filterOptions = filterOptions;
            _createLogger = name => _loggerFactory.CreateLogger(ToLoggerName(name));

            // The levels that the event sources are enabled at can only be limited if they can be determined
            // from the logging filter rules and if there is a notification when those change. That is only
            // known to be the case for the default ILoggerFactory, otherwise all events are always enabled.
            _canNarrowLevels = filterOptions != null && loggerFactory?.GetType() == typeof(LoggerFactory);
        }

        /// <summary>
        /// Initiates the log forwarding from the Azure SDK event sources to a provided <see cref="ILoggerFactory"/>, call <see cref="Dispose"/> to stop forwarding.
        /// </summary>
        public void Start()
        {
            if (_listener != null)
            {
                return;
            }

            _listener = new LogForwarderEventListener(LogEvent, GetEventLevel);

            if (_canNarrowLevels)
            {
                // The levels depend on the logging filter rules, so re-evaluate them if they are reloaded.
                _filterOptionsRegistration = _filterOptions.OnChange((_, _) => _listener?.RequestRefresh());

                // The rules may have changed between the levels first being evaluated and the registration above.
                _listener.RequestRefresh();
            }
        }

        internal EventLevel? GetEventLevel(string eventSourceName)
        {
            if (_loggerFactory == null)
            {
                return null;
            }

            return _canNarrowLevels ?
                LoggerFilterLevels.GetEventLevel(_filterOptions.CurrentValue, ToLoggerName(eventSourceName)) :
                EventLevel.Verbose;
        }

        private ILogger GetLogger(string eventSourceName)
        {
            return _loggerFactory == null ? null : _loggers.GetOrAdd(eventSourceName, _createLogger);
        }

        private void LogEvent(EventWrittenEventArgs eventData)
        {
            if (GetLogger(eventData.EventSource.Name) is not { } logger)
            {
                return;
            }

            logger.Log(MapLevel(eventData.Level), new EventId(eventData.EventId, eventData.EventName), new EventSourceEvent(eventData), null, _formatMessage);
        }

        private static string ToLoggerName(string name)
        {
            return name.Replace('-', '.');
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _filterOptionsRegistration?.Dispose();
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
