// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ConnectionMonitorCollection type. </summary>
    public partial class ConnectionMonitorCollection
    {
        /// <summary>
        /// Create or update a connection monitor.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if the method should return after starting the operation. </param>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="content"> Parameters that define the operation to create a connection monitor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An <see cref="ArmOperation{T}"/> that can be used to wait for completion and retrieve the created or updated resource. </returns>
        public virtual async Task<ArmOperation<ConnectionMonitorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string connectionMonitorName, ConnectionMonitorCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));
            return await CreateOrUpdateAsync(waitUntil, connectionMonitorName, new ConnectionMonitorContent(content, default), default, cancellationToken).ConfigureAwait(false);
        }
    }
}
