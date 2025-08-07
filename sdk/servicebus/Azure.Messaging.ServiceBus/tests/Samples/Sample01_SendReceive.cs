// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample01_SendReceive : ServiceBusLiveTestBase
    {
        [Test]
        public async Task SendAndReceiveMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusSendAndReceive
                #region Snippet:ServiceBusSendSingleMessage
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

                // create a message that we can send. UTF-8 encoding is used when providing a string.
                ServiceBusMessage message = new("Hello world!");

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
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new("Hello world!");

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
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;

                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);
                #region Snippet:ServiceBusSendAndReceiveBatch
                IList<ServiceBusMessage> messages = new List<ServiceBusMessage>
                {
                    new ServiceBusMessage("First"),
                    new ServiceBusMessage("Second")
                };
                // send the messages
                await sender.SendMessagesAsync(messages);
                #endregion
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

                #region Snippet:ServiceBusSendAndReceiveSafeBatch
                // add the messages that we plan to send to a local queue
                Queue<ServiceBusMessage> messages = new();
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

                #region Snippet:ServiceBusReceiveBatch
                // create a receiver that we can use to receive the messages
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                // the received message is a different type as it contains some service set properties
                // a batch of messages (maximum of 2 in this case) are received
                IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages: 2);

                // go through each of the messages received
                foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
                {
                    // get the message body as a string
                    string body = receivedMessage.Body.ToString();
                }
                #endregion
            }
        }

        [Test]
        public async Task ScheduleMessage()
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

        [Test]
        public async Task SendAndReceiveMessageUsingTopic()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusSendAndReceiveTopic
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string topicName = "<topic_name>";
                string subscriptionName = "<subscription_name>";

                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string topicName = scope.TopicName;
                string subscriptionName = scope.SubscriptionNames[0];

                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif
                // create the sender that we will use to send to our topic
                ServiceBusSender sender = client.CreateSender(topicName);

                // create a message that we can send. UTF-8 encoding is used when providing a string.
                ServiceBusMessage message = new("Hello world!");

                // send the message
                await sender.SendMessageAsync(message);

                // create a receiver for our subscription that we can use to receive the message
                ServiceBusReceiver receiver = client.CreateReceiver(topicName, subscriptionName);

                // the received message is a different type as it contains some service set properties
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                // get the message body as a string
                string body = receivedMessage.Body.ToString();
                Console.WriteLine(body);
                #endregion
                Assert.AreEqual("Hello world!", receivedMessage.Body.ToString());
            }
        }

        /// <summary>
        /// Connect to the service using a custom endpoint address.
        /// </summary>
        public void ConnectUsingCustomEndpoint()
        {
            #region Snippet:ServiceBusCustomEndpoint
            // Connect to the service using a custom endpoint
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            string customEndpoint = "<custom_endpoint>";

            var options = new ServiceBusClientOptions
            {
                CustomEndpointAddress = new Uri(customEndpoint)
            };

#if SNIPPET
            ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential(), options);
#else
            ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential, options);
#endif
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

        /// <summary>
        /// Set the TimeToLive on a message.
        /// </summary>
        public void SetMessageTimeToLive()
        {
            #region Snippet:ServiceBusMessageTimeToLive
            var message = new ServiceBusMessage("Hello world!") { TimeToLive = TimeSpan.FromMinutes(5) };
            #endregion
        }
    }
}
