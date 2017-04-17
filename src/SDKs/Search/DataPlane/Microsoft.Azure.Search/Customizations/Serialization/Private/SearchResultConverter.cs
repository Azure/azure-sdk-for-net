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
    /// <typeparam name="TResult">
    /// Type of the model class that encapsulates documents in a search response.
    /// </typeparam>
    internal class SearchResultConverter<TResult, TDoc> : JsonConverter
        where TResult : SearchResultBase<TDoc>, new()
        where TDoc : class
    {
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(TResult).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            JObject propertyBag = serializer.Deserialize<JObject>(reader);
            JToken score = propertyBag["@search.score"];
            JToken highlights = propertyBag["@search.highlights"];

            var result = new TResult();
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
