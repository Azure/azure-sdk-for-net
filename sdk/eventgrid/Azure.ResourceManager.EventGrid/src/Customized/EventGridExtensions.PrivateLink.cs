// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.EventGrid
{
    public static partial class EventGridExtensions
    {
        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="client"> The ARM client instance. </param>
        /// <param name="id"> The resource identifier. </param>
        /// <returns> The requested resource. </returns>
        public static EventGridDomainPrivateLinkResource GetEventGridDomainPrivateLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetEventGridDomainPrivateLinkResource(id);
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="client"> The ARM client instance. </param>
        /// <param name="id"> The resource identifier. </param>
        /// <returns> The requested resource. </returns>
        public static EventGridTopicPrivateLinkResource GetEventGridTopicPrivateLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetEventGridTopicPrivateLinkResource(id);
        }

        /// <summary> Gets a specific private link resource. </summary>
        /// <param name="client"> The ARM client instance. </param>
        /// <param name="id"> The resource identifier. </param>
        /// <returns> The requested resource. </returns>
        public static PartnerNamespacePrivateLinkResource GetPartnerNamespacePrivateLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetPartnerNamespacePrivateLinkResource(id);
        }
    }
}
