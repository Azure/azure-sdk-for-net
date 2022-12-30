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
        public virtual AsyncPageable<SyncGroupLogProperties> GetLogsAsync(string startTime, string endTime, SyncGroupLogType type, string continuationToken = null, CancellationToken cancellationToken = default) =>
            GetLogsAsync(new SyncGroupResourceGetLogsOptions(startTime, endTime, type)
            {
                ContinuationToken = continuationToken
            }, cancellationToken);

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
        public virtual Pageable<SyncGroupLogProperties> GetLogs(string startTime, string endTime, SyncGroupLogType type, string continuationToken = null, CancellationToken cancellationToken = default) =>
            GetLogs(new SyncGroupResourceGetLogsOptions(startTime, endTime, type)
            {
                ContinuationToken = continuationToken
            }, cancellationToken);
    }
}
