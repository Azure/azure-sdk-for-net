// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Json
{
    public partial class MutableJsonDocument
    {
        internal class ChangeTracker
        {
            private List<MutableJsonChange>? _changes;

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
                    var c = _changes[i];
                    if (c.Path.StartsWith(path, StringComparison.Ordinal))
                    {
                        return true;
                    }
                }

                return changed;
            }

            internal bool TryGetChange(ReadOnlySpan<byte> path, out MutableJsonChange change)
            {
                if (_changes == null)
                {
                    change = default;
                    return false;
                }

                // TODO: re-enable optimizations
                // (System.Text.Unicode.Utf8 isn't available to us here)
                var pathStr = Encoding.UTF8.GetString(path.ToArray());

                //Span<char> utf16 = stackalloc char[path.Length];
                //OperationStatus status = System.Text.Unicode.Utf8.ToUtf16(path, utf16, out _, out int written, false, true);
                //if (status != OperationStatus.Done)
                //{ throw new NotImplementedException(); } // TODO: needs to allocate from the pool
                //utf16 = utf16.Slice(0, written);

                for (int i = _changes.Count - 1; i >= 0; i--)
                {
                    var c = _changes[i];
                    if (c.Path == pathStr)
                    //if (change.Property.AsSpan().SequenceEqual(utf16))
                    {
                        change = c;
                        return true;
                    }
                }

                change = default;
                return false;
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
                    var c = _changes[i];
                    if (c.Path == path)
                    {
                        change = c;
                        return true;
                    }
                }

                change = default;
                return false;
            }

            internal int AddChange(string path, object? value, bool replaceJsonElement = false)
            {
                if (_changes == null)
                {
                    _changes = new List<MutableJsonChange>();
                }

                int index = _changes.Count;

                _changes.Add(new MutableJsonChange()
                {
                    Path = path,
                    Value = value,
                    Index = index,
                    ReplacesJsonElement = replaceJsonElement
                });

                return index;
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
                return $"{path}.{value}";
            }

            internal static string PushProperty(string path, ReadOnlySpan<byte> value)
            {
                string propertyName = BinaryData.FromBytes(value.ToArray()).ToString();
                if (path.Length == 0)
                {
                    return propertyName;
                }
                return $"{path}.{propertyName}";
            }

            internal static string PopProperty(string path)
            {
                int lastDelimiter = path.LastIndexOf('.');
                if (lastDelimiter == -1)
                {
                    return string.Empty;
                }
                return path.Substring(0, lastDelimiter);
            }
        }
    }
}
