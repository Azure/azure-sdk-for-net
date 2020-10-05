// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    // Hide the untyped SuggestResult
    [CodeGenModel("SuggestResult")]
    internal partial class SuggestResult { }

    /// <summary>
    /// A result containing a document found by a suggestion query, plus
    /// associated metadata.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
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

        #pragma warning disable CS1572 // Not all parameters will be used depending on feature flags
        /// <summary>
        /// Deserialize a SearchSuggestion and its model.
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
        /// <returns>Deserialized SearchSuggestion.</returns>
        internal static async Task<SearchSuggestion<T>> DeserializeAsync(
            JsonElement element,
            ObjectSerializer serializer,
            JsonSerializerOptions options,
            bool async,
            CancellationToken cancellationToken)
        #pragma warning restore CS1572
        {
            Debug.Assert(options != null);

            SearchSuggestion<T> suggestion = new SearchSuggestion<T>();
            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals(Constants.SearchTextKeyJson.EncodedUtf8Bytes))
                {
                    suggestion.Text = prop.Value.GetString();
                    break; // We only have one non-model property
                }
            }

            // Deserialize the model
            if (serializer != null)
            {
                using Stream stream = element.ToStream();
                T document = async ?
                    (T)await serializer.DeserializeAsync(stream, typeof(T), cancellationToken).ConfigureAwait(false) :
                    (T)serializer.Deserialize(stream, typeof(T), cancellationToken);
                suggestion.Document = document;
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
                suggestion.Document = document;
            }

            return suggestion;
        }
    }

    public static partial class SearchModelFactory
    {
        /// <summary> Initializes a new instance of SearchSuggestion. </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type can
        /// be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="document">The document being suggested.</param>
        /// <param name="text">The text of the suggestion result.</param>
        /// <returns>A new SuggestResults instance for mocking.</returns>
        public static SearchSuggestion<T> SearchSuggestion<T>(
            T document,
            string text) =>
            new SearchSuggestion<T>() { Document = document, Text = text };
    }
}
