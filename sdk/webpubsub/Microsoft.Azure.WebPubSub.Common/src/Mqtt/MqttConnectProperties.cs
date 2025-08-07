// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;
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

    /// <summary>
    /// Creates a new instance of <see cref="MqttConnectProperties"/>.
    /// </summary>
    /// <param name="protocolVersion"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="userProperties"></param>
    internal MqttConnectProperties(MqttProtocolVersion protocolVersion, string? username, string? password, IReadOnlyList<MqttUserProperty>? userProperties)
    {
        ProtocolVersion = protocolVersion;
        Username = username;
        Password = password;
        UserProperties = userProperties;
    }

    /// <summary>
    /// MQTT protocol version.
    /// </summary>
    [JsonPropertyName(ProtocolVersionProperty)]
    [DataMember(Name = ProtocolVersionProperty)]
    public MqttProtocolVersion ProtocolVersion { get; }

    /// <summary>
    /// The username field in the MQTT CONNECT packet.
    /// </summary>
    [JsonPropertyName(UsernameProperty)]
    [DataMember(Name = UsernameProperty)]
    public string? Username { get; }

    /// <summary>
    ///The password field in the MQTT CONNECT packet.
    /// Use string type instead of byte[] to avoid the problem of serialization.
    /// Although System.Text.Json serializes byte[] to base64 string by default, it is not explicitly documented.
    /// </summary>
    [JsonPropertyName(PasswordProperty)]
    [DataMember(Name = PasswordProperty)]
    public string? Password { get; }

    /// <summary>
    /// The user properties in the MQTT CONNECT packet.
    /// </summary>
    [JsonPropertyName(UserPropertiesProperty)]
    [DataMember(Name = UserPropertiesProperty)]
    public IReadOnlyList<MqttUserProperty>? UserProperties { get; }
}
