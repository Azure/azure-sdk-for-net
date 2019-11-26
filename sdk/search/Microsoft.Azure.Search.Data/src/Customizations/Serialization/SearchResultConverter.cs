// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Serialization
{
    using System;
    using System.Reflection;
    using Microsoft.Azure.Search.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using HitHighlights = System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>>;

    /// <summary>
    /// Deserializes SearchResult instances from OData-compliant JSON.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    internal class SearchResultConverter<T> : JsonConverter
    {
        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) =>
            typeof(SearchResult<T>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject propertyBag = serializer.Deserialize<JObject>(reader);

            HitHighlights DeserializeHighlights()
            {
                JToken highlights = propertyBag["@search.highlights"];

                if (highlights != null)
                {
                    var highlightReader = new JTokenReader(highlights);
                    return serializer.Deserialize<HitHighlights>(highlightReader);
                }

                return null;
            }

            T DeserializeDocument()
            {
                var docReader = new JTokenReader(propertyBag);
                return serializer.Deserialize<T>(docReader);
            }

            JToken score = propertyBag["@search.score"];
            return new SearchResult<T>(
                document: DeserializeDocument(), 
                score: score.Value<double>(), 
                highlights: DeserializeHighlights());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}
