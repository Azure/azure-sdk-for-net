// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class VirtualClusterResource
    {
        /// <summary> Backward-compatible synchronous wrapper that waits for completion. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ManagedInstanceUpdateDnsServersOperationData> UpdateDnsServers(CancellationToken cancellationToken = default)
        {
            ArmOperation<ManagedInstanceUpdateDnsServersOperationData> operation = UpdateDnsServers(WaitUntil.Completed, cancellationToken);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary> Backward-compatible asynchronous wrapper that waits for completion. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ManagedInstanceUpdateDnsServersOperationData>> UpdateDnsServersAsync(CancellationToken cancellationToken = default)
        {
            ArmOperation<ManagedInstanceUpdateDnsServersOperationData> operation = await UpdateDnsServersAsync(WaitUntil.Completed, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }
    }
}
