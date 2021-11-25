// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebPubSub.Common;
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
            var rawJson = JObject.Load(reader).ToString();

            return LoadWithSystemJson(rawJson);
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

        private static IReadOnlyDictionary<string, BinaryData> LoadWithSystemJson(string rawJson)
        {
            var dic = new Dictionary<string, BinaryData>();
            var element = SystemJson.JsonDocument.Parse(rawJson).RootElement;
            foreach (var elementInfo in element.EnumerateObject())
            {
                dic.Add(elementInfo.Name, BinaryData.FromString(elementInfo.Value.GetRawText()));
            }
            return dic;
        }
    }
}