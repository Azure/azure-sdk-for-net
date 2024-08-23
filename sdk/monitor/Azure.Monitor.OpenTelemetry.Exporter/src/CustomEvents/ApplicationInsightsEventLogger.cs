// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Azure.Monitor.OpenTelemetry.Events
{
    /// <summary>
    /// Default logger for logging Application Insights custom events.
    /// </summary>
    public sealed class ApplicationInsightsEventLogger : IApplicationInsightsEventLogger
    {
        private const string EventLoggerName = "Azure.Monitor.OpenTelemetry.CustomEvents";
        private static readonly Func<IReadOnlyList<KeyValuePair<string, object?>>?, Exception?, string> s_formatter = (state, ex) =>
        {
            return "Application Insights Custom Event";
        };

        private readonly ILogger _logger;

        /// <summary>
        /// Creates an instance of CustomEventLogger to log custom events.
        /// </summary>
        /// <param name="loggerFactory">LoggerFactory instance for logging events.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApplicationInsightsEventLogger(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));

            _logger = loggerFactory.CreateLogger(EventLoggerName);
        }

        // TODO: Follow up to check if nullables are ok.
        /// <inheritdoc/>
        public void TrackEvent(string name, IReadOnlyList<KeyValuePair<string, object?>>? attributes = null)
        {
            _logger.Log(LogLevel.Information, eventId: new EventId(1, name), attributes, exception: null, formatter: s_formatter);
        }
    }
}
