// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.Messaging.EventHubs.Diagnostics
{
    internal class EventInstrumentation
    {
        private const string DiagnosticIdProperty = "Diagnostic-Id";

        public static bool InstrumentEvent(EventData eventData, Activity activity)
        {
            if (activity != null &&
                !eventData.Properties.ContainsKey(DiagnosticIdProperty))
            {
                eventData.Properties[DiagnosticIdProperty] = activity.Id;
                return true;
            }

            return false;
        }

        public static void ResetEvent(EventData eventData)
        {
            eventData.Properties.Remove(DiagnosticIdProperty);
        }
    }
}
