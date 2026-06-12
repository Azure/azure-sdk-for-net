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
    public partial class EventGridTopicResource
    {
        public virtual EventGridTopicPrivateLinkResourceCollection GetEventGridTopicPrivateLinkResources()
        {
            return GetCachedClient(client => new EventGridTopicPrivateLinkResourceCollection(client, Id));
        }

        [ForwardsClientCalls]
        public virtual async Task<Response<EventGridTopicPrivateLinkResource>> GetEventGridTopicPrivateLinkResourceAsync(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return await GetEventGridTopicPrivateLinkResources().GetAsync(privateLinkResourceName, cancellationToken).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        public virtual Response<EventGridTopicPrivateLinkResource> GetEventGridTopicPrivateLinkResource(string privateLinkResourceName, CancellationToken cancellationToken = default)
        {
            return GetEventGridTopicPrivateLinkResources().Get(privateLinkResourceName, cancellationToken);
        }
    }
}
