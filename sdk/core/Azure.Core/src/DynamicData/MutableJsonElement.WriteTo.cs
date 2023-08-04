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

            // For an array, if any element has changed, the entire array is replaced.
            if (_root.RootElement.ValueKind == JsonValueKind.Array)
            {
                _root.RootElement.WriteTo(writer);
                return;
            }

            MutableJsonChange? change = _root.Changes.GetFirstMergePatchChange(out int maxPathLength);

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

            // Write the start of the PATCH JSON
            writer.WriteStartObject();
            Debug.WriteLine("** writer: Writing '{' | start PATCH");

            int i = 0;
            while (change != null)
            {
                ReadOnlySpan<char> changePath = change.Value.Path.AsSpan();
                Debug.WriteLine($"** Writing change {i++}: changePath is '{change.Value.Path}'");

                // reset current path for this loop
                currentPathLength = 0;

                // If the change we're on starts in a different object than we were writing to in
                // the last iteration, we need to write the end of any open objects.  Do that now.
                CloseOpenObjects(writer, changePath, patchPath, ref patchPathLength, ref patchElement);

                // Open any objects that aren't yet open between the first and last path segments
                // for the change we're writing in this loop iteration.
                OpenAncestorObjects(writer, changePath, currentPath, ref currentPathLength, patchPath, ref patchPathLength, ref patchElement);

                // Now we're at the last segment of the change path and patchElement points to
                // the node that contains the change we want to write into the PATCH JSON.
                ReadOnlySpan<char> segment = GetLastSegment(currentPath.Slice(0, currentPathLength));

                Debug.WriteLine($"** Writing changed element:");
                Debug.WriteLine($"**   currentPath is '{GetString(currentPath, 0, currentPathLength)}'");
                Debug.WriteLine($"**   patchPath is '{GetString(patchPath, 0, patchPathLength)}'");
                if (change.Value.ChangeKind != MutableJsonChangeKind.PropertyRemoval)
                {
                    Debug.WriteLine($"**   patchElement is '{patchElement}'");
                }
                Debug.WriteLine($"**   segment is '{GetString(segment, 0, segment.Length)}'");

                writer.WritePropertyName(segment);
                Debug.WriteLine($"** writer: Writing '\"{GetString(segment, 0, segment.Length)}\"' | foreach change");

                switch (change.Value.ChangeKind)
                {
                    case MutableJsonChangeKind.PropertyRemoval:
                        writer.WriteNullValue();
                        Debug.WriteLine("** writer: Writing 'null' | foreach change");
                        break;

                    case MutableJsonChangeKind.PropertyAddition:
                        patchElement.WriteTo(writer);
                        Debug.WriteLine($"** writer: Writing '{patchElement}' | foreach change");
                        break;

                    case MutableJsonChangeKind.PropertyUpdate:
                        if (patchElement.ValueKind == JsonValueKind.Object)
                        {
                            WriteObjectUpdate(writer, patchPath, patchPathLength, patchElement);
                        }
                        else
                        {
                            patchElement.WriteTo(writer);
                        }
                        break;

                    default:
                        Debug.Assert(false, $"Unknown change kind: '{change.Value.ChangeKind}'");
                        break;
                }

                change = _root.Changes.GetNextMergePatchChange(currentPath.Slice(0, currentPathLength));
            }

            // The above loop will have written out the values of all the elements on the
            // list of changes, but if the last element was multiple levels down the object
            // tree, it may not have written the ends of its ancestor objects.  Do that now.
            Debug.WriteLine($"** patchPath is '{GetString(patchPath, 0, patchPathLength)}'");
            CloseFinalObjects(writer, patchPath, patchPathLength);

            // Write the end of the PATCH JSON.
            writer.WriteEndObject();
            Debug.WriteLine("** writer: Writing '}' | end PATCH");
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

        private void CloseOpenObjects(Utf8JsonWriter writer, ReadOnlySpan<char> changePath, Span<char> patchPath, ref int patchPathLength, ref MutableJsonElement patchElement)
        {
            Debug.WriteLine($"** Closing open objects:");
            Debug.WriteLine($"**   firstSegment is '{GetString(changePath, 0, changePath.Length)}'");
            Debug.WriteLine($"**   patchPath is '{GetString(patchPath, 0, patchPathLength)}'");
            Debug.WriteLine($"**   patchElement is '{patchElement}'");

            // Pop the last segment because it was a leaf node
            MutableJsonDocument.ChangeTracker.PopProperty(patchPath, ref patchPathLength);
            Debug.WriteLine($"**   UPDATING patchPatch: patchPath is '{GetString(patchPath, 0, patchPathLength)}'");

            while (!MutableJsonChange.IsDescendant(patchPath.Slice(0, patchPathLength), changePath))
            {
                writer.WriteEndObject();
                Debug.WriteLine("** writer: Writing '}' | CloseOpenObjects");

                MutableJsonDocument.ChangeTracker.PopProperty(patchPath, ref patchPathLength);
                Debug.WriteLine($"**   UPDATING patchPatch: patchPath is '{GetString(patchPath, 0, patchPathLength)}'");
            }

            // patchElement tracks patchPath
            patchElement = GetPropertyFromRoot(patchPath, patchPathLength);
            Debug.WriteLine($"**   UPDATING patchElement: patchElement is '{patchElement}'");
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
                end = path.Slice(0, pathLength).Slice(start).IndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
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
            Debug.WriteLine($"** Closing final objects:");
            Debug.WriteLine($"**   patchPath is '{GetString(patchPath, 0, patchPathLength)}'");

            int length = patchPathLength;
            int start = 0;
            int end;
            do
            {
                end = patchPath.Slice(0, patchPathLength).Slice(start).IndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
                if (end == -1)
                {
                    end = length - start;
                }

                // don't close a leaf node
                if (end != 0 && start + end != length)
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
            Debug.WriteLine($"** Opening ancestor objects:");
            Debug.WriteLine($"**   currentPath is '{GetString(currentPath, 0, currentPathLength)}'");
            Debug.WriteLine($"**   patchPath is '{GetString(patchPath, 0, patchPathLength)}'");
            Debug.WriteLine($"**   patchElement is '{patchElement}'");

            int length = path.Length;
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
                    MutableJsonDocument.ChangeTracker.PushProperty(currentPath, ref currentPathLength, path.Slice(start), end);
                    Debug.WriteLine($"**   UPDATING currentPath: currentPath is '{GetString(currentPath, 0, currentPathLength)}'");

                    // if we haven't opened this object yet in the PATCH JSON, open it and set
                    // currentElement to the corresponding element for the object.
                    if (!patchPath.Slice(0, patchPathLength).StartsWith(currentPath.Slice(0, currentPathLength)) &&
                        currentPath.Slice(0, currentPathLength).StartsWith(patchPath.Slice(0, patchPathLength)))
                    {
                        MutableJsonDocument.ChangeTracker.PushProperty(patchPath, ref patchPathLength, path.Slice(start), end);
                        Debug.WriteLine($"**   UPDATING patchPatch: patchPath is '{GetString(patchPath, 0, patchPathLength)}'");

                        // patchElement tracks patchPatch
                        if (!patchElement.TryGetProperty(path.Slice(start, end), out patchElement))
                        {
                            // element was deleted
                            break;
                        }

                        if (patchElement.ValueKind == JsonValueKind.Array)
                        {
                            break;
                        }

                        if (start + end == length)
                        {
                            // this is the last segment, we'll write it outside the loop
                            break;
                        }

                        writer.WritePropertyName(path.Slice(start, end));
                        Debug.WriteLine($"** writer: Writing '\"{GetString(path, start, end)}\"' | OpenAncestorObjects");

                        writer.WriteStartObject();
                        Debug.WriteLine("** writer: Writing '{' | OpenAncestorObjects");
                    }
                }

                start += end + 1;
            }
            while (start < length);
        }

        private void WriteObjectUpdate(Utf8JsonWriter writer, ReadOnlySpan<char> path, int pathLength, MutableJsonElement patchElement)
        {
            // If an object has been updated, we need to check whether
            // any of its properties were incidentally deleted by not
            // being included in the update
            bool opened = false;
            JsonElement original = GetOriginalFromRoot(path, pathLength);
            foreach (JsonProperty property in original.EnumerateObject())
            {
                if (!patchElement.TryGetProperty(property.Name, out _))
                {
                    if (!opened)
                    {
                        writer.WriteStartObject();
                        opened = true;
                    }

                    writer.WritePropertyName(property.Name);
                    writer.WriteNullValue();
                }
            }

            if (opened)
            {
                // finish writing out the update values
                foreach ((string Name, MutableJsonElement Value) property in patchElement.EnumerateObject())
                {
                    writer.WritePropertyName(property.Name);
                    property.Value.WriteTo(writer);
                }

                writer.WriteEndObject();
            }
            else
            {
                patchElement.WriteTo(writer);
            }
        }

        private JsonElement GetOriginalFromRoot(ReadOnlySpan<char> path, int pathLength)
        {
            JsonElement current = _root.RootElement._element;

            if (pathLength == 0)
            {
                return current;
            }

            int length = pathLength;
            int start = 0;
            int end;
            do
            {
                end = path.Slice(0, pathLength).Slice(start).IndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
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
    }
}
