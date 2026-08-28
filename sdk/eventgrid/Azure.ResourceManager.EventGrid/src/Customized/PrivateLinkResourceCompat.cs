// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Internal helper: converts generated EventGridPrivateLinkResource model instances to the typed
// domain/topic/partner-namespace resource wrappers needed by the custom private-link collections.
// Used by EventGridDomainPrivateLinkResourceCollection, EventGridTopicPrivateLinkResourceCollection,
// and PartnerNamespacePrivateLinkResourceCollection.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.EventGrid
{
    internal static class PrivateLinkResourceCompat
    {
        internal static EventGridDomainPrivateLinkResource ToDomainResource(ArmClient client, global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource model)
            => new EventGridDomainPrivateLinkResource(client, EventGridPrivateLinkResourceData.FromGeneratedModel(model));

        internal static EventGridTopicPrivateLinkResource ToTopicResource(ArmClient client, global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource model)
            => new EventGridTopicPrivateLinkResource(client, EventGridPrivateLinkResourceData.FromGeneratedModel(model));

        internal static PartnerNamespacePrivateLinkResource ToPartnerNamespaceResource(ArmClient client, global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource model)
            => new PartnerNamespacePrivateLinkResource(client, EventGridPrivateLinkResourceData.FromGeneratedModel(model));

        internal static Response<T> Convert<T>(Response<global::Azure.ResourceManager.EventGrid.Models.EventGridPrivateLinkResource> response, T resource)
            => Response.FromValue(resource, response.GetRawResponse());
    }
}
