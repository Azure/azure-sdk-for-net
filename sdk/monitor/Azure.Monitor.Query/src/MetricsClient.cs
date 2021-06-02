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
    /// The <see cref="LogsClient"/> allows to query the Azure Monitor Metrics service.
    /// </summary>
    public class MetricsClient
    {
        private readonly MetricDefinitionsRestClient _metricDefinitionsClient;
        private readonly MetricsRestClient _metricsRestClient;
        private readonly MetricNamespacesRestClient _namespacesRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsClient"/>.
        /// </summary>
        /// <param name="endpoint">The service endpoint to use.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        public MetricsClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsClient"/>.
        /// </summary>
        /// <param name="endpoint">The service endpoint to use.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        /// <param name="options">The <see cref="MetricsClientOptions"/> instance to as client configuration.</param>
        public MetricsClient(Uri endpoint, TokenCredential credential, MetricsClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);

            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://management.azure.com//.default"));
            _metricDefinitionsClient = new MetricDefinitionsRestClient(_clientDiagnostics, pipeline, endpoint);
            _metricsRestClient = new MetricsRestClient(_clientDiagnostics, pipeline, endpoint);
            _namespacesRestClient = new MetricNamespacesRestClient(_clientDiagnostics, pipeline, endpoint);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetricsClient"/> for mocking.
        /// </summary>
        protected MetricsClient()
        {
        }

        /// <summary>
        /// Queries metrics for a resource.
        /// </summary>
        /// <param name="resourceId">The resource name.
        /// For example: <c>/subscriptions/[subscription_id]/resourceGroups/[resource_group_name]/providers/Microsoft.OperationalInsights/workspaces/[workspace_name]</c>.</param>
        /// <param name="metrics">The list of metrics to query.</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="MetricQueryResult"/> instance containing the query results.</returns>
        public virtual Response<MetricQueryResult> Query(string resourceId, IEnumerable<string> metrics, MetricsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return _metricsRestClient.List(resourceId,
                    timespan: options?.TimeSpan?.ToString(),
                    interval: options?.Interval,
                    filter: options?.Filter,
                    top: options?.Top,
                    aggregation: GetAggregation(options),
                    metricnames: string.Join(",", metrics),
                    orderby: options?.OrderBy,
                    metricnamespace: options?.MetricNamespace,
                    cancellationToken: cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Queries metrics for a resource.
        /// </summary>
        /// <param name="resourceId">The resource name.
        /// For example: <c>/subscriptions/[subscription_id]/resourceGroups/[resource_group_name]/providers/Microsoft.OperationalInsights/workspaces/[workspace_name]</c>.</param>
        /// <param name="metrics">The list of metrics to query.</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="MetricQueryResult"/> instance with query results.</returns>
        public virtual async Task<Response<MetricQueryResult>> QueryAsync(string resourceId, IEnumerable<string> metrics, MetricsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return await _metricsRestClient.ListAsync(resourceId,
                    timespan: options?.TimeSpan?.ToString(),
                    interval: options?.Interval,
                    filter: options?.Filter,
                    top: options?.Top,
                    aggregation: GetAggregation(options),
                    metricnames: string.Join(",", metrics),
                    orderby: options?.OrderBy,
                    metricnamespace: options?.MetricNamespace,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets metric definitions for a particular resource and metric namespace.
        /// </summary>
        /// <param name="resourceId">The resource name.
        /// For example: <c>/subscriptions/[subscription_id]/resourceGroups/[resource_group_name]/providers/Microsoft.OperationalInsights/workspaces/[workspace_name]</c>.</param>
        /// <param name="metricsNamespace">The metric namespace.
        /// For example: <c>Microsoft.OperationalInsights/workspaces</c>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A list of metric definitions.</returns>
        public virtual Response<IReadOnlyList<MetricDefinition>> GetMetrics(string resourceId, string metricsNamespace, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(GetMetrics)}");
            scope.Start();
            try
            {
                var response = _metricDefinitionsClient.List(resourceId, metricsNamespace, cancellationToken);

                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets metric definitions for a particular resource and metric namespace.
        /// </summary>
        /// <param name="resourceId">The resource name.
        /// For example: <c>/subscriptions/[subscription_id]/resourceGroups/[resource_group_name]/providers/Microsoft.OperationalInsights/workspaces/[workspace_name]</c>.</param>
        /// <param name="metricsNamespace">The metric namespace.
        /// For example: <c>Microsoft.OperationalInsights/workspaces</c>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A list of metric definitions.</returns>
        public virtual async Task<Response<IReadOnlyList<MetricDefinition>>> GetMetricsAsync(string resourceId, string metricsNamespace, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(GetMetrics)}");
            scope.Start();
            try
            {
                var response = await _metricDefinitionsClient.ListAsync(resourceId, metricsNamespace, cancellationToken).ConfigureAwait(false);

                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets metric namespaces for a particular resource.
        /// </summary>
        /// <param name="resourceId">The resource name.
        /// For example: <c>/subscriptions/[subscription_id]/resourceGroups/[resource_group_name]/providers/Microsoft.OperationalInsights/workspaces/[workspace_name]</c>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A list of metric namespaces.</returns>
        public virtual Response<IReadOnlyList<MetricNamespace>> GetMetricNamespaces(string resourceId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(GetMetricNamespaces)}");
            scope.Start();
            try
            {
                var response = _namespacesRestClient.List(resourceId, cancellationToken: cancellationToken);

                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets metric namespaces for a particular resource.
        /// </summary>
        /// <param name="resourceId">The resource name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A list of metric namespaces.</returns>
        public virtual async Task<Response<IReadOnlyList<MetricNamespace>>> GetMetricNamespacesAsync(string resourceId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsClient)}.{nameof(GetMetricNamespaces)}");
            scope.Start();
            try
            {
                var response = await _namespacesRestClient.ListAsync(resourceId, cancellationToken: cancellationToken).ConfigureAwait(false);

                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static string GetAggregation(MetricsQueryOptions options)
        {
            if (options?.Aggregations == null ||
                options.Aggregations.Count == 0)
            {
                return null;
            }
            return string.Join(",", options.Aggregations);
        }
    }
}