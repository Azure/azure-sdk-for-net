// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubDataTypeJsonConverter : JsonConverter<WebPubSubDataType>
    {
        private static readonly JsonSerializer JsonSerializer = JsonSerializer.Create(new JsonSerializerSettings
        {
            Converters = new[]
            {
                new StringEnumConverter()
            }
        });

        public override WebPubSubDataType ReadJson(JsonReader reader, Type objectType, WebPubSubDataType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return JsonSerializer.Deserialize<WebPubSubDataType>(reader);
        }

        public override void WriteJson(JsonWriter writer, WebPubSubDataType value, JsonSerializer serializer)
        {
            JsonSerializer.Serialize(writer, value);
        }
    }
}
