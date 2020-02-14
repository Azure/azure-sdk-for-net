// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Receiver;
using Azure.Messaging.ServiceBus.Sender;
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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                await sender.SendRangeAsync(GetMessages(10));
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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.FullyQualifiedNamespace, scope.QueueName, credential);
                await sender.SendAsync(GetMessage());
            }
        }

        [Test]
        public async Task Send_Connection_Topic()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var conn = new ServiceBusConnection(TestEnvironment.ServiceBusConnectionString, scope.TopicName);
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

                await using var sender = new ServiceBusSenderClient(conn, options);
                await sender.SendAsync(GetMessage());
            }
        }

        [Test]
        public async Task Send_Topic_Session()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
               await using var conn = new ServiceBusConnection(TestEnvironment.ServiceBusConnectionString, scope.TopicName);
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
                await using var sender = new ServiceBusSenderClient(conn, options);
                var message = GetMessage();
                message.SessionId = "1";
                await sender.SendAsync(message);
            }
        }

        [Test]
        public async Task ClientProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                Assert.AreEqual(scope.QueueName, sender.EntityName);
                Assert.AreEqual(TestEnvironment.FullyQualifiedNamespace, sender.FullyQualifiedNamespace);
            }
        }

        [Test]
        public async Task Schedule()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var scheduleTime = DateTimeOffset.UtcNow.AddHours(10);
                var sequenceNum = await sender.ScheduleMessageAsync(GetMessage(), scheduleTime);

                await using var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                ServiceBusMessage msg = await receiver.PeekBySequenceAsync(sequenceNum);
                Assert.AreEqual(0, Convert.ToInt32(new TimeSpan(scheduleTime.Ticks - msg.ScheduledEnqueueTimeUtc.Ticks).TotalSeconds));

                await sender.CancelScheduledMessageAsync(sequenceNum);
                msg = await receiver.PeekBySequenceAsync(sequenceNum);
                Assert.IsNull(msg);
            }
        }
    }
}
