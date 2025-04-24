// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text.Json;

#nullable enable

namespace Azure.Core.Json
{
    internal partial struct MutableJsonElement
    {
        internal void WritePatch(Utf8JsonWriter writer)
        {
            if (!Changes.HasChanges)
            {
                return;
            }

            // For an array, if any element has changed, the entire array is replaced.
            if (ValueKind == JsonValueKind.Array)
            {
                WriteTo(writer);
                return;
            }

            ReadOnlySpan<char> elementRootPath = _path.AsSpan();
            MutableJsonChange? change = Changes.GetFirstMergePatchChange(elementRootPath, out int maxPathLength);

            // patchPath tracks the global path we're on in writing out the PATCH JSON.
            // We only iterate forward through the PATCH JSON.
            Span<char> patchPath = maxPathLength <= MaxStackLimit ? stackalloc char[maxPathLength] : new char[maxPathLength];
            int patchPathLength = 0;
            CopyTo(patchPath, ref patchPathLength, elementRootPath);

            // patchElement tracks the element we're currently writing into the PATCH JSON.
            // It should match the element indicated by patchPath.
            MutableJsonElement patchElement = this;

            // currentPath tracks the path of the current change we're writing in
            // a given iteration of the loop over changes.
            Span<char> currentPath = maxPathLength <= MaxStackLimit ? stackalloc char[maxPathLength] : new char[maxPathLength];
            int currentPathLength = 0;
            CopyTo(currentPath, ref currentPathLength, elementRootPath);

            // Write the start of the PATCH JSON
            writer.WriteStartObject();

            // Write the changes in the PATCH
            while (change != null)
            {
                ReadOnlySpan<char> changePath = change.Value.Path.AsSpan();

                // Reset current path for this loop iteration
                currentPathLength = elementRootPath.Length;

                // If the change we're on starts in a different object than we were writing to in
                // the last iteration, we need to write the end of any open objects.
                CloseOpenObjects(writer, changePath, patchPath, ref patchPathLength, ref patchElement);

                // Open any objects that aren't yet open between the first and last path segments
                // for the change we're writing in this loop iteration.
                OpenAncestorObjects(writer, changePath.Slice(elementRootPath.Length), changePath.Length, currentPath, ref currentPathLength, patchPath, ref patchPathLength, ref patchElement);

                // We're at the last segment of the change path and patchElement points to the
                // node that contains the change we want to write into the PATCH JSON. Write it out.
                ReadOnlySpan<char> segment = GetLastSegment(currentPath.Slice(0, currentPathLength));
                writer.WritePropertyName(segment);
                WritePatchValue(writer, change.Value, patchPath.Slice(0, patchPathLength), patchElement);

                // Pop the last segment for our object tracking, because it was a leaf node.
                MutableJsonDocument.ChangeTracker.PopProperty(patchPath, ref patchPathLength);
                patchElement = GetPropertyFromRoot(patchPath.Slice(0, patchPathLength));

                change = Changes.GetNextMergePatchChange(elementRootPath, currentPath.Slice(0, currentPathLength));
            }

            // The above loop will have written out the values of all the elements on the
            // list of changes, but if the last element was multiple levels down the object
            // tree, it may not have written the ends of its ancestor objects.  Do that now.
            CloseFinalObjects(writer, patchPath.Slice(elementRootPath.Length, patchPathLength));

            // Write the end of the PATCH JSON.
            writer.WriteEndObject();
        }

        private static ReadOnlySpan<char> GetFirstSegment(ReadOnlySpan<char> path)
        {
            int idx = path.IndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
            return idx == -1 ? path : path.Slice(0, idx);
        }

        private static ReadOnlySpan<char> GetLastSegment(ReadOnlySpan<char> path)
        {
            int idx = path.LastIndexOf(MutableJsonDocument.ChangeTracker.Delimiter);
            return idx == -1 ? path : path.Slice(idx + 1);
        }

        private static void CopyTo(Span<char> target, ref int targetLength, ReadOnlySpan<char> value)
        {
            Debug.Assert(target.Length >= value.Length);

            value.CopyTo(target);
            targetLength = value.Length;
        }

