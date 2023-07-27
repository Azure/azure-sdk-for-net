// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
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
            IEnumerable<string> changePaths = _root.Changes.GetChangedProperties(out int maxPathLength);

            // patchPath tracks the path we're on in writing out the PATCH JSON.
            // We only iterate forward through the PATCH JSON.
            Span<char> patchPath = stackalloc char[maxPathLength];
            int patchPathLength = 0;

            // patchElement tracks the element we're currently writing to in the PATCH JSON.
            // It tracks with patchPath.
            MutableJsonElement patchElement = _root.RootElement;

            // currentPath tracks the path of the current change we're writing in
            // this iteration of the loop over changes.
            Span<char> currentPath = stackalloc char[maxPathLength];
            int currentPathLength = 0;

            // TODO: this breaks for arrays
            writer.WriteStartObject();

            // foreach unique change on the change list
            foreach (string changePath in changePaths)
            {
                string[] segments = changePath.Split(MutableJsonDocument.ChangeTracker.Delimiter);
                string name = segments[0];

                name.AsSpan().CopyTo(currentPath);
                currentPathLength = name.Length;

                // If the next change starts in a different one then we were writing to in
                // the last iteration, we need to write the end of any open objects.  Do that now.
                bool closedObject = false;
                while (!currentPath.Slice(0, currentPathLength).StartsWith(patchPath.Slice(0, patchPathLength)))
                {
                    writer.WriteEndObject();

                    // Pop path and current
                    MutableJsonDocument.ChangeTracker.PopProperty(patchPath, ref patchPathLength);

                    closedObject = true;
                }

                if (closedObject)
                {
                    patchElement = GetPropertyFromRoot(patchPath, patchPathLength);
                }

                // Move forward on path segments for the change we're writing in this loop iteration
                int i = 0;
                for (; i < segments.Length - 1; i++)
                {
                    if (i != 0)
                    {
                        name = segments[i];
                        MutableJsonDocument.ChangeTracker.PushProperty(currentPath, ref currentPathLength, name.AsSpan());
                    }

                    // if we haven't opened this object yet in the PATCH JSON, open it and set
                    // currentElement to the corresponding element for the object.
                    if (!patchPath.Slice(0, patchPathLength).StartsWith(currentPath.Slice(0, currentPathLength)) &&
                        currentPath.Slice(0, currentPathLength).StartsWith(patchPath.Slice(0, patchPathLength)))
                    {
                        writer.WritePropertyName(name);
                        writer.WriteStartObject();

                        MutableJsonDocument.ChangeTracker.PushProperty(patchPath, ref patchPathLength, name.AsSpan());
                        patchElement = patchElement.GetProperty(name);
                        continue;
                    }
                }

                // At this point, i should point to the last segment, and we should be in the
                // right position to write the change we're working on in this loop iteration
                // into the PATCH JSON. Update the current path and write out the current value.
                Debug.Assert(segments.Length - 1 == i);

                name = segments[i];
                writer.WritePropertyName(name);
                patchElement.GetProperty(name).WriteTo(writer);
            }

            // The above loop will have written out the values of all the elements on the
            // list of changes, but if the last element was multiple levels down the object
            // tree, it may not have written the ends of its ancestor objects.  Do that now.
            int length = patchPathLength;
            int start = 0;
            int end;
            do
            {
                end = patchPath.Slice(start).IndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
                if (end == -1)
                {
                    end = length - start;
                }

                if (end != 0)
                {
                    writer.WriteEndObject();
                }

                start += end + 1;
            } while (start < length);

            // Write the end of the PATCH JSON.
            writer.WriteEndObject();
        }

        private MutableJsonElement GetPropertyFromRoot(ReadOnlySpan<char> path, int pathLength)
        {
            MutableJsonElement current = _root.RootElement;

            if (pathLength == 0)
            {
                return current;
            }

            int length = pathLength;
            int start = 0;
            int end;
            do
            {
                end = path.Slice(start).IndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
                if (end == -1)
                {
                    end = length - start;
                }

                if (end != 0)
                {
                    // TODO: optimize
#if NET5_0_OR_GREATER
                    string segment = new string(path.Slice(start, end));
                    current = current.GetProperty(segment);
#else
                    string segment = new string(path.Slice(start, end).ToArray());
                    current = current.GetProperty(segment);
#endif
                }

                start += end + 1;
            } while (start < length);

            return current;
        }
    }
}
