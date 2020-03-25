// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Core.Pipeline;

namespace Azure.Messaging.EventHubs.Diagnostics
{
    /// <summary>
    ///   Enables diagnostics instrumentation to be applied to <see cref="EventData" />
    ///   instances.
    /// </summary>
    ///
    internal class EventDataInstrumentation
    {
        /// <summary>
        ///   Applies diagnostics instrumentation to a given event.
        /// </summary>
        ///
        /// <param name="clientDiagnostics">The client diagnostics instance responsible for managing scope.</param>
        /// <param name="eventData">The event to instrument.</param>
        ///
        /// <returns><c>true</c> if the event was instrumented in response to this request; otherwise, <c>false</c>.</returns>
        ///
        public static bool InstrumentEvent(ClientDiagnostics clientDiagnostics,
                                           EventData eventData)
        {
            if (!eventData.Properties.ContainsKey(DiagnosticProperty.DiagnosticIdAttribute))
            {
                using DiagnosticScope messageScope = clientDiagnostics.CreateScope(DiagnosticProperty.EventActivityName);
                messageScope.Start();

                var activity = Activity.Current;
                if (activity != null)
                {
                    eventData.Properties[DiagnosticProperty.DiagnosticIdAttribute] = activity.Id;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///   Resets the instrumentation associated with a given event.
        /// </summary>
        ///
        /// <param name="eventData">The event to reset.</param>
        ///
        public static void ResetEvent(EventData eventData) =>
            eventData.Properties.Remove(DiagnosticProperty.DiagnosticIdAttribute);
    }
}
