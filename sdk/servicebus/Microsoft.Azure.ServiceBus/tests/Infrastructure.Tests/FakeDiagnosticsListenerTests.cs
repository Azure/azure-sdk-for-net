// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Diagnostics
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
    using Xunit;

    [Collection(nameof(DiagnosticsTests))]
    public class FakeDiagnosticsListenerTests : DiagnosticsTests
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SubscriptionsEventsAreNotCapturedWhenDiagnosticsIsDisabled()
        {
            await ServiceBusScope.UsingTopicAsync(partitioned: false, sessionEnabled: false, async (topicName, subscriptionName) =>
            {
                var subscriptionClient = new SubscriptionClient(TestUtility.NamespaceConnectionString, topicName, subscriptionName, ReceiveMode.ReceiveAndDelete);
                var eventQueue = this.CreateEventQueue();
                var entityName = $"{topicName}/Subscriptions/{subscriptionName}";

                try
                {
                    using (var listener = this.CreateEventListener(entityName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        listener.Disable();

                        var ruleName = Guid.NewGuid().ToString();
                        await subscriptionClient.AddRuleAsync(ruleName, new TrueFilter());
                        await subscriptionClient.GetRulesAsync();
                        await subscriptionClient.RemoveRuleAsync(ruleName);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await subscriptionClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task QueueEventsAreNotCapturedWhenDiagnosticsIsDisabled()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        listener.Disable();

                        var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

                        await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                        queueClient.RegisterMessageHandler((msg, ct) =>
                        {
                            tcs.TrySetResult(0);
                            return Task.CompletedTask;
                        },
                        exArgs =>
                        {
                            // An exception is not interesting in this context; ignore any
                            // that may occur.
                            return Task.CompletedTask;
                        });

                        await tcs.Task.WithTimeout(DefaultTimeout);
                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task QueueEventsAreNotCapturedWhenDiagnosticsWhenEntityIsExplicitlyFiltered()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        listener.Enable((name, queue, arg) => queue?.ToString() != queueName);

                        var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

                        await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                        queueClient.RegisterMessageHandler((msg, ct) =>
                        {
                            tcs.TrySetResult(0);
                            return Task.CompletedTask;
                        },
                        exArgs =>
                        {
                            // An exception is not interesting in this context; ignore any
                            // that may occur.
                            return Task.CompletedTask;
                        });

                        await tcs.Task.WithTimeout(DefaultTimeout);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task QueueSessionEventsAreNotFiredWhenDiagnosticsIsDisabled()
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
                        listener.Disable();

                        var sessionId = Guid.NewGuid().ToString();
                        await messageSender.SendAsync(new Message
                        {
                            MessageId = "messageId",
                            SessionId = sessionId
                        });

                        messageSession = await sessionClient.AcceptMessageSessionAsync(sessionId);

                        await messageSession.SetStateAsync(new byte[] { 1 });
                        await messageSession.GetStateAsync();
                        await messageSession.SetStateAsync(new byte[] { });
                        await messageSession.ReceiveAsync();

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await Task.WhenAll(
                        messageSession?.CloseAsync(),
                        messageSender.CloseAsync(),
                        sessionClient.CloseAsync());
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task QueueHandlerEventsCanBeFiltered()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        listener.Enable((name, queue, arg) => 
                            !name.Contains("Send") && !name.Contains("Process") && !name.Contains("Receive") && !name.Contains("Exception"));

                        await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);

                        var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

                        queueClient.RegisterMessageHandler((msg, ct) =>
                        {
                            tcs.TrySetResult(0);
                            return Task.CompletedTask;
                        },
                        exArgs => 
                        {
                            // An exception is not interesting in this context; ignore any
                            // that may occur.
                            return Task.CompletedTask;
                        });

                        await tcs.Task.WithTimeout(DefaultTimeout);
                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }
    }
}
