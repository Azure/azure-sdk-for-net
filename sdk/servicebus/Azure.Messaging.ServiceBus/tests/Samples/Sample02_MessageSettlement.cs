// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
                #region Snippet:ServiceBusCompleteMessage
                //@@ string connectionString = "<connection_string>";
                //@@ string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(connectionString);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Encoding.Default.GetBytes("Hello world!"));

                // send the message
                await sender.SendAsync(message);

                // create a receiver that we can use to receive and settle the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                // the received message is a different type as it contains some service set properties
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveAsync();

                // complete the message, thereby deleting it from the service
                await receiver.CompleteAsync(receivedMessage);
                #endregion
                Assert.IsNull(await GetNoRetryClient().CreateReceiver(queueName).ReceiveAsync());
            }
        }

        [Test]
        public async Task AbandonMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(connectionString);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Encoding.Default.GetBytes("Hello world!"));

                // send the message
                await sender.SendAsync(message);

                // create a receiver that we can use to receive and settle the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                #region Snippet:ServiceBusAbandonMessage
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveAsync();

                // abandon the message, thereby releasing the lock and allowing it to be received again by this or other receivers
                await receiver.AbandonAsync(receivedMessage);
                #endregion
                Assert.IsNotNull(GetNoRetryClient().CreateReceiver(queueName).ReceiveAsync());
            }
        }

        [Test]
        public async Task DeferMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(connectionString);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Encoding.Default.GetBytes("Hello world!"));

                // send the message
                await sender.SendAsync(message);

                // create a receiver that we can use to receive and settle the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                #region Snippet:ServiceBusDeferMessage
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveAsync();

                // defer the message, thereby preventing the message from being received again without using
                // the received deferred message API.
                await receiver.DeferAsync(receivedMessage);

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
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(connectionString);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Encoding.Default.GetBytes("Hello world!"));

                // send the message
                await sender.SendAsync(message);

                // create a receiver that we can use to receive and settle the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                #region Snippet:ServiceBusDeadLetterMessage
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveAsync();

                // deadletter the message, thereby preventing the message from being received again without receiving from the dead letter queue.
                await receiver.DeadLetterAsync(receivedMessage);

                // receive the dead lettered message with receiver scoped to the dead letter queue.
                ServiceBusReceiver dlqReceiver = client.CreateDeadLetterReceiver(queueName);
                ServiceBusReceivedMessage dlqMessage = await dlqReceiver.ReceiveAsync();
                #endregion
                Assert.IsNotNull(dlqMessage);
            }
        }
    }
}
