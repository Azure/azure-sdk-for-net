// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

#pragma warning disable xUnit2002

    [CollectionDefinition(nameof(DiagnosticsTests), DisableParallelization = true)]
    [Collection(nameof(DiagnosticsTests))]
    public class DiagnosticsTests : ClientTestBase
    {
        protected const int MaxWaitSec = 10;
        protected readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(MaxWaitSec);

        private ConcurrentQueue<(string eventName, object payload, Activity activity)> CreateEventQueue() =>
            new ConcurrentQueue<(string eventName, object payload, Activity activity)>();

        private IDisposable SubscribeToEvents(IObserver<DiagnosticListener> listener) =>
            DiagnosticListener.AllListeners.Subscribe(listener);

        private FakeDiagnosticListener CreateEventListener(string entityName, ConcurrentQueue<(string eventName, object payload, Activity activity)> eventQueue) =>
            new FakeDiagnosticListener(kvp =>
            {
                if (kvp.Key == null || kvp.Value == null)
                {
                    TestUtility.Log("Diagnostics Problem: Missing diagnostics information.  Ignoring.");
                    return;
                }

                // If an entity name was provided, log those payloads where the target is explicitly not associated with the entity.
                if (!String.IsNullOrEmpty(entityName))
                {
                    var targetEntity = this.GetPropertyValueFromAnonymousTypeInstance<string>(kvp.Value, "Entity", true);

                    if (String.IsNullOrEmpty(targetEntity) || !String.Equals(targetEntity, entityName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        TestUtility.Log($"Diagnostics Mismatch: Interested in Entity [{ entityName }], received [{ kvp.Key }] for Target [{ targetEntity }].");
                    }
                }

                eventQueue?.Enqueue((kvp.Key, kvp.Value, Activity.Current));
            });

        private T GetPropertyValueFromAnonymousTypeInstance<T>(object obj, string propertyName, bool canValueBeNull = false)
        {
            Type t = obj.GetType();

            PropertyInfo p = t.GetRuntimeProperty(propertyName);

            object propertyValue = p.GetValue(obj);
            if (!canValueBeNull)
            {
                Assert.NotNull(propertyValue);
            }

            if (propertyValue != null)
            {
                Assert.IsAssignableFrom<T>(propertyValue);
            }

            return (T)propertyValue;
        }

        #region Tests

        #region Send

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendFiresEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var partitionKey = "SomePartitionKeyHere";
                var parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                var eventQueue = this.CreateEventQueue();
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                TestUtility.Log("Sending single Event via EventHubClient produces diagnostic events");

                try
                {
                    using (var listener = this.CreateEventListener(null, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    using (var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub by partitionKey!")))
                    {
                        // enable Send .Start & .Stop events
                        listener.Enable((name, queueName, arg) => name.Contains("Send") && !name.EndsWith(".Exception"));

                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));
                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));

                        parentActivity.Start();

                        await ehClient.SendAsync(eventData, partitionKey);

                        parentActivity.Stop();

                        // check Diagnostic-Id injection
                        Assert.True(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));

                        // check Correlation-Context injection
                        Assert.True(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));
                        Assert.Equal(EventHubsDiagnosticSource.SerializeCorrelationContext(parentActivity.Baggage.ToList()), eventData.Properties[EventHubsDiagnosticSource.CorrelationContextPropertyName]);

                        Assert.True(eventQueue.TryDequeue(out var sendStart));
                        AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, parentActivity, partitionKey, ehClient.ConnectionStringBuilder);

                        Assert.True(eventQueue.TryDequeue(out var sendStop));
                        AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity, partitionKey, ehClient.ConnectionStringBuilder);

                        // no more events
                        Assert.False(eventQueue.TryDequeue(out var evnt));
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendDoesNotInjectContextWhenNoListeners()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var partitionKey = "SomePartitionKeyHere";
                var parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                var eventQueue = this.CreateEventQueue();
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                TestUtility.Log("Sending single Event via EventHubClient produces diagnostic events");

                try
                {
                    using (var listener = this.CreateEventListener(null, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    using (var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub by partitionKey!")))
                    {
                        // disable all events
                        listener.Enable((name, queueName, arg) => false);

                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));
                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));

                        parentActivity.Start();

                        await ehClient.SendAsync(eventData, partitionKey);

                        parentActivity.Stop();

                        // check Diagnostic-Id not injected
                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));

                        // check Correlation-Context not injected
                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));

                        // no events
                        Assert.False(eventQueue.TryDequeue(out var evnt));
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendFiresExceptionEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var partitionKey = "SomePartitionKeyHere";
                var parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                var eventQueue = this.CreateEventQueue();
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                TestUtility.Log("Sending single Event via EventHubClient produces diagnostic events for exception");

                try
                {
                    using (var listener = this.CreateEventListener(null, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    using (var eventData = new EventData(new byte[300 * 1024 * 1024]))
                    {
                        // enable Send .Exception & .Stop events
                        listener.Enable((name, queueName, arg) => name.Contains("Send") && !name.EndsWith(".Start"));
                        parentActivity.Start();

                        // Events data size limit is 256kb - larger one will results in exception from within Send method
                        try
                        {
                            await ehClient.SendAsync(eventData, partitionKey);
                            Assert.True(false, "Exception was expected but not thrown");
                        }
                        catch (Exception)
                        { }

                        parentActivity.Stop();

                        Assert.True(eventQueue.TryDequeue(out var exception));
                        AssertSendException(exception.eventName, exception.payload, exception.activity, null, partitionKey, ehClient.ConnectionStringBuilder);

                        Assert.True(eventQueue.TryDequeue(out var sendStop));
                        AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, null, partitionKey, ehClient.ConnectionStringBuilder, isFaulted: true);

                        Assert.Equal(sendStop.activity, exception.activity);

                        // no more events
                        Assert.False(eventQueue.TryDequeue(out var evnt));
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }
        #endregion Send

        #region Partition Sender

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PartitionSenderSendFiresEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var partitionKey = "1";
                var parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                var eventQueue = this.CreateEventQueue();
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionSender1 = default(PartitionSender);

                TestUtility.Log("Sending single Event via PartitionSender produces diagnostic events");

                try
                {
                    using (var listener = this.CreateEventListener(null, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    using (var eventData = new EventData(Encoding.UTF8.GetBytes("Hello again EventHub Partition 1!")))
                    {
                        partitionSender1 = ehClient.CreatePartitionSender(partitionKey);

                        // enable Send .Start & .Stop events
                        listener.Enable((name, queueName, arg) => name.Contains("Send") && !name.EndsWith(".Exception"));

                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));
                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));

                        parentActivity.Start();

                        try
                        {
                            await partitionSender1.SendAsync(eventData);
                        }
                        finally
                        {
                            await partitionSender1.CloseAsync();
                        }

                        parentActivity.Stop();

                        // check Diagnostic-Id injection
                        Assert.True(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));

                        // check Correlation-Context injection
                        Assert.True(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));
                        Assert.Equal(EventHubsDiagnosticSource.SerializeCorrelationContext(parentActivity.Baggage.ToList()), eventData.Properties[EventHubsDiagnosticSource.CorrelationContextPropertyName]);

                        Assert.True(eventQueue.TryDequeue(out var sendStart));
                        AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, parentActivity, partitionKey, ehClient.ConnectionStringBuilder);

                        Assert.True(eventQueue.TryDequeue(out var sendStop));
                        AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity, partitionKey, ehClient.ConnectionStringBuilder);

                        // no more events
                        Assert.False(eventQueue.TryDequeue(out var evnt));
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PartitionSenderSendDoesNotInjectContextWhenNoListeners()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var partitionKey = "1";
                var parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                var eventQueue = this.CreateEventQueue();
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionSender1 = default(PartitionSender);

                TestUtility.Log("Sending single Event via PartitionSender produces diagnostic events");

                try
                {
                    using (var listener = this.CreateEventListener(null, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    using (var eventData = new EventData(Encoding.UTF8.GetBytes("Hello again EventHub Partition 1!")))
                    {
                        partitionSender1 = ehClient.CreatePartitionSender(partitionKey);

                        // disable all events
                        listener.Enable((name, queueName, arg) => false);

                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));
                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));

                        parentActivity.Start();

                        try
                        {
                            await partitionSender1.SendAsync(eventData);
                        }
                        finally
                        {
                            await partitionSender1.CloseAsync();
                        }

                        parentActivity.Stop();

                        // check Diagnostic-Id not injected
                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));

                        // check Correlation-Context not injected
                        Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));

                        // no events
                        Assert.False(eventQueue.TryDequeue(out var evnt));
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PartitionSenderSendFiresExceptionEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var partitionKey = "1";
                var parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                var eventQueue = this.CreateEventQueue();
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionSender1 = default(PartitionSender);

                TestUtility.Log("Sending single Event via PartitionSender produces diagnostic events for exception");

                try
                {
                    using (var listener = this.CreateEventListener(null, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    using (var eventData = new EventData(new byte[300 * 1024 * 1024]))
                    {
                        partitionSender1 = ehClient.CreatePartitionSender(partitionKey);

                        // enable Send .Exception & .Stop events
                        listener.Enable((name, queueName, arg) => name.Contains("Send") && !name.EndsWith(".Start"));
                        parentActivity.Start();

                        try
                        {
                            // Events data size limit is 256kb - larger one will results in exception from within Send method
                            await Assert.ThrowsAsync<MessageSizeExceededException>(() => partitionSender1.SendAsync(eventData));
                        }
                        finally
                        {
                            await partitionSender1.CloseAsync();
                        }

                        parentActivity.Stop();

                        Assert.True(eventQueue.TryDequeue(out var exception));
                        AssertSendException(exception.eventName, exception.payload, exception.activity, null, partitionKey, ehClient.ConnectionStringBuilder);

                        Assert.True(eventQueue.TryDequeue(out var sendStop));
                        AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, null, partitionKey, ehClient.ConnectionStringBuilder, isFaulted: true);

                        Assert.Equal(sendStop.activity, exception.activity);

                        // no more events
                        Assert.False(eventQueue.TryDequeue(out var evnt));
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ValidateDiagnosticsIdentifierWhenSentInBatch()
        {
            const string PartitionId = "0";

            await using (var scope = await EventHubScope.CreateAsync(3))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var eventQueue = this.CreateEventQueue();
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                try
                {
                    using (var listener = this.CreateEventListener(null, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        // Enable all events.
                        listener.Enable((name, queueName, arg) => true);

                        // Create a batch until it is maxed out.
                        var batch = ehClient.CreateBatch();
                        while (batch.TryAdd(new EventData(new byte[10 * 1024]))) { }

                        // Mark end of stream before sending.
                        var pInfo = await ehClient.GetPartitionRuntimeInformationAsync(PartitionId);

                        await TestUtility.SendToPartitionAsync(ehClient, PartitionId, batch);

                        // Create receiver from marked offset and receive some or all of the messages.
                        var receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, PartitionId, EventPosition.FromOffset(pInfo.LastEnqueuedOffset));
                        var messages = await receiver.ReceiveAsync(10);

                        Assert.True(messages.Count() > 0, "Couldn't receive any messages.");

                        // Validate all messages carry diagnostics-id in the property bag.
                        foreach(var eventData in messages)
                        {
                            var activity = eventData.ExtractActivity();
                            Assert.True(activity.ParentId != null, "Diagnostics identifier was missing for received event");
                        }
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [DisplayTestMethodName]
        public void BatchSizeCalculation()
        {
            var batchSizeWithDiagnostics = 0;

            // Create a batch w/o diagnostics enabled and get the batch size.
            var batch = new EventDataBatch(1024 * 1024);
            while (batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Hello EventHub by partitionKey!")))) { }
            var batchSizeWithoutDiagnostics = batch.Count;

            // Create a batch w diagnostics enabled and get the batch size.
            var eventQueue = this.CreateEventQueue();
            using (var listener = this.CreateEventListener(null, eventQueue))
            using (var subscription = this.SubscribeToEvents(listener))
            {
                // Enable all events.
                listener.Enable((name, queueName, arg) => true);
                
                batch = new EventDataBatch(1024 * 1024);
                while (batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Hello EventHub by partitionKey!")))) { }
                batchSizeWithDiagnostics = batch.Count;
            }

            // Because of the diagnostics-id overhead, we should have less number of events when diagnostics enabled.
            // Validate that there are less number of events in the batch when diagnostics enabled than disabled.
            Assert.True(batchSizeWithoutDiagnostics > batchSizeWithDiagnostics,
                $"Batch size with diagnostics isn't smaller. W/ diagnostics enabled: { batchSizeWithDiagnostics }, w/o diagnostics enabled: { batchSizeWithoutDiagnostics }");
        }

        #endregion Partition Sender

        #region Partition Receiver

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PartitionReceiverReceiveFiresEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(3))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var partitionKey = "2";
                var payloadString = "Hello EventHub!";
                var parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                var eventQueue = this.CreateEventQueue();
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                TestUtility.Log("Receiving Events via PartitionReceiver produces diagnostic events");

                try
                {
                    using (var listener = this.CreateEventListener(null, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    using (var sendEvent = new EventData(Encoding.UTF8.GetBytes(payloadString)))
                    {
                        // enable Send & Receive .Start & .Stop events
                        listener.Enable((name, queueName, arg) => !name.EndsWith(".Exception"));

                        // send to have some data to receive
                        Assert.False(sendEvent.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));
                        Assert.False(sendEvent.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));

                        parentActivity.Start();

                        // Mark end of stream before sending.
                        var pInfo = await ehClient.GetPartitionRuntimeInformationAsync(partitionKey);

                        await TestUtility.SendToPartitionAsync(ehClient, partitionKey, sendEvent, 1);

                        // Create receiver from marked offset.
                        var receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionKey, EventPosition.FromOffset(pInfo.LastEnqueuedOffset));
                        var messages = await receiver.ReceiveAsync(10);

                        Assert.True(messages.Count() == 1, $"Received {messages.Count()} messages whereas 1 expected.");
                        var receivedEvent = messages.First();

                        Assert.True(Encoding.UTF8.GetString(receivedEvent.Body.Array) == payloadString, "Received payload string isn't the same as sent payload string.");

                        parentActivity.Stop();

                        // check Diagnostic-Id injection
                        Assert.True(sendEvent.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));
                        Assert.True(receivedEvent.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));
                        Assert.Equal(sendEvent.Properties[EventHubsDiagnosticSource.ActivityIdPropertyName], receivedEvent.Properties[EventHubsDiagnosticSource.ActivityIdPropertyName]);

                        // check Correlation-Context injection
                        Assert.True(sendEvent.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));
                        Assert.True(receivedEvent.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));
                        Assert.Equal(sendEvent.Properties[EventHubsDiagnosticSource.CorrelationContextPropertyName], receivedEvent.Properties[EventHubsDiagnosticSource.CorrelationContextPropertyName]);
                        Assert.Equal(EventHubsDiagnosticSource.SerializeCorrelationContext(parentActivity.Baggage.ToList()), sendEvent.Properties[EventHubsDiagnosticSource.CorrelationContextPropertyName]);

                        Assert.True(eventQueue.TryDequeue(out var sendStart));
                        AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, parentActivity, partitionKey, ehClient.ConnectionStringBuilder);

                        Assert.True(eventQueue.TryDequeue(out var sendStop));
                        AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity, partitionKey, ehClient.ConnectionStringBuilder);

                        Assert.True(eventQueue.TryDequeue(out var receiveStart));
                        AssertReceiveStart(receiveStart.eventName, receiveStart.payload, receiveStart.activity, partitionKey, ehClient.ConnectionStringBuilder);

                        Assert.True(eventQueue.TryDequeue(out var receiveStop));
                        AssertReceiveStop(receiveStop.eventName, receiveStop.payload, receiveStop.activity, receiveStart.activity, partitionKey, ehClient.ConnectionStringBuilder, relatedId: sendStop.activity.Id);

                        // no more events
                        Assert.False(eventQueue.TryDequeue(out var evnt));
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        #endregion Partition Receiver

        #region Extract Activity

        [Fact]
        [DisplayTestMethodName]
        public void ExtractsActivityWithIdAndNoContext()
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));
            eventData.Properties["Diagnostic-Id"] = "diagnostic-id";

            var activity = eventData.ExtractActivity();

            Assert.Equal("diagnostic-id", activity.ParentId);
            Assert.Equal("diagnostic-id", activity.RootId);
            Assert.Null(activity.Id);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Assert.Empty(baggage);
        }

        [Fact]
        [DisplayTestMethodName]
        public void ExtractsActivityWithIdAndSingleContext()
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));
            eventData.Properties["Diagnostic-Id"] = "diagnostic-id";
            eventData.Properties["Correlation-Context"] = "k1=v1";

            var activity = eventData.ExtractActivity();

            Assert.Equal("diagnostic-id", activity.ParentId);
            Assert.Equal("diagnostic-id", activity.RootId);

            Assert.Null(activity.Id);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Assert.Single(baggage);
            Assert.Contains("k1", baggage.Keys);
            Assert.Equal("v1", baggage["k1"]);
        }

        [Fact]
        [DisplayTestMethodName]
        public void ExtractsActivityWithIdAndMultiContext()
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));
            eventData.Properties["Diagnostic-Id"] = "diagnostic-id";
            eventData.Properties["Correlation-Context"] = "k1=v1,k2=v2,k3=v3";

            var activity = eventData.ExtractActivity();

            Assert.Equal("diagnostic-id", activity.ParentId);
            Assert.Equal("diagnostic-id", activity.RootId);

            Assert.Null(activity.Id);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Assert.Equal(3, baggage.Count);
            Assert.Contains("k1", baggage.Keys);
            Assert.Contains("k2", baggage.Keys);
            Assert.Contains("k3", baggage.Keys);
            Assert.Equal("v1", baggage["k1"]);
            Assert.Equal("v2", baggage["k2"]);
            Assert.Equal("v3", baggage["k3"]);
        }

        [Fact]
        [DisplayTestMethodName]
        public void ExtractActivityWithAlternateName()
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));
            eventData.Properties["Diagnostic-Id"] = "diagnostic-id";

            var activity = eventData.ExtractActivity("My activity");

            Assert.Equal("My activity", activity.OperationName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("not valid context")]
        [InlineData("not,valid,context")]
        [DisplayTestMethodName]
        public void ExtractsActivityWithIdAndInvalidContext(string context)
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));
            eventData.Properties["Diagnostic-Id"] = "diagnostic-id";
            eventData.Properties["Correlation-Context"] = context;

            var activity = eventData.ExtractActivity();

            Assert.Equal("diagnostic-id", activity.ParentId);
            Assert.Equal("diagnostic-id", activity.RootId);
            Assert.Null(activity.Id);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Assert.Empty(baggage);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [DisplayTestMethodName]
        public void ExtractsActivityWithoutIdAsRoot(string id)
        {
            var eventData = new EventData(Encoding.UTF8.GetBytes("test"));
            eventData.Properties["Diagnostic-Id"] = id;
            eventData.Properties["Correlation-Context"] = "k1=v1,k2=v2";

            var activity = eventData.ExtractActivity();

            Assert.Null(activity.ParentId);
            Assert.Null(activity.RootId);
            Assert.Null(activity.Id);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            // baggage is ignored in absence of Id
            Assert.Empty(baggage);
        }

        #endregion Extract Activity

        #endregion Tests

        #region Assertion Helpers

        #region Send

        protected void AssertSendStart(string name, object payload, Activity activity, Activity parentActivity, string partitionKey, EventHubsConnectionStringBuilder connectionStringBuilder, int eventCount = 1)
        {
            Assert.Equal("Send.Start", name);
            AssertCommonPayloadProperties(payload, partitionKey, connectionStringBuilder);
            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IList<EventData>>(payload, "EventDatas");
            Assert.Equal(eventCount, eventDatas.Count);

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);

            AssertTagMatches(activity, "peer.hostname", connectionStringBuilder.Endpoint.Host);
            AssertTagMatches(activity, "eh.event_hub_name", connectionStringBuilder.EntityPath);
            if (partitionKey != null)
            {
                AssertTagMatches(activity, "eh.partition_key", partitionKey);
            }
            AssertTagMatches(activity, "eh.event_count", eventCount.ToString());
            AssertTagExists(activity, "eh.client_id");
        }

        protected void AssertSendException(string name, object payload, Activity activity, Activity parentActivity, string partitionKey, EventHubsConnectionStringBuilder connectionStringBuilder)
        {
            Assert.Equal("Send.Exception", name);
            AssertCommonPayloadProperties(payload, partitionKey, connectionStringBuilder);

            GetPropertyValueFromAnonymousTypeInstance<Exception>(payload, "Exception");

            Assert.NotNull(activity);
            if (parentActivity != null)
            {
                Assert.Equal(parentActivity, activity.Parent);
            }

            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IList<EventData>>(payload, "EventDatas");
            Assert.NotNull(eventDatas);
        }

        protected void AssertSendStop(string name, object payload, Activity activity, Activity sendActivity, string partitionKey, EventHubsConnectionStringBuilder connectionStringBuilder, bool isFaulted = false)
        {
            Assert.Equal("Send.Stop", name);
            AssertCommonStopPayloadProperties(payload, partitionKey, isFaulted, connectionStringBuilder);

            if (sendActivity != null)
            {
                Assert.Equal(sendActivity, activity);
            }

            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IList<EventData>>(payload, "EventDatas");
            Assert.NotNull(eventDatas);
        }

        #endregion

        #region Receive

        protected void AssertReceiveStart(string name, object payload, Activity activity, string partitionKey, EventHubsConnectionStringBuilder connectionStringBuilder)
        {
            Assert.Equal("Receive.Start", name);
            AssertCommonPayloadProperties(payload, partitionKey, connectionStringBuilder);

            Assert.NotNull(activity);

            AssertTagMatches(activity, "peer.hostname", connectionStringBuilder.Endpoint.Host);
            AssertTagMatches(activity, "eh.event_hub_name", connectionStringBuilder.EntityPath);
            if (partitionKey != null)
            {
                AssertTagMatches(activity, "eh.partition_key", partitionKey);
            }
            AssertTagExists(activity, "eh.event_count");
            AssertTagExists(activity, "eh.client_id");

            AssertTagExists(activity, "eh.consumer_group");
            AssertTagExists(activity, "eh.start_offset");
        }

        protected void AssertReceiveStop(string name, object payload, Activity activity, Activity receiveActivity, string partitionKey, EventHubsConnectionStringBuilder connectionStringBuilder, bool isFaulted = false, string relatedId = null)
        {
            Assert.Equal("Receive.Stop", name);
            AssertCommonStopPayloadProperties(payload, partitionKey, isFaulted, connectionStringBuilder);

            if (receiveActivity != null)
            {
                Assert.Equal(receiveActivity, activity);
            }

            if (!string.IsNullOrEmpty(relatedId))
            {
                var relatedToTag = activity.Tags.FirstOrDefault(tag => tag.Key == EventHubsDiagnosticSource.RelatedToTagName);
                Assert.NotNull(relatedToTag);
                Assert.NotNull(relatedToTag.Value);
                Assert.Contains(relatedToTag.Value, relatedId);
            }
        }

        #endregion Receive

        #region Common

        protected void AssertTagExists(Activity activity, string tagName)
        {
            Assert.Contains(tagName, activity.Tags.Select(t => t.Key));
        }

        protected void AssertTagMatches(Activity activity, string tagName, string tagValue)
        {
            Assert.Contains(tagName, activity.Tags.Select(t => t.Key));
            Assert.Equal(tagValue, activity.Tags.Single(t => t.Key == tagName).Value);
        }

        protected void AssertCommonPayloadProperties(object eventPayload, string partitionKey, EventHubsConnectionStringBuilder connectionStringBuilder)
        {
            var endpoint = GetPropertyValueFromAnonymousTypeInstance<Uri>(eventPayload, "Endpoint");
            Assert.Equal(connectionStringBuilder.Endpoint, endpoint);

            var entityPath = GetPropertyValueFromAnonymousTypeInstance<string>(eventPayload, "Entity");
            Assert.Equal(connectionStringBuilder.EntityPath, entityPath);

            var pKey = GetPropertyValueFromAnonymousTypeInstance<string>(eventPayload, "PartitionKey");
            Assert.Equal(partitionKey, pKey);
        }

        protected void AssertCommonStopPayloadProperties(object eventPayload, string partitionKey, bool isFaulted, EventHubsConnectionStringBuilder connectionStringBuilder)
        {
            AssertCommonPayloadProperties(eventPayload, partitionKey, connectionStringBuilder);
            var status = GetPropertyValueFromAnonymousTypeInstance<TaskStatus>(eventPayload, "Status");
            Assert.Equal(isFaulted ? TaskStatus.Faulted : TaskStatus.RanToCompletion, status);
        }

        protected T GetPropertyValueFromAnonymousTypeInstance<T>(object obj, string propertyName)
        {
            Type t = obj.GetType();

            PropertyInfo p = t.GetRuntimeProperty(propertyName);

            object propertyValue = p.GetValue(obj);
            Assert.NotNull(propertyValue);
            Assert.IsAssignableFrom<T>(propertyValue);

            return (T)propertyValue;
        }

        #endregion Common

        #endregion Assertion Helpers
    }
}
