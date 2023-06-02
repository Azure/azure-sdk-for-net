// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Dynamic;
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
        public static object? ToObjectFromJson(this BinaryData data)
        {
            JsonElement element = data.ToObjectFromJson<JsonElement>();
            return element.GetObject();
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// <paramref name="newPropertyConversion">A value that specifies how to convert the names of properties that are newly added to the dynamic object.
        /// New properties can be added in two ways.  The first is by setting a property on the dynamic object that wasn't present in the JSON content prior to
        /// the set operation.  In this case, the conversion specified by this parameter will be applied to the property name used in the set operation when setting
        /// the property in the data content.  The second way is by setting a new or existing property in the JSON content to an instance of a .NET object that has
        /// properties.  In this case, the conversion specified by this parameter will be applied to all property names in the object graph when serializing the
        /// value to JSON.</paramref>
        /// <paramref name="existingPropertyLookup">A value that specifies how to retrieve existing properties by name from the JSON content the returned
        /// dynamic object represents.  Passing <see cref="PropertyNameLookup.Strict"/> indicates that the property name used to get or set the existing property should be
        /// used exactly when looking up the JSON value.  Passing <see cref="PropertyNameLookup.AllowPascalCase"/> indicates that a "PascalCase" property name used to
        /// get or set an existing property may be used to retrieve a "camelCase" property name from the JSON content.</paramref>
        /// <paramref name="dateTimeHandling"></paramref>
        /// </summary>
        public static dynamic ToDynamicFromJson(this BinaryData utf8Json, PropertyNameConversion newPropertyConversion = PropertyNameConversion.None, PropertyNameLookup existingPropertyLookup = PropertyNameLookup.AllowPascalCase, DateTimeHandling dateTimeHandling = DateTimeHandling.Rfc3339)
        {
            DynamicDataOptions options = new()
            {
                NewPropertyConversion = newPropertyConversion,
                ExistingPropertyLookup = existingPropertyLookup,
                DateTimeHandling = dateTimeHandling
            };

            return utf8Json.ToDynamicFromJson(options);
        }

        /// <summary>
        /// Return the content of the BinaryData as a dynamic type.
        /// </summary>
        internal static dynamic ToDynamicFromJson(this BinaryData utf8Json, DynamicDataOptions options)
        {
            MutableJsonDocument mdoc = MutableJsonDocument.Parse(utf8Json, DynamicData.GetSerializerOptions(options));
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
