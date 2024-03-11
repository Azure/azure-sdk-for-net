// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// The <see cref="MetricsBatchQueryClient"/> allows you to query multiple Azure Monitor Metric services.
    /// </summary>
    public class MetricsBatchQueryClient
    {
        private readonly MetricsBatchRestClient _metricBatchClient;
        private readonly ClientDiagnostics _clientDiagnostics;

         /// <summary>
        /// Initializes a new instance of <see cref="MetricsBatchQueryClient"/>.
        /// </summary>
        /// <param name="endpoint">The data plane service endpoint to use. For example <c>https://metrics.monitor.azure.com/.default</c> for public cloud.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        /// <param name="options">The <see cref="MetricsQueryClientOptions"/> instance to as client configuration.</param>
        public MetricsBatchQueryClient(Uri endpoint, TokenCredential credential, MetricsBatchQueryClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsBatchQueryClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);

            var scope = "https://metrics.monitor.azure.com/.default";
            Endpoint = endpoint;

            var pipeline = HttpPipelineBuilder.Build(options,
                new BearerTokenAuthenticationPolicy(credential, scope));

            _metricBatchClient = new MetricsBatchRestClient(_clientDiagnostics, pipeline, endpoint);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsBatchQueryClient"/> for mocking.
        /// </summary>
        protected MetricsBatchQueryClient()
        {
        }

        /// <summary>
        /// Gets the endpoint used by the client.
        /// </summary>
        public Uri Endpoint { get; }

        /// <summary>
        /// Returns all the Azure Monitor metrics requested for the batch of resources.
        /// </summary>
        /// <param name="resourceIds">The resource URIs for which the metrics is requested.</param>
        /// <param name="metricNames">The names of the metrics to query.</param>
        /// <param name="metricNamespace">The namespace of the metrics to query.</param>
        /// <param name="options">The <see cref="MetricsBatchQueryClientOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A time-series metrics result for the requested metric names.</returns>
        public virtual Response<MetricsBatchResult> QueryBatch(List<string> resourceIds, List<string> metricNames, string metricNamespace, MetricsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            if (resourceIds.Count == 0 || metricNames.Count == 0)
            {
                throw new ArgumentException("Resource IDs or metricNames can not be empty");
            }
            if (metricNamespace == null)
            {
                throw new ArgumentNullException(nameof(metricNamespace));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsBatchQueryClient)}.{nameof(QueryBatch)}");
            scope.Start();

            try
            {
                return ExecuteBatchAsync(resourceIds, metricNames, metricNamespace, options, isAsync: false, cancellationToken).Result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private string GetSubscriptionId(string resourceId)
        {
            int startIndex = resourceId.IndexOf("subscriptions/") + 14;
            return resourceId.Substring(startIndex, resourceId.IndexOf("/", startIndex) - startIndex);
        }

        private async Task<Response<MetricsBatchResult>> ExecuteBatchAsync(List<string> resourceIds, List<string> metricNames, string metricNamespace, MetricsQueryOptions options = null, bool isAsync = default, CancellationToken cancellationToken = default)
        {
            var subscriptionId = GetSubscriptionId(resourceIds[0]);

            string filter = null;
            TimeSpan? granularity = null;
            string aggregations = null;
            string startTime = null;
            int? top = null;
            string orderBy = null;
            string endTime = null;
            ResourceIdList resourceIdList = new ResourceIdList(resourceIds);

            if (options != null)
            {
                startTime = options.TimeRange.Value.Start.ToString();
                endTime = options.TimeRange.Value.End.ToString();

                top = options.Size;
                orderBy = options.OrderBy;
                filter = options.Filter;
                granularity = options.Granularity;
            }

            if (!isAsync)
            {
                return _metricBatchClient.Batch(
                    subscriptionId,
                    metricNamespace,
                    metricNames,
                    resourceIdList,
                    startTime,
                    endTime,
                    granularity,
                    aggregations,
                    top,
                    orderBy,
                    filter,
                    cancellationToken);
            }

            else
            {
                return await _metricBatchClient.BatchAsync(
                    subscriptionId,
                    metricNamespace,
                    metricNames,
                    resourceIdList,
                    startTime,
                    endTime,
                    granularity,
                    aggregations,
                    top,
                    orderBy,
                    filter,
                    cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Returns all the Azure Monitor metrics requested for the batch of resources.
        /// </summary>
        /// <param name="resourceIds">The resource URIs for which the metrics is requested.</param>
        /// <param name="metricNames">The names of the metrics to query.</param>
        /// <param name="metricNamespace">The namespace of the metrics to query.</param>
        /// <param name="options">The <see cref="MetricsBatchQueryClientOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A time-series metrics result for the requested metric names.</returns>
        public virtual async Task<Response<MetricsBatchResult>> QueryBatchAsync(List<string> resourceIds, List<string> metricNames, string metricNamespace, MetricsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            if (resourceIds.Count == 0 || metricNames.Count == 0)
            {
                throw new ArgumentException("Resource IDs or metricNames can not be empty");
            }
            if (metricNamespace == null)
            {
                throw new ArgumentNullException(nameof(metricNamespace));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsBatchQueryClient)}.{nameof(QueryBatch)}");
            scope.Start();

            try
            {
                return await ExecuteBatchAsync(resourceIds, metricNames, metricNamespace, options, isAsync: true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
