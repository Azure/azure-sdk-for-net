// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using NUnit.Framework;
using static Microsoft.Azure.ServiceBus.Message;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class ServiceBusTriggerStrategyTests
    {
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

            Assert.AreEqual(15, bindingDataContract.Count);
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
            Assert.AreEqual(typeof(IDictionary<string, object>[]), bindingDataContract["UserPropertiesArray"]);
            Assert.AreEqual(typeof(MessageReceiver), bindingDataContract["MessageReceiver"]);
            Assert.AreEqual(typeof(IMessageSession), bindingDataContract["MessageSession"]);
        }

        [Test]
        public void GetBindingData_SingleDispatch_ReturnsExpectedValue()
        {
            var message = new Message(new byte[] { });
            SystemPropertiesCollection sysProp = GetSystemProperties();
            TestHelpers.SetField(message, "SystemProperties", sysProp);
            IDictionary<string, object> userProps = new Dictionary<string, object>();
            userProps.Add(new KeyValuePair<string, object>("prop1", "value1"));
            userProps.Add(new KeyValuePair<string, object>("prop2", "value2"));
            TestHelpers.SetField(message, "UserProperties", userProps);

            var input = ServiceBusTriggerInput.CreateSingle(message);
            var strategy = new ServiceBusTriggerBindingStrategy();
            var bindingData = strategy.GetBindingData(input);

            Assert.AreEqual(15, bindingData.Count);  // SystemPropertiesCollection is sealed

            Assert.AreSame(input.MessageReceiver as MessageReceiver, bindingData["MessageReceiver"]);
            Assert.AreSame(input.MessageReceiver as IMessageSession, bindingData["MessageSession"]);
            Assert.AreEqual(message.SystemProperties.LockToken, bindingData["LockToken"]);
            Assert.AreEqual(message.SystemProperties.SequenceNumber, bindingData["SequenceNumber"]);
            Assert.AreEqual(message.SystemProperties.DeliveryCount, bindingData["DeliveryCount"]);
            Assert.AreSame(message.SystemProperties.DeadLetterSource, bindingData["DeadLetterSource"]);
            Assert.AreEqual(message.ExpiresAtUtc, bindingData["ExpiresAtUtc"]);
            Assert.AreSame(message.MessageId, bindingData["MessageId"]);
            Assert.AreSame(message.ContentType, bindingData["ContentType"]);
            Assert.AreSame(message.ReplyTo, bindingData["ReplyTo"]);
            Assert.AreSame(message.To, bindingData["To"]);
            Assert.AreSame(message.Label, bindingData["Label"]);
            Assert.AreSame(message.CorrelationId, bindingData["CorrelationId"]);

            IDictionary<string, object> bindingDataUserProps = bindingData["UserProperties"] as Dictionary<string, object>;
            Assert.NotNull(bindingDataUserProps);
            Assert.AreEqual("value1", bindingDataUserProps["prop1"]);
            Assert.AreEqual("value2", bindingDataUserProps["prop2"]);
        }

        [Test]
        public void GetBindingData_MultipleDispatch_ReturnsExpectedValue()
        {
            var messages = new Message[3]
            {
                new Message(Encoding.UTF8.GetBytes("Event 1")),
                new Message(Encoding.UTF8.GetBytes("Event 2")),
                new Message(Encoding.UTF8.GetBytes("Event 3")),
            };

            foreach (var message in messages)
            {
                SystemPropertiesCollection sysProps = GetSystemProperties();
                TestHelpers.SetField(message, "SystemProperties", sysProps);
            }

            var input = ServiceBusTriggerInput.CreateBatch(messages);
            var strategy = new ServiceBusTriggerBindingStrategy();
            var bindingData = strategy.GetBindingData(input);

            Assert.AreEqual(15, bindingData.Count);
            Assert.AreSame(input.MessageReceiver as MessageReceiver, bindingData["MessageReceiver"]);
            Assert.AreSame(input.MessageReceiver as IMessageSession, bindingData["MessageSession"]);

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
            Assert.AreEqual(messages.Length, ((string[])bindingData["LabelArray"]).Length);
            Assert.AreEqual(messages.Length, ((string[])bindingData["CorrelationIdArray"]).Length);
            Assert.AreEqual(messages.Length, ((IDictionary<string, object>[])bindingData["UserPropertiesArray"]).Length);
        }

        [Test]
        public void BindSingle_Returns_Exptected_Message()
        {
            string data = "123";

            var strategy = new ServiceBusTriggerBindingStrategy();
            ServiceBusTriggerInput triggerInput = strategy.ConvertFromString(data);

            var contract = strategy.GetBindingData(triggerInput);

            Message single = strategy.BindSingle(triggerInput, null);
            string body = Encoding.UTF8.GetString(single.Body);

            Assert.AreEqual(data, body);
            Assert.Null(contract["MessageReceiver"]);
            Assert.Null(contract["MessageSession"]);
        }

        private static void CheckBindingContract(Dictionary<string, Type> bindingDataContract)
        {
            Assert.AreEqual(15, bindingDataContract.Count);
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
            Assert.AreEqual(typeof(IDictionary<string, object>), bindingDataContract["UserProperties"]);
            Assert.AreEqual(typeof(MessageReceiver), bindingDataContract["MessageReceiver"]);
            Assert.AreEqual(typeof(IMessageSession), bindingDataContract["MessageSession"]);
        }

        private static SystemPropertiesCollection GetSystemProperties()
        {
            SystemPropertiesCollection sysProps = new SystemPropertiesCollection();
            TestHelpers.SetField(sysProps, "deliveryCount", 1);
            TestHelpers.SetField(sysProps, "lockedUntilUtc", DateTime.MinValue);
            TestHelpers.SetField(sysProps, "sequenceNumber", 1);
            TestHelpers.SetField(sysProps, "enqueuedTimeUtc", DateTime.MinValue);
            TestHelpers.SetField(sysProps, "lockTokenGuid", Guid.NewGuid());
            TestHelpers.SetField(sysProps, "deadLetterSource", "test");
            return sysProps;
        }
    }
}
