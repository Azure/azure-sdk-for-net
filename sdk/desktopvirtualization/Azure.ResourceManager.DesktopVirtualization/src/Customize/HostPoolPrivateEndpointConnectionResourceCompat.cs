// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    public partial class HostPoolPrivateEndpointConnectionResource
    {
        /// <summary> Approve or reject a private endpoint connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="connection"> Object containing the updated connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<HostPoolPrivateEndpointConnectionResource>> UpdateAsync(WaitUntil waitUntil, DesktopVirtualizationPrivateEndpointConnection connection, CancellationToken cancellationToken)
        {
            var data = ToDataData(connection);
            return await UpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Approve or reject a private endpoint connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="connection"> Object containing the updated connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<HostPoolPrivateEndpointConnectionResource> Update(WaitUntil waitUntil, DesktopVirtualizationPrivateEndpointConnection connection, CancellationToken cancellationToken)
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
