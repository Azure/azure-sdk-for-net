// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Azure.AI.Personalizer
{
    /// <summary> Json raw string list converter </summary>
    internal class JsonRawStringListConverter : JsonConverter<List<string>>
    {
        /// <summary>
        /// Not implemented.
        /// </summary>
        public override List<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Outputs the string contents as JSON.
        /// </summary>
        public override void Write(Utf8JsonWriter writer, List<string> value, JsonSerializerOptions options)
        {
            if (value != null)
            {
                writer.WriteStartArray();
                foreach (var str in value)
                    writer.WriteRawValue(str);
                writer.WriteEndArray();
                return;
            }

            JsonSerializer.Serialize(writer, value);
        }
    }
}
