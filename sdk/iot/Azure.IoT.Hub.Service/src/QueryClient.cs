// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.IoT.Hub.Service.Models;

namespace Azure.IoT.Hub.Service
{
    /// <summary>
    /// Query client that can be used to query device and module twins.
    /// See <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-query-language#device-twin-queries">Device Twin query examples</see> and
    /// see <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-query-language#module-twin-queries">Module Twin query examples</see>.
    /// </summary>
    public class QueryClient
    {
        private const string ContinuationTokenHeader = "x-ms-continuation";

        private readonly QueryRestClient _queryRestClient;

        /// <summary>
        /// Initializes a new instance of QueryClient. This constructor should only be used for mocking purposes.
        /// </summary>
        protected QueryClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of QueryClient.
        /// <param name="queryRestClient"> The REST client to perform query operations. </param>
        /// </summary>
        internal QueryClient(QueryRestClient queryRestClient)
        {
            Argument.AssertNotNull(queryRestClient, nameof(queryRestClient));
            _queryRestClient = queryRestClient;
        }

        /// <summary>
        /// Query a set of device or module twins asynchronously.
        /// </summary>
        /// <param name="query">
        /// The query for device twins or module twins. See <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-query-language#device-twin-queries">Device Twin query examples</see>
        /// and see <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-query-language#module-twin-queries">Module Twin query examples</see>.
        /// </param>
        /// <param name="pageSize">The size of each page to be retrieved from the service. Service may override this size.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of device or module twins <see cref="AsyncPageable{T}"/>.</returns>
        public virtual AsyncPageable<TwinData> QueryAsync(string query, int? pageSize = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TwinData>> FirstPageFunc(int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification
                {
                    Query = query
                };
                Response<IReadOnlyList<TwinData>> response = await _queryRestClient.GetTwinsAsync(
                    querySpecification,
                    null,
                    pageSizeHint?.ToString(CultureInfo.InvariantCulture),
                    cancellationToken).ConfigureAwait(false);

                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);

                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            async Task<Page<TwinData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification()
                {
                    Query = query
                };
                Response<IReadOnlyList<TwinData>> response = await _queryRestClient.GetTwinsAsync(
                    querySpecification,
                    nextLink,
                    pageSizeHint?.ToString(CultureInfo.InvariantCulture),
                    cancellationToken).ConfigureAwait(false);

                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);
                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc, pageSize);
        }

        /// <summary>
        /// Query a set of device or module twins synchronously.
        /// </summary>
        /// <param name="query">
        /// The query for device twins or module twins. See <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-query-language#device-twin-queries">Device Twin query examples</see>
        /// and see <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-query-language#module-twin-queries">Module Twin query examples</see>.
        /// </param>
        /// <param name="pageSize">The size of each page to be retrieved from the service. Service may override this size.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of device or module twins <see cref="Pageable{T}"/>.</returns>
        public virtual Pageable<TwinData> Query(string query, int? pageSize = null, CancellationToken cancellationToken = default)
        {
            Page<TwinData> FirstPageFunc(int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification
                {
                    Query = query
                };

                Response<IReadOnlyList<TwinData>> response = _queryRestClient.GetTwins(
                    querySpecification,
                    null,
                    pageSizeHint?.ToString(CultureInfo.InvariantCulture),
                    cancellationToken);

                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);

                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            Page<TwinData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification()
                {
                    Query = query
                };
                Response<IReadOnlyList<TwinData>> response = _queryRestClient.GetTwins(
                    querySpecification,
                    nextLink,
                    pageSizeHint?.ToString(CultureInfo.InvariantCulture),
                    cancellationToken);

                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);
                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc, pageSize);
        }
    }
}
