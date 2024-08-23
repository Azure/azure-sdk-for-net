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
        /// Tracks Application Insights custom events.
        /// </summary>
        /// <param name="name">Name of the CustomEvent.</param>
        /// <param name="attributes">Custom dimensions of the event.</param>
        public void TrackEvent(string name, IReadOnlyList<KeyValuePair<string, string?>>? attributes = null);
    }
}
