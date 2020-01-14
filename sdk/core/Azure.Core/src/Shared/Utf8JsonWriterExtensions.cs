// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core
{
    internal static class Utf8JsonWriterExtensions
    {
        public static void WriteBooleanIfNotNull(this Utf8JsonWriter writer, string propertyName, bool? value)
        {
            if (value != default)
            {
                writer.WriteBoolean(propertyName, value.Value);
            }
        }

        public static void WriteStringIfNotNull(this Utf8JsonWriter writer, string propertyName, string value)
        {
            if (value != default)
            {
                writer.WriteString(propertyName, value);
            }
        }

        public static void WriteDictionaryIfNotNull(this Utf8JsonWriter writer, string propertyName, IDictionary<string, string> value)
        {
            if (value == default)
            {
                return;
            }

            writer.WriteStartObject(propertyName);
            foreach (KeyValuePair<string, string> kvp in value)
            {
                writer.WriteString(kvp.Key, kvp.Value);
            }
            writer.WriteEndObject();
        }
    }
}
