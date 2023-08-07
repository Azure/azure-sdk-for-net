// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Json
{
    internal partial class MutableJsonDocument
    {
        internal class ChangeTracker
        {
            public ChangeTracker(JsonSerializerOptions options)
            {
                _options = options;
            }

            private List<MutableJsonChange>? _changes;
            private JsonSerializerOptions _options;

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
                if (_changes == null)
                {
                    change = default;
                    return false;
                }

                for (int i = _changes!.Count - 1; i > lastAppliedChange; i--)
                {
                    MutableJsonChange c = _changes[i];
                    if (c.Path == path)
                    {
                        change = c;
                        return true;
                    }
                }

                change = default;
                return false;
            }

            internal int AddChange(string path, object? value, MutableJsonChangeKind changeKind = MutableJsonChangeKind.PropertyValue, string? addedPropertyName = null)
            {
                if (_changes == null)
                {
                    _changes = new List<MutableJsonChange>();
                }

                int index = _changes.Count;

                _changes.Add(new MutableJsonChange(path, index, value, _options, changeKind, addedPropertyName));

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

            internal static string PushProperty(string path, ReadOnlySpan<byte> value)
            {
                string propertyName = BinaryData.FromBytes(value.ToArray()).ToString();

                if (path.Length == 0)
                {
                    return propertyName;
                }

                return string.Concat(path, Delimiter, propertyName);
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
        }
    }
}
