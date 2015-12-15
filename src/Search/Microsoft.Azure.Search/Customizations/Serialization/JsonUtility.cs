// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    internal static class JsonUtility
    {
        public static readonly JsonSerializerSettings DefaultSerializerSettings = CreateDefaultSettings();

        public static readonly JsonSerializerSettings DocumentSerializerSettings = 
            CreateSerializerSettings<Document>(useCamelCase: false);

        public static readonly JsonSerializerSettings DocumentDeserializerSettings =
            CreateDeserializerSettings<SearchResult, SuggestResult, Document>();

        private static readonly IContractResolver CamelCaseResolver =
            new ValueTypePreservingContractResolver(new CamelCasePropertyNamesContractResolver());

        private static readonly IContractResolver DefaultResolver =
            new ValueTypePreservingContractResolver(new DefaultContractResolver());

        public static JsonSerializerSettings CreateDefaultSettings()
        {
            return new JsonSerializerSettings()
            {
                ContractResolver = CamelCaseResolver,
                Converters = new JsonConverter[]
                {
                    new StringEnumConverter() { CamelCaseText = true }
                },
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
        }

        public static JsonSerializerSettings CreateSerializerSettings<T>(bool useCamelCase) where T : class
        {
            return new JsonSerializerSettings()
            {
                ContractResolver = useCamelCase ? CamelCaseResolver : DefaultResolver,
                Converters = new JsonConverter[]
                { 
                    new GeographyPointConverter(),
                    new IndexActionConverter<T>(),
                    new DateTimeConverter()
                },
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
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
            return new JsonSerializerSettings()
            {
                ContractResolver = DefaultResolver,
                Converters = new JsonConverter[]
                { 
                    new GeographyPointConverter(),
                    new DocumentConverter(),
                    new DateTimeConverter(),
                    new SearchResultConverter<TSearchResult, TDoc>(),
                    new SuggestResultConverter<TSuggestResult, TDoc>()
                },
                DateParseHandling = DateParseHandling.DateTimeOffset
            };
        }
    }
}
