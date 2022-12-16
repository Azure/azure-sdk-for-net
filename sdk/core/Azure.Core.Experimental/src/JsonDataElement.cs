// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
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
            // TODO: (Issue) relying on paths means mutations can be misinterpreted, e.g.
            // what if a property of an object is changed first, and then the object is replaced.
            // the property change will "apply" to the new object.
            // I think we can deal with this by more clever merge logic, but it will be tricky
            var path = _path.Length == 0 ? name : _path + "." + name;
            return new JsonDataElement(_root, _element.GetProperty(name), path);
        }

        internal double GetDouble()
        {
            if (_root.TryGetChange(_path, out double value))
                return value;
            return _element.GetDouble();
        }

        internal string? GetString()
        {
            if (_root.TryGetChange(_path, out string? value))
                return value;
            return _element.GetString();
        }

        internal void Set(double value) => _root.Set(_path, value);

        internal void Set(string value) => _root.Set(_path, value);

        internal void Set(object value) => _root.Set(_path, value);
    }
}
