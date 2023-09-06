// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

#nullable enable

namespace Azure.Core.Json
{
    internal partial struct MutableJsonElement
    {
        internal void WriteTo(Utf8JsonWriter writer, string format)
        {
            switch (format)
            {
                case "J":
                    WriteTo(writer);
                    break;
                case "P":
                    WritePatch(writer);
                    break;
                default:
                    _root.AssertInvalidFormat(format);
                    break;
            }
        }
        internal void WriteTo(Utf8JsonWriter writer)
        {
            WriteElement(_path, _highWaterMark, _element, writer);
        }

        private void WriteElement(string path, int highWaterMark, JsonElement element, Utf8JsonWriter writer)
        {
            if (Changes.TryGetChange(path, highWaterMark, out MutableJsonChange change))
            {
                if (change.Value is JsonElement changeElement)
                {
                    element = changeElement;
                }
                else
                {
                    WritePrimitiveChange(change, writer);
                    return;
                }

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
                if (!Changes.WasRemoved(propertyPath, highWaterMark))
                {
                    writer.WritePropertyName(property.Name);
                    WriteElement(propertyPath, highWaterMark, property.Value, writer);
                }
            }

            IEnumerable<MutableJsonChange> added = Changes.GetAddedProperties(path, highWaterMark);
            foreach (MutableJsonChange property in added)
            {
                string propertyName = property.AddedPropertyName!;
                string propertyPath = MutableJsonDocument.ChangeTracker.PushProperty(path, propertyName);

                writer.WritePropertyName(propertyName);
                if (property.Value is JsonElement changeElement)
                {
                    WriteElement(propertyPath, highWaterMark, changeElement, writer);
                }
                else
                {
                    WritePrimitiveChange(property, writer);
                }
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
        private void WritePrimitiveChange(MutableJsonChange change, Utf8JsonWriter writer)
        {
            switch (change.Value)
            {
                case bool b:
                    writer.WriteBooleanValue(b);
                    return;
                case byte b:
                    writer.WriteNumberValue(b);
                    return;
                case sbyte sb:
                    writer.WriteNumberValue(sb);
                    return;
                case short sh:
                    writer.WriteNumberValue(sh);
                    return;
                case ushort us:
                    writer.WriteNumberValue(us);
                    return;
                case int i:
                    writer.WriteNumberValue(i);
                    return;
                case uint u:
                    writer.WriteNumberValue(u);
                    return;
                case long l:
                    writer.WriteNumberValue(l);
                    return;
                case ulong ul:
                    writer.WriteNumberValue(ul);
                    return;
                case float f:
                    writer.WriteNumberValue(f);
                    return;
                case double d:
                    writer.WriteNumberValue(d);
                    return;
                case decimal d:
                    writer.WriteNumberValue(d);
                    return;
                case string s:
                    writer.WriteStringValue(s);
                    return;
                case DateTime d:
                    writer.WriteStringValue(d);
                    return;
                case DateTimeOffset d:
                    writer.WriteStringValue(d);
                    return;
                case Guid g:
                    writer.WriteStringValue(g);
                    return;
                case null:
                    writer.WriteNullValue();
                    return;
                default:
                    throw new InvalidOperationException($"Unrecognized change type '{change.Value.GetType()}'.");
            }
        }
    }
}
