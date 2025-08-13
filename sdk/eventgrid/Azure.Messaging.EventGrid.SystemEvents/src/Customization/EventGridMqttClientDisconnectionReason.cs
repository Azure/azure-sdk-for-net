// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Reason for the disconnection of the MQTT client's session. The value could be one of the values in the disconnection reasons table. </summary>
    public readonly partial struct EventGridMqttClientDisconnectionReason : IEquatable<EventGridMqttClientDisconnectionReason>
    {
        /// <summary> The client's IP address is blocked by IP filter or Private links configuration. </summary>
        [CodeGenMember("IpForbidden")]
        public static EventGridMqttClientDisconnectionReason IPForbidden { get; } =
            new EventGridMqttClientDisconnectionReason(IpForbiddenValue);
    }
}
