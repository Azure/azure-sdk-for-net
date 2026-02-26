// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: The Update method's parameter type changed from
// DesktopVirtualizationPrivateEndpointConnection to DesktopVirtualizationPrivateEndpointConnectionDataData.
// These overloads preserve the old signature by converting the old type to the new type,
// so existing callers are not broken.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    public partial class WorkspacePrivateEndpointConnectionResource
    {
        /// <summary> Approve or reject a private endpoint connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="connection"> Object containing the updated connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<WorkspacePrivateEndpointConnectionResource>> UpdateAsync(WaitUntil waitUntil, DesktopVirtualizationPrivateEndpointConnection connection, CancellationToken cancellationToken = default)
        {
            var data = ToDataData(connection);
            return await UpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Approve or reject a private endpoint connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="connection"> Object containing the updated connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<WorkspacePrivateEndpointConnectionResource> Update(WaitUntil waitUntil, DesktopVirtualizationPrivateEndpointConnection connection, CancellationToken cancellationToken = default)
        {
            var data = ToDataData(connection);
            return Update(waitUntil, data, cancellationToken);
        }

        private static DesktopVirtualizationPrivateEndpointConnectionDataData ToDataData(DesktopVirtualizationPrivateEndpointConnection connection)
        {
            if (connection == null)
                return null;
            var data = new DesktopVirtualizationPrivateEndpointConnectionDataData();
            data.ConnectionState = connection.ConnectionState;
            return data;
        }
    }
}
