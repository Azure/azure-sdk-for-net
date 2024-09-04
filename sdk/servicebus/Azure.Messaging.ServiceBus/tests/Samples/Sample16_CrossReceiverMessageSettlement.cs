// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Amqp;
using Azure.Identity;
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
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
#endif

                #region Snippet:ServiceBusWriteReceivedMessage

                ServiceBusClient client1 = new(fullyQualifiedNamespace, new DefaultAzureCredential());
                ServiceBusSender sender = client1.CreateSender(queueName);

                ServiceBusMessage message = new("some message");
                await sender.SendMessageAsync(message);

                ServiceBusReceiver receiver1 = client1.CreateReceiver(queueName);
                ServiceBusReceivedMessage receivedMessage = await receiver1.ReceiveMessageAsync();
                ReadOnlyMemory<byte> amqpMessageBytes = receivedMessage.GetRawAmqpMessage().ToBytes().ToMemory();
                ReadOnlyMemory<byte> lockTokenBytes = Guid.Parse(receivedMessage.LockToken).ToByteArray();
                #endregion

                #region Snippet:ServiceBusReadReceivedMessage
                AmqpAnnotatedMessage amqpMessage = AmqpAnnotatedMessage.FromBytes(new BinaryData(amqpMessageBytes));
                ServiceBusReceivedMessage rehydratedMessage = ServiceBusReceivedMessage.FromAmqpMessage(amqpMessage, new BinaryData(lockTokenBytes));

                var client2 = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
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
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
#endif

                #region Snippet:ServiceBusWriteReceivedMessageLockToken

                ServiceBusClient client1 = new(fullyQualifiedNamespace, new DefaultAzureCredential());
                ServiceBusSender sender = client1.CreateSender(queueName);

                ServiceBusMessage message = new("some message");
                await sender.SendMessageAsync(message);

                ServiceBusReceiver receiver1 = client1.CreateReceiver(queueName);
                ServiceBusReceivedMessage receivedMessage = await receiver1.ReceiveMessageAsync();
                ReadOnlyMemory<byte> lockTokenBytes = Guid.Parse(receivedMessage.LockToken).ToByteArray();
                #endregion

                #region Snippet:ServiceBusReadReceivedMessageLockToken

                ServiceBusReceivedMessage rehydratedMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(lockTokenGuid: new Guid(lockTokenBytes.ToArray()));

                ServiceBusClient client2 = new(fullyQualifiedNamespace, new DefaultAzureCredential());
                ServiceBusReceiver receiver2 = client2.CreateReceiver(queueName);
                await receiver2.CompleteMessageAsync(rehydratedMessage);
                #endregion
            }
        }
    }
}
