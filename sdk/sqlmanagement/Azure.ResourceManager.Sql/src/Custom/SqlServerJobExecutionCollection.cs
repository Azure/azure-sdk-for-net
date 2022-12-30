// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="SqlServerJobExecutionResource" /> and their operations.
    /// Each <see cref="SqlServerJobExecutionResource" /> in the collection will belong to the same instance of <see cref="SqlServerJobResource" />.
    /// To get a <see cref="SqlServerJobExecutionCollection" /> instance call the GetSqlServerJobExecutions method from an instance of <see cref="SqlServerJobResource" />.
    /// </summary>
    public partial class SqlServerJobExecutionCollection : ArmCollection, IEnumerable<SqlServerJobExecutionResource>, IAsyncEnumerable<SqlServerJobExecutionResource>
    {
        /// <summary>
        /// Lists a job&apos;s executions.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions
        /// Operation Id: JobExecutions_ListByJob
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
        public virtual AsyncPageable<SqlServerJobExecutionResource> GetAllAsync(DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new SqlServerJobExecutionCollectionGetAllOptions
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
        /// Lists a job&apos;s executions.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions
        /// Operation Id: JobExecutions_ListByJob
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
        public virtual Pageable<SqlServerJobExecutionResource> GetAll(DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default) =>
            GetAll(new SqlServerJobExecutionCollectionGetAllOptions
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
        /// Lists target executions for all steps of a job execution.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/targets
        /// Operation Id: JobTargetExecutions_ListByJobExecution
        /// </summary>
        /// <param name="jobExecutionId"> The id of the job execution. </param>
        /// <param name="createTimeMin"> If specified, only job executions created at or after the specified time are included. </param>
        /// <param name="createTimeMax"> If specified, only job executions created before the specified time are included. </param>
        /// <param name="endTimeMin"> If specified, only job executions completed at or after the specified time are included. </param>
        /// <param name="endTimeMax"> If specified, only job executions completed before the specified time are included. </param>
        /// <param name="isActive"> If specified, only active or only completed job executions are included. </param>
        /// <param name="skip"> The number of elements in the collection to skip. </param>
        /// <param name="top"> The number of elements to return from the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlServerJobExecutionStepTargetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlServerJobExecutionStepTargetResource> GetJobTargetExecutionsAsync(Guid jobExecutionId, DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default) =>
            GetJobTargetExecutionsAsync(new SqlServerJobExecutionCollectionGetJobTargetExecutionsOptions(jobExecutionId)
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
        /// Lists target executions for all steps of a job execution.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/targets
        /// Operation Id: JobTargetExecutions_ListByJobExecution
        /// </summary>
        /// <param name="jobExecutionId"> The id of the job execution. </param>
        /// <param name="createTimeMin"> If specified, only job executions created at or after the specified time are included. </param>
        /// <param name="createTimeMax"> If specified, only job executions created before the specified time are included. </param>
        /// <param name="endTimeMin"> If specified, only job executions completed at or after the specified time are included. </param>
        /// <param name="endTimeMax"> If specified, only job executions completed before the specified time are included. </param>
        /// <param name="isActive"> If specified, only active or only completed job executions are included. </param>
        /// <param name="skip"> The number of elements in the collection to skip. </param>
        /// <param name="top"> The number of elements to return from the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlServerJobExecutionStepTargetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlServerJobExecutionStepTargetResource> GetJobTargetExecutions(Guid jobExecutionId, DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default) =>
            GetJobTargetExecutions(new SqlServerJobExecutionCollectionGetJobTargetExecutionsOptions(jobExecutionId)
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
