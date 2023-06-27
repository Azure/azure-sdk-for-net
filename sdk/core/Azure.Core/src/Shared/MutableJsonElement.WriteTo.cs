// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.Core.Json
{
    internal partial struct MutableJsonElement
    {
        internal void WriteTo(Utf8JsonWriter writer)
        {
            WriteElement(_path, _highWaterMark, _element, writer);
        }

        internal void WriteTo(Stream stream, StandardFormat format)
        {
            // TODO: Test case: This writes for the current element,
            // not the full root document.

            _root.WriteTo(stream, format);
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

                element = change.GetSerializedValue();
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
                WriteElement(propertyPath, highWaterMark, property.GetSerializedValue(), writer);
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

        internal void WritePatch(Utf8JsonWriter writer)
        {
            // This version is not efficient; Proof of concept.

            int hwm = -1;

            // Get the list of paths to properties that have changed.
            // This should consolidate multiple changes to a path down to one.

            // TODO: it would be cool to get these sorted hierarchically to make
            // it easy to write the JSON grouped correctly as objects.
            HashSet<string> changedProperties = _root.Changes.GetChangedProperties(hwm);

            // TODO: deal with descendants and ancestors.
            // This version just writes out merge patch for individual properties.

            // Test case: properties on the same descendant object are updated
            // between updates to different descendant objects, but they group
            // together correctly in the PATCH JSON.

            // Test case: ancestor changes then descendant changes
            // Test case: descendant changes then ancestor changes

            // Test case: array elements change
            // Test case: enum values change
            // Test case: new property is added
            // Test case: property is deleted

            writer.WriteStartObject();

            foreach (string path in changedProperties)
            {
                if (_root.Changes.TryGetChange(path, hwm, out MutableJsonChange change))
                {
                    string[] pathSegments = path.Split(MutableJsonDocument.ChangeTracker.Delimiter);
                    if (pathSegments.Length == 1)
                    {
                        writer.WritePropertyName(pathSegments[0]);
                        change.GetSerializedValue().WriteTo(writer);
                    }
                }
            }

            writer.WriteEndObject();
        }
    }
}
