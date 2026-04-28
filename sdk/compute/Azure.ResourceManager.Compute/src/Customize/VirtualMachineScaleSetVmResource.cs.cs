// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: preserve old Update/PowerOn overloads without MatchConditions params.
    public partial class VirtualMachineScaleSetVmResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetVmResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, data, default, cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetVmResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken)
            => Update(waitUntil, data, default, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetVmResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, data, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetVmResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => Update(waitUntil, data, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);

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
