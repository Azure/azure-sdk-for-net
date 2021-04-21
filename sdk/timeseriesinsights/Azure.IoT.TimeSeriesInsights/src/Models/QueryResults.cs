// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Time Series Insights query results.
    /// </summary>
    public class QueryResults
    {
        private CancellationToken _cancellationToken;

        private readonly QueryRequest _queryRequest;
        private readonly QueryRestClient _queryClient;
        private readonly string _storeType;

        /// <summary>
        /// Initializes a new instance of the QueryResults class.
        /// </summary>
        /// <param name="queryClient">The query REST client that talks to TSI service.</param>
        /// <param name="queryRequest">The query request payload.</param>
        /// <param name="storeType">The store the query should be executed on.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        internal QueryResults(QueryRestClient queryClient, QueryRequest queryRequest, string storeType, CancellationToken cancellationToken)
        {
            _queryRequest = queryRequest;
            _storeType = storeType;
            _cancellationToken = cancellationToken;
            _queryClient = queryClient;
        }

        /// <summary>
        /// Get all of the <see cref="TimeSeriesPoint"/> asynchronously.
        /// </summary>
        /// <returns>The search results represented as <see cref="TimeSeriesPoint"/>.</returns>
        public AsyncPageable<TimeSeriesPoint> GetResultsAsync()
        {
            async Task<Page<TimeSeriesPoint>> FirstPageFunc(int? pageSizeHint)
            {
                try
                {
                    Response<QueryResultPage> response = await _queryClient
                        .ExecuteAsync(_queryRequest, _storeType, null, null, _cancellationToken)
                        .ConfigureAwait(false);

                    TimeSeriesPoint[] points = QueryHelper.CreateQueryResponse(response.Value);

                    return Page.FromValues(points, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception)
                {
                    throw;
                }
            }

            async Task<Page<TimeSeriesPoint>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                try
                {
                    Response<QueryResultPage> response = await _queryClient
                        .ExecuteAsync(_queryRequest, _storeType, nextLink, null, _cancellationToken)
                        .ConfigureAwait(false);

                    TimeSeriesPoint[] points = QueryHelper.CreateQueryResponse(response.Value);

                    return Page.FromValues(points, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Get all of the <see cref="TimeSeriesPoint"/> synchronously.
        /// </summary>
        /// <returns>The search results represented as <see cref="TimeSeriesPoint"/>.</returns>
        public Pageable<TimeSeriesPoint> GetResults()
        {
            Page<TimeSeriesPoint> FirstPageFunc(int? pageSizeHint)
            {
                try
                {
                    Response<QueryResultPage> response = _queryClient
                        .Execute(_queryRequest, _storeType, null, null, _cancellationToken);

                    TimeSeriesPoint[] points = QueryHelper.CreateQueryResponse(response.Value);

                    return Page.FromValues(points, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception)
                {
                    throw;
                }
            }

            Page<TimeSeriesPoint> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                try
                {
                    Response<QueryResultPage> response = _queryClient
                        .Execute(_queryRequest, _storeType, nextLink, null, _cancellationToken);

                    TimeSeriesPoint[] points = QueryHelper.CreateQueryResponse(response.Value);

                    return Page.FromValues(points, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
