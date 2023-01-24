// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobExecutionStepTargetCollection
    {
        /// <summary>
        /// Lists the target executions of a job step execution.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/steps/{stepName}/targets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>JobTargetExecutions_ListByStep</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="createTimeMin"> If specified, only job executions created at or after the specified time are included. </param>
        /// <param name="createTimeMax"> If specified, only job executions created before the specified time are included. </param>
        /// <param name="endTimeMin"> If specified, only job executions completed at or after the specified time are included. </param>
        /// <param name="endTimeMax"> If specified, only job executions completed before the specified time are included. </param>
        /// <param name="isActive"> If specified, only active or only completed job executions are included. </param>
        /// <param name="skip"> The number of elements in the collection to skip. </param>
        /// <param name="top"> The number of elements to return from the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlServerJobExecutionStepTargetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlServerJobExecutionStepTargetResource> GetAllAsync(DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            SqlServerJobExecutionStepTargetCollectionGetAllOptions options = new SqlServerJobExecutionStepTargetCollectionGetAllOptions();
            options.CreateTimeMin = createTimeMin;
            options.CreateTimeMax = createTimeMax;
            options.EndTimeMin = endTimeMin;
            options.EndTimeMax = endTimeMax;
            options.IsActive = isActive;
            options.Skip = skip;
            options.Top = top;

            return GetAllAsync(options, cancellationToken);
        }

        /// <summary>
        /// Lists the target executions of a job step execution.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/steps/{stepName}/targets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>JobTargetExecutions_ListByStep</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="createTimeMin"> If specified, only job executions created at or after the specified time are included. </param>
        /// <param name="createTimeMax"> If specified, only job executions created before the specified time are included. </param>
        /// <param name="endTimeMin"> If specified, only job executions completed at or after the specified time are included. </param>
        /// <param name="endTimeMax"> If specified, only job executions completed before the specified time are included. </param>
        /// <param name="isActive"> If specified, only active or only completed job executions are included. </param>
        /// <param name="skip"> The number of elements in the collection to skip. </param>
        /// <param name="top"> The number of elements to return from the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlServerJobExecutionStepTargetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlServerJobExecutionStepTargetResource> GetAll(DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            SqlServerJobExecutionStepTargetCollectionGetAllOptions options = new SqlServerJobExecutionStepTargetCollectionGetAllOptions();
            options.CreateTimeMin = createTimeMin;
            options.CreateTimeMax = createTimeMax;
            options.EndTimeMin = endTimeMin;
            options.EndTimeMax = endTimeMax;
            options.IsActive = isActive;
            options.Skip = skip;
            options.Top = top;

            return GetAll(options, cancellationToken);
        }
    }
}
