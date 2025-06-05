// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace EventGridSourceGenerator
{
    internal class SystemEventNode
    {
        public string EventName { get; set; }

        public string EventConstantName
        {
            get
            {
                // special case a few events that don't follow the pattern
                return EventName switch
                {
                    "ServiceBusDeadletterMessagesAvailableWithNoListenersEventData" => "ServiceBusDeadletterMessagesAvailableWithNoListener",
                    "SubscriptionDeletedEventData" => "EventGridSubscriptionDeleted",
                    "SubscriptionValidationEventData" => "EventGridSubscriptionValidation",
                    _ => EventName?.Replace("EventData", ""),
                };
            }
        }

        public string EventType { get; set; }

        public string DeserializeMethod { get; set; }
    }
}
