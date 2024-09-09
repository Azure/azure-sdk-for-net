// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

/// <summary>
/// This converter is used to avoid serializing the properties of the base class <see cref="EventErrorResponse"/>.
/// </summary>
internal class MqttConnectEventErrorResponseJsonConverter : JsonConverter<MqttConnectEventErrorResponse>
{
    public static MqttConnectEventErrorResponseJsonConverter Instance = new();

    public override MqttConnectEventErrorResponse ReadJson(JsonReader reader, Type objectType, MqttConnectEventErrorResponse existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, MqttConnectEventErrorResponse value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("mqtt");
        serializer.Serialize(writer, value.Mqtt);
        writer.WriteEndObject();
    }
}
