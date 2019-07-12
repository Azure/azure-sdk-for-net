using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using TrackOne;

namespace Azure.Messaging.EventHubs.Tests
{
    internal static class DiagnosticsCommon
    {
        public static ConcurrentQueue<(string eventName, object payload, Activity activity)> CreateEventQueue() =>
            new ConcurrentQueue<(string eventName, object payload, Activity activity)>();

        public static IDisposable SubscribeToEvents(IObserver<DiagnosticListener> listener) =>
            DiagnosticListener.AllListeners.Subscribe(listener);

        public static FakeDiagnosticListener CreateEventListener(string entityName, ConcurrentQueue<(string eventName, object payload, Activity activity)> eventQueue) =>
            new FakeDiagnosticListener(kvp =>
            {
                if (kvp.Key == null || kvp.Value == null)
                {
                    return;
                }

                eventQueue?.Enqueue((kvp.Key, kvp.Value, Activity.Current));
            });

        public static void AssertSendStart(string name, object payload, Activity activity, Activity parentActivity, string partitionKey, EventHubsConnectionStringBuilder connectionStringBuilder, int eventCount = 1)
        {
        }

        public static void AssertSendStop(string name, object payload, Activity activity, Activity sendActivity, string partitionKey, EventHubsConnectionStringBuilder connectionStringBuilder, bool isFaulted = false)
        {
        }
    }
}
