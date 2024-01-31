// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Amqp;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample16_CrossReceiverMessageSettlement : ServiceBusLiveTestBase
    {
        [Test]
        public async Task RehydrateReceivedMessageUsingRawBytes()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
#if SNIPPET
                string connectionString = "<connection_string>";
                string queueName = "<queue_name>";
#else
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
#endif

                #region Snippet:ServiceBusWriteReceivedMessage

                var client1 = new ServiceBusClient(connectionString);
                ServiceBusSender sender = client1.CreateSender(queueName);

                var message = new ServiceBusMessage("some message");
                await sender.SendMessageAsync(message);

                ServiceBusReceiver receiver1 = client1.CreateReceiver(queueName);
                ServiceBusReceivedMessage receivedMessage = await receiver1.ReceiveMessageAsync();
                ReadOnlyMemory<byte> amqpMessageBytes = receivedMessage.GetRawAmqpMessage().ToBytes().ToMemory();
                ReadOnlyMemory<byte> lockTokenBytes = Guid.Parse(receivedMessage.LockToken).ToByteArray();
                #endregion

                #region Snippet:ServiceBusReadReceivedMessage
                AmqpAnnotatedMessage amqpMessage = AmqpAnnotatedMessage.FromBytes(new BinaryData(amqpMessageBytes));
                ServiceBusReceivedMessage rehydratedMessage = ServiceBusReceivedMessage.FromAmqpMessage(amqpMessage, new BinaryData(lockTokenBytes));

                var client2 = new ServiceBusClient(connectionString);
                ServiceBusReceiver receiver2 = client2.CreateReceiver(queueName);
                await receiver2.CompleteMessageAsync(rehydratedMessage);
                #endregion

                Assert.AreEqual("some message", rehydratedMessage.Body.ToString());
            }
        }

        [Test]
        public async Task RehydrateReceivedMessageUsingLockToken()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
#if SNIPPET
                string connectionString = "<connection_string>";
                string queueName = "<queue_name>";
#else
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
#endif

                #region Snippet:ServiceBusWriteReceivedMessageLockToken

                var client1 = new ServiceBusClient(connectionString);
                ServiceBusSender sender = client1.CreateSender(queueName);

                var message = new ServiceBusMessage("some message");
                await sender.SendMessageAsync(message);

                ServiceBusReceiver receiver1 = client1.CreateReceiver(queueName);
                ServiceBusReceivedMessage receivedMessage = await receiver1.ReceiveMessageAsync();
                ReadOnlyMemory<byte> lockTokenBytes = Guid.Parse(receivedMessage.LockToken).ToByteArray();
                #endregion

                #region Snippet:ServiceBusReadReceivedMessageLockToken

                ServiceBusReceivedMessage rehydratedMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(lockTokenGuid: new Guid(lockTokenBytes.ToArray()));

                var client2 = new ServiceBusClient(connectionString);
                ServiceBusReceiver receiver2 = client2.CreateReceiver(queueName);
                await receiver2.CompleteMessageAsync(rehydratedMessage);
                #endregion
            }
        }
    }
}
