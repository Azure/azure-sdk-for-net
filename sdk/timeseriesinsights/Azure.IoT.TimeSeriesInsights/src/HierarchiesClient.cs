// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Hierarchies client that can be used to perform operations such as creating, listing, replacing and deleting Time Series hierarchies.
    /// </summary>
    public class HierarchiesClient
    {
        private readonly TimeSeriesHierarchiesRestClient _hierarchiesRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of ModelSettings. This constructor should only be used for mocking purposes.
        /// </summary>
        protected HierarchiesClient()
        {
        }

        internal HierarchiesClient(TimeSeriesHierarchiesRestClient hierarchiesRestClient, ClientDiagnostics clientDiagnostics)
        {
            Argument.AssertNotNull(hierarchiesRestClient, nameof(hierarchiesRestClient));
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

            _hierarchiesRestClient = hierarchiesRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Gets Time Series Insights hierarchies in pages asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{TimeSeriesHierarchy}"/> of Time Series hierarchies with the http response.</returns>
        public virtual AsyncPageable<TimeSeriesHierarchy> GetHierarchiesAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetHierarchies)}");
            scope.Start();

            try
            {
                async Task<Page<TimeSeriesHierarchy>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetHierarchies)}");
                    scope.Start();

                    try
                    {
                        Response<GetHierarchiesPage> getHierarchiesResponse = await _hierarchiesRestClient
                            .ListAsync(null, null, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(getHierarchiesResponse.Value.Hierarchies, getHierarchiesResponse.Value.ContinuationToken, getHierarchiesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                async Task<Page<TimeSeriesHierarchy>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetHierarchies)}");
                    scope.Start();

                    try
                    {
                        Response<GetHierarchiesPage> getHierarchiesResponse = await _hierarchiesRestClient
                            .ListAsync(nextLink, null, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(getHierarchiesResponse.Value.Hierarchies, getHierarchiesResponse.Value.ContinuationToken, getHierarchiesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series Insights hierarchies in pages synchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{TimeSeriesHierarchy}"/> of Time Series hierarchies with the http response.</returns>
        /// <seealso cref="GetHierarchiesAsync(CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<TimeSeriesHierarchy> GetHierarchies(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetHierarchies)}");
            scope.Start();

            try
            {
                Page<TimeSeriesHierarchy> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetHierarchies)}");
                    scope.Start();

                    try
                    {
                        Response<GetHierarchiesPage> getHierarchiesResponse = _hierarchiesRestClient.List(null, null, cancellationToken);
                        return Page.FromValues(getHierarchiesResponse.Value.Hierarchies, getHierarchiesResponse.Value.ContinuationToken, getHierarchiesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                Page<TimeSeriesHierarchy> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetHierarchies)}");
                    scope.Start();

                    try
                    {
                        Response<GetHierarchiesPage> getHierarchiesResponse = _hierarchiesRestClient.List(nextLink, null, cancellationToken);
                        return Page.FromValues(getHierarchiesResponse.Value.Hierarchies, getHierarchiesResponse.Value.ContinuationToken, getHierarchiesResponse.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
