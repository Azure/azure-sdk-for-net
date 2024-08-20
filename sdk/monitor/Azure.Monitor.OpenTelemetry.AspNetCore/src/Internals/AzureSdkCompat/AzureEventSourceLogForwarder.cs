// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;
using Azure.Core.Shared;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Internals.AzureSdkCompat
{
    internal sealed class AzureEventSourceLogForwarder : IHostedService, IDisposable
    {
        internal static readonly AzureEventSourceLogForwarder Noop = new AzureEventSourceLogForwarder(null, null);
        private readonly ILoggerFactory _loggerFactory;
        private readonly HashSet<string> _eventSourceSet = new();
        private readonly List<string> _wildcardLoggerPatterns = new();

        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private readonly Func<EventSourceEvent, Exception, string> _formatMessage = FormatMessage;

        private AzureEventSourceListener _listener;

        public AzureEventSourceLogForwarder(ILoggerFactory loggerFactory, LoggerFilterOptions loggerFilterOptions)
        {
            _loggerFactory = loggerFactory;

            foreach (var rule in loggerFilterOptions?.Rules ?? Enumerable.Empty<LoggerFilterRule>())
            {
                AddRuleToSets(rule.CategoryName);
            }
        }

        private void AddRuleToSets(string categoryName)
        {
            if (!string.IsNullOrEmpty(categoryName) &&
                (categoryName.StartsWith("Azure.") || categoryName.StartsWith("Microsoft.Azure.")))
            {
                if (categoryName.EndsWith(".*"))
                {
                    // Add the wildcard prefix (without the ".*")
                    _wildcardLoggerPatterns.Add(ToEventSourceName(categoryName.Substring(0, categoryName.Length - 2)));
                }
                else
                {
                    _eventSourceSet.Add(ToEventSourceName(categoryName));
                }
            }
        }

        private void LogEvent(EventWrittenEventArgs eventData)
        {
            var logger = _loggers.GetOrAdd(eventData.EventSource.Name, name => _loggerFactory!.CreateLogger(ToLoggerName(name)));
            logger.Log(MapLevel(eventData.Level), new EventId(eventData.EventId, eventData.EventName), new EventSourceEvent(eventData), null, _formatMessage);
        }

        private void LogFilteringEvent(EventWrittenEventArgs eventData)
        {
            var logger = _loggers.GetOrAdd(eventData.EventSource.Name, name => _loggerFactory!.CreateLogger(ToLoggerName(name)));
            var isInEventSourceSet = IsInEventSourceSet(eventData.EventSource.Name);
            var logLevel = MapLevel(eventData.Level);

            // Log only if the event is not in the event source set or the log level is >= Warning
            if (isInEventSourceSet || logLevel >= LogLevel.Warning)
            {
                logger.Log(logLevel, new EventId(eventData.EventId, eventData.EventName), new EventSourceEvent(eventData), null, _formatMessage);
            }
        }

        private bool IsInEventSourceSet(string eventSourceName)
        {
            // Check for exact match
            if (_eventSourceSet.Contains(eventSourceName))
            {
                return true;
            }

            // Check if the eventSourceName starts with any wildcard pattern prefix
            return _wildcardLoggerPatterns.Count > 0 && _wildcardLoggerPatterns.Any(pattern => eventSourceName.StartsWith(pattern));
        }

        private static string ToLoggerName(string name)
        {
            return name.Replace('-', '.');
        }

        private static string ToEventSourceName(string name)
        {
            return name.Replace('.', '-');
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
                    AzureMonitorAspNetCoreEventSource.Log.MapLogLevelFailed(level);
                    return LogLevel.None;
            }
        }

        private static string FormatMessage(EventSourceEvent eventSourceEvent, Exception _) => eventSourceEvent.Format();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (_loggerFactory != null)
            {
                if (_eventSourceSet.Count == 0 && _wildcardLoggerPatterns.Count == 0)
                {
                    _listener ??= new AzureEventSourceListener((e, s) => LogEvent(e), EventLevel.Warning);
                }
                else
                {
                    _listener ??= new AzureEventSourceListener((e, s) => LogFilteringEvent(e), EventLevel.Verbose);
                }
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _listener?.Dispose();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _listener?.Dispose();
        }
    }
}
