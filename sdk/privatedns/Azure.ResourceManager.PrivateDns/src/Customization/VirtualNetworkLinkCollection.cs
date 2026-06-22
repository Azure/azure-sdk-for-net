// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.PrivateDns
{
    public partial class VirtualNetworkLinkCollection
    {
        // Preserve the shipped overload that accepted raw ETag headers before MatchConditions became the generated pattern.
        /// <summary> Creates or updates a virtual network link to the specified Private DNS zone. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="virtualNetworkLinkName"> The name of the virtual network link. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The ETag of the virtual network link to the Private DNS zone. Omit this value to always overwrite the current virtual network link. Specify the last-seen ETag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new virtual network link to the Private DNS zone to be created, but to prevent updating an existing link. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualNetworkLinkResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string virtualNetworkLinkName, VirtualNetworkLinkData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, virtualNetworkLinkName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = new ETag(ifNoneMatch) }, cancellationToken).ConfigureAwait(false);

        // Preserve the shipped overload that accepted raw ETag headers before MatchConditions became the generated pattern.
        /// <summary> Creates or updates a virtual network link to the specified Private DNS zone. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="virtualNetworkLinkName"> The name of the virtual network link. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The ETag of the virtual network link to the Private DNS zone. Omit this value to always overwrite the current virtual network link. Specify the last-seen ETag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new virtual network link to the Private DNS zone to be created, but to prevent updating an existing link. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualNetworkLinkResource> CreateOrUpdate(WaitUntil waitUntil, string virtualNetworkLinkName, VirtualNetworkLinkData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, virtualNetworkLinkName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = new ETag(ifNoneMatch) }, cancellationToken);
    }
}
