// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    public partial class WorkspacePrivateEndpointConnectionCollection
    {
        /// <summary> Approve or reject a private endpoint connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection associated with the Azure resource. </param>
        /// <param name="connection"> Object containing the updated connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<WorkspacePrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, DesktopVirtualizationPrivateEndpointConnection connection, CancellationToken cancellationToken = default)
        {
            var data = ToDataData(connection);
            return await CreateOrUpdateAsync(waitUntil, privateEndpointConnectionName, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Approve or reject a private endpoint connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection associated with the Azure resource. </param>
        /// <param name="connection"> Object containing the updated connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<WorkspacePrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, DesktopVirtualizationPrivateEndpointConnection connection, CancellationToken cancellationToken = default)
        {
            var data = ToDataData(connection);
            return CreateOrUpdate(waitUntil, privateEndpointConnectionName, data, cancellationToken);
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
