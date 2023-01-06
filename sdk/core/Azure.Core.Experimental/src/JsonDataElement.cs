// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

            // TODO: (Issue) relying on paths means mutations can be misinterpreted, e.g.
            // what if a property of an object is changed first, and then the object is replaced.
            // the property change will "apply" to the new object.
            // I think we can deal with this by more clever merge logic, but it will be tricky
            var path = _path.Length == 0 ? name : _path + "." + name;

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
            if (_root.TryGetChange(_path, out double value))
            {
                return value;
            }

            return _element.GetDouble();
        }

        internal int GetInt32()
        {
            if (_root.TryGetChange(_path, out int value))
            {
                return value;
            }

            return _element.GetInt32();
        }

        internal string? GetString()
        {
            if (_root.TryGetChange(_path, out string? value))
            {
                return value;
            }

            return _element.GetString();
        }

        internal void Set(double value) => _root.Set(_path, _element, value);

        internal void Set(int value) => _root.Set(_path, _element, value);

        internal void Set(string value) => _root.Set(_path, _element, value);

        internal void Set(object value) => _root.Set(_path, _element, value);
    }
}
