// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample02_MessageSettlement : ServiceBusLiveTestBase
    {
        [Test]
        public async Task CompleteMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusCompleteMessage
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";

                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;

                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif
                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new("Hello world!");

                // send the message
                await sender.SendMessageAsync(message);

                // create a receiver that we can use to receive and settle the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                // the received message is a different type as it contains some service set properties
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                // complete the message, thereby deleting it from the service
                await receiver.CompleteMessageAsync(receivedMessage);
                #endregion
                Assert.IsNull(await CreateNoRetryClient().CreateReceiver(queueName).ReceiveMessageAsync());
            }
        }

        [Test]
        public async Task AbandonMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string fullQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullQualifiedNamespace, TestEnvironment.Credential);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new("Hello world!");

                // send the message
                await sender.SendMessageAsync(message);

                // create a receiver that we can use to receive and settle the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                #region Snippet:ServiceBusAbandonMessage
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                // abandon the message, thereby releasing the lock and allowing it to be received again by this or other receivers
                await receiver.AbandonMessageAsync(receivedMessage);
                #endregion
                Assert.IsNotNull(CreateNoRetryClient().CreateReceiver(queueName).ReceiveMessageAsync());
            }
        }

        [Test]
        public async Task DeferMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(fullyQualifiedNamespace, TestEnvironment.Credential);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new("Hello world!");

                // send the message
                await sender.SendMessageAsync(message);

                // create a receiver that we can use to receive and settle the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                #region Snippet:ServiceBusDeferMessage
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                // defer the message, thereby preventing the message from being received again without using
                // the received deferred message API.
                await receiver.DeferMessageAsync(receivedMessage);

                // receive the deferred message by specifying the service set sequence number of the original
                // received message
                ServiceBusReceivedMessage deferredMessage = await receiver.ReceiveDeferredMessageAsync(receivedMessage.SequenceNumber);
                #endregion
                Assert.IsNotNull(deferredMessage);
            }
        }

        [Test]
        public async Task DeadLetterMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new("Hello world!");

                // send the message
                await sender.SendMessageAsync(message);

                // create a receiver that we can use to receive and settle the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                #region Snippet:ServiceBusDeadLetterMessage
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                // Dead-letter the message, thereby preventing the message from being received again without receiving from the dead letter queue.
                // We can optionally pass a dead letter reason and dead letter description to further describe the reason for dead-lettering the message.
                await receiver.DeadLetterMessageAsync(receivedMessage, "sample reason", "sample description");

                // receive the dead lettered message with receiver scoped to the dead letter queue.
                ServiceBusReceiver dlqReceiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions
                {
                    SubQueue = SubQueue.DeadLetter
                });
                ServiceBusReceivedMessage dlqMessage = await dlqReceiver.ReceiveMessageAsync();

                // The reason and the description that we specified when dead-lettering the message will be available in the received dead letter message.
                string reason = dlqMessage.DeadLetterReason;
                string description = dlqMessage.DeadLetterErrorDescription;
                #endregion

                Assert.IsNotNull(dlqMessage);
                Assert.AreEqual("sample reason", reason);
                Assert.AreEqual("sample description", description);
            }
        }

        [Test]
        public async Task RenewMessageLockAndComplete()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new("Hello world!");

                // send the message
                await sender.SendMessageAsync(message);

                // create a receiver that we can use to receive and settle the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                #region Snippet:ServiceBusRenewMessageLockAndComplete
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                // If we know that we are going to be processing the message for a long time, we can extend the lock for the message
                // by the configured LockDuration (by default, 30 seconds).
                await receiver.RenewMessageLockAsync(receivedMessage);

                // simulate some processing of the message
                await Task.Delay(TimeSpan.FromSeconds(10));

                // complete the message, thereby deleting it from the service
                await receiver.CompleteMessageAsync(receivedMessage);
                #endregion
                Assert.IsNull(await CreateNoRetryClient().CreateReceiver(queueName).ReceiveMessageAsync());
            }
        }
    }
}
