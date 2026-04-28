// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: preserve old CreateOrUpdate overloads without ifMatch/ifNoneMatch params.
    public partial class VirtualMachineScaleSetVmCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetVmResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string instanceId, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, instanceId, data, default, cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetVmResource> CreateOrUpdate(WaitUntil waitUntil, string instanceId, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, instanceId, data, default, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetVmResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string instanceId, VirtualMachineScaleSetVmData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, instanceId, data, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetVmResource> CreateOrUpdate(WaitUntil waitUntil, string instanceId, VirtualMachineScaleSetVmData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, instanceId, data, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);

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
