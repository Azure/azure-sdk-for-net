// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

internal class WebPubSubTriggerAcceptedClientProtocolsJsonConverter : JsonConverter<WebPubSubTriggerAcceptedClientProtocols>
{
    private static readonly JsonSerializer JsonSerializer = JsonSerializer.Create(new JsonSerializerSettings
    {
        Converters = new[]
        {
            new StringEnumConverter()
        }
    });

    public override WebPubSubTriggerAcceptedClientProtocols ReadJson(JsonReader reader, Type objectType, WebPubSubTriggerAcceptedClientProtocols existingValue, bool hasExistingValue, JsonSerializer serializer) => JsonSerializer.Deserialize<WebPubSubTriggerAcceptedClientProtocols>(reader);

    public override void WriteJson(JsonWriter writer, WebPubSubTriggerAcceptedClientProtocols value, JsonSerializer serializer) => JsonSerializer.Serialize(writer, value);
}
