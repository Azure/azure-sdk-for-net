// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Json;
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
        /// Converts the json value represented by <see cref="BinaryData"/> to an object of a specific type.
        /// </summary>
        /// <param name="data">The <see cref="BinaryData"/> instance to convert.</param>
        /// <returns> The object value of the json value.
        /// If the object contains a primitive type such as string, int, double, bool, or null literal, it returns that type.
        /// Otherwise, it returns either an object[] or Dictionary&lt;string, object&gt;.
        /// Each value in the key value pair or list will also be converted into a primitive or another complex type recursively.
        /// </returns>
        [RequiresUnreferencedCode(DynamicData.SerializationRequiresUnreferencedCode)]
        [RequiresDynamicCode(DynamicData.SerializationRequiresUnreferencedCode)]
        public static object? ToObjectFromJson(this BinaryData data)
        {
            JsonElement element = data.ToObjectFromJson<JsonElement>();
            return element.GetObject();
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.  Please see https://aka.ms/azsdk/net/dynamiccontent for details.
        /// </summary>
        [RequiresUnreferencedCode(DynamicData.SerializationRequiresUnreferencedCode)]
        [RequiresDynamicCode(DynamicData.SerializationRequiresUnreferencedCode)]
        public static dynamic ToDynamicFromJson(this BinaryData utf8Json)
        {
            DynamicDataOptions options = new DynamicDataOptions();
            return utf8Json.ToDynamicFromJson(options);
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.  Please see https://aka.ms/azsdk/net/dynamiccontent for details.
        /// <paramref name="propertyNameFormat">The format of property names in the JSON content.
        /// This value indicates to the dynamic type that it can convert property names on the returned value to this format in the underlying JSON.
        /// Please see https://aka.ms/azsdk/net/dynamiccontent#use-c-naming-conventions for details.
        /// </paramref>
        /// <paramref name="dateTimeFormat">The standard format specifier to pass when serializing DateTime and DateTimeOffset values in the JSON content.
        /// To serialize to unix time, pass the value <code>"x"</code> and
        /// see <see href="https://learn.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings">https://learn.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings#table-of-format-specifiers</see> for other well known values.
        /// </paramref>
        /// </summary>
        [RequiresUnreferencedCode(DynamicData.SerializationRequiresUnreferencedCode)]
        [RequiresDynamicCode(DynamicData.SerializationRequiresUnreferencedCode)]
        public static dynamic ToDynamicFromJson(this BinaryData utf8Json, JsonPropertyNames propertyNameFormat, string dateTimeFormat = DynamicData.RoundTripFormat)
        {
            DynamicDataOptions options = new DynamicDataOptions()
            {
                PropertyNameFormat = propertyNameFormat,
                DateTimeFormat = dateTimeFormat
            };

            return utf8Json.ToDynamicFromJson(options);
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        [RequiresUnreferencedCode(DynamicData.SerializationRequiresUnreferencedCode)]
        [RequiresDynamicCode(DynamicData.SerializationRequiresUnreferencedCode)]
        internal static dynamic ToDynamicFromJson(this BinaryData utf8Json, DynamicDataOptions options)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(utf8Json, DynamicDataOptions.ToSerializerOptions(options));
            return new DynamicData(mdoc.RootElement, options);
        }

        private static object? GetObject(in this JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    if (element.TryGetInt32(out int intValue))
                    {
                        return intValue;
                    }
                    if (element.TryGetInt64(out long longValue))
                    {
                        return longValue;
                    }
                    return element.GetDouble();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.Object:
                    var dictionary = new Dictionary<string, object?>();
                    foreach (JsonProperty jsonProperty in element.EnumerateObject())
                    {
                        dictionary.Add(jsonProperty.Name, jsonProperty.Value.GetObject());
                    }
                    return dictionary;
                case JsonValueKind.Array:
                    var list = new List<object?>();
                    foreach (JsonElement item in element.EnumerateArray())
                    {
                        list.Add(item.GetObject());
                    }
                    return list.ToArray();
                default:
                    throw new NotSupportedException("Not supported value kind " + element.ValueKind);
            }
        }
    }
}
