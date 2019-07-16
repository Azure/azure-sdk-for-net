using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Errors;
using Azure.Messaging.EventHubs.Metadata;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Dummy.
    /// </summary>
    ///
    [TestFixture]
    [NonParallelizable]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    class DiagnosticsLiveTests
    {
        private static ConcurrentQueue<(string eventName, object payload, Activity activity)> CreateEventQueue() =>
            new ConcurrentQueue<(string eventName, object payload, Activity activity)>();

        private static IDisposable SubscribeToEvents(IObserver<DiagnosticListener> listener) =>
            DiagnosticListener.AllListeners.Subscribe(listener);

        private static FakeDiagnosticListener CreateEventListener(ConcurrentQueue<(string eventName, object payload, Activity activity)> eventQueue) =>
            new FakeDiagnosticListener(kvp =>
            {
                if (kvp.Key == null || kvp.Value == null)
                {
                    return;
                }

                eventQueue?.Enqueue((kvp.Key, kvp.Value, Activity.Current));
            });

        private static T GetPropertyValueFromAnonymousTypeInstance<T>(object obj, string propertyName)
        {
            Type t = obj.GetType();
            PropertyInfo p = t.GetRuntimeProperty(propertyName);
            object propertyValue = p.GetValue(obj);

            Assert.That(propertyValue, Is.Not.Null);
            Assert.That(propertyValue, Is.AssignableTo<T>());

            return (T)propertyValue;
        }

        [Test]
        [Ignore("Injection step not working")]
        public async Task SendFiresEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var eventQueue = CreateEventQueue();

                    using (var listener = CreateEventListener(eventQueue))
                    using (var subscription = SubscribeToEvents(listener))
                    {
                        var parentActivity = new Activity("RandomName").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                        var eventData = new EventData(Encoding.UTF8.GetBytes("I hope it works!"));
                        var partitionKey = "AmIaGoodPartitionKey";

                        // Enable Send .Start & .Stop events.

                        listener.Enable((name, queueName, arg) => name.Contains("Send") && !name.EndsWith(".Exception"));

                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.False);
                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName), Is.False);

                        parentActivity.Start();

                        await producer.SendAsync(eventData, new SendOptions { PartitionKey = partitionKey });

                        parentActivity.Stop();

                        // Check Diagnostic-Id injection.

                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.True);

                        // Check Correlation-Context injection.

                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName), Is.True);
                        Assert.That(TrackOne.EventHubsDiagnosticSource.SerializeCorrelationContext(parentActivity.Baggage.ToList()), Is.EqualTo(eventData.Properties[TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName]));

                        Assert.That(eventQueue.TryDequeue(out var sendStart), Is.True);
                        AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, parentActivity, partitionKey, connectionString);

                        Assert.That(eventQueue.TryDequeue(out var sendStop), Is.True);
                        AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity, partitionKey, connectionString);

                        // There should be no more events to dequeue.

                        Assert.That(eventQueue.TryDequeue(out var evnt), Is.False);
                    }
                }
            }
        }

        [Test]
        public async Task SendDoesNotInjectContextWhenNoListeners()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var eventQueue = CreateEventQueue();

                    using (var listener = CreateEventListener(eventQueue))
                    using (var subscription = SubscribeToEvents(listener))
                    {
                        // TODO: is parentActivity necessary?
                        var parentActivity = new Activity("RandomName").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                        var eventData = new EventData(Encoding.UTF8.GetBytes("I hope it works!"));

                        // Disable all events.

                        listener.Disable();

                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.False);
                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName), Is.False);

                        parentActivity.Start();

                        await producer.SendAsync(eventData);

                        parentActivity.Stop();

                        // There should be no Diagnostic-Id injection.

                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.False);

                        // There should be no Correlation-Context injection.

                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName), Is.False);

                        // There should be no more events to dequeue.

                        Assert.That(eventQueue.TryDequeue(out var evnt), Is.False);
                    }
                }
            }
        }

        [Test]
        public async Task SendFiresExceptionEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var eventQueue = CreateEventQueue();

                    using (var listener = CreateEventListener(eventQueue))
                    using (var subscription = SubscribeToEvents(listener))
                    {
                        var parentActivity = new Activity("RandomName").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                        var eventData = new EventData(new byte[300 * 1024 * 1024]);
                        var partitionKey = "AmIaGoodPartitionKey";

                        // Enable Send .Exception & .Stop events.

                        listener.Enable((name, queueName, arg) => name.Contains("Send") && !name.EndsWith(".Start"));

                        parentActivity.Start();

                        // Try sending a large message. A SizeLimitException is expected.

                        Assert.That(async () => await producer.SendAsync(eventData, new SendOptions { PartitionKey = partitionKey }), Throws.InstanceOf<MessageSizeExceededException>());

                        parentActivity.Stop();

                        Assert.That(eventQueue.TryDequeue(out var exception), Is.True);
                        AssertSendException(exception.eventName, exception.payload, exception.activity, null, partitionKey, connectionString);

                        Assert.That(eventQueue.TryDequeue(out var sendStop), Is.True);
                        AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, null, partitionKey, connectionString);

                        Assert.That(sendStop.activity, Is.EqualTo(exception.activity));

                        // There should be no more events to dequeue.

                        Assert.That(eventQueue.TryDequeue(out var evnt), Is.False);
                    }
                }
            }
        }

        private static void AssertSendStart(string name, object payload, Activity activity, Activity parentActivity, string partitionKey, string connectionString, int eventCount = 1)
        {
            var connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            Assert.That(name, Is.EqualTo("Azure.Messaging.EventHubs.Send.Start"));
            AssertCommonPayloadProperties(payload, partitionKey, connectionStringProperties);

            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IEnumerable<TrackOne.EventData>>(payload, "EventDatas");
            Assert.That(eventDatas.Count, Is.EqualTo(eventCount));

            Assert.That(activity, Is.Not.Null);
            Assert.That(activity.Parent, Is.EqualTo(parentActivity));

            AssertTagMatches(activity, "peer.hostname", connectionStringProperties.Endpoint.Host);
            AssertTagMatches(activity, "eh.event_hub_name", connectionStringProperties.EventHubPath);

            if (partitionKey != null)
            {
                AssertTagMatches(activity, "eh.partition_key", partitionKey);
            }

            AssertTagMatches(activity, "eh.event_count", eventCount.ToString());
            AssertTagExists(activity, "eh.client_id");
        }

        private void AssertSendException(string name, object payload, Activity activity, Activity parentActivity, string partitionKey, string connectionString)
        {
            var connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            Assert.That(name, Is.EqualTo("Azure.Messaging.EventHubs.Send.Exception"));
            AssertCommonPayloadProperties(payload, partitionKey, connectionStringProperties);

            GetPropertyValueFromAnonymousTypeInstance<Exception>(payload, "Exception");

            Assert.That(activity, Is.Not.Null);

            if (parentActivity != null)
            {
                Assert.That(activity.Parent, Is.EqualTo(parentActivity));
            }

            // TODO: keep track one?
            // TODO: why doesn't IList work?
            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IEnumerable<TrackOne.EventData>>(payload, "EventDatas");
            Assert.That(eventDatas, Is.Not.Null);
        }

        private static void AssertSendStop(string name, object payload, Activity activity, Activity sendActivity, string partitionKey, string connectionString, bool isFaulted = false)
        {
            var connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            Assert.That(name, Is.EqualTo("Azure.Messaging.EventHubs.Send.Stop"));
            AssertCommonStopPayloadProperties(payload, partitionKey, isFaulted, connectionStringProperties); ;

            if (sendActivity != null)
            {
                Assert.That(activity, Is.EqualTo(sendActivity));
            }

            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IEnumerable<TrackOne.EventData>>(payload, "EventDatas");
            Assert.That(eventDatas, Is.Not.Null);
        }

        private static void AssertTagExists(Activity activity, string tagName)
        {
            Assert.That(activity.Tags.Select(t => t.Key).Contains(tagName), Is.True);
        }

        private static void AssertTagMatches(Activity activity, string tagName, string tagValue)
        {
            Assert.That(activity.Tags.Select(t => t.Key).Contains(tagName), Is.True);
            Assert.That(activity.Tags.Single(t => t.Key == tagName).Value, Is.EqualTo(tagValue));
        }

        private static void AssertCommonPayloadProperties(object eventPayload, string partitionKey, ConnectionStringProperties connectionStringProperties)
        {
            var endpoint = GetPropertyValueFromAnonymousTypeInstance<Uri>(eventPayload, "Endpoint");
            var entityPath = GetPropertyValueFromAnonymousTypeInstance<string>(eventPayload, "Entity");
            var pKey = GetPropertyValueFromAnonymousTypeInstance<string>(eventPayload, "PartitionKey");

            // endpoint is amqps://cooleventhubs.servicebus.windows.net/SendFiresExceptionEvents-a2fda415
            // connectionString is sb://cooleventhubs.servicebus.windows.net/
            // TODO: should we update the diagnostics output?
            var expectedEndpointStart = "amqps://" + connectionStringProperties.Endpoint.Host;

            Assert.That(endpoint.AbsoluteUri.StartsWith(expectedEndpointStart), Is.True);
            Assert.That(entityPath, Is.EqualTo(connectionStringProperties.EventHubPath));
            Assert.That(pKey, Is.EqualTo(partitionKey));
        }

        private static void AssertCommonStopPayloadProperties(object eventPayload, string partitionKey, bool isFaulted, ConnectionStringProperties connectionStringProperties)
        {
            AssertCommonPayloadProperties(eventPayload, partitionKey, connectionStringProperties);
        }
    }
}
