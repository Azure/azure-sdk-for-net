// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable enable

namespace Microsoft.Azure.WebPubSub.Common;

/// <summary>
/// Successful response for MQTT connect event.
/// </summary>
[DataContract]
public sealed class MqttConnectEventResponse : ConnectEventResponse
{
    internal const string MqttWebSocketSubprotocolHeaderValue = "mqtt";
    internal const string MqttProperty = "mqtt";

    /// <summary>
    /// Default constructor for JsonSerialize.
    /// </summary>
    public MqttConnectEventResponse()
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="MqttConnectEventResponse"/>.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="groups"></param>
    /// <param name="roles"></param>
    public MqttConnectEventResponse(string? userId, IEnumerable<string>? groups, IEnumerable<string>? roles) : base(userId, groups, MqttWebSocketSubprotocolHeaderValue, roles)
    {
    }

    /// <summary>
    /// Represents the MQTT specific properties in a successful MQTT connection event response.
    /// </summary>
    [JsonPropertyName(MqttProperty)]
    [DataMember(Name = MqttProperty)]
    public MqttConnectEventResponseProperties? Mqtt { get; set; }
}
