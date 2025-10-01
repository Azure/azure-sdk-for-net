// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    // Binding strategy for an event hub triggers.
#pragma warning disable 618
    internal class EventHubTriggerBindingStrategy : ITriggerBindingStrategy<EventData, EventHubTriggerInput>
#pragma warning restore 618
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public EventHubTriggerInput ConvertFromString(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            EventData eventData = new EventData(bytes);

            // Return a single event. Doesn't support multiple dispatch
            return EventHubTriggerInput.New(eventData);
        }

        // Single instance: Core --> EventData
        public EventData BindSingle(EventHubTriggerInput value, ValueBindingContext context)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            return value.GetSingleEventData();
        }

        public EventData[] BindMultiple(EventHubTriggerInput value, ValueBindingContext context)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            return value.Events;
        }

        public Dictionary<string, Type> GetBindingContract(bool isSingleDispatch = true)
        {
            var contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
            contract.Add("TriggerPartitionContext", typeof(TriggerPartitionContext));
            contract.Add("PartitionContext", typeof(PartitionContext));

            AddBindingContractMember(contract, "PartitionKey", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "Offset", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "OffsetString", typeof(string), isSingleDispatch);
            AddBindingContractMember(contract, "SequenceNumber", typeof(long), isSingleDispatch);
            AddBindingContractMember(contract, "EnqueuedTimeUtc", typeof(DateTime), isSingleDispatch);
            AddBindingContractMember(contract, "Properties", typeof(IDictionary<string, object>), isSingleDispatch);
            AddBindingContractMember(contract, "SystemProperties", typeof(IDictionary<string, object>), isSingleDispatch);

            return contract;
        }

        private static void AddBindingContractMember(Dictionary<string, Type> contract, string name, Type type, bool isSingleDispatch)
        {
            if (!isSingleDispatch)
            {
                name += "Array";
            }
            contract.Add(name, isSingleDispatch ? type : type.MakeArrayType());
        }

        public Dictionary<string, object> GetBindingData(EventHubTriggerInput value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            SafeAddValue(() => bindingData.Add("TriggerPartitionContext", value.ProcessorPartition?.PartitionContext));
            SafeAddValue(() => bindingData.Add("PartitionContext", value.ProcessorPartition?.PartitionContext));

            if (value.IsSingleDispatch)
            {
                AddBindingData(bindingData, value.GetSingleEventData());
            }
            else
            {
                AddBindingData(bindingData, value.Events);
            }

            return bindingData;
        }

        internal static void AddBindingData(Dictionary<string, object> bindingData, EventData[] events)
        {
            var length = events.Length;
            var partitionKeys = new string[length];
            var offsets = new string[length];
            var offsetStrings = new string[length];
            var sequenceNumbers = new long[length];
            var enqueuedTimesUtc = new DateTime[length];
            var properties = new IDictionary<string, object>[length];
            var systemProperties = new IDictionary<string, object>[length];

            SafeAddValue(() => bindingData.Add("PartitionKeyArray", partitionKeys));
            SafeAddValue(() => bindingData.Add("OffsetArray", offsets));
            SafeAddValue(() => bindingData.Add("OffsetStringArray", offsetStrings));
            SafeAddValue(() => bindingData.Add("SequenceNumberArray", sequenceNumbers));
            SafeAddValue(() => bindingData.Add("EnqueuedTimeUtcArray", enqueuedTimesUtc));
            SafeAddValue(() => bindingData.Add("PropertiesArray", properties));
            SafeAddValue(() => bindingData.Add("SystemPropertiesArray", systemProperties));

            for (int i = 0; i < events.Length; i++)
            {
                if (!long.TryParse(events[i].OffsetString, NumberStyles.Integer, CultureInfo.InvariantCulture, out var offset))
                {
                    // Default to "beginning of stream" if parsing fails.  This will result in duplicates,
                    // but ensures no data loss.

                    offset = -1;
                }

                partitionKeys[i] = events[i].PartitionKey;
                offsets[i] = offset.ToString(CultureInfo.InvariantCulture);
                offsetStrings[i] = events[i].OffsetString;
                sequenceNumbers[i] = events[i].SequenceNumber;
                enqueuedTimesUtc[i] = events[i].EnqueuedTime.DateTime;
                properties[i] = events[i].Properties;
                systemProperties[i] = GetSystemPropertiesForBinding(events[i]);
            }
        }

        private static void AddBindingData(Dictionary<string, object> bindingData, EventData eventData)
        {
            if (!long.TryParse(eventData.OffsetString, NumberStyles.Integer, CultureInfo.InvariantCulture, out var offset))
            {
                // Default to "beginning of stream" if parsing fails.  This will result in duplicates,
                // but ensures no data loss.

                offset = -1;
            }

            SafeAddValue(() => bindingData.Add("PartitionKey", eventData.PartitionKey));
            SafeAddValue(() => bindingData.Add("Offset", offset.ToString(CultureInfo.InvariantCulture)));
            SafeAddValue(() => bindingData.Add("OffsetString", eventData.OffsetString));
            SafeAddValue(() => bindingData.Add("SequenceNumber", eventData.SequenceNumber));
            SafeAddValue(() => bindingData.Add("EnqueuedTimeUtc", eventData.EnqueuedTime.DateTime));
            SafeAddValue(() => bindingData.Add("Properties", eventData.Properties));
            SafeAddValue(() => bindingData.Add("SystemProperties", GetSystemPropertiesForBinding(eventData)));
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

        private static IDictionary<string, object> GetSystemPropertiesForBinding(EventData eventData)
        {
            IDictionary<string, object> modifiedDictionary = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> kvp in eventData.SystemProperties)
            {
                modifiedDictionary[kvp.Key] = kvp.Value;
            }

            // Following is needed to maintain structure of bindingdata: https://github.com/Azure/azure-webjobs-sdk/pull/1849

            if (!long.TryParse(eventData.OffsetString, NumberStyles.Integer, CultureInfo.InvariantCulture, out var offset))
            {
                // Default to "beginning of stream" if parsing fails.  This will result in duplicates,
                // but ensures no data loss.

                offset = -1;
            }

            modifiedDictionary["SequenceNumber"] = eventData.SequenceNumber;
            modifiedDictionary["Offset"] = offset;
            modifiedDictionary["OffsetString"] = eventData.OffsetString;
            modifiedDictionary["PartitionKey"] = eventData.PartitionKey;
            modifiedDictionary["EnqueuedTimeUtc"] = eventData.EnqueuedTime.DateTime;
            return modifiedDictionary;
        }
    }
}