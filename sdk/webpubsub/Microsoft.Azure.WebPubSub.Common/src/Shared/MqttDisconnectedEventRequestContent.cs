// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

internal class MqttDisconnectedEventRequestContent
{
    [JsonPropertyName("reason")]
    public string Reason { get; set; }

    [JsonPropertyName("mqtt")]
    public MqttDisconnectedEventRequestProperties Mqtt { get; set; }
}
