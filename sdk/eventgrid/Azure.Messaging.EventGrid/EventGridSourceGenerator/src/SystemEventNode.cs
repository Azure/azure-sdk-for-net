// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.EventGrid.Messaging.SourceGeneration
{
    internal sealed class SystemEventNode
    {
        public SystemEventNode(string eventName, string eventType, string deserializeMethod)
        {
            EventName = eventName;
            EventType = eventType;
            DeserializeMethod = deserializeMethod;
            EventConstantName = Convert(EventName);
        }

        private static string Convert(string eventName)
        {
            // special case a few events that don't follow the pattern
            return eventName switch
            {
                "ServiceBusDeadletterMessagesAvailableWithNoListenersEventData" => "ServiceBusDeadletterMessagesAvailableWithNoListener",
                "SubscriptionDeletedEventData" => "EventGridSubscriptionDeleted",
                "SubscriptionValidationEventData" => "EventGridSubscriptionValidation",
                _ => eventName?.Replace("EventData", ""),
            };
        }

        public string EventName { get; }

        public string EventConstantName { get; }

        public string EventType { get; }

        public string DeserializeMethod { get; }
    }
}
