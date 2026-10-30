// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class IpamPoolCollection
    {
        // Preserve the 1.15.0 token-only overload; select the native ETag overload with no condition.
        /// <summary> Creates or updates the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<IpamPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string poolName, IpamPoolData data, CancellationToken cancellationToken)
            => CreateOrUpdateAsync(waitUntil, poolName, data, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the synchronous 1.15.0 token-only overload without adding an If-Match header.
        /// <summary> Creates or updates the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<IpamPoolResource> CreateOrUpdate(WaitUntil waitUntil, string poolName, IpamPoolData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, poolName, data, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the 1.15.0 string signature and exact header value; keep required arguments to avoid new native-overload ambiguity.
        /// <summary> Creates or updates the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<IpamPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string poolName, IpamPoolData data, string ifMatch, CancellationToken cancellationToken)
            => CreateOrUpdateAsync(waitUntil, poolName, data, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);

        // Preserve the synchronous 1.15.0 string signature; convert only the header type, not its contents.
        /// <summary> Creates or updates the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<IpamPoolResource> CreateOrUpdate(WaitUntil waitUntil, string poolName, IpamPoolData data, string ifMatch, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, poolName, data, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);
    }
}
