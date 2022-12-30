// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A Class representing a SqlServerJobAgent along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SqlServerJobAgentResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSqlServerJobAgentResource method.
    /// Otherwise you can get one from its parent resource <see cref="SqlServerResource" /> using the GetSqlServerJobAgent method.
    /// </summary>
    public partial class SqlServerJobAgentResource : ArmResource
    {
        /// <summary>
        /// Lists all executions in a job agent.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/executions
        /// Operation Id: JobExecutions_ListByAgent
        /// </summary>
        /// <param name="createTimeMin"> If specified, only job executions created at or after the specified time are included. </param>
        /// <param name="createTimeMax"> If specified, only job executions created before the specified time are included. </param>
        /// <param name="endTimeMin"> If specified, only job executions completed at or after the specified time are included. </param>
        /// <param name="endTimeMax"> If specified, only job executions completed before the specified time are included. </param>
        /// <param name="isActive"> If specified, only active or only completed job executions are included. </param>
        /// <param name="skip"> The number of elements in the collection to skip. </param>
        /// <param name="top"> The number of elements to return from the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlServerJobExecutionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlServerJobExecutionResource> GetJobExecutionsByAgentAsync(DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default) =>
            GetJobExecutionsByAgentAsync(new SqlServerJobAgentResourceGetJobExecutionsByAgentOptions
            {
                CreateTimeMin = createTimeMin,
                CreateTimeMax = createTimeMax,
                EndTimeMin = endTimeMin,
                EndTimeMax = endTimeMax,
                IsActive = isActive,
                Skip = skip,
                Top = top
            }, cancellationToken);

        /// <summary>
        /// Lists all executions in a job agent.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/executions
        /// Operation Id: JobExecutions_ListByAgent
        /// </summary>
        /// <param name="createTimeMin"> If specified, only job executions created at or after the specified time are included. </param>
        /// <param name="createTimeMax"> If specified, only job executions created before the specified time are included. </param>
        /// <param name="endTimeMin"> If specified, only job executions completed at or after the specified time are included. </param>
        /// <param name="endTimeMax"> If specified, only job executions completed before the specified time are included. </param>
        /// <param name="isActive"> If specified, only active or only completed job executions are included. </param>
        /// <param name="skip"> The number of elements in the collection to skip. </param>
        /// <param name="top"> The number of elements to return from the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlServerJobExecutionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlServerJobExecutionResource> GetJobExecutionsByAgent(DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default) =>
            GetJobExecutionsByAgent(new SqlServerJobAgentResourceGetJobExecutionsByAgentOptions
            {
                CreateTimeMin = createTimeMin,
                CreateTimeMax = createTimeMax,
                EndTimeMin = endTimeMin,
                EndTimeMax = endTimeMax,
                IsActive = isActive,
                Skip = skip,
                Top = top
            }, cancellationToken);
    }
}
