// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Collections.Generic;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Rest.Serialization;

    internal static class JsonUtility
    {
        private static readonly IContractResolver CamelCaseResolver = new CamelCasePropertyNamesContractResolver();

        private static readonly IContractResolver DefaultResolver = new DefaultContractResolver();

        public static JsonSerializerSettings CreateTypedSerializerSettings<T>(
            JsonSerializerSettings baseSettings,
            bool useCamelCase) where T : class
        {
            return CreateSerializerSettings<T>(baseSettings, useCamelCase);
        }

        public static JsonSerializerSettings CreateTypedDeserializerSettings<T>(JsonSerializerSettings baseSettings)
            where T : class
        {
            return CreateDeserializerSettings<SearchResult<T>, SuggestResult<T>, T>(baseSettings);
        }

        public static JsonSerializerSettings CreateDocumentSerializerSettings(JsonSerializerSettings baseSettings)
        {
            return CreateSerializerSettings<Document>(baseSettings, useCamelCase: false);
        }

        public static JsonSerializerSettings CreateDocumentDeserializerSettings(JsonSerializerSettings baseSettings)
        {
            return CreateDeserializerSettings<SearchResult, SuggestResult, Document>(baseSettings);
        }

        private static JsonSerializerSettings CreateSerializerSettings<T>(
            JsonSerializerSettings baseSettings, 
            bool useCamelCase) where T : class
        {
            JsonSerializerSettings settings = CopySettings(baseSettings);
            settings.Converters.Add(new GeographyPointConverter());
            settings.Converters.Add(new IndexActionConverter<T>());
            settings.Converters.Add(new DateTimeConverter());
            settings.NullValueHandling = NullValueHandling.Ignore;

            if (useCamelCase)
            {
                settings.ContractResolver = CamelCaseResolver;
            }
            else if (settings.ContractResolver is ReadOnlyJsonContractResolver)
            {
                settings.ContractResolver = DefaultResolver;
            }

            return settings;
        }

        private static JsonSerializerSettings CreateDeserializerSettings<TSearchResult, TSuggestResult, TDoc>(
            JsonSerializerSettings baseSettings)
            where TSearchResult : SearchResultBase<TDoc>, new()
            where TSuggestResult : SuggestResultBase<TDoc>, new()
            where TDoc : class
        {
            JsonSerializerSettings settings = CopySettings(baseSettings);
            settings.Converters.Add(new GeographyPointConverter());
            settings.Converters.Add(new DocumentConverter());
            settings.Converters.Add(new DateTimeConverter());
            settings.Converters.Add(new SearchResultConverter<TSearchResult, TDoc>());
            settings.Converters.Add(new SuggestResultConverter<TSuggestResult, TDoc>());
            settings.DateParseHandling = DateParseHandling.DateTimeOffset;

            // Fail when deserializing null into a non-nullable type. This is to avoid silent data corruption issues.
            settings.NullValueHandling = NullValueHandling.Include;

            if (settings.ContractResolver is ReadOnlyJsonContractResolver)
            {
                settings.ContractResolver = DefaultResolver;
            }

            return settings;
        }

        private static JsonSerializerSettings CopySettings(JsonSerializerSettings baseSettings)
        {
            return new JsonSerializerSettings()
            {
                Binder = baseSettings.Binder,
                CheckAdditionalContent = baseSettings.CheckAdditionalContent,
                ConstructorHandling = baseSettings.ConstructorHandling,
                Context = baseSettings.Context,
                ContractResolver = baseSettings.ContractResolver,
                Converters = new List<JsonConverter>(baseSettings.Converters),
                Culture = baseSettings.Culture,
                DateFormatHandling = baseSettings.DateFormatHandling,
                DateFormatString = baseSettings.DateFormatString,
                DateParseHandling = baseSettings.DateParseHandling,
                DateTimeZoneHandling = baseSettings.DateTimeZoneHandling,
                DefaultValueHandling = baseSettings.DefaultValueHandling,
                Error = baseSettings.Error,
                FloatFormatHandling = baseSettings.FloatFormatHandling,
                FloatParseHandling = baseSettings.FloatParseHandling,
                Formatting = baseSettings.Formatting,
                MaxDepth = baseSettings.MaxDepth,
                MetadataPropertyHandling = baseSettings.MetadataPropertyHandling,
                MissingMemberHandling = baseSettings.MissingMemberHandling,
                NullValueHandling = baseSettings.NullValueHandling,
                ObjectCreationHandling = baseSettings.ObjectCreationHandling,
                PreserveReferencesHandling = baseSettings.PreserveReferencesHandling,
                ReferenceLoopHandling = baseSettings.ReferenceLoopHandling,
                StringEscapeHandling = baseSettings.StringEscapeHandling,
                TraceWriter = baseSettings.TraceWriter,
                TypeNameHandling = baseSettings.TypeNameHandling,
                TypeNameAssemblyFormat = baseSettings.TypeNameAssemblyFormat
            };
        }
    }
}
