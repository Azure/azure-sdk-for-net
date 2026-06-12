// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.EventGrid
{
    public partial class PartnerNamespaceResource
    {
        public virtual PartnerNamespacePrivateLinkResourceCollection GetPartnerNamespacePrivateLinkResources()
        {
            return GetCachedClient(client => new PartnerNamespacePrivateLinkResourceCollection(client, Id));
        }

        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerNamespacePrivateLinkResource>> GetPartnerNamespacePrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return await GetPartnerNamespacePrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        public virtual Response<PartnerNamespacePrivateLinkResource> GetPartnerNamespacePrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetPartnerNamespacePrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }
    }
}
