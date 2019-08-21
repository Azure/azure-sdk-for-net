// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Core.Pipeline;

namespace Azure.Messaging.EventHubs.Diagnostics
{
    internal class EventDataInstrumentation
    {
        private const string DiagnosticIdProperty = "Diagnostic-Id";

        private static readonly string MessageActivityName = $"{nameof(Azure)}.{nameof(Messaging)}.{nameof(EventHubs)}.Message";

        public static bool InstrumentEvent(ClientDiagnostics clientDiagnostics, EventData eventData)
        {
            if (!eventData.Properties.ContainsKey(DiagnosticIdProperty))
            {
                using DiagnosticScope messageScope = clientDiagnostics.CreateScope(MessageActivityName);
                messageScope.AddAttribute("kind", "internal");
                messageScope.Start();

                var activity = Activity.Current;
                if (activity != null)
                {
                    eventData.Properties[DiagnosticIdProperty] = activity.Id;
                    return true;
                }
            }

            return false;
        }

        public static void ResetEvent(EventData eventData)
        {
            eventData.Properties.Remove(DiagnosticIdProperty);
        }
    }
}
