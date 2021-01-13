// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Xunit;
using static Microsoft.Azure.ServiceBus.Message;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class ServiceBusTriggerStrategyTests
    {
        [Fact]
        public void GetStaticBindingContract_ReturnsExpectedValue()
        {
            var strategy = new ServiceBusTriggerBindingStrategy();
            var bindingDataContract = strategy.GetBindingContract();

            CheckBindingContract(bindingDataContract);
        }

        [Fact]
        public void GetBindingContract_SingleDispatch_ReturnsExpectedValue()
        {
            var strategy = new ServiceBusTriggerBindingStrategy();
            var bindingDataContract = strategy.GetBindingContract(true);

            CheckBindingContract(bindingDataContract);
        }

        [Fact]
        public void GetBindingContract_MultipleDispatch_ReturnsExpectedValue()
        {
            var strategy = new ServiceBusTriggerBindingStrategy();
            var bindingDataContract = strategy.GetBindingContract(false);

            Assert.Equal(15, bindingDataContract.Count);
            Assert.Equal(typeof(int[]), bindingDataContract["DeliveryCountArray"]);
            Assert.Equal(typeof(string[]), bindingDataContract["DeadLetterSourceArray"]);
            Assert.Equal(typeof(string[]), bindingDataContract["LockTokenArray"]);
            Assert.Equal(typeof(DateTime[]), bindingDataContract["ExpiresAtUtcArray"]);
            Assert.Equal(typeof(DateTime[]), bindingDataContract["EnqueuedTimeUtcArray"]);
            Assert.Equal(typeof(string[]), bindingDataContract["MessageIdArray"]);
            Assert.Equal(typeof(string[]), bindingDataContract["ContentTypeArray"]);
            Assert.Equal(typeof(string[]), bindingDataContract["ReplyToArray"]);
            Assert.Equal(typeof(long[]), bindingDataContract["SequenceNumberArray"]);
            Assert.Equal(typeof(string[]), bindingDataContract["ToArray"]);
            Assert.Equal(typeof(string[]), bindingDataContract["LabelArray"]);
            Assert.Equal(typeof(string[]), bindingDataContract["CorrelationIdArray"]);
            Assert.Equal(typeof(IDictionary<string, object>[]), bindingDataContract["UserPropertiesArray"]);
            Assert.Equal(typeof(MessageReceiver), bindingDataContract["MessageReceiver"]);
            Assert.Equal(typeof(IMessageSession), bindingDataContract["MessageSession"]);
        }

        [Fact]
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

            Assert.Equal(15, bindingData.Count);  // SystemPropertiesCollection is sealed

            Assert.Same(input.MessageReceiver as MessageReceiver, bindingData["MessageReceiver"]);
            Assert.Same(input.MessageReceiver as IMessageSession, bindingData["MessageSession"]);
            Assert.Equal(message.SystemProperties.LockToken, bindingData["LockToken"]);
            Assert.Equal(message.SystemProperties.SequenceNumber, bindingData["SequenceNumber"]);
            Assert.Equal(message.SystemProperties.DeliveryCount, bindingData["DeliveryCount"]);
            Assert.Same(message.SystemProperties.DeadLetterSource, bindingData["DeadLetterSource"]);
            Assert.Equal(message.ExpiresAtUtc, bindingData["ExpiresAtUtc"]);
            Assert.Same(message.MessageId, bindingData["MessageId"]);
            Assert.Same(message.ContentType, bindingData["ContentType"]);
            Assert.Same(message.ReplyTo, bindingData["ReplyTo"]);
            Assert.Same(message.To, bindingData["To"]);
            Assert.Same(message.Label, bindingData["Label"]);
            Assert.Same(message.CorrelationId, bindingData["CorrelationId"]);

            IDictionary<string, object> bindingDataUserProps = bindingData["UserProperties"] as Dictionary<string, object>;
            Assert.NotNull(bindingDataUserProps);
            Assert.Equal("value1", bindingDataUserProps["prop1"]);
            Assert.Equal("value2", bindingDataUserProps["prop2"]);
        }

        [Fact]
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

            Assert.Equal(15, bindingData.Count);
            Assert.Same(input.MessageReceiver as MessageReceiver, bindingData["MessageReceiver"]);
            Assert.Same(input.MessageReceiver as IMessageSession, bindingData["MessageSession"]);

            // verify an array was created for each binding data type
            Assert.Equal(messages.Length, ((int[])bindingData["DeliveryCountArray"]).Length);
            Assert.Equal(messages.Length, ((string[])bindingData["DeadLetterSourceArray"]).Length);
            Assert.Equal(messages.Length, ((string[])bindingData["LockTokenArray"]).Length);
            Assert.Equal(messages.Length, ((DateTime[])bindingData["ExpiresAtUtcArray"]).Length);
            Assert.Equal(messages.Length, ((DateTime[])bindingData["EnqueuedTimeUtcArray"]).Length);
            Assert.Equal(messages.Length, ((string[])bindingData["MessageIdArray"]).Length);
            Assert.Equal(messages.Length, ((string[])bindingData["ContentTypeArray"]).Length);
            Assert.Equal(messages.Length, ((string[])bindingData["ReplyToArray"]).Length);
            Assert.Equal(messages.Length, ((long[])bindingData["SequenceNumberArray"]).Length);
            Assert.Equal(messages.Length, ((string[])bindingData["ToArray"]).Length);
            Assert.Equal(messages.Length, ((string[])bindingData["LabelArray"]).Length);
            Assert.Equal(messages.Length, ((string[])bindingData["CorrelationIdArray"]).Length);
            Assert.Equal(messages.Length, ((IDictionary<string, object>[])bindingData["UserPropertiesArray"]).Length);
        }

        [Fact]
        public void BindSingle_Returns_Exptected_Message()
        {
            string data = "123";

            var strategy = new ServiceBusTriggerBindingStrategy();
            ServiceBusTriggerInput triggerInput = strategy.ConvertFromString(data);

            var contract = strategy.GetBindingData(triggerInput);

            Message single = strategy.BindSingle(triggerInput, null);
            string body = Encoding.UTF8.GetString(single.Body);

            Assert.Equal(data, body);
            Assert.Null(contract["MessageReceiver"]);
            Assert.Null(contract["MessageSession"]);
        }

        private static void CheckBindingContract(Dictionary<string, Type> bindingDataContract)
        {
            Assert.Equal(15, bindingDataContract.Count);
            Assert.Equal(typeof(int), bindingDataContract["DeliveryCount"]);
            Assert.Equal(typeof(string), bindingDataContract["DeadLetterSource"]);
            Assert.Equal(typeof(string), bindingDataContract["LockToken"]);
            Assert.Equal(typeof(DateTime), bindingDataContract["ExpiresAtUtc"]);
            Assert.Equal(typeof(DateTime), bindingDataContract["EnqueuedTimeUtc"]);
            Assert.Equal(typeof(string), bindingDataContract["MessageId"]);
            Assert.Equal(typeof(string), bindingDataContract["ContentType"]);
            Assert.Equal(typeof(string), bindingDataContract["ReplyTo"]);
            Assert.Equal(typeof(long), bindingDataContract["SequenceNumber"]);
            Assert.Equal(typeof(string), bindingDataContract["To"]);
            Assert.Equal(typeof(string), bindingDataContract["Label"]);
            Assert.Equal(typeof(string), bindingDataContract["CorrelationId"]);
            Assert.Equal(typeof(IDictionary<string, object>), bindingDataContract["UserProperties"]);
            Assert.Equal(typeof(MessageReceiver), bindingDataContract["MessageReceiver"]);
            Assert.Equal(typeof(IMessageSession), bindingDataContract["MessageSession"]);
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
