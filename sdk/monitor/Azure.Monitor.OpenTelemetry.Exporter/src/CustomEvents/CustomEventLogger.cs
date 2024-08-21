// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Azure.Monitor.OpenTelemetry.CustomEvents
{
    /// <summary>
    /// Default logger for logging custom events telemetry.
    /// </summary>
    public sealed class CustomEventLogger : ICustomEventLogger
    {
        private static readonly Func<IReadOnlyList<KeyValuePair<string, object?>>?, Exception?, string> s_formatter = (state, ex) =>
        {
            return "CustomEvent";
        };

        private readonly ILogger _logger;

        /// <summary>
        /// Custom events.
        /// </summary>
        /// <param name="loggerFactory">LoggerFactory instance for logging events.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CustomEventLogger(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));

            _logger = loggerFactory.CreateLogger("Azure.Monitor.OpenTelemetry.CustomEvents");
        }

        /// <inheritdoc/>
        public void TrackEvent(string name, IReadOnlyList<KeyValuePair<string, object?>>? attributes = null)
        {
            // Setting the loglevel to critical to ensure events are not filtered.
            _logger.Log(LogLevel.Critical, eventId: new EventId(1, name), attributes, exception: null, formatter: s_formatter);
        }
    }
}
