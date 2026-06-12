// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using Azure.Core;

namespace Azure.ResourceManager.EventGrid.Mocking
{
    public partial class MockableEventGridArmClient
    {
        public virtual EventGridDomainPrivateLinkResource GetEventGridDomainPrivateLinkResource(ResourceIdentifier id)
        {
            EventGridDomainPrivateLinkResource.ValidateResourceId(id);
            return new EventGridDomainPrivateLinkResource(Client, id);
        }

        public virtual EventGridTopicPrivateLinkResource GetEventGridTopicPrivateLinkResource(ResourceIdentifier id)
        {
            EventGridTopicPrivateLinkResource.ValidateResourceId(id);
            return new EventGridTopicPrivateLinkResource(Client, id);
        }

        public virtual PartnerNamespacePrivateLinkResource GetPartnerNamespacePrivateLinkResource(ResourceIdentifier id)
        {
            PartnerNamespacePrivateLinkResource.ValidateResourceId(id);
            return new PartnerNamespacePrivateLinkResource(Client, id);
        }
    }
}
