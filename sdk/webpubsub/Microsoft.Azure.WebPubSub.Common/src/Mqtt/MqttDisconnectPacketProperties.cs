// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

/// <summary>
/// Represents the properties of an MQTT DISCONNECT packet.
/// </summary>
[DataContract]
[JsonConverter(typeof(MqttDisconnectPacketPropertiesJsonConverter))]
internal class MqttDisconnectPacketProperties
{
    internal const string CodeProperty = "code";
    internal const string UserPropertiesProperty = "userProperties";

    /// <param name="code"></param>
    internal MqttDisconnectPacketProperties(MqttDisconnectReasonCode code)
    {
        Code = code;
    }

    /// <summary>
    /// The DISCONNECT reason code defined in MQTT 5.0 spec.
    /// For MQTT 3.1.1 clients, it's always the default value 0.
    /// </summary>
    [JsonPropertyName(CodeProperty)]
    [DataMember(Name = CodeProperty)]
    public MqttDisconnectReasonCode Code { get; }

    // TODO: Uncomment this property when we finalize the user properties design.
    ///// <summary>
    ///// The user properties in the DISCONNECT packet sent by the client.The value is not null only if the client sent a DISCONNECT packet with user properties.
    ///// </summary>
    //[DataMember(Name = UserPropertiesProperty)]
    //[JsonPropertyName(UserPropertiesProperty)]
    //[JsonConverter(typeof(MqttUserPropertyJsonConverter))]
    //internal IReadOnlyList<KeyValuePair<string, string>>? UserProperties { get; }
}
