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
    public class DiagnosticsTests : ClientTestBase
    {
        protected ConcurrentQueue<(string eventName, object payload, Activity activity)> events;
        protected FakeDiagnosticListener listener;
        protected IDisposable subscription;
        protected const int maxWaitSec = 10;
        private bool disposed = false;

        public DiagnosticsTests()
        {
            this.events = new ConcurrentQueue<(string eventName, object payload, Activity activity)>();
            this.listener = new FakeDiagnosticListener(kvp =>
            {
                TestUtility.Log($"Diagnostics event: {kvp.Key}, Activity Id: {Activity.Current?.Id}");
                if (kvp.Key.Contains("Exception"))
                {
                    TestUtility.Log($"Exception {kvp.Value}");
                }

                this.events.Enqueue((kvp.Key, kvp.Value, Activity.Current));
            });
            this.subscription = DiagnosticListener.AllListeners.Subscribe(this.listener);
        }

        #region Tests

        #region Send

        [Fact]
        [DisplayTestMethodName]
        async Task SendFiresEvents()
        {
            string partitionKey = "SomePartitionKeyHere";

            TestUtility.Log("Sending single Event via EventHubClient produces diagnostic events");
            Activity parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");

            // enable Send .Start & .Stop events
            this.listener.Enable((name, queueName, arg) => name.Contains("Send") && !name.EndsWith(".Exception"));

            var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub by partitionKey!"));
            Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));
            Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));

            parentActivity.Start();

            await this.EventHubClient.SendAsync(eventData, partitionKey);

            parentActivity.Stop();

            // check Diagnostic-Id injection
            Assert.True(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));

            // check Correlation-Context injection
            Assert.True(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));
            Assert.Equal(EventHubsDiagnosticSource.SerializeCorrelationContext(parentActivity.Baggage.ToList()), eventData.Properties[EventHubsDiagnosticSource.CorrelationContextPropertyName]);

            Assert.True(this.events.TryDequeue(out var sendStart));
            AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, parentActivity, partitionKey: partitionKey);

            Assert.True(this.events.TryDequeue(out var sendStop));
            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity, partitionKey: partitionKey);

            // no more events
            Assert.False(this.events.TryDequeue(out var evnt));
        }

        [Fact]
        [DisplayTestMethodName]
        async Task SendDoesNotInjectContextWhenNoListeners()
        {
            string partitionKey = "SomePartitionKeyHere";

            TestUtility.Log("Sending single Event via EventHubClient produces diagnostic events");
            Activity parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");

            // disable all events
            this.listener.Enable((name, queueName, arg) => false);

            var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub by partitionKey!"));
            Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));
            Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));

            parentActivity.Start();

            await this.EventHubClient.SendAsync(eventData, partitionKey);

            parentActivity.Stop();

            // check Diagnostic-Id not injected
            Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));

            // check Correlation-Context not injected
            Assert.False(eventData.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));

            // no events
            Assert.False(this.events.TryDequeue(out var evnt));
        }

        [Fact]
        [DisplayTestMethodName]
        async Task SendFiresExceptionEvents()
        {
            string partitionKey = "SomePartitionKeyHere";

            TestUtility.Log("Sending single Event via EventHubClient produces diagnostic events for exception");
            Activity parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");

            // enable Send .Exception & .Stop events
            this.listener.Enable((name, queueName, arg) => name.Contains("Send") && !name.EndsWith(".Start"));

            parentActivity.Start();

            // Events data size limit is 256kb - larger one will results in exception from within Send method
            var eventData = new EventData(new byte[300 * 1024 * 1024]);

            try
            {
                await this.EventHubClient.SendAsync(eventData, partitionKey);
                Assert.True(false, "Exception was expected but not thrown");
            }
            catch (Exception)
            { }

            parentActivity.Stop();
            
            Assert.True(this.events.TryDequeue(out var exception));
            AssertSendException(exception.eventName, exception.payload, exception.activity, null, partitionKey);

            Assert.True(this.events.TryDequeue(out var sendStop));
            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, null, partitionKey, isFaulted: true);

            Assert.Equal(sendStop.activity, exception.activity);

            // no more events
            Assert.False(this.events.TryDequeue(out var evnt));
        }

        #endregion Send

        #region Partition Sender

        [Fact]
        [DisplayTestMethodName]
        async Task PartitionSenderSendFiresEvents()
        {
            string partitionKey = "1";
            TestUtility.Log("Sending single Event via PartitionSender produces diagnostic events");

            PartitionSender partitionSender1 = this.EventHubClient.CreatePartitionSender(partitionKey);
            Activity parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");

            // enable Send .Start & .Stop events
            this.listener.Enable((name, queueName, arg) => name.Contains("Send") && !name.EndsWith(".Exception"));

            var eventData = new EventData(Encoding.UTF8.GetBytes("Hello again EventHub Partition 1!"));
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

            Assert.True(this.events.TryDequeue(out var sendStart));
            AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, parentActivity, partitionKey);

            Assert.True(this.events.TryDequeue(out var sendStop));
            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity, partitionKey);

            // no more events
            Assert.False(this.events.TryDequeue(out var evnt));
        }

        [Fact]
        [DisplayTestMethodName]
        async Task PartitionSenderSendDoesNotInjectContextWhenNoListeners()
        {
            string partitionKey = "1";
            TestUtility.Log("Sending single Event via PartitionSender produces diagnostic events");

            PartitionSender partitionSender1 = this.EventHubClient.CreatePartitionSender(partitionKey);
            Activity parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");

            // disable all events
            this.listener.Enable((name, queueName, arg) => false);

            var eventData = new EventData(Encoding.UTF8.GetBytes("Hello again EventHub Partition 1!"));
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
            Assert.False(this.events.TryDequeue(out var evnt));
        }

        [Fact]
        [DisplayTestMethodName]
        async Task PartitionSenderSendFiresExceptionEvents()
        {
            string partitionKey = "1";
            TestUtility.Log("Sending single Event via PartitionSender produces diagnostic events for exception");

            PartitionSender partitionSender1 = this.EventHubClient.CreatePartitionSender(partitionKey);
            Activity parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");

            // enable Send .Exception & .Stop events
            this.listener.Enable((name, queueName, arg) => name.Contains("Send") && !name.EndsWith(".Start"));

            parentActivity.Start();

            try
            {
                // Events data size limit is 256kb - larger one will results in exception from within Send method
                var eventData = new EventData(new byte[300 * 1024 * 1024]);
                await partitionSender1.SendAsync(eventData);
                Assert.True(false, "Exception was expected but not thrown");
            }
            catch (Exception)
            { }
            finally
            {
                await partitionSender1.CloseAsync();
            }

            parentActivity.Stop();

            Assert.True(this.events.TryDequeue(out var exception));
            AssertSendException(exception.eventName, exception.payload, exception.activity, null, partitionKey);

            Assert.True(this.events.TryDequeue(out var sendStop));
            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, null, partitionKey, isFaulted: true);

            Assert.Equal(sendStop.activity, exception.activity);

            // no more events
            Assert.False(this.events.TryDequeue(out var evnt));
        }

        #endregion Partition Sender

        #region Partition Receiver

        [Fact]
        [DisplayTestMethodName]
        async Task PartitionReceiverReceiveFiresEvents()
        {
            string partitionKey = "2";
            string payloadString = "Hello EventHub!";

            TestUtility.Log("Receiving Events via PartitionReceiver produces diagnostic events");

            Activity parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");

            // enable Send & Receive .Start & .Stop events
            this.listener.Enable((name, queueName, arg) => !name.EndsWith(".Exception"));

            // send to have some data to receive
            var sendEvent = new EventData(Encoding.UTF8.GetBytes(payloadString));
            Assert.False(sendEvent.Properties.ContainsKey(EventHubsDiagnosticSource.ActivityIdPropertyName));
            Assert.False(sendEvent.Properties.ContainsKey(EventHubsDiagnosticSource.CorrelationContextPropertyName));

            parentActivity.Start();

            // Mark end of stream before sending.
            var pInfo = await this.EventHubClient.GetPartitionRuntimeInformationAsync(partitionKey);

            await TestUtility.SendToPartitionAsync(this.EventHubClient, partitionKey, sendEvent, 1);

            // Create receiver from marked offset.
            var receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionKey, EventPosition.FromOffset(pInfo.LastEnqueuedOffset));
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

            Assert.True(this.events.TryDequeue(out var sendStart));
            AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, parentActivity, partitionKey);

            Assert.True(this.events.TryDequeue(out var sendStop));
            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity, partitionKey);

            Assert.True(this.events.TryDequeue(out var receiveStart));
            AssertReceiveStart(receiveStart.eventName, receiveStart.payload, receiveStart.activity, partitionKey);

            Assert.True(this.events.TryDequeue(out var receiveStop));
            AssertReceiveStop(receiveStop.eventName, receiveStop.payload, receiveStop.activity, receiveStart.activity, partitionKey, relatedId: sendStop.activity.Id);

            // no more events
            Assert.False(this.events.TryDequeue(out var evnt));
        }

        #endregion Partition Receiver

        #region Extract Activity

        [Fact]
        [DisplayTestMethodName]
        void ExtractsActivityWithIdAndNoContext()
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
        void ExtractsActivityWithIdAndSingleContext()
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
        void ExtractsActivityWithIdAndMultiContext()
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
        void ExtractActivityWithAlternateName()
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
        void ExtractsActivityWithIdAndInvalidContext(string context)
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
        void ExtractsActivityWithoutIdAsRoot(string id)
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

        protected void AssertSendStart(string name, object payload, Activity activity, Activity parentActivity, string partitionKey, int eventCount = 1)
        {
            Assert.Equal("Microsoft.Azure.EventHubs.Send.Start", name);
            AssertCommonPayloadProperties(payload, partitionKey);
            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IList<EventData>>(payload, "EventDatas");
            Assert.Equal(eventCount, eventDatas.Count);

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);

            AssertTagMatches(activity, "peer.hostname", this.EventHubClient.ConnectionStringBuilder.Endpoint.Host);
            AssertTagMatches(activity, "eh.event_hub_name", this.EventHubClient.ConnectionStringBuilder.EntityPath);
            if (partitionKey != null)
            {
                AssertTagMatches(activity, "eh.partition_key", partitionKey);
            }
            AssertTagMatches(activity, "eh.event_count", eventCount.ToString());
            AssertTagExists(activity, "eh.client_id");
        }

        protected void AssertSendException(string name, object payload, Activity activity, Activity parentActivity, string partitionKey)
        {
            Assert.Equal("Microsoft.Azure.EventHubs.Send.Exception", name);
            AssertCommonPayloadProperties(payload, partitionKey);

            GetPropertyValueFromAnonymousTypeInstance<Exception>(payload, "Exception");

            Assert.NotNull(activity);
            if (parentActivity != null)
            {
                Assert.Equal(parentActivity, activity.Parent);
            }

            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IList<EventData>>(payload, "EventDatas");
            Assert.NotNull(eventDatas);
        }

        protected void AssertSendStop(string name, object payload, Activity activity, Activity sendActivity, string partitionKey, bool isFaulted = false)
        {
            Assert.Equal("Microsoft.Azure.EventHubs.Send.Stop", name);
            AssertCommonStopPayloadProperties(payload, partitionKey, isFaulted);

            if (sendActivity != null)
            {
                Assert.Equal(sendActivity, activity);
            }

            var eventDatas = GetPropertyValueFromAnonymousTypeInstance<IList<EventData>>(payload, "EventDatas");
            Assert.NotNull(eventDatas);
        }

        #endregion

        #region Receive

        protected void AssertReceiveStart(string name, object payload, Activity activity, string partitionKey)
        {
            Assert.Equal("Microsoft.Azure.EventHubs.Receive.Start", name);
            AssertCommonPayloadProperties(payload, partitionKey);

            Assert.NotNull(activity);

            AssertTagMatches(activity, "peer.hostname", this.EventHubClient.ConnectionStringBuilder.Endpoint.Host);
            AssertTagMatches(activity, "eh.event_hub_name", this.EventHubClient.ConnectionStringBuilder.EntityPath);
            if (partitionKey != null)
            {
                AssertTagMatches(activity, "eh.partition_key", partitionKey);
            }
            AssertTagExists(activity, "eh.event_count");
            AssertTagExists(activity, "eh.client_id");

            AssertTagExists(activity, "eh.consumer_group");
            AssertTagExists(activity, "eh.start_offset");
        }

        protected void AssertReceiveStop(string name, object payload, Activity activity, Activity receiveActivity, string partitionKey, bool isFaulted = false, string relatedId = null)
        {
            Assert.Equal("Microsoft.Azure.EventHubs.Receive.Stop", name);
            AssertCommonStopPayloadProperties(payload, partitionKey, isFaulted);

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

        protected void AssertCommonPayloadProperties(object eventPayload, string partitionKey)
        {
            var endpoint = GetPropertyValueFromAnonymousTypeInstance<Uri>(eventPayload, "Endpoint");
            Assert.Equal(this.EventHubClient.ConnectionStringBuilder.Endpoint, endpoint);

            var entityPath = GetPropertyValueFromAnonymousTypeInstance<string>(eventPayload, "Entity");
            Assert.Equal(this.EventHubClient.ConnectionStringBuilder.EntityPath, entityPath);

            var pKey = GetPropertyValueFromAnonymousTypeInstance<string>(eventPayload, "PartitionKey");
            Assert.Equal(partitionKey, pKey);
        }

        protected void AssertCommonStopPayloadProperties(object eventPayload, string partitionKey, bool isFaulted)
        {
            AssertCommonPayloadProperties(eventPayload, partitionKey);
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

        #region IDisposable

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                this.listener?.Disable();

                while (this.events.TryDequeue(out var evnt))
                {
                }

                while (Activity.Current != null)
                {
                    Activity.Current.Stop();
                }

                this.listener?.Dispose();
                this.subscription?.Dispose();

                this.events = null;
                this.listener = null;
                this.subscription = null;
            }

            this.disposed = true;
        }

        #endregion IDisposable
    }
}
