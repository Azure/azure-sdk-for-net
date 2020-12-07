// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
                #region Snippet:ServiceBusSendSingleMessage
                //@@ string connectionString = "<connection_string>";
                //@@ string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(connectionString);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send. UTF-8 encoding is used when providing a string.
                ServiceBusMessage message = new ServiceBusMessage("Hello world!");

                // send the message
                await sender.SendMessageAsync(message);

                #endregion
                #region Snippet:ServiceBusReceiveSingleMessage
                // create a receiver that we can use to receive the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                // the received message is a different type as it contains some service set properties
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                // get the message body as a string
                string body = receivedMessage.Body.ToString();
                Console.WriteLine(body);
                #endregion
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
                ServiceBusMessage message = new ServiceBusMessage("Hello world!");

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
                messages.Add(new ServiceBusMessage("First"));
                messages.Add(new ServiceBusMessage("Second"));
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

                #region Snippet:ServiceBusSendAndReceiveSafeBatch
                // add the messages that we plan to send to a local queue
                Queue<ServiceBusMessage> messages = new Queue<ServiceBusMessage>();
                messages.Enqueue(new ServiceBusMessage("First message"));
                messages.Enqueue(new ServiceBusMessage("Second message"));
                messages.Enqueue(new ServiceBusMessage("Third message"));

                // create a message batch that we can send
                // total number of messages to be sent to the Service Bus queue
                int messageCount = messages.Count;

                // while all messages are not sent to the Service Bus queue
                while (messages.Count > 0)
                {
                    // start a new batch
                    using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

                    // add the first message to the batch
                    if (messageBatch.TryAddMessage(messages.Peek()))
                    {
                        // dequeue the message from the .NET queue once the message is added to the batch
                        messages.Dequeue();
                    }
                    else
                    {
                        // if the first message can't fit, then it is too large for the batch
                        throw new Exception($"Message {messageCount - messages.Count} is too large and cannot be sent.");
                    }

                    // add as many messages as possible to the current batch
                    while (messages.Count > 0 && messageBatch.TryAddMessage(messages.Peek()))
                    {
                        // dequeue the message from the .NET queue as it has been added to the batch
                        messages.Dequeue();
                    }

                    // now, send the batch
                    await sender.SendMessagesAsync(messageBatch);

                    // if there are any remaining messages in the .NET queue, the while loop repeats
                }
                #endregion

                // create a receiver that we can use to receive the messages
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                // the received message is a different type as it contains some service set properties
                IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages: 2);

                foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
                {
                    // get the message body as a string
                    string body = receivedMessage.Body.ToString();
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
                ServiceBusMessage message = new ServiceBusMessage("Hello world!");

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
