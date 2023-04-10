// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Core.Json
{
    public partial struct MutableJsonElement
    {
        internal void WriteTo(Utf8JsonWriter writer)
        {
            WriteElement(_path, _highWaterMark, _element, writer);
            writer.Flush();
        }

        private void WriteElement(string path, int highWaterMark, JsonElement originalElement, Utf8JsonWriter writer)
        {
            if (Changes.TryGetChange(path, highWaterMark, out MutableJsonChange change))
            {
                change.AsJsonElement().WriteTo(writer);
                return;
            }

            if (Changes.DescendantChanged(path, highWaterMark))
            {
                switch (originalElement.ValueKind)
                {
                    case JsonValueKind.Object:
                        WriteObject(path, highWaterMark, originalElement, writer);
                        break;
                    case JsonValueKind.Array:
                        WriteArray(path, highWaterMark, originalElement, writer);
                        break;
                    default:
                        throw new InvalidOperationException("Element doesn't have descendants.");
                }

                return;
            }

            originalElement.WriteTo(writer);
        }

        private void WriteObject(string path, int highWaterMark, JsonElement originalElement, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            foreach (JsonProperty property in originalElement.EnumerateObject())
            {
                string propertyPath = MutableJsonDocument.ChangeTracker.PushProperty(path, property.Name);

                if (Changes.TryGetChange(propertyPath, highWaterMark, out MutableJsonChange change))
                {
                    writer.WritePropertyName(property.Name);
                    change.AsJsonElement().WriteTo(writer);
                    continue;
                }

                if (Changes.DescendantChanged(propertyPath, highWaterMark))
                {
                    writer.WritePropertyName(property.Name);
                    WriteElement(propertyPath, highWaterMark, property.Value, writer);
                    continue;
                }

                property.WriteTo(writer);
            }

            writer.WriteEndObject();
        }

        private void WriteArray(string path, int highWaterMark, JsonElement originalElement, Utf8JsonWriter writer)
        {
            if (Changes.TryGetChange(path, highWaterMark, out MutableJsonChange change))
            {
                JsonElement changedElement = change.AsJsonElement();
                changedElement.WriteTo(writer);
                return;
            }

            writer.WriteStartArray();

            int arrayIndex = 0;
            foreach (JsonElement arrayElement in originalElement.EnumerateArray())
            {
                string arrayElementPath = MutableJsonDocument.ChangeTracker.PushIndex(path, arrayIndex++);
                WriteElement(arrayElementPath, highWaterMark, arrayElement, writer);
            }

            writer.WriteEndArray();
        }
    }
}
