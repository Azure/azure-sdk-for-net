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
    /// A class representing a collection of <see cref="SqlServerJobExecutionStepTargetResource" /> and their operations.
    /// Each <see cref="SqlServerJobExecutionStepTargetResource" /> in the collection will belong to the same instance of <see cref="SqlServerJobExecutionStepResource" />.
    /// To get a <see cref="SqlServerJobExecutionStepTargetCollection" /> instance call the GetSqlServerJobExecutionStepTargets method from an instance of <see cref="SqlServerJobExecutionStepResource" />.
    /// </summary>
    public partial class SqlServerJobExecutionStepTargetCollection : ArmCollection, IEnumerable<SqlServerJobExecutionStepTargetResource>, IAsyncEnumerable<SqlServerJobExecutionStepTargetResource>
    {
        /// <summary>
        /// Lists the target executions of a job step execution.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/steps/{stepName}/targets
        /// Operation Id: JobTargetExecutions_ListByStep
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
            async Task<Page<SqlServerJobExecutionStepTargetResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionStepTargetJobTargetExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionStepTargetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sqlServerJobExecutionStepTargetJobTargetExecutionsRestClient.ListByStepAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Guid.Parse(Id.Parent.Name), Id.Name, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _sqlServerJobExecutionStepTargetJobTargetExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionStepTargetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sqlServerJobExecutionStepTargetJobTargetExecutionsRestClient.ListByStepNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Guid.Parse(Id.Parent.Name), Id.Name, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Lists the target executions of a job step execution.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/steps/{stepName}/targets
        /// Operation Id: JobTargetExecutions_ListByStep
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
            Page<SqlServerJobExecutionStepTargetResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlServerJobExecutionStepTargetJobTargetExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionStepTargetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sqlServerJobExecutionStepTargetJobTargetExecutionsRestClient.ListByStep(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Guid.Parse(Id.Parent.Name), Id.Name, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken);
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
                using var scope = _sqlServerJobExecutionStepTargetJobTargetExecutionsClientDiagnostics.CreateScope("SqlServerJobExecutionStepTargetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sqlServerJobExecutionStepTargetJobTargetExecutionsRestClient.ListByStepNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Guid.Parse(Id.Parent.Name), Id.Name, createTimeMin, createTimeMax, endTimeMin, endTimeMax, isActive, skip, top, cancellationToken: cancellationToken);
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
