// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: preserve old Update overloads where ifMatch/ifNoneMatch were positional string params.
    // New generated code uses MatchConditions instead.
    public partial class VirtualMachineResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachinePatch patch, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, patch, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineResource> Update(WaitUntil waitUntil, VirtualMachinePatch patch, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => Update(waitUntil, patch, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);

        // Backward-compat: preserve the (CT-only) overload that shipped before MatchConditions was added as an optional middle parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<VirtualMachineResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachinePatch patch, CancellationToken cancellationToken)
            => UpdateAsync(waitUntil, patch, matchConditions: null, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineResource> Update(WaitUntil waitUntil, VirtualMachinePatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, matchConditions: null, cancellationToken);

        // Backward-compat: preserve the (WaitUntil, hibernate, CT) Deallocate overloads that shipped before forceDeallocate was added as an optional middle parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> DeallocateAsync(WaitUntil waitUntil, bool? hibernate, CancellationToken cancellationToken)
            => DeallocateAsync(waitUntil, hibernate, forceDeallocate: null, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Deallocate(WaitUntil waitUntil, bool? hibernate, CancellationToken cancellationToken)
            => Deallocate(waitUntil, hibernate, forceDeallocate: null, cancellationToken);

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
