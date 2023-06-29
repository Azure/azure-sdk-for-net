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

        //internal void WritePatch(Utf8JsonWriter writer)
        //{
        //    // This version is not efficient; Proof of concept.

        //    _root.Changes.GetChangedProperties();

        //    WritePatchElement(root, writer);

        //    // Test case: properties on the same descendant object are updated
        //    // between updates to different descendant objects, but they group
        //    // together correctly in the PATCH JSON.

        //    // Test case: ancestor changes then descendant changes
        //    // Test case: descendant changes then ancestor changes

        //    // Test case: array elements change
        //    // Test case: enum values change
        //    // Test case: new property is added
        //    // Test case: property is deleted

        //    // TODO: this will break on arrays
        //}

        //private void WritePatchElement(MutableJsonPatchNode node, Utf8JsonWriter writer)
        //{
        //    switch (node.Kind)
        //    {
        //        case MutableJsonPatchNodeKind.Value:
        //            node.Change!.Value.GetSerializedValue().WriteTo(writer);
        //            break;
        //        case MutableJsonPatchNodeKind.Object:
        //            WritePatchObject(node, writer);
        //            break;
        //        case MutableJsonPatchNodeKind.Array:
        //            WritePatchArray(node, writer);
        //            break;
        //        default:
        //            throw new InvalidOperationException("Unrecognized PATCH kind.");
        //    }
        //}

        //private void WritePatchObject(MutableJsonPatchNode node, Utf8JsonWriter writer)
        //{
        //    writer.WriteStartObject();
        //    foreach (MutableJsonPatchNode child in node.Children!)
        //    {
        //        writer.WritePropertyName(child.Name);
        //        WritePatchElement(child, writer);
        //    }
        //    writer.WriteEndObject();
        //}

        //private void WritePatchArray(MutableJsonPatchNode node, Utf8JsonWriter writer)
        //{
        //    writer.WriteStartArray();
        //    foreach (MutableJsonPatchNode child in node.Children!)
        //    {
        //        WritePatchElement(child, writer);
        //    }
        //    writer.WriteEndArray();
        //}
    }
}
