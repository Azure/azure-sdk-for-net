// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Models
{
    // Hide the untyped SuggestDocumentsResult
    [CodeGenSchema("SuggestDocumentsResult")]
    internal partial class SuggestDocumentsResult { }

    /// <summary>
    /// Response containing suggestion query results from an index.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    [JsonConverter(typeof(SuggestResultsConverterFactory))]
    public partial class SuggestResults<T>
    {
        /// <summary>
        /// A value indicating the percentage of the index that was included in
        /// the query, or null if minimumCoverage was not set in the request.
        /// </summary>
        public double? Coverage { get; internal set; }

        /// <summary>
        /// The sequence of suggestions returned by the query.
        /// </summary>
        public IList<SearchSuggestion<T>> Results { get; internal set; } =
            new List<SearchSuggestion<T>>();

        /// <summary>
        /// Initializes a new instance of the SuggestResults class.
        /// </summary>
        internal SuggestResults() { }
    }

    /// <summary>
    /// JsonConverterFactory to create closed instances of
    /// <see cref="SuggestResultsConverter{T}"/>.
    /// </summary>
    internal class SuggestResultsConverterFactory : ModelConverterFactory
    {
        protected override Type GenericType => typeof(SuggestResults<>);
        protected override Type GenericConverterType => typeof(SuggestResultsConverter<>);
        protected override bool ConstructWithOptions => true;
    }

    /// <summary>
    /// Convert from JSON to <see cref="SuggestResults{T}"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    internal class SuggestResultsConverter<T> : JsonConverter<SuggestResults<T>>
    {
        private Type _suggestionType;
        private readonly JsonConverter<SearchSuggestion<T>> _suggestionConverter;

        /// <summary>
        /// Initializes a new instance of the SuggestResultsConverter class.
        /// </summary>
        /// <param name="options">Serialization options.</param>
        public SuggestResultsConverter(JsonSerializerOptions options)
        {
            Debug.Assert(options != null);

            // Cache the SearchSuggestion<T> converter
            _suggestionConverter = (JsonConverter<SearchSuggestion<T>>)options.GetConverter(typeof(SearchSuggestion<T>));
            _suggestionType = typeof(SearchSuggestion<T>);
        }

        /// <summary>
        /// Serializing SuggestResults isn't supported as it's an output only
        /// model type.  This always fails.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The suggestion.</param>
        /// <param name="options">Serialization options.</param>
        public override void Write(Utf8JsonWriter writer, SuggestResults<T> value, JsonSerializerOptions options) =>
            throw new NotSupportedException($"{nameof(SuggestResults<T>)} cannot be serialized to JSON.");

        /// <summary>
        /// Parse the SuggestResults and its suggestions.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type to parse into.</param>
        /// <param name="options">Serialization options.</param>
        /// <returns>The deserialized suggestions.</returns>
        public override SuggestResults<T> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert != null);
            Debug.Assert(typeToConvert.IsAssignableFrom(typeof(SuggestResults<T>)));
            Debug.Assert(options != null);

            SuggestResults<T> suggestions = new SuggestResults<T>();
            reader.Expects(JsonTokenType.StartObject);
            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                switch (reader.ExpectsPropertyName())
                {
                    case Constants.SearchCoverageKey:
                        suggestions.Coverage = reader.ExpectsNullableDouble();
                        break;
                    case Constants.ValueKey:
                        reader.Expects(JsonTokenType.StartArray);
                        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                        {
                            SearchSuggestion<T> suggestion =
                                _suggestionConverter.Read(ref reader, _suggestionType, options);
                            suggestions.Results.Add(suggestion);
                        }
                        break;
                    default:
                        // Ignore other properties (including OData context, etc.)
                        reader.Skip();
                        break;
                }
            }
            return suggestions;
        }
    }
}
