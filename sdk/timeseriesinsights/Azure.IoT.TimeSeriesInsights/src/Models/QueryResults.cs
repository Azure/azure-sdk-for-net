// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// </summary>
    public class QueryResults
    {
        private CancellationToken _cancellationToken;

        private readonly QueryRequest _queryRequest;
        private readonly string _storeType;
        private readonly QueryRestClient _queryClient;
        private readonly HashSet<EventProperty> _eventProperties;

        /// <summary>
        /// Initializes a new instance of the QueryResults class.
        /// </summary>
        internal QueryResults() { }

        /// <summary>
        /// </summary>
        /// <param name="queryClient"></param>
        /// <param name="queryRequest"></param>
        /// <param name="storeType"></param>
        /// <param name="cancellationToken"></param>
        internal QueryResults(QueryRestClient queryClient, QueryRequest queryRequest, string storeType, CancellationToken cancellationToken)
        {
            _queryRequest = queryRequest;
            _storeType = storeType;
            _cancellationToken = cancellationToken;
            _queryClient = queryClient;
            _eventProperties = new HashSet<EventProperty>();
        }

        /// <summary>
        /// </summary>
        /// <returns>The search results.</returns>
        public AsyncPageable<TimeSeriesPoint> GetResultsAsync()
        {
            async Task<Page<TimeSeriesPoint>> FirstPageFunc(int? pageSizeHint)
            {
                try
                {
                    Response<QueryResultPage> response = await _queryClient
                        .ExecuteAsync(_queryRequest, _storeType, null, null, _cancellationToken)
                        .ConfigureAwait(false);

                    TimeSeriesPoint[] points = QueryHelper.CreateQueryResponse(response.Value, _eventProperties);

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

                    TimeSeriesPoint[] points = QueryHelper.CreateQueryResponse(response.Value, _eventProperties);

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
        /// </summary>
        /// <returns></returns>
        public Pageable<TimeSeriesPoint> GetResults()
        {
            Page<TimeSeriesPoint> FirstPageFunc(int? pageSizeHint)
            {
                try
                {
                    Response<QueryResultPage> response = _queryClient
                        .Execute(_queryRequest, _storeType, null, null, _cancellationToken);

                    TimeSeriesPoint[] points = QueryHelper.CreateQueryResponse(response.Value, _eventProperties);

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

                    TimeSeriesPoint[] points = QueryHelper.CreateQueryResponse(response.Value, _eventProperties);

                    return Page.FromValues(points, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string[] GetUniquePropertyNames()
        {
            return _eventProperties.Select((eventProperty) => eventProperty.Name).Distinct().ToArray();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public EventProperty[] GetProperties()
        {
            return _eventProperties.ToArray();
        }
    }
}
