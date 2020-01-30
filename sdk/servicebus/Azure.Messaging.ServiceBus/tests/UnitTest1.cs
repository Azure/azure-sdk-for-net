// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using Azure.Messaging.ServiceBus.Producer;
using Azure.Messaging.ServiceBus;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using System.Net;
using Azure.Messaging.ServiceBus.Consumer;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Azure.Amqp.Framing;

namespace Microsoft.Azure.Template.Tests
{
    public class UnitTest1
    {
        private static string ConnString = Environment.GetEnvironmentVariable("SERVICE_BUS_CONN_STRING", EnvironmentVariableTarget.Machine);
        private static string TenantId = Environment.GetEnvironmentVariable("TENANT_ID", EnvironmentVariableTarget.Machine);
        private static string ClientId = Environment.GetEnvironmentVariable("CLIENT_ID", EnvironmentVariableTarget.Machine);
        private static string ClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET", EnvironmentVariableTarget.Machine);

        private const string QueueName = "josh";
        private const string SessionQueueName = "joshsession";
        private const string TopicName = "joshtopic";
        private const string Endpoint = "jolovservicebus.servicebus.windows.net";

        [Test]
        public async Task Send_ConnString()
        {
            var sender = new ServiceBusSenderClient(ConnString, QueueName);
            await sender.SendAsync(GetMessages(10));
        }

        [Test]
        public async Task Send_Token()
        {
            ClientSecretCredential credential = new ClientSecretCredential(
                TenantId,
                ClientId,
                ClientSecret);

            var sender = new ServiceBusSenderClient(Endpoint, QueueName, credential);
            await sender.SendAsync(GetMessage());
        }

        [Test]
        public async Task Send_Connection_Topic()
        {
            var conn = new ServiceBusConnection(ConnString, TopicName);
            var options = new ServiceBusSenderClientOptions
            {
                RetryOptions = new ServiceBusRetryOptions(),
                ConnectionOptions = new ServiceBusConnectionOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets,
                    Proxy = new WebProxy("localHost")
                }
            };
            options.RetryOptions.Mode = ServiceBusRetryMode.Exponential;
            var sender = new ServiceBusSenderClient(conn, options);

            await sender.SendAsync(GetMessage());
        }

        [Test]
        public async Task Send_Topic_Session()
        {
            var conn = new ServiceBusConnection(ConnString, "joshtopic");
            var options = new ServiceBusSenderClientOptions
            {
                RetryOptions = new ServiceBusRetryOptions(),
                ConnectionOptions = new ServiceBusConnectionOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets,
                    Proxy = new WebProxy("localHost")
                }
            };
            options.RetryOptions.Mode = ServiceBusRetryMode.Exponential;
            var sender = new ServiceBusSenderClient(conn, options);
            var message = GetMessage();
            message.SessionId = "1";
            await sender.SendAsync(message);
        }

        [Test]
        public async Task Receive()
        {
            var sender = new ServiceBusSenderClient(ConnString, QueueName);
            await sender.SendAsync(GetMessages(10));

            var receiver = new ServiceBusReceiverClient(ConnString, QueueName);
            var msgs = await receiver.ReceiveAsync(0, 10);
            int ct = 0;
            foreach (ServiceBusMessage msg in msgs)
            {
                var text = Encoding.Default.GetString(msg.Body);
                TestContext.Progress.WriteLine($"#{++ct} - {msg.Label}: {text}");
            }
        }

        [Test]
        public async Task Peek()
        {
            var sender = new ServiceBusSenderClient(ConnString, QueueName);
            var messageCt = 10;

            IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt);
            await sender.SendAsync(sentMessages);

            var receiver = new ServiceBusReceiverClient(ConnString, QueueName);

            Dictionary<string, string> sentMessageIdToLabel = new Dictionary<string, string>();
            foreach (ServiceBusMessage message in sentMessages)
            {
                sentMessageIdToLabel.Add(message.MessageId, Encoding.Default.GetString(message.Body));
            }
            IAsyncEnumerable<ServiceBusMessage> peekedMessages = receiver.PeekAsync(
                fromSequenceNumber: 1,
                messageCount: messageCt);

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
            await sender.SendAsync(sentMessages);

            // peek the messages
            var receiver = new ServiceBusReceiverClient(ConnString, SessionQueueName);
            Dictionary<string, ServiceBusMessage> sentMessageIdToMsg = new Dictionary<string, ServiceBusMessage>();
            foreach (ServiceBusMessage message in sentMessages)
            {
                sentMessageIdToMsg.Add(message.MessageId, message);
            }
            sequenceNumber ??= 1;
            IAsyncEnumerable<ServiceBusMessage> peekedMessages = receiver.PeekAsync(
                fromSequenceNumber: (long)sequenceNumber,
                messageCount: messageCt,
                sessionId: sessionId);
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
        public void ClientProperties()
        {
            var sender = new ServiceBusSenderClient(ConnString, QueueName);
            Assert.AreEqual(QueueName, sender.EntityName);
            Assert.AreEqual(Endpoint, sender.FullyQualifiedNamespace);
        }

        private IEnumerable<ServiceBusMessage> GetMessages(int count, string sessionId = null, string partitionKey = null)
        {
            var messages = new List<ServiceBusMessage>();
            for (int i = 0; i < count; i++)
            {
                messages.Add(GetMessage(sessionId, partitionKey));
            }
            return messages;
        }

        private ServiceBusMessage GetMessage(string sessionId = null, string partitionKey = null)
        {
            var msg = new ServiceBusMessage(GetRandomBuffer(100))
            {
                Label = $"test-{Guid.NewGuid()}",
                MessageId = Guid.NewGuid().ToString()
            };
            if (sessionId != null)
            {
                msg.SessionId = sessionId;
            }
            if (partitionKey != null)
            {
                msg.PartitionKey = partitionKey;
            }
            return msg;
        }

        private byte[] GetRandomBuffer(long size)
        {
            var chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

            var csp = new RNGCryptoServiceProvider();
            var bytes = new byte[4];
            csp.GetBytes(bytes);
            var random = new Random(BitConverter.ToInt32(bytes, 0));
            var buffer = new byte[size];
            random.NextBytes(buffer);
            var text = new byte[size];
            for (int i = 0; i < size; i++)
            {
                var idx = buffer[i] % chars.Length;
                text[i] = (byte)chars[idx];
            }
            return text;
        }
    }
}
