// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    ///   The suite of live tests for the <see cref="TrackOne.EventHubsDiagnosticSource" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests have a dependency on live Azure services and may
    ///   incur costs for the associated Azure subscription.
    ///
    ///   Every send or receive call will trigger diagnostics events as
    ///   long as they are being listened to, making it possible for other
    ///   tests to interfere with these. For this reason, these tests are
    ///   marked as non-parallelizable.
    /// </remarks>
    ///
    [TestFixture]
    [NonParallelizable]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class DiagnosticsLiveTests
    {
        /// <summary>The maximum number of times that the receive loop should iterate to collect the expected number of messages.</summary>
        private const int ReceiveRetryLimit = 10;

        /// <summary>
        ///   Provides a new empty queue to store diagnostics events.
        /// </summary>
        ///
        /// <returns>An empty <see cref="ConcurrentQueue{T}" /> to store diagnostics events.</returns>
        ///
        private static ConcurrentQueue<(string eventName, object payload, Activity activity)> CreateEventQueue() =>
            new ConcurrentQueue<(string eventName, object payload, Activity activity)>();

        /// <summary>
        ///   Subscribes an <see cref="IObserver{T}" /> to <see cref="DiagnosticListener.AllListeners" /> so it
        ///   can locate the Azure.Messaging.EventHubs <see cref="DiagnosticListener" />.
        /// </summary>
        ///
        /// <param name="listener">The <see cref="IObserver{T}" /> that will subscribe to the Azure.Messaging.EventHubs <see cref="DiagnosticListener" />.</param>
        ///
        /// <returns>An <see cref="IDisposable" /> subscription. The subscription can be canceled by disposing of it.</returns>
        ///
        private static IDisposable SubscribeToEvents(IObserver<DiagnosticListener> listener) =>
            DiagnosticListener.AllListeners.Subscribe(listener);

        /// <summary>
        ///   Provides a new <see cref="FakeDiagnosticListener" /> that populates a given <see cref="ConcurrentQueue{T}" /> with
        ///   event information once enabled.
        /// </summary>
        ///
        /// <param name="eventQueue">The event queue to be populated.</param>
        ///
        /// <returns>A <see cref="FakeDiagnosticListener" /> that will populate the given event queue once enabled.</returns>
        ///
        /// <remarks>
        ///   <see cref="SubscribeToEvents" /> must be called before listening to events.
        /// </remarks>
        ///
        private static FakeDiagnosticListener CreateEventListener(ConcurrentQueue<(string eventName, object payload, Activity activity)> eventQueue) =>
            new FakeDiagnosticListener(kvp =>
            {
                if (kvp.Key == null || kvp.Value == null)
                {
                    return;
                }

                eventQueue?.Enqueue((kvp.Key, kvp.Value, Activity.Current));
            });

        /// <summary>
        ///   Extracts a property from a payload object given its type and name.
        /// </summary>
        ///
        /// <param name="obj">The payload object containing the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        ///
        /// <returns>The typed property extracted from the given payload object.</returns>
        ///
        /// <remarks>
        ///   If a non-string type property value is found to be <c>null</c>, an assertion
        ///   error is expected.
        /// </remarks>
        ///
        private static T GetPropertyValueFromAnonymousTypeInstance<T>(object obj, string propertyName)
        {
            Type t = obj.GetType();
            PropertyInfo p = t.GetRuntimeProperty(propertyName);
            object propertyValue = p.GetValue(obj);

            // If a null string property was found, return it.  This is necessary for testing
            // the ActivePartitionRouting property when no Partition Key or Partition Id was set.

            if (typeof(T) == typeof(string) && propertyValue == null)
            {
                return (T)propertyValue;
            }

            Assert.That(propertyValue, Is.Not.Null);
            Assert.That(propertyValue, Is.AssignableTo<T>());

            return (T)propertyValue;
        }

        /// <summary>
        ///   Verifies that the <see cref="TrackOne.EventHubsDiagnosticSource" /> fires
        ///   events as expected.
        /// </summary>
        ///
        [Test]
        [TestCase(null, false)]
        [TestCase(null, true)]
        [TestCase("AmIaGoodPartitionKey", false)]
        public async Task SendFiresEvents(string partitionKey,
                                          bool usePartitionId)
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    string partitionId = null;

                    if (usePartitionId)
                    {
                        partitionId = (await client.GetPartitionIdsAsync()).First();
                    }

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partitionId }))
                    {
                        var eventQueue = CreateEventQueue();

                        using (var listener = CreateEventListener(eventQueue))
                        using (var subscription = SubscribeToEvents(listener))
                        {
                            var parentActivity = new Activity("RandomName").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                            var eventData = new EventData(Encoding.UTF8.GetBytes("I hope it works!"));

                            // Enable Send .Start & .Stop events.

                            listener.Enable(name => name.Contains("Send") && !name.EndsWith(".Exception"));

                            // Assert that the properties we want to inject are not already included.

                            Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.False);
                            Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName), Is.False);

                            // Send the event.

                            parentActivity.Start();

                            await producer.SendAsync(eventData, new SendOptions { PartitionKey = partitionKey });

                            parentActivity.Stop();

                            // Check Diagnostic-Id injection.

                            Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.True);

                            // Check Correlation-Context injection.

                            Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName), Is.True);
                            Assert.That(TrackOne.EventHubsDiagnosticSource.SerializeCorrelationContext(parentActivity.Baggage.ToList()), Is.EqualTo(eventData.Properties[TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName]));

                            // Check diagnostics information.

                            Assert.That(eventQueue.TryDequeue(out var sendStart), Is.True);
                            AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, parentActivity, partitionKey ?? partitionId, connectionString);

                            Assert.That(eventQueue.TryDequeue(out var sendStop), Is.True);
                            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity, partitionKey ?? partitionId, connectionString);

                            // There should be no more events to dequeue.

                            Assert.That(eventQueue.TryDequeue(out var evnt), Is.False);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="TrackOne.EventHubsDiagnosticSource" /> fires
        ///   events as expected.
        /// </summary>
        ///
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
                        var parentActivity = new Activity("RandomName").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                        var eventData = new EventData(Encoding.UTF8.GetBytes("I hope it works!"));

                        // Disable all events.

                        listener.Disable();

                        // Assert that the properties we will check are not already included.

                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.False);
                        Assert.That(eventData.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName), Is.False);

                        // Send the event.

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

        /// <summary>
        ///   Verifies that the <see cref="TrackOne.EventHubsDiagnosticSource" /> fires
        ///   events as expected.
        /// </summary>
        ///
        [Test]
        [TestCase(null, false)]
        [TestCase(null, true)]
        [TestCase("AmIaGoodPartitionKey", false)]
        public async Task SendFiresExceptionEvents(string partitionKey,
                                                   bool usePartitionId)
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    string partitionId = null;

                    if (usePartitionId)
                    {
                        partitionId = (await client.GetPartitionIdsAsync()).First();
                    }

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partitionId }))
                    {
                        var eventQueue = CreateEventQueue();

                        using (var listener = CreateEventListener(eventQueue))
                        using (var subscription = SubscribeToEvents(listener))
                        {
                            var parentActivity = new Activity("RandomName").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                            var eventData = new EventData(new byte[1500000]);

                            // Enable Send .Exception & .Stop events.

                            listener.Enable(name => name.Contains("Send") && !name.EndsWith(".Start"));

                            // Try sending a large message. A SizeLimitException is expected.

                            parentActivity.Start();

                            Assert.That(async () => await producer.SendAsync(eventData, new SendOptions { PartitionKey = partitionKey }), Throws.InstanceOf<MessageSizeExceededException>());

                            parentActivity.Stop();

                            // Check diagnostics information.

                            Assert.That(eventQueue.TryDequeue(out var exception), Is.True);
                            AssertSendException(exception.eventName, exception.payload, exception.activity, parentActivity, partitionKey ?? partitionId, connectionString);

                            Assert.That(eventQueue.TryDequeue(out var sendStop), Is.True);
                            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, null, partitionKey ?? partitionId, connectionString, isFaulted: true);

                            Assert.That(sendStop.activity, Is.EqualTo(exception.activity));

                            // There should be no more events to dequeue.

                            Assert.That(eventQueue.TryDequeue(out var evnt), Is.False);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="TrackOne.EventHubsDiagnosticSource" /> fires
        ///   events as expected.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveFiresEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var eventQueue = CreateEventQueue();
                    var partition = (await client.GetPartitionIdsAsync()).First();
                    var consumerGroup = EventHubConsumer.DefaultConsumerGroupName;
                    EventPosition position = EventPosition.Latest;

                    using (var listener = CreateEventListener(eventQueue))
                    using (var subscription = SubscribeToEvents(listener))
                    await using (var consumer = client.CreateConsumer(consumerGroup, partition, position))
                    {
                        var payloadString = "Easter Egg";
                        var parentActivity = new Activity("RandomName").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                        var sendEvent = new EventData(Encoding.UTF8.GetBytes(payloadString));

                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        await consumer.ReceiveAsync(1, TimeSpan.Zero);

                        // Enable Send & Receive .Start & .Stop events.

                        listener.Enable(name => !name.EndsWith(".Exception"));

                        // Assert that the properties we want to inject are not already included.

                        Assert.That(sendEvent.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.False);
                        Assert.That(sendEvent.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName), Is.False);

                        // Send the event.

                        parentActivity.Start();

                        await producer.SendAsync(sendEvent);

                        // Receive the event; because there is some non-determinism in the messaging flow, the
                        // sent event may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var expectedEventsCount = 1;
                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < expectedEventsCount) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await consumer.ReceiveAsync(10, TimeSpan.FromMilliseconds(25)));
                        }

                        parentActivity.Stop();

                        // Validate the received event body.

                        var receivedEvent = receivedEvents.Single();
                        Assert.That(Encoding.UTF8.GetString(receivedEvent.Body.ToArray()), Is.EqualTo(payloadString));

                        // Check Diagnostic-Id injection.

                        Assert.That(sendEvent.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.True);
                        Assert.That(receivedEvent.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName), Is.True);
                        Assert.That(receivedEvent.Properties[TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName], Is.EqualTo(sendEvent.Properties[TrackOne.EventHubsDiagnosticSource.ActivityIdPropertyName]));

                        // Check Correlation-Context injection.

                        Assert.That(receivedEvent.Properties.ContainsKey(TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName), Is.True);
                        Assert.That(receivedEvent.Properties[TrackOne.EventHubsDiagnosticSource.CorrelationContextPropertyName], Is.EqualTo(TrackOne.EventHubsDiagnosticSource.SerializeCorrelationContext(parentActivity.Baggage.ToList())));

                        // Check diagnostics information.

                        Assert.That(eventQueue.TryDequeue(out var sendStart), Is.True);
                        Assert.That(eventQueue.TryDequeue(out var sendStop), Is.True);

                        Assert.That(eventQueue.TryDequeue(out var receiveStart), Is.True);
                        AssertReceiveStart(receiveStart.eventName, receiveStart.payload, receiveStart.activity, parentActivity, consumerGroup, position, partition, connectionString);

                        Assert.That(eventQueue.TryDequeue(out var receiveStop), Is.True);
                        AssertReceiveStop(receiveStop.eventName, receiveStop.payload, receiveStop.activity, receiveStart.activity, consumerGroup, partition, connectionString, relatedId: sendStop.activity.Id);

                        // There should be no more events to dequeue.

                        Assert.That(eventQueue.TryDequeue(out var evnt), Is.False);
                    }
                }
            }
        }

        /// <summary>
        ///   Asserts that the information received from a Send .Start event is accurate.
        /// </summary>
        ///
        /// <param name="name">The event name received from the event.</param>
        /// <param name="payload">The payload object received from the event.</param>
        /// <param name="activity">The activity received from the event.</param>
        /// <param name="parentActivity">The current <see cref="Activity" /> just before receiving. If <c>null</c>, the corresponding assertion will be skipped.</param>
        /// <param name="activePartitionRouting">The expected partition routing method in use. It may be <c>null</c>, a Partition Key or a Partition Id.</param>
        /// <param name="connectionString">The client's connection string.</param>
        /// <param name="eventCount">The expected number of events.</param>
        ///
        private static void AssertSendStart(string name, object payload, Activity activity, Activity parentActivity, string activePartitionRouting, string connectionString, int eventCount = 1)
        {
            var connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            // Check name.

            Assert.That(name, Is.EqualTo("Azure.Messaging.EventHubs.Send.Start"));

            // Check payload.

            AssertCommonPayloadProperties(payload, activePartitionRouting, connectionStringProperties);

            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IEnumerable<EventData>>(payload, "EventDatas");
            Assert.That(eventDatas.Count, Is.EqualTo(eventCount));

            // Check Activity and its tags.

            Assert.That(activity, Is.Not.Null);

            if (parentActivity != null)
            {
                Assert.That(activity.Parent, Is.EqualTo(parentActivity));
            }

            AssertTagMatches(activity, "peer.hostname", connectionStringProperties.Endpoint.Host);
            AssertTagMatches(activity, "eh.event_hub_name", connectionStringProperties.EventHubName);
            AssertTagMatches(activity, "eh.active_partition_routing", activePartitionRouting);
            AssertTagMatches(activity, "eh.event_count", eventCount.ToString());
            AssertTagExists(activity, "eh.client_id");
        }

        /// <summary>
        ///   Asserts that the information received from a Send .Exception event is accurate.
        /// </summary>
        ///
        /// <param name="name">The event name received from the event.</param>
        /// <param name="payload">The payload object received from the event.</param>
        /// <param name="activity">The activity received from the event.</param>
        /// <param name="parentActivity">The current <see cref="Activity" /> just before receiving. If <c>null</c>, the corresponding assertion will be skipped.</param>
        /// <param name="activePartitionRouting">The expected partition routing method in use. It may be <c>null</c>, a Partition Key or a Partition Id.</param>
        /// <param name="connectionString">The client's connection string.</param>
        ///
        private void AssertSendException(string name, object payload, Activity activity, Activity parentActivity, string activePartitionRouting, string connectionString)
        {
            var connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            // Check name.

            Assert.That(name, Is.EqualTo("Azure.Messaging.EventHubs.Send.Exception"));

            // Check payload.

            AssertCommonPayloadProperties(payload, activePartitionRouting, connectionStringProperties);

            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IEnumerable<EventData>>(payload, "EventDatas");
            Assert.That(eventDatas, Is.Not.Null);

            GetPropertyValueFromAnonymousTypeInstance<Exception>(payload, "Exception");

            // Check Activity.

            Assert.That(activity, Is.Not.Null);

            if (parentActivity != null)
            {
                Assert.That(activity.Parent, Is.EqualTo(parentActivity));
            }
        }

        /// <summary>
        ///   Asserts that the information received from a Send .Stop event is accurate.
        /// </summary>
        ///
        /// <param name="name">The event name received from the event.</param>
        /// <param name="payload">The payload object received from the event.</param>
        /// <param name="activity">The activity received from the event.</param>
        /// <param name="sendActivity">The activity received from the associated Send.Start event. If <c>null</c>, the corresponding assertion will be skipped.</param>
        /// <param name="activePartitionRouting">The expected partition routing method in use. It may be <c>null</c>, a Partition Key or a Partition Id.</param>
        /// <param name="connectionString">The client's connection string.</param>
        /// <param name="isFaulted"><c>true</c> if the expected <see cref="TaskStatus" /> is <see cref="TaskStatus.Faulted" />; <c>false</c> if it is <see cref="TaskStatus.RanToCompletion" />.</param>
        ///
        private static void AssertSendStop(string name, object payload, Activity activity, Activity sendActivity, string activePartitionRouting, string connectionString, bool isFaulted = false)
        {
            var connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            // Check name.

            Assert.That(name, Is.EqualTo("Azure.Messaging.EventHubs.Send.Stop"));

            // Check payload.

            AssertCommonStopPayloadProperties(payload, activePartitionRouting, isFaulted, connectionStringProperties);

            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IEnumerable<EventData>>(payload, "EventDatas");
            Assert.That(eventDatas, Is.Not.Null);

            // Check Activity.

            if (sendActivity != null)
            {
                Assert.That(activity, Is.EqualTo(sendActivity));
            }
        }

        /// <summary>
        ///   Asserts that the information received from a Receive .Start event is accurate.
        /// </summary>
        ///
        /// <param name="name">The event name received from the event.</param>
        /// <param name="payload">The payload object received from the event.</param>
        /// <param name="activity">The activity received from the event.</param>
        /// <param name="parentActivity">The current <see cref="Activity" /> just before receiving. If <c>null</c>, the corresponding assertion will be skipped.</param>
        /// <param name="consumerGroup">The consumer group of the receiving consumer.</param>
        /// <param name="position">The <see cref="EventPosition" /> used when creating the receiving consumer.</param>
        /// <param name="activePartitionRouting">The expected partition routing method in use. It may be <c>null</c>, a Partition Key or a Partition Id.</param>
        /// <param name="connectionString">The client's connection string.</param>
        ///
        private static void AssertReceiveStart(string name, object payload, Activity activity, Activity parentActivity, string consumerGroup, EventPosition position, string activePartitionRouting, string connectionString)
        {
            var connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            // Check name.

            Assert.That(name, Is.EqualTo("Azure.Messaging.EventHubs.Receive.Start"));

            // Check payload.

            AssertCommonPayloadProperties(payload, activePartitionRouting, connectionStringProperties);

            // Check Activity and its tags.

            Assert.That(activity, Is.Not.Null);

            if (parentActivity != null)
            {
                Assert.That(activity.Parent, Is.EqualTo(parentActivity));
            }

            AssertTagMatches(activity, "peer.hostname", connectionStringProperties.Endpoint.Host);
            AssertTagMatches(activity, "eh.event_hub_name", connectionStringProperties.EventHubName);
            AssertTagMatches(activity, "eh.active_partition_routing", activePartitionRouting);
            AssertTagMatches(activity, "eh.consumer_group", consumerGroup);
            AssertTagMatches(activity, "eh.start_offset", position.Offset);
            AssertTagMatches(activity, "eh.start_sequence_number", position.SequenceNumber?.ToString());
            AssertTagMatches(activity, "eh.start_date_time", position.EnqueuedTime?.UtcDateTime.ToString());
            AssertTagExists(activity, "eh.client_id");
        }

        /// <summary>
        ///   Asserts that the information received from a Receive .Stop event is accurate.
        /// </summary>
        ///
        /// <param name="name">The event name received from the event.</param>
        /// <param name="payload">The payload object received from the event.</param>
        /// <param name="activity">The activity received from the event.</param>
        /// <param name="receiveActivity">The activity received from the associated Receive.Start event. If <c>null</c>, the corresponding assertion will be skipped.</param>
        /// <param name="consumerGroup">The consumer group of the receiving consumer.</param>
        /// <param name="activePartitionRouting">The expected partition routing method in use. It may be <c>null</c>, a Partition Key or a Partition Id.</param>
        /// <param name="connectionString">The client's connection string.</param>
        /// <param name="eventCount">The expected number of events.</param>
        /// <param name="isFaulted"><c>true</c> if the expected <see cref="TaskStatus" /> is <see cref="TaskStatus.Faulted" />; <c>false</c> if it is <see cref="TaskStatus.RanToCompletion" />.</param>
        /// <param name="relatedId">The id of the related send activity. If <c>null</c> or empty, the corresponding assertion will be skipped.</param>
        ///
        private static void AssertReceiveStop(string name, object payload, Activity activity, Activity receiveActivity, string consumerGroup, string activePartitionRouting, string connectionString, int eventCount = 1, bool isFaulted = false, string relatedId = null)
        {
            var connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            // Check name.

            Assert.That(name, Is.EqualTo("Azure.Messaging.EventHubs.Receive.Stop"));

            // Check payload.

            AssertCommonStopPayloadProperties(payload, activePartitionRouting, isFaulted, connectionStringProperties);

            var payloadConsumerGroup = GetPropertyValueFromAnonymousTypeInstance<string>(payload, "ConsumerGroup");
            Assert.That(payloadConsumerGroup, Is.EqualTo(consumerGroup));

            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IEnumerable<EventData>>(payload, "EventDatas");
            Assert.That(eventDatas.Count, Is.EqualTo(eventCount));

            // Check Activity and its tags.

            if (receiveActivity != null)
            {
                Assert.That(activity, Is.EqualTo(receiveActivity));
            }

            if (!string.IsNullOrEmpty(relatedId))
            {
                var relatedToTag = activity.Tags.FirstOrDefault(tag => tag.Key == TrackOne.EventHubsDiagnosticSource.RelatedToTagName);

                Assert.That(relatedToTag, Is.Not.Null);
                Assert.That(relatedToTag.Value, Is.Not.Null);
                Assert.That(relatedToTag.Value.Contains(relatedId), Is.True);
            }

            AssertTagMatches(activity, "eh.event_count", eventCount.ToString());
        }

        /// <summary>
        ///   Asserts that an activity contains a specified tag.
        /// </summary>
        ///
        /// <param name="activity">The activity containing the tag to be checked.</param>
        /// <param name="tagName">The name of the tag.</param>
        ///
        private static void AssertTagExists(Activity activity, string tagName)
        {
            Assert.That(activity.Tags.Select(t => t.Key).Contains(tagName), Is.True);
        }

        /// <summary>
        ///   Asserts that an activity contains a specified tag and it matches a specified value.
        /// </summary>
        ///
        /// <param name="activity">The activity containing the tag to be checked.</param>
        /// <param name="tagName">The name of the tag.</param>
        /// <param name="tagValue">The expected value of the tag.</param>
        ///
        private static void AssertTagMatches(Activity activity, string tagName, string tagValue)
        {
            Assert.That(activity.Tags.Select(t => t.Key).Contains(tagName), Is.True);
            Assert.That(activity.Tags.Single(t => t.Key == tagName).Value, Is.EqualTo(tagValue));
        }

        /// <summary>
        ///   Asserts that the common payload properties of Send & Receive .Start & .Exception events contain the expected values.
        /// </summary>
        ///
        /// <param name="eventPayload">The payload object received from the event.</param>
        /// <param name="activePartitionRouting">The expected partition routing method in use. It may be <c>null</c>, a Partition Key or a Partition Id.</param>
        /// <param name="connectionStringProperties">The client's connection string properties.</param>
        ///
        private static void AssertCommonPayloadProperties(object eventPayload, string activePartitionRouting, ConnectionStringProperties connectionStringProperties)
        {
            var endpoint = GetPropertyValueFromAnonymousTypeInstance<Uri>(eventPayload, "Endpoint");
            var entityPath = GetPropertyValueFromAnonymousTypeInstance<string>(eventPayload, "Entity");
            var partitionRouting = GetPropertyValueFromAnonymousTypeInstance<string>(eventPayload, "ActivePartitionRouting");

            var expectedEndpointStart = "amqps://" + connectionStringProperties.Endpoint.Host;

            Assert.That(endpoint.AbsoluteUri.StartsWith(expectedEndpointStart), Is.True);
            Assert.That(entityPath, Is.EqualTo(connectionStringProperties.EventHubName));
            Assert.That(partitionRouting, Is.EqualTo(activePartitionRouting));
        }

        /// <summary>
        ///   Asserts that the common payload properties of Send & Receive .Stop events contain the expected values.
        /// </summary>
        ///
        /// <param name="eventPayload">The payload object received from the event.</param>
        /// <param name="activePartitionRouting">The expected partition routing method in use. It may be <c>null</c>, a Partition Key or a Partition Id.</param>
        /// <param name="isFaulted"><c>true</c> if the expected <see cref="TaskStatus" /> is <see cref="TaskStatus.Faulted" />; <c>false</c> if it is <see cref="TaskStatus.RanToCompletion" />.</param>
        /// <param name="connectionStringProperties">The client's connection string properties.</param>
        ///
        private static void AssertCommonStopPayloadProperties(object eventPayload, string activePartitionRouting, bool isFaulted, ConnectionStringProperties connectionStringProperties)
        {
            var expectedStatus = isFaulted ? TaskStatus.Faulted : TaskStatus.RanToCompletion;

            AssertCommonPayloadProperties(eventPayload, activePartitionRouting, connectionStringProperties);

            var status = GetPropertyValueFromAnonymousTypeInstance<TaskStatus>(eventPayload, "Status");
            Assert.That(status, Is.EqualTo(expectedStatus));
        }
    }
}
