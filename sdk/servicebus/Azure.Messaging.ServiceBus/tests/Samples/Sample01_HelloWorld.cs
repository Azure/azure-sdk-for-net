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

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Encoding.UTF8.GetBytes("Hello world!"));

                // send the message
                await sender.SendMessageAsync(message);

                // create a receiver that we can use to receive the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                // the received message is a different type as it contains some service set properties
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                // get the message body as a string
                string body = receivedMessage.Body.ToString();
                Console.WriteLine(body);
                #endregion
                Assert.AreEqual("Hello world!", receivedMessage.Body.ToString());
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

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Encoding.UTF8.GetBytes("Hello world!"));

                // send the message
                await sender.SendMessageAsync(message);

                // create a receiver that we can use to receive the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                #region Snippet:ServiceBusPeek
                ServiceBusReceivedMessage peekedMessage = await receiver.PeekMessageAsync();
                #endregion

                // get the message body as a string
                string body = peekedMessage.Body.ToString();
                Assert.AreEqual("Hello world!", peekedMessage.Body.ToString());
            }
        }

        [Test]
        public async Task SendAndReceiveMessageBatch()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;

                #region Snippet:ServiceBusInitializeSend
                //@@ string connectionString = "<connection_string>";
                //@@ string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(connectionString);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);
                #region Snippet:ServiceBusSendAndReceiveBatch
                IList<ServiceBusMessage> messages = new List<ServiceBusMessage>();
                messages.Add(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
                messages.Add(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));
                // send the messages
                await sender.SendMessagesAsync(messages);
                #endregion
                #endregion
                #region Snippet:ServiceBusReceiveBatch
                // create a receiver that we can use to receive the messages
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                // the received message is a different type as it contains some service set properties
                IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages: 2);

                foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
                {
                    // get the message body as a string
                    string body = receivedMessage.Body.ToString();
                    Console.WriteLine(body);
                }
                #endregion

                var sentMessagesEnum = messages.GetEnumerator();
                foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
                {
                    sentMessagesEnum.MoveNext();
                    Assert.AreEqual(sentMessagesEnum.Current.Body.ToString(), receivedMessage.Body.ToString());
                }
            }
        }

        [Test]
        public async Task SendAndReceiveMessageSafeBatch()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;

                //@@ string connectionString = "<connection_string>";
                //@@ string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(connectionString);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message batch that we can send
                #region Snippet:ServiceBusSendAndReceiveSafeBatch
                ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
                messageBatch.TryAddMessage(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
                messageBatch.TryAddMessage(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));

                // send the message batch
                await sender.SendMessagesAsync(messageBatch);
                #endregion

                // create a receiver that we can use to receive the messages
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                // the received message is a different type as it contains some service set properties
                IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages: 2);

                foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
                {
                    // get the message body as a string using an implicit cast
                    string body = receivedMessage.Body.ToString();
                }
                var sentMessagesEnum = messageBatch.AsEnumerable<ServiceBusMessage>().GetEnumerator();
                foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
                {
                    sentMessagesEnum.MoveNext();
                    Assert.AreEqual(sentMessagesEnum.Current.Body.ToString(), receivedMessage.Body.ToString());
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

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Encoding.UTF8.GetBytes("Hello world!"));

                #region Snippet:ServiceBusSchedule
                long seq = await sender.ScheduleMessageAsync(
                    message,
                    DateTimeOffset.Now.AddDays(1));
                #endregion

                // create a receiver that we can use to peek the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);
                Assert.IsNotNull(await receiver.PeekMessageAsync());

                // cancel the scheduled messaged, thereby deleting from the service
                #region Snippet:ServiceBusCancelScheduled
                await sender.CancelScheduledMessageAsync(seq);
                #endregion
                Assert.IsNull(await receiver.PeekMessageAsync());
            }
        }

        /// <summary>
        /// Authenticate with <see cref="DefaultAzureCredential"/>.
        /// </summary>
        public void AuthenticateWithAAD()
        {
            #region Snippet:ServiceBusAuthAAD
            // Create a ServiceBusClient that will authenticate through Active Directory
            string fullyQualifiedNamespace = "yournamespace.servicebus.windows.net";
            ServiceBusClient client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
            #endregion
        }

        /// <summary>
        /// Authenticate with <see cref="DefaultAzureCredential"/>.
        /// </summary>
        public void AuthenticateWithConnectionString()
        {
            #region Snippet:ServiceBusAuthConnString
            // Create a ServiceBusClient that will authenticate using a connection string
            string connectionString = "<connection_string>";
            ServiceBusClient client = new ServiceBusClient(connectionString);
            #endregion
        }

        /// <summary>
        /// Shows how to use <see cref="ServiceBusFailureReason"/> in <see cref="ServiceBusException"/>.
        /// </summary>
        public void ServiceBusExceptionFailureReasonUsage()
        {
            #region Snippet:ServiceBusExceptionFailureReasonUsage
            try
            {
                // Receive messages using the receiver client
            }
            catch (ServiceBusException ex) when
                (ex.Reason == ServiceBusFailureReason.ServiceTimeout)
            {
                // Take action based on a service timeout
            }
            #endregion
        }
    }
}
