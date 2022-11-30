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

            Assert.AreEqual(BindingContractCount, bindingDataContract.Count);
            Assert.AreEqual(typeof(int[]), bindingDataContract["DeliveryCountArray"]);
            Assert.AreEqual(typeof(string[]), bindingDataContract["DeadLetterSourceArray"]);
            Assert.AreEqual(typeof(string[]), bindingDataContract["LockTokenArray"]);
            Assert.AreEqual(typeof(DateTime[]), bindingDataContract["ExpiresAtUtcArray"]);
            Assert.AreEqual(typeof(DateTime[]), bindingDataContract["EnqueuedTimeUtcArray"]);
            Assert.AreEqual(typeof(string[]), bindingDataContract["MessageIdArray"]);
            Assert.AreEqual(typeof(string[]), bindingDataContract["ContentTypeArray"]);
            Assert.AreEqual(typeof(string[]), bindingDataContract["ReplyToArray"]);
            Assert.AreEqual(typeof(long[]), bindingDataContract["SequenceNumberArray"]);
            Assert.AreEqual(typeof(string[]), bindingDataContract["ToArray"]);
            Assert.AreEqual(typeof(string[]), bindingDataContract["LabelArray"]);
            Assert.AreEqual(typeof(string[]), bindingDataContract["CorrelationIdArray"]);
            Assert.AreEqual(typeof(string[]), bindingDataContract["ReplyToSessionIdArray"]);
            Assert.AreEqual(typeof(string[]), bindingDataContract["SessionIdArray"]);
            Assert.AreEqual(typeof(IDictionary<string, object>[]), bindingDataContract["ApplicationPropertiesArray"]);
            Assert.AreEqual(typeof(ServiceBusMessageActions), bindingDataContract["MessageReceiver"]);
            Assert.AreEqual(typeof(ServiceBusSessionMessageActions), bindingDataContract["MessageSession"]);
            Assert.AreEqual(typeof(ServiceBusMessageActions), bindingDataContract["MessageActions"]);
            Assert.AreEqual(typeof(ServiceBusSessionMessageActions), bindingDataContract["SessionActions"]);
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

            Assert.AreEqual(BindingContractCount, bindingData.Count);

            Assert.AreSame(input.MessageActions, bindingData["MessageReceiver"]);
            Assert.AreSame(input.MessageActions, bindingData["MessageSession"]);
            Assert.AreSame(input.MessageActions, bindingData["MessageActions"]);
            Assert.AreSame(input.MessageActions, bindingData["SessionActions"]);
            Assert.AreSame(input.ReceiveActions, bindingData["ReceiveActions"]);
            Assert.AreEqual(message.LockToken, bindingData["LockToken"]);
            Assert.AreEqual(message.SequenceNumber, bindingData["SequenceNumber"]);
            Assert.AreEqual(message.DeliveryCount, bindingData["DeliveryCount"]);
            Assert.AreSame(message.DeadLetterSource, bindingData["DeadLetterSource"]);
            Assert.AreEqual(message.ExpiresAt.DateTime, bindingData["ExpiresAtUtc"]);
            Assert.AreEqual(message.EnqueuedTime.DateTime, bindingData["EnqueuedTimeUtc"]);
            Assert.AreSame(message.MessageId, bindingData["MessageId"]);
            Assert.AreSame(message.ContentType, bindingData["ContentType"]);
            Assert.AreSame(message.ReplyTo, bindingData["ReplyTo"]);
            Assert.AreSame(message.To, bindingData["To"]);
            Assert.AreSame(message.Subject, bindingData["Label"]);
            Assert.AreSame(message.CorrelationId, bindingData["CorrelationId"]);
            Assert.AreSame(message.SessionId, bindingData["SessionId"]);
            Assert.AreSame(message.ReplyToSessionId, bindingData["ReplyToSessionId"]);
            Assert.AreSame(message.PartitionKey, bindingData["PartitionKey"]);
            Assert.AreSame(message.TransactionPartitionKey, bindingData["TransactionPartitionKey"]);

            IDictionary<string, object> bindingDataUserProps = bindingData["ApplicationProperties"] as IDictionary<string, object>;
            Assert.NotNull(bindingDataUserProps);
            Assert.AreEqual("value1", bindingDataUserProps["prop1"]);
            Assert.AreEqual("value2", bindingDataUserProps["prop2"]);
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

            Assert.AreEqual(BindingContractCount, bindingData.Count);
            Assert.AreSame(input.MessageActions, bindingData["MessageReceiver"]);
            Assert.AreSame(input.MessageActions, bindingData["MessageSession"]);
            Assert.AreSame(input.MessageActions, bindingData["MessageActions"]);
            Assert.AreSame(input.MessageActions, bindingData["SessionActions"]);
            Assert.AreSame(input.ReceiveActions, bindingData["ReceiveActions"]);

            // verify an array was created for each binding data type
            Assert.AreEqual(messages.Length, ((int[])bindingData["DeliveryCountArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["DeadLetterSourceArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["LockTokenArray"]).Length);
            Assert.AreEqual(messages.Length, ((DateTime[])bindingData["ExpiresAtUtcArray"]).Length);
            Assert.AreEqual(messages.Length, ((DateTime[])bindingData["EnqueuedTimeUtcArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["MessageIdArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["ContentTypeArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["ReplyToArray"]).Length);
            Assert.AreEqual(messages.Length, ((long[])bindingData["SequenceNumberArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["ToArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["SubjectArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["CorrelationIdArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["SessionIdArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["ReplyToSessionIdArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["PartitionKeyArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["TransactionPartitionKeyArray"]).Length);
            Assert.AreEqual(messages.Length, ((IDictionary<string, object>[])bindingData["ApplicationPropertiesArray"]).Length);
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

            Assert.AreEqual(data, body);
            Assert.Null(contract["MessageReceiver"]);
            Assert.Null(contract["MessageSession"]);
        }

        private static void CheckBindingContract(Dictionary<string, Type> bindingDataContract)
        {
            Assert.AreEqual(BindingContractCount, bindingDataContract.Count);
            Assert.AreEqual(typeof(int), bindingDataContract["DeliveryCount"]);
            Assert.AreEqual(typeof(string), bindingDataContract["DeadLetterSource"]);
            Assert.AreEqual(typeof(string), bindingDataContract["LockToken"]);
            Assert.AreEqual(typeof(DateTime), bindingDataContract["ExpiresAtUtc"]);
            Assert.AreEqual(typeof(DateTime), bindingDataContract["EnqueuedTimeUtc"]);
            Assert.AreEqual(typeof(string), bindingDataContract["MessageId"]);
            Assert.AreEqual(typeof(string), bindingDataContract["ContentType"]);
            Assert.AreEqual(typeof(string), bindingDataContract["ReplyTo"]);
            Assert.AreEqual(typeof(long), bindingDataContract["SequenceNumber"]);
            Assert.AreEqual(typeof(string), bindingDataContract["To"]);
            Assert.AreEqual(typeof(string), bindingDataContract["Label"]);
            Assert.AreEqual(typeof(string), bindingDataContract["CorrelationId"]);
            Assert.AreEqual(typeof(string), bindingDataContract["SessionId"]);
            Assert.AreEqual(typeof(string), bindingDataContract["ReplyToSessionId"]);
            Assert.AreEqual(typeof(string), bindingDataContract["PartitionKey"]);
            Assert.AreEqual(typeof(string), bindingDataContract["TransactionPartitionKey"]);
            Assert.AreEqual(typeof(IDictionary<string, object>), bindingDataContract["ApplicationProperties"]);
            Assert.AreEqual(typeof(ServiceBusMessageActions), bindingDataContract["MessageReceiver"]);
            Assert.AreEqual(typeof(ServiceBusSessionMessageActions), bindingDataContract["MessageSession"]);
            Assert.AreEqual(typeof(ServiceBusMessageActions), bindingDataContract["MessageActions"]);
            Assert.AreEqual(typeof(ServiceBusSessionMessageActions), bindingDataContract["SessionActions"]);
            Assert.AreEqual(typeof(ServiceBusReceiveActions), bindingDataContract["ReceiveActions"]);
            Assert.AreEqual(typeof(ServiceBusClient), bindingDataContract["Client"]);
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
