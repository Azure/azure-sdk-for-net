// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCt = 10;
                var sessionId = Guid.NewGuid().ToString();

                // send the messages
                IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt, sessionId, partitionKey);
                await sender.SendBatchAsync(sentMessages);
                Dictionary<string, ServiceBusMessage> sentMessageIdToMsg = new Dictionary<string, ServiceBusMessage>();
                foreach (ServiceBusMessage message in sentMessages)
                {
                    sentMessageIdToMsg.Add(message.MessageId, message);
                }

                var options = new ServiceBusReceiverClientOptions()
                {
                    SessionId = sessionId,
                    IsSessionEntity = true
                };
                var receiver = new ServiceBusReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    options);

                sequenceNumber ??= 1;
                IAsyncEnumerable<ServiceBusMessage> peekedMessages = receiver.PeekBatchBySequenceAsync(
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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCt = 10;
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt, sessionId);
                await sender.SendBatchAsync(sentMessages);

                var options = new ServiceBusReceiverClientOptions()
                {
                    SessionId = sessionId,
                    IsSessionEntity = true
                };
                var receiver1 = new ServiceBusReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    options);
                var receiver2 = new ServiceBusReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    options);
                Dictionary<string, ServiceBusMessage> sentMessageIdToMsg = new Dictionary<string, ServiceBusMessage>();

                // peek the messages
                IAsyncEnumerable<ServiceBusMessage> peekedMessages1 = receiver1.PeekBatchBySequenceAsync(
                    fromSequenceNumber: 1,
                    maxMessages: messageCt);
                IAsyncEnumerable<ServiceBusMessage> peekedMessages2 = receiver2.PeekBatchBySequenceAsync(
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
                var sender = new ServiceBusSenderClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt, sessionId);
                await sender.SendBatchAsync(sentMessages);

                var options = new ServiceBusReceiverClientOptions()
                {
                    SessionId = sessionId,
                    IsSessionEntity = true
                };
                var receiver = new ServiceBusReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    options);


                long seq = 0;
                for (int i = 0; i < messageCt / peekCt; i++)
                {
                    IAsyncEnumerable<ServiceBusMessage> peekedMessages = receiver.PeekBatchAsync(
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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var sessionId = Guid.NewGuid().ToString();
                // send the messages
                IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt, sessionId);
                await sender.SendBatchAsync(sentMessages);

                var options = new ServiceBusReceiverClientOptions()
                {
                    SessionId = sessionId,
                    IsSessionEntity = true
                };
                var receiver = new ServiceBusReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    options);


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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCt = 10;
                HashSet<string> sessions = new HashSet<string>() { "1", "2", "3" };

                // send the messages
                foreach (string session in sessions)
                {
                    await sender.SendBatchAsync(GetMessages(messageCt, session));
                }

                // create receiver not scoped to a specific session
                for (int i = 0; i < 10; i++)
                {
                    var options = new ServiceBusReceiverClientOptions()
                    {
                        IsSessionEntity = true
                    };

                    var receiver = new ServiceBusReceiverClient(
                        TestEnvironment.ServiceBusConnectionString,
                        scope.QueueName,
                        options);
                    IAsyncEnumerable<ServiceBusMessage> peekedMessages = receiver.PeekBatchBySequenceAsync(
                        fromSequenceNumber: 1,
                        maxMessages: 10);

                    await foreach (ServiceBusMessage peekedMessage in peekedMessages)
                    {
                        var sessionId = await receiver.Session.GetSessionIdAsync();
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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                var sessionId = "sessionId1";
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount, sessionId);
                await sender.SendBatchAsync(messages);

                ServiceBusConnection conn = new ServiceBusConnection(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var options = new ServiceBusReceiverClientOptions()
                {
                    SessionId = sessionId,
                    IsSessionEntity = true
                };
                var receiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName, options);
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
                IAsyncEnumerable<ServiceBusMessage> peekMessages = receiver.PeekBatchAsync(messageCount);
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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                var sessionId = "sessionId1";
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount, sessionId);
                await sender.SendBatchAsync(messages);

                ServiceBusConnection conn = new ServiceBusConnection(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var clientOptions = new ServiceBusReceiverClientOptions()
                {
                    SessionId = sessionId,
                    IsSessionEntity = true,
                    ReceiveMode = ReceiveMode.ReceiveAndDelete
                };

                var receiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName, clientOptions);
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

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task Receive_Event(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var sender = new ServiceBusSenderClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                for (int i = 0; i < numThreads; i++)
                {
                    var sessionId = Guid.NewGuid().ToString();
                    await sender.SendAsync(GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                var clientOptions = new ServiceBusReceiverClientOptions()
                {
                    IsSessionEntity = true,
                    ReceiveMode = ReceiveMode.ReceiveAndDelete
                };
                await using var receiver = new ServiceBusReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    clientOptions);
                int messageCt = 0;

                receiver.ProcessSessionMessageAsync += ProcessMessage;
                receiver.ProcessErrorAsync += ExceptionHandler;

                var options = new MessageHandlerOptions()
                {
                    MaxConcurrentCalls = numThreads
                };

                await receiver.StartProcessingAsync(options);

                // Allow 5s to be sure there is enough time for a message to be processed per thread.
                await Task.Delay(1000 * 5);

                async Task ProcessMessage(ServiceBusMessage message, ServiceBusSession session)
                {
                    await receiver.CompleteAsync(message.SystemProperties.LockToken);
                    Interlocked.Increment(ref messageCt);
                    sessions.TryRemove(message.SessionId, out bool _);
                    Assert.AreEqual(message.SessionId, await session.GetSessionIdAsync());
                    Assert.IsNotNull(await session.GetLockedUntilUtcAsync());
                    await Task.Delay(1000 * 5);
                }

                // we only give each thread enough time to process one message, so the total number of messages
                // processed should equal the number of threads
                Assert.AreEqual(numThreads, messageCt);

                // we should have received messages from each of the sessions
                Assert.AreEqual(0, sessions.Count);
            }
        }


        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task Receive_Event_SessionId(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true))
            {
                await using var sender = new ServiceBusSenderClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);

                // send 1 message for each thread and use a different session for each message
                ConcurrentDictionary<string, bool> sessions = new ConcurrentDictionary<string, bool>();
                string sessionId = null;
                for (int i = 0; i < numThreads; i++)
                {
                    sessionId = Guid.NewGuid().ToString();
                    await sender.SendAsync(GetMessage(sessionId));
                    sessions.TryAdd(sessionId, true);
                }

                var clientOptions = new ServiceBusReceiverClientOptions()
                {
                    // just use the last sessionId from the loop above
                    SessionId = sessionId,
                    IsSessionEntity = true,
                };

                await using var receiver = new ServiceBusReceiverClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName,
                    clientOptions);
                int messageCt = 0;

                receiver.ProcessSessionMessageAsync += ProcessMessage;
                receiver.ProcessErrorAsync += ExceptionHandler;

                var options = new MessageHandlerOptions()
                {
                    MaxConcurrentCalls = numThreads
                };

                await receiver.StartProcessingAsync(options);

                // Allow 5s to be sure there is enough time for a message to be processed per thread.
                await Task.Delay(1000 * 5);

                async Task ProcessMessage(ServiceBusMessage message, ServiceBusSession session)
                {
                    await receiver.CompleteAsync(message.SystemProperties.LockToken);
                    Interlocked.Increment(ref messageCt);
                    sessions.TryRemove(message.SessionId, out bool _);
                    Assert.AreEqual(sessionId, message.SessionId);
                    Assert.AreEqual(sessionId, await session.GetSessionIdAsync());
                    Assert.IsNotNull(await session.GetLockedUntilUtcAsync());
                    await Task.Delay(1000 * 5);
                }

                // although we are allowing concurrent calls,
                // since we are specifying a specific session, the
                // concurrency won't really work as only one receiver can be linked to the session; TODO may want to add validation for this
                Assert.AreEqual(1, messageCt);

                // we should have received messages from only the specified session
                Assert.AreEqual(numThreads - 1, sessions.Count);
            }
        }
    }
}
