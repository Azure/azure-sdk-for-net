// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Diagnostics
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Azure.ServiceBus.Core;
    using Xunit;

    public class SessionDiagnosticsTests : DiagnosticsTests
    {
        protected override string EntityName => TestConstants.SessionNonPartitionedQueueName;
        private IMessageSession messageSession;
        private SessionClient sessionClient;
        private MessageSender messageSender;
        private QueueClient queueClient;
        private bool disposed;

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task AcceptSetAndGetStateGetFireEvents()
        {
            this.messageSender = new MessageSender(TestUtility.NamespaceConnectionString,
                TestConstants.SessionNonPartitionedQueueName);
            this.sessionClient = new SessionClient(TestUtility.NamespaceConnectionString,
                TestConstants.SessionNonPartitionedQueueName, ReceiveMode.ReceiveAndDelete);

            this.listener.Enable();

            var sessionId = Guid.NewGuid().ToString();
            await this.messageSender.SendAsync(new Message
            {
                MessageId = "messageId",
                SessionId = sessionId
            });
            this.messageSession = await this.sessionClient.AcceptMessageSessionAsync(sessionId);

            await this.messageSession.SetStateAsync(new byte[] {1});
            await this.messageSession.GetStateAsync();
            await this.messageSession.SetStateAsync(new byte[] { });

            await this.messageSession.ReceiveAsync();

            Assert.True(events.TryDequeue(out var sendStart));
            AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, null);

            Assert.True(events.TryDequeue(out var sendStop));
            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity);

            Assert.True(events.TryDequeue(out var acceptStart));
            AssertAcceptMessageSessionStart(acceptStart.eventName, acceptStart.payload, acceptStart.activity);

            Assert.True(events.TryDequeue(out var acceptStop));
            AssertAcceptMessageSessionStop(acceptStop.eventName, acceptStop.payload, acceptStop.activity,
                acceptStart.activity);

            Assert.True(events.TryDequeue(out var setStateStart));
            AssertSetSessionStateStart(setStateStart.eventName, setStateStart.payload, setStateStart.activity);

            Assert.True(events.TryDequeue(out var setStateStop));
            AssertSetSessionStateStop(setStateStop.eventName, setStateStop.payload, setStateStop.activity,
                setStateStart.activity);

            Assert.True(events.TryDequeue(out var getStateStart));
            AssertGetSessionStateStart(getStateStart.eventName, getStateStart.payload, getStateStart.activity);

            Assert.True(events.TryDequeue(out var getStateStop));
            AssertGetSessionStateStop(getStateStop.eventName, getStateStop.payload, getStateStop.activity,
                getStateStop.activity);

            Assert.True(events.TryDequeue(out var setStateStart2));
            Assert.True(events.TryDequeue(out var setStateStop2));

            Assert.True(events.TryDequeue(out var receiveStart));
            AssertReceiveStart(receiveStart.eventName, receiveStart.payload, receiveStart.activity);

            Assert.True(events.TryDequeue(out var receiveStop));
            AssertReceiveStop(receiveStop.eventName, receiveStop.payload, receiveStop.activity, receiveStart.activity,
                sendStart.activity);

            Assert.True(events.IsEmpty);
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task EventsAreNotFiredWhenDiagnosticsIsDisabled()
        {
            this.messageSender = new MessageSender(TestUtility.NamespaceConnectionString,
                TestConstants.SessionNonPartitionedQueueName);
            this.sessionClient = new SessionClient(TestUtility.NamespaceConnectionString,
                TestConstants.SessionNonPartitionedQueueName, ReceiveMode.ReceiveAndDelete);

            this.listener.Disable();

            var sessionId = Guid.NewGuid().ToString();
            await this.messageSender.SendAsync(new Message
            {
                MessageId = "messageId",
                SessionId = sessionId
            });
            this.messageSession = await sessionClient.AcceptMessageSessionAsync(sessionId);

            await this.messageSession.SetStateAsync(new byte[] {1});
            await this.messageSession.GetStateAsync();
            await this.messageSession.SetStateAsync(new byte[] { });

            await this.messageSession.ReceiveAsync();

            Assert.True(events.IsEmpty);
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task SessionHandlerFireEvents()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(5);
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString,
                TestConstants.SessionNonPartitionedQueueName, ReceiveMode.ReceiveAndDelete, new NoRetry())
            {
                OperationTimeout = timeout
            };

            this.queueClient.ServiceBusConnection.OperationTimeout = timeout;
            this.queueClient.SessionClient.OperationTimeout = timeout;

            Stopwatch sw = Stopwatch.StartNew();
            ManualResetEvent processingDone = new ManualResetEvent(false);
            this.listener.Enable((name, queueName, arg) => !name.Contains("AcceptMessageSession") &&
                                                      !name.Contains("Receive") &&
                                                      !name.Contains("Exception"));
            var sessionId = Guid.NewGuid().ToString();
            var message = new Message
            {
                MessageId = "messageId",
                SessionId = sessionId
            };
            await this.queueClient.SendAsync(message);

            this.queueClient.RegisterSessionHandler((session, msg, ct) =>
                {
                    processingDone.Set();
                    return Task.CompletedTask;
                },
                exArgs => Task.CompletedTask);

            processingDone.WaitOne(TimeSpan.FromSeconds(maxWaitSec));

            Assert.True(events.TryDequeue(out var sendStart));
            AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, null);

            Assert.True(events.TryDequeue(out var sendStop));
            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity);

            Assert.True(events.TryDequeue(out var processStart));
            AssertProcessSessionStart(processStart.eventName, processStart.payload, processStart.activity,
                sendStart.activity);

            int wait = 0;
            while (wait++ < maxWaitSec && events.Count < 1)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            Assert.True(events.TryDequeue(out var processStop));
            AssertProcessSessionStop(processStop.eventName, processStop.payload, processStop.activity,
                processStart.activity);

            Assert.True(events.IsEmpty);

            // workaround for https://github.com/Azure/azure-service-bus-dotnet/issues/372:
            // SessionPumpTaskAsync calls AcceptMessageSessionAsync() without cancellation token.
            // Even after SessionPump is stopped, this Task may still wait for session during operation timeout
            // It may interferee with other tests by acception it's sessions and throwing exceptions.
            // So, let's wait for timeout and a bit more to make sure all created tasks are completed
            sw.Stop();

            var timeToWait = (timeout - sw.Elapsed).TotalMilliseconds + 1000;
            if (timeToWait > 0)
            {
                await Task.Delay((int)timeToWait);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                this.queueClient?.SessionPumpHost?.Close();
                this.queueClient?.SessionClient.CloseAsync().Wait(TimeSpan.FromSeconds(maxWaitSec));
                this.queueClient?.CloseAsync().Wait(TimeSpan.FromSeconds(maxWaitSec));
                this.messageSession?.CloseAsync().Wait(TimeSpan.FromSeconds(maxWaitSec));
                this.sessionClient?.CloseAsync().Wait(TimeSpan.FromSeconds(maxWaitSec));
                this.messageSender?.CloseAsync().Wait(TimeSpan.FromSeconds(maxWaitSec));
            }

            this.disposed = true;

            base.Dispose(disposing);
        }

        protected void AssertAcceptMessageSessionStart(string name, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.AcceptMessageSession.Start", name);
            this.AssertCommonPayloadProperties(payload);

            var sessionId = this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");
            
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sessionId, activity.Tags.Single(t => t.Key == "SessionId").Value);
        }

        protected void AssertAcceptMessageSessionStop(string name, object payload, Activity activity, Activity acceptActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.AcceptMessageSession.Stop", name);
            this.AssertCommonStopPayloadProperties(payload);
            this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");

            if (acceptActivity != null)
            {
                Assert.Equal(acceptActivity, activity);
            }
        }

        protected void AssertGetSessionStateStart(string name, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.GetSessionState.Start", name);
            this.AssertCommonPayloadProperties(payload);

            var sessionId = this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");
            
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sessionId, activity.Tags.Single(t => t.Key == "SessionId").Value);
        }

        protected void AssertGetSessionStateStop(string name, object payload, Activity activity, Activity getStateActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.GetSessionState.Stop", name);
            this.AssertCommonStopPayloadProperties(payload);
            this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");
            this.GetPropertyValueFromAnonymousTypeInstance<byte[]>(payload, "State");

            if (getStateActivity != null)
            {
                Assert.Equal(getStateActivity, activity);
            }
        }

        protected void AssertSetSessionStateStart(string name, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.SetSessionState.Start", name);
            this.AssertCommonPayloadProperties(payload);
            var sessionId = this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");
            this.GetPropertyValueFromAnonymousTypeInstance<byte[]>(payload, "State");

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sessionId, activity.Tags.Single(t => t.Key == "SessionId").Value);
        }

        protected void AssertSetSessionStateStop(string name, object payload, Activity activity, Activity setStateActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.SetSessionState.Stop", name);

            this.AssertCommonStopPayloadProperties(payload);
            this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");
            this.GetPropertyValueFromAnonymousTypeInstance<byte[]>(payload, "State");

            if (setStateActivity != null)
            {
                Assert.Equal(setStateActivity, activity);
            }
        }

        protected void AssertRenewSessionLockStart(string name, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RenewSessionLock.Start", name);
            this.AssertCommonPayloadProperties(payload);
            var sessionId= this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sessionId, activity.Tags.Single(t => t.Key == "SessionId").Value);
        }

        protected void AssertRenewSessionLockStop(string name, object payload, Activity activity, Activity renewActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RenewSessionLock.Stop", name);

            this.AssertCommonStopPayloadProperties(payload);
            this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");

            if (renewActivity != null)
            {
                Assert.Equal(renewActivity, activity);
            }
        }

        protected void AssertProcessSessionStart(string name, object payload, Activity activity, Activity sendActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.ProcessSession.Start", name);
            AssertCommonPayloadProperties(payload);

            GetPropertyValueFromAnonymousTypeInstance<IMessageSession>(payload, "Session");
            var message = GetPropertyValueFromAnonymousTypeInstance<Message>(payload, "Message");

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sendActivity.Id, activity.ParentId);
            Assert.Equal(sendActivity.Baggage.OrderBy(p => p.Key), activity.Baggage.OrderBy(p => p.Key));

            AssertTags(message, activity);
        }

        protected void AssertProcessSessionStop(string name, object payload, Activity activity, Activity processActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.ProcessSession.Stop", name);
            AssertCommonStopPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<IMessageSession>(payload, "Session");
            var message = GetPropertyValueFromAnonymousTypeInstance<Message>(payload, "Message");

            if (processActivity != null)
            {
                Assert.Equal(processActivity, activity);
            }
        }
    }
}
