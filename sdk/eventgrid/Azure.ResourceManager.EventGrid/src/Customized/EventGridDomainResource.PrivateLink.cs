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
    public partial class EventGridDomainResource
    {
        /// <summary> Gets the private link resources for this Event Grid domain. </summary>
        /// <returns> The requested resource. </returns>
        public virtual EventGridDomainPrivateLinkResourceCollection GetEventGridDomainPrivateLinkResources()
        {
            return GetCachedClient(client => new EventGridDomainPrivateLinkResourceCollection(client, Id));
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<EventGridDomainPrivateLinkResource>> GetEventGridDomainPrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return await GetEventGridDomainPrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        [ForwardsClientCalls]
        public virtual Response<EventGridDomainPrivateLinkResource> GetEventGridDomainPrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetEventGridDomainPrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }
    }
}
