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
    internal static class EventDataInstrumentation
    {
        /// <summary>The client diagnostics instance responsible for managing scope.</summary>
        public static DiagnosticScopeFactory ScopeFactory { get; } = new DiagnosticScopeFactory("Azure.Messaging.EventHubs", "Microsoft.EventHub", true);

        /// <summary>
        ///   Applies diagnostics instrumentation to a given event.
        /// </summary>
        ///
        /// <param name="eventData">The event to instrument.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to use for instrumentation.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the event with.</param>
        ///
        /// <returns><c>true</c> if the event was instrumented in response to this request; otherwise, <c>false</c>.</returns>
        ///
        public static bool InstrumentEvent(EventData eventData,
                                           string fullyQualifiedNamespace,
                                           string eventHubName)
        {
            if (!eventData.Properties.ContainsKey(DiagnosticProperty.DiagnosticIdAttribute))
            {
                using DiagnosticScope messageScope = ScopeFactory.CreateScope(DiagnosticProperty.EventActivityName);
                messageScope.AddAttribute(DiagnosticProperty.KindAttribute, DiagnosticProperty.ProducerKind);
                messageScope.AddAttribute(DiagnosticProperty.EventHubAttribute, eventHubName);
                messageScope.AddAttribute(DiagnosticProperty.EndpointAttribute, fullyQualifiedNamespace);
                messageScope.Start();

                Activity activity = Activity.Current;
                if (activity != null)
                {
                    eventData.Properties[DiagnosticProperty.DiagnosticIdAttribute] = activity.Id;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///   Extracts a diagnostic id from the given event.
        /// </summary>
        ///
        /// <param name="eventData">The event to instrument.</param>
        /// <param name="id">The value of the diagnostics identifier assigned to the event. </param>
        ///
        /// <returns><c>true</c> if the event was contained the diagnostic id; otherwise, <c>false</c>.</returns>
        ///
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
