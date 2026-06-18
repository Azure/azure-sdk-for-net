// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.EventGrid
{
    public partial class PartnerNamespaceResource
    {
        /// <summary> Gets a collection of PartnerNamespacePrivateLinkResources in the PartnerNamespace. </summary>
        /// <returns> An object representing collection of PartnerNamespacePrivateLinkResources and their operations over a PartnerNamespacePrivateLinkResource. </returns>
        public virtual PartnerNamespacePrivateLinkResourceCollection GetPartnerNamespacePrivateLinkResources()
        {
            return GetCachedClient(client => new PartnerNamespacePrivateLinkResourceCollection(client, Id));
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<PartnerNamespacePrivateLinkResource>> GetPartnerNamespacePrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return await GetPartnerNamespacePrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<PartnerNamespacePrivateLinkResource> GetPartnerNamespacePrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetPartnerNamespacePrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }
    }
}
