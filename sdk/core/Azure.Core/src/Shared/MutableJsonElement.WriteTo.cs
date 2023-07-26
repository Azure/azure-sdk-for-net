// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
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

			// TODO: rewrite using Span APIs
            IEnumerable<string> changePaths = _root.Changes.GetChangedProperties();

            // patchPath tracks the path we're on in writing out the PATCH JSON.
            // We only iterate forward through the PATCH JSON.
            string patchPath = string.Empty;

            // patchElement tracks the element we're currently writing to in the PATCH JSON.
            // It tracks with patchPath.
            MutableJsonElement patchElement = _root.RootElement;

            // TODO: this breaks for arrays
            writer.WriteStartObject();

            // foreach unique change on the change list
            foreach (string changePath in changePaths)
            {
                string[] segments = changePath.Split(MutableJsonDocument.ChangeTracker.Delimiter);
                string name = segments[0];

                // currentPath tracks the path of the current change we're writing in
                // this iteration of the loop over changes.
                string currentPath = name;

                // updatePathElement keeps track of whether or not we've changed the element
                // we're writing to for this change.  We'll want to get a new element if
                // we either open a new object or close an object we opened in an earlier
                // iteration of this loop.
                bool updatePathElement = false;

                // If the next change starts in a different one then we were writing to in
                // the last iteration, we need to write the end of any open objects.  Do that now.
                while (!currentPath.StartsWith(patchPath))
                {
                    writer.WriteEndObject();

                    // Pop path and current
                    patchPath = MutableJsonDocument.ChangeTracker.PopProperty(patchPath);
                    updatePathElement = true;
                }

                // Move forward on path segments for the change we're writing in this loop iteration
                int i = 0;
                for (; i < segments.Length - 1; i++)
                {
                    if (i != 0)
                    {
                        name = segments[i];
                        currentPath = MutableJsonDocument.ChangeTracker.PushProperty(currentPath, name);
                    }

                    // if we haven't opened this object yet in the PATCH JSON, open it and set
                    // currentElement to the corresponding element for the object.
                    if (!patchPath.StartsWith(currentPath) && currentPath.StartsWith(patchPath))
                    {
                        writer.WritePropertyName(name);
                        writer.WriteStartObject();

                        updatePathElement = true;

                        patchPath = MutableJsonDocument.ChangeTracker.PushProperty(patchPath, name);
                        continue;
                    }
                }

                // At this point, i should point to the last segment, and we should be in the
                // right position to write the change we're working on in this loop iteration
                // into the PATCH JSON. Update the current path and write out its value.
                Debug.Assert(segments.Length - 1 == i);

                name = segments[i];
                currentPath = MutableJsonDocument.ChangeTracker.PushProperty(currentPath, name);

                if (updatePathElement)
                {
                    patchElement = GetPropertyFromRoot(patchPath);
                }

                writer.WritePropertyName(name);
                patchElement.GetProperty(name).WriteTo(writer);
            }

            // The above loop will have written out the values of all the elements on the
            // list of changes, but if the last element was multiple levels down the object
            // tree, it may not have written the ends of parent object.  Do that now.
            string[] finalSegments = patchPath.Split(MutableJsonDocument.ChangeTracker.Delimiter);
            for (int i = 0; i < finalSegments.Length; i++)
            {
                if (finalSegments[i] != string.Empty)
                {
                    writer.WriteEndObject();
                }
            }

            // Write the end of the PATCH JSON.
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
