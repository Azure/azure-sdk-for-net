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
    /// The <see cref="MetricsQueryClient"/> allows you to query the Azure Monitor Metrics service for a single Azure resource.
    /// </summary>
    public class MetricsQueryClient
    {
        private static readonly Uri _defaultEndpoint = new Uri("https://management.azure.com");

        private readonly MetricDefinitionsRestClient _metricDefinitionsClient;
        private readonly MetricsRestClient _metricsRestClient;
        private readonly MetricNamespacesRestClient _namespacesRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Creates an instance of <see cref="MetricsQueryClient"/> for Azure Public Cloud usage. Uses the default 'https://management.azure.com' endpoint.
        /// To access an Azure sovereign cloud, use the following constructor overload:
        /// <see cref="MetricsQueryClient.MetricsQueryClient(TokenCredential, MetricsQueryClientOptions)"/>
        /// <code snippet="Snippet:CreateMetricsQueryClient" language="csharp">
        /// var client = new MetricsQueryClient(new DefaultAzureCredential());
        /// </code>
        /// </summary>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        public MetricsQueryClient(TokenCredential credential) : this(credential, null)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MetricsQueryClient"/> for Azure Public Cloud usage. Uses the default 'https://management.azure.com' endpoint, unless <see cref="MetricsQueryClientOptions.Audience"/> is set to an Azure sovereign cloud.
        /// </summary>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        /// <param name="options">The <see cref="MetricsQueryClientOptions"/> instance to use as client configuration.</param>
        public MetricsQueryClient(TokenCredential credential, MetricsQueryClientOptions options) : this(string.IsNullOrEmpty(options.Audience?.ToString()) ? _defaultEndpoint : new Uri(options.Audience.ToString()), credential, options)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MetricsQueryClient"/> for the Azure cloud represented by <paramref name="endpoint"/>.
        /// </summary>
        /// <param name="endpoint">The Azure Resource Manager service endpoint to use. Some examples include:
        /// <list type="bullet">
        ///     <item><c>https://management.usgovcloudapi.net</c> for Azure US Government Cloud</item>
        ///     <item><c>https://management.chinacloudapi.cn</c> for Azure China Cloud</item>
        /// </list>
        /// </param>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        /// <param name="options">The <see cref="MetricsQueryClientOptions"/> instance to use as client configuration.</param>
        public MetricsQueryClient(Uri endpoint, TokenCredential credential, MetricsQueryClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsQueryClientOptions();
            var authorizationScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? MetricsQueryAudience.AzurePublicCloud : options.Audience)}";
            authorizationScope += "//.default";
            var scopes = new List<string> { authorizationScope };

            _clientDiagnostics = new ClientDiagnostics(options);

            Endpoint = endpoint;

            var pipeline = HttpPipelineBuilder.Build(options,
                new BearerTokenAuthenticationPolicy(credential, scopes));

            _metricDefinitionsClient = new MetricDefinitionsRestClient(_clientDiagnostics, pipeline, endpoint);
            _metricsRestClient = new MetricsRestClient(_clientDiagnostics, pipeline, endpoint);
            _namespacesRestClient = new MetricNamespacesRestClient(_clientDiagnostics, pipeline, endpoint);
        }

        /// <summary>
        /// Creates an instance of <see cref="MetricsQueryClient"/> to support <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        protected MetricsQueryClient()
        {
        }

        /// <summary>
        /// Gets the endpoint used by the client.
        /// </summary>
        public Uri Endpoint { get; }

        /// <summary>
        /// Queries metrics for a resource.
        /// <code snippet="Snippet:QueryMetrics" language="csharp">
        /// string resourceId =
        ///     &quot;/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;&quot;;
        /// var client = new MetricsQueryClient(new DefaultAzureCredential());
        ///
        /// Response&lt;MetricsQueryResult&gt; results = await client.QueryResourceAsync(
        ///     resourceId,
        ///     new[] { &quot;Average_% Free Space&quot;, &quot;Average_% Used Space&quot; }
        /// );
        ///
        /// foreach (MetricResult metric in results.Value.Metrics)
        /// {
        ///     Console.WriteLine(metric.Name);
        ///     foreach (MetricTimeSeriesElement element in metric.TimeSeries)
        ///     {
        ///         Console.WriteLine(&quot;Dimensions: &quot; + string.Join(&quot;,&quot;, element.Metadata));
        ///
        ///         foreach (MetricValue value in element.Values)
        ///         {
        ///             Console.WriteLine(value);
        ///         }
        ///     }
        /// }
        /// </code>
        /// </summary>
        /// <param name="resourceId">The resource name.
        /// For example:
        /// <c>/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;</c>,<br/>
        /// <c>/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/resource-group/providers/Microsoft.Storage/storageAccounts/mystorage</c>,<br/>
        /// <c>/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/resource-group/providers/Microsoft.Compute/virtualMachines/myvm</c><br/>
        /// </param>
        /// <param name="metrics">The list of metrics to query.</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="MetricsQueryResult"/> instance containing the query results.</returns>
        public virtual Response<MetricsQueryResult> QueryResource(string resourceId, IEnumerable<string> metrics, MetricsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsQueryClient)}.{nameof(QueryResource)}");
            scope.Start();
            try
            {
                return _metricsRestClient.List(resourceId,
                    timespan: options?.TimeRange?.ToIsoString(),
                    interval: options?.Granularity,
                    filter: options?.Filter,
                    top: options?.Size,
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
        /// <code snippet="Snippet:QueryMetrics" language="csharp">
        /// string resourceId =
        ///     &quot;/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;&quot;;
        /// var client = new MetricsQueryClient(new DefaultAzureCredential());
        ///
        /// Response&lt;MetricsQueryResult&gt; results = await client.QueryResourceAsync(
        ///     resourceId,
        ///     new[] { &quot;Average_% Free Space&quot;, &quot;Average_% Used Space&quot; }
        /// );
        ///
        /// foreach (MetricResult metric in results.Value.Metrics)
        /// {
        ///     Console.WriteLine(metric.Name);
        ///     foreach (MetricTimeSeriesElement element in metric.TimeSeries)
        ///     {
        ///         Console.WriteLine(&quot;Dimensions: &quot; + string.Join(&quot;,&quot;, element.Metadata));
        ///
        ///         foreach (MetricValue value in element.Values)
        ///         {
        ///             Console.WriteLine(value);
        ///         }
        ///     }
        /// }
        /// </code>
        /// </summary>
        /// <param name="resourceId">The resource name.
        /// For example:
        /// <c>/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;</c>,<br/>
        /// <c>/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/resource-group/providers/Microsoft.Storage/storageAccounts/mystorage</c>,<br/>
        /// <c>/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/resource-group/providers/Microsoft.Compute/virtualMachines/myvm</c><br/>
        /// </param>
        /// <param name="metrics">The list of metrics to query.</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="MetricsQueryResult"/> instance with query results.</returns>
        public virtual async Task<Response<MetricsQueryResult>> QueryResourceAsync(string resourceId, IEnumerable<string> metrics, MetricsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsQueryClient)}.{nameof(QueryResource)}");
            scope.Start();
            try
            {
                return await _metricsRestClient.ListAsync(resourceId,
                    timespan: options?.TimeRange?.ToIsoString(),
                    interval: options?.Granularity,
                    filter: options?.Filter,
                    top: options?.Size,
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
        /// For example:
        /// <c>/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;</c>,<br/>
        /// <c>/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/resource-group/providers/Microsoft.Storage/storageAccounts/mystorage</c>,<br/>
        /// <c>/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/resource-group/providers/Microsoft.Compute/virtualMachines/myvm</c><br/>
        /// </param>
        /// <param name="metricsNamespace">The metric namespace.
        /// For example: <c>Microsoft.OperationalInsights/workspaces</c>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A pageable collection of metric definitions.</returns>
        public virtual Pageable<MetricDefinition> GetMetricDefinitions(string resourceId, string metricsNamespace, CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable(_ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsQueryClient)}.{nameof(GetMetricDefinitions)}");
                scope.Start();
                try
                {
                    var response = _metricDefinitionsClient.List(resourceId, metricsNamespace, cancellationToken);

                    return Page<MetricDefinition>.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            });
        }

        /// <summary>
        /// Gets metric definitions for a particular resource and metric namespace.
        /// </summary>
        /// <param name="resourceId">The resource name.
        ///
        /// For example:
        /// <c>/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;</c>,<br/>
        /// <c>/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/resource-group/providers/Microsoft.Storage/storageAccounts/mystorage</c>,<br/>
        /// <c>/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/resource-group/providers/Microsoft.Compute/virtualMachines/myvm</c><br/>
        /// </param>
        /// <param name="metricsNamespace">The metric namespace.
        /// For example: <c>Microsoft.OperationalInsights/workspaces</c>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A pageable collection of metric definitions.</returns>
        public virtual AsyncPageable<MetricDefinition> GetMetricDefinitionsAsync(string resourceId, string metricsNamespace, CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async _ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsQueryClient)}.{nameof(GetMetricDefinitions)}");
                scope.Start();
                try
                {
                    var response = await _metricDefinitionsClient.ListAsync(resourceId, metricsNamespace, cancellationToken).ConfigureAwait(false);

                    return Page<MetricDefinition>.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            });
        }

        /// <summary>
        /// Gets metric namespaces for a particular resource.
        /// </summary>
        /// <param name="resourceId">The resource name.
        /// For example:
        /// <c>/subscriptions/&lt;subscription_id&gt;/resourceGroups/&lt;resource_group_name&gt;/providers/&lt;resource_provider&gt;/&lt;resource&gt;</c>,<br/>
        /// <c>/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/resource-group/providers/Microsoft.Storage/storageAccounts/mystorage</c>,<br/>
        /// <c>/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/resource-group/providers/Microsoft.Compute/virtualMachines/myvm</c><br/>
        /// </param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A pageable collection of metric namespaces.</returns>
        public virtual Pageable<MetricNamespace> GetMetricNamespaces(string resourceId, CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable(_ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsQueryClient)}.{nameof(GetMetricNamespaces)}");
                scope.Start();
                try
                {
                    var response = _namespacesRestClient.List(resourceId, cancellationToken: cancellationToken);

                    return Page<MetricNamespace>.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            });
        }

        /// <summary>
        /// Gets metric namespaces for a particular resource.
        /// </summary>
        /// <param name="resourceId">The resource name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A pageable collection of metric namespaces.</returns>
        public virtual AsyncPageable<MetricNamespace> GetMetricNamespacesAsync(string resourceId, CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async _ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsQueryClient)}.{nameof(GetMetricNamespaces)}");
                scope.Start();
                try
                {
                    var response = await _namespacesRestClient.ListAsync(resourceId, cancellationToken: cancellationToken).ConfigureAwait(false);

                    return Page<MetricNamespace>.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            });
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
