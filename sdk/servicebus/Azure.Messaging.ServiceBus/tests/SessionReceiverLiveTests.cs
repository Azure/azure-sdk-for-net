// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Receiver;
using Azure.Messaging.ServiceBus.Sender;
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
            var sender = new ServiceBusSenderClient(ConnString, SessionQueueName);
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
            var receiver = new SessionReceiverClient(sessionId, ConnString, SessionQueueName);

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

        [Test]
        public async Task PeekMultipleSessions_ShouldThrow()
        {
            var sender = new ServiceBusSenderClient(ConnString, SessionQueueName);
            var messageCt = 10;
            var sessionId = Guid.NewGuid().ToString();
            // send the messages
            IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt, sessionId);
            await sender.SendRangeAsync(sentMessages);

            var receiver1 = new SessionReceiverClient(sessionId, ConnString, SessionQueueName);
            var receiver2 = new SessionReceiverClient(sessionId, ConnString, SessionQueueName);
            Dictionary<string, ServiceBusMessage> sentMessageIdToMsg = new Dictionary<string, ServiceBusMessage>();

            // peek the messages
            IAsyncEnumerable<ServiceBusMessage> peekedMessages1 = receiver1.PeekRangeBySequenceAsync(
                fromSequenceNumber: 1,
                maxMessages: messageCt);
            IAsyncEnumerable<ServiceBusMessage> peekedMessages2 = receiver2.PeekRangeBySequenceAsync(
                fromSequenceNumber: 1,
                maxMessages: messageCt);
            await peekedMessages1.GetAsyncEnumerator().MoveNextAsync();
            try
            {
                await peekedMessages2.GetAsyncEnumerator().MoveNextAsync();
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail("No exception!");
        }

        [Test]
        [TestCase(10, 2)]
        [TestCase(10, 5)]
        [TestCase(50, 1)]
        [TestCase(50, 10)]
        public async Task PeekRange_IncrementsSequenceNmber(int messageCt, int peekCt)
        {
            var sender = new ServiceBusSenderClient(ConnString, SessionQueueName);
            var sessionId = Guid.NewGuid().ToString();
            // send the messages
            IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt, sessionId);
            await sender.SendRangeAsync(sentMessages);

            var receiver = new SessionReceiverClient(sessionId, ConnString, SessionQueueName);


            long seq = 0;
            for (int i = 0; i < messageCt/peekCt; i++)
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

        [Test]
        [TestCase(10)]
        [TestCase(50)]
        public async Task Peek_IncrementsSequenceNmber(int messageCt)
        {
            var sender = new ServiceBusSenderClient(ConnString, SessionQueueName);
            var sessionId = Guid.NewGuid().ToString();
            // send the messages
            IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt, sessionId);
            await sender.SendRangeAsync(sentMessages);

            var receiver = new SessionReceiverClient(sessionId, ConnString, SessionQueueName);


            long seq = 0;
            for (int i = 0; i < messageCt ; i++)
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

        [Test]
        public async Task RoundRobinSessions()
        {
            var sender = new ServiceBusSenderClient(ConnString, SessionQueueName);
            var messageCt = 10;
            HashSet<string> sessions = new HashSet<string>() { "1", "2", "3" };

            // send the messages
            foreach (string session in sessions)
            {
                await sender.SendRangeAsync(GetMessages(messageCt, session));
            }

            var receiverClient = new QueueReceiverClient(ConnString, SessionQueueName);
            var sessionId = "";
            // create receiver not scoped to a specific session
            for (int i = 0; i < 10; i++)
            {
                SessionReceiverClient sessionClient = receiverClient.GetSessionReceiverClient();
                IAsyncEnumerable<ServiceBusMessage> peekedMessages = sessionClient.PeekRangeBySequenceAsync(
                    fromSequenceNumber: 1,
                    maxMessages: 10);

                await foreach (ServiceBusMessage peekedMessage in peekedMessages)
                {
                    Assert.AreEqual(sessionClient.SessionId, peekedMessage.SessionId);
                }
                TestContext.Progress.WriteLine(sessionId);
                sessionId = sessionClient.SessionId;

                // Close the session client when we are done with it. Since the sessionClient doesn't own the underlying connection, the connection remains open, but the session link will be closed.
                await sessionClient.CloseAsync();
            }
        }
    }
}
