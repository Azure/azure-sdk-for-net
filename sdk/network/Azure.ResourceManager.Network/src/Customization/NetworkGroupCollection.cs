// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkGroupCollection
    {
        // Preserve the 1.15.0 string condition while forwarding its exact value to the native ETag overload.
        /// <summary> Creates or updates a network group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<NetworkGroupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkGroupName, NetworkGroupData data, string ifMatch, CancellationToken cancellationToken)
            => CreateOrUpdateAsync(waitUntil, networkGroupName, data, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);

        // Preserve the synchronous 1.15.0 string signature without adding native-overload ambiguity.
        /// <summary> Creates or updates a network group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<NetworkGroupResource> CreateOrUpdate(WaitUntil waitUntil, string networkGroupName, NetworkGroupData data, string ifMatch, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, networkGroupName, data, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);
    }
}
