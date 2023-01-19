// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Dynamic
{
    public partial class JsonData
    {
        internal class ChangeTracker
        {
            private List<JsonDataChange>? _changes;

            internal bool HasChanges => _changes != null && _changes.Count > 0;

            internal bool TryGetChange(ReadOnlySpan<byte> path, out JsonDataChange change)
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

            internal bool TryGetChange(string path, out JsonDataChange change)
            {
                if (_changes == null)
                {
                    change = default;
                    return false;
                }

                for (int i = _changes.Count - 1; i >= 0; i--)
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

            internal void AddChange(string path, object? value, bool replaceJsonElement = false)
            {
                if (_changes == null)
                {
                    _changes = new List<JsonDataChange>();
                }

                _changes.Add(new JsonDataChange() { Path = path, Value = value, ReplacesJsonElement = replaceJsonElement });
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
