// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Messaging.ServiceBus.Sender;
using Azure.Messaging.ServiceBus;
using System.Threading.Tasks;
using Azure.Identity;
using System.Net;
using Azure.Messaging.ServiceBus.Tests;
using System;
using Azure.Messaging.ServiceBus.Receiver;
using System.Xml.Schema;
using Azure.Core.Testing;
using Moq;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Core;
using Azure.Core.Pipeline;

namespace Microsoft.Azure.Template.Tests
{
    public class SenderLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task Send_ConnString()
        {
            var sender = new ServiceBusSenderClient(ConnString, QueueName);
            await sender.SendRangeAsync(GetMessages(10));
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
        public void ClientProperties()
        {
            var sender = new ServiceBusSenderClient(ConnString, QueueName);
            Assert.AreEqual(QueueName, sender.EntityName);
            Assert.AreEqual(Endpoint, sender.FullyQualifiedNamespace);
        }

        [Test]
        public async Task Schedule()
        {
            var sender = new ServiceBusSenderClient(ConnString, QueueName);
            var scheduleTime = DateTimeOffset.UtcNow.AddHours(10);
            var sequenceNum = await sender.ScheduleMessageAsync(GetMessage(), scheduleTime);

            var receiver = new QueueReceiverClient(ConnString, QueueName);
            ServiceBusMessage msg = await receiver.PeekBySequenceAsync(sequenceNum);
            Assert.AreEqual(0, Convert.ToInt32(new TimeSpan(scheduleTime.Ticks - msg.ScheduledEnqueueTimeUtc.Ticks).TotalSeconds));

            await sender.CancelScheduledMessageAsync(sequenceNum);
            msg = await receiver.PeekBySequenceAsync(sequenceNum);
            Assert.IsNull(msg);
        }
    }
}
