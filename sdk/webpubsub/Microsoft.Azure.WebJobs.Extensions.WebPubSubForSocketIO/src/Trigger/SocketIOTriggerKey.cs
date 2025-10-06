// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal class SocketIOTriggerKey
    {
        public string Hub { get; set; }

        public string EventName { get; set; }

        public WebPubSubEventType EventType { get; set; }

        public string Namespace { get; set; }

        public SocketIOTriggerKey(string hub, string @namespace, WebPubSubEventType eventType, string eventName)
        {
            Hub = hub;
            EventName = eventName;
            EventType = eventType;
            Namespace = @namespace;
        }

        public override bool Equals(object obj)
        {
            if (obj is SocketIOTriggerKey key)
            {
                return string.Equals(Hub, key.Hub, StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals(EventName, key.EventName, StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals(Namespace, key.Namespace, StringComparison.InvariantCultureIgnoreCase)
                    && EventType == key.EventType;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + (Hub != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(Hub) : 0);
                hash = hash * 23 + (EventName != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(EventName) : 0);
                hash = hash * 23 + (Namespace != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(Namespace) : 0);
                hash = hash * 23 + EventType.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"Hub: {Hub}, Namespace: {Namespace}, EventName: {EventName}, EventType: {EventType}";
        }
    }
}
