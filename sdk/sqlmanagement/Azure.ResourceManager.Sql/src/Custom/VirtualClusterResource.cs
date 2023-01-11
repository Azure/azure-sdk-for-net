// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A Class representing a VirtualCluster along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="VirtualClusterResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetVirtualClusterResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetVirtualCluster method.
    /// </summary>
    public partial class VirtualClusterResource
    {
        /// <summary>
        /// Synchronizes the DNS server settings used by the managed instances inside the given virtual cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/virtualClusters/{virtualClusterName}/updateManagedInstanceDnsServers
        /// Operation Id: VirtualClusters_UpdateDnsServers
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<ManagedInstanceUpdateDnsServersOperationData>> UpdateDnsServersAsync(CancellationToken cancellationToken = default) =>
            await (await UpdateDnsServersAsync(WaitUntil.Started, cancellationToken).ConfigureAwait(false)).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        /// <summary>
        /// Synchronizes the DNS server settings used by the managed instances inside the given virtual cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/virtualClusters/{virtualClusterName}/updateManagedInstanceDnsServers
        /// Operation Id: VirtualClusters_UpdateDnsServers
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<ManagedInstanceUpdateDnsServersOperationData> UpdateDnsServers(CancellationToken cancellationToken = default) =>
            UpdateDnsServers(WaitUntil.Started, cancellationToken).WaitForCompletion(cancellationToken);
    }
}
