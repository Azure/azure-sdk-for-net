﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents.Models
{
    // Hide the untyped SearchDocumentsResult
    [CodeGenModel("SearchDocumentsResult")]
    internal partial class SearchDocumentsResult { }

    /// <summary>
    /// Response containing search results from an index.
    /// </summary>
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

        /// <summary> The answers query results for the search operation;
        /// <c>null</c> if the <see cref="SearchOptions.QueryAnswer"/> parameter was not specified or set to <see cref="QueryAnswer.None"/>. </summary>
        public IList<AnswerResult> Answers { get; internal set; }

        /// <summary>
        /// Gets the first (server side) page of search result values.
        /// </summary>
        internal List<SearchResult<T>> Values { get; } = new List<SearchResult<T>>();

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
        internal Response RawResponse { get; set; }

        /// <summary>
        /// The SearchClient used to fetch the next page of results.  This is
        /// only used when paging.
        /// </summary>
        private SearchClient _pagingClient;

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
        /// The SearchClient to make requests.
        /// </param>
        /// <param name="rawResponse">
        /// The raw response that obtained these results.
        /// </param>
        internal void ConfigurePaging(SearchClient client, Response rawResponse)
        {
            Debug.Assert(client != null);
            Debug.Assert(rawResponse != null);
            _pagingClient = client;
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
            if (_pagingClient != null && NextOptions != null)
            {
                next = async ?
                    await _pagingClient.SearchAsync<T>(
                        NextOptions.SearchText,
                        NextOptions,
                        cancellationToken)
                        .ConfigureAwait(false) :
                    _pagingClient.Search<T>(
                        NextOptions.SearchText,
                        NextOptions,
                        cancellationToken);
            }
            return next;
        }

        #pragma warning disable CS1572 // Not all parameters will be used depending on feature flags
        /// <summary>
        /// Deserialize the SearchResults.
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
        /// <returns>Deserialized SearchResults.</returns>
        internal static async Task<SearchResults<T>> DeserializeAsync(
            Stream json,
            ObjectSerializer serializer,
            bool async,
            CancellationToken cancellationToken)
        #pragma warning restore CS1572
        {
            // Parse the JSON
            using JsonDocument doc = async ?
                await JsonDocument.ParseAsync(json, cancellationToken: cancellationToken).ConfigureAwait(false) :
                JsonDocument.Parse(json);

            JsonSerializerOptions defaultSerializerOptions = JsonSerialization.SerializerOptions;

            SearchResults<T> results = new SearchResults<T>();
            foreach (JsonProperty prop in doc.RootElement.EnumerateObject())
            {
                if (prop.NameEquals(Constants.ODataCountKeyJson.EncodedUtf8Bytes) &&
                    prop.Value.ValueKind != JsonValueKind.Null)
                {
                    results.TotalCount = prop.Value.GetInt64();
                }
                else if (prop.NameEquals(Constants.SearchCoverageKeyJson.EncodedUtf8Bytes) &&
                    prop.Value.ValueKind != JsonValueKind.Null)
                {
                    results.Coverage = prop.Value.GetDouble();
                }
                else if (prop.NameEquals(Constants.SearchFacetsKeyJson.EncodedUtf8Bytes))
                {
                    results.Facets = new Dictionary<string, IList<FacetResult>>();
                    foreach (JsonProperty facetObject in prop.Value.EnumerateObject())
                    {
                        // Get the values of the facet
                        List<FacetResult> facets = new List<FacetResult>();
                        foreach (JsonElement facetValue in facetObject.Value.EnumerateArray())
                        {
                            Dictionary<string, object> facetValues = new Dictionary<string, object>();
                            long? facetCount = null;
                            foreach (JsonProperty facetProperty in facetValue.EnumerateObject())
                            {
                                if (facetProperty.NameEquals(Constants.CountKeyJson.EncodedUtf8Bytes))
                                {
                                    if (facetProperty.Value.ValueKind != JsonValueKind.Null)
                                    {
                                        facetCount = facetProperty.Value.GetInt64();
                                    }
                                }
                                else
                                {
                                    object value = facetProperty.Value.GetSearchObject();
                                    facetValues[facetProperty.Name] = value;
                                }
                            }
                            facets.Add(new FacetResult(facetCount, facetValues));
                        }
                        // Add the facet to the results
                        results.Facets[facetObject.Name] = facets;
                    }
                }
                else if (prop.NameEquals(Constants.ODataNextLinkKeyJson.EncodedUtf8Bytes))
                {
                    results.NextUri = new Uri(prop.Value.GetString());
                }
                else if (prop.NameEquals(Constants.SearchNextPageKeyJson.EncodedUtf8Bytes))
                {
                    results.NextOptions = SearchOptions.DeserializeSearchOptions(prop.Value);
                }
                else if (prop.NameEquals(Constants.SearchAnswersKeyJson.EncodedUtf8Bytes) &&
                    prop.Value.ValueKind != JsonValueKind.Null)
                {
                    results.Answers = new List<AnswerResult>();
                    foreach (JsonElement answerValue in prop.Value.EnumerateArray())
                    {
                        results.Answers.Add(AnswerResult.DeserializeAnswerResult(answerValue));
                    }
                }
                else if (prop.NameEquals(Constants.ValueKeyJson.EncodedUtf8Bytes))
                {
                    foreach (JsonElement element in prop.Value.EnumerateArray())
                    {
                        SearchResult<T> result = await SearchResult<T>.DeserializeAsync(
                            element,
                            serializer,
                            defaultSerializerOptions,
                            async,
                            cancellationToken)
                            .ConfigureAwait(false);
                        results.Values.Add(result);
                    }
                }
            }
            return results;
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

        /// <inheritdoc />
        public override string ContinuationToken =>
            SearchContinuationToken.Serialize(_results.NextUri, _results.NextOptions);

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
            // The first page of our results is always provided so we can
            // ignore the continuation token.  Users can only provide a token
            // directly to the Search method.
            Debug.Assert(continuationToken == null);

            SearchResults<T> initial = _results;
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
            // The first page of our results is always provided so we can
            // ignore the continuation token.  Users can only provide a token
            // directly to the Search method.
            Debug.Assert(continuationToken == null);

            SearchResults<T> initial = _results;
            for (SearchResults<T> results = initial;
                 results != null;
                 results = results.GetNextPageAsync(async: false, CancellationToken).EnsureCompleted())
            {
                yield return new SearchResultsPage<T>(results);
            }
        }
    }

    public static partial class SearchModelFactory
    {
        /// <summary> Initializes a new instance of SearchResults. </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type can
        /// be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="values">The search result values.</param>
        /// <param name="totalCount">The total count of results found by the search operation.</param>
        /// <param name="facets">The facet query results for the search operation.</param>
        /// <param name="coverage">A value indicating the percentage of the index that was included in the query</param>
        /// <param name="rawResponse">The raw Response that obtained these results from the service.</param>
        /// <returns>A new SearchResults instance for mocking.</returns>
        public static SearchResults<T> SearchResults<T>(
            IEnumerable<SearchResult<T>> values,
            long? totalCount,
            IDictionary<string, IList<FacetResult>> facets,
            double? coverage,
            Response rawResponse)
        {
            var results = new SearchResults<T>()
            {
                TotalCount = totalCount,
                Coverage = coverage,
                Facets = facets,
                RawResponse = rawResponse
            };
            results.Values.AddRange(values);
            return results;
        }

        /// <summary> Initializes a new instance of SearchResultsPage. </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type can
        /// be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="results">The search results for this page.</param>
        /// <returns>A new SearchResultsPage instance for mocking.</returns>
        public static SearchResultsPage<T> SearchResultsPage<T>(
            SearchResults<T> results) =>
            new SearchResultsPage<T>(results);
    }
}
