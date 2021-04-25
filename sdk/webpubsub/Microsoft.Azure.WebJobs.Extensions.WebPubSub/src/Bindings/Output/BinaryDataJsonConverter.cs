// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class BinaryDataJsonConverter : JsonConverter<BinaryData>
    {
        public override BinaryData ReadJson(JsonReader reader, Type objectType, BinaryData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return BinaryData.FromString(serializer.Deserialize<string>(reader));
            }
            // string JObject
            return BinaryData.FromString(JToken.Load(reader).ToString());
        }

        public override void WriteJson(JsonWriter writer, BinaryData value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
}
