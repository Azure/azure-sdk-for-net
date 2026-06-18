// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.EventGrid.Mocking
{
    public partial class MockableEventGridArmClient
    {
        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <returns> The requested resource. </returns>
        public virtual EventGridDomainPrivateLinkResource GetEventGridDomainPrivateLinkResource(ResourceIdentifier id)
        {
            EventGridDomainPrivateLinkResource.ValidateResourceId(id);
            return new EventGridDomainPrivateLinkResource(Client, id);
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <returns> The requested resource. </returns>
        public virtual EventGridTopicPrivateLinkResource GetEventGridTopicPrivateLinkResource(ResourceIdentifier id)
        {
            EventGridTopicPrivateLinkResource.ValidateResourceId(id);
            return new EventGridTopicPrivateLinkResource(Client, id);
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <returns> The requested resource. </returns>
        public virtual PartnerNamespacePrivateLinkResource GetPartnerNamespacePrivateLinkResource(ResourceIdentifier id)
        {
            PartnerNamespacePrivateLinkResource.ValidateResourceId(id);
            return new PartnerNamespacePrivateLinkResource(Client, id);
        }
    }
}
