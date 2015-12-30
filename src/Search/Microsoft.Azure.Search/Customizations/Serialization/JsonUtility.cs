// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    internal static class JsonUtility
    {
        private static readonly IContractResolver CamelCaseResolver = new CamelCasePropertyNamesContractResolver();

        private static readonly IContractResolver DefaultResolver = new DefaultContractResolver();

        public static JsonSerializerSettings CreateTypedSerializerSettings<T>(
            JsonSerializerSettings baseSettings,
            bool useCamelCase) where T : class
        {
            // TODO: Merge settings
            return CreateSerializerSettings<T>(useCamelCase);
        }

        public static JsonSerializerSettings CreateTypedDeserializerSettings<T>(JsonSerializerSettings baseSettings)
            where T : class
        {
            // TODO: Merge settings
            return CreateDeserializerSettings<SearchResult<T>, SuggestResult<T>, T>();
        }

        public static JsonSerializerSettings CreateDocumentSerializerSettings(JsonSerializerSettings baseSettings)
        {
            // TODO: Merge settings
            return CreateSerializerSettings<Document>(useCamelCase: false);
        }

        public static JsonSerializerSettings CreateDocumentDeserializerSettings(JsonSerializerSettings baseSettings)
        {
            // TODO: Merge settings
            return CreateDeserializerSettings<SearchResult, SuggestResult, Document>();
        }

        private static JsonSerializerSettings CreateSerializerSettings<T>(bool useCamelCase) where T : class
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
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
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
