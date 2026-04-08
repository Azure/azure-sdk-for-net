// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Source-generated JSON serializer context for Web PubSub common types.
    /// Not intended for direct use.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [JsonSerializable(typeof(ConnectEventRequest))]
    [JsonSerializable(typeof(DisconnectedEventRequest))]
    [JsonSerializable(typeof(MqttConnectEventRequest))]
    [JsonSerializable(typeof(MqttDisconnectedEventRequest))]
    [JsonSerializable(typeof(MqttConnectProperties))]
    [JsonSerializable(typeof(MqttDisconnectedEventRequestProperties))]
    [JsonSerializable(typeof(JoinedGroupEventRequest))]
    [JsonSerializable(typeof(LeftGroupEventRequest))]
    [JsonSerializable(typeof(ConnectEventResponse))]
    [JsonSerializable(typeof(MqttConnectEventResponse))]
    [JsonSerializable(typeof(MqttConnectEventResponseProperties))]
    [JsonSerializable(typeof(MqttConnectEventErrorResponse))]
    [JsonSerializable(typeof(MqttConnectEventErrorResponseProperties))]
    [JsonSerializable(typeof(MqttUserProperty))]
    [JsonSourceGenerationOptions(
        PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        WriteIndented = false)]
    public partial class WebPubSubCommonJsonSerializerContext : JsonSerializerContext
    {
    }
}