        private void CloseOpenObjects(Utf8JsonWriter writer, ReadOnlySpan<char> changePath, Span<char> patchPath, ref int patchPathLength, ref MutableJsonElement patchElement)
        {
            bool closedObject = false;
            while (!MutableJsonChange.IsDescendant(patchPath.Slice(0, patchPathLength), changePath))
            {
                writer.WriteEndObject();
                MutableJsonDocument.ChangeTracker.PopProperty(patchPath, ref patchPathLength);

                closedObject = true;
            }

            if (closedObject)
            {
                // patchElement tracks patchPath
                patchElement = GetPropertyFromRoot(patchPath.Slice(0, patchPathLength));
            }
        }

        private void OpenAncestorObjects(Utf8JsonWriter writer, ReadOnlySpan<char> path, in int changePathLength, Span<char> currentPath, ref int currentPathLength, Span<char> patchPath, ref int patchPathLength, ref MutableJsonElement patchElement)
        {
            foreach (ReadOnlySpan<char> segment in MutableJsonDocument.ChangeTracker.Split(path))
            {
                if (segment.Length == 0)
                {
                    continue;
                }

                MutableJsonDocument.ChangeTracker.PushProperty(currentPath, ref currentPathLength, segment);

                // if we haven't opened this object yet in the PATCH JSON, open it and set
                // currentElement to the corresponding element for the object.
                if (!patchPath.Slice(0, patchPathLength).StartsWith(currentPath.Slice(0, currentPathLength)) &&
                    currentPath.Slice(0, currentPathLength).StartsWith(patchPath.Slice(0, patchPathLength)))
                {
                    MutableJsonDocument.ChangeTracker.PushProperty(patchPath, ref patchPathLength, segment);

                    // patchElement tracks patchPatch
                    if (!patchElement.TryGetProperty(segment, out patchElement))
                    {
                        // element was deleted
                        break;
                    }

                    if (patchElement.ValueKind == JsonValueKind.Array)
                    {
                        break;
                    }

                    if (changePathLength == currentPathLength)
                    {
                        // this is the last segment, we'll write it outside the loop
                        break;
                    }

                    writer.WritePropertyName(segment);
                    writer.WriteStartObject();
                }
            }
        }

        private void CloseFinalObjects(Utf8JsonWriter writer, ReadOnlySpan<char> patchPath)
        {
            foreach (ReadOnlySpan<char> segment in MutableJsonDocument.ChangeTracker.Split(patchPath))
            {
                if (segment.Length > 0)
                {
                    writer.WriteEndObject();
                }
            }
        }

        private void WritePatchValue(Utf8JsonWriter writer, MutableJsonChange change, ReadOnlySpan<char> patchPath, MutableJsonElement patchElement)
        {
            switch (change.ChangeKind)
            {
                case MutableJsonChangeKind.PropertyRemoval:
                    writer.WriteNullValue();
                    break;

                case MutableJsonChangeKind.PropertyAddition:
                    patchElement.WriteTo(writer);
                    break;

                case MutableJsonChangeKind.PropertyUpdate:
                    if (patchElement.ValueKind == JsonValueKind.Object)
                    {
                        WriteObjectUpdate(writer, patchPath, patchElement);
                    }
                    else
                    {
                        patchElement.WriteTo(writer);
                    }
                    break;

                default:
                    Debug.Assert(false, $"Unknown change kind: '{change.ChangeKind}'");
                    break;
            }
        }

        private void WriteObjectUpdate(Utf8JsonWriter writer, ReadOnlySpan<char> path, MutableJsonElement patchElement)
        {
            // If an object-type JSON element was updated, check whether
            // any of its properties were incidentally deleted by not
            // being included in the update
            bool opened = false;
            JsonElement original = GetOriginal(path);
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

        private MutableJsonElement GetPropertyFromRoot(ReadOnlySpan<char> path)
        {
            MutableJsonElement current = _root.RootElement;

            foreach (ReadOnlySpan<char> segment in MutableJsonDocument.ChangeTracker.Split(path))
            {
                if (segment.Length > 0)
                {
                    current = current.GetProperty(segment);
                }
            }

            return current;
        }

        private JsonElement GetOriginal(ReadOnlySpan<char> path)
        {
            JsonElement current = _root.RootElement._element;

            foreach (ReadOnlySpan<char> segment in MutableJsonDocument.ChangeTracker.Split(path))
            {
                if (segment.Length > 0)
                {
                    current = current.GetProperty(segment);
                }
            }

            return current;
        }
    }
}
