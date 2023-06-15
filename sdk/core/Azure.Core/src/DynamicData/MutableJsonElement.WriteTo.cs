// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Core.Json
{
    internal partial struct MutableJsonElement
    {
        internal void WriteTo(Utf8JsonWriter writer)
        {
            WriteElement(_path, _highWaterMark, _element, writer);
        }

        private void WriteElement(string path, int highWaterMark, JsonElement element, Utf8JsonWriter writer)
        {
            if (Changes.TryGetChange(path, highWaterMark, out MutableJsonChange change))
            {
                switch (change.Value)
                {
                    case int i:
                        writer.WriteNumberValue(i);
                        return;
                    case long l:
                        writer.WriteNumberValue(l);
                        return;
                    case double d:
                        writer.WriteNumberValue(d);
                        return;
                    case float f:
                        writer.WriteNumberValue(f);
                        return;
                    case bool b:
                        writer.WriteBooleanValue(b);
                        return;
                    case null:
                        writer.WriteNullValue();
                        return;
                    default:
                        break;

                        // Note: string is not included to let JsonElement handle escaping.
                }

                element = change.AsJsonElement();
                highWaterMark = change.Index;
            }

            if (Changes.DescendantChanged(path, highWaterMark))
            {
                switch (element.ValueKind)
                {
                    case JsonValueKind.Object:
                        WriteObject(path, highWaterMark, element, writer);
                        break;
                    case JsonValueKind.Array:
                        WriteArray(path, highWaterMark, element, writer);
                        break;
                    default:
                        throw new InvalidOperationException("Element doesn't have descendants.");
                }

                return;
            }

            element.WriteTo(writer);
        }

        private void WriteObject(string path, int highWaterMark, JsonElement element, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            foreach (JsonProperty property in element.EnumerateObject())
            {
                string propertyPath = MutableJsonDocument.ChangeTracker.PushProperty(path, property.Name);

                writer.WritePropertyName(property.Name);
                WriteElement(propertyPath, highWaterMark, property.Value, writer);
            }

            writer.WriteEndObject();
        }

        private void WriteArray(string path, int highWaterMark, JsonElement element, Utf8JsonWriter writer)
        {
            writer.WriteStartArray();

            int arrayIndex = 0;
            foreach (JsonElement arrayElement in element.EnumerateArray())
            {
                string arrayElementPath = MutableJsonDocument.ChangeTracker.PushIndex(path, arrayIndex++);
                WriteElement(arrayElementPath, highWaterMark, arrayElement, writer);
            }

            writer.WriteEndArray();
        }
    }
}
