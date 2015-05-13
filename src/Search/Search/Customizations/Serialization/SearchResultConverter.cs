// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using Microsoft.Azure.Search.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Search.Serialization
{
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
            return typeof(TResult).IsAssignableFrom(objectType);
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
