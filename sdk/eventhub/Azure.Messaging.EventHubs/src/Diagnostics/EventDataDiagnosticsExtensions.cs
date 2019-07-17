// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.Messaging.EventHubs.Diagnostics
{
    /// <summary>
    ///   Diagnostic extension methods for <see cref="EventData"/>.
    /// </summary>
    ///
    internal static class EventDataDiagnosticsExtensions
    {
        /// <summary>
        ///   Creates <see cref="Activity"/> based on the tracing context stored in the <see cref="EventData"/>.
        /// </summary>
        ///
        /// <param name="eventData">The event received from EventHub.</param>
        /// <param name="activityName">Optional Activity name.</param>
        ///
        /// <returns>New <see cref="Activity"/> with tracing context.</returns>
        ///
        public static Activity ExtractActivity(this EventData eventData, string activityName = null)
        {
            static TrackOne.EventData TransformEvent(EventData eventData) =>
                new TrackOne.EventData(eventData.Body.ToArray())
                {
                    Properties = eventData.Properties
                };

            return TrackOne.EventDataDiagnosticExtensions.ExtractActivity(TransformEvent(eventData), activityName);
        }
    }
}
