// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

/// <summary>
/// Represents the properties of an MQTT connection failure response.
/// </summary>
[DataContract]
public class MqttConnectEventErrorResponseProperties
{
    internal const string CodeProperty = "code";
    internal const string ReasonProperty = "reason";
    internal const string UserPropertiesProperty = "userProperties";
    /// <summary>
    /// The failure code. It will be sent to the clients in the CONNACK packet as a return code (MQTT 3.1.1) or reason code (MQTT 5.0). Upstream webhook should select a valid integer value defined the MQTT protocols according to the protocol versions of the clients. If Upstream webhook sets an invalid value, clients will receive "unspecified error" in the CONNACK packet.
    /// </summary>
    [DataMember(Name = CodeProperty)]
    [JsonPropertyName(CodeProperty)]
    public int Code
    {
        get;
    }

    /// <summary>
    /// The reason for the failure. It's a human readable failure reason string designed for diagnostics. It will be sent to those clients whose protocols support reason string in the CONNACK packet. Now only MQTT 5.0 supports it.
    /// </summary>
    [DataMember(Name = ReasonProperty)]
    [JsonPropertyName(ReasonProperty)]
    public string? Reason { get; set; }

    /// <summary>
    /// The user properties in the response.
    /// </summary>
    [DataMember(Name = UserPropertiesProperty)]
    [JsonPropertyName(UserPropertiesProperty)]
    public IReadOnlyList<MqttUserProperty>? UserProperties { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="MqttConnectEventErrorResponseProperties"/>.
    /// </summary>
    /// <param name="code"></param>
    public MqttConnectEventErrorResponseProperties(MqttV500ConnectReasonCode code)
    {
        Code = (int)code;
    }

    /// <summary>
    /// Creates a new instance of <see cref="MqttConnectEventErrorResponseProperties"/>.
    /// </summary>
    /// <param name="code"></param>
    public MqttConnectEventErrorResponseProperties(MqttV311ConnectReturnCode code)
    {
        Code = (int)code;
    }
}
