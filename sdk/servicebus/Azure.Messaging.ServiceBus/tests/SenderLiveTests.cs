// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Tests;
using NUnit.Framework;

namespace Microsoft.Azure.Template.Tests
{
    public class SenderLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task Send_ConnString()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString).GetSender(scope.QueueName);
                await sender.SendBatchAsync(GetMessages(10));
            }
        }

        [Test]
        public async Task Send_Token()
        {
            ClientSecretCredential credential = new ClientSecretCredential(
                TestEnvironment.ServiceBusTenant,
                TestEnvironment.ServiceBusClient,
                TestEnvironment.ServiceBusSecret);

            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, credential);
                var sender = client.GetSender(scope.QueueName);
                await sender.SendAsync(GetMessage());
            }
        }

        [Test]
        public async Task Send_Connection_Topic()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets,
                    Proxy = WebRequest.DefaultWebProxy
                };
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, options);

                var senderOptions = new ServiceBusSenderOptions
                {
                    RetryOptions = new ServiceBusRetryOptions()
                    {
                        Mode = ServiceBusRetryMode.Exponential
                    }
                };
                ServiceBusSender sender = client.GetSender(scope.TopicName, senderOptions);
                await sender.SendAsync(GetMessage());
            }
        }

        [Test]
        public async Task Send_Topic_Session()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets,
                    Proxy = WebRequest.DefaultWebProxy
                };
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, options);

                var senderOptions = new ServiceBusSenderOptions
                {
                    RetryOptions = new ServiceBusRetryOptions()
                    {
                        Mode = ServiceBusRetryMode.Exponential
                    }
                };
                ServiceBusSender sender = client.GetSender(scope.TopicName, senderOptions);
                await sender.SendAsync(GetMessage("sessionId"));
            }
        }

        [Test]
        public async Task ClientProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString).GetSender(scope.QueueName);
                Assert.AreEqual(scope.QueueName, sender.EntityName);
                Assert.AreEqual(TestEnvironment.FullyQualifiedNamespace, sender.FullyQualifiedNamespace);
            }
        }

        [Test]
        public async Task Schedule()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.GetSender(scope.QueueName);
                var scheduleTime = DateTimeOffset.UtcNow.AddHours(10);
                var sequenceNum = await sender.ScheduleMessageAsync(GetMessage(), scheduleTime);

                await using var receiver = client.GetReceiver(scope.QueueName);
                ServiceBusMessage msg = await receiver.PeekBySequenceAsync(sequenceNum);
                Assert.AreEqual(0, Convert.ToInt32(new TimeSpan(scheduleTime.Ticks - msg.ScheduledEnqueueTimeUtc.Ticks).TotalSeconds));

                await sender.CancelScheduledMessageAsync(sequenceNum);
                msg = await receiver.PeekBySequenceAsync(sequenceNum);
                Assert.IsNull(msg);
            }
        }

        [Test]
        public async Task Close_Sender_Should_Not_Close_Connection()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.GetSender(scope.QueueName);
                var scheduleTime = DateTimeOffset.UtcNow.AddHours(10);
                var sequenceNum = await sender.ScheduleMessageAsync(GetMessage(), scheduleTime);
                await sender.CloseAsync(); // shouldn't close connection, but should close send link

                Assert.That(async () => await sender.SendAsync(GetMessage()), Throws.Exception);

                await using var receiver = client.GetReceiver(scope.QueueName);
                ServiceBusMessage msg = await receiver.PeekBySequenceAsync(sequenceNum);
                Assert.AreEqual(0, Convert.ToInt32(new TimeSpan(scheduleTime.Ticks - msg.ScheduledEnqueueTimeUtc.Ticks).TotalSeconds));

                await sender.CancelScheduledMessageAsync(sequenceNum);
                msg = await receiver.PeekBySequenceAsync(sequenceNum);
                Assert.IsNull(msg);
            }
        }

        [Test]
        public async Task Create_Sender_Without_Parent_Reference()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString).GetSender(scope.QueueName);
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);
                    await sender.SendAsync(GetMessage());
                }
            }
        }
    }
}
