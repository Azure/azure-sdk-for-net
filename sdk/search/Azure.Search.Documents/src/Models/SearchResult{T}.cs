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
    // Hide the untyped SearchResult
    [CodeGenSchema("SearchResult")]
    internal partial class SearchResult { }

    /// <summary>
    /// Contains a document found by a search query, plus associated metadata.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    [JsonConverter(typeof(SearchResultConverterFactory))]
    public class SearchResult<T>
    {
        /// <summary>
        /// The relevance score of the document compared to other documents
        /// returned by the query.
        /// </summary>
        public double? Score { get; internal set; }

        /// <summary>
        /// Text fragments from the document that indicate the matching search
        /// terms, organized by each applicable field; null if hit highlighting
        /// was not enabled for the query.
        /// </summary>
        public IDictionary<string, IList<string>> Highlights { get; internal set; }

        /// <summary>
        /// The document found by the search query.
        /// </summary>
        public T Document { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the SearchResult class.
        /// </summary>
        internal SearchResult() { }
    }

    /// <summary>
    /// JsonConverterFactory to create closed instances of
    /// <see cref="SuggestResultsConverter{T}"/>.
    /// </summary>
    internal class SearchResultConverterFactory : ModelConverterFactory
    {
        protected override Type GenericType => typeof(SearchResult<>);
        protected override Type GenericConverterType => typeof(SuggestResultConverter<>);
    }

    /// <summary>
    /// Convert from JSON to <see cref="SearchResult{T}"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    internal class SuggestResultConverter<T> : JsonConverter<SearchResult<T>>
    {
        /// <summary>
        /// Serializing SearchResult isn't supported as it's an output only
        /// model type.  This always fails.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The search result.</param>
        /// <param name="options">Serialization options.</param>
        public override void Write(Utf8JsonWriter writer, SearchResult<T> value, JsonSerializerOptions options) =>
            throw new NotSupportedException($"{nameof(SearchResult<T>)} cannot be serialized to JSON.");

        /// <summary>
        /// Parse a SearchResult and its model.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type to parse into.</param>
        /// <param name="options">Serialization options.</param>
        /// <returns>The deserialized search result.</returns>
        public override SearchResult<T> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            Debug.Assert(options != null);
            SearchResult<T> result = new SearchResult<T>();

            // Clone the reader so we can get the search text property without
            // advancing the reader over any properties needed to deserialize
            // the user's model type.
            Utf8JsonReader clone = reader;

            // Keep track of the properties we've found so we can stop reading
            // through the cloned object
            bool parsedScore = false;
            bool parsedHighlights = false;

            clone.Expects(JsonTokenType.StartObject);
            while (
                (!parsedScore || !parsedHighlights) &&
                clone.Read() &&
                clone.TokenType != JsonTokenType.EndObject)
            {
                string name = clone.ExpectsPropertyName();
                if (name == Constants.SearchScoreKey)
                {
                    parsedScore = true;
                    result.Score = clone.ExpectsNullableDouble();
                }
                else if (name == Constants.SearchHighlightsKey)
                {
                    parsedHighlights = true;
                    ReadHighlights(ref clone, result);
                }
                else
                {
                    // Skip the rest of the next property's value
                    clone.Skip();
                }
            }

            // Deserialize the model
            T document = JsonSerializer.Deserialize<T>(ref reader, options);
            result.Document = document;

            return result;
        }

        /// <summary>
        /// Read the @search.highlights property value.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="result">The SearchResult to add the highlights to.</param>
        private static void ReadHighlights(ref Utf8JsonReader reader, SearchResult<T> result)
        {
            Debug.Assert(result != null);
            result.Highlights = new Dictionary<string, IList<string>>();
            reader.Expects(JsonTokenType.StartObject);
            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                // Get the highlight field name
                string name = reader.ExpectsPropertyName();

                // Get the highlight values
                List<string> values = new List<string>();
                reader.Expects(JsonTokenType.StartArray);
                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    values.Add(reader.ExpectsString());
                }

                // Add the highlight
                result.Highlights[name] = values;
            }
        }
    }
}
