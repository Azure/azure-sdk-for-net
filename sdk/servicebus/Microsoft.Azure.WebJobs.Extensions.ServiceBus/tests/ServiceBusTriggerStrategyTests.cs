// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Azure.Messaging.ServiceBus;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class ServiceBusTriggerStrategyTests
    {
        private const int BindingContractCount = 27;

        [Test]
        public void GetStaticBindingContract_ReturnsExpectedValue()
        {
            var strategy = new ServiceBusTriggerBindingStrategy();
            var bindingDataContract = strategy.GetBindingContract();

            CheckBindingContract(bindingDataContract);
        }

        [Test]
        public void GetBindingContract_SingleDispatch_ReturnsExpectedValue()
        {
            var strategy = new ServiceBusTriggerBindingStrategy();
            var bindingDataContract = strategy.GetBindingContract(true);

            CheckBindingContract(bindingDataContract);
        }

        [Test]
        public void GetBindingContract_MultipleDispatch_ReturnsExpectedValue()
        {
            var strategy = new ServiceBusTriggerBindingStrategy();
            var bindingDataContract = strategy.GetBindingContract(false);

            Assert.That(bindingDataContract, Has.Count.EqualTo(BindingContractCount));
            Assert.Multiple(() =>
            {
                Assert.That(bindingDataContract["DeliveryCountArray"], Is.EqualTo(typeof(int[])));
                Assert.That(bindingDataContract["DeadLetterSourceArray"], Is.EqualTo(typeof(string[])));
                Assert.That(bindingDataContract["LockTokenArray"], Is.EqualTo(typeof(string[])));
                Assert.That(bindingDataContract["ExpiresAtUtcArray"], Is.EqualTo(typeof(DateTime[])));
                Assert.That(bindingDataContract["EnqueuedTimeUtcArray"], Is.EqualTo(typeof(DateTime[])));
                Assert.That(bindingDataContract["MessageIdArray"], Is.EqualTo(typeof(string[])));
                Assert.That(bindingDataContract["ContentTypeArray"], Is.EqualTo(typeof(string[])));
                Assert.That(bindingDataContract["ReplyToArray"], Is.EqualTo(typeof(string[])));
                Assert.That(bindingDataContract["SequenceNumberArray"], Is.EqualTo(typeof(long[])));
                Assert.That(bindingDataContract["ToArray"], Is.EqualTo(typeof(string[])));
                Assert.That(bindingDataContract["LabelArray"], Is.EqualTo(typeof(string[])));
                Assert.That(bindingDataContract["CorrelationIdArray"], Is.EqualTo(typeof(string[])));
                Assert.That(bindingDataContract["ReplyToSessionIdArray"], Is.EqualTo(typeof(string[])));
                Assert.That(bindingDataContract["SessionIdArray"], Is.EqualTo(typeof(string[])));
                Assert.That(bindingDataContract["ApplicationPropertiesArray"], Is.EqualTo(typeof(IDictionary<string, object>[])));
                Assert.That(bindingDataContract["MessageReceiver"], Is.EqualTo(typeof(ServiceBusMessageActions)));
                Assert.That(bindingDataContract["MessageSession"], Is.EqualTo(typeof(ServiceBusSessionMessageActions)));
                Assert.That(bindingDataContract["MessageActions"], Is.EqualTo(typeof(ServiceBusMessageActions)));
                Assert.That(bindingDataContract["SessionActions"], Is.EqualTo(typeof(ServiceBusSessionMessageActions)));
            });
        }

        [Test]
        public void GetBindingData_SingleDispatch_ReturnsExpectedValue()
        {
            IDictionary<string, object> userProps = new Dictionary<string, object>();
            userProps.Add(new KeyValuePair<string, object>("prop1", "value1"));
            userProps.Add(new KeyValuePair<string, object>("prop2", "value2"));
            var message = CreateMessageWithSystemProperties(applicationProperties: userProps);

            var input = ServiceBusTriggerInput.CreateSingle(message, null, null, null);
            var strategy = new ServiceBusTriggerBindingStrategy();
            var bindingData = strategy.GetBindingData(input);

            Assert.That(bindingData, Has.Count.EqualTo(BindingContractCount));

            Assert.Multiple(() =>
            {
                Assert.That(bindingData["MessageReceiver"], Is.SameAs(input.MessageActions));
                Assert.That(bindingData["MessageSession"], Is.SameAs(input.MessageActions));
                Assert.That(bindingData["MessageActions"], Is.SameAs(input.MessageActions));
                Assert.That(bindingData["SessionActions"], Is.SameAs(input.MessageActions));
                Assert.That(bindingData["ReceiveActions"], Is.SameAs(input.ReceiveActions));
                Assert.That(bindingData["LockToken"], Is.EqualTo(message.LockToken));
                Assert.That(bindingData["SequenceNumber"], Is.EqualTo(message.SequenceNumber));
                Assert.That(bindingData["DeliveryCount"], Is.EqualTo(message.DeliveryCount));
                Assert.That(bindingData["DeadLetterSource"], Is.SameAs(message.DeadLetterSource));
                Assert.That(bindingData["ExpiresAtUtc"], Is.EqualTo(message.ExpiresAt.DateTime));
                Assert.That(bindingData["EnqueuedTimeUtc"], Is.EqualTo(message.EnqueuedTime.DateTime));
                Assert.That(bindingData["MessageId"], Is.SameAs(message.MessageId));
                Assert.That(bindingData["ContentType"], Is.SameAs(message.ContentType));
                Assert.That(bindingData["ReplyTo"], Is.SameAs(message.ReplyTo));
                Assert.That(bindingData["To"], Is.SameAs(message.To));
                Assert.That(bindingData["Label"], Is.SameAs(message.Subject));
                Assert.That(bindingData["CorrelationId"], Is.SameAs(message.CorrelationId));
                Assert.That(bindingData["SessionId"], Is.SameAs(message.SessionId));
                Assert.That(bindingData["ReplyToSessionId"], Is.SameAs(message.ReplyToSessionId));
                Assert.That(bindingData["PartitionKey"], Is.SameAs(message.PartitionKey));
                Assert.That(bindingData["TransactionPartitionKey"], Is.SameAs(message.TransactionPartitionKey));
            });

            IDictionary<string, object> bindingDataUserProps = bindingData["ApplicationProperties"] as IDictionary<string, object>;
            Assert.That(bindingDataUserProps, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(bindingDataUserProps["prop1"], Is.EqualTo("value1"));
                Assert.That(bindingDataUserProps["prop2"], Is.EqualTo("value2"));
            });
        }

        [Test]
        public void GetBindingData_MultipleDispatch_ReturnsExpectedValue()
        {
            var messages = new ServiceBusReceivedMessage[3]
            {
                CreateMessageWithSystemProperties("Event 1"),
                CreateMessageWithSystemProperties("Event 2"),
                CreateMessageWithSystemProperties("Event 3"),
            };

            var input = ServiceBusTriggerInput.CreateBatch(messages, null, null, null);
            var strategy = new ServiceBusTriggerBindingStrategy();
            var bindingData = strategy.GetBindingData(input);

            Assert.That(bindingData, Has.Count.EqualTo(BindingContractCount));
            Assert.Multiple(() =>
            {
                Assert.That(bindingData["MessageReceiver"], Is.SameAs(input.MessageActions));
                Assert.That(bindingData["MessageSession"], Is.SameAs(input.MessageActions));
                Assert.That(bindingData["MessageActions"], Is.SameAs(input.MessageActions));
                Assert.That(bindingData["SessionActions"], Is.SameAs(input.MessageActions));
                Assert.That(bindingData["ReceiveActions"], Is.SameAs(input.ReceiveActions));

                // verify an array was created for each binding data type
                Assert.That(((int[])bindingData["DeliveryCountArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["DeadLetterSourceArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["LockTokenArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((DateTime[])bindingData["ExpiresAtUtcArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((DateTime[])bindingData["EnqueuedTimeUtcArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["MessageIdArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["ContentTypeArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["ReplyToArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((long[])bindingData["SequenceNumberArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["ToArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["SubjectArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["CorrelationIdArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["SessionIdArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["ReplyToSessionIdArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["PartitionKeyArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((string[])bindingData["TransactionPartitionKeyArray"]).Length, Is.EqualTo(messages.Length));
                Assert.That(((IDictionary<string, object>[])bindingData["ApplicationPropertiesArray"]).Length, Is.EqualTo(messages.Length));
            });
        }

        [Test]
        public void BindSingle_Returns_Exptected_Message()
        {
            string data = "123";

            var strategy = new ServiceBusTriggerBindingStrategy();
            ServiceBusTriggerInput triggerInput = strategy.ConvertFromString(data);

            var contract = strategy.GetBindingData(triggerInput);

            ServiceBusReceivedMessage single = strategy.BindSingle(triggerInput, null);
            string body = single.Body.ToString();

            Assert.Multiple(() =>
            {
                Assert.That(body, Is.EqualTo(data));
                Assert.That(contract["MessageReceiver"], Is.Null);
                Assert.That(contract["MessageSession"], Is.Null);
            });
        }

        private static void CheckBindingContract(Dictionary<string, Type> bindingDataContract)
        {
            Assert.That(bindingDataContract, Has.Count.EqualTo(BindingContractCount));
            Assert.Multiple(() =>
            {
                Assert.That(bindingDataContract["DeliveryCount"], Is.EqualTo(typeof(int)));
                Assert.That(bindingDataContract["DeadLetterSource"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["LockToken"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["ExpiresAtUtc"], Is.EqualTo(typeof(DateTime)));
                Assert.That(bindingDataContract["EnqueuedTimeUtc"], Is.EqualTo(typeof(DateTime)));
                Assert.That(bindingDataContract["MessageId"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["ContentType"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["ReplyTo"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["SequenceNumber"], Is.EqualTo(typeof(long)));
                Assert.That(bindingDataContract["To"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["Label"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["CorrelationId"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["SessionId"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["ReplyToSessionId"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["PartitionKey"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["TransactionPartitionKey"], Is.EqualTo(typeof(string)));
                Assert.That(bindingDataContract["ApplicationProperties"], Is.EqualTo(typeof(IDictionary<string, object>)));
                Assert.That(bindingDataContract["MessageReceiver"], Is.EqualTo(typeof(ServiceBusMessageActions)));
                Assert.That(bindingDataContract["MessageSession"], Is.EqualTo(typeof(ServiceBusSessionMessageActions)));
                Assert.That(bindingDataContract["MessageActions"], Is.EqualTo(typeof(ServiceBusMessageActions)));
                Assert.That(bindingDataContract["SessionActions"], Is.EqualTo(typeof(ServiceBusSessionMessageActions)));
                Assert.That(bindingDataContract["ReceiveActions"], Is.EqualTo(typeof(ServiceBusReceiveActions)));
                Assert.That(bindingDataContract["Client"], Is.EqualTo(typeof(ServiceBusClient)));
            });
        }

        private static ServiceBusReceivedMessage CreateMessageWithSystemProperties(string body = default, IDictionary<string, object> applicationProperties = default)
        {
            ServiceBusReceivedMessage receivedMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(
                body: body == null ? null : new BinaryData(body),
                deliveryCount: 1,
                lockedUntil: DateTime.MinValue,
                sequenceNumber: 1,
                enqueuedTime: DateTime.MinValue,
                lockTokenGuid: Guid.NewGuid(),
                deadLetterSource: "test",
                properties: applicationProperties);
            return receivedMessage;
        }
    }
}
