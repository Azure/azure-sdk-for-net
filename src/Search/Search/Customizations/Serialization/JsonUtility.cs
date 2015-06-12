﻿// 
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

using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.Search
{
    internal static class JsonUtility
    {
        public static readonly JsonSerializerSettings DocumentSerializerSettings = 
            CreateSerializerSettings<Document>(useCamelCase: false);

        public static readonly JsonSerializerSettings DocumentDeserializerSettings =
            CreateDeserializerSettings<SearchResult, SuggestResult, Document>();

        public static JsonSerializerSettings CreateSerializerSettings<T>(bool useCamelCase) where T : class
        {
            var settings =
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    Converters = new JsonConverter[]
                    { 
                        new GeographyPointConverter(),
                        new IndexActionConverter<T>(),
                        new DateTimeConverter()
                    },
                    DefaultValueHandling = DefaultValueHandling.Ignore
                };

            if (useCamelCase)
            {
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }

            return settings;
        }

        public static JsonSerializerSettings CreateTypedDeserializerSettings<T>() where T : class
        {
            return CreateDeserializerSettings<SearchResult<T>, SuggestResult<T>, T>();
        }

        private static JsonSerializerSettings CreateDeserializerSettings<TSearchResult, TSuggestResult, TDoc>()
            where TSearchResult : SearchResultBase<TDoc>, new()
            where TSuggestResult : SuggestResultBase<TDoc>, new()
            where TDoc : class
        {
            var settings =
                new JsonSerializerSettings()
                {
                    DateParseHandling = DateParseHandling.DateTimeOffset,
                    Converters = new JsonConverter[]
                    { 
                        new GeographyPointConverter(),
                        new DocumentConverter(),
                        new SearchResultConverter<TSearchResult, TDoc>(),
                        new SuggestResultConverter<TSuggestResult, TDoc>()
                    }
                };

            return settings;
        }
    }
}
