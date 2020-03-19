// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Tests;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Sender
{
    public class SenderLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task SendConnString()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString).GetSender(scope.QueueName);
                await sender.SendAsync(GetMessage());
            }
        }

        [Test]
        public async Task SendToken()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, GetTokenCredential());
                var sender = client.GetSender(scope.QueueName);
                await sender.SendAsync(GetMessage());
            }
        }

        [Test]
        public async Task SendConnectionTopic()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets,
                    Proxy = WebRequest.DefaultWebProxy,
                    RetryOptions = new ServiceBusRetryOptions()
                    {
                        Mode = ServiceBusRetryMode.Exponential
                    }
                };
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, options);

                ServiceBusSender sender = client.GetSender(scope.TopicName);
                await sender.SendAsync(GetMessage());
            }
        }

        [Test]
        public async Task SendTopicSession()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets,
                    Proxy = WebRequest.DefaultWebProxy,
                    RetryOptions = new ServiceBusRetryOptions()
                    {
                        Mode = ServiceBusRetryMode.Exponential
                    }
                };
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, options);

                ServiceBusSender sender = client.GetSender(scope.TopicName);
                await sender.SendAsync(GetMessage("sessionId"));
            }
        }

        [Test]
        public async Task SenderCanSendAMessageBatch()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                ServiceBusMessageBatch messageBatch = AddMessages(batch, 3);

                await sender.SendBatchAsync(messageBatch);
            }
        }

        [Test]
        public async Task SenderCanSendAnEmptyBodyMessageBatch()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                batch.TryAdd(new ServiceBusMessage(Array.Empty<byte>()));

                await sender.SendBatchAsync(batch);
            }
        }

        [Test]
        public async Task SenderCanSendLargeMessageBatch()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();

                // Actual limit is 262144 bytes for a single message.
                batch.TryAdd(new ServiceBusMessage(new byte[100000 / 3]));
                batch.TryAdd(new ServiceBusMessage(new byte[100000 / 3]));
                batch.TryAdd(new ServiceBusMessage(new byte[100000 / 3]));

                await sender.SendBatchAsync(batch);
            }
        }

        [Test]
        public async Task SenderCannotSendLargerThanMaximumSize()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();

                // Actual limit is 262144 bytes for a single message.
                ServiceBusMessage message = new ServiceBusMessage(new byte[300000]);

                Assert.That(async () => await sender.SendAsync(message), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessageSizeExceeded));
            }
        }

        [Test]
        public async Task TryAddReturnsFalseIfSizeExceed()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();

                // Actual limit is 262144 bytes for a single message.
                Assert.That(() => batch.TryAdd(new ServiceBusMessage(new byte[200000])), Is.True, "A message was rejected by the batch; all messages should be accepted.");
                Assert.That(() => batch.TryAdd(new ServiceBusMessage(new byte[200000])), Is.False, "A message was rejected by the batch; message size exceed.");

                await sender.SendBatchAsync(batch);
            }
        }

        [Test]
        public async Task ClientProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString).GetSender(scope.QueueName);
                Assert.AreEqual(scope.QueueName, sender.EntityPath);
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
                ServiceBusReceivedMessage msg = await receiver.PeekAtAsync(sequenceNum);
                Assert.AreEqual(0, Convert.ToInt32(new TimeSpan(scheduleTime.Ticks - msg.ScheduledEnqueueTime.Ticks).TotalSeconds));

                await sender.CancelScheduledMessageAsync(sequenceNum);
                msg = await receiver.PeekAtAsync(sequenceNum);
                Assert.IsNull(msg);
            }
        }

        [Test]
        public async Task CloseSenderShouldNotCloseConnection()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.GetSender(scope.QueueName);
                var scheduleTime = DateTimeOffset.UtcNow.AddHours(10);
                var sequenceNum = await sender.ScheduleMessageAsync(GetMessage(), scheduleTime);
                await sender.DisposeAsync(); // shouldn't close connection, but should close send link

                Assert.That(async () => await sender.SendAsync(GetMessage()),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.ClientClosed));
                Assert.That(async () => await sender.ScheduleMessageAsync(GetMessage(), default), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.ClientClosed));
                Assert.That(async () => await sender.CancelScheduledMessageAsync(sequenceNum), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.ClientClosed));

                // receive should still work
                await using var receiver = client.GetReceiver(scope.QueueName);
                ServiceBusReceivedMessage msg = await receiver.PeekAtAsync(sequenceNum);
                Assert.AreEqual(0, Convert.ToInt32(new TimeSpan(scheduleTime.Ticks - msg.ScheduledEnqueueTime.Ticks).TotalSeconds));
            }
        }

        [Test]
        public async Task CreateSenderWithoutParentReference()
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

        [Test]
        public async Task CanSendReceivedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(
                    TestEnvironment.FullyQualifiedNamespace,
                    GetTokenCredential());
                await using var sender = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString).GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                var messageCt = 10;
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCt).AsEnumerable<ServiceBusMessage>();
                await sender.SendBatchAsync(batch);

                var receiver = client.GetReceiver(scope.QueueName, new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ReceiveMode.PeekLock
                });
                var receivedMessages = await receiver.ReceiveBatchAsync(messageCt);

                foreach (ServiceBusReceivedMessage msg in receivedMessages)
                {
                    await sender.SendAsync(ServiceBusMessage.CreateFrom(msg));
                }

                int receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCt))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                }
                Assert.AreEqual(messageCt, receivedMessages.Count);

            }
        }

        [Test]
        public async Task CreateBatchThrowsIftheEntityDoesNotExist()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEntity("FakeEntity");
                await using var client = new ServiceBusClient(connectionString);

                ServiceBusSender sender = client.GetSender("FakeEntity");
                Assert.That(async () => await sender.CreateBatchAsync(), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));
            }
        }
    }
}
