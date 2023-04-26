﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Azure.Core.Json
{
    /// <summary>
    /// A mutable representation of a JSON element.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public readonly partial struct MutableJsonElement
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
                throw new InvalidOperationException($"{_path} does not contain property called {name}");
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
        /// Attempts to represent the current JSON number as a <see cref="double"/>.
        /// </summary>
        /// <returns>
        ///   <see langword="true"/> if the number can be represented as a <see cref="double"/>,
        ///   <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.</exception>
        public bool TryGetDouble(out double value)
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                switch (change.Value)
                {
                    case double d:
                        value = d;
                        return true;
                    case JsonElement element:
                        return element.TryGetDouble(out value);
                    default:
                        value = default;
                        return false;
                }
            }

            return _element.TryGetDouble(out value);
        }

        /// <summary>
        /// Gets the current JSON number as a <see cref="double"/>.
        /// </summary>
        /// <returns>The current JSON number as a <see cref="double"/>.</returns>
        /// <exception cref="InvalidOperationException">This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.</exception>
        /// <exception cref="FormatException">The value cannot be represented as a <see cref="double"/>.</exception>
        public double GetDouble()
        {
            if (!TryGetDouble(out double value))
            {
                throw new FormatException(GetFormatExceptionText(_path, typeof(double)));
            }

            return value;
        }

        private static string GetFormatExceptionText(string path, Type type)
        {
            return $"Element at {path} cannot be formatted as type '{type.ToString()}.";
        }

        /// <summary>
        /// Attempts to represent the current JSON number as a <see cref="int"/>.
        /// </summary>
        /// <returns>
        ///   <see langword="true"/> if the number can be represented as a <see cref="int"/>,
        ///   <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.</exception>
        public bool TryGetInt32(out int value)
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                switch (change.Value)
                {
                    case int i:
                        value = i;
                        return true;
                    case JsonElement element:
                        return element.TryGetInt32(out value);
                    default:
                        value = default;
                        return false;
                }
            }

            return _element.TryGetInt32(out value);
        }

        /// <summary>
        /// Gets the current JSON number as a <see cref="int"/>.
        /// </summary>
        /// <returns>The current JSON number as a <see cref="int"/>.</returns>
        /// <exception cref="InvalidOperationException">This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.</exception>
        /// <exception cref="FormatException">The value cannot be represented as a <see cref="int"/>.</exception>
        public int GetInt32()
        {
            if (!TryGetInt32(out int value))
            {
                throw new FormatException(GetFormatExceptionText(_path, typeof(int)));
            }

            return value;
        }

        /// <summary>
        /// Attempts to represent the current JSON number as a <see cref="long"/>.
        /// </summary>
        /// <returns>
        ///   <see langword="true"/> if the number can be represented as a <see cref="long"/>,
        ///   <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.</exception>
        public bool TryGetInt64(out long value)
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                switch (change.Value)
                {
                    case long l:
                        value = l;
                        return true;
                    case JsonElement element:
                        return element.TryGetInt64(out value);
                    default:
                        value = default;
                        return false;
                }
            }

            return _element.TryGetInt64(out value);
        }

        /// <summary>
        /// Gets the current JSON number as a <see cref="long"/>.
        /// </summary>
        /// <returns>The current JSON number as a <see cref="long"/>.</returns>
        /// <exception cref="InvalidOperationException">This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.</exception>
        /// <exception cref="FormatException">The value cannot be represented as a <see cref="long"/>.</exception>
        public long GetInt64()
        {
            if (!TryGetInt64(out long value))
            {
                throw new FormatException(GetFormatExceptionText(_path, typeof(long)));
            }

            return value;
        }

        /// <summary>
        /// Attempts to represent the current JSON number as a <see cref="float"/>.
        /// </summary>
        /// <returns>
        ///   <see langword="true"/> if the number can be represented as a <see cref="float"/>,
        ///   <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.</exception>
        public bool TryGetSingle(out float value)
        {
            EnsureValid();

            if (Changes.TryGetChange(_path, _highWaterMark, out MutableJsonChange change))
            {
                switch (change.Value)
                {
                    case float f:
                        value = f;
                        return true;
                    case JsonElement element:
                        return element.TryGetSingle(out value);
                    default:
                        value = default;
                        return false;
                }
            }

            return _element.TryGetSingle(out value);
        }

        /// <summary>
        /// Gets the current JSON number as a <see cref="float"/>.
        /// </summary>
        /// <returns>The current JSON number as a <see cref="float"/>.</returns>
        /// <exception cref="InvalidOperationException">This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.</exception>
        /// <exception cref="FormatException">The value cannot be represented as a <see cref="float"/>.</exception>
        public float GetSingle()
        {
            if (!TryGetSingle(out float value))
            {
                throw new FormatException(GetFormatExceptionText(_path, typeof(float)));
            }

            return value;
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
        /// Gets an enumerator to enumerate the values in the JSON array represented by this MutableJsonElement.
        /// </summary>
        public ArrayEnumerator EnumerateArray()
        {
            EnsureValid();

            EnsureArray();

            return new ArrayEnumerator(this);
        }

        /// <summary>
        /// Gets an enumerator to enumerate the properties in the JSON object represented by this JsonElement.
        /// </summary>
        public ObjectEnumerator EnumerateObject()
        {
            EnsureValid();

            EnsureObject();

            return new ObjectEnumerator(this);
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
            using MemoryStream changedElementStream = new();
            using (Utf8JsonWriter changedElementWriter = new(changedElementStream))
            {
                WriteTo(changedElementWriter);
            }

            return changedElementStream.ToArray();
        }

        internal static Utf8JsonReader GetReaderForElement(JsonElement element)
        {
            using MemoryStream stream = new();
            using (Utf8JsonWriter writer = new(stream))
            {
                element.WriteTo(writer);
            }

            return new Utf8JsonReader(stream.GetBuffer().AsSpan().Slice(0, (int)stream.Position));
        }

        internal void DisposeRoot()
        {
            _root.Dispose();
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"ValueKind = {ValueKind} : \"{ToString()}\"";
    }
}
