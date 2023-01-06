// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// A mutable representation of a JSON element.
    /// </summary>
    public struct JsonDataElement
    {
        private readonly JsonData _root;
        private readonly JsonElement _element;
        private readonly string _path;

        private readonly JsonData.ChangeTracker Changes => _root.Changes;

        // TODO: we will need to look up whether a parent has changed.
#pragma warning disable CA1822 // Mark members as static
        private bool IsValid => true;
#pragma warning restore CA1822 // Mark members as static

        internal JsonDataElement(JsonData root, JsonElement element, string path)
        {
            _element = element;
            _root = root;
            _path = path;
        }

        internal JsonDataElement GetProperty(string name)
        {
            if (_element.ValueKind != JsonValueKind.Object)
            {
                throw new InvalidOperationException($"Expected an 'Object' type but was {_element.ValueKind}.");
            }

            // Note: if we are in this element, we can assume we've already
            // addressed those changes.

            // TODO: (Issue) relying on paths means mutations can be misinterpreted, e.g.
            // what if a property of an object is changed first, and then the object is replaced.
            // the property change will "apply" to the new object.
            // I think we can deal with this by more clever merge logic, but it will be tricky
            var path = _path.Length == 0 ? name : _path + "." + name;

            // TODO: Check for changes?
            //if (Changes.Tra)

            //// If the object referred to has been changed, we need to refer to
            //// the new object. (See CanAssignObject test case.)
            ////
            //// This case is different, because it changes the structure of the JSON --
            //// the JsonDocument and JsonElements we're holding at the root no longer
            //// reflect the structure of the end-state of the JsonData.  We may want to
            //// set a dirty-bit at the root level to indicate that to the serialization
            //// methods.
            //if ((_element.ValueKind == JsonValueKind.Object) &&
            //    _root.TryGetChange(path, out object? value))
            //{
            //    // Need to make new node to use for this element
            //    // TODO: using this constructor for convenience - rewrite for clarity
            //    var jd = new JsonData(value);
            //    return new JsonDataElement(_root, jd.RootElement._element, path);

            //    // TODO: if we keep this approach, we'd want to cache the serialized JsonElement
            //    // so we don't re-serialize it each time.  Would we store it back on the change record?
            //    // Or would it be better to start building a shadow JSON tree if we have
            //    // to store these things anyway?
            //}

            return new JsonDataElement(_root, _element.GetProperty(name), path);
        }

        internal JsonDataElement GetIndexElement(int index)
        {
            if (_element.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Expected an 'Array' type but was {_element.ValueKind}.");
            }

            var pathIndex = $"[{index}]";
            var path = _path.Length == 0 ? pathIndex : _path + pathIndex;

            return new JsonDataElement(_root, _element[index], path);
        }

        internal double GetDouble()
        {
            if (Changes.TryGetChange(_path, out JsonDataChange change))
            {
                if (change.Value == null)
                {
                    throw new InvalidCastException("Property has been removed");
                }

                return (double)change.Value;
            }

            return _element.GetDouble();
        }

        internal int GetInt32()
        {
            if (Changes.TryGetChange(_path, out JsonDataChange change))
            {
                if (change.Value == null)
                {
                    throw new InvalidCastException("Property has been removed");
                }

                return (int)change.Value;
            }

            return _element.GetInt32();
        }

        internal string? GetString()
        {
            if (Changes.TryGetChange(_path, out JsonDataChange change))
            {
                return (string?)change.Value;
            }

            return _element.GetString();
        }

        internal void SetProperty(string name, object value)
        {
            if (_element.ValueKind != JsonValueKind.Object)
            {
                throw new InvalidOperationException($"Expected an 'Object' type but was {_element.ValueKind}.");
            }

            var path = _path.Length == 0 ? name : _path + "." + name;

            // Per copying Dictionary semantics, if the property already exists, just replace the value.
            // If the property already exists, just set it.

            if (_element.TryGetProperty(name, out _))
            {
                Changes.AddChange(path, value);
            }

            // If it's not already there, we'll add a different kind of change.
            // We are adding a property to this object.  The change reflects an update
            // to the object's JsonElement.  Get the new JsonElement.
            Dictionary<string, object> dict = JsonSerializer.Deserialize<Dictionary<string, object>>(_element.ToString());
            dict[name] = value;

            var bytes = JsonSerializer.SerializeToUtf8Bytes(dict);
            var newElement = JsonDocument.Parse(bytes).RootElement;

            Changes.AddChange(_path, newElement, true);
        }

        internal void Set(double value) => Changes.AddChange(_path, value);

        internal void Set(int value) => Changes.AddChange(_path, value);

        internal void Set(string value) => Changes.AddChange(_path, value);

        internal void Set(object value) => Changes.AddChange(_path, value);
    }
}
