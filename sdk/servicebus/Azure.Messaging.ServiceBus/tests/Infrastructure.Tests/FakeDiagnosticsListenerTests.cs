// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Azure.Messaging.ServiceBus.UnitTests.Diagnostics
{
    using System;
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus.Core;
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
                await using var subscriptionClient = new SubscriptionClient(TestUtility.NamespaceConnectionString, topicName, subscriptionName, ReceiveMode.ReceiveAndDelete);
                var eventQueue = this.CreateEventQueue();
                var entityName = $"{topicName}/Subscriptions/{subscriptionName}";

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
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task QueueEventsAreNotCapturedWhenDiagnosticsIsDisabled()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                var eventQueue = this.CreateEventQueue();

                using (var listener = this.CreateEventListener(queueName, eventQueue))
                using (var subscription = this.SubscribeToEvents(listener))
                {
                    listener.Disable();

                    var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
                    await using var sender = queueClient.CreateSender();
                    await using var receiver = queueClient.CreateReceiver(ReceiveMode.ReceiveAndDelete);

                    await TestUtility.SendMessagesAsync(sender, 1);
                    receiver.RegisterMessageHandler((msg, ct) =>
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
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task QueueEventsAreNotCapturedWhenDiagnosticsWhenEntityIsExplicitlyFiltered()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                var eventQueue = this.CreateEventQueue();

                using (var listener = this.CreateEventListener(queueName, eventQueue))
                using (var subscription = this.SubscribeToEvents(listener))
                {
                    listener.Enable((name, queue, arg) => queue?.ToString() != queueName);
                        
                    await using var sender = queueClient.CreateSender();
                    await using var receiver = queueClient.CreateReceiver(ReceiveMode.ReceiveAndDelete);

                    var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

                    await TestUtility.SendMessagesAsync(sender, 1);
                    receiver.RegisterMessageHandler((msg, ct) =>
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
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task QueueSessionEventsAreNotFiredWhenDiagnosticsIsDisabled()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: true, async queueName =>
            {
                await using var messageSender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                await using var sessionClient = new SessionClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                var messageSession = default(MessageSession);
                var eventQueue = this.CreateEventQueue();

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
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task QueueHandlerEventsCanBeFiltered()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                var eventQueue = this.CreateEventQueue();

                using (var listener = this.CreateEventListener(queueName, eventQueue))
                using (var subscription = this.SubscribeToEvents(listener))
                {
                    listener.Enable((name, queue, arg) => 
                        !name.Contains("Send") && !name.Contains("Process") && !name.Contains("Receive") && !name.Contains("Exception"));

                    await using var sender = queueClient.CreateSender();
                    await using var receiver = queueClient.CreateReceiver(ReceiveMode.ReceiveAndDelete);

                    await TestUtility.SendMessagesAsync(sender, 1);

                    var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

                    receiver.RegisterMessageHandler((msg, ct) =>
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
            });
        }
    }
}
