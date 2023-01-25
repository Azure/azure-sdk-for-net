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
    public partial struct JsonDataElement
    {
        internal static readonly MethodInfo GetPropertyMethod = typeof(JsonDataElement).GetMethod(nameof(GetProperty), BindingFlags.NonPublic | BindingFlags.Instance);

        private readonly JsonData _root;
        private readonly JsonElement _element;
        private readonly string _path;
        private readonly int _highWaterMark;

        private readonly JsonData.ChangeTracker Changes => _root.Changes;

        internal JsonDataElement(JsonData root, JsonElement element, string path, int highWaterMark = -1)
        {
            _element = element;
            _root = root;
            _path = path;
            _highWaterMark = highWaterMark;
        }

        /// <summary>
        /// Gets the JsonDataElement for the value of the property with the specified name.
        /// </summary>
        internal JsonDataElement GetProperty(string name)
        {
            if (!TryGetProperty(name, out JsonDataElement value))
            {
                throw new InvalidOperationException($"{_path} does not containe property called {name}");
            }

            return value;
        }

        internal bool TryGetProperty(string name, out JsonDataElement value)
        {
            EnsureValid();

            EnsureObject();

            bool hasProperty = _element.TryGetProperty(name, out JsonElement element);
            if (!hasProperty)
            {
                value = default;
                return false;
            }

            var path = JsonData.ChangeTracker.PushProperty(_path, name);
            if (Changes.TryGetChange(path, _highWaterMark, out JsonDataChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    value = new JsonDataElement(_root, change.AsJsonElement(), path, change.Index);
                    return true;
                }
            }

            value = new JsonDataElement(_root, element, path, _highWaterMark);
            return true;
        }

        internal JsonDataElement GetIndexElement(int index)
        {
            EnsureValid();

            EnsureArray();

            var path = JsonData.ChangeTracker.PushIndex(_path, index);

            if (Changes.TryGetChange(path, _highWaterMark, out JsonDataChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    return new JsonDataElement(_root, change.AsJsonElement(), path, change.Index);
                }
            }

            return new JsonDataElement(_root, _element[index], path, _highWaterMark);
        }

        internal double GetDouble()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out JsonDataChange change))
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

        internal int GetInt32()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out JsonDataChange change))
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

        internal long GetInt64() => throw new NotImplementedException();

        internal float GetFloat() => throw new NotImplementedException();

        internal string? GetString()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out JsonDataChange change))
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

        internal bool GetBoolean()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out JsonDataChange change))
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

        internal void SetProperty(string name, object value)
        {
            EnsureValid();

            EnsureObject();

            // Per copying Dictionary semantics, if the property already exists, just replace the value.
            // If the property already exists, just set it.

            var path = JsonData.ChangeTracker.PushProperty(_path, name);

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

        internal void RemoveProperty(string name)
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

        internal void Set(double value)
        {
            EnsureValid();

            Changes.AddChange(_path, value, _element.ValueKind != JsonValueKind.Number);
        }

        internal void Set(int value)
        {
            EnsureValid();

            Changes.AddChange(_path, value, _element.ValueKind != JsonValueKind.Number);
        }

        internal void Set(string value)
        {
            EnsureValid();

            Changes.AddChange(_path, value, _element.ValueKind != JsonValueKind.String);
        }

        internal void Set(bool value)
        {
            EnsureValid();

            Changes.AddChange(_path, value,
                !(_element.ValueKind == JsonValueKind.True ||
                  _element.ValueKind == JsonValueKind.False));
        }

        internal void Set(object value)
        {
            EnsureValid();

            Changes.AddChange(_path, value, true);
        }

        internal void Set(JsonDataElement value)
        {
            EnsureValid();

            value.EnsureValid();

            JsonElement element = value._element;

            if (Changes.TryGetChange(value._path, value._highWaterMark, out JsonDataChange change))
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
