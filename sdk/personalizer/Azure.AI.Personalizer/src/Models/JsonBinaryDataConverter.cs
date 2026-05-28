// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace Azure.AI.Personalizer
{
    /// <summary> Json raw string list converter </summary>
    internal class JsonBinaryDataConverter : JsonConverter<BinaryData>
    {
        /// <summary>
        /// Not implemented.
        /// </summary>
        public override BinaryData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Outputs the binarydata contents as JSON.
        /// </summary>
        public override void Write(Utf8JsonWriter writer, BinaryData value, JsonSerializerOptions options)
        {
            using JsonDocument doc = JsonDocument.Parse(value.ToStream());
            doc.RootElement.WriteTo(writer);
        }
    }
}
