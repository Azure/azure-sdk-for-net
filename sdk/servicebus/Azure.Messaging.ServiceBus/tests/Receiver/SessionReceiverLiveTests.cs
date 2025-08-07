// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Amqp;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Messaging.ServiceBus.Tests.Receiver
{
    public class SessionReceiverLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        [TestCase(1)]
        [TestCase(10000)]
        [TestCase(null)]
        public async Task PeekSession(long? sequenceNumber)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCt = 10;
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                List<ServiceBusMessage> sentMessages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCt, sessionId, sessionId);

                await sender.SendMessagesAsync(batch);
                Dictionary<string, ServiceBusMessage> sentMessageIdToMsg = new Dictionary<string, ServiceBusMessage>();
                foreach (ServiceBusMessage message in sentMessages)
                {
                    sentMessageIdToMsg.Add(message.MessageId, message);
                }

                var receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    sessionId);

                sequenceNumber ??= 1;

                // verify peeked == send
                var ct = 0;
                foreach (ServiceBusReceivedMessage peekedMessage in await receiver.PeekMessagesAsync(
                    messageCt,
                    sequenceNumber))
                {
                    var peekedText = peekedMessage.Body.ToString();
                    var sentMsg = sentMessageIdToMsg[peekedMessage.MessageId];

                    sentMessageIdToMsg.Remove(peekedMessage.MessageId);
                    Assert.AreEqual(sentMsg.Body.ToString(), peekedText);
                    Assert.AreEqual(sentMsg.SessionId, peekedMessage.SessionId);
                    Assert.IsTrue(peekedMessage.SequenceNumber >= sequenceNumber);
                    ct++;
                }
                if (sequenceNumber == 1)
                {
                    Assert.AreEqual(messageCt, ct);
                }
            }
        }

        [Test]
        public async Task LockSameSessionShouldThrow()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                int messageCt = 10;
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                ServiceBusMessageBatch messageBatch = ServiceBusTestUtilities.AddMessages(batch, messageCt, sessionId);

                await sender.SendMessagesAsync(messageBatch);
                ServiceBusReceiver receiver1 = await client.AcceptSessionAsync(
                    scope.QueueName,
                    sessionId);

                Assert.That(
                    async () =>
                    await CreateNoRetryClient().AcceptSessionAsync(
                        scope.QueueName,
                        sessionId),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.SessionCannotBeLocked));
            }
        }

        [Test]
        [TestCase(10, 2)]
        [TestCase(10, 5)]
        [TestCase(50, 1)]
        [TestCase(50, 10)]
        public async Task PeekRangeIncrementsSequenceNumber(int messageCt, int peekCt)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                ServiceBusMessageBatch messagebatch = ServiceBusTestUtilities.AddMessages(batch, messageCt, sessionId);

                await sender.SendMessagesAsync(messagebatch);
                ServiceBusReceiver receiver = await client.AcceptNextSessionAsync(scope.QueueName);

                long seq = 0;
                for (int i = 0; i < messageCt / peekCt; i++)
                {
                    foreach (ServiceBusReceivedMessage msg in await receiver.PeekMessagesAsync(
                        maxMessages: peekCt))
                    {
                        Assert.IsTrue(msg.SequenceNumber > seq);
                        if (seq > 0)
                        {
                            Assert.IsTrue(msg.SequenceNumber == seq + 1);
                        }
                        seq = msg.SequenceNumber;
                    }
                }
            }
        }

        [Test]
        [TestCase(10)]
        [TestCase(50)]
        public async Task PeekIncrementsSequenceNumber(int messageCt)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                ServiceBusMessageBatch messagebatch = ServiceBusTestUtilities.AddMessages(batch, messageCt, sessionId);

                await sender.SendMessagesAsync(messagebatch);

                ServiceBusReceiver receiver = await client.AcceptNextSessionAsync(scope.QueueName);

                long seq = 0;
                for (int i = 0; i < messageCt; i++)
                {
                    ServiceBusReceivedMessage msg = await receiver.PeekMessageAsync();
                    Assert.IsTrue(msg.SequenceNumber > seq);
                    if (seq > 0)
                    {
                        Assert.IsTrue(msg.SequenceNumber == seq + 1);
                    }
                    seq = msg.SequenceNumber;
                }
            }
        }

        [Test]
        public async Task RoundRobinSessions()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCt = 10;
                HashSet<string> sessions = new HashSet<string>() { "1", "2", "3" };
                // send the messages
                foreach (string session in sessions)
                {
                    using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                    ServiceBusMessageBatch messageBatch = ServiceBusTestUtilities.AddMessages(batch, messageCt, session);
                    await sender.SendMessagesAsync(messageBatch);
                }

                // create receiver not scoped to a specific session
                for (int i = 0; i < 10; i++)
                {
                    ServiceBusSessionReceiver receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                    foreach (ServiceBusReceivedMessage peekedMessage in await receiver.PeekMessagesAsync(
                        fromSequenceNumber: 1,
                        maxMessages: 10))
                    {
                        var sessionId = receiver.SessionId;
                        Assert.AreEqual(sessionId, peekedMessage.SessionId);
                    }

                    // Close the receiver client when we are done with it. Since the sessionClient doesn't own the underlying connection, the connection remains open, but the session link will be closed.
                    await receiver.DisposeAsync();
                }
            }
        }

        [Test]
        public async Task ReceiveMessagesWhenQueueEmpty()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential, new ServiceBusClientOptions
                {
                    RetryOptions =
                    {
                        // very high TryTimeout
                        TryTimeout = TimeSpan.FromSeconds(120)
                    }
                });

                var messageCount = 2;
                var sessionId = "sessionId1";
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount, sessionId);
                await sender.SendMessagesAsync(batch);

                ServiceBusReceiver receiver = await client.AcceptNextSessionAsync(
                    scope.QueueName,
                    new ServiceBusSessionReceiverOptions
                    {
                        PrefetchCount = 100
                    });

                var remainingMessages = messageCount;
                while (remainingMessages > 0)
                {
                    foreach (var message in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        await receiver.CompleteMessageAsync(message);
                        remainingMessages--;
                    }
                }

                using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));

                var start = DateTime.UtcNow;
                Assert.ThrowsAsync<TaskCanceledException>(async () => await receiver.ReceiveMessagesAsync(1, cancellationToken: cancellationTokenSource.Token));
                var stop = DateTime.UtcNow;

                Assert.That(stop - start,  Is.EqualTo(TimeSpan.FromSeconds(3)).Within(TimeSpan.FromSeconds(5)));
            }
        }

        [Test]
        public async Task ReceiveMessagesInPeekLockMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount, sessionId);

                await sender.SendMessagesAsync(batch);

                ServiceBusReceiver receiver = await client.AcceptNextSessionAsync(
                    scope.QueueName,
                    new ServiceBusSessionReceiverOptions
                    {
                        PrefetchCount = 100
                    });

                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveMessagesAsync(messageCount))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                    Assert.AreEqual(item.DeliveryCount, 1);
                }

                messageEnum.Reset();
                foreach (var item in await receiver.PeekMessagesAsync(messageCount))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                }
            }
        }

        [Test]
        public async Task ReceiveMessagesInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount, sessionId);

                await sender.SendMessagesAsync(batch);

                var clientOptions = new ServiceBusSessionReceiverOptions
                {
                    ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete
                };

                ServiceBusReceiver receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    sessionId,
                    clientOptions);

                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                        remainingMessages--;
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        public async Task DeleteMessagesInPeekLockMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount, sessionId);

                await sender.SendMessagesAsync(batch);

                ServiceBusReceiver receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    sessionId);

                var time = (DateTimeOffset.UtcNow).AddSeconds(5); // UtcNow sometimes gets resolved as the same time as messages sent
                var numMessagesDeleted = await receiver.DeleteMessagesAsync(messageCount, time);
                Assert.NotZero(numMessagesDeleted);
                Assert.LessOrEqual(numMessagesDeleted, messageCount);
            }
        }

        [Test]
        public async Task DeleteMessagesInReceiveDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount, sessionId);

                await sender.SendMessagesAsync(batch);

                var clientOptions = new ServiceBusSessionReceiverOptions
                {
                    ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete
                };

                ServiceBusReceiver receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    sessionId,
                    clientOptions);

                var time = (DateTimeOffset.UtcNow).AddSeconds(5); // UtcNow sometimes gets resolved as the same time as messages sent
                var numMessagesDeleted = await receiver.DeleteMessagesAsync(messageCount, time);
                Assert.NotZero(numMessagesDeleted);
                Assert.LessOrEqual(numMessagesDeleted, messageCount);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CompleteMessages(bool useSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount, sessionId);

                await sender.SendMessagesAsync(batch);

                ServiceBusReceiver receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    useSpecificSession ? sessionId : null);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                        await receiver.CompleteMessageAsync(item);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AbandonMessages(bool useSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount, sessionId);

                await sender.SendMessagesAsync(batch);

                ServiceBusReceiver receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    useSpecificSession ? sessionId : null);
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
                        Assert.AreEqual(messageEnum.Current.SessionId, msg.SessionId);
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
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeadLetterMessages(bool useSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount, sessionId);

                await sender.SendMessagesAsync(batch);

                var receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    useSpecificSession ? sessionId : null);
                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                        await receiver.DeadLetterMessageAsync(item, "testReason", "testDescription");
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);

                messageEnum.Reset();
                remainingMessages = messageCount;
                var deadLetterReceiver = client.CreateReceiver(scope.QueueName, new ServiceBusReceiverOptions
                {
                    SubQueue = SubQueue.DeadLetter
                });

                while (remainingMessages > 0)
                {
                    foreach (var msg in await deadLetterReceiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, msg.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, msg.SessionId);
                        Assert.AreEqual("testReason", msg.DeadLetterReason);
                        Assert.AreEqual("testDescription", msg.DeadLetterErrorDescription);
                        await deadLetterReceiver.CompleteMessageAsync(msg);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var deadLetterMessage = await deadLetterReceiver.PeekMessageAsync();
                Assert.IsNull(deadLetterMessage);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeadLetterMessagesSubscription(bool useSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.TopicName);
                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount, sessionId);

                await sender.SendMessagesAsync(batch);
                var topicName = scope.TopicName;
                var subscriptionName = scope.SubscriptionNames.First();

                var receiver = await client.AcceptSessionAsync(
                    topicName: topicName,
                    subscriptionName: subscriptionName,
                    useSpecificSession ? sessionId : null);
                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                        var props = new Dictionary<string, object>();
                        // these should be ignored by DeadLetter property getters as they are not strings
                        props[AmqpMessageConstants.DeadLetterReasonHeader] = DateTime.UtcNow;
                        props[AmqpMessageConstants.DeadLetterErrorDescriptionHeader] = DateTime.UtcNow;

                        await receiver.DeadLetterMessageAsync(item, props);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);

                messageEnum.Reset();
                remainingMessages = messageCount;
                var deadLetterReceiver = client.CreateReceiver(topicName, subscriptionName, new ServiceBusReceiverOptions
                {
                    SubQueue = SubQueue.DeadLetter
                });

                while (remainingMessages > 0)
                {
                    foreach (var msg in await deadLetterReceiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, msg.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, msg.SessionId);
                        Assert.IsNull(msg.DeadLetterErrorDescription);
                        Assert.IsNull(msg.DeadLetterReason);
                        Assert.IsNotNull(msg.ApplicationProperties[AmqpMessageConstants.DeadLetterReasonHeader]);
                        Assert.IsNotNull(msg.ApplicationProperties[AmqpMessageConstants.DeadLetterErrorDescriptionHeader]);
                        await deadLetterReceiver.CompleteMessageAsync(msg);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var deadLetterMessage = await deadLetterReceiver.PeekMessageAsync();
                Assert.IsNull(deadLetterMessage);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeferMessages(bool useSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount, sessionId);

                await sender.SendMessagesAsync(batch);

                var receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    useSpecificSession ? sessionId : null);
                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();
                IList<long> sequenceNumbers = new List<long>();
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId.ToString(), item.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                        sequenceNumbers.Add(item.SequenceNumber);
                        await receiver.DeferMessageAsync(item);
                    }
                }
                Assert.AreEqual(0, remainingMessages);
                IReadOnlyList<ServiceBusReceivedMessage> deferedMessages = await receiver.ReceiveDeferredMessagesAsync(sequenceNumbers);

                var messageList = messages.ToList();
                Assert.AreEqual(messageList.Count, deferedMessages.Count);
                for (int i = 0; i < messageList.Count; i++)
                {
                    Assert.AreEqual(messageList[i].MessageId, deferedMessages[i].MessageId);
                }
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RenewSessionLock(bool isSessionSpecified)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messageCount = 1;
                var sessionId1 = "sessionId1";
                ServiceBusMessage message = ServiceBusTestUtilities.GetMessage(sessionId1);

                // send another session message before the one we are interested in to make sure that when isSessionSpecified=true, it is being respected
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("sessionId2"));
                await sender.SendMessageAsync(message);

                ServiceBusSessionReceiver receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    isSessionSpecified ? sessionId1 : null);
                if (isSessionSpecified)
                {
                    Assert.AreEqual(sessionId1, receiver.SessionId);
                }
                ServiceBusReceivedMessage[] receivedMessages = (await receiver.ReceiveMessagesAsync(messageCount)).ToArray();

                var receivedMessage = receivedMessages.First();
                var firstLockedUntilUtcTime = receiver.SessionLockedUntil;

                // Sleeping for 10 seconds...
                await Task.Delay(10000);

                await receiver.RenewSessionLockAsync();

                Assert.Greater(receiver.SessionLockedUntil, firstLockedUntilUtcTime);

                // Complete Messages
                await receiver.CompleteMessageAsync(receivedMessage);

                Assert.AreEqual(messageCount, receivedMessages.Length);
                if (isSessionSpecified)
                {
                    Assert.AreEqual(message.MessageId, receivedMessage.MessageId);
                }

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ReceiverThrowsAfterSessionLockLost(bool isSessionSpecified)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true, lockDuration: TimeSpan.FromSeconds(5)))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(3, "sessionId1"));
                // send another session message before the one we are interested in to make sure that when isSessionSpecified=true, it is being respected
                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(3, "sessionId2"));

                ServiceBusSessionReceiver receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    isSessionSpecified ? "sessionId1" : null);
                if (isSessionSpecified)
                {
                    Assert.AreEqual("sessionId1", receiver.SessionId);
                }

                var message = await receiver.ReceiveMessageAsync();
                Assert.AreEqual(receiver.SessionId, message.SessionId);
                var sessionId = receiver.SessionId;
                await Task.Delay((receiver.SessionLockedUntil - DateTime.UtcNow) + TimeSpan.FromSeconds(5));

                Assert.IsTrue(receiver.IsClosed);

                Assert.That(async () => await receiver.ReceiveMessageAsync(),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusFailureReason.SessionLockLost));

                Assert.That(async () => await receiver.SetSessionStateAsync(null),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusFailureReason.SessionLockLost));

                Assert.That(async () => await receiver.GetSessionStateAsync(),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusFailureReason.SessionLockLost));

                Assert.That(async () => await receiver.CompleteMessageAsync(message),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusFailureReason.SessionLockLost));

                Assert.That(async () => await receiver.CompleteMessageAsync(message),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusFailureReason.SessionLockLost));

                Assert.That(async () => await receiver.DeadLetterMessageAsync(message),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusFailureReason.SessionLockLost));

                Assert.That(async () => await receiver.DeferMessageAsync(message),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                    .EqualTo(ServiceBusFailureReason.SessionLockLost));
            }
        }

        [Test]
        public async Task ClientThrowsSessionCannotBeLockedWhenSessionLocked()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateClient();
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var sessionId = "sessionId";
                var receiver = await client.AcceptSessionAsync(scope.QueueName, sessionId);

                // should not throw when using different session
                await client.AcceptSessionAsync(scope.QueueName, "sessionId2");

                // for some reason, using Throws.InstanceOf and Assert.ThrowsAsync always end up coming back
                // as a timeout exception.
                try
                {
                    await client.AcceptSessionAsync(scope.QueueName, sessionId);
                }
                catch (ServiceBusException ex)
                when (ex.Reason == ServiceBusFailureReason.SessionCannotBeLocked)
                {
                    return;
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Expected exception not thrown: {ex}");
                }
                Assert.Fail("No exception thrown!");
            }
        }

        [Test]
        public async Task SessionReceiverThrowsWhenUsingNonSessionEntity()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusMessage sentMessage = ServiceBusTestUtilities.GetMessage();
                await sender.SendMessageAsync(sentMessage);

                Assert.That(
                    async () => await client.AcceptNextSessionAsync(scope.QueueName),
                    Throws.InstanceOf<InvalidOperationException>());
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetAndSetSessionStateTest(bool isSessionSpecified)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var sessionId = "test-sessionId";
                ServiceBusMessage message = ServiceBusTestUtilities.GetMessage(sessionId);
                await sender.SendMessageAsync(message);

                ServiceBusSessionReceiver receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    isSessionSpecified ? sessionId : null);
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.AreEqual(message.MessageId, receivedMessage.MessageId);
                Assert.AreEqual(message.SessionId, receivedMessage.SessionId);
                Assert.AreEqual(message.Body.ToArray(), receivedMessage.Body.ToArray());

                var sessionStateString = "Received Message From Session!";
                var sessionState = new BinaryData(sessionStateString);
                await receiver.SetSessionStateAsync(sessionState);

                var returnedSessionState = await receiver.GetSessionStateAsync();
                var returnedSessionStateString = returnedSessionState.ToString();
                Assert.AreEqual(sessionStateString, returnedSessionStateString);

                // Complete message using Session Receiver
                await receiver.CompleteMessageAsync(receivedMessage);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);

                sessionStateString = "Completed Message On Session!";
                sessionState = new BinaryData(sessionStateString);
                await receiver.SetSessionStateAsync(sessionState);

                returnedSessionState = await receiver.GetSessionStateAsync();
                returnedSessionStateString = returnedSessionState.ToString();
                Assert.AreEqual(sessionStateString, returnedSessionStateString);

                // Can clear the session state by setting to null
                await receiver.SetSessionStateAsync(null);
                Assert.IsNull(await receiver.GetSessionStateAsync());
            }
        }

        [Test]
        public async Task ReceiveIteratorUserCanMaintainSessionLock()
        {
            var lockDuration = TimeSpan.FromSeconds(10);
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true, lockDuration: lockDuration))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messages = ServiceBusTestUtilities.GetMessages(messageCount, "sessionId");
                var secondSet = ServiceBusTestUtilities.GetMessages(messageCount, "sessionId");
                await sender.SendMessagesAsync(messages);
                _ = Task.Delay(TimeSpan.FromSeconds(30)).ContinueWith(
                    async _ => await sender.SendMessagesAsync(secondSet));

                var receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                var cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromMinutes(1));
                messages.AddRange(secondSet);
                _ = RenewLock();

                async Task RenewLock()
                {
                    while (!cts.Token.IsCancellationRequested)
                    {
                        try
                        {
                            await Task.Delay(TimeSpan.FromSeconds(5), cts.Token);
                            await receiver.RenewSessionLockAsync(cts.Token);
                        }
                        catch (TaskCanceledException) { }
                    }
                }

                int ct = 0;

                try
                {
                    await foreach (var msg in receiver.ReceiveMessagesAsync(cts.Token))
                    {
                        Assert.AreEqual(messages[ct].MessageId, msg.MessageId);
                        await receiver.CompleteMessageAsync(msg);
                        ct++;
                        if (ct == messageCount)
                        {
                            await Task.Delay(lockDuration);
                        }
                    }
                }
                catch (TaskCanceledException) { }
                Assert.AreEqual(messageCount * 2, ct);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanAcceptMultipleSessionsUsingSameOptions(bool acceptSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var msgs = new List<ServiceBusMessage>();
                for (int i = 0; i < 20; i++)
                {
                    msgs.Add(new ServiceBusMessage() { SessionId = i.ToString() });
                }
                await sender.SendMessagesAsync(msgs);

                var options = new ServiceBusSessionReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete };
                var tasks = new List<Task>();
                for (int i = 0; i < 20; i++)
                {
                    if (acceptSpecificSession)
                    {
                        tasks.Add(client.AcceptSessionAsync(scope.QueueName, i.ToString(), options));
                    }
                    else
                    {
                        tasks.Add(client.AcceptNextSessionAsync(scope.QueueName, options));
                    }
                }
                await Task.WhenAll(tasks);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanAcceptMultipleSessionsUsingSameOptionsTopic(bool acceptSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.TopicName);
                var msgs = new List<ServiceBusMessage>();
                for (int i = 0; i < 20; i++)
                {
                    msgs.Add(new ServiceBusMessage() { SessionId = i.ToString() });
                }
                await sender.SendMessagesAsync(msgs);

                var options = new ServiceBusSessionReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete };
                var tasks = new List<Task>();
                for (int i = 0; i < 20; i++)
                {
                    if (acceptSpecificSession)
                    {
                        tasks.Add(client.AcceptSessionAsync(scope.TopicName, scope.SubscriptionNames.First(), i.ToString(), options));
                    }
                    else
                    {
                        tasks.Add(client.AcceptNextSessionAsync(scope.TopicName, scope.SubscriptionNames.First(), options));
                    }
                }
                await Task.WhenAll(tasks);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CancelingDoesNotLoseSessionMessages(bool prefetch)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateClient();

                var messageCount = 10;
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = ServiceBusTestUtilities.AddAndReturnMessages(batch, messageCount, "SessionId");
                await sender.SendMessagesAsync(batch);
                var receiver = await client.AcceptSessionAsync(
                    scope.QueueName,
                    "sessionId",
                    new ServiceBusSessionReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete, PrefetchCount = prefetch ? 10 : 0 });

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
        public async Task CancelingDoesNotBlockSubsequentReceives(bool prefetch)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateClient();

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var receiver = await client.AcceptSessionAsync(scope.QueueName, "sessionId", new ServiceBusSessionReceiverOptions { PrefetchCount = prefetch ? 10 : 0 });

                using var cancellationTokenSource = new CancellationTokenSource(500);
                var start = DateTime.UtcNow;

                Assert.That(
                    async () => await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(60), cancellationToken: cancellationTokenSource.Token),
                    Throws.InstanceOf<TaskCanceledException>());

                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("sessionId"));
                var msg = await receiver.ReceiveMessageAsync();
                Assert.AreEqual(1, msg.DeliveryCount);
                var end = DateTime.UtcNow;
                Assert.NotNull(msg);
                Assert.Less(end - start, TimeSpan.FromSeconds(10));
            }
        }

        [Test]
        public async Task LinkCloseCausesIsClosedToBeTrue()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateClient();

                var receiver = await client.AcceptSessionAsync(scope.QueueName, "sessionId");
                Assert.IsFalse(receiver.IsClosed);

                SimulateNetworkFailure(client);
                Assert.IsTrue(receiver.IsClosed);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task OpenSessionIsNotClosedWhenAcceptNextSessionTimesOut(bool enableCrossEntityTransactions)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                var options = new ServiceBusClientOptions
                {
                    EnableCrossEntityTransactions = enableCrossEntityTransactions,
                    RetryOptions = new ServiceBusRetryOptions
                    {
                        TryTimeout = TimeSpan.FromSeconds(10),
                        MaxRetries = 0
                    }
                };
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential, options);
                await using var sender = client.CreateSender(scope.QueueName);

                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("sessionId"));

                var receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                await AsyncAssert.ThrowsAsync<ServiceBusException>(async () => await client.AcceptNextSessionAsync(scope.QueueName));

                // the receive link should not have been closed due to the other accept call timing out
                var message = await receiver.ReceiveMessageAsync();
                Assert.IsNotNull(message);
            }
        }

        [Test]
        public async Task CannotCompleteAfterLinkReconnect()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("session"));
                var receiver = await client.AcceptNextSessionAsync(scope.QueueName);

                var message = await receiver.ReceiveMessageAsync();

                SimulateNetworkFailure(client);
                Assert.That(
                    async () => await receiver.CompleteMessageAsync(message),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                        .EqualTo(ServiceBusFailureReason.SessionLockLost));
            }
        }

        [Test]
        public async Task CanAbandonAfterLinkReconnect()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("session"));
                var receiver = await client.AcceptNextSessionAsync(scope.QueueName);

                var message = await receiver.ReceiveMessageAsync();

                SimulateNetworkFailure(client);
                Assert.That(
                    async () => await receiver.AbandonMessageAsync(message),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                        .EqualTo(ServiceBusFailureReason.SessionLockLost));
            }
        }

        [Test]
        public async Task CannotDeferAfterLinkReconnect()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("session"));
                var receiver = await client.AcceptNextSessionAsync(scope.QueueName);

                var message = await receiver.ReceiveMessageAsync();

                SimulateNetworkFailure(client);
                Assert.That(
                    async () => await receiver.DeferMessageAsync(message),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                        .EqualTo(ServiceBusFailureReason.SessionLockLost));
            }
        }

        [Test]
        public async Task CannotDeadLetterAfterLinkReconnect()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("session"));
                var receiver = await client.AcceptNextSessionAsync(scope.QueueName);

                var message = await receiver.ReceiveMessageAsync();

                SimulateNetworkFailure(client);
                Assert.That(
                    async () => await receiver.DeadLetterMessageAsync(message),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason))
                        .EqualTo(ServiceBusFailureReason.SessionLockLost));
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SessionOrderingIsGuaranteed(bool prefetch)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var receiver = await client.AcceptSessionAsync(scope.QueueName, "session", new ServiceBusSessionReceiverOptions
                {
                    PrefetchCount = prefetch ? 5 : 0
                });
                var sender = client.CreateSender(scope.QueueName);

                CancellationTokenSource cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromSeconds(60));

                var receive = ReceiveMessagesAsync();

                var send = SendMessagesAsync();

                await Task.WhenAll(send, receive);

                async Task SendMessagesAsync()
                {
                    while (!cts.IsCancellationRequested)
                    {
                        await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("session"));
                        await Task.Delay(TimeSpan.FromMilliseconds(100));
                    }
                }

                async Task ReceiveMessagesAsync()
                {
                    long lastSequenceNumber = 0;
                    while (!cts.IsCancellationRequested)
                    {
                        var messages = await receiver.ReceiveMessagesAsync(10);
                        foreach (var message in messages)
                        {
                            Assert.That(
                                message.SequenceNumber,
                                Is.EqualTo(lastSequenceNumber + 1),
                                $"Last sequence number: {lastSequenceNumber}, current sequence number: {message.SequenceNumber}");

                            lastSequenceNumber = message.SequenceNumber;

                            await receiver.CompleteMessageAsync(message);
                        }
                    }
                }
            }
        }
    }
}
