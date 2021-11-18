// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SystemJson = System.Text.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class StateDictionaryJsonConverter : JsonConverter<IReadOnlyDictionary<string, object>>
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override IReadOnlyDictionary<string, object> ReadJson(JsonReader reader, Type objectType, IReadOnlyDictionary<string, object> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, IReadOnlyDictionary<string, object> value, JsonSerializer serializer)
        {
            if (value != null)
            {
                writer.WriteStartObject();
                foreach (var pair in value)
                {
                    writer.WritePropertyName(pair.Key);
                    if (pair.Value is SystemJson.JsonElement element)
                    {
                        writer.WriteRawValue(element.GetRawText());
                    }
                    else
                    {
                        writer.WriteValue(pair.Value);
                    }
                }
                writer.WriteEndObject();
            }
        }
    }
}
