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

            MutableJsonChange? change = _root.Changes.GetNextMergePatchChange(null, out int maxPathLength);

            // patchPath tracks the global path we're on in writing out the PATCH JSON.
            // We only iterate forward through the PATCH JSON.
            Span<char> patchPath = stackalloc char[maxPathLength];
            int patchPathLength = 0;

            // patchElement tracks the element we're currently writing into the PATCH JSON.
            // It should match the element indicated by patchPath.
            MutableJsonElement patchElement = _root.RootElement;

            // currentPath tracks the path of the current change we're writing in
            // a given iteration of the loop over changes.
            Span<char> currentPath = stackalloc char[maxPathLength];
            int currentPathLength = 0;

            // TODO: this breaks for arrays

            if (_root.RootElement.ValueKind != JsonValueKind.Array)
            {
                // Write the start of the PATCH JSON
                writer.WriteStartObject();
                Debug.WriteLine("** writer: Writing '{' | start PATCH");
            }

            while (change != null)
            {
                ReadOnlySpan<char> changePath = change.Value.Path.AsSpan();

                CopyTo(currentPath, ref currentPathLength, GetFirstSegment(changePath));

                // If the change we're on starts in a different object than we were writing to in
                // the last iteration, we need to write the end of any open objects.  Do that now.
                CloseOpenObjects(writer, currentPath, currentPathLength, patchPath, ref patchPathLength, ref patchElement);

                // Open any objects that aren't yet open between the first and last path segments
                // for the change we're writing in this loop iteration.
                OpenAncestorObjects(writer, changePath, currentPath, ref currentPathLength, patchPath, ref patchPathLength, ref patchElement);

                // Now we're at the last segment of the change path and patchElement points to
                // the node that contains the change we want to write into the PATCH JSON.
                ReadOnlySpan<char> segment = GetLastSegment(changePath);

                // TODO: Handle root element is array separately - we don't need to
                // do any of this in that case.

                // If we got an array, we're going to replace it entirely.  We won't
                // process any further changes to anything below the root element of
                // the array.
                // If the current change path is on an array element item, we need to merge this
                // with other array changes. Create a new change to represent the
                // whole array.
                if (patchElement.ValueKind == JsonValueKind.Array &&
                    !patchPath.Slice(0, patchPathLength).SequenceEqual(currentPath.Slice(0, currentPathLength)))
                {
                    Debug.Assert(patchElement.ValueKind == JsonValueKind.Array);
                    Debug.Assert(change.Value.ChangeKind == MutableJsonChangeKind.PropertyValue);

                    change = new MutableJsonChange(GetString(patchPath, 0, patchPathLength), -1, null, _root.SerializerOptions, change.Value.ChangeKind, null);
                }

                Debug.WriteLine($"** currentPath is '{GetString(currentPath, 0, currentPathLength)}'");
                Debug.WriteLine($"** patchPath is '{GetString(patchPath, 0, patchPathLength)}'");
                Debug.WriteLine($"** patchElement is '{patchElement}'");
                Debug.WriteLine($"** segment is '{GetString(segment, 0, segment.Length)}'");

                if (patchElement.ValueKind == JsonValueKind.Array)
                {
                    // For an array, if any element has changed, the entire array is replaced.
                    writer.WritePropertyName(segment);
                    Debug.WriteLine($"** writer: Writing '{GetString(segment, 0, segment.Length)}' | foreach change");

                    patchElement.WriteTo(writer);
                    Debug.WriteLine($"** writer: Writing '{patchElement}' | foreach change");
                }
                else
                {
                    writer.WritePropertyName(segment);
                    if (change.Value.ChangeKind == MutableJsonChangeKind.PropertyRemoval)
                    {
                        writer.WriteNullValue();
                        Debug.WriteLine("** writer: Writing 'null' | foreach change");
                    }
                    else
                    {
                        patchElement.GetProperty(segment).WriteTo(writer);
                        Debug.WriteLine($"** writer: Writing '{patchElement}' | foreach change");
                    }
                }

                change = _root.Changes.GetNextMergePatchChange(change, out _);
            }

            // The above loop will have written out the values of all the elements on the
            // list of changes, but if the last element was multiple levels down the object
            // tree, it may not have written the ends of its ancestor objects.  Do that now.
            Debug.WriteLine($"** patchPath is '{GetString(patchPath, 0, patchPathLength)}'");
            CloseFinalObjects(writer, patchPath, patchPathLength);

            if (_root.RootElement.ValueKind != JsonValueKind.Array)
            {
                // Write the end of the PATCH JSON.
                writer.WriteEndObject();
                Debug.WriteLine("** writer: Writing '}' | end PATCH");
            }
        }
        private ReadOnlySpan<char> GetFirstSegment(ReadOnlySpan<char> path)
        {
            int idx = path.IndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
            return idx == -1 ? path : path.Slice(0, idx);
        }

        private ReadOnlySpan<char> GetLastSegment(ReadOnlySpan<char> path)
        {
            int idx = path.LastIndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
            return idx == -1 ? path : path.Slice(idx + 1);
        }

        private void CopyTo(Span<char> target, ref int targetLength, ReadOnlySpan<char> value)
        {
            Debug.Assert(target.Length >= value.Length);

            value.CopyTo(target);
            targetLength = value.Length;
        }

        private void CloseOpenObjects(Utf8JsonWriter writer, ReadOnlySpan<char> currentPath, int currentPathLength, Span<char> patchPath, ref int patchPathLength, ref MutableJsonElement patchElement)
        {
            bool closedObject = false;
            while (!currentPath.Slice(0, currentPathLength).StartsWith(patchPath.Slice(0, patchPathLength)))
            {
                writer.WriteEndObject();
                Debug.WriteLine("** writer: Writing '}' | CloseOpenObjects");

                MutableJsonDocument.ChangeTracker.PopProperty(patchPath, ref patchPathLength);

                closedObject = true;
            }

            if (closedObject)
            {
                patchElement = GetPropertyFromRoot(patchPath, patchPathLength);
            }
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
                    current = current.GetProperty(path.Slice(start, end));
                }

                start += end + 1;
            }
            while (start < length);

            return current;
        }

        private void CloseFinalObjects(Utf8JsonWriter writer, ReadOnlySpan<char> patchPath, int patchPathLength)
        {
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
                    Debug.WriteLine("** writer: Writing '}' | CloseFinalObjects");
                }

                start += end + 1;
            }
            while (start < length);
        }

        private void OpenAncestorObjects(Utf8JsonWriter writer, ReadOnlySpan<char> path, Span<char> currentPath, ref int currentPathLength, Span<char> patchPath, ref int patchPathLength, ref MutableJsonElement patchElement)
        {
            int length = path.Length;
            int start = 0;
            int end;

            do
            {
                end = path.Slice(start).IndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
                if (end == -1)
                {
                    // skip the last segment
                    return;
                }

                // currentPath already holds the first property, so don't push it if we're
                // still on the first one.
                if (end != 0 && start != 0)
                {
                    MutableJsonDocument.ChangeTracker.PushProperty(currentPath, ref currentPathLength, path.Slice(start), end);
                }

                // if we haven't opened this object yet in the PATCH JSON, open it and set
                // currentElement to the corresponding element for the object.
                if (!patchPath.Slice(0, patchPathLength).StartsWith(currentPath.Slice(0, currentPathLength)) &&
                    currentPath.Slice(0, currentPathLength).StartsWith(patchPath.Slice(0, patchPathLength)))
                {
                    patchElement = patchElement.GetProperty(path.Slice(start, end));

                    // Stop at an array -- the entire thing will be replaced.
                    if (patchElement.ValueKind == JsonValueKind.Array)
                    {
                        break;
                    }

                    MutableJsonDocument.ChangeTracker.PushProperty(patchPath, ref patchPathLength, path.Slice(start), end);

                    writer.WritePropertyName(path.Slice(start, end));
                    Debug.WriteLine($"** writer: Writing '\"{GetString(path, start, end)}\"' | OpenAncestorObjects");

                    writer.WriteStartObject();
                    Debug.WriteLine("** writer: Writing '{' | OpenAncestorObjects");
                }

                start += end + 1;
            }
            while (start < length);
        }
    }
}
