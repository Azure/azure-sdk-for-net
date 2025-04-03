// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.Sql.Models;
using System.Threading;
using Azure.Core;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedInstanceResource
    {
        /// <summary>
        /// Get top resource consuming queries of a managed instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/topqueries</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedInstances_ListByManagedInstance</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="numberOfQueries"> How many &apos;top queries&apos; to return. Default is 5. </param>
        /// <param name="databases"> Comma separated list of databases to be included into search. All DB&apos;s are included if this parameter is not specified. </param>
        /// <param name="startTime"> Start time for observed period. </param>
        /// <param name="endTime"> End time for observed period. </param>
        /// <param name="interval"> The time step to be used to summarize the metric values. Default value is PT1H. </param>
        /// <param name="aggregationFunction"> Aggregation function to be used, default value is &apos;sum&apos;. </param>
        /// <param name="observationMetric"> Metric to be used for ranking top queries. Default is &apos;cpu&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TopQueries" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TopQueries> GetTopQueriesAsync(int? numberOfQueries = null, string databases = null, string startTime = null, string endTime = null, QueryTimeGrainType? interval = null, AggregationFunctionType? aggregationFunction = null, SqlMetricType? observationMetric = null, CancellationToken cancellationToken = default)
        {
            ManagedInstanceResourceGetTopQueriesOptions options = new ManagedInstanceResourceGetTopQueriesOptions();
            options.NumberOfQueries = numberOfQueries;
            options.Databases = databases;
            options.StartTime = startTime;
            options.EndTime = endTime;
            options.Interval = interval;
            options.AggregationFunction = aggregationFunction;
            options.ObservationMetric = observationMetric;

            return GetTopQueriesAsync(options, cancellationToken);
        }

        /// <summary>
        /// Get top resource consuming queries of a managed instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/topqueries</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedInstances_ListByManagedInstance</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="numberOfQueries"> How many &apos;top queries&apos; to return. Default is 5. </param>
        /// <param name="databases"> Comma separated list of databases to be included into search. All DB&apos;s are included if this parameter is not specified. </param>
        /// <param name="startTime"> Start time for observed period. </param>
        /// <param name="endTime"> End time for observed period. </param>
        /// <param name="interval"> The time step to be used to summarize the metric values. Default value is PT1H. </param>
        /// <param name="aggregationFunction"> Aggregation function to be used, default value is &apos;sum&apos;. </param>
        /// <param name="observationMetric"> Metric to be used for ranking top queries. Default is &apos;cpu&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TopQueries" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TopQueries> GetTopQueries(int? numberOfQueries = null, string databases = null, string startTime = null, string endTime = null, QueryTimeGrainType? interval = null, AggregationFunctionType? aggregationFunction = null, SqlMetricType? observationMetric = null, CancellationToken cancellationToken = default)
        {
            ManagedInstanceResourceGetTopQueriesOptions options = new ManagedInstanceResourceGetTopQueriesOptions();
            options.NumberOfQueries = numberOfQueries;
            options.Databases = databases;
            options.StartTime = startTime;
            options.EndTime = endTime;
            options.Interval = interval;
            options.AggregationFunction = aggregationFunction;
            options.ObservationMetric = observationMetric;

            return GetTopQueries(options, cancellationToken);
        }

        /// <summary> Gets a collection of DistributedAvailabilityGroupResources in the ManagedInstance. </summary>
        /// <returns> An object representing collection of DistributedAvailabilityGroupResources and their operations over a DistributedAvailabilityGroupResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DistributedAvailabilityGroupCollection GetDistributedAvailabilityGroups()
        {
            return GetCachedClient(client => new DistributedAvailabilityGroupCollection(client, Id));
        }

        /// <summary>
        /// Gets a distributed availability group info.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups/{distributedAvailabilityGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributedAvailabilityGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="distributedAvailabilityGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DistributedAvailabilityGroupResource>> GetDistributedAvailabilityGroupAsync(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            return await GetDistributedAvailabilityGroups().GetAsync(distributedAvailabilityGroupName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a distributed availability group info.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups/{distributedAvailabilityGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributedAvailabilityGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="distributedAvailabilityGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DistributedAvailabilityGroupResource> GetDistributedAvailabilityGroup(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            return GetDistributedAvailabilityGroups().Get(distributedAvailabilityGroupName, cancellationToken);
        }
    }
}
