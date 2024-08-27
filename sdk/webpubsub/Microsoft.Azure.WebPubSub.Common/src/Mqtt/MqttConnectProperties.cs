// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

/// <summary>
/// The properties of the MQTT CONNECT packet.
/// </summary>
[DataContract]
[JsonConverter(typeof(MqttConnectPropertiesJsonConverter))]
public class MqttConnectProperties
{
    internal const string ProtocolVersionProperty = "protocolVersion";
    internal const string UsernameProperty = "username";
    internal const string PasswordProperty = "password";
    internal const string UserPropertiesProperty = "userProperties";

    internal MqttConnectProperties(MqttProtocolVersion protocolVersion, string? username, string? password)
    {
        ProtocolVersion = protocolVersion;
        Username = username;
        Password = password;
    }

    /// <summary>
    /// MQTT protocol version.
    /// </summary>
    /// <remarks>This API involves general purpose MQTT API. We can make it public once those general purpose MQTT API are released in a shared package.</remarks>
    [JsonPropertyName(ProtocolVersionProperty)]
    [DataMember(Name = ProtocolVersionProperty)]
    internal MqttProtocolVersion ProtocolVersion { get; }

    /// <summary>
    /// The username field in the MQTT CONNECT packet.
    /// </summary>
    [JsonPropertyName(UsernameProperty)]
    [DataMember(Name = UsernameProperty)]
    public string? Username { get; }

    /// <summary>
    ///The password field in the MQTT CONNECT packet.
    /// </summary>
    [JsonPropertyName(PasswordProperty)]
    [DataMember(Name = PasswordProperty)]
    public string? Password { get; }

    // Uncomment this property when we finalize the user properties design.
    ///// <summary>
    ///// The user properties in the MQTT CONNECT packet.
    ///// </summary>
    //[JsonPropertyName(UserPropertiesProperty)]
    //[DataMember(Name = UserPropertiesProperty)]
    //public IReadOnlyList<KeyValuePair<string, string>>? UserProperties { get; }
}
