// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A Class representing a NetworkCloudBareMetalMachine along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="NetworkCloudBareMetalMachineResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetNetworkCloudBareMetalMachineResource method.
    /// Otherwise you can get one from its parent resource using the GetNetworkCloudBareMetalMachine method.
    /// </summary>
    public partial class NetworkCloudBareMetalMachineResource : ArmResource
    {
        /// <summary>
        /// Patch properties of the provided bare metal machine, or update tags associated with the bare metal machine. Properties and tag updates can be done independently.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NetworkCloudBareMetalMachineResource>> UpdateAsync(WaitUntil waitUntil, NetworkCloudBareMetalMachinePatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, patch, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Patch properties of the provided bare metal machine, or update tags associated with the bare metal machine. Properties and tag updates can be done independently.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="patch"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NetworkCloudBareMetalMachineResource> Update(WaitUntil waitUntil, NetworkCloudBareMetalMachinePatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, null, null, cancellationToken);
    }
}
