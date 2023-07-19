// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Allows a user to query for pages of data.
    /// </summary>
    public class TimeSeriesQueryAnalyzer
    {
        private readonly QueryRequest _queryRequest;
        private readonly QueryRestClient _queryClient;
        private readonly string _storeType;
        private CancellationToken _cancellationToken;

        /// <summary>
        /// Approximate progress of the query in percentage. It can be between 0 and 100. When the continuation token in the response is null,
        /// the progress is expected to be 100.
        /// </summary>
        public double? Progress { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the TimeSeriesQueryAnalyzer class.
        /// </summary>
        /// <param name="queryClient">The query REST client that talks to the Time Series Insights service.</param>
        /// <param name="queryRequest">The query request payload.</param>
        /// <param name="storeType">The store the query should be executed on.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        internal TimeSeriesQueryAnalyzer(QueryRestClient queryClient, QueryRequest queryRequest, string storeType, CancellationToken cancellationToken)
        {
            _queryRequest = queryRequest;
            _storeType = storeType;
            _cancellationToken = cancellationToken;
            _queryClient = queryClient;
            Progress = 0;
        }

        /// <summary>
        /// Get all of the <see cref="TimeSeriesPoint"/> in pages asynchronously.
        /// </summary>
        /// <returns>The pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/> of time series points.</returns>
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

                    Progress = response.Value.Progress;

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

                    Progress = response.Value.Progress;

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
        /// Get all of the <see cref="TimeSeriesPoint"/> in pages synchronously.
        /// </summary>
        /// <returns>The pageable list <see cref="Pageable{TimeSeriesPoint}"/> of time series points.</returns>
        public Pageable<TimeSeriesPoint> GetResults()
        {
            Page<TimeSeriesPoint> FirstPageFunc(int? pageSizeHint)
            {
                try
                {
                    Response<QueryResultPage> response = _queryClient
                        .Execute(_queryRequest, _storeType, null, null, _cancellationToken);

                    TimeSeriesPoint[] points = QueryHelper.CreateQueryResponse(response.Value);

                    Progress = response.Value.Progress;

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

                    Progress = response.Value.Progress;

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
