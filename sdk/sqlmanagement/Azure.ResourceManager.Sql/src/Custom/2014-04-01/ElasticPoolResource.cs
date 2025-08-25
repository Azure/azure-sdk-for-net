// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class ElasticPoolResource
    {
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
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ElasticPoolActivity"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ElasticPoolActivity> GetElasticPoolActivitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
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
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ElasticPoolActivity"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ElasticPoolActivity> GetElasticPoolActivities(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
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
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ElasticPoolDatabaseActivity"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ElasticPoolDatabaseActivity> GetElasticPoolDatabaseActivitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
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
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ElasticPoolDatabaseActivity"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ElasticPoolDatabaseActivity> GetElasticPoolDatabaseActivities(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
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
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlMetricDefinition"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlMetricDefinition> GetMetricDefinitionsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
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
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlMetricDefinition"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlMetricDefinition> GetMetricDefinitions(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
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
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> An OData filter expression that describes a subset of metrics to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> An async collection of <see cref="SqlMetric"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlMetric> GetMetricsAsync(string filter, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
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
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> An OData filter expression that describes a subset of metrics to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> A collection of <see cref="SqlMetric"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlMetric> GetMetrics(string filter, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }
    }
}
