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
    // New generated code uses MatchConditions instead of separate string params.
    public partial class VirtualMachineScaleSetCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vmScaleSetName, VirtualMachineScaleSetData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, vmScaleSetName, data, default, cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetResource> CreateOrUpdate(WaitUntil waitUntil, string vmScaleSetName, VirtualMachineScaleSetData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, vmScaleSetName, data, default, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vmScaleSetName, VirtualMachineScaleSetData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, vmScaleSetName, data, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetResource> CreateOrUpdate(WaitUntil waitUntil, string vmScaleSetName, VirtualMachineScaleSetData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, vmScaleSetName, data, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);

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
