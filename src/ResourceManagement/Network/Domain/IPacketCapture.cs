// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Client-side representation of Packet capture object, associated with Network Watcher.
    /// </summary>
    public interface IPacketCapture  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.PacketCaptureResultInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable
    {
        /// <summary>
        /// Gets the maximum size of the capture output.
        /// </summary>
        int TotalBytesPerSession { get; }

        /// <summary>
        /// Gets the target id value.
        /// </summary>
        string TargetId { get; }

        /// <summary>
        /// Stops a specified packet capture session.
        /// </summary>
        void Stop();

        /// <summary>
        /// Query the status of a running packet capture session asynchronously.
        /// </summary>
        /// <return>Packet capture status.</return>
        Task<Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus> GetStatusAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the maximum duration of the capture session in seconds.
        /// </summary>
        int TimeLimitInSeconds { get; }

        /// <summary>
        /// Stops a specified packet capture session asynchronously.
        /// </summary>
        /// <return>The handle to the REST call.</return>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the number of bytes captured per packet, the remaining bytes are truncated.
        /// </summary>
        int BytesToCapturePerPacket { get; }

        /// <summary>
        /// Gets the storageLocation value.
        /// </summary>
        Models.PacketCaptureStorageLocation StorageLocation { get; }

        /// <summary>
        /// Gets the filters value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.PacketCaptureFilter> Filters { get; }

        /// <summary>
        /// Gets the provisioning state of the packet capture session. Possible values
        /// include: 'Succeeded', 'Updating', 'Deleting', 'Failed'.
        /// </summary>
        /// <summary>
        /// Gets the provisioningState value.
        /// </summary>
        Models.ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Query the status of a running packet capture session.
        /// </summary>
        /// <return>Packet capture status.</return>
        Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus GetStatus();
    }
}