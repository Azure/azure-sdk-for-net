// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Messaging.ServiceBus.Receiver;
using Azure.Messaging.ServiceBus.Sender;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class ReceiverLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task Peek()
        {
            var sender = new ServiceBusSenderClient(ConnString, QueueName);
            var messageCt = 10;

            IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt);
            await sender.SendRangeAsync(sentMessages);

            var receiver = new QueueReceiverClient(ConnString, QueueName);

            Dictionary<string, string> sentMessageIdToLabel = new Dictionary<string, string>();
            foreach (ServiceBusMessage message in sentMessages)
            {
                sentMessageIdToLabel.Add(message.MessageId, Encoding.Default.GetString(message.Body));
            }
            IAsyncEnumerable<ServiceBusMessage> peekedMessages = receiver.PeekRangeAsync(
                maxMessages: messageCt);

            var ct = 0;
            await foreach (ServiceBusMessage peekedMessage in peekedMessages)
            {
                var peekedText = Encoding.Default.GetString(peekedMessage.Body);
                //var sentText = sentMessageIdToLabel[peekedMessage.MessageId];

                //sentMessageIdToLabel.Remove(peekedMessage.MessageId);
                //Assert.AreEqual(sentText, peekedText);

                TestContext.Progress.WriteLine($"{peekedMessage.Label}: {peekedText}");
                ct++;
            }
            Assert.AreEqual(messageCt, ct);
        }
    }
}
