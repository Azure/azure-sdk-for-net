﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Messaging.ServiceBus.Tests.Receiver
{
    public class SessionReceiverLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        [TestCase(1, null)]
        [TestCase(1, "key")]
        [TestCase(10000, null)]
        [TestCase(null, null)]
        public async Task PeekSession(long? sequenceNumber, string partitionKey)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCt = 10;
                var sessionId = Guid.NewGuid().ToString();

                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> sentMessages = AddMessages(batch, messageCt, sessionId, partitionKey).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);
                Dictionary<string, ServiceBusMessage> sentMessageIdToMsg = new Dictionary<string, ServiceBusMessage>();
                foreach (ServiceBusMessage message in sentMessages)
                {
                    sentMessageIdToMsg.Add(message.MessageId, message);
                }

                var receiver = await client.CreateSessionReceiverAsync(
                    scope.QueueName,
                    null,
                    sessionId);

                sequenceNumber ??= 1;

                // verify peeked == send
                var ct = 0;
                foreach (ServiceBusReceivedMessage peekedMessage in await receiver.PeekBatchAtAsync(
                    sequenceNumber: (long)sequenceNumber,
                    maxMessages: messageCt))
                {
                    var peekedText = Encoding.Default.GetString(peekedMessage.Body.ToArray());
                    var sentMsg = sentMessageIdToMsg[peekedMessage.MessageId];

                    sentMessageIdToMsg.Remove(peekedMessage.MessageId);
                    Assert.AreEqual(Encoding.Default.GetString(sentMsg.Body.ToArray()), peekedText);
                    Assert.AreEqual(sentMsg.PartitionKey, peekedMessage.PartitionKey);
                    Assert.IsTrue(peekedMessage.SequenceNumber >= sequenceNumber);
                    TestContext.Progress.WriteLine($"{peekedMessage.Label}: {peekedText}");
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                int messageCt = 10;
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                ServiceBusMessageBatch messageBatch = AddMessages(batch, messageCt, sessionId);

                await sender.SendBatchAsync(messageBatch);

                ServiceBusReceiver receiver1 = await client.CreateSessionReceiverAsync(
                    scope.QueueName,
                    sessionId: sessionId);

                Assert.That(
                    async () =>
                    await GetNoRetryClient().CreateSessionReceiverAsync(
                        scope.QueueName,
                        sessionId: sessionId),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.SessionCannotBeLocked));
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                ServiceBusMessageBatch messagebatch = AddMessages(batch, messageCt, sessionId);

                await sender.SendBatchAsync(messagebatch);
                ServiceBusReceiver receiver = await client.CreateSessionReceiverAsync(scope.QueueName);

                long seq = 0;
                for (int i = 0; i < messageCt / peekCt; i++)
                {
                    foreach (ServiceBusReceivedMessage msg in await receiver.PeekBatchAsync(
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                ServiceBusMessageBatch messagebatch = AddMessages(batch, messageCt, sessionId);

                await sender.SendBatchAsync(messagebatch);

                ServiceBusReceiver receiver = await client.CreateSessionReceiverAsync(scope.QueueName);

                long seq = 0;
                for (int i = 0; i < messageCt; i++)
                {
                    ServiceBusReceivedMessage msg = await receiver.PeekAsync();
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCt = 10;
                HashSet<string> sessions = new HashSet<string>() { "1", "2", "3" };
                // send the messages
                foreach (string session in sessions)
                {
                    using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                    ServiceBusMessageBatch messageBatch = AddMessages(batch, messageCt, session);
                    await sender.SendBatchAsync(messageBatch);
                }

                // create receiver not scoped to a specific session
                for (int i = 0; i < 10; i++)
                {
                    ServiceBusSessionReceiver receiver = await client.CreateSessionReceiverAsync(scope.QueueName);
                    foreach (ServiceBusReceivedMessage peekedMessage in await receiver.PeekBatchAtAsync(
                        sequenceNumber: 1,
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
        public async Task ReceiveMessagesInPeekLockMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                ServiceBusReceiver receiver = await client.CreateSessionReceiverAsync(scope.QueueName);

                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                    Assert.AreEqual(item.DeliveryCount, 1);
                }

                messageEnum.Reset();
                foreach (var item in await receiver.PeekBatchAsync(messageCount))
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var clientOptions = new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete
                };

                ServiceBusReceiver receiver = await client.CreateSessionReceiverAsync(
                    scope.QueueName,
                    clientOptions,
                    sessionId);

                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveBatchAsync(remainingMessages))
                    {
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                        remainingMessages--;
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CompleteMessages(bool useSpecificSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                ServiceBusReceiver receiver = await client.CreateSessionReceiverAsync(
                    scope.QueueName,
                    sessionId: sessionId);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                        await receiver.CompleteAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekAsync();
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                ServiceBusReceiver receiver = await client.CreateSessionReceiverAsync(
                    scope.QueueName,
                    sessionId: useSpecificSession ? sessionId : null);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;
                IList<ServiceBusReceivedMessage> receivedMessages = new List<ServiceBusReceivedMessage>();

                while (remainingMessages > 0)
                {
                    foreach (var msg in await receiver.ReceiveBatchAsync(remainingMessages))
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
                    await receiver.AbandonAsync(msg);
                }

                messageEnum.Reset();
                var receivedMessageCount = 0;
                foreach (var item in await receiver.PeekBatchAsync(messageCount))
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var receiver = await client.CreateSessionReceiverAsync(
                    scope.QueueName,
                    sessionId: useSpecificSession ? sessionId : null);
                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                        await receiver.DeadLetterAsync(item.LockToken, "testReason", "testDescription");
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);

                messageEnum.Reset();
                remainingMessages = messageCount;
                var deadLetterReceiver = client.CreateDeadLetterReceiver(scope.QueueName);

                while (remainingMessages > 0)
                {
                    foreach (var msg in await deadLetterReceiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, msg.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, msg.SessionId);
                        Assert.AreEqual("testReason", msg.DeadLetterReason);
                        Assert.AreEqual("testDescription", msg.DeadLetterErrorDescription);
                        await deadLetterReceiver.CompleteAsync(msg.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var deadLetterMessage = await deadLetterReceiver.PeekAsync();
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.TopicName);
                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);
                var topicName = scope.TopicName;
                var subscriptionName = scope.SubscriptionNames.First();

                var receiver = await client.CreateSessionReceiverAsync(
                    topicName: topicName,
                    subscriptionName: subscriptionName,
                    sessionId: useSpecificSession ? sessionId : null);
                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                        var props = new Dictionary<string, object>();
                        // these should be ignored by DeadLetter property getters as they are not strings
                        props[ServiceBusReceivedMessage.DeadLetterReasonHeader] = DateTime.UtcNow;
                        props[ServiceBusReceivedMessage.DeadLetterErrorDescriptionHeader] = DateTime.UtcNow;

                        await receiver.DeadLetterAsync(item.LockToken, props);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);

                messageEnum.Reset();
                remainingMessages = messageCount;
                var deadLetterReceiver = client.CreateDeadLetterReceiver(topicName, subscriptionName);

                while (remainingMessages > 0)
                {
                    foreach (var msg in await deadLetterReceiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, msg.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, msg.SessionId);
                        Assert.IsNull(msg.DeadLetterErrorDescription);
                        Assert.IsNull(msg.DeadLetterReason);
                        Assert.IsNotNull(msg.Properties[ServiceBusReceivedMessage.DeadLetterReasonHeader]);
                        Assert.IsNotNull(msg.Properties[ServiceBusReceivedMessage.DeadLetterErrorDescriptionHeader]);
                        await deadLetterReceiver.CompleteAsync(msg.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var deadLetterMessage = await deadLetterReceiver.PeekAsync();
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                var messageCount = 10;
                var sessionId = "sessionId1";
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, sessionId).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var receiver = await client.CreateSessionReceiverAsync(
                    scope.QueueName,
                    sessionId: useSpecificSession ? sessionId : null);
                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();
                IList<long> sequenceNumbers = new List<long>();
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.SessionId, item.SessionId);
                        sequenceNumbers.Add(item.SequenceNumber);
                        await receiver.DeferAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);
                IList<ServiceBusReceivedMessage> deferedMessages = await receiver.ReceiveDeferredMessageBatchAsync(sequenceNumbers);

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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messageCount = 1;
                var sessionId1 = "sessionId1";
                ServiceBusMessage message = GetMessage(sessionId1);

                // send another session message before the one we are interested in to make sure that when isSessionSpecified=true, it is being respected
                await sender.SendAsync(GetMessage("sessionId2"));
                await sender.SendAsync(message);

                ServiceBusSessionReceiver receiver = await client.CreateSessionReceiverAsync(scope.QueueName, sessionId: isSessionSpecified ? sessionId1 : null);
                if (isSessionSpecified)
                {
                    Assert.AreEqual(sessionId1, receiver.SessionId);
                }
                ServiceBusReceivedMessage[] receivedMessages = (await receiver.ReceiveBatchAsync(messageCount)).ToArray();

                var receivedMessage = receivedMessages.First();
                var firstLockedUntilUtcTime = receiver.SessionLockedUntil;

                // Sleeping for 10 seconds...
                await Task.Delay(10000);

                await receiver.RenewSessionLockAsync();

                Assert.True(receiver.SessionLockedUntil >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(10));

                // Complete Messages
                await receiver.CompleteAsync(receivedMessage.LockToken);

                Assert.AreEqual(messageCount, receivedMessages.Length);
                if (isSessionSpecified)
                {
                    Assert.AreEqual(message.MessageId, receivedMessage.MessageId);
                }

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        public async Task SessionReceiverThrowsWhenUsingNonSessionEntity()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusMessage sentMessage = GetMessage();
                await sender.SendAsync(sentMessage);

                Assert.That(
                    async () => await client.CreateSessionReceiverAsync(scope.QueueName),
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var sessionId = "test-sessionId";
                ServiceBusMessage message = GetMessage(sessionId);
                await sender.SendAsync(message);

                ServiceBusSessionReceiver receiver = await client.CreateSessionReceiverAsync(
                    scope.QueueName,
                    sessionId: isSessionSpecified ? sessionId : null);
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveAsync();
                Assert.AreEqual(message.MessageId, receivedMessage.MessageId);
                Assert.AreEqual(message.SessionId, receivedMessage.SessionId);

                var sessionStateString = "Received Message From Session!";
                var sessionState = Encoding.UTF8.GetBytes(sessionStateString);
                await receiver.SetSessionStateAsync(sessionState);

                var returnedSessionState = await receiver.GetSessionStateAsync();
                var returnedSessionStateString = Encoding.UTF8.GetString(returnedSessionState);
                Assert.AreEqual(sessionStateString, returnedSessionStateString);

                // Complete message using Session Receiver
                await receiver.CompleteAsync(receivedMessage);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);

                sessionStateString = "Completed Message On Session!";
                sessionState = Encoding.UTF8.GetBytes(sessionStateString);
                await receiver.SetSessionStateAsync(sessionState);

                returnedSessionState = await receiver.GetSessionStateAsync();
                returnedSessionStateString = Encoding.UTF8.GetString(returnedSessionState);
                Assert.AreEqual(sessionStateString, returnedSessionStateString);
            }
        }
    }
}
