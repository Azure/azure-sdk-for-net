// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: preserve old method overloads (Update, Deallocate, PowerOn, etc.)
    // that had fewer parameters before the TypeSpec migration added MatchConditions/hibernate.
    public partial class VirtualMachineScaleSetResource
    {
        /// <summary> Deallocates specific virtual machines in a VM scale set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeallocateAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds, CancellationToken cancellationToken)
            => await DeallocateAsync(waitUntil, vmInstanceIds, default, cancellationToken).ConfigureAwait(false);

        /// <summary> Deallocates specific virtual machines in a VM scale set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Deallocate(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds, CancellationToken cancellationToken)
            => Deallocate(waitUntil, vmInstanceIds, default, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetPatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, patch, default, cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetPatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, default, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetPatch patch, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, patch, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetPatch patch, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => Update(waitUntil, patch, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);

        private static MatchConditions BuildMatchConditions(string ifMatch, string ifNoneMatch)
        {
            if (ifMatch == null && ifNoneMatch == null)
            {
                return null;
            }
            return new MatchConditions
            {
                IfMatch = ifMatch != null ? new ETag(ifMatch) : default(ETag?),
                IfNoneMatch = ifNoneMatch != null ? new ETag(ifNoneMatch) : default(ETag?),
            };
        }
    }
}
