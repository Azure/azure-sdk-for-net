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
            private List<IJsonDataChange>? _changes;
            private List<IJsonDataChange>? _removals;

            internal bool HasChanges => _changes != null && _changes.Count > 0;

            internal bool TryGetChange<T>(string path, out T? value)
            {
                if (_changes == null)
                {
                    value = default;
                    return false;
                }

                for (int i = _changes.Count - 1; i >= 0; i--)
                {
                    var change = _changes[i];
                    if (change.Property == path)
                    {
                        // TODO: does this do boxing?
                        value = ((JsonDataChange<T>)change).Value;
                        return true;
                    }
                }

                value = default;
                return false;
            }

            internal bool TryGetChange<T>(ReadOnlySpan<byte> path, out T? value)
            {
                if (_changes == null)
                {
                    value = default;
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
                    var change = _changes[i];
                    if (change.Property == pathStr)
                    //if (change.Property.AsSpan().SequenceEqual(utf16))
                    {
                        // TODO: does this do boxing?
                        value = ((JsonDataChange<T>)change).Value;
                        return true;
                    }
                }

                value = default;
                return false;
            }

            internal void AddChange<T>(string path, JsonElement element, T? value)
            {
                // Assignment of an object or an array is special, because it potentially
                // changes the structure of the JSON.
                // TODO: Handle the case where a primitive leaf node is assigned
                // an object or an array ... this changes the structure as well.

                // We handle this here as a removal and a change.  The presence of a removal
                // indicates that the structure of the JSON has changed and additional care
                // must be taken for any child elements of the removed element.
                if (element.ValueKind == JsonValueKind.Object ||
                    element.ValueKind == JsonValueKind.Array)
                {
                    if (_removals == null)
                    {
                        _removals = new List<IJsonDataChange>();
                    }

                    _removals.Add(new JsonDataChange<T>() { Property = path, Value = default });
                }

                if (_changes == null)
                {
                    _changes = new List<IJsonDataChange>();
                }

                _changes.Add(new JsonDataChange<T>() { Property = path, Value = value });
            }
        }
    }
}
