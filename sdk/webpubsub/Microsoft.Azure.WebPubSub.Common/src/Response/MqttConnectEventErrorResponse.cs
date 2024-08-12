// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

/// <summary>
/// Represents the response properties of an MQTT connection failure.
/// </summary>
[DataContract]
public class MqttConnectEventErrorResponse : EventErrorResponse
{
    internal const string MqttProperty = "mqtt";

    /// <summary>
    /// Represents the properties of an MQTT connection failure response.
    /// </summary>
    [DataMember(Name = MqttProperty)]
    [JsonPropertyName(MqttProperty)]
    public MqttConnectEventErrorResponseProperties Mqtt
    {
        get;
    }

    /// <summary>
    /// Creates an instance of <see cref="MqttConnectEventErrorResponse"/>.
    /// </summary>
    public MqttConnectEventErrorResponse(MqttV500ConnectReasonCode code, string? reason) : base(WebPubSubErrorCodeExtensions.FromMqttV500ConnectReasonCode(code), reason)
    {
        Mqtt = new MqttConnectEventErrorResponseProperties(code)
        {
            Reason = reason
        };
    }

    /// <summary>
    /// Creates an instance of <see cref="MqttConnectEventErrorResponse"/>.
    /// </summary>
    public MqttConnectEventErrorResponse(MqttV311ConnectReturnCode code, string? reason) : base(WebPubSubErrorCodeExtensions.FromMqttV311ConnectReturnCode(code), reason)
    {
        Mqtt = new MqttConnectEventErrorResponseProperties(code)
        {
            Reason = reason
        };
    }

    /// <summary>
    /// Default constructor for JsonSerialize.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public MqttConnectEventErrorResponse(MqttConnectEventErrorResponseProperties mqtt)
    {
        Mqtt = mqtt;
    }
}
