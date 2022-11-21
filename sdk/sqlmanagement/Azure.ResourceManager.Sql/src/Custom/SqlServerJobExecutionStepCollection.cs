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
    /// A class representing a collection of <see cref="SqlServerJobExecutionStepResource" /> and their operations.
    /// Each <see cref="SqlServerJobExecutionStepResource" /> in the collection will belong to the same instance of <see cref="SqlServerJobExecutionResource" />.
    /// To get a <see cref="SqlServerJobExecutionStepCollection" /> instance call the GetSqlServerJobExecutionSteps method from an instance of <see cref="SqlServerJobExecutionResource" />.
    /// </summary>
    public partial class SqlServerJobExecutionStepCollection : ArmCollection, IEnumerable<SqlServerJobExecutionStepResource>, IAsyncEnumerable<SqlServerJobExecutionStepResource>
    {
        /// <summary>
        /// Lists the step executions of a job execution.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/steps
        /// Operation Id: JobStepExecutions_ListByJobExecution
        /// </summary>
        /// <param name="createTimeMin"> If specified, only job executions created at or after the specified time are included. </param>
        /// <param name="createTimeMax"> If specified, only job executions created before the specified time are included. </param>
        /// <param name="endTimeMin"> If specified, only job executions completed at or after the specified time are included. </param>
        /// <param name="endTimeMax"> If specified, only job executions completed before the specified time are included. </param>
        /// <param name="isActive"> If specified, only active or only completed job executions are included. </param>
        /// <param name="skip"> The number of elements in the collection to skip. </param>
        /// <param name="top"> The number of elements to return from the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlServerJobExecutionStepResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlServerJobExecutionStepResource> GetAllAsync(DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SqlServerJobExecutionStepResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionStepJobStepExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionStepCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sqlServerJobExecutionStepJobStepExecutionsRestClient.ListByJobExecutionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Guid.Parse(Id.Name), createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionStepResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SqlServerJobExecutionStepResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionStepJobStepExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionStepCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sqlServerJobExecutionStepJobStepExecutionsRestClient.ListByJobExecutionNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Guid.Parse(Id.Name), createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionStepResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the step executions of a job execution.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/steps
        /// Operation Id: JobStepExecutions_ListByJobExecution
        /// </summary>
        /// <param name="createTimeMin"> If specified, only job executions created at or after the specified time are included. </param>
        /// <param name="createTimeMax"> If specified, only job executions created before the specified time are included. </param>
        /// <param name="endTimeMin"> If specified, only job executions completed at or after the specified time are included. </param>
        /// <param name="endTimeMax"> If specified, only job executions completed before the specified time are included. </param>
        /// <param name="isActive"> If specified, only active or only completed job executions are included. </param>
        /// <param name="skip"> The number of elements in the collection to skip. </param>
        /// <param name="top"> The number of elements to return from the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlServerJobExecutionStepResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlServerJobExecutionStepResource> GetAll(DateTimeOffset? createTimeMin = null, DateTimeOffset? createTimeMax = null, DateTimeOffset? endTimeMin = null, DateTimeOffset? endTimeMax = null, bool? isActive = null, int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<SqlServerJobExecutionStepResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionStepJobStepExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionStepCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sqlServerJobExecutionStepJobStepExecutionsRestClient.ListByJobExecution(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Guid.Parse(Id.Name), createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionStepResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SqlServerJobExecutionStepResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionStepJobStepExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionStepCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sqlServerJobExecutionStepJobStepExecutionsRestClient.ListByJobExecutionNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Guid.Parse(Id.Name), createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlServerJobExecutionStepResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
