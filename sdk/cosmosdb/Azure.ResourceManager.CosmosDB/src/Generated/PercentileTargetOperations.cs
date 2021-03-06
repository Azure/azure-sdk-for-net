// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.ResourceManager.CosmosDB
{
    /// <summary> The PercentileTarget service client. </summary>
    public partial class PercentileTargetOperations
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal PercentileTargetRestOperations RestClient { get; }

        /// <summary> Initializes a new instance of PercentileTargetOperations for mocking. </summary>
        protected PercentileTargetOperations()
        {
        }

        /// <summary> Initializes a new instance of PercentileTargetOperations. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="endpoint"> server parameter. </param>
        internal PercentileTargetOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null)
        {
            RestClient = new PercentileTargetRestOperations(clientDiagnostics, pipeline, subscriptionId, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Retrieves the metrics determined by the given filter for the given account target region. This url is only for PBS and Replication Latency data. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="targetRegion"> Target region to which data is written. Cosmos DB region, with spaces between words and each word capitalized. </param>
        /// <param name="filter"> An OData filter expression that describes a subset of metrics to return. The parameters that can be filtered are name.value (name of the metric, can have an or of multiple names), startTime, endTime, and timeGrain. The supported operator is eq. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="targetRegion"/>, or <paramref name="filter"/> is null. </exception>
        public virtual AsyncPageable<PercentileMetric> ListMetricsAsync(string resourceGroupName, string accountName, string targetRegion, string filter, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (targetRegion == null)
            {
                throw new ArgumentNullException(nameof(targetRegion));
            }
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            async Task<Page<PercentileMetric>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PercentileTargetOperations.ListMetrics");
                scope.Start();
                try
                {
                    var response = await RestClient.ListMetricsAsync(resourceGroupName, accountName, targetRegion, filter, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Retrieves the metrics determined by the given filter for the given account target region. This url is only for PBS and Replication Latency data. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="targetRegion"> Target region to which data is written. Cosmos DB region, with spaces between words and each word capitalized. </param>
        /// <param name="filter"> An OData filter expression that describes a subset of metrics to return. The parameters that can be filtered are name.value (name of the metric, can have an or of multiple names), startTime, endTime, and timeGrain. The supported operator is eq. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="targetRegion"/>, or <paramref name="filter"/> is null. </exception>
        public virtual Pageable<PercentileMetric> ListMetrics(string resourceGroupName, string accountName, string targetRegion, string filter, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (targetRegion == null)
            {
                throw new ArgumentNullException(nameof(targetRegion));
            }
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            Page<PercentileMetric> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PercentileTargetOperations.ListMetrics");
                scope.Start();
                try
                {
                    var response = RestClient.ListMetrics(resourceGroupName, accountName, targetRegion, filter, cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }
    }
}
