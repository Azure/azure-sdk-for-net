// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    // Hub and event names can contain dots, so they must remain separate routing dimensions.
    internal readonly struct WebPubSubTriggerKey : IEquatable<WebPubSubTriggerKey>
    {
        private static readonly StringComparer NameComparer = StringComparer.InvariantCultureIgnoreCase;

        public WebPubSubTriggerKey(string hub, WebPubSubEventType eventType, string eventName, WebPubSubTriggerAcceptedClientProtocols clientProtocols)
        {
            Hub = hub ?? string.Empty;
            EventType = eventType;
            EventName = eventName ?? string.Empty;
            ClientProtocols = clientProtocols;
        }

        public string Hub { get; }

        public WebPubSubEventType EventType { get; }

        public string EventName { get; }

        public WebPubSubTriggerAcceptedClientProtocols ClientProtocols { get; }

        public bool Equals(WebPubSubTriggerKey other) =>
            NameComparer.Equals(Hub, other.Hub) &&
            EventType == other.EventType &&
            NameComparer.Equals(EventName, other.EventName) &&
            ClientProtocols == other.ClientProtocols;

        public override bool Equals(object obj) => obj is WebPubSubTriggerKey other && Equals(other);

        public override int GetHashCode() =>
            (NameComparer.GetHashCode(Hub ?? string.Empty), EventType,
                NameComparer.GetHashCode(EventName ?? string.Empty), ClientProtocols).GetHashCode();

        public override string ToString() => $"{Hub},{EventType},{EventName},{ClientProtocols}";
    }
}
