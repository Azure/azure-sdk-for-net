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
        private readonly bool _hasAzureLoggerFilterOptionsRules = false;

        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private readonly Func<EventSourceEvent, Exception, string> _formatMessage = FormatMessage;

        private AzureEventSourceListener _listener;

        public AzureEventSourceLogForwarder(ILoggerFactory loggerFactory, LoggerFilterOptions loggerFilterOptions)
        {
            _loggerFactory = loggerFactory;

            foreach (var rule in loggerFilterOptions?.Rules ?? Enumerable.Empty<LoggerFilterRule>())
            {
                if (!string.IsNullOrEmpty(rule.CategoryName)
                    && (rule.CategoryName.StartsWith("Azure.") || rule.CategoryName.StartsWith("Microsoft.Azure.")))
                {
                    _hasAzureLoggerFilterOptionsRules = true;
                }
            }
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
                    AzureMonitorAspNetCoreEventSource.Log.MapLogLevelFailed(level);
                    return LogLevel.None;
            }
        }

        private static string FormatMessage(EventSourceEvent eventSourceEvent, Exception _) => eventSourceEvent.Format();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (_loggerFactory != null)
            {
                // Setting even a single custom filter for Azure SDK logs will reset the default warning level and switch to listening at the verbose level.
                // This gives the customer full control over the log levels for all Azure SDK components.
                _listener ??= new AzureEventSourceListener(LogEvent, _hasAzureLoggerFilterOptionsRules ? EventLevel.Verbose : EventLevel.Warning);
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
