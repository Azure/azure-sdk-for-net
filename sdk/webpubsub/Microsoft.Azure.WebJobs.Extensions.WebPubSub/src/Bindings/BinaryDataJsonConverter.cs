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

            var value = JToken.Load(reader);

            if (TryLoadBinary(value, out var bytes))
            {
                return BinaryData.FromBytes(bytes);
            }
            // string JObject
            return BinaryData.FromString(value.ToString());
        }

        public override void WriteJson(JsonWriter writer, BinaryData value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }

        private static bool TryLoadBinary(JToken input, out byte[] output)
        {
            if (input["type"] != null)
            {
                var target = input.ToObject<ArrayBuffer>();
                output = target.Data;
                return true;
            }
            output = null;
            return false;
        }

        private sealed class ArrayBuffer
        {
            public string Type { get; set; }
            public byte[] Data { get; set; }
        }
    }
}
