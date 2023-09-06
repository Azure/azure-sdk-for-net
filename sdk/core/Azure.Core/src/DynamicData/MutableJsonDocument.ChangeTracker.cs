// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable enable

namespace Azure.Core.Json
{
    internal partial class MutableJsonDocument
    {
        internal class ChangeTracker
        {
            private List<MutableJsonChange>? _changes;

            internal const char Delimiter = (char)1;

            internal bool HasChanges => _changes != null && _changes.Count > 0;

            internal bool AncestorChanged(string path, int highWaterMark)
            {
                if (_changes == null)
                {
                    return false;
                }

                bool changed = false;

                // Check for changes to ancestor elements
                while (!changed && path.Length > 0)
                {
                    path = PopProperty(path);
                    changed = TryGetChange(path, highWaterMark, out MutableJsonChange change);
                }

                return changed;
            }

            internal bool DescendantChanged(string path, int highWaterMark)
            {
                if (_changes == null)
                {
                    return false;
                }

                bool changed = false;

                for (int i = _changes!.Count - 1; i > highWaterMark; i--)
                {
                    MutableJsonChange c = _changes[i];
                    if (c.IsDescendant(path))
                    {
                        return true;
                    }
                }

                return changed;
            }

            internal bool TryGetChange(string path, in int lastAppliedChange, out MutableJsonChange change)
            {
                return TryGetChange(path.AsSpan(), lastAppliedChange, out change);
            }

            internal bool TryGetChange(ReadOnlySpan<char> path, in int lastAppliedChange, out MutableJsonChange change)
            {
                if (_changes == null)
                {
                    change = default;
                    return false;
                }

                for (int i = _changes!.Count - 1; i > lastAppliedChange; i--)
                {
                    MutableJsonChange c = _changes[i];
                    if (c.Path.AsSpan().SequenceEqual(path))
                    {
                        change = c;
                        return true;
                    }
                }

                change = default;
                return false;
            }

            internal int AddChange(string path, object? value, MutableJsonChangeKind changeKind = MutableJsonChangeKind.PropertyUpdate, string? addedPropertyName = null)
            {
                if (_changes == null)
                {
                    _changes = new List<MutableJsonChange>();
                }

                int index = _changes.Count;

                _changes.Add(new MutableJsonChange(path, index, value, changeKind, addedPropertyName));

                return index;
            }

            internal IEnumerable<MutableJsonChange> GetAddedProperties(string path, int highWaterMark)
            {
                if (_changes == null)
                {
                    yield break;
                }

                for (int i = _changes!.Count - 1; i > highWaterMark; i--)
                {
                    MutableJsonChange c = _changes[i];
                    if (c.IsDirectDescendant(path) &&
                        c.ChangeKind == MutableJsonChangeKind.PropertyAddition)
                    {
                        yield return c;
                    }
                }
            }

            internal IEnumerable<MutableJsonChange> GetRemovedProperties(string path, int highWaterMark)
            {
                if (_changes == null)
                {
                    yield break;
                }

                for (int i = _changes!.Count - 1; i > highWaterMark; i--)
                {
                    MutableJsonChange c = _changes[i];
                    if (c.IsDirectDescendant(path) &&
                        c.ChangeKind == MutableJsonChangeKind.PropertyRemoval)
                    {
                        yield return c;
                    }
                }
            }

            internal MutableJsonChange? GetFirstMergePatchChange(ReadOnlySpan<char> rootPath, out int maxPathLength)
            {
                // This method gets the first change from the list in sorted order by path
                // It also returns the max path length of changes on the list.

                maxPathLength = -1;

                if (_changes == null)
                {
                    return null;
                }

                MutableJsonChange? min = null;

                for (int i = _changes.Count - 1; i >= 0; i--)
                {
                    MutableJsonChange c = _changes[i];

                    if (c.Path.AsSpan().StartsWith(rootPath) &&
                        (min == null || c.IsLessThan(min.Value.Path.AsSpan())))
                    {
                        min = c;
                    }

                    if (c.Path.Length > maxPathLength)
                    {
                        maxPathLength = c.Path.Length;
                    }
                }

                return min;
            }

