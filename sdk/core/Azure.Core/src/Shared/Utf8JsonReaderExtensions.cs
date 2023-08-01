// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core
{
    //wip
    internal static class Utf8JsonReaderExtensions
    {
        public delegate void PropertySetter<T>(ReadOnlySpan<byte> propertyName, ref T properties, ref Utf8JsonReader reader, ModelSerializerOptions options);
        private delegate object ReadValue(ref Utf8JsonReader reader);

        private static readonly Dictionary<Type, ReadValue> _readerActions = new Dictionary<Type, ReadValue>()
        {
            { typeof(string), (ref Utf8JsonReader reader) => reader.GetString() },
            { typeof(bool), (ref Utf8JsonReader reader) => reader.GetBoolean() },
            { typeof(int), (ref Utf8JsonReader reader) => reader.GetInt32() },
            { typeof(long), (ref Utf8JsonReader reader) => reader.GetInt64() },
            { typeof(double), (ref Utf8JsonReader reader) => reader.GetDouble() },
            { typeof(float), (ref Utf8JsonReader reader) => reader.GetSingle() },
            { typeof(decimal), (ref Utf8JsonReader reader) => reader.GetDecimal() },
            { typeof(DateTimeOffset), (ref Utf8JsonReader reader) => reader.GetDateTimeOffset() },
            { typeof(Guid), (ref Utf8JsonReader reader) => reader.GetGuid() },
            { typeof(byte[]), (ref Utf8JsonReader reader) => reader.GetBytesFromBase64() },
        };

        private static readonly Dictionary<Type, Func<string, object>> _keyConverter = new Dictionary<Type, Func<string, object>>()
        {
            { typeof(int), str => Convert.ToInt32(str) },
            { typeof(string), str => str },
        };

        private static string ConvertKeyToString(Type typeToConvert, string key) => key;

        public static List<T> GetList<T>(this ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            List<T> list = new List<T>();

            if (reader.TokenType == JsonTokenType.Null)
                return null;

            if (reader.TokenType != JsonTokenType.StartArray)
                throw new InvalidOperationException("Expected StartArray token");

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                    break;

                list.Add(reader.GetObject<T>(options));
            }

            return list;
        }

        public static Dictionary<TKey, TValue> GetDictionary<TKey, TValue>(this ref Utf8JsonReader reader, ModelSerializerOptions options)
            where TKey : notnull
        {
            if (!_keyConverter.TryGetValue(typeof(TKey), out var converter))
                throw new InvalidOperationException($"Cannot use type {typeof(TKey).Name} as a key for a dictionary");

            Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
            reader.Read();

            if (reader.TokenType == JsonTokenType.Null)
                return null;

            if (reader.TokenType != JsonTokenType.StartObject)
                throw new InvalidOperationException("Expected StartObject token");

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new InvalidOperationException("Expected PropertyName token");

                var propertyName = reader.GetString();
                reader.Read();
                dictionary.Add((TKey)converter(propertyName), reader.GetObject<TValue>(options));
            }

            return dictionary;
        }

        public static T GetObject<T>(this ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            var typeToConvert = typeof(T);

            if (_readerActions.TryGetValue(typeToConvert, out var readValue))
            {
                return (T)readValue(ref reader);
            }

            var model = Activator.CreateInstance(typeToConvert, true) as IModelJsonSerializable<T>;
            if (model is null)
                throw new InvalidOperationException($"{typeToConvert.Name} does not implement {nameof(IModelJsonSerializable<T>)}");

            return (T)model.Deserialize(ref reader, options);
        }

        public static bool TryDeserialize<T>(this ref Utf8JsonReader reader, ModelSerializerOptions options, PropertySetter<T> setProperty, out T properties)
            where T : new()
        {
            properties = new T();

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                reader.Read();
                if (reader.TokenType == JsonTokenType.Null)
                    return false;
            }

            if (reader.TokenType != JsonTokenType.StartObject)
                throw new FormatException("Expected StartObject token");

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new FormatException("Expected PropertyName token");

                setProperty(reader.ValueSpan, ref properties, ref reader, options);
            }

            return true;
        }

        public delegate void PropertySetter2(ReadOnlySpan<byte> propertyName, ref Utf8JsonReader reader, ModelSerializerOptions options);

        public static bool TryDeserialize(this ref Utf8JsonReader reader, ModelSerializerOptions options, PropertySetter2 setProperty)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                reader.Read();
                if (reader.TokenType == JsonTokenType.Null)
                    return false;
            }

            if (reader.TokenType != JsonTokenType.StartObject)
                throw new FormatException("Expected StartObject token");

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new FormatException("Expected PropertyName token");

                setProperty(reader.ValueSpan, ref reader, options);
            }

            return true;
        }
    }
}
