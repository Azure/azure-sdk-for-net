// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

/// <summary>
/// Represents the response of an MQTT connection failure.
/// </summary>
[DataContract]
public class MqttDisconnectedEventRequest : DisconnectedEventRequest
{
    internal const string MqttProperty = "mqtt";

    /// <summary>
    /// Creates a new instance of <see cref="MqttDisconnectedEventRequest"/>.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="reason"></param>
    /// <param name="mqtt"></param>
    public MqttDisconnectedEventRequest(MqttConnectionContext context, string reason, MqttDisconnectedEventRequestProperties mqtt) : base(context, reason)
    {
        Mqtt = mqtt;
    }

    /// <summary>
    /// Represents the properties of an MQTT disconnection event request.
    /// </summary>
    [DataMember(Name = MqttProperty)]
    [JsonPropertyName(MqttProperty)]
    public MqttDisconnectedEventRequestProperties Mqtt { get; }
}