            internal MutableJsonChange? GetNextMergePatchChange(ReadOnlySpan<char> rootPath, ReadOnlySpan<char> lastChangePath)
            {
                // This method gets changes from the list in sorted order by path.

                if (_changes == null)
                {
                    return null;
                }

                MutableJsonChange? min = null;

                // This implementation is based on the assumption that iterating through
                // list elements is fast.
                // Iterating backwards means we get the latest change for a given path.
                for (int i = _changes.Count - 1; i >= 0; i--)
                {
                    MutableJsonChange c = _changes[i];

                    if (c.Path.AsSpan().StartsWith(rootPath) &&
                        c.IsGreaterThan(lastChangePath) &&
                        (min == null || c.IsLessThan(min.Value.Path.AsSpan())) &&
                        // Ignore descendant if its ancestor changed
                        !c.IsDescendant(lastChangePath))
                    {
                        min = c;
                    }
                }

                return min;
            }

            internal bool WasRemoved(string path, int highWaterMark)
            {
                if (_changes == null)
                {
                    return false;
                }

                for (int i = _changes!.Count - 1; i > highWaterMark; i--)
                {
                    MutableJsonChange c = _changes[i];
                    if (c.Path == path &&
                        c.ChangeKind == MutableJsonChangeKind.PropertyRemoval)
                    {
                        return true;
                    }
                }

                return false;
            }

            internal static SegmentEnumerator Split(ReadOnlySpan<char> path) => new(path);

            internal ref struct SegmentEnumerator
            {
                private readonly ReadOnlySpan<char> _path;

                private int _start = 0;
                private int _segmentLength;
                private ReadOnlySpan<char> _current;

                public SegmentEnumerator(ReadOnlySpan<char> path)
                {
                    _path = path;
                }

                public readonly SegmentEnumerator GetEnumerator() => this;

                public bool MoveNext()
                {
                    if (_start > _path.Length)
                    {
                        return false;
                    }

                    _segmentLength = _path.Slice(_start).IndexOf(Delimiter);
                    if (_segmentLength == -1)
                    {
                        _segmentLength = _path.Length - _start;
                    }

                    _current = _path.Slice(_start, _segmentLength);
                    _start += _segmentLength + 1;

                    return true;
                }

                public readonly ReadOnlySpan<char> Current => _current;
            }

            internal static string PushIndex(string path, int index)
            {
                return PushProperty(path, $"{index}");
            }

            internal static string PopIndex(string path)
            {
                return PopProperty(path);
            }

            internal static string PushProperty(string path, string value)
            {
                if (path.Length == 0)
                {
                    return value;
                }

                return string.Concat(path, Delimiter, value);
            }

            internal static void PushProperty(Span<char> path, ref int pathLength, ReadOnlySpan<char> value)
            {
                // Validate that path is large enough to write value into
                Debug.Assert(path.Length - pathLength >= value.Length);

                if (pathLength == 0)
                {
                    value.Slice(0, value.Length).CopyTo(path);
                    pathLength = value.Length;
                    return;
                }

                path[pathLength] = Delimiter;
                value.Slice(0, value.Length).CopyTo(path.Slice(pathLength + 1));
                pathLength += value.Length + 1;
            }

            internal static string PopProperty(string path)
            {
                int lastDelimiter = path.LastIndexOf(Delimiter);

                if (lastDelimiter == -1)
                {
                    return string.Empty;
                }

                return path.Substring(0, lastDelimiter);
            }

            internal static void PopProperty(Span<char> path, ref int pathLength)
            {
                int lastDelimiter = path.Slice(0, pathLength).LastIndexOf(Delimiter);
                pathLength = lastDelimiter == -1 ? 0 : lastDelimiter;
            }
        }
    }
}
