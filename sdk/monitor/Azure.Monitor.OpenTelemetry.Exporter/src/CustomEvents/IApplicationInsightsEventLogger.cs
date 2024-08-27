// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Events
{
    /// <summary>
    /// An interface for logging custom events telemetry.
    /// </summary>
    public interface IApplicationInsightsEventLogger
    {
        /// <summary>
        /// Tracks Application Insights Custom Events.
        /// </summary>
        /// <param name="name">Name of the Custom Event.</param>
        /// <param name="attributes">Custom dimensions of the Event.</param>
        /// <remarks>
        /// <para>
        /// This API is intended for use only in specific cases where you need to log data as <a href="https://learn.microsoft.com/azure/azure-monitor/app/api-custom-events-metrics#trackevent">Application Insights Custom Events</a>.
        /// For general logging purposes, it is recommended to use <a href="https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger">ILogger</a>.
        /// </para>
        /// </remarks>
        public void TrackEvent(string name, IReadOnlyList<KeyValuePair<string, object?>>? attributes = null);
    }
}
