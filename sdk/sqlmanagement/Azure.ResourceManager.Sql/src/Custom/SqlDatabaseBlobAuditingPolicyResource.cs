// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseBlobAuditingPolicyResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SqlDatabaseBlobAuditingPolicyResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscription id. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="serverName"> The server name. </param>
        /// <param name="databaseName"> The database name. </param>
        /// <param name="blobAuditingPolicyName"> The blob auditing policy name. Ignored; always treated as "default". </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, BlobAuditingPolicyName blobAuditingPolicyName)
        {
            _ = blobAuditingPolicyName;
            return CreateResourceIdentifier(subscriptionId, resourceGroupName, serverName, databaseName);
        }

        /// <summary> Updates a database's blob auditing policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> The blob auditing policy data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SqlDatabaseBlobAuditingPolicyResource> Update(WaitUntil waitUntil, SqlDatabaseBlobAuditingPolicyData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, data, cancellationToken);

        /// <summary> Updates a database's blob auditing policy. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> The blob auditing policy data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<SqlDatabaseBlobAuditingPolicyResource>> UpdateAsync(WaitUntil waitUntil, SqlDatabaseBlobAuditingPolicyData data, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
    }
}
