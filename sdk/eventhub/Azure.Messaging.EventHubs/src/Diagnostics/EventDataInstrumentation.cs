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
        public static ClientDiagnostics ClientDiagnostics { get; } =  new ClientDiagnostics(true);

        /// <summary>
        ///   Applies diagnostics instrumentation to a given event.
        /// </summary>
        ///
        /// <param name="eventData">The event to instrument.</param>
        ///
        /// <returns><c>true</c> if the event was instrumented in response to this request; otherwise, <c>false</c>.</returns>
        ///
        public static bool InstrumentEvent(EventData eventData)
        {
            if (!eventData.Properties.ContainsKey(DiagnosticProperty.DiagnosticIdAttribute))
            {
                using DiagnosticScope messageScope = ClientDiagnostics.CreateScope(DiagnosticProperty.EventActivityName);
                messageScope.AddAttribute("kind", "internal");
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

        public static bool TryExtractDiagnosticId(EventData eventData, out string id)
        {
            id = null;

            if (eventData.Properties.TryGetValue(DiagnosticProperty.DiagnosticIdAttribute, out var objectId) && objectId is string stringId)
            {
                id = stringId;
                return true;
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
