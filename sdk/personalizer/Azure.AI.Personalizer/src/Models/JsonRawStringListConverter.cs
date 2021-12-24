// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Azure.AI.Personalizer
{
    /// <summary> Json raw string list converter </summary>
    internal class JsonRawStringListConverter : JsonConverter
    {
        /// <summary>
        /// Supports string only.
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<string>);
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Outputs the string contents as JSON.
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var valueStringEnumerable = value as List<string>;
            if (valueStringEnumerable != null)
            {
                writer.WriteStartArray();
                foreach (var str in valueStringEnumerable)
                    writer.WriteRawValue(str);
                writer.WriteEndArray();
                return;
            }

            serializer.Serialize(writer, value);
        }

        /// <summary>
        /// List of independently parseable JSON fragments.
        /// </summary>
        public static IEnumerable<string> JsonFragments(object value)
        {
            var valueStringList = value as List<string>;
            if (valueStringList == null)
                throw new ArgumentException($"Unsupported type: {value}");

            return valueStringList;
        }
    }
}
