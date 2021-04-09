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
    public class QueryAsyncResults
    {
        private QueryRequest _queryRequest;
        private string _storeType;
        private CancellationToken _cancellationToken;
        private QueryRestClient _queryClient;
        private HashSet<EventProperty> _eventProperties;
        private Dictionary<string, List<object>> _allPropertyValues;

        /// <summary>
        /// Initializes a new instance of the QueryResults class.
        /// </summary>
        internal QueryAsyncResults() { }

        /// <summary>
        /// </summary>
        /// <param name="queryClient"></param>
        /// <param name="queryRequest"></param>
        /// <param name="storeType"></param>
        /// <param name="cancellationToken"></param>
        internal QueryAsyncResults(QueryRestClient queryClient, QueryRequest queryRequest, string storeType, CancellationToken cancellationToken)
        {
            _queryRequest = queryRequest;
            _storeType = storeType;
            _cancellationToken = cancellationToken;
            _queryClient = queryClient;
            _eventProperties = new HashSet<EventProperty>();
            _allPropertyValues = new Dictionary<string, List<object>>();
        }

        /// <summary>
        /// </summary>
        /// <returns>The search results.</returns>
        public AsyncPageable<TimeSeriesPoint> GetPageableResultsAsync()
        {
            async Task<Page<TimeSeriesPoint>> FirstPageFunc(int? pageSizeHint)
            {
                try
                {
                    Response<QueryResultPage> response = await _queryClient
                        .ExecuteAsync(_queryRequest, _storeType, null, null, _cancellationToken)
                        .ConfigureAwait(false);

                    TimeSeriesPoint[] points = createQueryResponse(response.Value);

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

                    TimeSeriesPoint[] points = createQueryResponse(response.Value);

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

        /// <summary>
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public object[] GetValues(string propertyName)
        {
            return _allPropertyValues[propertyName].ToArray();
        }

        private TimeSeriesPoint[] createQueryResponse(QueryResultPage value)
        {
            var result = new List<TimeSeriesPoint>();

            for (int i = 0; i < value.Timestamps.Count; i++)
            {
                DateTimeOffset timestamp = value.Timestamps[i];
                var point = new TimeSeriesPoint(timestamp);

                foreach (PropertyValues property in value.Properties)
                {
                    var eventProperty = new EventProperty(property.Name, property.Type);
                    point.Values[eventProperty] = property.Values[i];
                    _eventProperties.Add(eventProperty);
                }

                result.Add(point);
            }

            foreach (PropertyValues property in value.Properties)
            {
                if (_allPropertyValues.ContainsKey(property.Name))
                {
                    _allPropertyValues[property.Name].AddRange(property.Values);
                }
                else
                {
                    _allPropertyValues[property.Name] = new List<object>(property.Values);
                }
            }

            return result.ToArray();
        }
    }
}
