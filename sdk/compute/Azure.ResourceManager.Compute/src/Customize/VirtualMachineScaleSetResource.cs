// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineScaleSetResource
    {
        /// <summary> Deallocates specific virtual machines in a VM scale set. Shuts down the virtual machines and releases the compute resources. You are not billed for the compute resources that this virtual machine scale set deallocates. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeallocateAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds, CancellationToken cancellationToken)
            => await DeallocateAsync(waitUntil, vmInstanceIds, null, cancellationToken).ConfigureAwait(false);

        /// <summary> Deallocates specific virtual machines in a VM scale set. Shuts down the virtual machines and releases the compute resources. You are not billed for the compute resources that this virtual machine scale set deallocates. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Deallocate(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds , CancellationToken cancellationToken)
            => Deallocate(waitUntil, vmInstanceIds, null, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetPatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, patch, null, null, cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetPatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, null, null, cancellationToken);
    }
}
