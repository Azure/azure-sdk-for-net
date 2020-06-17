// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace Azure.Core
{
    /// <summary>
    ///
    /// </summary>
    public class DynamicJson : IDynamicMetaObjectProvider
    {
        private readonly JsonValueKind _kind;
        private Dictionary<string, DynamicJson>? _objectRepresentation;
        private List<DynamicJson>? _arrayRepresentation;
        private object? _value;

        public DynamicJson(string json): this(JsonDocument.Parse(json).RootElement)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="element"></param>
        public DynamicJson(JsonElement element)
        {
            _kind = element.ValueKind;
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    _objectRepresentation = new Dictionary<string, DynamicJson>();
                    foreach (var item in element.EnumerateObject())
                    {
                        _objectRepresentation[item.Name] = new DynamicJson(item.Value);
                    }
                    break;
                case JsonValueKind.Array:
                    _arrayRepresentation = new List<DynamicJson>();
                    foreach (var item in element.EnumerateArray())
                    {
                        _arrayRepresentation.Add(new DynamicJson(item));
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

        private DynamicJson(IEnumerable<KeyValuePair<string,DynamicJson>> properties)
        {
            _kind = JsonValueKind.Object;
            _objectRepresentation = new Dictionary<string, DynamicJson>();
            foreach (var property in properties)
            {
                _objectRepresentation[property.Key] = property.Value;
            }
        }

        private DynamicJson(IEnumerable<DynamicJson> array)
        {
            _kind = JsonValueKind.Array;
            _arrayRepresentation = new List<DynamicJson>();
            foreach (var item in array)
            {
                if (item == null)
                {
                    _arrayRepresentation.Add(new DynamicJson((object?)null));
                }
                else
                {
                    _arrayRepresentation.Add(item);
                }
            }
        }

        private DynamicJson(object? value)
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
                default:
                    _kind = value == null ? JsonValueKind.Null : JsonValueKind.String;
                    break;
            }
        }

        public static DynamicJson Parse(string json)
        {
            return Create(JsonDocument.Parse(json).RootElement);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static DynamicJson Create(JsonElement element)
        {
            return new DynamicJson(element);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="writer"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void WriteTo(Utf8JsonWriter writer)
        {
            switch (_kind)
            {
                case JsonValueKind.Null:
                case JsonValueKind.String:
                    writer.WriteStringValue((string?)_value);
                    break;
                case JsonValueKind.Number:
                    ((Number) _value!).WriteTo(writer);
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        public DynamicJson this[int index]
        {
            get => GetValueAt(index);
            set => SetValueAt(index, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="property"></param>
        public DynamicJson this[string property]
        {
            get => GetValue(property);
            set => SetValue(property, value);
        }

        private object SetValueAt(int index, object value)
        {
            if (!(value is DynamicJson dynamicJson))
            {
                dynamicJson = new DynamicJson(value);
            }
            EnsureArray()[index] = dynamicJson;
            return value;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public JsonElement ToJsonElement()
        {
            var memoryStream = new MemoryStream();
            var writer = new Utf8JsonWriter(memoryStream);
            WriteTo(writer);
            return JsonDocument.Parse(memoryStream.ToArray()).RootElement;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            using var memoryStream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                WriteTo(writer);
            }
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        /// <inheritdoc />
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) => new MetaObject(parameter, this);

        private DynamicJson GetValue(string propertyName)
        {
            if (propertyName == "Length" && _kind == JsonValueKind.Array)
            {
                return EnsureArray().Count;
            }

            if (EnsureObject().TryGetValue(propertyName, out DynamicJson element))
            {
                return element;
            }

            throw new InvalidOperationException($"Property {propertyName} not found");
        }

        private object? SetValue(string propertyName, object? value)
        {
            if (!(value is DynamicJson json))
            {
                json = new DynamicJson(value);
            }

            EnsureObject()[propertyName] = json;
            return value;
        }

        private List<DynamicJson> EnsureArray()
        {
            if (_kind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Expected kind to be array but was {_kind} instead");
            }

            Debug.Assert(_arrayRepresentation != null);
            return _arrayRepresentation!;
        }

        private Dictionary<string, DynamicJson> EnsureObject()
        {
            if (_kind != JsonValueKind.Object)
            {
                throw new InvalidOperationException($"Expected kind to be object but was {_kind} instead");
            }

            Debug.Assert(_objectRepresentation != null);
            return _objectRepresentation!;
        }

        private object? EnsureValue()
        {
            if (_kind == JsonValueKind.Object || _kind == JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Expected kind to be value but was {_kind} instead");
            }

            return _value;
        }

        private DynamicJson GetValueAt(int index)
        {
            return EnsureArray()[index];
        }

        private object? ConvertTo(Type type)
        {
            Debug.Assert(type != null);

            if (type == typeof(IEnumerable))
            {
                return EnsureArray();
            }

            var value = EnsureValue();

            if (value == null)
            {
                return null;
            }

            if (type == typeof(long))
            {
                return ((Number)value).AsLong();
            }
            if (type == typeof(int))
            {
                return checked((int)((Number)value).AsLong());
            }

            if (type == typeof(double))
            {
                return ((Number)value).AsDouble();
            }
            if (type == typeof(float))
            {
                return (float)((Number)value).AsDouble();
            }

            if (type == typeof(bool))
            {
                return (bool)value;
            }

            if (type == typeof(string))
            {
                return (string)value;
            }

            throw new InvalidOperationException($"Unknown type {type}");
        }

        private class MetaObject : DynamicMetaObject
        {
            internal MetaObject(Expression parameter, IDynamicMetaObjectProvider value) : base(parameter, BindingRestrictions.Empty, value)
            { }

            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                var targetObject = Expression.Convert(Expression, LimitType);
                var methodIplementation = typeof(DynamicJson).GetMethod(nameof(GetValue), BindingFlags.NonPublic | BindingFlags.Instance);
                var arguments = new Expression[] { Expression.Constant(binder.Name) };

                var getPropertyCall = Expression.Call(targetObject, methodIplementation, arguments);
                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                DynamicMetaObject getProperty = new DynamicMetaObject(getPropertyCall, restrictions);
                return getProperty;
            }

            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                Expression targetObject = Expression.Convert(Expression, LimitType);
                var methodImplementation = typeof(DynamicJson).GetMethod(nameof(SetValue), BindingFlags.NonPublic | BindingFlags.Instance);
                var arguments = new Expression[2] { Expression.Constant(binder.Name), Expression.Convert(value.Expression, typeof(object)) };

                Expression setPropertyCall = Expression.Call(targetObject, methodImplementation, arguments);
                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                DynamicMetaObject setProperty = new DynamicMetaObject(setPropertyCall, restrictions);
                return setProperty;
            }

            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                var sourceInstance = Expression.Convert(Expression, LimitType);
                var destinationType = binder.Type;
                var destinationTypeExpression = Expression.Constant(destinationType);

                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                var methodIplementation = typeof(DynamicJson).GetMethod(nameof(ConvertTo), BindingFlags.NonPublic | BindingFlags.Instance);
                Expression expression = Expression.Call(sourceInstance, methodIplementation, new Expression[] { destinationTypeExpression });
                expression = Expression.Convert(expression, binder.Type);
                return new DynamicMetaObject(expression, restrictions);
            }

            public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
            {
                if (indexes.Length != 1) throw new InvalidOperationException();
                var index = indexes[0].Expression;

                var targetObject = Expression.Convert(Expression, LimitType);
                var methodIplementation = typeof(DynamicJson).GetMethod(nameof(GetValueAt), BindingFlags.NonPublic | BindingFlags.Instance);
                var arguments = new[] { index };

                var getPropertyCall = Expression.Call(targetObject, methodIplementation, arguments);
                var restrictions = binder.FallbackGetIndex(this, indexes).Restrictions; // TODO: all these restrictions are a hack. Tthey need to be cleaned up.
                DynamicMetaObject getProperty = new DynamicMetaObject(getPropertyCall, restrictions);
                return getProperty;
            }

            public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value)
            {
                if (indexes.Length != 1) throw new InvalidOperationException();
                var index = indexes[0].Expression;

                var targetObject = Expression.Convert(Expression, LimitType);
                var methodIplementation = typeof(DynamicJson).GetMethod(nameof(SetValueAt), BindingFlags.NonPublic | BindingFlags.Instance);
                var arguments = new[] { index, Expression.Convert(value.Expression, typeof(object)) };

                var setPropertyCall = Expression.Call(targetObject, methodIplementation, arguments);
                var restrictions = binder.FallbackSetIndex(this, indexes, value).Restrictions; // TODO: all these restrictions are a hack. Tthey need to be cleaned up.
                DynamicMetaObject getProperty = new DynamicMetaObject(setPropertyCall , restrictions);
                return getProperty;
            }
        }


        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DynamicJson> EnumerateArray()
        {
            return EnsureArray();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, DynamicJson>> EnumerateObject()
        {
            return EnsureObject();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
#pragma warning disable CA1720 // Identifier 'Object' contains type name
        public static DynamicJson Object()
        {
            return Object(System.Array.Empty<KeyValuePair<string, DynamicJson>>());
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static DynamicJson Object(IEnumerable<KeyValuePair<string, DynamicJson>> values)
        {
            return new DynamicJson(values);
        }
#pragma warning restore CA1720

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static DynamicJson Array()
        {
            return Array(System.Array.Empty<DynamicJson>());
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static DynamicJson Array(IEnumerable<DynamicJson> values)
        {
            return new DynamicJson(values);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static DynamicJson Array(params DynamicJson[] values)
        {
            return new DynamicJson(values);
        }

        public static explicit operator bool(DynamicJson json) => (bool) json.ConvertTo(typeof(bool))!;
        public static explicit operator int(DynamicJson json) => (int) json.ConvertTo(typeof(int))!;
        public static explicit operator long(DynamicJson json) => (int) json.ConvertTo(typeof(long))!;
        public static explicit operator string?(DynamicJson json) => (string?) json.ConvertTo(typeof(string));
        public static explicit operator float(DynamicJson json) => (int) json.ConvertTo(typeof(float))!;
        public static explicit operator double(DynamicJson json) => (int) json.ConvertTo(typeof(float))!;

        public static implicit operator DynamicJson(int value) => new DynamicJson(value);
        public static implicit operator DynamicJson(long value) => new DynamicJson(value);
        public static implicit operator DynamicJson(double value) => new DynamicJson(value);
        public static implicit operator DynamicJson(float value) => new DynamicJson(value);
        public static implicit operator DynamicJson(bool value) => new DynamicJson(value);
        public static implicit operator DynamicJson(string? value) => new DynamicJson((object?)value);

        public string? GetString() => (string?) this;
        public int GetIn32() => (int) this;
        public long GetLong() => (long) this;
        public float GetFloat() => (float) this;
        public double GetDouble() => (double) this;
        public bool GetBoolean() => (bool) this;
        public int GetArrayLength() => EnsureArray().Count;
        public DynamicJson GetProperty(string name) => GetValue(name);


        public static DynamicJson Serialize<T>(T value, JsonSerializerOptions? options = null)
        {
            var serialized = JsonSerializer.Serialize<T>(value, options);
            return new DynamicJson(JsonDocument.Parse(serialized).RootElement);
        }

        public static DynamicJson Serialize<T>(T value, ObjectSerializer serializer)
        {
            using var memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, value, typeof(T));
            memoryStream.Position = 0;
            return new DynamicJson(JsonDocument.Parse(memoryStream).RootElement);
        }

        public static async Task<DynamicJson> SerializeAsync<T>(T value, ObjectSerializer serializer)
        {
            using var memoryStream = new MemoryStream();
            await serializer.SerializeAsync(memoryStream, value, typeof(T)).ConfigureAwait(false);
            memoryStream.Position = 0;
            return new DynamicJson(JsonDocument.Parse(memoryStream).RootElement);
        }

        public T Deserialize<T>(JsonSerializerOptions? options = null)
        {
            return JsonSerializer.Deserialize<T>(ToString(), options);
        }

        public T Deserialize<T>(JsonObjectSerializer serializer)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(ToString()));
            return (T) serializer.Deserialize(stream, typeof(T));
        }

        public async Task<T> DeserializeAsync<T>(JsonObjectSerializer serializer)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(ToString()));
            return (T) await serializer.DeserializeAsync(stream, typeof(T)).ConfigureAwait(false);
        }

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
                return _long;
            }

            public double AsDouble()
            {
                return _double;
            }
        }

    }
}