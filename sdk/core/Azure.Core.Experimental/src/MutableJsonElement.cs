// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// A mutable representation of a JSON element.
    /// </summary>
    public partial struct MutableJsonElement
    {
        private readonly MutableJsonDocument _root;
        private readonly JsonElement _element;
        private readonly string _path;
        private readonly int _highWaterMark;

        private readonly MutableJsonDocument.ChangeTracker Changes => _root.Changes;

        internal MutableJsonElement(MutableJsonDocument root, JsonElement element, string path, int highWaterMark = -1)
        {
            _element = element;
            _root = root;
            _path = path;
            _highWaterMark = highWaterMark;
        }

        /// <summary>
        /// Gets the MutableJsonElement for the value of the property with the specified name.
        /// </summary>
        public MutableJsonElement GetProperty(string name)
        {
            if (!TryGetProperty(name, out MutableJsonElement value))
            {
                throw new InvalidOperationException($"{_path} does not containe property called {name}");
            }

            return value;
        }

        /// <summary>
        /// Looks for a property named propertyName in the current object, returning a value that indicates whether or not such a property exists. When the property exists, its value is assigned to the value argument.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetProperty(string name, out MutableJsonElement value)
        {
            EnsureValid();

            EnsureObject();

            bool hasProperty = _element.TryGetProperty(name, out JsonElement element);
            if (!hasProperty)
            {
                value = default;
                return false;
            }

            var path = MutableJsonDocument.ChangeTracker.PushProperty(_path, name);
            if (Changes.TryGetChange(path, _highWaterMark, out MutableJsonChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    value = new MutableJsonElement(_root, change.AsJsonElement(), path, change.Index);
                    return true;
                }
            }

            value = new MutableJsonElement(_root, element, path, _highWaterMark);
            return true;
        }

        internal MutableJsonElement GetIndexElement(int index)
        {
            EnsureValid();

            EnsureArray();

            var path = MutableJsonDocument.ChangeTracker.PushIndex(_path, index);

            if (Changes.TryGetChange(path, _highWaterMark, out MutableJsonChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    return new MutableJsonElement(_root, change.AsJsonElement(), path, change.Index);
                }
            }

            return new MutableJsonElement(_root, _element[index], path, _highWaterMark);
        }

        /// <summary>
        /// Gets the current JSON number as a double.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public double GetDouble()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                switch (change.Value)
                {
                    case double d:
                        return d;
                    case JsonElement element:
                        return element.GetDouble();
                    default:
                        throw new InvalidOperationException($"Element at {_path} is not a double.");
                }
            }

            return _element.GetDouble();
        }

        /// <summary>
        /// Gets the current JSON number as an int.
        /// </summary>
        /// <returns></returns>
        public int GetInt32()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                switch (change.Value)
                {
                    case int i:
                        return i;
                    case JsonElement element:
                        return element.GetInt32();
                    default:
                        throw new InvalidOperationException($"Element at {_path} is not an Int32.");
                }
            }

            return _element.GetInt32();
        }

        /// <summary>
        /// Gets the current JSON number as a long.
        /// </summary>
        /// <returns></returns>
        public long GetInt64() => throw new NotImplementedException();

        /// <summary>
        /// Gets the current JSON number as a float.
        /// </summary>
        /// <returns></returns>
        public float GetFloat() => throw new NotImplementedException();

        /// <summary>
        /// Gets the value of the element as a string.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string? GetString()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                switch (change.Value)
                {
                    case string s:
                        return s;
                    case JsonElement element:
                        return element.GetString();
                    default:
                        if (change.Value == null)
                        {
                            return null;
                        }
                        throw new InvalidOperationException($"Element at {_path} is not a string.");
                }
            }

            return _element.GetString();
        }

        /// <summary>
        /// Gets the value of the element as a bool.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool GetBoolean()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                switch (change.Value)
                {
                    case bool b:
                        return b;
                    case JsonElement element:
                        return element.GetBoolean();
                    default:
                        throw new InvalidOperationException($"Element at {_path} is not a bool.");
                }
            }

            return _element.GetBoolean();
        }

        /// <summary>
        /// Set the value of the property with the specified name to the passed-in value.  If the property is not already present, it will be created.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetProperty(string name, object value)
        {
            EnsureValid();

            EnsureObject();

            // Per copying Dictionary semantics, if the property already exists, just replace the value.
            // If the property already exists, just set it.

            var path = MutableJsonDocument.ChangeTracker.PushProperty(_path, name);

            if (_element.TryGetProperty(name, out _))
            {
                Changes.AddChange(path, value, true);
                return;
            }

            // If it's not already there, we'll add a change to the JsonElement instead.
            Dictionary<string, object> dict = JsonSerializer.Deserialize<Dictionary<string, object>>(_element.ToString());
            dict[name] = value;

            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(dict);
            JsonElement newElement = JsonDocument.Parse(bytes).RootElement;

            Changes.AddChange(_path, newElement, true);
        }

        /// <summary>
        /// Remove the property with the specified name from the current MutableJsonElement.
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveProperty(string name)
        {
            EnsureValid();

            EnsureObject();

            // TODO: Removal per JSON Merge Patch https://www.rfc-editor.org/rfc/rfc7386?

            if (!_element.TryGetProperty(name, out _))
            {
                throw new InvalidOperationException($"Object does not have property: {name}.");
            }

            Dictionary<string, object> dict = JsonSerializer.Deserialize<Dictionary<string, object>>(_element.ToString());
            dict.Remove(name);

            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(dict);
            JsonElement newElement = JsonDocument.Parse(bytes).RootElement;

            Changes.AddChange(_path, newElement, true);
        }

        /// <summary>
        /// Sets the value of this element to the passed-in value.
        /// </summary>
        /// <param name="value"></param>
        public void Set(double value)
        {
            EnsureValid();

            Changes.AddChange(_path, value, _element.ValueKind != JsonValueKind.Number);
        }

        /// <summary>
        /// Sets the value of this element to the passed-in value.
        /// </summary>
        /// <param name="value"></param>
        public void Set(int value)
        {
            EnsureValid();

            Changes.AddChange(_path, value, _element.ValueKind != JsonValueKind.Number);
        }

        /// <summary>
        /// Sets the value of this element to the passed-in value.
        /// </summary>
        /// <param name="value"></param>
        public void Set(string value)
        {
            EnsureValid();

            Changes.AddChange(_path, value, _element.ValueKind != JsonValueKind.String);
        }

        /// <summary>
        /// Sets the value of this element to the passed-in value.
        /// </summary>
        /// <param name="value"></param>
        public void Set(bool value)
        {
            EnsureValid();

            Changes.AddChange(_path, value,
                !(_element.ValueKind == JsonValueKind.True ||
                  _element.ValueKind == JsonValueKind.False));
        }

        /// <summary>
        /// Sets the value of this element to the passed-in value.
        /// </summary>
        /// <param name="value"></param>
        public void Set(object value)
        {
            EnsureValid();

            Changes.AddChange(_path, value, true);
        }

        /// <summary>
        /// Sets the value of this element to the passed-in value.
        /// </summary>
        /// <param name="value"></param>
        public void Set(MutableJsonElement value)
        {
            EnsureValid();

            value.EnsureValid();

            JsonElement element = value._element;

            if (Changes.TryGetChange(value._path, value._highWaterMark, out MutableJsonChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    element = change.AsJsonElement();
                }
            }

            Changes.AddChange(_path, element, true);
        }

        private void EnsureObject()
        {
            if (_element.ValueKind != JsonValueKind.Object)
            {
                throw new InvalidOperationException($"Expected an 'Object' type but was {_element.ValueKind}.");
            }
        }

        private void EnsureArray()
        {
            if (_element.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Expected an 'Array' type but was {_element.ValueKind}.");
            }
        }

        private void EnsureValid()
        {
            if (Changes.AncestorChanged(_path, _highWaterMark))
            {
                throw new InvalidOperationException("An ancestor node of this element has unapplied changes.  Please re-request this property from the RootElement.");
            }
        }
    }
}
