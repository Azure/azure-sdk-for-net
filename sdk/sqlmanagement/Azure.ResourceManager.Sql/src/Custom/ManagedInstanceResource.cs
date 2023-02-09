// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.Sql.Models;
using System.Threading;

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
    }
}
