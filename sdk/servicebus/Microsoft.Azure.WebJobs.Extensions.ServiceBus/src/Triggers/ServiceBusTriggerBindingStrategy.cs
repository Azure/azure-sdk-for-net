// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    // Binding strategy for a service bus triggers.
#pragma warning disable 618
    internal class ServiceBusTriggerBindingStrategy : ITriggerBindingStrategy<Message, ServiceBusTriggerInput>
#pragma warning restore 618
    {
        public ServiceBusTriggerInput ConvertFromString(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            Message message = new Message(bytes);

            // Return a single message. Doesn't support multiple dispatch
            return ServiceBusTriggerInput.CreateSingle(message);
        }

        // Single instance: Core --> Message
        public Message BindSingle(ServiceBusTriggerInput value, ValueBindingContext context)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value.Messages[0];
        }

        public Message[] BindMultiple(ServiceBusTriggerInput value, ValueBindingContext context)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value.Messages;
        }

        public Dictionary<string, object> GetBindingData(ServiceBusTriggerInput value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            SafeAddValue(() => bindingData.Add(nameof(value.MessageReceiver), value.MessageReceiver as MessageReceiver));
            SafeAddValue(() => bindingData.Add("MessageSession", value.MessageReceiver as IMessageSession));

            if (value.IsSingleDispatch)
            {
                AddBindingData(bindingData, value.Messages[0]);
            }
            else
            {
                AddBindingData(bindingData, value.Messages);
            }

            return bindingData;
        }

        public Dictionary<string, Type> GetBindingContract(bool isSingleDispatch = true)
        {
            var contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
            AddBindingContractMember(contract, "DeliveryCount", typeof(int), isSingleDispatch);
            AddBindingContractMember(contract, "DeadLetterSource", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "LockToken", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "ExpiresAtUtc", typeof(DateTime), isSingleDispatch);
            AddBindingContractMember(contract, "EnqueuedTimeUtc", typeof(DateTime), isSingleDispatch);
            AddBindingContractMember(contract, "MessageId", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "ContentType", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "ReplyTo", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "SequenceNumber", typeof(long), isSingleDispatch);
            AddBindingContractMember(contract, "To", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "Label", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "CorrelationId", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "UserProperties", typeof(IDictionary<string, object>), isSingleDispatch);
            contract.Add("MessageReceiver", typeof(MessageReceiver));
            contract.Add("MessageSession", typeof(IMessageSession));

            return contract;
        }

        internal static void AddBindingData(Dictionary<string, object> bindingData, Message[] messages)
        {
            int length = messages.Length;
            var deliveryCounts = new int[length];
            var deadLetterSources = new string[length];
            var lockTokens = new string[length];
            var expiresAtUtcs = new DateTime[length];
            var enqueuedTimeUtcs = new DateTime[length];
            var messageIds = new string[length];
            var contentTypes = new string[length];
            var replyTos = new string[length];
            var sequenceNumbers = new long[length];
            var tos = new string[length];
            var labels = new string[length];
            var correlationIds = new string[length];
            var userProperties = new IDictionary<string, object>[length];

            SafeAddValue(() => bindingData.Add("DeliveryCountArray", deliveryCounts));
            SafeAddValue(() => bindingData.Add("DeadLetterSourceArray", deadLetterSources));
            SafeAddValue(() => bindingData.Add("LockTokenArray", lockTokens));
            SafeAddValue(() => bindingData.Add("ExpiresAtUtcArray", expiresAtUtcs));
            SafeAddValue(() => bindingData.Add("EnqueuedTimeUtcArray", enqueuedTimeUtcs));
            SafeAddValue(() => bindingData.Add("MessageIdArray", messageIds));
            SafeAddValue(() => bindingData.Add("ContentTypeArray", contentTypes));
            SafeAddValue(() => bindingData.Add("ReplyToArray", replyTos));
            SafeAddValue(() => bindingData.Add("SequenceNumberArray", sequenceNumbers));
            SafeAddValue(() => bindingData.Add("ToArray", tos));
            SafeAddValue(() => bindingData.Add("LabelArray", labels));
            SafeAddValue(() => bindingData.Add("CorrelationIdArray", correlationIds));
            SafeAddValue(() => bindingData.Add("UserPropertiesArray", userProperties));

            for (int i = 0; i < messages.Length; i++)
            {
                deliveryCounts[i] = messages[i].SystemProperties.DeliveryCount;
                deadLetterSources[i] = messages[i].SystemProperties.DeadLetterSource;
                lockTokens[i] = messages[i].SystemProperties.IsLockTokenSet ? messages[i].SystemProperties.LockToken : string.Empty;
                //this is temporary until the Service Bus SDK addresses the missing timezone issue in case DateTime.MaxValue, github.com/Azure/azure-sdk-for-net/issues/15343
                expiresAtUtcs[i] = messages[i].ExpiresAtUtc.ToUniversalTime();
                enqueuedTimeUtcs[i] = messages[i].SystemProperties.EnqueuedTimeUtc;
                messageIds[i] = messages[i].MessageId;
                contentTypes[i] = messages[i].ContentType;
                replyTos[i] = messages[i].ReplyTo;
                sequenceNumbers[i] = messages[i].SystemProperties.SequenceNumber;
                tos[i] = messages[i].To;
                labels[i] = messages[i].Label;
                correlationIds[i] = messages[i].CorrelationId;
                userProperties[i] = messages[i].UserProperties;
            }
        }

        private static void AddBindingData(Dictionary<string, object> bindingData, Message value)
        {
            SafeAddValue(() => bindingData.Add(nameof(value.SystemProperties.DeliveryCount), value.SystemProperties.DeliveryCount));
            SafeAddValue(() => bindingData.Add(nameof(value.SystemProperties.DeadLetterSource), value.SystemProperties.DeadLetterSource));
            SafeAddValue(() => bindingData.Add(nameof(value.SystemProperties.LockToken), value.SystemProperties.IsLockTokenSet ? value.SystemProperties.LockToken : string.Empty));
            //this is temporary until the Service Bus SDK addresses the missing timezone issue in case DateTime.MaxValue, github.com/Azure/azure-sdk-for-net/issues/15343
            SafeAddValue(() => bindingData.Add(nameof(value.ExpiresAtUtc), value.ExpiresAtUtc.ToUniversalTime()));
            SafeAddValue(() => bindingData.Add(nameof(value.SystemProperties.EnqueuedTimeUtc), value.SystemProperties.EnqueuedTimeUtc));
            SafeAddValue(() => bindingData.Add(nameof(value.MessageId), value.MessageId));
            SafeAddValue(() => bindingData.Add(nameof(value.ContentType), value.ContentType));
            SafeAddValue(() => bindingData.Add(nameof(value.ReplyTo), value.ReplyTo));
            SafeAddValue(() => bindingData.Add(nameof(value.SystemProperties.SequenceNumber), value.SystemProperties.SequenceNumber));
            SafeAddValue(() => bindingData.Add(nameof(value.To), value.To));
            SafeAddValue(() => bindingData.Add(nameof(value.Label), value.Label));
            SafeAddValue(() => bindingData.Add(nameof(value.CorrelationId), value.CorrelationId));
            SafeAddValue(() => bindingData.Add(nameof(value.UserProperties), value.UserProperties));
        }

        private static void SafeAddValue(Action addValue)
        {
            try
            {
                addValue();
            }
            catch
            {
                // some message propery getters can throw, based on the
                // state of the message
            }
        }

        private static void AddBindingContractMember(Dictionary<string, Type> contract, string name, Type type, bool isSingleDispatch)
        {
            if (!isSingleDispatch)
            {
                name += "Array";
            }

            contract.Add(name, isSingleDispatch ? type : type.MakeArrayType());
        }
    }
}