// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    /// <summary>
    ///   Enables diagnostics instrumentation to be applied to <see cref="ServiceBusMessage" />
    ///   instances.
    /// </summary>
    ///
    internal static class ServiceBusMessageInstrumentation
    {
        /// <summary>
        ///   Applies diagnostics instrumentation to a given event.
        /// </summary>
        /// <param name="clientDiagnostics"></param>
        ///
        /// <param name="message">The event to instrument.</param>
        ///
        /// <returns><c>true</c> if the event was instrumented in response to this request; otherwise, <c>false</c>.</returns>
        ///
        public static bool InstrumentEvent(ClientDiagnostics clientDiagnostics, ServiceBusMessage message)
        {
            if (!message.Properties.ContainsKey(DiagnosticProperty.DiagnosticIdAttribute))
            {
                using DiagnosticScope messageScope = clientDiagnostics.CreateScope(DiagnosticProperty.EventActivityName);
                messageScope.AddAttribute(DiagnosticProperty.KindAttribute, DiagnosticProperty.InternalKind);
                messageScope.Start();

                Activity activity = Activity.Current;
                if (activity != null)
                {
                    message.Properties[DiagnosticProperty.DiagnosticIdAttribute] = activity.Id;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///   Extracts a diagnostic id from the given event.
        /// </summary>
        ///
        /// <param name="message">The event to instrument.</param>
        /// <param name="id">The value of the diagnostics identifier assigned to the event. </param>
        ///
        /// <returns><c>true</c> if the event was contained the diagnostic id; otherwise, <c>false</c>.</returns>
        ///
        public static bool TryExtractDiagnosticId(ServiceBusMessage message, out string id)
        {
            id = null;

            if (message.Properties.TryGetValue(DiagnosticProperty.DiagnosticIdAttribute, out var objectId) && objectId is string stringId)
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
        /// <param name="message">The event to reset.</param>
        ///
        public static void ResetEvent(ServiceBusMessage message) =>
            message.Properties.Remove(DiagnosticProperty.DiagnosticIdAttribute);
    }
}
