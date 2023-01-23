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
        private readonly int _highWaterMark;

        private readonly JsonData.ChangeTracker Changes => _root.Changes;

        // TODO: we will need to look up whether a parent has changed.
#pragma warning disable CA1822 // Mark members as static
        private bool IsValid => true;
#pragma warning restore CA1822 // Mark members as static

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
            return GetProperty(name, true);
        }

        private JsonDataElement GetProperty(string name, bool checkChanges)
        {
            EnsureValid();

            if (checkChanges)
            {
                return GetObject().GetProperty(name, false);
            }

            EnsureObject();

            var path = JsonData.ChangeTracker.PushProperty(_path, name);

            if (Changes.TryGetChange(path, out JsonDataChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    return new JsonDataElement(_root, change.AsJsonElement(), path, change.Index);
                }
            }

            return new JsonDataElement(_root, _element.GetProperty(name), path, _highWaterMark);
        }

        // TODO: Reimplement GetProperty in terms of TryGetProperty().
        internal bool TryGetProperty(string name, out JsonDataElement value)
        {
            if (_element.ValueKind != JsonValueKind.Object)
            {
                throw new InvalidOperationException($"Expected an 'Object' type but was {_element.ValueKind}.");
            }

            JsonElement element = _element;

            var path = JsonData.ChangeTracker.PushProperty(_path, name);

            if (Changes.TryGetChange(path, out JsonDataChange change))
            {
                if (change.Value == null)
                {
                    // TODO: handle this.
                    //throw new InvalidCastException("Property has been removed");
                }

                if (change.ReplacesJsonElement)
                {
                    element = change.AsJsonElement();
                }
            }

            if (element.TryGetProperty(name, out _))
            {
                value = new JsonDataElement(_root, element, path);
                return true;
            }

            value = default;
            return false;
        }

        internal JsonDataElement GetIndexElement(int index)
        {
            return GetIndexElement(index, true);
        }

        private JsonDataElement GetIndexElement(int index, bool checkChanges)
        {
            EnsureValid();

            if (checkChanges)
            {
                return GetArray().GetIndexElement(index, false);
            }

            EnsureArray();

            var path = JsonData.ChangeTracker.PushIndex(_path, index);

            if (Changes.TryGetChange(path, out JsonDataChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    return new JsonDataElement(_root, change.AsJsonElement(), path, change.Index);
                }
            }

            return new JsonDataElement(_root, _element[index], path, _highWaterMark);
        }

        private JsonDataElement GetObject()
        {
            EnsureValid();

            EnsureObject();

            if (Changes.TryGetChange(_path, out JsonDataChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    return new JsonDataElement(_root, change.AsJsonElement(), _path, change.Index);
                }
            }

            return this;
        }

        private JsonDataElement GetArray()
        {
            EnsureValid();

            EnsureArray();

            if (Changes.TryGetChange(_path, out JsonDataChange change))
            {
                if (change.ReplacesJsonElement)
                {
                    return new JsonDataElement(_root, change.AsJsonElement(), _path, change.Index);
                }
            }

            return this;
        }

        internal double GetDouble()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, out JsonDataChange change))
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

            if (Changes.TryGetChange(_path, out JsonDataChange change))
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

        internal string? GetString()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, out JsonDataChange change))
            {
                switch (change.Value)
                {
                    case string s:
                        return s;
                    case JsonElement element:
                        return element.GetString();
                    default:
                        throw new InvalidOperationException($"Element at {_path} is not a string.");
                }
            }

            return _element.GetString();
        }

        internal void SetProperty(string name, object value)
        {
            EnsureValid();

            EnsureObject();

            // TODO: check for changes first?

            var path = JsonData.ChangeTracker.PushProperty(_path, name);

            // Per copying Dictionary semantics, if the property already exists, just replace the value.
            // If the property already exists, just set it.

            if (_element.TryGetProperty(name, out _))
            {
                // TODO: should this be a structural change?  Confirm.
                Changes.AddChange(path, value, true);
            }

            // If it's not already there, we'll add a different kind of change.
            // We are adding a property to this object.  The change reflects an update
            // to the object's JsonElement.  Get the new JsonElement.
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

        internal void Set(object value)
        {
            EnsureValid();

            Changes.AddChange(_path, value, true);
        }

        internal void Set(JsonDataElement value)
        {
            value.EnsureValid();

            JsonElement element = value._element;

            if (Changes.TryGetChange(value._path, out JsonDataChange change))
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

        // TODO: Decide whether to keep this implementation.
        private void EnsureValid()
        {
            if (Changes.AncestorChanged(_path, _highWaterMark))
            {
                throw new InvalidOperationException("An ancestor node of this element has unapplied changes.  Please re-request this property from the RootElement.");
            }
        }
    }
}
