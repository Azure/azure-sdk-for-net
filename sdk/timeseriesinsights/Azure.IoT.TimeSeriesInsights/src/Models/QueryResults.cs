// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// .
    /// </summary>
    public class QueryResults
    {
        private QueryRequest _queryRequest;
        private string _storeType;
        private CancellationToken _cancellationToken;
        private QueryRestClient _queryClient;
        private readonly HashSet<EventProperty> _eventProperties;

        /// <summary>
        /// Initializes a new instance of the QueryResults class.
        /// </summary>
        internal QueryResults() { }

        /// <summary>
        /// ctor.
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
        public Pageable<TimeSeriesPoint> GetPageableResults()
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
    }
}
