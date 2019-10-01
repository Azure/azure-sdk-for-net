// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Linq;
using Azure.Core.Pipeline;

namespace Azure.Messaging.EventHubs.Diagnostics
{

    public class A
    {
        private byte[] A;
        private byte[] B;


    }
    /// <summary>
    ///   Enables diagnostics instrumentation to be applied to <see cref="EventData" />
    ///   instances.
    /// </summary>
    ///
    public static class EventDataDiagnostics
    {bool Compare(byte[] a, byte[] b)
        {
            if (!Equals(a, b) && (a == null || b == null || !a.SequenceEqual(b)))
            {
                return false;
            }

            return true;
        }


        /// <summary>The client diagnostics instance responsible for managing scope.</summary>
        internal static ClientDiagnostics ClientDiagnostics { get; } = new ClientDiagnostics(true);


        /// <summary>
        ///   Applies diagnostics instrumentation to a given event.
        /// </summary>
        ///
        /// <param name="eventData">The event to instrument.</param>
        ///
        /// <returns><c>true</c> if the event was instrumented in response to this request; otherwise, <c>false</c>.</returns>
        ///
        internal static bool InstrumentEvent(EventData eventData)
        {

            if (!eventData.Properties.ContainsKey(DiagnosticProperty.DiagnosticIdAttribute))
            {
                using DiagnosticScope messageScope = ClientDiagnostics.CreateScope(DiagnosticProperty.EventActivityName);
                messageScope.AddAttribute("kind", "internal");
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
        internal static bool TryExtractDiagnosticId(EventData eventData, out string id)
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
        internal static void ResetEvent(EventData eventData) =>
            eventData.Properties.Remove(DiagnosticProperty.DiagnosticIdAttribute);
    }
}
