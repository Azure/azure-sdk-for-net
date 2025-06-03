// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class ElasticPoolResource
    {
        private readonly ElasticPoolActivitiesRestOperations _elasticPoolActivitiesRestClient;
        private readonly ClientDiagnostics _elasticPoolActivitiesClientDiagnostics;
        private readonly ElasticPoolDatabaseActivitiesRestOperations _elasticPoolDatabaseActivitiesRestClient;
        private readonly ClientDiagnostics _elasticPoolDatabaseActivitiesClientDiagnostics;
        private readonly MetricDefinitionsRestOperations _metricDefinitionsRestClient;
        private readonly ClientDiagnostics _metricDefinitionsClientDiagnostics;
        private readonly MetricsRestOperations _metricsRestClient;
        private readonly ClientDiagnostics _metricsClientDiagnostics;

        /// <summary> Initializes a new instance of the <see cref="ElasticPoolResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ElasticPoolResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _elasticPoolClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string elasticPoolApiVersion);
            _elasticPoolRestClient = new ElasticPoolsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, elasticPoolApiVersion);
            _sqlDatabaseDatabasesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", SqlDatabaseResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SqlDatabaseResource.ResourceType, out string sqlDatabaseDatabasesApiVersion);
            _sqlDatabaseDatabasesRestClient = new DatabasesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, sqlDatabaseDatabasesApiVersion);
            _elasticPoolOperationsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _elasticPoolOperationsRestClient = new ElasticPoolRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _elasticPoolActivitiesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _elasticPoolActivitiesRestClient = new ElasticPoolActivitiesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _elasticPoolDatabaseActivitiesRestClient = new ElasticPoolDatabaseActivitiesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _elasticPoolDatabaseActivitiesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _metricDefinitionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _metricDefinitionsRestClient = new MetricDefinitionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _metricsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _metricsRestClient = new MetricsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        /// <summary>
        /// Returns elastic pool activities.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/elasticPools/{elasticPoolName}/elasticPoolActivity</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ElasticPoolActivities_ListByElasticPool</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-08-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ElasticPoolActivity"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ElasticPoolActivity> GetElasticPoolActivitiesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _elasticPoolActivitiesRestClient.CreateListByElasticPoolRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => ElasticPoolActivity.DeserializeElasticPoolActivity(e), _elasticPoolActivitiesClientDiagnostics, Pipeline, "ElasticPoolResource.GetElasticPoolActivities", "value", null, cancellationToken);
        }

        /// <summary>
        /// Returns elastic pool activities.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/elasticPools/{elasticPoolName}/elasticPoolActivity</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ElasticPoolActivities_ListByElasticPool</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-08-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ElasticPoolActivity"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ElasticPoolActivity> GetElasticPoolActivities(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _elasticPoolActivitiesRestClient.CreateListByElasticPoolRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => ElasticPoolActivity.DeserializeElasticPoolActivity(e), _elasticPoolActivitiesClientDiagnostics, Pipeline, "ElasticPoolResource.GetElasticPoolActivities", "value", null, cancellationToken);
        }

        /// <summary>
        /// Returns activity on databases inside of an elastic pool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/elasticPools/{elasticPoolName}/elasticPoolDatabaseActivity</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ElasticPoolDatabaseActivities_ListByElasticPool</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-08-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ElasticPoolDatabaseActivity"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ElasticPoolDatabaseActivity> GetElasticPoolDatabaseActivitiesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _elasticPoolDatabaseActivitiesRestClient.CreateListByElasticPoolRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => ElasticPoolDatabaseActivity.DeserializeElasticPoolDatabaseActivity(e), _elasticPoolDatabaseActivitiesClientDiagnostics, Pipeline, "ElasticPoolResource.GetElasticPoolDatabaseActivities", "value", null, cancellationToken);
        }

        /// <summary>
        /// Returns activity on databases inside of an elastic pool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/elasticPools/{elasticPoolName}/elasticPoolDatabaseActivity</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ElasticPoolDatabaseActivities_ListByElasticPool</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-08-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ElasticPoolDatabaseActivity"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ElasticPoolDatabaseActivity> GetElasticPoolDatabaseActivities(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _elasticPoolDatabaseActivitiesRestClient.CreateListByElasticPoolRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => ElasticPoolDatabaseActivity.DeserializeElasticPoolDatabaseActivity(e), _elasticPoolDatabaseActivitiesClientDiagnostics, Pipeline, "ElasticPoolResource.GetElasticPoolDatabaseActivities", "value", null, cancellationToken);
        }

        /// <summary>
        /// Returns elastic pool metric definitions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/elasticPools/{elasticPoolName}/metricDefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MetricDefinitions_ListElasticPool</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-08-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlMetricDefinition"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlMetricDefinition> GetMetricDefinitionsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _metricDefinitionsRestClient.CreateListElasticPoolRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => SqlMetricDefinition.DeserializeSqlMetricDefinition(e), _metricDefinitionsClientDiagnostics, Pipeline, "ElasticPoolResource.GetMetricDefinitions", "value", null, cancellationToken);
        }

        /// <summary>
        /// Returns elastic pool metric definitions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/elasticPools/{elasticPoolName}/metricDefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MetricDefinitions_ListElasticPool</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-08-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlMetricDefinition"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlMetricDefinition> GetMetricDefinitions(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _metricDefinitionsRestClient.CreateListElasticPoolRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => SqlMetricDefinition.DeserializeSqlMetricDefinition(e), _metricDefinitionsClientDiagnostics, Pipeline, "ElasticPoolResource.GetMetricDefinitions", "value", null, cancellationToken);
        }

        /// <summary>
        /// Returns elastic pool  metrics.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/elasticPools/{elasticPoolName}/metrics</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Metrics_ListElasticPool</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-08-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> An OData filter expression that describes a subset of metrics to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> An async collection of <see cref="SqlMetric"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlMetric> GetMetricsAsync(string filter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(filter, nameof(filter));

            HttpMessage FirstPageRequest(int? pageSizeHint) => _metricsRestClient.CreateListElasticPoolRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => SqlMetric.DeserializeSqlMetric(e), _metricsClientDiagnostics, Pipeline, "ElasticPoolResource.GetMetrics", "value", null, cancellationToken);
        }

        /// <summary>
        /// Returns elastic pool  metrics.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/elasticPools/{elasticPoolName}/metrics</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Metrics_ListElasticPool</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-08-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> An OData filter expression that describes a subset of metrics to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> A collection of <see cref="SqlMetric"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlMetric> GetMetrics(string filter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(filter, nameof(filter));

            HttpMessage FirstPageRequest(int? pageSizeHint) => _metricsRestClient.CreateListElasticPoolRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => SqlMetric.DeserializeSqlMetric(e), _metricsClientDiagnostics, Pipeline, "ElasticPoolResource.GetMetrics", "value", null, cancellationToken);
        }
    }
}
