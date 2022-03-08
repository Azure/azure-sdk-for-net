// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;

namespace Azure
{
    /// <summary>
    /// Extensions that can be used for serialization.
    /// </summary>
    public static class AzureCoreExtensions
    {
        /// <summary>
        /// Converts the <see cref="BinaryData"/> to the specified type using
        /// the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="data">The <see cref="BinaryData"/> instance to convert.</param>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        ///<returns>The data converted to the specified type.</returns>
        public static T? ToObject<T>(this BinaryData data, ObjectSerializer serializer, CancellationToken cancellationToken = default) =>
            (T?)serializer.Deserialize(data.ToStream(), typeof(T), cancellationToken);

        /// <summary>
        /// Converts the <see cref="BinaryData"/> to the specified type using
        /// the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="data">The <see cref="BinaryData"/> instance to convert.</param>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        ///<returns>The data converted to the specified type.</returns>
        public static async ValueTask<T?> ToObjectAsync<T>(this BinaryData data, ObjectSerializer serializer, CancellationToken cancellationToken = default) =>
            (T?)await serializer.DeserializeAsync(data.ToStream(), typeof(T), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Converts the <see cref="BinaryData"/> to a Dictionary of string to object.
        /// Each value in the key value pair will be strongly typed as an int, long, string, Guid, double or bool.
        /// Each value can also be another Dictionary of string object representing an inner object or
        /// a List of objects representing an array.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> instance to convert.</param>
        /// <returns>The data converted to the Dictionary of string to object.</returns>
        public static Dictionary<string, object?> ToDictionaryFromJson(this BinaryData data)
        {
            Utf8JsonReader reader = new Utf8JsonReader(data);
            reader.Read();
            Dictionary<string, object?> result = new Dictionary<string, object?>();
            ParseObject(ref reader, result);
            return result;
        }

        private static void ParseObject(ref Utf8JsonReader reader, Dictionary<string, object?> result)
        {
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.Comment:
                        break;
                    case JsonTokenType.EndArray:
                        return;
                    case JsonTokenType.EndObject:
                        return;
                    case JsonTokenType.None:
                        break;
                    case JsonTokenType.PropertyName:
                        var propertyName = reader.GetString();
                        if (propertyName is null)
                            throw new InvalidOperationException("Property name was null while parsing json");
                        reader.Read();
                        var value = GetValueKind(ref reader);
                        result.Add(propertyName, value);
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid token type found {reader.TokenType}");
                }
            }
        }

        private static void FillList(ref Utf8JsonReader reader, List<object?> list)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                    break;

                list.Add(GetValueKind(ref reader));
            }
        }

        private static object? GetValueKind(ref Utf8JsonReader reader)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.False:
                    return false;
                case JsonTokenType.True:
                    return true;
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.Number:
                    return GetNumberValue(ref reader);
                case JsonTokenType.String:
                    return GetStringValue(ref reader);
                case JsonTokenType.StartObject:
                    var inner = new Dictionary<string, object?>();
                    ParseObject(ref reader, inner);
                    return inner;
                case JsonTokenType.StartArray:
                    var list = new List<object?>();
                    FillList(ref reader, list);
                    return list;
                default:
                    throw new InvalidOperationException($"Invalid token type found getting value {reader.TokenType}");
            }
        }

        private static object? GetStringValue(ref Utf8JsonReader reader)
        {
            if (reader.TryGetGuid(out var guidValue))
            {
                return guidValue;
            }
            return reader.GetString();
        }

        private static object? GetNumberValue(ref Utf8JsonReader reader)
        {
            if (reader.TryGetInt32(out var int32Value))
            {
                return int32Value;
            }
            else if (reader.TryGetInt64(out var int64Value))
            {
                return int64Value;
            }
            else if (reader.TryGetDouble(out var doubleValue))
            {
                return doubleValue;
            }
            else
            {
                throw new InvalidOperationException("Unsupported number type found");
            }
        }
    }
}
