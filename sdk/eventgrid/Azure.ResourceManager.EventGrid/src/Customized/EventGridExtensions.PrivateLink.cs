// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using System;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.EventGrid
{
    public static partial class EventGridExtensions
    {
        public static EventGridDomainPrivateLinkResource GetEventGridDomainPrivateLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetEventGridDomainPrivateLinkResource(id);
        }

        public static EventGridTopicPrivateLinkResource GetEventGridTopicPrivateLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetEventGridTopicPrivateLinkResource(id);
        }

        public static PartnerNamespacePrivateLinkResource GetPartnerNamespacePrivateLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableEventGridArmClient(client).GetPartnerNamespacePrivateLinkResource(id);
        }
    }
}
