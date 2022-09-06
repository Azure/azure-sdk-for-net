// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Models
{
    // Hide the untyped SearchResult
    [CodeGenModel("SearchResult")]
    internal partial class SearchResult { }

    /// <summary>
    /// Contains a document found by a search query, plus associated metadata.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
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

        #pragma warning disable CS1572 // Not all parameters will be used depending on feature flags
        /// <summary>
        /// Deserialize a SearchResult and its model.
        /// </summary>
        /// <param name="element">A JSON element.</param>
        /// <param name="serializer">
        /// Optional serializer that can be used to customize the serialization
        /// of strongly typed models.
        /// </param>
        /// <param name="options">JSON serializer options.</param>
        /// <param name="async">Whether to execute sync or async.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>Deserialized SearchResults.</returns>
        internal static async Task<SearchResult<T>> DeserializeAsync(
            JsonElement element,
            ObjectSerializer serializer,
            JsonSerializerOptions options,
            bool async,
            CancellationToken cancellationToken)
        #pragma warning restore CS1572
        {
            Debug.Assert(options != null);
            SearchResult<T> result = new SearchResult<T>();
            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals(Constants.SearchScoreKeyJson.EncodedUtf8Bytes) &&
                    prop.Value.ValueKind != JsonValueKind.Null)
                {
                    result.Score = prop.Value.GetDouble();
                }
                else if (prop.NameEquals(Constants.SearchHighlightsKeyJson.EncodedUtf8Bytes))
                {
                    result.Highlights = new Dictionary<string, IList<string>>();
                    foreach (JsonProperty highlight in prop.Value.EnumerateObject())
                    {
                        // Add the highlight values
                        List<string> values = new List<string>();
                        result.Highlights[highlight.Name] = values;
                        foreach (JsonElement highlightValue in highlight.Value.EnumerateArray())
                        {
                            values.Add(highlightValue.GetString());
                        }
                    }
                }
            }

            // Deserialize the model
            if (serializer != null)
            {
                using Stream stream = element.ToStream();
                T document = async ?
                    (T)await serializer.DeserializeAsync(stream, typeof(T), cancellationToken).ConfigureAwait(false) :
                    (T)serializer.Deserialize(stream, typeof(T), cancellationToken);
                result.Document = document;
            }
            else
            {
                T document;
                if (async)
                {
                    using Stream stream = element.ToStream();
                    document = await JsonSerializer.DeserializeAsync<T>(stream, options, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    document = JsonSerializer.Deserialize<T>(element.GetRawText(), options);
                }
                result.Document = document;
            }

            return result;
        }
    }

    public static partial class SearchModelFactory
    {
        /// <summary> Initializes a new instance of SearchResult. </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type can
        /// be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="document">The document found by the search query.</param>
        /// <param name="score">
        /// The relevance score of the document compared to other documents
        /// returned by the query.
        /// </param>
        /// <param name="highlights">
        /// Text fragments from the document that indicate the matching search
        /// terms, organized by each applicable field; null if hit highlighting
        /// was not enabled for the query.
        /// </param>
        /// <returns>A new SearchResult instance for mocking.</returns>
        public static SearchResult<T> SearchResult<T>(
            T document,
            double? score,
            IDictionary<string, IList<string>> highlights) =>
            new SearchResult<T>()
            {
                Score = score,
                Highlights = highlights,
                Document = document };
    }
}
