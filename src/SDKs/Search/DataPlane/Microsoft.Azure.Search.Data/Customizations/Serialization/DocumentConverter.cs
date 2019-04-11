// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
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
    internal class DocumentConverter : JsonConverter
    {
        private static readonly string[] EmptyStringArray = new string[0];

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

                object value;
                switch (field.Value)
                {
                    case null:
                        value = null;
                        break;

                    case JArray array:
                        value = ConvertArray(array, serializer);
                        break;

                    case JObject _:
                        var tokenReader = new JTokenReader(field.Value);

                        // Assume GeoPoint for now.
                        value = serializer.Deserialize<GeographyPoint>(tokenReader);
                        break;

                    default:
                        value = field.Value.ToObject(typeof(object), serializer);
                        break;
                }

                result[field.Name] = value;
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

        private static object[] ConvertArray(JArray array, JsonSerializer serializer)
        {
            if (array.Count == 0)
            {
                // Assume string arrays for now.
                return EmptyStringArray;
            }

            // There are two cases to consider: Either everything is a string, or it's not. If not, don't attempt
            // any conversions and return everything in an object array.
            return array.All(t => t.Type == JTokenType.String || t.Type == JTokenType.Null) ? 
                array.Select(t => t.Value<string>()).ToArray() : 
                array.Select(t => t.ToObject(typeof(object), serializer)).ToArray();
        }
    }
}
