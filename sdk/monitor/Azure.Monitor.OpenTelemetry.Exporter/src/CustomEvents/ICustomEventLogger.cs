// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.CustomEvents
{
    /// <summary>
    /// An interface for logging custom events telemetry.
    /// </summary>
    public interface ICustomEventLogger
    {
        /// <summary>
        /// Tracks custom events.
        /// </summary>
        /// <param name="name">Name of the CustomEvent.</param>
        /// <param name="attributes">Custom dimensions of the event.</param>
        public void TrackEvent(string name, IReadOnlyList<KeyValuePair<string, object?>>? attributes = null);
    }
}
