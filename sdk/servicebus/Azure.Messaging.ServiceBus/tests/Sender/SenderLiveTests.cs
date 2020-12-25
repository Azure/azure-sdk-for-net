// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task SendConnStringWithSharedKey()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString).CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());
            }
        }

        [Test]
        public async Task SendConnStringWithSignature()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions();
                var audience = ServiceBusConnection.BuildConnectionResource(options.TransportType, TestEnvironment.FullyQualifiedNamespace, scope.QueueName);
                var connectionString = TestEnvironment.BuildConnectionStringWithSharedAccessSignature(scope.QueueName, audience);

                await using var sender = new ServiceBusClient(connectionString, options).CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());
            }
        }

        [Test]
        public async Task SendToken()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());
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
                    WebProxy = WebRequest.DefaultWebProxy,
                    RetryOptions = new ServiceBusRetryOptions()
                    {
                        Mode = ServiceBusRetryMode.Exponential
                    }
                };
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, options);

                ServiceBusSender sender = client.CreateSender(scope.TopicName);
                await sender.SendMessageAsync(GetMessage());
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
                    WebProxy = WebRequest.DefaultWebProxy,
                    RetryOptions = new ServiceBusRetryOptions()
                    {
                        Mode = ServiceBusRetryMode.Exponential
                    }
                };
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, options);

                ServiceBusSender sender = client.CreateSender(scope.TopicName);
                await sender.SendMessageAsync(GetMessage("sessionId"));
            }
        }

        [Test]
        public async Task CanSendAMessageBatch()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                ServiceBusMessageBatch messageBatch = AddMessages(batch, 3);

                await sender.SendMessagesAsync(messageBatch);
            }
        }

        [Test]
        public async Task SendingEmptyBatchDoesNotThrow()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                await sender.SendMessagesAsync(batch);
            }
        }

        [Test]
        public async Task CanSendAnEmptyBodyMessageBatch()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>()));

                await sender.SendMessagesAsync(batch);
            }
        }

        [Test]
        public async Task CanSendLargeMessageBatch()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();

                // Actual limit is set by the service; query it from the batch.  Because this will be used for the
                // message body, leave some padding for the conversion and batch envelope.
                var size = (long)(Math.Floor(batch.MaxSizeInBytes / 3.0f) - 150);

                batch.TryAddMessage(new ServiceBusMessage(new byte[size]));
                batch.TryAddMessage(new ServiceBusMessage(new byte[size]));
                batch.TryAddMessage(new ServiceBusMessage(new byte[size]));

                await sender.SendMessagesAsync(batch);
            }
        }

        [Test]
        public async Task CannotSendLargerThanMaximumSize()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();

                // Actual limit is set by the service; query it from the batch.
                ServiceBusMessage message = new ServiceBusMessage(new byte[batch.MaxSizeInBytes + 10]);
                Assert.That(async () => await sender.SendMessageAsync(message), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessageSizeExceeded));
            }
        }

        [Test]
        public async Task TryAddReturnsFalseIfSizeExceed()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();

                // Actual limit is set by the service; query it from the batch.  Because this will be used for the
                // message body, leave some padding for the conversion and batch envelope.
                var padding = 500;
                var size = (batch.MaxSizeInBytes - padding);

                Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(new byte[size])), Is.True, "A message was rejected by the batch; all messages should be accepted.");
                Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(new byte[padding + 1])), Is.False, "A message was rejected by the batch; message size exceed.");

                await sender.SendMessagesAsync(batch);
            }
        }

        [Test]
        public async Task ClientProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString).CreateSender(scope.QueueName);
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
                await using var sender = client.CreateSender(scope.QueueName);
                var scheduleTime = DateTimeOffset.UtcNow.AddHours(10);
                var seq = await sender.ScheduleMessageAsync(GetMessage(), scheduleTime);

                await using var receiver = client.CreateReceiver(scope.QueueName);
                ServiceBusReceivedMessage msg = await receiver.PeekMessageAsync(seq);
                Assert.AreEqual(0, Convert.ToInt32(new TimeSpan(scheduleTime.Ticks - msg.ScheduledEnqueueTime.Ticks).TotalSeconds));

                await sender.CancelScheduledMessageAsync(seq);
                msg = await receiver.PeekMessageAsync(seq);
                Assert.IsNull(msg);
            }
        }

        [Test]
        public async Task ScheduleMultipleArray()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);
                var scheduleTime = DateTimeOffset.UtcNow.AddHours(10);
                var sequenceNums = await sender.ScheduleMessagesAsync(GetMessages(5), scheduleTime);
                await using var receiver = client.CreateReceiver(scope.QueueName);
                foreach (long seq in sequenceNums)
                {
                    ServiceBusReceivedMessage msg = await receiver.PeekMessageAsync(seq);
                    Assert.AreEqual(0, Convert.ToInt32(new TimeSpan(scheduleTime.Ticks - msg.ScheduledEnqueueTime.Ticks).TotalSeconds));
                }
                await sender.CancelScheduledMessagesAsync(sequenceNumbers: sequenceNums);

                foreach (long seq in sequenceNums)
                {
                    ServiceBusReceivedMessage msg = await receiver.PeekMessageAsync(seq);
                    Assert.IsNull(msg);
                }

                // can cancel empty array
                await sender.CancelScheduledMessagesAsync(sequenceNumbers: Array.Empty<long>());

                // cannot cancel null
                Assert.That(
                    async () => await sender.CancelScheduledMessagesAsync(sequenceNumbers: null),
                    Throws.InstanceOf<ArgumentNullException>());
            }
        }

        [Test]
        public async Task ScheduleMultipleList()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);
                var scheduleTime = DateTimeOffset.UtcNow.AddHours(10);
                var sequenceNums = await sender.ScheduleMessagesAsync(GetMessages(5), scheduleTime);
                await using var receiver = client.CreateReceiver(scope.QueueName);
                foreach (long seq in sequenceNums)
                {
                    ServiceBusReceivedMessage msg = await receiver.PeekMessageAsync(seq);
                    Assert.AreEqual(0, Convert.ToInt32(new TimeSpan(scheduleTime.Ticks - msg.ScheduledEnqueueTime.Ticks).TotalSeconds));
                }
                await sender.CancelScheduledMessagesAsync(sequenceNumbers: new List<long>(sequenceNums));

                foreach (long seq in sequenceNums)
                {
                    ServiceBusReceivedMessage msg = await receiver.PeekMessageAsync(seq);
                    Assert.IsNull(msg);
                }

                // can cancel empty list
                await sender.CancelScheduledMessagesAsync(sequenceNumbers: new List<long>());

                // cannot cancel null
                Assert.That(
                    async () => await sender.CancelScheduledMessagesAsync(sequenceNumbers: null),
                    Throws.InstanceOf<ArgumentNullException>());
            }
        }

        [Test]
        public async Task ScheduleMultipleEnumerable()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                await using var sender = client.CreateSender(scope.QueueName);
                var scheduleTime = DateTimeOffset.UtcNow.AddHours(10);
                var sequenceNums = await sender.ScheduleMessagesAsync(GetMessages(5), scheduleTime);
                await using var receiver = client.CreateReceiver(scope.QueueName);
                foreach (long seq in sequenceNums)
                {
                    ServiceBusReceivedMessage msg = await receiver.PeekMessageAsync(seq);
                    Assert.AreEqual(0, Convert.ToInt32(new TimeSpan(scheduleTime.Ticks - msg.ScheduledEnqueueTime.Ticks).TotalSeconds));
                }

                // use an enumerable
                await sender.CancelScheduledMessagesAsync(sequenceNumbers: GetEnumerable());

                IEnumerable<long> GetEnumerable()
                {
                    foreach (long seq in sequenceNums)
                    {
                        yield return seq;
                    }
                }

                foreach (long seq in sequenceNums)
                {
                    ServiceBusReceivedMessage msg = await receiver.PeekMessageAsync(seq);
                    Assert.IsNull(msg);
                }

                // can cancel empty enumerable
                await sender.CancelScheduledMessagesAsync(sequenceNumbers: Enumerable.Empty<long>());

                // cannot cancel null
                Assert.That(
                    async () => await sender.CancelScheduledMessagesAsync(sequenceNumbers: null),
                    Throws.InstanceOf<ArgumentNullException>());
            }
        }

        [Test]
        public async Task CloseSenderShouldNotCloseConnection()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);
                var scheduleTime = DateTimeOffset.UtcNow.AddHours(10);
                var sequenceNum = await sender.ScheduleMessageAsync(GetMessage(), scheduleTime);
                await sender.DisposeAsync(); // shouldn't close connection, but should close send link

                Assert.That(async () => await sender.SendMessageAsync(GetMessage()), Throws.InstanceOf<ObjectDisposedException>());
                Assert.That(async () => await sender.ScheduleMessageAsync(GetMessage(), default), Throws.InstanceOf<ObjectDisposedException>());
                Assert.That(async () => await sender.CancelScheduledMessageAsync(sequenceNum), Throws.InstanceOf<ObjectDisposedException>());

                // receive should still work
                await using var receiver = client.CreateReceiver(scope.QueueName);
                ServiceBusReceivedMessage msg = await receiver.PeekMessageAsync(sequenceNum);
                Assert.AreEqual(0, Convert.ToInt32(new TimeSpan(scheduleTime.Ticks - msg.ScheduledEnqueueTime.Ticks).TotalSeconds));
            }
        }

        [Test]
        public async Task CreateSenderWithoutParentReference()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString).CreateSender(scope.QueueName);
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);
                    await sender.SendMessageAsync(GetMessage());
                }
            }
        }

        [Test]
        public async Task SendSessionMessageToNonSessionfulEntityShouldNotThrow()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);
                // this is apparently supported. The session is ignored by the service but can be used
                // as additional app data. Not recommended.
                await sender.SendMessageAsync(GetMessage("sessionId"));
                var receiver = client.CreateReceiver(scope.QueueName);
                var msg = await receiver.ReceiveMessageAsync();
                Assert.AreEqual("sessionId", msg.SessionId);
            }
        }

        [Test]
        public async Task SendNonSessionMessageToSessionfulEntityShouldThrow()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var sender = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString).CreateSender(scope.QueueName);
                Assert.That(
                    async () => await sender.SendMessageAsync(GetMessage()),
                    Throws.InstanceOf<InvalidOperationException>());
            }
        }

        [Test]
        public async Task CanSendReceivedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(
                    TestEnvironment.FullyQualifiedNamespace,
                    TestEnvironment.Credential);
                await using var sender = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString).CreateSender(scope.QueueName);
                var messageCt = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCt);
                await sender.SendMessagesAsync(messages);

                var receiver = client.CreateReceiver(scope.QueueName, new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete
                });

                var remainingMessages = messageCt;
                IList<ServiceBusReceivedMessage> receivedMessages = new List<ServiceBusReceivedMessage>();
                while (remainingMessages > 0)
                {
                    foreach (var msg in await receiver.ReceiveMessagesAsync(messageCt))
                    {
                        remainingMessages--;
                        receivedMessages.Add(msg);
                    }
                }
                foreach (ServiceBusReceivedMessage msg in receivedMessages)
                {
                    await sender.SendMessageAsync(new ServiceBusMessage(msg));
                }

                var messageEnum = receivedMessages.GetEnumerator();

                remainingMessages = messageCt;
                while (remainingMessages > 0)
                {
                    foreach (var msg in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, msg.MessageId);
                    }
                }
                Assert.AreEqual(0, remainingMessages);
            }
        }

        [Test]
        public async Task CreateBatchThrowsIftheEntityDoesNotExist()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEntity("FakeEntity");
                await using var client = new ServiceBusClient(connectionString);

                ServiceBusSender sender = client.CreateSender("FakeEntity");
                Assert.That(async () => await sender.CreateMessageBatchAsync(), Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));
            }
        }
    }
}
