// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Dynamic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// A mutable representation of a JSON value.
    /// </summary>
    //[DebuggerDisplay("{DebuggerDisplay,nq}")]
    //[DebuggerTypeProxy(typeof(JsonDataDebuggerProxy))]
    [JsonConverter(typeof(JsonConverter))]
    public partial class JsonData : DynamicData, IEquatable<JsonData>
    {
        private readonly Memory<byte> _original;
        private readonly JsonElement _originalElement;

        internal ChangeTracker Changes { get; } = new();

        internal JsonDataElement RootElement
        {
            get
            {
                if (Changes.TryGetChange(string.Empty, -1, out JsonDataChange change))
                {
                    if (change.ReplacesJsonElement)
                    {
                        return new JsonDataElement(this, change.AsJsonElement(), string.Empty, change.Index);
                    }
                }

                return new JsonDataElement(this, _originalElement, string.Empty);
            }
        }

        internal override void WriteTo(Stream stream) => WriteTo(stream, default);

        internal void WriteTo(Stream stream, StandardFormat format)
        {
            // this is so we can add JSON Patch in the future
            if (format != default)
            {
                throw new ArgumentOutOfRangeException(nameof(format));
            }

            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            if (!Changes.HasChanges)
            {
                Write(stream, _original.Span);
                stream.Flush();
                return;
            }

            WriteElementTo(writer);
        }

        private static void Write(Stream stream, ReadOnlySpan<byte> buffer)
        {
            byte[] sharedBuffer = ArrayPool<byte>.Shared.Rent(buffer.Length);
            try
            {
                buffer.CopyTo(sharedBuffer);
                stream.Write(sharedBuffer, 0, buffer.Length);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(sharedBuffer);
            }
        }

        private static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions();

        /// <summary>
        /// Parses a UTF-8 encoded string representing a single JSON value into a <see cref="JsonData"/>.
        /// </summary>
        /// <param name="utf8Json">A UTF-8 encoded string representing a JSON value.</param>
        /// <returns>A <see cref="JsonData"/> representation of the value.</returns>
        internal static JsonData Parse(BinaryData utf8Json)
        {
            var doc = JsonDocument.Parse(utf8Json);
            return new JsonData(doc, utf8Json.ToArray().AsMemory());
        }

        /// <summary>
        /// Parses test representing a single JSON value into a <see cref="JsonData"/>.
        /// </summary>
        /// <param name="json">The JSON string.</param>
        /// <returns>A <see cref="JsonData"/> representation of the value.</returns>
        internal static JsonData Parse(string json)
        {
            byte[] utf8 = Encoding.UTF8.GetBytes(json);
            Memory<byte> jsonMemory = utf8.AsMemory();
            return new JsonData(JsonDocument.Parse(jsonMemory), jsonMemory);
        }

        internal JsonData(JsonDocument jsonDocument, Memory<byte> utf8Json) : this(jsonDocument.RootElement)
        {
            _original = utf8Json;
            _originalElement = jsonDocument.RootElement;
        }

        /// <summary>
        /// Creates a new JsonData object which represents the given object.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        internal JsonData(object? value) : this(value, DefaultJsonSerializerOptions)
        {
        }

        /// <summary>
        /// Creates a new JsonData object which represents the given object.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="options">Options to control the conversion behavior.</param>
        /// <param name="type">The type of the value to convert. </param>
        internal JsonData(object? value, JsonSerializerOptions options, Type? type = null)
        {
            if (value is JsonDocument)
                throw new InvalidOperationException("Calling wrong constructor.");

            Type inputType = type ?? (value == null ? typeof(object) : value.GetType());
            _original = JsonSerializer.SerializeToUtf8Bytes(value, inputType, options);
            _originalElement = JsonDocument.Parse(_original).RootElement;
        }

        /// <summary>
        /// Converts the given JSON value into an instance of a given type.
        /// </summary>
        /// <typeparam name="T">The type to convert the value into.</typeparam>
        /// <returns>A new instance of <typeparamref name="T"/> constructed from the underlying JSON value.</returns>
        internal T To<T>() => To<T>(DefaultJsonSerializerOptions);

        /// <summary>
        /// Deserializes the given JSON value into an instance of a given type.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the value into</typeparam>
        /// <param name="options">Options to control the conversion behavior.</param>
        /// <returns>A new instance of <typeparamref name="T"/> constructed from the underlying JSON value.</returns>
        internal T To<T>(JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(ToJsonString(), options);
        }

        /// <summary>
        /// Returns a stringified version of the JSON for this value.
        /// </summary>
        /// <returns>Returns a stringified version of the JSON for this value.</returns>
        internal string ToJsonString()
        {
            using var stream = new MemoryStream();
            WriteTo(stream);
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        ///// <summary>
        ///// Returns the names of all the properties of this object.
        ///// </summary>
        ///// <remarks>If <see cref="Kind"/> is not <see cref="JsonValueKind.Object"/> this methods throws <see cref="InvalidOperationException"/>.</remarks>
        //internal IEnumerable<string> Properties
        //{
        //    get => EnsureObject().Keys;
        //}

        ///// <summary>
        ///// Returns all the elements in this array.
        ///// </summary>
        ///// <remarks>If<see cref="Kind"/> is not<see cref="JsonValueKind.Array"/> this methods throws <see cref = "InvalidOperationException" />.</remarks>
        //internal IEnumerable<JsonData> Items
        //{
        //    get { return this.EnumerateArray(); }
        //}

        //private IEnumerable<JsonData> EnumerateArray()
        //{
        //    EnsureArray();

        //    foreach (var item in _element.EnumerateArray())
        //    {
        //        yield new JsonData(item);
        //    };
        //}

        ///// <inheritdoc />
        //public override string ToString()
        //{
        //    if (Kind == JsonValueKind.Object || Kind == JsonValueKind.Array)
        //    {
        //        return ToJsonString();
        //    }

        //    return (_value ?? "<null>").ToString();
        //}

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            //if (obj is string)
            //{
            //    return this == ((string?)obj);
            //}

            //if (obj is JsonData)
            //{
            //    return Equals((JsonData)obj);
            //}

            return base.Equals(obj);
        }

        /// <inheritdoc />
        public bool Equals(JsonData? other)
        {
            if (other is null)
            {
                return false;
            }

            return RootElement.Equals(other.RootElement);

            // TODO: pass this through to the RootElement
            //if (Kind != other.Kind)
            //{
            //    return false;
            //}

            // TODO: JsonElement doesn't implement equality, per
            // https://github.com/dotnet/runtime/issues/62585
            // We could implement this by comparing _utf8 values;
            // depends on getting those from JsonElement.
            //return _element.Equals(other._element);
        }

        /// <inheritdoc />
        public override int GetHashCode() => RootElement.GetHashCode();

        private string? GetString() => RootElement.GetString();

        private int GetInt32() => RootElement.GetInt32();

        private long GetInt64() => RootElement.GetInt64();

        private float GetFloat() => RootElement.GetFloat();
        //{
        //    var value = _element.GetDouble();
        //    if (value > float.MaxValue || value < float.MinValue)
        //    {
        //        throw new OverflowException();
        //    }
        //    return (float)value;
        //}

        private double GetDouble() => RootElement.GetDouble();

        private bool GetBoolean() => RootElement.GetBoolean();

        // TODO: Handle array length separately - but do we need to?
        ///// <summary>
        ///// Used by the dynamic meta object to fetch properties. We can't use GetPropertyValue because when the underlying
        ///// value is an array, we want `.Length` to mean "the length of the array" and not "treat the array as an object
        ///// and get the Length property", and we also want the return type to be "int" and not a JsonData wrapping the int.
        ///// </summary>
        ///// <param name="propertyName">The name of the property to get the value of.</param>
        ///// <returns></returns>
        //private object? GetDynamicPropertyValue(string propertyName)
        //{
        //    if (Kind == JsonValueKind.Array && propertyName == nameof(Length))
        //    {
        //        return Length;
        //    }

        //    if (Kind == JsonValueKind.Object)
        //    {
        //        return GetPropertyValue(propertyName);
        //    }

        //    throw new InvalidOperationException($"Cannot get property on JSON element with kind {Kind}.");
        //}

        // TODO: Multiplex indexer for properties and arrays
        //private JsonData? GetViaIndexer(object index)
        //{
        //    switch (index)
        //    {
        //        case string propertyName:
        //            return GetPropertyValue(propertyName);
        //        case int arrayIndex:
        //            return GetValueAt(arrayIndex);
        //    }

        //    throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        //}

        //private JsonData SetValue(string propertyName, object value)
        //{
        //    if (!(value is JsonData json))
        //    {
        //        json = new JsonData(value);
        //    }

        //    EnsureObject()[propertyName] = json;
        //    return json;
        //}

        //private JsonData SetViaIndexer(object index, object value)
        //{
        //    switch (index)
        //    {
        //        case string propertyName:
        //            return SetValue(propertyName, value);
        //        case int arrayIndex:
        //            return SetValueAt(arrayIndex, value);
        //    }

        //    throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        //}

        //private JsonData SetValueAt(int index, object value)
        //{
        //    if (!(value is JsonData json))
        //    {
        //        json = new JsonData(value);
        //    }

        //    EnsureArray()[index] = json;
        //    return json;
        //}

        //private IEnumerable GetDynamicEnumerable()
        //{
        //    if (Kind == JsonValueKind.Array)
        //    {
        //        return EnsureArray();
        //    }

        //    return EnsureObject();
        //}

        private string DebuggerDisplay => ToJsonString();

        private struct Number
        {
            public Number(in JsonElement element)
            {
                _hasDouble = element.TryGetDouble(out _double);
                _hasLong = element.TryGetInt64(out _long);
            }

            public Number(long l)
            {
                _long = l;
                _hasLong = true;
                _double = default;
                _hasDouble = false;
            }

            private long _long;
            private bool _hasLong;
            private double _double;
            private bool _hasDouble;

            public Number(double d)
            {
                _long = default;
                _hasLong = false;
                _double = d;
                _hasDouble = true;
            }

            public void WriteTo(Utf8JsonWriter writer)
            {
                if (_hasDouble)
                {
                    writer.WriteNumberValue(_double);
                }
                else
                {
                    writer.WriteNumberValue(_long);
                }
            }

            public long AsLong()
            {
                if (!_hasLong)
                {
                    throw new FormatException();
                }
                return _long;
            }

            public double AsDouble()
            {
                return _double;
            }
        }
    }
}
