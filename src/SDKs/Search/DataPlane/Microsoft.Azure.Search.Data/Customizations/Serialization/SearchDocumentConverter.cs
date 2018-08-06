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

    /// <summary>
    /// Deserializes SearchResult instances from OData-compliant JSON.
    /// </summary>
    /// <typeparam name="TDoc">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    internal class SearchDocumentConverter<TDoc> : JsonConverter
         where TDoc : class, new()
    {
        private static readonly string[] EmptyStringArray = new string[0];

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(SearchDocument).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            SearchDocument result = new SearchDocument();

            JObject propertyBag = serializer.Deserialize<JObject>(reader);

            JToken score = propertyBag["@search.score"];
            JToken highlights = propertyBag["@search.highlights"];

            result.Score = score.Value<double>();

            if (highlights != null)
            {
                var highlightReader = new JTokenReader(highlights);
                result.Highlights = serializer.Deserialize<HitHighlights>(highlightReader);
            }

            var docReader = new JTokenReader(propertyBag);
            result.Document = serializer.Deserialize<TDoc>(docReader);

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
