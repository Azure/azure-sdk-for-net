// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A Class representing a SyncGroup along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SyncGroupResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSyncGroupResource method.
    /// Otherwise you can get one from its parent resource <see cref="SqlDatabaseResource" /> using the GetSyncGroup method.
    /// </summary>
    public partial class SyncGroupResource : ArmResource
    {
        /// <summary>
        /// Gets a collection of sync group logs.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/logs
        /// Operation Id: SyncGroups_ListLogs
        /// </summary>
        /// <param name="startTime"> Get logs generated after this time. </param>
        /// <param name="endTime"> Get logs generated before this time. </param>
        /// <param name="type"> The types of logs to retrieve. </param>
        /// <param name="continuationToken"> The continuation token for this operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="startTime"/> or <paramref name="endTime"/> is null. </exception>
        /// <returns> An async collection of <see cref="SyncGroupLogProperties" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SyncGroupLogProperties> GetLogsAsync(string startTime, string endTime, SyncGroupLogType type, string continuationToken = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(startTime, nameof(startTime));
            Argument.AssertNotNull(endTime, nameof(endTime));

            async Task<Page<SyncGroupLogProperties>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _syncGroupClientDiagnostics.CreateScope("SyncGroupResource.GetLogs");
                scope.Start();
                try
                {
                    var response = await _syncGroupRestClient.ListLogsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, startTime, endTime, type, continuationToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SyncGroupLogProperties>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _syncGroupClientDiagnostics.CreateScope("SyncGroupResource.GetLogs");
                scope.Start();
                try
                {
                    var response = await _syncGroupRestClient.ListLogsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, startTime, endTime, type, continuationToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a collection of sync group logs.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/logs
        /// Operation Id: SyncGroups_ListLogs
        /// </summary>
        /// <param name="startTime"> Get logs generated after this time. </param>
        /// <param name="endTime"> Get logs generated before this time. </param>
        /// <param name="type"> The types of logs to retrieve. </param>
        /// <param name="continuationToken"> The continuation token for this operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="startTime"/> or <paramref name="endTime"/> is null. </exception>
        /// <returns> A collection of <see cref="SyncGroupLogProperties" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SyncGroupLogProperties> GetLogs(string startTime, string endTime, SyncGroupLogType type, string continuationToken = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(startTime, nameof(startTime));
            Argument.AssertNotNull(endTime, nameof(endTime));

            Page<SyncGroupLogProperties> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _syncGroupClientDiagnostics.CreateScope("SyncGroupResource.GetLogs");
                scope.Start();
                try
                {
                    var response = _syncGroupRestClient.ListLogs(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, startTime, endTime, type, continuationToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SyncGroupLogProperties> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _syncGroupClientDiagnostics.CreateScope("SyncGroupResource.GetLogs");
                scope.Start();
                try
                {
                    var response = _syncGroupRestClient.ListLogsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, startTime, endTime, type, continuationToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
