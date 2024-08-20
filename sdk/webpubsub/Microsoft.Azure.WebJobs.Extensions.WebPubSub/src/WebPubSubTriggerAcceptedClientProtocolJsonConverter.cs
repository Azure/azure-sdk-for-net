// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

internal class WebPubSubTriggerAcceptedClientProtocolJsonConverter : JsonConverter<WebPubSubTriggerAcceptedClientProtocol>
{
    private static readonly JsonSerializer JsonSerializer = JsonSerializer.Create(new JsonSerializerSettings
    {
        Converters = new[]
        {
            new StringEnumConverter()
        }
    });

    public override WebPubSubTriggerAcceptedClientProtocol ReadJson(JsonReader reader, Type objectType, WebPubSubTriggerAcceptedClientProtocol existingValue, bool hasExistingValue, JsonSerializer serializer) => JsonSerializer.Deserialize<WebPubSubTriggerAcceptedClientProtocol>(reader);

    public override void WriteJson(JsonWriter writer, WebPubSubTriggerAcceptedClientProtocol value, JsonSerializer serializer) => JsonSerializer.Serialize(writer, value);
}
