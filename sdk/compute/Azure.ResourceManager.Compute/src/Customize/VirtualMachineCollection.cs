// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: preserve old overloads where ifMatch/ifNoneMatch were positional string params.
    // New generated code uses MatchConditions instead, and GetAll no longer exposes statusOnly.
    public partial class VirtualMachineCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vmName, VirtualMachineData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, vmName, data, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineResource> CreateOrUpdate(WaitUntil waitUntil, string vmName, VirtualMachineData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, vmName, data, BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);

        // Backward-compat: preserve the (CT-only) overload that shipped before MatchConditions was added as an optional middle parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<VirtualMachineResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vmName, VirtualMachineData data, CancellationToken cancellationToken)
            => CreateOrUpdateAsync(waitUntil, vmName, data, matchConditions: null, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineResource> CreateOrUpdate(WaitUntil waitUntil, string vmName, VirtualMachineData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, vmName, data, matchConditions: null, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<VirtualMachineResource> GetAllAsync(string statusOnly, CancellationToken cancellationToken = default)
            => GetAllAsync(filter: null, expand: null, cancellationToken: cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<VirtualMachineResource> GetAll(string statusOnly, CancellationToken cancellationToken = default)
            => GetAll(filter: null, expand: null, cancellationToken: cancellationToken);

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
