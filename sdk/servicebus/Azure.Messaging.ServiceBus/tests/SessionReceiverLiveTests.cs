// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Core;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class SessionReceiverLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        [TestCase(1, null)]
        [TestCase(1, "key")]
        [TestCase(10000, null)]
        [TestCase(null, null)]
        public async Task Peek_Session(long? sequenceNumber, string partitionKey)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCt = 10;
                var sessionId = Guid.NewGuid().ToString();

                // send the messages
                IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt, sessionId, partitionKey);
                await sender.SendRangeAsync(sentMessages);
                Dictionary<string, ServiceBusMessage> sentMessageIdToMsg = new Dictionary<string, ServiceBusMessage>();
                foreach (ServiceBusMessage message in sentMessages)
                {
                    sentMessageIdToMsg.Add(message.MessageId, message);
                }

                // peek the messages
                var sessionSettings = new SessionOptions()
                {
                    Connection = new ServiceBusConnection(
                        TestEnvironment.ServiceBusConnectionString,
                        scope.QueueName),
                    SessionId = sessionId
                };
                var receiver = new QueueReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    sessionSettings);

                sequenceNumber ??= 1;
                IAsyncEnumerable<ServiceBusMessage> peekedMessages = receiver.PeekRangeBySequenceAsync(
                    fromSequenceNumber: (long)sequenceNumber,
                    maxMessages: messageCt);

                // verify peeked == send
                var ct = 0;
                await foreach (ServiceBusMessage peekedMessage in peekedMessages)
                {
                    var peekedText = Encoding.Default.GetString(peekedMessage.Body);
                    var sentMsg = sentMessageIdToMsg[peekedMessage.MessageId];

                    sentMessageIdToMsg.Remove(peekedMessage.MessageId);
                    Assert.AreEqual(Encoding.Default.GetString(sentMsg.Body), peekedText);
                    Assert.AreEqual(sentMsg.PartitionKey, peekedMessage.PartitionKey);
                    Assert.IsTrue(peekedMessage.SystemProperties.SequenceNumber >= sequenceNumber);
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
        public async Task PeekMultipleSessions_ShouldThrow()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCt = 10;
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt, sessionId);
                await sender.SendRangeAsync(sentMessages);

                var sessionSettings = new SessionOptions()
                {
                    Connection = new ServiceBusConnection(
                        TestEnvironment.ServiceBusConnectionString,
                        scope.QueueName),
                    SessionId = sessionId
                };
                var receiver1 = new QueueReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    sessionSettings);
                var receiver2 = new QueueReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    sessionSettings);
                Dictionary<string, ServiceBusMessage> sentMessageIdToMsg = new Dictionary<string, ServiceBusMessage>();

                // peek the messages
                IAsyncEnumerable<ServiceBusMessage> peekedMessages1 = receiver1.PeekRangeBySequenceAsync(
                    fromSequenceNumber: 1,
                    maxMessages: messageCt);
                IAsyncEnumerable<ServiceBusMessage> peekedMessages2 = receiver2.PeekRangeBySequenceAsync(
                    fromSequenceNumber: 1,
                    maxMessages: messageCt);
                await peekedMessages1.GetAsyncEnumerator().MoveNextAsync();
                Assert.That(async () => await peekedMessages2.GetAsyncEnumerator().MoveNextAsync(), Throws.Exception);
            }
        }

        [Test]
        [TestCase(10, 2)]
        [TestCase(10, 5)]
        [TestCase(50, 1)]
        [TestCase(50, 10)]
        public async Task PeekRange_IncrementsSequenceNumber(int messageCt, int peekCt)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                var sender = new QueueSenderClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt, sessionId);
                await sender.SendRangeAsync(sentMessages);

                var sessionSettings = new SessionOptions()
                {
                    Connection = new ServiceBusConnection(
                        TestEnvironment.ServiceBusConnectionString,
                        scope.QueueName),
                    SessionId = sessionId
                };
                var receiver = new QueueReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    sessionSettings);


                long seq = 0;
                for (int i = 0; i < messageCt / peekCt; i++)
                {
                    IAsyncEnumerable<ServiceBusMessage> peekedMessages = receiver.PeekRangeAsync(
                        maxMessages: peekCt);


                    await foreach (ServiceBusMessage msg in peekedMessages)
                    {
                        Assert.IsTrue(msg.SystemProperties.SequenceNumber > seq);
                        if (seq > 0)
                        {
                            Assert.IsTrue(msg.SystemProperties.SequenceNumber == seq + 1);
                        }
                        seq = msg.SystemProperties.SequenceNumber;
                    }
                }
            }
        }

        [Test]
        [TestCase(10)]
        [TestCase(50)]
        public async Task Peek_IncrementsSequenceNmber(int messageCt)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt, sessionId);
                await sender.SendRangeAsync(sentMessages);

                var sessionSettings = new SessionOptions()
                {
                    Connection = new ServiceBusConnection(
                        TestEnvironment.ServiceBusConnectionString,
                        scope.QueueName),
                    SessionId = sessionId
                };
                var receiver = new QueueReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    sessionSettings);


                long seq = 0;
                for (int i = 0; i < messageCt; i++)
                {
                    ServiceBusMessage msg = await receiver.PeekAsync();
                    Assert.IsTrue(msg.SystemProperties.SequenceNumber > seq);
                    if (seq > 0)
                    {
                        Assert.IsTrue(msg.SystemProperties.SequenceNumber == seq + 1);
                    }
                    seq = msg.SystemProperties.SequenceNumber;
                }
            }
        }

        [Test]
        public async Task RoundRobinSessions()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCt = 10;
                HashSet<string> sessions = new HashSet<string>() { "1", "2", "3" };

                // send the messages
                foreach (string session in sessions)
                {
                    await sender.SendRangeAsync(GetMessages(messageCt, session));
                }

                // create receiver not scoped to a specific session
                for (int i = 0; i < 10; i++)
                {
                    var sessionSettings = new SessionOptions()
                    {
                        Connection = new ServiceBusConnection(
                            TestEnvironment.ServiceBusConnectionString,
                            scope.QueueName),
                        SessionId = null
                    };

                    var receiver = new QueueReceiverClient(
                        TestEnvironment.ServiceBusConnectionString,
                        scope.QueueName,
                        sessionSettings);
                    IAsyncEnumerable<ServiceBusMessage> peekedMessages = receiver.PeekRangeBySequenceAsync(
                        fromSequenceNumber: 1,
                        maxMessages: 10);

                    await foreach (ServiceBusMessage peekedMessage in peekedMessages)
                    {
                        var sessionId = await receiver.Session.GetSessionId();
                        Assert.AreEqual(sessionId, peekedMessage.SessionId);
                    }

                    // Close the receiver client when we are done with it. Since the sessionClient doesn't own the underlying connection, the connection remains open, but the session link will be closed.
                    await receiver.CloseAsync();
                }
            }
        }

        [Test]
        public async Task ReceiveMessagesInPeekLockMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                var sessionId = "sessionId1";
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount, sessionId);
                await sender.SendRangeAsync(messages);

                ServiceBusConnection conn = new ServiceBusConnection(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var sessionOptions = new SessionOptions()
                {
                    SessionId = sessionId,
                    Connection = conn
                };
                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName, sessionOptions);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                await foreach (var item in receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    Assert.AreEqual(item.SessionId, messageEnum.Current.SessionId);
                    Assert.AreEqual(item.SystemProperties.DeliveryCount, 1);
                }
                Assert.AreEqual(receivedMessageCount, messageCount);

                messageEnum.Reset();
                IAsyncEnumerable<ServiceBusMessage> peekMessages = receiver.PeekRangeAsync(messageCount);
                await foreach (var item in peekMessages)
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.SessionId, messageEnum.Current.SessionId);
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                }
            }
        }

        [Test]
        public async Task ReceiveMessagesInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                var sessionId = "sessionId1";
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount, sessionId);
                await sender.SendRangeAsync(messages);

                ServiceBusConnection conn = new ServiceBusConnection(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var sessionOptions = new SessionOptions()
                {
                    SessionId = sessionId,
                    Connection = conn
                };

                var clientOptions = new QueueReceiverClientOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete,
                };
                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName, sessionOptions, clientOptions);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                await foreach (var item in receiver.ReceiveBatchAsync(messageCount))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.SessionId, messageEnum.Current.SessionId);
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    receivedMessageCount++;
                }
                Assert.AreEqual(receivedMessageCount, messageCount);

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);
            }
        }
    }
}
