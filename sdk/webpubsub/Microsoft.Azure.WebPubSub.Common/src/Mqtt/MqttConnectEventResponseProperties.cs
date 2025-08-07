// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

/// <summary>
/// Represents the MQTT specific properties in a successful MQTT connection event response.
/// </summary>
[DataContract]
public class MqttConnectEventResponseProperties
{
    internal const string UserPropertiesProperty = "userProperties";

    /// <summary>
    /// It's additional diagnostic or other information provided by upstream server. They'll be converted to the user properties field in the CONNACK packet, and sent to clients whose protocols support user properties. Now only MQTT 5.0 supports user properties. Upstream webhook can use the property to communicate additional diagnostic or other information with clients.
    /// </summary>
    [DataMember(Name = UserPropertiesProperty)]
    [JsonPropertyName(UserPropertiesProperty)]
    public IReadOnlyList<MqttUserProperty>? UserProperties { get; set; }
}
