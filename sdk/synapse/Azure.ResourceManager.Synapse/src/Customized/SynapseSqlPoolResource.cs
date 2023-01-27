// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Synapse.Models;

namespace Azure.ResourceManager.Synapse
{
    /// <summary>
    /// A Class representing a SynapseSqlPool along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SynapseSqlPoolResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSynapseSqlPoolResource method.
    /// Otherwise you can get one from its parent resource <see cref="SynapseWorkspaceResource" /> using the GetSynapseSqlPool method.
    /// </summary>
    public partial class SynapseSqlPoolResource
    {
        /// <summary>
        /// Apply a partial update to a SQL pool
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}
        /// Operation Id: SqlPools_Update
        /// </summary>
        /// <param name="patch"> The updated SQL pool properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release, please use UpdateAsync(WaitUntil waitUntil, SynapseSqlPoolPatch patch, CancellationToken cancellationToken = default).", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<SynapseSqlPoolResource>> UpdateAsync(SynapseSqlPoolPatch patch, CancellationToken cancellationToken = default) =>
            await (await UpdateAsync(WaitUntil.Started, patch, cancellationToken).ConfigureAwait(false)).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Apply a partial update to a SQL pool
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}
        /// Operation Id: SqlPools_Update
        /// </summary>
        /// <param name="patch"> The updated SQL pool properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release, please use Update(WaitUntil waitUntil, SynapseSqlPoolPatch patch, CancellationToken cancellationToken = default).", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<SynapseSqlPoolResource> Update(SynapseSqlPoolPatch patch, CancellationToken cancellationToken = default) =>
            Update(WaitUntil.Started, patch, cancellationToken).WaitForCompletion(cancellationToken);
    }
}
