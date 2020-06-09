// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Models
{
    // Hide the untyped SuggestDocumentsResult
    [CodeGenModel("SuggestDocumentsResult")]
    internal partial class SuggestDocumentsResult { }

    /// <summary>
    /// Response containing suggestion query results from an index.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
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

        #pragma warning disable CS1572 // Not all parameters will be used depending on feature flags
        /// <summary>
        /// Deserialize the SuggestResults.
        /// </summary>
        /// <param name="json">A JSON stream.</param>
        /// <param name="serializer">
        /// Optional serializer that can be used to customize the serialization
        /// of strongly typed models.
        /// </param>
        /// <param name="async">Whether to execute sync or async.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>Deserialized SuggestResults.</returns>
        internal static async Task<SuggestResults<T>> DeserializeAsync(
            Stream json,
#if EXPERIMENTAL_SERIALIZER
            ObjectSerializer serializer,
#endif
            bool async,
            CancellationToken cancellationToken)
        #pragma warning restore CS1572
        {
            // Parse the JSON
            using JsonDocument doc = async ?
                await JsonDocument.ParseAsync(json, cancellationToken: cancellationToken).ConfigureAwait(false) :
                JsonDocument.Parse(json);

            JsonSerializerOptions defaultSerializerOptions = JsonSerialization.SerializerOptions;

            SuggestResults<T> suggestions = new SuggestResults<T>();
            foreach (JsonProperty prop in doc.RootElement.EnumerateObject())
            {
                if (prop.NameEquals(Constants.SearchCoverageKeyJson.EncodedUtf8Bytes) &&
                    prop.Value.ValueKind != JsonValueKind.Null)
                {
                    suggestions.Coverage = prop.Value.GetDouble();
                }
                else if (prop.NameEquals(Constants.ValueKeyJson.EncodedUtf8Bytes))
                {
                    foreach (JsonElement element in prop.Value.EnumerateArray())
                    {
                        SearchSuggestion<T> suggestion = await SearchSuggestion<T>.DeserializeAsync(
                            element,
#if EXPERIMENTAL_SERIALIZER
                            serializer,
#endif
                            defaultSerializerOptions,
                            async,
                            cancellationToken)
                            .ConfigureAwait(false);
                        suggestions.Results.Add(suggestion);
                    }
                }
            }
            return suggestions;
        }
    }

    public static partial class SearchModelFactory
    {
        /// <summary> Initializes a new instance of SearchResult. </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type can
        /// be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="results"></param>
        /// <param name="coverage"></param>
        /// <returns>A new SuggestResults instance for mocking.</returns>
        public static SuggestResults<T> SuggestResults<T>(
            IList<SearchSuggestion<T>> results,
            double? coverage) =>
            new SuggestResults<T>() { Coverage = coverage, Results = results };
    }
}
