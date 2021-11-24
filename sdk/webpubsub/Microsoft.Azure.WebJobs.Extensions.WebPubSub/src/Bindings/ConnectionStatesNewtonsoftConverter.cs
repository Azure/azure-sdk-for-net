// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class ConnectionStatesNewtonsoftConverter : JsonConverter<IReadOnlyDictionary<string, BinaryData>>
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override IReadOnlyDictionary<string, BinaryData> ReadJson(JsonReader reader, Type objectType, IReadOnlyDictionary<string, BinaryData> existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            throw new NotImplementedException();

        public override void WriteJson(JsonWriter writer, IReadOnlyDictionary<string, BinaryData> value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            if (value != null)
            {
                foreach (KeyValuePair<string, BinaryData> pair in value)
                {
                    writer.WritePropertyName(pair.Key);
                    // BinaryData.ToString() use UTF8.GetString() which may lose data if original in real binary.
                    // TODO: considering whether to make it Base64Encode always.
                    writer.WriteRawValue(pair.Value.ToString());
                }
            }
            writer.WriteEndObject();
        }
    }
}