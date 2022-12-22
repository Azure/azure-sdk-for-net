// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// <summary>
    /// A mutable representation of a JSON value.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [DebuggerTypeProxy(typeof(JsonDataDebuggerProxy))]
    [JsonConverter(typeof(JsonConverter))]
    public partial class JsonData : DynamicData, IDynamicMetaObjectProvider, IEquatable<JsonData>
    {
        private readonly JsonValueKind _kind;
        private Dictionary<string, JsonData>? _objectRepresentation;
        private List<JsonData>? _arrayRepresentation;
        private object? _value;

        private static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions();

        /// <summary>
        /// Parses a UTF-8 encoded string representing a single JSON value into a <see cref="JsonData"/>.
        /// </summary>
        /// <param name="utf8Json">A UTF-8 encoded string representing a JSON value.</param>
        /// <returns>A <see cref="JsonData"/> representation of the value.</returns>
        internal static JsonData Parse(BinaryData utf8Json)
        {
            using var doc = JsonDocument.Parse(utf8Json);
            return new JsonData(doc);
        }

        /// <summary>
        /// Parses test representing a single JSON value into a <see cref="JsonData"/>.
        /// </summary>
        /// <param name="json">The JSON string.</param>
        /// <returns>A <see cref="JsonData"/> representation of the value.</returns>
        internal static JsonData Parse(string json)
        {
            using var doc = JsonDocument.Parse(json);
            return new JsonData(doc);
        }

        /// <summary>
        ///  Creates a new JsonData object which represents the value of the given JsonDocument.
        /// </summary>
        /// <param name="jsonDocument">The JsonDocument to convert.</param>
        /// <remarks>A JsonDocument can be constructed from a JSON string using <see cref="JsonDocument.Parse(string, JsonDocumentOptions)"/>.</remarks>
        internal JsonData(JsonDocument jsonDocument) : this((object?)jsonDocument)
        {
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
            _value = value;
            switch (value)
            {
                case long l:
                    _kind = JsonValueKind.Number;
                    _value = new Number(l);
                    break;
                case int i:
                    _kind = JsonValueKind.Number;
                    _value = new Number(i);
                    break;
                case double d:
                    _kind = JsonValueKind.Number;
                    _value = new Number(d);
                    break;
                case float d:
                    _kind = JsonValueKind.Number;
                    _value = new Number(d);
                    break;
                case bool b when b:
                    _kind = JsonValueKind.True;
                    break;
                case bool b when !b:
                    _kind = JsonValueKind.False;
                    break;
                case string:
                    _kind = JsonValueKind.String;
                    break;
                case null:
                    _kind = JsonValueKind.Null;
                    break;
                case JsonDocument doc:
                    _kind = doc.RootElement.ValueKind;
                    InitFromElement(doc.RootElement);
                    break;
                default:
                    Type inputType = type ?? (value == null ? typeof(object) : value.GetType());

                    // TODO: Profile to determine if this is the best approach to serialize/parse
                    using (var stream = new MemoryStream())
                    {
                        using (var writer = new Utf8JsonWriter(stream))
                        {
                            JsonSerializer.Serialize(writer, value, inputType, options);
                            stream.Position = 0;
                            JsonElement e = JsonDocument.Parse(stream).RootElement;
                            _kind = e.ValueKind;
                            InitFromElement(e);
                        }
                    }
                    break;
            }
        }

        private JsonData(JsonElement element)
        {
            _kind = element.ValueKind;
            InitFromElement(element);
        }

        private void InitFromElement(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    _objectRepresentation = new Dictionary<string, JsonData>();
                    foreach (var item in element.EnumerateObject())
                    {
                        _objectRepresentation[item.Name] = new JsonData(item.Value);
                    }
                    break;
                case JsonValueKind.Array:
                    _arrayRepresentation = new List<JsonData>();
                    foreach (var item in element.EnumerateArray())
                    {
                        _arrayRepresentation.Add(new JsonData(item));
                    }
                    break;
                case JsonValueKind.String:
                    _value = element.GetString();
                    break;
                case JsonValueKind.Number:
                    _value = new Number(element);
                    break;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    _value = element.GetBoolean();
                    break;
                case JsonValueKind.Null:
                    _value = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(element), "Unsupported element kind");
            }
        }

        /// <summary>
        /// Gets the value of a property from an object, or <code>null</code> if no such property exists.
        /// </summary>
        /// <param name="propertyName">The name of the property to get</param>
        /// <returns>The value for a given property, or <code>null</code> if no such property exists.</returns>
        /// <remarks>If the <see cref="Kind"/> property is not <see cref="JsonValueKind.Object"/> this method throws <see cref="InvalidOperationException"/>.</remarks>
        internal JsonData? Get(string propertyName)
        {
            if (EnsureObject().TryGetValue(propertyName, out JsonData value))
            {
                return value;
            }

            return null;
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
            using var memoryStream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                WriteTo(writer);
            }
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        /// <summary>
        /// The <see cref="JsonValueKind"/> of the value of this instance.
        /// </summary>
        internal JsonValueKind Kind
        {
            get => _kind;
        }

        /// <summary>
        /// Returns the number of elements in this array.
        /// </summary>
        /// <remarks>If <see cref="Kind"/> is not <see cref="JsonValueKind.Array"/> this methods throws <see cref="InvalidOperationException"/>.</remarks>
        internal int Length
        {
            get => EnsureArray().Count;
        }

        /// <summary>
        /// Returns the names of all the properties of this object.
        /// </summary>
        /// <remarks>If <see cref="Kind"/> is not <see cref="JsonValueKind.Object"/> this methods throws <see cref="InvalidOperationException"/>.</remarks>
        internal IEnumerable<string> Properties
        {
            get => EnsureObject().Keys;
        }

        /// <summary>
        /// Returns all the elements in this array.
        /// </summary>
        /// <remarks>If<see cref="Kind"/> is not<see cref="JsonValueKind.Array"/> this methods throws <see cref = "InvalidOperationException" />.</remarks>
        internal IEnumerable<JsonData> Items
        {
            get => EnsureArray();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (_kind == JsonValueKind.Object || _kind == JsonValueKind.Array)
            {
                return ToJsonString();
            }

            return (_value ?? "<null>").ToString();
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is string)
            {
                return this == ((string?)obj);
            }

            if (obj is JsonData)
            {
                return Equals((JsonData)obj);
            }

            return base.Equals(obj);
        }

        /// <inheritdoc />
        public bool Equals(JsonData other)
        {
            if (_kind != other._kind)
            {
                return false;
            }

            switch (_kind)
            {
                case JsonValueKind.Null:
                case JsonValueKind.Undefined:
                    return true;
                case JsonValueKind.Object:
                    return _objectRepresentation!.Equals(other._objectRepresentation);
                case JsonValueKind.Array:
                    return _arrayRepresentation!.Equals(other._arrayRepresentation);
                default:
                    return _value!.Equals(other._value);
            }
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            if (_kind == JsonValueKind.String)
            {
                return ((string?)_value)!.GetHashCode();
            }

            return base.GetHashCode();
        }

        private string? GetString() => (string?)EnsureValue();

        private int GetInt32()
        {
            var value = EnsureNumberValue().AsLong();
            if (value > int.MaxValue || value < int.MinValue)
            {
                throw new OverflowException();
            }
            return (int)value;
        }

        private long GetLong() => EnsureNumberValue().AsLong();

        private float GetFloat()
        {
            var value = EnsureNumberValue().AsDouble();
            if (value > float.MaxValue || value < float.MinValue)
            {
                throw new OverflowException();
            }
            return (float)value;
        }
        private double GetDouble() => EnsureNumberValue().AsDouble();

        private bool GetBoolean() => (bool)EnsureValue()!;

        internal override void WriteTo(Utf8JsonWriter writer)
        {
            switch (_kind)
            {
                case JsonValueKind.Null:
                case JsonValueKind.String:
                    writer.WriteStringValue((string?)_value);
                    break;
                case JsonValueKind.Number:
                    ((Number)_value!).WriteTo(writer);
                    break;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    writer.WriteBooleanValue((bool)_value!);
                    break;
                case JsonValueKind.Object:
                    writer.WriteStartObject();
                    foreach (var property in EnsureObject())
                    {
                        writer.WritePropertyName(property.Key);
                        property.Value.WriteTo(writer);
                    }
                    writer.WriteEndObject();
                    break;
                case JsonValueKind.Array:
                    writer.WriteStartArray();
                    foreach (var item in EnsureArray())
                    {
                        item.WriteTo(writer);
                    }
                    writer.WriteEndArray();
                    break;
            }
        }

        private Dictionary<string, JsonData> EnsureObject()
        {
            if (_kind != JsonValueKind.Object)
            {
                throw new InvalidOperationException($"Expected kind to be object but was {_kind} instead");
            }

            Debug.Assert(_objectRepresentation != null);
            return _objectRepresentation!;
        }

        private JsonData? GetPropertyValue(string propertyName)
        {
            if (EnsureObject().TryGetValue(propertyName, out JsonData element))
            {
                return element;
            }

            return null;
        }

        /// <summary>
        /// Used by the dynamic meta object to fetch properties. We can't use GetPropertyValue because when the underlying
        /// value is an array, we want `.Length` to mean "the length of the array" and not "treat the array as an object
        /// and get the Length property", and we also want the return type to be "int" and not a JsonData wrapping the int.
        /// </summary>
        /// <param name="propertyName">The name of the property to get the value of.</param>
        /// <returns></returns>
        private object? GetDynamicPropertyValue(string propertyName)
        {
            if (_kind == JsonValueKind.Array && propertyName == nameof(Length))
            {
                return Length;
            }

            if (_kind == JsonValueKind.Object)
            {
                return GetPropertyValue(propertyName);
            }

            throw new InvalidOperationException($"Cannot get property on JSON element with kind {_kind}.");
        }

        private JsonData? GetViaIndexer(object index)
        {
            switch (index)
            {
                case string propertyName:
                    return GetPropertyValue(propertyName);
                case int arrayIndex:
                    return GetValueAt(arrayIndex);;
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private JsonData SetValue(string propertyName, object value)
        {
            if (!(value is JsonData json))
            {
                json = new JsonData(value);
            }

            EnsureObject()[propertyName] = json;
            return json;
        }

        private List<JsonData> EnsureArray()
        {
            if (_kind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Expected kind to be array but was {_kind} instead");
            }

            Debug.Assert(_arrayRepresentation != null);
            return _arrayRepresentation!;
        }

        private JsonData SetViaIndexer(object index, object value)
        {
            switch (index)
            {
                case string propertyName:
                    return SetValue(propertyName, value);
                case int arrayIndex:
                    return SetValueAt(arrayIndex, value);
            }

            throw new InvalidOperationException($"Tried to access indexer with an unsupported index type: {index}");
        }

        private JsonData GetValueAt(int index)
        {
            return EnsureArray()[index];
        }

        private JsonData SetValueAt(int index, object value)
        {
            if (!(value is JsonData json))
            {
                json = new JsonData(value);
            }

            EnsureArray()[index] = json;
            return json;
        }

        private object? EnsureValue()
        {
            if (_kind == JsonValueKind.Object || _kind == JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Expected kind to be value but was {_kind} instead");
            }

            return _value;
        }

        private Number EnsureNumberValue()
        {
            if (_kind != JsonValueKind.Number)
            {
                throw new InvalidOperationException($"Expected kind to be number but was {_kind} instead");
            }

            return (Number)EnsureValue()!;
        }

        /// <inheritdoc />
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) => new MetaObject(parameter, this);

        private IEnumerable GetDynamicEnumerable()
        {
            if (_kind == JsonValueKind.Array)
            {
                return EnsureArray();
            }

            return EnsureObject();
        }

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

        private class MetaObject : DynamicMetaObject
        {
            private static readonly MethodInfo GetDynamicValueMethod = typeof(JsonData).GetMethod(nameof(GetDynamicPropertyValue), BindingFlags.NonPublic | BindingFlags.Instance);

            private static readonly MethodInfo GetDynamicEnumerableMethod = typeof(JsonData).GetMethod(nameof(GetDynamicEnumerable), BindingFlags.NonPublic | BindingFlags.Instance);

            private static readonly MethodInfo SetValueMethod = typeof(JsonData).GetMethod(nameof(SetValue), BindingFlags.NonPublic | BindingFlags.Instance);

            private static readonly MethodInfo GetViaIndexerMethod = typeof(JsonData).GetMethod(nameof(GetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance);

            private static readonly MethodInfo SetViaIndexerMethod = typeof(JsonData).GetMethod(nameof(SetViaIndexer), BindingFlags.NonPublic | BindingFlags.Instance);

            // Operators that cast from JsonData to another type
            private static readonly Dictionary<Type, MethodInfo> CastFromOperators = GetCastFromOperators();

            internal MetaObject(Expression parameter, IDynamicMetaObjectProvider value) : base(parameter, BindingRestrictions.Empty, value)
            {
            }

            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                var targetObject = Expression.Convert(Expression, LimitType);

                var arguments = new Expression[] { Expression.Constant(binder.Name) };
                var getPropertyCall = Expression.Call(targetObject, GetDynamicValueMethod, arguments);

                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(getPropertyCall, restrictions);
            }

            public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
            {
                var targetObject = Expression.Convert(Expression, LimitType);
                var arguments = new Expression[] { Expression.Convert(indexes[0].Expression, typeof(object)) };
                var getViaIndexerCall = Expression.Call(targetObject, GetViaIndexerMethod, arguments);

                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(getViaIndexerCall, restrictions);
            }

            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                Expression targetObject = Expression.Convert(Expression, LimitType);
                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                Expression convertCall;

                if (binder.Type == typeof(IEnumerable))
                {
                    convertCall = Expression.Call(targetObject, GetDynamicEnumerableMethod);
                    return new DynamicMetaObject(convertCall, restrictions);
                }

                if (CastFromOperators.TryGetValue(binder.Type, out MethodInfo? castOperator))
                {
                    convertCall = Expression.Call(castOperator, targetObject);
                    return new DynamicMetaObject(convertCall, restrictions);
                }

                convertCall = Expression.Call(targetObject, nameof(To), new Type[] { binder.Type });
                return new DynamicMetaObject(convertCall, restrictions);
            }

            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                Expression targetObject = Expression.Convert(Expression, LimitType);
                var arguments = new Expression[2] { Expression.Constant(binder.Name), Expression.Convert(value.Expression, typeof(object)) };

                Expression setPropertyCall = Expression.Call(targetObject, SetValueMethod, arguments);
                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                DynamicMetaObject setProperty = new DynamicMetaObject(setPropertyCall, restrictions);
                return setProperty;
            }

            public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value)
            {
                var targetObject = Expression.Convert(Expression, LimitType);
                var arguments = new Expression[2] {
                    Expression.Convert(indexes[0].Expression, typeof(object)),
                    Expression.Convert(value.Expression, typeof(object))
                };
                var setCall = Expression.Call(targetObject, SetViaIndexerMethod, arguments);

                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                return new DynamicMetaObject(setCall, restrictions);
            }

            private static Dictionary<Type, MethodInfo> GetCastFromOperators()
            {
                return typeof(JsonData)
                    .GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .Where(method => method.Name == "op_Explicit" || method.Name == "op_Implicit")
                    .ToDictionary(method => method.ReturnType);
            }
        }

        internal class JsonDataDebuggerProxy
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly JsonData _jsonData;

            public JsonDataDebuggerProxy(JsonData jsonData)
            {
                _jsonData = jsonData;
            }

            [DebuggerDisplay("{Value.DebuggerDisplay,nq}", Name = "{Name,nq}")]
            internal class PropertyMember
            {
                [DebuggerBrowsable(DebuggerBrowsableState.Never)]
                public string? Name { get; set; }
                [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
                public JsonData? Value { get; set; }
            }

            [DebuggerDisplay("{Value,nq}")]
            internal class SingleMember
            {
                public object? Value { get; set; }
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public object Members
            {
                get
                {
                    if (_jsonData.Kind != JsonValueKind.Array &&
                        _jsonData.Kind != JsonValueKind.Object)
                        return new SingleMember() { Value = _jsonData.ToJsonString() };

                    return BuildMembers().ToArray();
                }
            }

            private IEnumerable<object> BuildMembers()
            {
                if (_jsonData.Kind == JsonValueKind.Object)
                {
                    foreach (var property in _jsonData.Properties)
                    {
                        yield return new PropertyMember() { Name = property, Value = _jsonData.Get(property) };
                    }
                }
                else if (_jsonData.Kind == JsonValueKind.Array)
                {
                    foreach (var property in _jsonData.Items)
                    {
                        yield return property;
                    }
                }
            }
        }

        /// <summary>
        /// The default serialization behavior for <see cref="JsonData"/> is not the behavior we want, we want to use
        /// the underlying JSON value that <see cref="JsonData"/> wraps, instead of using the default behavior for
        /// POCOs.
        /// </summary>
        private class JsonConverter : JsonConverter<JsonData>
        {
            public override JsonData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return new JsonData(document);
            }

            public override void Write(Utf8JsonWriter writer, JsonData value, JsonSerializerOptions options)
            {
                value.WriteTo(writer);
            }
        }
    }
}
