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
    // GA-compat private-link surface: the generator emits one generic PrivateLinkResources group; main exposes
    // typed per-resource (Domain/Topic/PartnerNamespace) collections/resources. Rationale: PrivateLinkResourceCompat.cs.
    public partial class EventGridTopicResource
    {
        /// <summary> Gets the private link resources for this Event Grid topic. </summary>
        /// <returns> The requested resource. </returns>
        public virtual EventGridTopicPrivateLinkResourceCollection GetEventGridTopicPrivateLinkResources()
        {
            return GetCachedClient(client => new EventGridTopicPrivateLinkResourceCollection(client, Id));
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<EventGridTopicPrivateLinkResource>> GetEventGridTopicPrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return await GetEventGridTopicPrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="privateLinkResourceName"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The requested resource. </returns>
        [ForwardsClientCalls]
        public virtual Response<EventGridTopicPrivateLinkResource> GetEventGridTopicPrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetEventGridTopicPrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }
    }
}
