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
    public partial class EventGridDomainResource
    {
        public virtual EventGridDomainPrivateLinkResourceCollection GetEventGridDomainPrivateLinkResources()
        {
            return GetCachedClient(client => new EventGridDomainPrivateLinkResourceCollection(client, Id));
        }

        [ForwardsClientCalls]
        public virtual async Task<Response<EventGridDomainPrivateLinkResource>> GetEventGridDomainPrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return await GetEventGridDomainPrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        public virtual Response<EventGridDomainPrivateLinkResource> GetEventGridDomainPrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetEventGridDomainPrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }
    }
}
