// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SystemJson = System.Text.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// JsonConverter works for Functions JavaScript language object converters.
    /// </summary>
    internal class ConnectionStatesNewtonsoftConverter : JsonConverter<IReadOnlyDictionary<string, BinaryData>>
    {
        public override IReadOnlyDictionary<string, BinaryData> ReadJson(JsonReader reader, Type objectType, IReadOnlyDictionary<string, BinaryData> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dic = new Dictionary<string, BinaryData>();
            var jdic = JToken.Load(reader).ToObject<Dictionary<string, JToken>>();
            foreach (var item in jdic)
            {
                dic.Add(item.Key, BinaryData.FromString(JsonConvert.SerializeObject(item.Value)));
            }

            return dic;
        }

        public override void WriteJson(JsonWriter writer, IReadOnlyDictionary<string, BinaryData> value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            if (value != null)
            {
                foreach (KeyValuePair<string, BinaryData> pair in value)
                {
                    writer.WritePropertyName(pair.Key);
                    writer.WriteRawValue(pair.Value.ToString());
                }
            }
            writer.WriteEndObject();
        }
    }
}