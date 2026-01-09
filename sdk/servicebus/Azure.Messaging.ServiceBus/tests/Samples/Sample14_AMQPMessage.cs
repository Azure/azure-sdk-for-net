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
    public class Sample14_AMQPMessage : ServiceBusLiveTestBase
    {
        [Test]
        public async Task SendAndReceiveValueBody()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                DefaultAzureCredential credential = new();
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                var credential = TestEnvironment.Credential;
#endif

                #region Snippet:ServiceBusSendValueBody

                var client = new ServiceBusClient(fullyQualifiedNamespace, credential);
                ServiceBusSender sender = client.CreateSender(queueName);

                var message = new ServiceBusMessage();
                message.GetRawAmqpMessage().Body = AmqpMessageBody.FromValue(42);
                await sender.SendMessageAsync(message);

                #endregion

                #region Snippet:ServiceBusInspectMessageBody

                ServiceBusReceiver receiver = client.CreateReceiver(queueName);
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                AmqpAnnotatedMessage amqpMessage = receivedMessage.GetRawAmqpMessage();
                if (amqpMessage.Body.TryGetValue(out object value))
                {
                    // handle the value body
                }
                else if (amqpMessage.Body.TryGetSequence(out IEnumerable<IList<object>> sequence))
                {
                    // handle the sequence body
                }
                else if (amqpMessage.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> data))
                {
                    // handle the data body - note that unlike when accessing the Body property of the received message,
                    // we actually get back a list of byte arrays, not a single byte array. If you were to access the Body property,
                    // the data would be flattened into a single byte array.
                }

                #endregion

                Assert.That(value, Is.EqualTo(42));
            }
        }

        [Test]
        public async Task SetMiscellaneousProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                DefaultAzureCredential credential = new();
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                var credential = TestEnvironment.Credential;
#endif

                #region Snippet:ServiceBusSetMiscellaneousProperties
                var client = new ServiceBusClient(fullyQualifiedNamespace, credential);
                ServiceBusSender sender = client.CreateSender(queueName);

                var message = new ServiceBusMessage("message with AMQP properties set");
                AmqpAnnotatedMessage amqpMessage = message.GetRawAmqpMessage();

                // set some properties of the AMQP header
                amqpMessage.Header.Durable = true;
                amqpMessage.Header.Priority = 1;

                // set some custom properties in the footer
                amqpMessage.Footer["custom-footer-property"] = "custom-footer-value";

                // set some custom properties in the message annotations
                amqpMessage.MessageAnnotations["custom-message-annotation"] = "custom-message-annotation-value";

                // set some custom properties in the delivery annotations
                amqpMessage.DeliveryAnnotations["custom-delivery-annotation"] = "custom-delivery-annotation-value";
                await sender.SendMessageAsync(message);
                #endregion

                #region Snippet:ServiceBusGetMiscellaneousProperties
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                AmqpAnnotatedMessage receivedAmqpMessage = receivedMessage.GetRawAmqpMessage();
                AmqpMessageHeader header = receivedAmqpMessage.Header;

                bool? durable = header.Durable;
                byte? priority = header.Priority;
                string customFooterValue = (string)receivedAmqpMessage.Footer["custom-footer-property"];
                string customMessageAnnotation = (string)receivedAmqpMessage.MessageAnnotations["custom-message-annotation"];
                string customDeliveryAnnotation = (string)receivedAmqpMessage.DeliveryAnnotations["custom-delivery-annotation"];
                Assert.Multiple(() =>
                {
                    #endregion

                    Assert.That(durable, Is.True);
                    Assert.That(priority, Is.EqualTo(1));
                    Assert.That(customFooterValue, Is.EqualTo("custom-footer-value"));
                    Assert.That(customMessageAnnotation, Is.EqualTo("custom-message-annotation-value"));
                    Assert.That(customDeliveryAnnotation, Is.EqualTo("custom-delivery-annotation-value"));
                });
            }
        }
    }
}
