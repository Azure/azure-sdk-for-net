// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    // Binding strategy for a service bus triggers.
#pragma warning disable 618
    internal class ServiceBusTriggerBindingStrategy : ITriggerBindingStrategy<ServiceBusReceivedMessage, ServiceBusTriggerInput>
#pragma warning restore 618
    {
        public ServiceBusTriggerInput ConvertFromString(string input)
        {
            ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(new BinaryData(input));

            // Return a single message. Doesn't support multiple dispatch
            return ServiceBusTriggerInput.CreateSingle(message, null, null, null);
        }

        // Single instance: Core --> Message
        public ServiceBusReceivedMessage BindSingle(ServiceBusTriggerInput value, ValueBindingContext context)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value.Messages[0];
        }

        public ServiceBusReceivedMessage[] BindMultiple(ServiceBusTriggerInput value, ValueBindingContext context)
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

            // Support MessageReceiver and MessageSession parameters for backcompat
            SafeAddValue(() => bindingData.Add("MessageReceiver", value.MessageActions));
            SafeAddValue(() => bindingData.Add("MessageSession", value.MessageActions));

            SafeAddValue(() => bindingData.Add("MessageActions", value.MessageActions));
            SafeAddValue(() => bindingData.Add("SessionActions", value.MessageActions));
            SafeAddValue(() => bindingData.Add("ReceiveActions", value.ReceiveActions));
            SafeAddValue(() => bindingData.Add("Client", value.Client));

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
            AddBindingContractMember(contract, "ExpiresAt", typeof(DateTimeOffset), isSingleDispatch);
            AddBindingContractMember(contract, "EnqueuedTimeUtc", typeof(DateTime), isSingleDispatch);
            AddBindingContractMember(contract, "EnqueuedTime", typeof(DateTimeOffset), isSingleDispatch);
            AddBindingContractMember(contract, "MessageId", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "ContentType", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "ReplyTo", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "SequenceNumber", typeof(long), isSingleDispatch);
            AddBindingContractMember(contract, "To", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "Subject", typeof(string), isSingleDispatch);
            // for backcompat
            AddBindingContractMember(contract, "Label", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "CorrelationId", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "ApplicationProperties", typeof(IDictionary<string, object>), isSingleDispatch);
            // for backcompat
            AddBindingContractMember(contract, "UserProperties", typeof(IDictionary<string, object>), isSingleDispatch);
            AddBindingContractMember(contract, "SessionId", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "ReplyToSessionId", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "PartitionKey", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "TransactionPartitionKey", typeof(string), isSingleDispatch);

            contract.Add("MessageReceiver", typeof(ServiceBusMessageActions));
            contract.Add("MessageSession", typeof(ServiceBusSessionMessageActions));
            contract.Add("MessageActions", typeof(ServiceBusMessageActions));
            contract.Add("SessionActions", typeof(ServiceBusSessionMessageActions));
            contract.Add("ReceiveActions", typeof(ServiceBusReceiveActions));
            contract.Add("Client", typeof(ServiceBusClient));
            return contract;
        }

        internal static void AddBindingData(Dictionary<string, object> bindingData, ServiceBusReceivedMessage[] messages)
        {
            int length = messages.Length;
            var deliveryCounts = new int[length];
            var deadLetterSources = new string[length];
            var lockTokens = new string[length];
            var expiresAtUtcs = new DateTime[length];
            var expiresAt = new DateTimeOffset[length];
            var enqueuedTimeUtcs = new DateTime[length];
            var enqueuedTimes = new DateTimeOffset[length];
            var messageIds = new string[length];
            var contentTypes = new string[length];
            var replyTos = new string[length];
            var sequenceNumbers = new long[length];
            var tos = new string[length];
            var subjects = new string[length];
            var correlationIds = new string[length];
            var applicationProperties = new IDictionary<string, object>[length];
            var sessionIds = new string[length];
            var replyToSessionIds = new string[length];
            var partitionKeys = new string[length];
            var transactionPartitionKeys = new string[length];

            SafeAddValue(() => bindingData.Add("DeliveryCountArray", deliveryCounts));
            SafeAddValue(() => bindingData.Add("DeadLetterSourceArray", deadLetterSources));
            SafeAddValue(() => bindingData.Add("LockTokenArray", lockTokens));
            SafeAddValue(() => bindingData.Add("ExpiresAtUtcArray", expiresAtUtcs));
            SafeAddValue(() => bindingData.Add("ExpiresAtArray", expiresAt));
            SafeAddValue(() => bindingData.Add("EnqueuedTimeUtcArray", enqueuedTimeUtcs));
            SafeAddValue(() => bindingData.Add("EnqueuedTimeArray", enqueuedTimes));
            SafeAddValue(() => bindingData.Add("MessageIdArray", messageIds));
            SafeAddValue(() => bindingData.Add("ContentTypeArray", contentTypes));
            SafeAddValue(() => bindingData.Add("ReplyToArray", replyTos));
            SafeAddValue(() => bindingData.Add("SequenceNumberArray", sequenceNumbers));
            SafeAddValue(() => bindingData.Add("ToArray", tos));
            SafeAddValue(() => bindingData.Add("SubjectArray", subjects));
            // for backcompat
            SafeAddValue(() => bindingData.Add("LabelArray", subjects));
            SafeAddValue(() => bindingData.Add("CorrelationIdArray", correlationIds));
            SafeAddValue(() => bindingData.Add("ApplicationPropertiesArray", applicationProperties));
            // for backcompat
            SafeAddValue(() => bindingData.Add("UserPropertiesArray", applicationProperties));
            SafeAddValue(() => bindingData.Add("SessionIdArray", sessionIds));
            SafeAddValue(() => bindingData.Add("ReplyToSessionIdArray", replyToSessionIds));
            SafeAddValue(() => bindingData.Add("PartitionKeyArray", partitionKeys));
            SafeAddValue(() => bindingData.Add("TransactionPartitionKeyArray", partitionKeys));
            for (int i = 0; i < messages.Length; i++)
            {
                deliveryCounts[i] = messages[i].DeliveryCount;
                deadLetterSources[i] = messages[i].DeadLetterSource;
                lockTokens[i] = messages[i].LockToken;
                expiresAtUtcs[i] = messages[i].ExpiresAt.DateTime;
                expiresAt[i] = messages[i].ExpiresAt;
                enqueuedTimeUtcs[i] = messages[i].EnqueuedTime.DateTime;
                enqueuedTimes[i] = messages[i].EnqueuedTime;
                messageIds[i] = messages[i].MessageId;
                contentTypes[i] = messages[i].ContentType;
                replyTos[i] = messages[i].ReplyTo;
                sequenceNumbers[i] = messages[i].SequenceNumber;
                tos[i] = messages[i].To;
                subjects[i] = messages[i].Subject;
                correlationIds[i] = messages[i].CorrelationId;
                applicationProperties[i] = messages[i].ApplicationProperties.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                sessionIds[i] = messages[i].SessionId;
                replyToSessionIds[i] = messages[i].ReplyToSessionId;
                partitionKeys[i] = messages[i].PartitionKey;
                transactionPartitionKeys[i] = messages[i].TransactionPartitionKey;
            }
        }

        private static void AddBindingData(Dictionary<string, object> bindingData, ServiceBusReceivedMessage value)
        {
            SafeAddValue(() => bindingData.Add(nameof(value.DeliveryCount), value.DeliveryCount));
            SafeAddValue(() => bindingData.Add(nameof(value.DeadLetterSource), value.DeadLetterSource));
            SafeAddValue(() => bindingData.Add(nameof(value.LockToken), value.LockToken));
            // for backcompat
            SafeAddValue(() => bindingData.Add("ExpiresAtUtc", value.ExpiresAt.DateTime));
            SafeAddValue(() => bindingData.Add(nameof(value.ExpiresAt), value.ExpiresAt));
            // for backcompat
            SafeAddValue(() => bindingData.Add("EnqueuedTimeUtc", value.EnqueuedTime.DateTime));
            SafeAddValue(() => bindingData.Add(nameof(value.EnqueuedTime), value.EnqueuedTime));
            SafeAddValue(() => bindingData.Add(nameof(value.MessageId), value.MessageId));
            SafeAddValue(() => bindingData.Add(nameof(value.ContentType), value.ContentType));
            SafeAddValue(() => bindingData.Add(nameof(value.ReplyTo), value.ReplyTo));
            SafeAddValue(() => bindingData.Add(nameof(value.SequenceNumber), value.SequenceNumber));
            SafeAddValue(() => bindingData.Add(nameof(value.To), value.To));
            SafeAddValue(() => bindingData.Add(nameof(value.Subject), value.Subject));
            // for backcompat
            SafeAddValue(() => bindingData.Add("Label", value.Subject));
            SafeAddValue(() => bindingData.Add(nameof(value.CorrelationId), value.CorrelationId));
            SafeAddValue(() => bindingData.Add(nameof(value.ApplicationProperties), value.ApplicationProperties));
            // for backcompat
            SafeAddValue(() => bindingData.Add("UserProperties", value.ApplicationProperties));
            SafeAddValue(() => bindingData.Add(nameof(value.SessionId), value.SessionId));
            SafeAddValue(() => bindingData.Add(nameof(value.ReplyToSessionId), value.ReplyToSessionId));
            SafeAddValue(() => bindingData.Add(nameof(value.PartitionKey), value.PartitionKey));
            SafeAddValue(() => bindingData.Add(nameof(value.TransactionPartitionKey), value.TransactionPartitionKey));
        }

        private static void SafeAddValue(Action addValue)
        {
            try
            {
                addValue();
            }
            catch
            {
                // some message property getters can throw, based on the
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