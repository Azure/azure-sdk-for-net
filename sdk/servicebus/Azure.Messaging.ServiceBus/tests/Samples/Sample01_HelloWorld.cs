// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample01_HelloWorld : ServiceBusLiveTestBase
    {
        [Test]
        public async Task SendAndReceiveMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
                #region Snippet:ServiceBusSendAndReceive
                //@@ string connectionString = "<connection_string>";
                //@@ string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(connectionString);

                // get the sender
                ServiceBusSender sender = client.GetSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Encoding.Default.GetBytes("Hello world!"));

                // send the message
                await sender.SendAsync(message);

                // get a receiver that we can use to receive the message
                ServiceBusReceiver receiver = client.GetReceiver(queueName);

                // the received message is a different type as it contains some service set properties
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveAsync();

                // get the message body as a string
                string body = Encoding.Default.GetString(receivedMessage.Body.ToArray());
                Console.WriteLine(body);
                #endregion
                Assert.AreEqual(Encoding.Default.GetBytes("Hello world!"), receivedMessage.Body.ToArray());
            }
        }

        [Test]
        public async Task SendAndPeekMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
                await using var client = new ServiceBusClient(connectionString);

                // get the sender
                ServiceBusSender sender = client.GetSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Encoding.Default.GetBytes("Hello world!"));

                // send the message
                await sender.SendAsync(message);

                // get a receiver that we can use to receive the message
                ServiceBusReceiver receiver = client.GetReceiver(queueName);

                // the received message is a different type as it contains some service set properties
                ServiceBusReceivedMessage peekedMessage = await receiver.PeekAsync();

                // get the message body as a string
                string body = Encoding.Default.GetString(peekedMessage.Body.ToArray());
                Assert.AreEqual(Encoding.Default.GetBytes("Hello world!"), peekedMessage.Body.ToArray());
            }
        }

        [Test]
        public async Task SendAndReceiveMessageBatch()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
                #region Snippet:ServiceBusSendAndReceiveBatch
                //@@ string connectionString = "<connection_string>";
                //@@ string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(connectionString);

                // get the sender
                ServiceBusSender sender = client.GetSender(queueName);

                // create a message batch that we can send
                ServiceBusMessageBatch messageBatch = await sender.CreateBatchAsync();
                messageBatch.TryAdd(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
                messageBatch.TryAdd(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));

                // send the message batch
                await sender.SendBatchAsync(messageBatch);

                // get a receiver that we can use to receive the messages
                ServiceBusReceiver receiver = client.GetReceiver(queueName);

                // the received message is a different type as it contains some service set properties
                IList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveBatchAsync(maxMessages: 2);

                foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
                {
                    // get the message body as a string
                    string body = Encoding.Default.GetString(receivedMessage.Body.ToArray());
                    Console.WriteLine(body);
                }
                #endregion
                var sentMessagesEnum = messageBatch.AsEnumerable<ServiceBusMessage>().GetEnumerator();
                foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
                {
                    sentMessagesEnum.MoveNext();
                    Assert.AreEqual(sentMessagesEnum.Current.Body.ToArray(), receivedMessage.Body.ToArray());
                }
            }
        }

        [Test]
        public async Task ScheduleMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(connectionString);

                // get the sender
                ServiceBusSender sender = client.GetSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Encoding.Default.GetBytes("Hello world!"));

                // schedule the message for tomorrow
                // this prevents the message from being enqueued until tomorrow, but it can still be peeked
                long seq = await sender.ScheduleMessageAsync(
                    message,
                    DateTimeOffset.Now.AddDays(1));

                // get a receiver that we can use to peek the message
                ServiceBusReceiver receiver = client.GetReceiver(queueName);
                Assert.IsNotNull(await receiver.PeekAsync());

                // cancel the scheduled messaged, thereby deleting from the service
                await sender.CancelScheduledMessageAsync(seq);
                Assert.IsNull(await receiver.PeekAsync());
            }
        }

        /// <summary>
        /// Authenticate with <see cref="DefaultAzureCredential"/>.
        /// </summary>
        public void Authenticate()
        {
            #region Snippet:ServiceBusAuth
            // Create a BlobServiceClient that will authenticate through Active Directory
            string fullyQualifiedNamespace = "yournamespace.servicebus.windows.net";
            ServiceBusClient client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
            #endregion
        }
    }
}
