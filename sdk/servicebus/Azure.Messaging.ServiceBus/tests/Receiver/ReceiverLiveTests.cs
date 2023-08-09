// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Amqp;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Receiver
{
    public class ReceiverLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task PeekUsingConnectionStringWithSharedKey()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCt = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> sentMessages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCt);

                await sender.SendMessagesAsync(batch);

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = sentMessages.GetEnumerator();

                var ct = 0;
                while (ct < messageCt)
                {
                    foreach (ServiceBusReceivedMessage peekedMessage in await receiver.PeekMessagesAsync(
                    maxMessages: messageCt))
                    {
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, peekedMessage.MessageId);
                        ct++;
                    }
                }
                Assert.AreEqual(messageCt, ct);
            }
        }

        [Test]
        public async Task PeekWithZeroTimeout()
        {
            await using (var scope =
                await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var receiverWithPrefetch = client.CreateReceiver(scope.QueueName,
                    options: new ServiceBusReceiverOptions { PrefetchCount = 10 });

                // establish the receive link up front before measuring elapsed time
                await receiverWithPrefetch.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                await receiverWithPrefetch.ReceiveMessagesAsync(10, TimeSpan.Zero).ConfigureAwait(false);
                stopwatch.Stop();
                var durationWithPrefetchModeInSecs = stopwatch.Elapsed.TotalSeconds;

                // If prefetch is enabled, timeout 0 secs will not be replaced with default timeout.
                // In such case, only prefetched messages will be returned and no call to server will be made and call will be very fast.
                Assert.IsTrue(durationWithPrefetchModeInSecs < 1);
            }
        }

        /// <summary>
        /// This test validates that outstanding link credits are drained when the receiver is closed so messages do not remain locked.
        /// This is a best effort attempt at draining until better support is added in the AMQP library, <see href="https://github.com/Azure/azure-amqp/issues/229"/>.
        /// </summary>
        [Test]
        public async Task ReceiverDrainsOnClosing()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false, lockDuration: ShortLockDuration))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                using var cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromSeconds(30));

                List<Task> tasks = new();
                tasks.Add(Send());

                for (int i = 0; i < 100; i++)
                {
                    tasks.Add(Receive());
                }

                await Task.WhenAll(tasks);

                async Task Receive()
                {
                    while (!cts.IsCancellationRequested)
                    {
                        await using var receiver = client.CreateReceiver(scope.QueueName);

                        var message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(2));

                        if (message != null)
                        {
                            Assert.AreEqual(1, message.DeliveryCount);
                            await receiver.CompleteMessageAsync(message);
                        }
                    }
                }

                async Task Send()
                {
                    while (!cts.IsCancellationRequested)
                    {
                        await Task.Delay(500);
                        await using var sender = client.CreateSender(scope.QueueName);
                        await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());
                    }
                }
            }
        }

        [Test]
        public async Task PeekUsingConnectionStringWithSas()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions();
                var audience = ServiceBusConnection.BuildConnectionResource(options.TransportType, TestEnvironment.FullyQualifiedNamespace, scope.QueueName);
                var connectionString = TestEnvironment.BuildConnectionStringWithSharedAccessSignature(scope.QueueName, audience);

                await using var client = new ServiceBusClient(connectionString, options);
                var messageCt = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> sentMessages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCt);

                await sender.SendMessagesAsync(batch);

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = sentMessages.GetEnumerator();

                var ct = 0;
                while (ct < messageCt)
                {
                    foreach (ServiceBusReceivedMessage peekedMessage in await receiver.PeekMessagesAsync(
                    maxMessages: messageCt))
                    {
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, peekedMessage.MessageId);
                        ct++;
                    }
                }
                Assert.AreEqual(messageCt, ct);
            }
        }

        [Test]
        public async Task PeekSingleMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var msgs = ServiceBusTestUtilities.GetMessages(2);
                await sender.SendMessagesAsync(msgs);
                var receiver = client.CreateReceiver(scope.QueueName);
                var message1 = await receiver.PeekMessageAsync();
                Assert.IsNotNull(message1.SequenceNumber);
                var message2 = await receiver.PeekMessageAsync(message1.SequenceNumber + 1);
                Assert.AreEqual(msgs[1].MessageId, message2.MessageId);
            }
        }

        [Test]
        public async Task CanRenewWithSeparateReceiver()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());
                var receiver1 = client.CreateReceiver(scope.QueueName);
                var message1 = await receiver1.ReceiveMessageAsync();
                await receiver1.RenewMessageLockAsync(message1);

                var receiver2 = client.CreateReceiver(scope.QueueName);
                await receiver2.RenewMessageLockAsync(message1);
                await receiver2.CompleteMessageAsync(message1);
            }
        }

        [Test]
        public async Task CanCompleteAfterLinkReconnect()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);
                var receiver = client.CreateReceiver(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

                var message = await receiver.ReceiveMessageAsync();

                SimulateNetworkFailure(client);

                await receiver.CompleteMessageAsync(message);
            }
        }

        [Test]
        public async Task CanAbandonAfterLinkReconnect()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);
                var receiver = client.CreateReceiver(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

                var message = await receiver.ReceiveMessageAsync();

                SimulateNetworkFailure(client);

                await receiver.AbandonMessageAsync(message, new Dictionary<string, object>{{ "test key", "test value" }});
                message = await receiver.ReceiveMessageAsync();
                Assert.AreEqual("test value", message.ApplicationProperties["test key"]);
            }
        }

        [Test]
        public async Task CanDeferAfterLinkReconnect()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);
                var receiver = client.CreateReceiver(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

                var message = await receiver.ReceiveMessageAsync();

                SimulateNetworkFailure(client);

                await receiver.DeferMessageAsync(message, new Dictionary<string, object>{{ "test key", "test value" }});
                message = await receiver.ReceiveDeferredMessageAsync(message.SequenceNumber);
                Assert.AreEqual("test value", message.ApplicationProperties["test key"]);
            }
        }

        [Test]
        public async Task CanDeadLetterAfterLinkReconnect()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);
                var receiver = client.CreateReceiver(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

                var message = await receiver.ReceiveMessageAsync();

                SimulateNetworkFailure(client);

                await receiver.DeadLetterMessageAsync(message, new Dictionary<string, object>{{ "test key", "test value" }}, "test reason", "test description");

                var dlqReceiver = client.CreateReceiver(scope.QueueName, new ServiceBusReceiverOptions { SubQueue = SubQueue.DeadLetter });
                var dlqMessage = await dlqReceiver.ReceiveMessageAsync();
                Assert.AreEqual("test reason", dlqMessage.DeadLetterReason);
                Assert.AreEqual("test description", dlqMessage.DeadLetterErrorDescription);
                Assert.AreEqual("test value", dlqMessage.ApplicationProperties["test key"]);
            }
        }

        [Test]
        public async Task PeekMessagesWithACustomIdentifier()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCt = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> sentMessages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCt);

                await sender.SendMessagesAsync(batch);

                var options = new ServiceBusReceiverOptions
                {
                    Identifier = "MyServiceBusReceiver"
                };
                await using var receiver = client.CreateReceiver(scope.QueueName, options);
                var messageEnum = sentMessages.GetEnumerator();

                var ct = 0;
                while (ct < messageCt)
                {
                    foreach (ServiceBusReceivedMessage peekedMessage in await receiver.PeekMessagesAsync(
                    maxMessages: messageCt))
                    {
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, peekedMessage.MessageId);
                        ct++;
                    }
                }
                Assert.AreEqual(messageCt, ct);
            }
        }

        [Test]
        public async Task ReceiveMessagesWhenQueueEmpty()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, new ServiceBusClientOptions
                {
                    RetryOptions =
                    {
                        // very high TryTimeout
                        TryTimeout = TimeSpan.FromSeconds(120)
                    }
                });

                var messageCount = 2;
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount);
                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);

                foreach (var message in await receiver.ReceiveMessagesAsync(2))
                {
                    await receiver.CompleteMessageAsync(message);
                }

                using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));

                var start = DateTime.UtcNow;
                Assert.ThrowsAsync<TaskCanceledException>(async () => await receiver.ReceiveMessagesAsync(1, cancellationToken: cancellationTokenSource.Token));
                var stop = DateTime.UtcNow;

                Assert.That(stop - start, Is.EqualTo(TimeSpan.FromSeconds(3)).Within(TimeSpan.FromSeconds(5)));
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CancellingDoesNotLoseMessages(bool prefetch)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();

                var messageCount = 10;
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                _ = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount);
                await sender.SendMessagesAsync(batch);
                var receiver = client.CreateReceiver(
                    scope.QueueName,
                    new ServiceBusReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete, PrefetchCount = prefetch ? 10 : 0 });

                using var cancellationTokenSource = new CancellationTokenSource(500);
                var received = 0;

                try
                {
                    for (int i = 0; i < messageCount; i++)
                    {
                        await receiver.ReceiveMessageAsync(cancellationToken: cancellationTokenSource.Token);
                        received++;
                        await Task.Delay(100);
                    }
                }
                catch (TaskCanceledException)
                {
                }

                Assert.Less(received, messageCount);

                var remaining = messageCount - received;
                for (int i = 0; i < remaining; i++)
                {
                    await receiver.ReceiveMessageAsync();
                    received++;
                }
                Assert.AreEqual(messageCount, received);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CancellingDoesNotBlockSubsequentReceives(bool prefetch)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var receiver = client.CreateReceiver(scope.QueueName, new ServiceBusReceiverOptions { PrefetchCount = prefetch ? 10 : 0 });

                using var cancellationTokenSource = new CancellationTokenSource(2000);
                var start = DateTime.UtcNow;
                Assert.That(
                    async () => await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(60), cancellationToken: cancellationTokenSource.Token),
                    Throws.InstanceOf<TaskCanceledException>());

                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());
                var msg = await receiver.ReceiveMessageAsync();
                Assert.AreEqual(1, msg.DeliveryCount);
                var end = DateTime.UtcNow;
                Assert.NotNull(msg);
                Assert.Less(end - start, TimeSpan.FromSeconds(10));
            }
        }

        [Test]
        public async Task ReceiveMessagesInPeekLockMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount);

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(item.DeliveryCount, 1);
                    }
                }
                Assert.AreEqual(0, remainingMessages);
                messageEnum.Reset();
                foreach (var item in await receiver.PeekMessagesAsync(messageCount))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                }
            }
        }

        [Test]
        public async Task CompleteMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount);

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        await receiver.CompleteMessageAsync(item);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        public async Task ServerBusyRespected()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                const int messageCount = 1000;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount);

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    var tasks = new List<Task>();
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        tasks.Add(receiver.CompleteMessageAsync(item));
                    }

                    // Attempt to complete many messages in parallel which will cause the service to throttle our requests.
                    // The retry policy should back off automatically and retries will succeed.
                    await Task.WhenAll(tasks);
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        public async Task ReceiveIterator()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messages = ServiceBusTestUtilities.GetMessages(messageCount);
                var secondSet = ServiceBusTestUtilities.GetMessages(messageCount);
                await sender.SendMessagesAsync(messages);
                _ = Task.Delay(TimeSpan.FromSeconds(30)).ContinueWith(
                    async _ => await sender.SendMessagesAsync(secondSet));

                var receiver = client.CreateReceiver(scope.QueueName);
                var cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromMinutes(1));
                messages.AddRange(secondSet);

                int ct = 0;
                try
                {
                    await foreach (var msg in receiver.ReceiveMessagesAsync(cts.Token))
                    {
                        Assert.AreEqual(messages[ct].MessageId, msg.MessageId);
                        await receiver.CompleteMessageAsync(msg, CancellationToken.None);
                        ct++;
                    }
                }
                catch (TaskCanceledException) { }
                Assert.AreEqual(messageCount * 2, ct);
            }
        }

        [Test]
        public async Task AbandonMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount);

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);

                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;
                IList<ServiceBusReceivedMessage> receivedMessages = new List<ServiceBusReceivedMessage>();
                while (remainingMessages > 0)
                {
                    foreach (var msg in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, msg.MessageId);
                        receivedMessages.Add(msg);
                        Assert.AreEqual(msg.DeliveryCount, 1);
                    }
                }

                Assert.AreEqual(0, remainingMessages);

                // don't abandon in the receive loop
                // as this would make the message available to be immediately received again
                foreach (var msg in receivedMessages)
                {
                    await receiver.AbandonMessageAsync(msg);
                }
                messageEnum.Reset();
                var receivedMessageCount = 0;
                foreach (var item in await receiver.PeekMessagesAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);
            }
        }

        [Test]
        public async Task DeadLetterMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.GetMessages(messageCount);

                await sender.SendMessagesAsync(messages);

                var receiver = client.CreateReceiver(scope.QueueName, new ServiceBusReceiverOptions
                {
                    PrefetchCount = 10
                });
                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.Body.ToArray(), item.Body.ToArray());
                        await receiver.DeadLetterMessageAsync(item);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);

                messageEnum.Reset();
                string deadLetterQueuePath = EntityNameFormatter.FormatDeadLetterPath(scope.QueueName);
                var deadLetterReceiver = client.CreateReceiver(deadLetterQueuePath);
                remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (var item in await deadLetterReceiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        await deadLetterReceiver.CompleteMessageAsync(item);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var deadLetterMessage = deadLetterReceiver.PeekMessageAsync();
                Assert.IsNull(deadLetterMessage.Result);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeadLetterMessagesModifiesProperties(bool setInPropertiesDict)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.GetMessages(messageCount);

                await sender.SendMessagesAsync(messages);

                var receiver = client.CreateReceiver(scope.QueueName, new ServiceBusReceiverOptions
                {
                    PrefetchCount = 10
                });
                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();

                var propertyReason = "property-reason";
                var propertyDescription = "property-description";
                var overloadReason = "overload-reason";
                var overloadDescription = "overload-description";

                var propertiesToModify = new Dictionary<string, object>();
                propertiesToModify.Add(AmqpMessageConstants.DeadLetterReasonHeader, propertyReason);
                propertiesToModify.Add(AmqpMessageConstants.DeadLetterErrorDescriptionHeader, propertyDescription);

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.Body.ToArray(), item.Body.ToArray());
                        if (setInPropertiesDict)
                        {
                            await receiver.DeadLetterMessageAsync(item, propertiesToModify);
                        }
                        else
                        {
                            await receiver.DeadLetterMessageAsync(item, overloadReason, overloadDescription);
                        }
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);

                messageEnum.Reset();
                string deadLetterQueuePath = EntityNameFormatter.FormatDeadLetterPath(scope.QueueName);
                var deadLetterReceiver = client.CreateReceiver(deadLetterQueuePath);
                remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (ServiceBusReceivedMessage item in await deadLetterReceiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        if (setInPropertiesDict)
                        {
                            Assert.AreEqual(item.DeadLetterReason, propertyReason);
                            Assert.AreEqual(item.DeadLetterErrorDescription, propertyDescription);
                        }
                        else
                        {
                            Assert.AreEqual(item.DeadLetterReason, overloadReason);
                            Assert.AreEqual(item.DeadLetterErrorDescription, overloadDescription);
                        }
                        await deadLetterReceiver.CompleteMessageAsync(item);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var deadLetterMessage = deadLetterReceiver.PeekMessageAsync();
                Assert.IsNull(deadLetterMessage.Result);
            }
        }

        [Test]
        public async Task DeferMessagesList()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                List<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount);

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                IList<long> sequenceNumbers = new List<long>();
                var remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        sequenceNumbers.Add(item.SequenceNumber);
                        await receiver.DeferMessageAsync(item);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                IReadOnlyList<ServiceBusReceivedMessage> deferredMessages = await receiver.ReceiveDeferredMessagesAsync(sequenceNumbers);

                var messageList = messages.ToList();
                Assert.AreEqual(messageList.Count, deferredMessages.Count);
                for (int i = 0; i < messageList.Count; i++)
                {
                    Assert.AreEqual(messageList[i].MessageId, deferredMessages[i].MessageId);
                    Assert.AreEqual(messageList[i].Body.ToArray(), deferredMessages[i].Body.ToArray());
                    Assert.AreEqual(ServiceBusMessageState.Deferred, deferredMessages[i].State);
                }

                // verify that looking up a non-existent sequence number will throw
                sequenceNumbers.Add(45);
                Assert.That(
                    async () => await receiver.ReceiveDeferredMessagesAsync(sequenceNumbers),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessageNotFound));

                // verify that an empty list can be passed
                deferredMessages = await receiver.ReceiveDeferredMessagesAsync(Array.Empty<long>());
                Assert.IsEmpty(deferredMessages);
            }
        }

        [Test]
        public async Task DeferMessagesArray()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                List<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount);

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                long[] sequenceNumbers = new long[messageCount];
                var remainingMessages = messageCount;
                int idx = 0;
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        sequenceNumbers[idx++] = item.SequenceNumber;
                        await receiver.DeferMessageAsync(item);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                IReadOnlyList<ServiceBusReceivedMessage> deferredMessages = await receiver.ReceiveDeferredMessagesAsync(sequenceNumbers);

                var messageList = messages.ToList();
                Assert.AreEqual(messageList.Count, deferredMessages.Count);
                for (int i = 0; i < messageList.Count; i++)
                {
                    Assert.AreEqual(messageList[i].MessageId, deferredMessages[i].MessageId);
                    Assert.AreEqual(messageList[i].Body.ToArray(), deferredMessages[i].Body.ToArray());
                    Assert.AreEqual(ServiceBusMessageState.Deferred, deferredMessages[i].State);
                }

                // verify that an empty array can be passed
                deferredMessages = await receiver.ReceiveDeferredMessagesAsync(Array.Empty<long>());
                Assert.IsEmpty(deferredMessages);
            }
        }

        [Test]
        public async Task DeferMessagesEnumerable()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                List<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount);

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                long[] sequenceNumbers = new long[messageCount];
                var remainingMessages = messageCount;
                int idx = 0;
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        sequenceNumbers[idx++] = item.SequenceNumber;
                        await receiver.DeferMessageAsync(item);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                IReadOnlyList<ServiceBusReceivedMessage> deferredMessages = await receiver.ReceiveDeferredMessagesAsync(GetEnumerable());

                IEnumerable<long> GetEnumerable()
                {
                    foreach (long seq in sequenceNumbers)
                    {
                        yield return seq;
                    }
                }

                var messageList = messages.ToList();
                Assert.AreEqual(messageList.Count, deferredMessages.Count);
                for (int i = 0; i < messageList.Count; i++)
                {
                    Assert.AreEqual(messageList[i].MessageId, deferredMessages[i].MessageId);
                    Assert.AreEqual(messageList[i].Body.ToArray(), deferredMessages[i].Body.ToArray());
                    Assert.AreEqual(ServiceBusMessageState.Deferred, deferredMessages[i].State);
                }

                // verify that an empty enumerable can be passed
                deferredMessages = await receiver.ReceiveDeferredMessagesAsync(Enumerable.Empty<long>());
                Assert.IsEmpty(deferredMessages);
            }
        }

        [Test]
        public async Task CanPeekADeferredMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);
                var receivedMsg = await receiver.ReceiveMessageAsync();

                await receiver.DeferMessageAsync(receivedMsg);
                var peekedMsg = await receiver.PeekMessageAsync();
                Assert.AreEqual(receivedMsg.MessageId, peekedMsg.MessageId);
                Assert.AreEqual(receivedMsg.SequenceNumber, peekedMsg.SequenceNumber);
                Assert.AreEqual(ServiceBusMessageState.Deferred, peekedMsg.State);

                var deferredMsg = await receiver.ReceiveDeferredMessageAsync(peekedMsg.SequenceNumber);
                Assert.AreEqual(peekedMsg.MessageId, deferredMsg.MessageId);
                Assert.AreEqual(peekedMsg.SequenceNumber, deferredMsg.SequenceNumber);
                Assert.AreEqual(peekedMsg.State, deferredMsg.State);
            }
        }

        [Test]
        public async Task ReceiveMessagesInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount);

                await sender.SendMessagesAsync(batch);

                var clientOptions = new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete,
                };
                var receiver = client.CreateReceiver(scope.QueueName, clientOptions);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages).ConfigureAwait(false))
                    {
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        remainingMessages--;
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        public async Task ReceiveSingleMessageInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusMessage sentMessage = ServiceBusTestUtilities.GetMessage();
                await sender.SendMessageAsync(sentMessage);

                var clientOptions = new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete,
                };
                var receiver = client.CreateReceiver(scope.QueueName, clientOptions);
                var receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.AreEqual(sentMessage.MessageId, receivedMessage.MessageId);

                var message = receiver.PeekMessageAsync();
                Assert.IsNull(message.Result);
            }
        }

        [Test]
        public async Task ReceiverThrowsWhenUsingSessionEntity()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusMessage sentMessage = ServiceBusTestUtilities.GetMessage("sessionId");
                await sender.SendMessageAsync(sentMessage);

                var receiver = client.CreateReceiver(scope.QueueName);
                Assert.That(
                    async () => await receiver.ReceiveMessageAsync(),
                    Throws.InstanceOf<InvalidOperationException>());
            }
        }

        [Test]
        public async Task RenewMessageLock()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messageCount = 1;
                ServiceBusMessage message = ServiceBusTestUtilities.GetMessage();
                await sender.SendMessageAsync(message);

                var receiver = client.CreateReceiver(scope.QueueName);
                ServiceBusReceivedMessage[] receivedMessages = (await receiver.ReceiveMessagesAsync(messageCount)).ToArray();

                var receivedMessage = receivedMessages.First();
                var firstLockedUntilUtcTime = receivedMessage.LockedUntil;

                // Sleeping for 10 seconds...
                await Task.Delay(10000);

                await receiver.RenewMessageLockAsync(receivedMessage);

                Assert.Greater(receivedMessage.LockedUntil, firstLockedUntilUtcTime);

                // Complete Messages
                await receiver.CompleteMessageAsync(receivedMessage);

                Assert.AreEqual(messageCount, receivedMessages.Length);
                Assert.AreEqual(message.MessageId, receivedMessage.MessageId);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        public async Task MaxWaitTimeRespected()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(
                    TestEnvironment.ServiceBusConnectionString,
                    new ServiceBusClientOptions
                    {
                        RetryOptions = new ServiceBusRetryOptions
                        {
                            TryTimeout = TimeSpan.FromSeconds(20),
                            MaxRetries = 0
                        }
                    });

                var receiver = client.CreateReceiver(scope.QueueName);
                var start = DateTimeOffset.UtcNow;
                var receivedMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                var end = DateTimeOffset.UtcNow;
                Assert.IsNull(receivedMessage);
                var diff = end - start;
                Assert.IsTrue(diff.TotalSeconds < 10);

                start = DateTimeOffset.UtcNow;
                // no wait time specified => should default to TryTimeout
                receivedMessage = await receiver.ReceiveMessageAsync();
                end = DateTimeOffset.UtcNow;
                Assert.IsNull(receivedMessage);
                diff = end - start;
                Assert.IsTrue(diff.TotalSeconds > 10);
            }
        }

        [Test]
        public async Task ThrowIfCompletePeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.CompleteMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("peeked message"));
            }
        }

        [Test]
        public async Task ThrowIfAbandonPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.AbandonMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("peeked message"));
            }
        }

        [Test]
        public async Task ThrowIfDeferPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.DeferMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("peeked message"));
            }
        }

        [Test]
        public async Task ThrowIfDeadletterPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.DeadLetterMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("peeked message"));
            }
        }

        [Test]
        public async Task ThrowIfSettleInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

                var receiver = client.CreateReceiver(
                    scope.QueueName,
                    new ServiceBusReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.DeadLetterMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("receive mode"));

                Assert.That(
                    async () => await receiver.DeferMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("receive mode"));

                Assert.That(
                    async () => await receiver.CompleteMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("receive mode"));

                Assert.That(
                    async () => await receiver.AbandonMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("receive mode"));
            }
        }

        /// <summary>
        /// This test validates that we are not limited to 5k unsettled messages on the link, as we have updated
        /// the sessionSettings.IncomingWindow value to Int32.MaxValue in AmqpConnectionScope. Without this change, receivers
        /// would just stop receiving after 5k unsettled messages and would not throw an exception.
        /// </summary>
        [Test]
        public async Task CanHaveManyUnsettledMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                int sentCount = 6000;
                int messagesPerBatch = 1000;

                await sender.SendMessagesAsync(new List<ServiceBusMessage>());

                for (int i = 0; i < sentCount / messagesPerBatch; i++)
                {
                    await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(messagesPerBatch));
                }

                var receiver = client.CreateReceiver(scope.QueueName);

                var receivedCount = 0;
                while (receivedCount <= sentCount)
                {
                    var msgs = await receiver.ReceiveMessagesAsync(sentCount);
                    receivedCount += msgs.Count;
                }
            }
        }

        [Test]
        public async Task ThrowIfRenewlockOfPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.RenewMessageLockAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>());
            }
        }

        [Test]
        public async Task ReceiveMessageReactsToClosingTheClient()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var messageCount = 5;

                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);

                // Send a batch of messages.

                using var batch = ServiceBusTestUtilities.AddMessages(await sender.CreateMessageBatchAsync(), messageCount);
                await sender.SendMessagesAsync(batch);

                // Receive the first message.

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var firstMessage = await receiver.ReceiveMessageAsync();

                Assert.IsNotNull(firstMessage, "The first message should have been received.");

                // Close the client and attempt to receive another message.

                await client.DisposeAsync();

                Assert.That(async () => await receiver.ReceiveMessageAsync(),
                    Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
            }
        }

        [Test]
        public async Task ReceiveMessagesReactsToClosingTheClient()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var messageCount = 10;
                var halfMessageCount = (messageCount / 2);

                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);

                // Send a batch of messages.

                using var batch = ServiceBusTestUtilities.AddMessages(await sender.CreateMessageBatchAsync(), messageCount);
                await sender.SendMessagesAsync(batch);

                // Receive the first batch message.

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var firstReceivedBatch = await ReceiveMessagesAsync(halfMessageCount, receiver);

                Assert.IsNotNull(firstReceivedBatch, "The first batch of messages should have been received.");
                Assert.AreEqual(halfMessageCount, firstReceivedBatch.Count, "The first batch of messages should have the correct count.");

                // Close the client and attempt to receive another message batch.

                await client.DisposeAsync();

                Assert.That(async () => await receiver.ReceiveMessagesAsync(halfMessageCount),
                    Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
            }
        }

        [Test]
        public async Task ReceiveDeferredMessageReactsToClosingTheClient()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var messageCount = 5;

                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);

                // Send a batch of messages.

                using var batch = ServiceBusTestUtilities.AddMessages(await sender.CreateMessageBatchAsync(), messageCount);
                await sender.SendMessagesAsync(batch);

                // Receive the first message.

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var firstMessage = await receiver.ReceiveMessageAsync();

                Assert.IsNotNull(firstMessage, "The first message should have been received.");

                // Capture the sequence number and defer the message.

                var sequenceNumber = firstMessage.SequenceNumber;
                await receiver.DeferMessageAsync(firstMessage);

                // Receive the deferred message, and defer it again.

                var deferredMessage = await receiver.ReceiveDeferredMessageAsync(sequenceNumber);
                Assert.IsNotNull(deferredMessage, "The deferred message should have been received.");

                await receiver.DeferMessageAsync(deferredMessage);

                // Close the client and attempt to receive another message.

                await client.DisposeAsync();

                Assert.That(async () => await receiver.ReceiveDeferredMessageAsync(sequenceNumber),
                    Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
            }
        }

        [Test]
        public async Task ReceiveDeferredMessagesReactsToClosingTheClient()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var messageCount = 10;
                var halfMessageCount = (messageCount / 2);

                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);

                // Send a batch of messages.

                using var batch = ServiceBusTestUtilities.AddMessages(await sender.CreateMessageBatchAsync(), messageCount);
                await sender.SendMessagesAsync(batch);

                // Receive the first batch message.

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var firstReceivedBatch = await ReceiveMessagesAsync(halfMessageCount, receiver);

                Assert.IsNotNull(firstReceivedBatch, "The first batch of messages should have been received.");
                Assert.AreEqual(halfMessageCount, firstReceivedBatch.Count, "The first batch of messages should have the correct count.");

                // Capture the sequence numbers and defer the messages.

                var sequenceNumbers = new List<long>(halfMessageCount);
                var deferTasks = new List<Task>(halfMessageCount);

                foreach (var message in firstReceivedBatch)
                {
                    sequenceNumbers.Add(message.SequenceNumber);
                    deferTasks.Add(receiver.DeferMessageAsync(message));
                }

                await Task.WhenAll(deferTasks);
                deferTasks.Clear();

                // Receive the deferred messages and defer them again.

                var deferredMessages = await receiver.ReceiveDeferredMessagesAsync(sequenceNumbers);

                Assert.IsNotNull(deferredMessages, "The batch of deferred messages should have been received.");
                Assert.AreEqual(halfMessageCount, deferredMessages.Count, "The batch of deferred messages should have the correct count.");

                foreach (var message in deferredMessages)
                {
                    deferTasks.Add(receiver.DeferMessageAsync(message));
                }

                await Task.WhenAll(deferTasks);

                // Close the client and attempt to receive another message batch.

                await client.DisposeAsync();

                Assert.That(async () => await receiver.ReceiveDeferredMessagesAsync(sequenceNumbers),
                    Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
            }
        }

        [Test]
        public async Task PeekMessageReactsToClosingTheClient()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var messageCount = 5;

                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);

                // Send a batch of messages.

                using var batch = ServiceBusTestUtilities.AddMessages(await sender.CreateMessageBatchAsync(), messageCount);
                await sender.SendMessagesAsync(batch);

                // Peek the first message.

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var firstMessage = await receiver.PeekMessageAsync();

                Assert.IsNotNull(firstMessage, "The first message should have been received.");

                // Close the client and attempt to peek another message.

                await client.DisposeAsync();

                Assert.That(async () => await receiver.PeekMessageAsync(),
                    Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
            }
        }

        [Test]
        public async Task PeekMessagesReactsToClosingTheClient()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var messageCount = 10;
                var halfMessgageCount = (messageCount / 2);

                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);

                // Send a batch of messages.

                using var batch = ServiceBusTestUtilities.AddMessages(await sender.CreateMessageBatchAsync(), messageCount);
                await sender.SendMessagesAsync(batch);

                // Peek the first batch message.

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var firstReceivedBatch = await PeekMessagesAsync(halfMessgageCount, receiver);

                Assert.IsNotNull(firstReceivedBatch, "The first batch of messages should have been received.");

                // Close the client and attempt to peek another message batch.

                await client.DisposeAsync();

                Assert.That(async () => await receiver.PeekMessagesAsync(halfMessgageCount),
                    Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
            }
        }

        [Test]
        public async Task CompleteMessageReactsToClosingTheClient()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var sendCount = 5;
                var receiveCount = 2;

                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);

                // Send a batch of messages.

                using var batch = ServiceBusTestUtilities.AddMessages(await sender.CreateMessageBatchAsync(), sendCount);
                await sender.SendMessagesAsync(batch);

                // Receive the messages.

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var receivedMessages = await ReceiveMessagesAsync(receiveCount, receiver);

                Assert.AreEqual(receiveCount, receivedMessages.Count, "An incorrect number of messages were received.");

                // Settle the first message.

                await receiver.CompleteMessageAsync(receivedMessages[0]);

                // Close the client and attempt to settle another message.

                await client.DisposeAsync();

                Assert.That(async () => await receiver.CompleteMessageAsync(receivedMessages[1]),
                    Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
            }
        }

        [Test]
        public async Task AbandonMessageReactsToClosingTheClient()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var sendCount = 5;
                var receiveCount = 2;

                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);

                // Send a batch of messages.

                using var batch = ServiceBusTestUtilities.AddMessages(await sender.CreateMessageBatchAsync(), sendCount);
                await sender.SendMessagesAsync(batch);

                // Receive the messages.

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var receivedMessages = await ReceiveMessagesAsync(receiveCount, receiver);

                Assert.AreEqual(receiveCount, receivedMessages.Count, "An incorrect number of messages were received.");

                // Settle the first message.

                await receiver.AbandonMessageAsync(receivedMessages[0]);

                // Close the client and attempt to settle another message.

                await client.DisposeAsync();

                Assert.That(async () => await receiver.AbandonMessageAsync(receivedMessages[1]),
                    Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
            }
        }

        [Test]
        public async Task DeadLetterMessageReactsToClosingTheClient()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var sendCount = 5;
                var receiveCount = 2;

                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);

                // Send a batch of messages.

                using var batch = ServiceBusTestUtilities.AddMessages(await sender.CreateMessageBatchAsync(), sendCount);
                await sender.SendMessagesAsync(batch);

                // Receive the messages.

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var receivedMessages = await ReceiveMessagesAsync(receiveCount, receiver);

                Assert.AreEqual(receiveCount, receivedMessages.Count, "An incorrect number of messages were received.");

                // Settle the first message.

                await receiver.DeadLetterMessageAsync(receivedMessages[0]);

                // Close the client and attempt to settle another message.

                await client.DisposeAsync();

                Assert.That(async () => await receiver.DeadLetterMessageAsync(receivedMessages[1]),
                    Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
            }
        }

        [Test]
        public async Task DeferMessageReactsToClosingTheClient()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var sendCount = 5;
                var receiveCount = 2;

                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);

                // Send a batch of messages.

                using var batch = ServiceBusTestUtilities.AddMessages(await sender.CreateMessageBatchAsync(), sendCount);
                await sender.SendMessagesAsync(batch);

                // Receive the messages.

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var receivedMessages = await ReceiveMessagesAsync(receiveCount, receiver);

                Assert.AreEqual(receiveCount, receivedMessages.Count, "An incorrect number of messages were received.");

                // Settle the first message.

                await receiver.DeferMessageAsync(receivedMessages[0]);

                // Close the client and attempt to settle another message.

                await client.DisposeAsync();

                Assert.That(async () => await receiver.DeferMessageAsync(receivedMessages[1]),
                    Throws.InstanceOf<ObjectDisposedException>().And.Property(nameof(ObjectDisposedException.ObjectName)).EqualTo(nameof(ServiceBusConnection)));
            }
        }

        [Test]
        public async Task NullableAmqpPropertiesRoundTripCorrectly()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);

                var message = new ServiceBusMessage
                {
                    ReplyTo = null,
                    To = null,
                    CorrelationId = null
                };

                Assert.IsNull(message.ReplyTo);
                Assert.IsNull(message.To);
                Assert.IsNull(message.CorrelationId);

                await sender.SendMessageAsync(message);

                await using var receiver = client.CreateReceiver(scope.QueueName);
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.IsNull(receivedMessage.ReplyTo);
                Assert.IsNull(receivedMessage.To);
                Assert.IsNull(receivedMessage.CorrelationId);

                // verify default null behavior

                message = new ServiceBusMessage();

                Assert.IsNull(message.ReplyTo);
                Assert.IsNull(message.To);
                Assert.IsNull(message.CorrelationId);

                await sender.SendMessageAsync(message);

                receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.IsNull(receivedMessage.ReplyTo);
                Assert.IsNull(receivedMessage.To);
                Assert.IsNull(receivedMessage.CorrelationId);

                // verify empty string respected

                message = new ServiceBusMessage
                {
                    ReplyTo = "",
                    To = "",
                    CorrelationId = ""
                };

                Assert.AreEqual("", message.ReplyTo);
                Assert.AreEqual("", message.To);
                Assert.AreEqual("", message.CorrelationId);

                await sender.SendMessageAsync(message);

                receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.AreEqual("", receivedMessage.ReplyTo);
                Assert.AreEqual("", receivedMessage.To);
                Assert.AreEqual("", receivedMessage.CorrelationId);
            }
        }

        private static async Task<List<ServiceBusReceivedMessage>> ReceiveMessagesAsync(
            int messageCount,
            ServiceBusReceiver receiver,
            TimeSpan? maxWaitTime = default,
            CancellationToken cancellationToken = default)
        {
            var receivedMessages = new List<ServiceBusReceivedMessage>(messageCount);

            while (messageCount > 0)
            {
                foreach (var message in (await receiver.ReceiveMessagesAsync(messageCount, maxWaitTime, cancellationToken)))
                {
                    receivedMessages.Add(message);
                    --messageCount;
                }
            }

            return receivedMessages;
        }

        private static async Task<List<ServiceBusReceivedMessage>> PeekMessagesAsync(
            int messageCount,
            ServiceBusReceiver receiver,
            CancellationToken cancellationToken = default)
        {
            var receivedMessages = new List<ServiceBusReceivedMessage>(messageCount);

            while (messageCount > 0)
            {
                foreach (var message in (await receiver.PeekMessagesAsync(messageCount, cancellationToken: cancellationToken)))
                {
                    receivedMessages.Add(message);
                    --messageCount;
                }
            }

            return receivedMessages;
        }
    }
}
