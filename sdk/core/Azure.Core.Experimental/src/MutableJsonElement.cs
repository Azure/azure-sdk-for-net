// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        /// Gets the type of the current JSON value.
        /// </summary>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public JsonValueKind ValueKind
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            get
            {
                JsonElement element = GetJsonElement();
                return element.ValueKind;
            }
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
        public long GetInt64()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                switch (change.Value)
                {
                    case long l:
                        return l;
                    case JsonElement element:
                        return element.GetInt64();
                    default:
                        throw new InvalidOperationException($"Element at {_path} is not an Int32.");
                }
            }

            return _element.GetInt64();
        }

        /// <summary>
        /// Gets the current JSON number as a float.
        /// </summary>
        /// <returns></returns>
        public float GetSingle()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                switch (change.Value)
                {
                    case float f:
                        return f;
                    case JsonElement element:
                        return element.GetSingle();
                    default:
                        throw new InvalidOperationException($"Element at {_path} is not an Int32.");
                }
            }

            return _element.GetSingle();
        }

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
        /// Get an enumerator to enumerate the values in the JSON array represented by this MutableJsonElement.
        /// </summary>
        /// <returns></returns>
        public ArrayEnumerator EnumerateArray()
        {
            EnsureValid();

            EnsureArray();

            return new ArrayEnumerator(this);
        }

        /// <summary>
        /// Set the value of the property with the specified name to the passed-in value.  If the property is not already present, it will be created.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public MutableJsonElement SetProperty(string name, object value)
        {
            if (TryGetProperty(name, out MutableJsonElement element))
            {
                element.Set(value);
                return this;
            }

#if !NET6_0_OR_GREATER
            // Earlier versions of JsonSerializer.Serialize include "RootElement"
            // as a property when called on JsonDocument.
            if (value is JsonDocument doc)
            {
                value = doc.RootElement;
            }
#endif

            // If it's not already there, we'll add a change to this element's JsonElement instead.
            Dictionary<string, object> dict = JsonSerializer.Deserialize<Dictionary<string, object>>(GetRawBytes())!;
            dict[name] = value;

            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(dict);
            JsonElement newElement = JsonDocument.Parse(bytes).RootElement;

            int index = Changes.AddChange(_path, newElement, true);

            // Make sure the object reference is stored to ensure reference semantics
            string path = MutableJsonDocument.ChangeTracker.PushProperty(_path, name);
            Changes.AddChange(path, value, true);

            // Element has changed, return the new valid one.
            return new MutableJsonElement(_root, newElement, _path, index);
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

            if (!_element.TryGetProperty(name, out _))
            {
                throw new InvalidOperationException($"Object does not have property: {name}.");
            }

            Dictionary<string, object> dict = JsonSerializer.Deserialize<Dictionary<string, object>>(GetRawBytes())!;
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
        public void Set(long value)
        {
            EnsureValid();

            Changes.AddChange(_path, value, _element.ValueKind != JsonValueKind.Number);
        }

        /// <summary>
        /// Sets the value of this element to the passed-in value.
        /// </summary>
        /// <param name="value"></param>
        public void Set(float value)
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

            switch (value)
            {
                case int i:
                    Set(i);
                    break;
                case double d:
                    Set(d);
                    break;
                case string s:
                    Set(s);
                    break;
                case bool b:
                    Set(b);
                    break;
                case long l:
                    Set(l);
                    break;
                case float f:
                    Set(f);
                    break;
                case MutableJsonElement e:
                    Set(e);
                    break;
                case MutableJsonDocument d:
                    Set(d.RootElement);
                    break;
                case JsonDocument d:
                    Set(d.RootElement);
                    break;
                default:
                    Changes.AddChange(_path, value, true);
                    break;
            }
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

        internal void WriteTo(Utf8JsonWriter writer)
        {
            Utf8JsonReader reader = GetReaderForElement(_element);
            _root.WriteElement(_path, _highWaterMark, ref reader, writer);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                if (change.Value == null)
                    return "null";

                return change.Value.ToString()!;
            }

            // Account for changes to descendants of this element as well
            if (Changes.DescendantChanged(_path, _highWaterMark))
            {
                return Encoding.UTF8.GetString(GetRawBytes());
            }

            return _element.ToString();
        }

        internal JsonElement GetJsonElement()
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                return change.AsJsonElement();
            }

            // Account for changes to descendants of this element as well
            if (Changes.DescendantChanged(_path, _highWaterMark))
            {
                JsonDocument document = JsonDocument.Parse(GetRawBytes());
                return document.RootElement;
            }

            return _element;
        }

        private byte[] GetRawBytes()
        {
            Utf8JsonReader reader = GetReaderForElement(_element);

            using MemoryStream changedElementStream = new();
            Utf8JsonWriter changedElementWriter = new(changedElementStream);
            _root.WriteElement(_path, _highWaterMark, ref reader, changedElementWriter);
            changedElementWriter.Flush();

            return changedElementStream.ToArray();
        }

        internal static Utf8JsonReader GetReaderForElement(JsonElement element)
        {
            using MemoryStream stream = new();
            Utf8JsonWriter writer = new(stream);
            element.WriteTo(writer);
            writer.Flush();
            return new Utf8JsonReader(stream.GetBuffer().AsSpan().Slice(0, (int)stream.Position));
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
