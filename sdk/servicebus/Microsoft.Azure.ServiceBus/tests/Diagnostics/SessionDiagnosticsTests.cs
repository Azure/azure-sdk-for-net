// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Diagnostics
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
    using Xunit;

    [Collection(nameof(DiagnosticsTests))]
    public class SessionDiagnosticsTests : DiagnosticsTests
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task AcceptSetAndGetStateGetFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: true, async queueName =>
            {
                var messageSender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var sessionClient = new SessionClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                var messageSession = default(IMessageSession);
                var eventQueue = this.CreateEventQueue();
                
                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        listener.Enable();

                        var sessionId = Guid.NewGuid().ToString();
                        await messageSender.SendAsync(new Message
                        {
                            MessageId = "messageId",
                            SessionId = sessionId
                        });

                        messageSession = await sessionClient.AcceptMessageSessionAsync(sessionId);

                        await messageSession.SetStateAsync(new byte[] {1});
                        await messageSession.GetStateAsync();
                        await messageSession.SetStateAsync(new byte[] { });
                        await messageSession.ReceiveAsync();

                        Assert.True(eventQueue.TryDequeue(out var sendStart));
                        AssertSendStart(queueName, sendStart.eventName, sendStart.payload, sendStart.activity, null);

                        Assert.True(eventQueue.TryDequeue(out var sendStop));
                        AssertSendStop(queueName, sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var acceptStart));
                        AssertAcceptMessageSessionStart(queueName, acceptStart.eventName, acceptStart.payload, acceptStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var acceptStop));
                        AssertAcceptMessageSessionStop(queueName, acceptStop.eventName, acceptStop.payload, acceptStop.activity,
                            acceptStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var setStateStart));
                        AssertSetSessionStateStart(queueName, setStateStart.eventName, setStateStart.payload, setStateStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var setStateStop));
                        AssertSetSessionStateStop(queueName, setStateStop.eventName, setStateStop.payload, setStateStop.activity,
                            setStateStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var getStateStart));
                        AssertGetSessionStateStart(queueName, getStateStart.eventName, getStateStart.payload, getStateStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var getStateStop));
                        AssertGetSessionStateStop(queueName, getStateStop.eventName, getStateStop.payload, getStateStop.activity,
                            getStateStop.activity);

                        Assert.True(eventQueue.TryDequeue(out var setStateStart2));
                        Assert.True(eventQueue.TryDequeue(out var setStateStop2));

                        Assert.True(eventQueue.TryDequeue(out var receiveStart));
                        AssertReceiveStart(queueName, receiveStart.eventName, receiveStart.payload, receiveStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var receiveStop));
                        AssertReceiveStop(queueName, receiveStop.eventName, receiveStop.payload, receiveStop.activity, receiveStart.activity,
                            sendStart.activity);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await Task.WhenAll(
                        messageSession.CloseAsync(),
                        messageSender.CloseAsync(), 
                        sessionClient.CloseAsync());
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SessionHandlerFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: true, async queueName =>
            {
                var timeout = TimeSpan.FromSeconds(5);
                var eventQueue = this.CreateEventQueue();

                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete, new NoRetry())
                {
                    OperationTimeout = timeout
                };
                
                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        queueClient.ServiceBusConnection.OperationTimeout = timeout;
                        queueClient.SessionClient.OperationTimeout = timeout;

                        var sw = Stopwatch.StartNew();
                
                        listener.Enable((name, queue, arg) => !name.Contains("AcceptMessageSession") &&
                                                                   !name.Contains("Receive") &&
                                                                   !name.Contains("Exception"));
                        var sessionId = Guid.NewGuid().ToString();
                        var message = new Message
                        {
                            MessageId = "messageId",
                            SessionId = sessionId
                        };
                        await queueClient.SendAsync(message);

                        var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

                        queueClient.RegisterSessionHandler((session, msg, ct) =>
                        {
                            tcs.TrySetResult(0);
                            return Task.CompletedTask;
                        },
                        exArgs => 
                        {
                            tcs.TrySetException(exArgs.Exception);
                            return Task.CompletedTask;
                        });

                        await tcs.Task.WithTimeout(DefaultTimeout);

                        Assert.True(eventQueue.TryDequeue(out var sendStart));
                        AssertSendStart(queueName, sendStart.eventName, sendStart.payload, sendStart.activity, null);

                        Assert.True(eventQueue.TryDequeue(out var sendStop));
                        AssertSendStop(queueName, sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var processStart));
                        AssertProcessSessionStart(queueName, processStart.eventName, processStart.payload, processStart.activity, sendStart.activity);

                        int wait = 0;
                        while (wait++ < MaxWaitSec && eventQueue.Count < 1)
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1));
                        }

                        Assert.True(eventQueue.TryDequeue(out var processStop));
                        AssertProcessSessionStop(queueName, processStop.eventName, processStop.payload, processStop.activity,
                            processStart.activity);

                        Assert.True(eventQueue.IsEmpty);

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
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        protected void AssertAcceptMessageSessionStart(string entityName, string eventName, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.AcceptMessageSession.Start", eventName);
            this.AssertCommonPayloadProperties(entityName, payload);

            var sessionId = this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");
            
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sessionId, activity.Tags.Single(t => t.Key == "SessionId").Value);
        }

        protected void AssertAcceptMessageSessionStop(string entityName, string eventName, object payload, Activity activity, Activity acceptActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.AcceptMessageSession.Stop", eventName);
            this.AssertCommonStopPayloadProperties(entityName, payload);
            this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");

            if (acceptActivity != null)
            {
                Assert.Equal(acceptActivity, activity);
            }
        }

        protected void AssertGetSessionStateStart(string entityName, string eventName, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.GetSessionState.Start", eventName);
            this.AssertCommonPayloadProperties(entityName, payload);

            var sessionId = this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");
            
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sessionId, activity.Tags.Single(t => t.Key == "SessionId").Value);
        }

        protected void AssertGetSessionStateStop(string entityName, string eventName, object payload, Activity activity, Activity getStateActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.GetSessionState.Stop", eventName);
            this.AssertCommonStopPayloadProperties(entityName, payload);
            this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");
            this.GetPropertyValueFromAnonymousTypeInstance<byte[]>(payload, "State");

            if (getStateActivity != null)
            {
                Assert.Equal(getStateActivity, activity);
            }
        }

        protected void AssertSetSessionStateStart(string entityName, string eventName, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.SetSessionState.Start", eventName);
            this.AssertCommonPayloadProperties(entityName, payload);
            var sessionId = this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");
            this.GetPropertyValueFromAnonymousTypeInstance<byte[]>(payload, "State");

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sessionId, activity.Tags.Single(t => t.Key == "SessionId").Value);
        }

        protected void AssertSetSessionStateStop(string entityName, string eventName, object payload, Activity activity, Activity setStateActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.SetSessionState.Stop", eventName);

            this.AssertCommonStopPayloadProperties(entityName, payload);
            this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");
            this.GetPropertyValueFromAnonymousTypeInstance<byte[]>(payload, "State");

            if (setStateActivity != null)
            {
                Assert.Equal(setStateActivity, activity);
            }
        }

        protected void AssertRenewSessionLockStart(string entityName, string eventName, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RenewSessionLock.Start", eventName);
            this.AssertCommonPayloadProperties(entityName, payload);
            var sessionId= this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sessionId, activity.Tags.Single(t => t.Key == "SessionId").Value);
        }

        protected void AssertRenewSessionLockStop(string entityName, string eventName, object payload, Activity activity, Activity renewActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RenewSessionLock.Stop", eventName);

            this.AssertCommonStopPayloadProperties(entityName, payload);
            this.GetPropertyValueFromAnonymousTypeInstance<string>(payload, "SessionId");

            if (renewActivity != null)
            {
                Assert.Equal(renewActivity, activity);
            }
        }

        protected void AssertProcessSessionStart(string entityName, string eventName, object payload, Activity activity, Activity sendActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.ProcessSession.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);

            GetPropertyValueFromAnonymousTypeInstance<IMessageSession>(payload, "Session");
            var message = GetPropertyValueFromAnonymousTypeInstance<Message>(payload, "Message");

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sendActivity.Id, activity.ParentId);
            Assert.Equal(sendActivity.Baggage.OrderBy(p => p.Key), activity.Baggage.OrderBy(p => p.Key));

            AssertTags(message, activity);
        }

        protected void AssertProcessSessionStop(string entityName, string eventName, object payload, Activity activity, Activity processActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.ProcessSession.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<IMessageSession>(payload, "Session");
            var message = GetPropertyValueFromAnonymousTypeInstance<Message>(payload, "Message");

            if (processActivity != null)
            {
                Assert.Equal(processActivity, activity);
            }
        }
    }
}
