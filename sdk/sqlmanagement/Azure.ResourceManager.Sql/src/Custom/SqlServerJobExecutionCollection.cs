// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

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
        public virtual AsyncPageable<SqlServerJobExecutionResource> GetAllAsync(DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SqlServerJobExecutionResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionJobExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sqlServerJobExecutionJobExecutionsRestClient.ListByJobAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SqlServerJobExecutionResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionJobExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sqlServerJobExecutionJobExecutionsRestClient.ListByJobNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

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
        public virtual Pageable<SqlServerJobExecutionResource> GetAll(DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<SqlServerJobExecutionResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionJobExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sqlServerJobExecutionJobExecutionsRestClient.ListByJob(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SqlServerJobExecutionResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionJobExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sqlServerJobExecutionJobExecutionsRestClient.ListByJobNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

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
        public virtual AsyncPageable<SqlServerJobExecutionStepTargetResource> GetJobTargetExecutionsAsync(Guid jobExecutionId, DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SqlServerJobExecutionStepTargetResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionStepTargetJobTargetExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionCollection.GetJobTargetExecutions");
                scope.Start();
                try
                {
                    var response = await _sqlServerJobExecutionStepTargetJobTargetExecutionsRestClient.ListByJobExecutionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, jobExecutionId, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionStepTargetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SqlServerJobExecutionStepTargetResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionStepTargetJobTargetExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionCollection.GetJobTargetExecutions");
                scope.Start();
                try
                {
                    var response = await _sqlServerJobExecutionStepTargetJobTargetExecutionsRestClient.ListByJobExecutionNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, jobExecutionId, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionStepTargetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

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
        public virtual Pageable<SqlServerJobExecutionStepTargetResource> GetJobTargetExecutions(Guid jobExecutionId, DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<SqlServerJobExecutionStepTargetResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionStepTargetJobTargetExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionCollection.GetJobTargetExecutions");
                scope.Start();
                try
                {
                    var response = _sqlServerJobExecutionStepTargetJobTargetExecutionsRestClient.ListByJobExecution(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, jobExecutionId, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionStepTargetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SqlServerJobExecutionStepTargetResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionStepTargetJobTargetExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionCollection.GetJobTargetExecutions");
                scope.Start();
                try
                {
                    var response = _sqlServerJobExecutionStepTargetJobTargetExecutionsRestClient.ListByJobExecutionNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, jobExecutionId, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionStepTargetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
