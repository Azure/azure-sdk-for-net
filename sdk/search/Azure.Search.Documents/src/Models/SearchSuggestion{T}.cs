// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Models
{
    // Hide the untyped SuggestResult
    [CodeGenSchema("SuggestResult")]
    internal partial class SuggestResult { }

    /// <summary>
    /// A result containing a document found by a suggestion query, plus
    /// associated metadata.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    [JsonConverter(typeof(SearchSuggestionConverterFactory))]
    public class SearchSuggestion<T>
    {
        /// <summary>
        /// The text of the suggestion result.
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        /// The document being suggested.
        /// </summary>
        public T Document { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the SearchSuggestion class.
        /// </summary>
        internal SearchSuggestion() { }
    }

    /// <summary>
    /// JsonConverterFactory to create closed instances of
    /// <see cref="SuggestResultsConverter{T}"/>.
    /// </summary>
    internal class SearchSuggestionConverterFactory : ModelConverterFactory
    {
        protected override Type GenericType => typeof(SearchSuggestion<>);
        protected override Type GenericConverterType => typeof(SearchSuggestionConverter<>);
    }

    /// <summary>
    /// Convert from JSON to <see cref="SearchSuggestion{T}"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    internal class SearchSuggestionConverter<T> : JsonConverter<SearchSuggestion<T>>
    {
        /// <summary>
        /// Serializing SearchSuggestion isn't supported as it's an output only
        /// model type.  This always fails.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The suggestion.</param>
        /// <param name="options">Serialization options.</param>
        public override void Write(Utf8JsonWriter writer, SearchSuggestion<T> value, JsonSerializerOptions options) =>
            throw new NotSupportedException($"{nameof(SearchSuggestion<T>)} cannot be serialized to JSON.");

        /// <summary>
        /// Parse a SearchSuggestion and its model.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type to parse into.</param>
        /// <param name="options">Serialization options.</param>
        /// <returns>The deserialized suggestion.</returns>
        public override SearchSuggestion<T> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            Debug.Assert(options != null);
            SearchSuggestion<T> suggestion = new SearchSuggestion<T>();

            // Clone the reader so we can get the search text property without
            // advancing the reader over any properties needed to deserialize
            // the user's model type.
            Utf8JsonReader clone = reader;
            clone.Expects(JsonTokenType.StartObject);
            while (clone.Read() && clone.TokenType != JsonTokenType.EndObject)
            {
                string name = clone.ExpectsPropertyName();
                if (name == Constants.SearchTextKey)
                {
                    suggestion.Text = clone.ExpectsString();
                    break;
                }
            }

            // Deserialize the model
            T document = JsonSerializer.Deserialize<T>(ref reader, options);
            suggestion.Document = document;

            return suggestion;
        }
    }
}
