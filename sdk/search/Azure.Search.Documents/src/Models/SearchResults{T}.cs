// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Models
{
    // Hide the untyped SearchDocumentsResult
    [CodeGenSchema("SearchDocumentsResult")]
    internal partial class SearchDocumentsResult { }

    /// <summary>
    /// Response containing search results from an index.
    /// </summary>
    [JsonConverter(typeof(SearchResultsConverterFactory))]
    public class SearchResults<T>
    {
        /// <summary>
        /// The total count of results found by the search operation, or null
        /// if the count was not requested via
        /// <see cref="SearchOptions.IncludeTotalCount"/>.  If present, the
        /// count may be greater than the number of results in this response.
        /// This can happen if you use the <see cref="SearchOptions.Size"/> or
        /// <see cref="SearchOptions.Skip"/> parameters, or if Azure Cognitive
        /// Search can't return all the requested documents in a single Search
        /// response.
        /// </summary>
        public long? TotalCount { get; internal set; }

        /// <summary>
        /// A value indicating the percentage of the index that was included in
        /// the query, or null if <see cref="SearchOptions.MinimumCoverage"/>
        /// was not specified in the request.
        /// </summary>
        public double? Coverage { get; internal set; }

        /// <summary>
        /// The facet query results for the search operation, organized as a
        /// collection of buckets for each faceted field; null if the query did
        /// not include any facet expressions via
        /// <see cref="SearchOptions.Facets"/>.
        /// </summary>
        public IDictionary<string, IList<FacetResult>> Facets { get; internal set; }

        /// <summary>
        /// Gets the first (server side) page of search result values.
        /// </summary>
        internal IList<SearchResult<T>> Values { get; } = new List<SearchResult<T>>();

        /// <summary>
        /// Gets or sets the fully constructed URI for the next page of
        /// results.
        /// </summary>
        internal Uri NextUri { get; set; }

        /// <summary>
        /// Gets or sets the SearchOptions required to fetch the next page of
        /// results.
        /// </summary>
        internal SearchOptions NextOptions { get; set; }

        /// <summary>
        /// Gets the raw Response that obtained these results from the service.
        /// This is only used when paging.
        /// </summary>
        internal Response RawResponse { get; private set; }

        /// <summary>
        /// The IndexClient used to fetch the next page of results.  This is
        /// only used when paging.
        /// </summary>
        private SearchIndexClient _indexClient;

        /// <summary>
        /// Initializes a new instance of the SearchResults class.
        /// </summary>
        internal SearchResults() { }

        /// <summary>
        /// Get all of the <see cref="SearchResult{T}"/>s synchronously.
        /// </summary>
        /// <returns>The search results.</returns>
        public Pageable<SearchResult<T>> GetResults() =>
            new SearchPageable<T>(this);

        /// <summary>
        /// Get all of the <see cref="SearchResult{T}"/>s asynchronously.
        /// </summary>
        /// <returns>The search results.</returns>
        public AsyncPageable<SearchResult<T>> GetResultsAsync() =>
            new SearchAsyncPageable<T>(this);

        /// <summary>
        /// Initialize the state needed to allow paging.
        /// </summary>
        /// <param name="client">
        /// The SearchIndexClient to make requests.
        /// </param>
        /// <param name="rawResponse">
        /// The raw response that obtained these results.
        /// </param>
        internal void ConfigurePaging(SearchIndexClient client, Response rawResponse)
        {
            Debug.Assert(client != null);
            Debug.Assert(rawResponse != null);
            _indexClient = client;
            RawResponse = rawResponse;
        }

        /// <summary>
        /// Get the next (server-side) page of results.
        /// </summary>
        /// <param name="async">
        /// Whether to execute synchronously or asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>The next page of SearchResults.</returns>
        internal async Task<SearchResults<T>> GetNextPageAsync(bool async, CancellationToken cancellationToken)
        {
            SearchResults<T> next = null;
            if (_indexClient != null && NextOptions != null)
            {
                next = async ?
                    await _indexClient.SearchAsync<T>(
                        NextOptions.SearchText,
                        NextOptions,
                        cancellationToken)
                        .ConfigureAwait(false) :
                    _indexClient.Search<T>(
                        NextOptions.SearchText,
                        NextOptions,
                        cancellationToken);
            }
            return next;
        }
    }

    /// <summary>
    /// A page of <see cref="SearchResult{T}"/>s returned from
    /// <see cref="SearchResults{T}.GetResultsAsync"/>'s
    /// <see cref="AsyncPageable{T}.AsPages(string, int?)"/> method.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    public class SearchResultsPage<T> : Page<SearchResult<T>>
    {
        private SearchResults<T> _results;
        private IReadOnlyList<SearchResult<T>> _values;

        internal SearchResultsPage(SearchResults<T> results)
        {
            Debug.Assert(results != null);
            _results = results;
        }

        /// <summary>
        /// The total count of results found by the search operation, or null
        /// if the count was not requested via
        /// <see cref="SearchOptions.IncludeTotalCount"/>.  If present, the
        /// count may be greater than the number of results in this response.
        /// This can happen if you use the <see cref="SearchOptions.Size"/> or
        /// <see cref="SearchOptions.Skip"/> parameters, or if Azure Cognitive
        /// Search can't return all the requested documents in a single Search
        /// response.
        /// </summary>
        public long? TotalCount => _results.TotalCount;

        /// <summary>
        /// A value indicating the percentage of the index that was included in
        /// the query, or null if <see cref="SearchOptions.MinimumCoverage"/>
        /// was not specified in the request.
        /// </summary>
        public double? Coverage => _results.Coverage;

        /// <summary>
        /// The facet query results for the search operation, organized as a
        /// collection of buckets for each faceted field; null if the query did
        /// not include any facet expressions via
        /// <see cref="SearchOptions.Facets"/>.
        /// </summary>
        public IDictionary<string, IList<FacetResult>> Facets => _results.Facets;

        /// <inheritdoc />
        public override IReadOnlyList<SearchResult<T>> Values =>
            _values ??= new ReadOnlyCollection<SearchResult<T>>(_results.Values);

        // TODO: #10590 - Add durable continuation tokens
        #pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
        /// <inheritdoc />
        public override string ContinuationToken => throw new NotImplementedException();
        #pragma warning restore CA1065

        /// <inheritdoc />
        public override Response GetRawResponse() => _results.RawResponse;
    }

    /// <summary>
    /// <see cref="AsyncPageable{T}"/> of <see cref="SearchResult{T}"/>s
    /// returned from <see cref="SearchResults{T}.GetResultsAsync"/> to
    /// enumerate all of the search results.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    internal class SearchAsyncPageable<T> : AsyncPageable<SearchResult<T>>
    {
        private SearchResults<T> _results;
        public SearchAsyncPageable(SearchResults<T> results)
        {
            Debug.Assert(results != null);
            _results = results;
        }

        /// <inheritdoc />
        public override async IAsyncEnumerable<Page<SearchResult<T>>> AsPages(string continuationToken = default, int? pageSizeHint = default)
        {
            SearchResults<T> initial = _results; // TODO: #10590 - Add durable continuation tokens
            for (SearchResults<T> results = initial;
                 results != null;
                 results = await results.GetNextPageAsync(async: true, CancellationToken).ConfigureAwait(false))
            {
                yield return new SearchResultsPage<T>(results);
            }
        }
    }

    /// <summary>
    /// <see cref="Pageable{T}"/> of <see cref="SearchResult{T}"/>s returned
    /// from <see cref="SearchResults{T}.GetResults"/> to enumerate all of the
    /// search results.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    internal class SearchPageable<T> : Pageable<SearchResult<T>>
    {
        private SearchResults<T> _results;
        public SearchPageable(SearchResults<T> results)
        {
            Debug.Assert(results != null);
            _results = results;
        }

        /// <inheritdoc />
        public override IEnumerable<Page<SearchResult<T>>> AsPages(string continuationToken = default, int? pageSizeHint = default)
        {
            SearchResults<T> initial = _results; // TODO: #10590 - Add durable continuation tokens
            for (SearchResults<T> results = initial;
                 results != null;
                 results = results.GetNextPageAsync(async: false, CancellationToken).EnsureCompleted())
            {
                yield return new SearchResultsPage<T>(results);
            }
        }
    }

    /// <summary>
    /// JsonConverterFactory to create closed instances of
    /// <see cref="SearchResultsConverter{T}"/>.
    /// </summary>
    internal class SearchResultsConverterFactory : ModelConverterFactory
    {
        protected override Type GenericType => typeof(SearchResults<>);
        protected override Type GenericConverterType => typeof(SearchResultsConverter<>);
        protected override bool ConstructWithOptions => true;
    }

    /// <summary>
    /// Convert from JSON to <see cref="SearchResults{T}"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema. Instances of this type can
    /// be retrieved as documents from the index.
    /// </typeparam>
    internal class SearchResultsConverter<T> : JsonConverter<SearchResults<T>>
    {
        private Type _resultType;
        private readonly JsonConverter<SearchResult<T>> _resultConverter;

        /// <summary>
        /// Initializes a new instance of the SearchResultsConverter class.
        /// </summary>
        /// <param name="options">Serialization options.</param>
        public SearchResultsConverter(JsonSerializerOptions options)
        {
            Debug.Assert(options != null);

            // Cache the SearchResult<T> converter
            _resultConverter = (JsonConverter<SearchResult<T>>)options.GetConverter(typeof(SearchResult<T>));
            _resultType = typeof(SearchResult<T>);
        }

        /// <summary>
        /// Serializing SearchResults isn't supported as it's an output only
        /// model type.  This always fails.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The search result.</param>
        /// <param name="options">Serialization options.</param>
        public override void Write(Utf8JsonWriter writer, SearchResults<T> value, JsonSerializerOptions options) =>
            throw new NotSupportedException($"{nameof(SearchResults<T>)} cannot be serialized to JSON.");

        /// <summary>
        /// Parse the SearchResults and its search results.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type to parse into.</param>
        /// <param name="options">Serialization options.</param>
        /// <returns>The deserialized search results.</returns>
        public override SearchResults<T> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert != null);
            Debug.Assert(typeToConvert.IsAssignableFrom(typeof(SearchResults<T>)));
            Debug.Assert(options != null);

            SearchResults<T> results = new SearchResults<T>();
            reader.Expects(JsonTokenType.StartObject);
            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                switch (reader.ExpectsPropertyName())
                {
                    case Constants.ODataCountKey:
                        results.TotalCount = reader.ExpectsNullableLong();
                        break;
                    case Constants.SearchCoverageKey:
                        results.Coverage = reader.ExpectsNullableDouble();
                        break;
                    case Constants.SearchFacetsKey:
                        ReadFacets(ref reader, results, options);
                        break;
                    case Constants.ODataNextLinkKey:
                        results.NextUri = new Uri(reader.ExpectsString());
                        break;
                    case Constants.SearchNextPageKey:
                        results.NextOptions = ReadNextPageOptions(ref reader);
                        break;
                    case Constants.ValueKey:
                        reader.Expects(JsonTokenType.StartArray);
                        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                        {
                            SearchResult<T> result = _resultConverter.Read(ref reader, _resultType, options);
                            results.Values.Add(result);
                        }
                        break;
                    default:
                        // Ignore other properties (including OData context, etc.)
                        reader.Skip();
                        break;
                }
            }
            return results;
        }

        /// <summary>
        /// Read the @search.facets property value.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="results">The SearchResults to add the facets to.</param>
        /// <param name="options">JSON serializer options.</param>
        private static void ReadFacets(
            ref Utf8JsonReader reader,
            SearchResults<T> results,
            JsonSerializerOptions options)
        {
            Debug.Assert(results != null);

            // Facets are optional, so short circuit if nothing is found
            if (reader.TokenType == JsonTokenType.Null)
            {
                return;
            }

            results.Facets = new Dictionary<string, IList<FacetResult>>();
            reader.Expects(JsonTokenType.StartObject);
            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                // Get the name of the facet
                string facetName = reader.ExpectsPropertyName();

                // Get the values of the facet
                List<FacetResult> facets = new List<FacetResult>();
                reader.Expects(JsonTokenType.StartArray);
                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    FacetResult facet = ReadFacetResult(ref reader, options);
                    facets.Add(facet);
                }

                // Add the facet to the results
                results.Facets[facetName] = facets;
            }
        }

        /// <summary>
        /// Read the facet result value.
        /// </summary>
        /// <param name="reader">JSON reader.</param>
        /// <param name="options">Serializer options.</param>
        /// <returns>The facet result.</returns>
        private static FacetResult ReadFacetResult(
            ref Utf8JsonReader reader,
            JsonSerializerOptions options)
        {
            FacetResult facet = new FacetResult();
            reader.Expects(JsonTokenType.StartObject);
            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                // Get the name of the facet property
                string facetName = reader.ExpectsPropertyName();
                if (facetName == Constants.CountKey)
                {
                    facet.Count = reader.ExpectsNullableLong();
                }
                else
                {
                    object value = reader.ReadObject(options);
                    facet[facetName] = value;
                }
            }
            return facet;
        }

        /// <summary>
        /// Read the @search.nextPageParameters property value.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <returns>The next SearchOptions.</returns>
        private static SearchOptions ReadNextPageOptions(ref Utf8JsonReader reader)
        {
            // Next page options aren't required, so short circuit if nothing
            // is found
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            // Use the generated SearchOptions parsing code
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return SearchOptions.DeserializeSearchOptions(doc.RootElement);
        }
    }
}
