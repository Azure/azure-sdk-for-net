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

            // name is the property name of the current segment we're working with.
            Span<char> name = stackalloc char[maxPathLength];
            int nameLength = 0;

            // TODO: this breaks for arrays
            writer.WriteStartObject();

            // foreach unique change on the change list
            foreach (string changePath in changePaths)
            {
                ReadOnlySpan<char> segment = GetFirstSegment(changePath.AsSpan());
                WriteValue(name, ref nameLength, segment, segment.Length);
                WriteValue(currentPath, ref currentPathLength, name, nameLength);

                CloseOpenObjects(writer, currentPath, currentPathLength, patchPath, ref patchPathLength, ref patchElement);

                // Move forward on path segments for the change we're writing in this loop iteration
                int l = changePath.Length;
                int s = 0;
                int e = changePath.AsSpan().Slice(s).IndexOf(MutableJsonDocument.ChangeTracker.Delimiter);

                do
                {
                    // set name to next segment
                    e = changePath.AsSpan().Slice(s).IndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
                    if (e == -1)
                    {
                        e = l - s;
                        // skip the last segment
                        break;
                    }

                    // currentPath already holds the first property, so don't push it if we're
                    // still on the first one.
                    if (e != 0 && s != 0)
                    {
                        WriteValue(name, ref nameLength, changePath.AsSpan().Slice(s), e);
                        MutableJsonDocument.ChangeTracker.PushProperty(currentPath, ref currentPathLength, name, nameLength);
                    }

                    // if we haven't opened this object yet in the PATCH JSON, open it and set
                    // currentElement to the corresponding element for the object.
                    if (!patchPath.Slice(0, patchPathLength).StartsWith(currentPath.Slice(0, currentPathLength)) &&
                        currentPath.Slice(0, currentPathLength).StartsWith(patchPath.Slice(0, patchPathLength)))
                    {
                        writer.WritePropertyName(name.Slice(0, nameLength));
                        writer.WriteStartObject();

                        MutableJsonDocument.ChangeTracker.PushProperty(patchPath, ref patchPathLength, name, nameLength);
                        patchElement = patchElement.GetProperty(GetString(name, 0, nameLength));
                    }

                    s += e + 1;
                }
                while (s < l);

                // At this point, we're at the last segment and are in right position to write
                // the change we're working on in this loop iteration into the PATCH JSON.
                // Update name to the last segment and write out the current value.
                WriteValue(name, ref nameLength, changePath.AsSpan().Slice(s), e);

                writer.WritePropertyName(name.Slice(0, nameLength));
                patchElement.GetProperty(GetString(name, 0, nameLength)).WriteTo(writer);
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
                    current = current.GetProperty(GetString(path, start, end));
                }

                start += end + 1;
            } while (start < length);

            return current;
        }

        private ReadOnlySpan<char> GetFirstSegment(ReadOnlySpan<char> path)
        {
            int idx = path.IndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
            if (idx == -1)
            {
                idx = path.Length;
            }
            return path.Slice(0, idx);
        }

        private void WriteValue(Span<char> target, ref int targetLength, ReadOnlySpan<char> value, int valueLength)
        {
            Debug.Assert(target.Length >= valueLength);

            value.Slice(0, valueLength).CopyTo(target);
            targetLength = valueLength;
        }

        private void CloseOpenObjects(Utf8JsonWriter writer, ReadOnlySpan<char> currentPath, int currentPathLength, Span<char> patchPath, ref int patchPathLength, ref MutableJsonElement patchElement)
        {
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
        }

        private void OpenAncestorObjects(Utf8JsonWriter writer, Span<char> currentPath, ref int currentPathLength, Span<char> patchPath, ref int patchPathLength, ref MutableJsonElement patchElement)
        {
        }

        // TODO: optimize - bypass string use entirely.  Remove this method.
        private string GetString(ReadOnlySpan<char> value, int start, int end)
        {
#if NET5_0_OR_GREATER
            return new string(value.Slice(start, end));
#else
            return new string(value.Slice(start, end).ToArray());
#endif
        }
    }
}
