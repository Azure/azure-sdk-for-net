// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Json
{
    internal partial struct MutableJsonElement
    {
        internal void WriteTo(Utf8JsonWriter writer)
        {
            WriteElement(_path, _highWaterMark, _element, writer);
        }

        internal void WriteTo(Utf8JsonWriter writer, StandardFormat format)
        {
            // TODO: consolidate format switching with root
            if (format != default && format.Symbol != 'J' && format.Symbol != 'P')
            {
                throw new FormatException($"Unsupported format {format.Symbol}. Supported formats are: 'J' - JSON, 'P' - JSON Merge Patch.");
            }

            switch (format.Symbol)
            {
                case 'P':
                    WritePatch(writer);
                    break;
                case 'J':
                default:
                    WriteTo(writer);
                    break;
            }

            // TODO: Test case: Make sure we write the current element, not the root
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
            if (!_root.Changes.HasChanges)
            {
                return;
            }

            // This version is not efficient; Proof of concept.

            // TODO: rewrite using Span, so much win there
            IEnumerable<string> changed = _root.Changes.GetChangedProperties();

            string jsonPath = string.Empty;

            MutableJsonElement current = _root.RootElement;

            // TODO: this breaks for arrays
            writer.WriteStartObject();

            foreach (string path in changed)
            {
                string currentPath = string.Empty;
                string[] segments = path.Split(MutableJsonDocument.ChangeTracker.Delimiter);
                string name = segments[0];
                currentPath = MutableJsonDocument.ChangeTracker.PushProperty(currentPath, name);

                while (!currentPath.StartsWith(jsonPath))
                {
                    writer.WriteEndObject();

                    // Pop path and current
                    jsonPath = MutableJsonDocument.ChangeTracker.PopProperty(jsonPath);
                    current = GetPropertyFromRoot(jsonPath);
                }

                int i = 0;
                for (; i < segments.Length - 1; i++)
                {
                    if (i != 0)
                    {
                        name = segments[i];
                        currentPath = MutableJsonDocument.ChangeTracker.PushProperty(currentPath, name);
                    }

                    if (!jsonPath.StartsWith(currentPath) && currentPath.StartsWith(jsonPath))
                    {
                        writer.WritePropertyName(name);
                        writer.WriteStartObject();

                        jsonPath = MutableJsonDocument.ChangeTracker.PushProperty(jsonPath, name);
                        current = current.GetProperty(name);
                        continue;
                    }
                }

                name = segments[i];
                currentPath = MutableJsonDocument.ChangeTracker.PushProperty(currentPath, name);
                writer.WritePropertyName(name);
                current.GetProperty(name).WriteTo(writer);
            }

            // Close off the last change we wrote
            string[] finalSegments = jsonPath.Split(MutableJsonDocument.ChangeTracker.Delimiter);
            for (int i = 0; i < finalSegments.Length; i++)
            {
                if (finalSegments[i] != string.Empty)
                {
                    writer.WriteEndObject();
                }
            }

            writer.WriteEndObject();
        }

        private MutableJsonElement GetPropertyFromRoot(string path)
        {
            if (path == string.Empty)
            {
                return _root.RootElement;
            }

            string[] segments = path.Split(MutableJsonDocument.ChangeTracker.Delimiter);
            MutableJsonElement current = _root.RootElement;
            foreach (string segment in segments)
            {
                current = current.GetProperty(segment);
            }
            return current;
        }
    }
}
