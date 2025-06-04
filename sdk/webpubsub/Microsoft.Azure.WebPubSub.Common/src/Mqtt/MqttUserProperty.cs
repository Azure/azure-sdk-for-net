// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

/// <summary>
/// A class representing a user property in MQTT.
/// </summary>
[DataContract]
[JsonConverter(typeof(MqttUserPropertyJsonConverter))]
public record MqttUserProperty
{
    internal const string NamePropertyName = "name";
    internal const string ValuePropertyName = "value";

    /// <summary>
    /// Creates a new instance of <see cref="MqttUserProperty"/>.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public MqttUserProperty(string name, string value)
    {
        Name = name;
        Value = value;
    }

    /// <summary>
    /// The name of the property.
    /// </summary>
    [DataMember(Name = NamePropertyName)]
    [JsonPropertyName(NamePropertyName)]
    public string Name { get; }

    /// <summary>
    /// The value of the property.
    /// </summary>
    [DataMember(Name = ValuePropertyName)]
    [JsonPropertyName(ValuePropertyName)]
    public string Value { get; }
}