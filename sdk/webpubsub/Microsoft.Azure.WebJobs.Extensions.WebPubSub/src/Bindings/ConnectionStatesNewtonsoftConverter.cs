// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// JsonConverter works for Functions JavaScript language object converters.
    /// </summary>
    internal class ConnectionStatesNewtonsoftConverter : JsonConverter<IReadOnlyDictionary<string, BinaryData>>
    {
        public override IReadOnlyDictionary<string, BinaryData> ReadJson(JsonReader reader, Type objectType, IReadOnlyDictionary<string, BinaryData> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dict = new Dictionary<string, BinaryData>();
            var jDict = JToken.Load(reader).ToObject<Dictionary<string, JToken>>();
            foreach (var item in jDict)
            {
                // Pairing with WriteJson of always write RawValue
                dict.Add(item.Key, BinaryData.FromString(JsonConvert.SerializeObject(item.Value)));
            }

            return dict;
        }

        public override void WriteJson(JsonWriter writer, IReadOnlyDictionary<string, BinaryData> value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            if (value != null)
            {
                foreach (KeyValuePair<string, BinaryData> pair in value)
                {
                    writer.WritePropertyName(pair.Key);
                    // Pairing with ReadJson of always stringify value.
                    writer.WriteRawValue(pair.Value.ToString());
                }
            }
            writer.WriteEndObject();
        }
    }
}