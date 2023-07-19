// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Search.Serialization
{
    /// <summary>
    /// Deserializes JSON objects and arrays to .NET types instead of JObject and JArray.
    /// </summary>
    /// <remarks>
    /// This JSON converter supports reading only. When deserializing JSON to an instance of type <see cref="Document" />, it will
    /// recursively deserialize JSON objects to <see cref="Document" /> instances as well. This includes object properties as well
    /// as arrays of objects. It also makes a best-effort attempt to deserialize JSON arrays to a specific .NET array type. Heterogenous
    /// arrays are deserialized to arrays of <see cref="System.Object" />.
    /// </remarks>
    internal class DocumentConverter : JsonConverter
    {
        private static readonly object[] EmptyObjectArray = new object[0];

        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) =>
            typeof(Document).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = new Document();
            JObject bag = serializer.Deserialize<JObject>(reader);

            foreach (JProperty field in bag.Properties())
            {
                // Skip OData @search annotations. These are deserialized separately.
                if (field.Name.StartsWith("@search.", StringComparison.Ordinal))
                {
                    continue;
                }

                object value =
                    (field.Value is JArray array) ?
                        ConvertArray(array, serializer) :
                        ConvertToken(field.Value, serializer);

                result[field.Name] = value;
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

        private static object ConvertToken(JToken token, JsonSerializer serializer)
        {
            switch (token)
            {
                case JObject obj:
                    var tokenReader = new JTokenReader(obj);
                    return obj.IsGeoJsonPoint() ?
                        serializer.Deserialize<GeographyPoint>(tokenReader) :
                        (object)serializer.Deserialize<Document>(tokenReader);

                default:
                    return token.ToObject(typeof(object), serializer);
            }
        }

        private static Array ConvertArray(JArray array, JsonSerializer serializer)
        {
            if (array.Count < 1)
            {
                // With no type information, assume type object.
                return EmptyObjectArray;
            }

            Tuple<bool, T> ConvertToReferenceType<T>(JToken token, bool allowNull) where T : class
            {
                switch (ConvertToken(token, serializer))
                {
                    case T typedValue:
                        return Tuple.Create(true, typedValue);

                    case null when allowNull:
                        return Tuple.Create(true, (T)null);

                    default:
                        return Tuple.Create(false, (T)null);
                }
            }

            Tuple<bool, T> ConvertToValueType<T>(JToken token) where T : struct
            {
                switch (ConvertToken(token, serializer))
                {
                    case T typedValue:
                        return Tuple.Create(true, typedValue);

                    default:
                        return Tuple.Create(false, default(T));
                }
            }

            Array ConvertToArrayOfType<T>(Func<JToken, Tuple<bool, T>> convert)
            {
                var typedValues = new T[array.Count];

                // Explicit loop ensures only one pass through the array.
                for (int i = 0; i < typedValues.Length; i++)
                {
                    JToken token = array[i];

                    // Avoiding ValueTuple for now to avoid taking an extra dependency.
                    Tuple<bool, T> convertResult = convert(token);
                    bool wasConverted = convertResult.Item1;
                    T typedValue = convertResult.Item2;

                    if (wasConverted)
                    {
                        typedValues[i] = typedValue;
                    }
                    else
                    {
                        // As soon as we see something other than the expected type, give up on the typed array and build an object array.
                        IEnumerable<JToken> remainingTokens = array.Skip(i);
                        IEnumerable<object> remainingObjects = remainingTokens.Select(t => ConvertToken(t, serializer));
                        return typedValues.Take(i).Cast<object>().Concat(remainingObjects).ToArray();
                    }
                }

                return typedValues;
            }

            Array ConvertToArrayOfReferenceType<T>(bool allowNull = false) where T : class =>
                ConvertToArrayOfType<T>(t => ConvertToReferenceType<T>(t, allowNull));

            Array ConvertToArrayOfValueType<T>() where T : struct => ConvertToArrayOfType<T>(ConvertToValueType<T>);

            // We need to figure out the best-fit type for the array based on the data that's been deserialized so far.
            // We can do this by checking the first element. Note that null as a first element is a special case for
            // backward compatibility.
            switch (array[0].Type)
            {
                case JTokenType.Null:
                case JTokenType.String:
                    // Arrays of all nulls or a mixture of strings and nulls are treated as string arrays for backward compatibility.
                    return ConvertToArrayOfReferenceType<string>(allowNull: true);

                case JTokenType.Boolean:
                    return ConvertToArrayOfValueType<bool>();

                case JTokenType.Integer:
                    return ConvertToArrayOfValueType<long>();

                case JTokenType.Float:
                    return ConvertToArrayOfValueType<double>();

                case JTokenType.Date:
                    return ConvertToArrayOfValueType<DateTimeOffset>();

                case JTokenType.Object:
                    return ((JObject)array[0]).IsGeoJsonPoint() ?
                        ConvertToArrayOfReferenceType<GeographyPoint>() :
                        ConvertToArrayOfReferenceType<Document>();

                default:
                    return array.Select(t => ConvertToken(t, serializer)).ToArray();
            }
        }
    }
}
