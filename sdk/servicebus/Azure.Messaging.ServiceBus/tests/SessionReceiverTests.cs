// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Receiver;
using Azure.Messaging.ServiceBus.Sender;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class SessionReceiverTests : ServiceBusTestBase
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
            var receiver = new SessionReceiverClient(ConnString, SessionQueueName, sessionId);

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

            var receiver1 = new SessionReceiverClient(ConnString, SessionQueueName, sessionId);
            var receiver2 = new SessionReceiverClient(ConnString, SessionQueueName, sessionId);
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
    }
}
