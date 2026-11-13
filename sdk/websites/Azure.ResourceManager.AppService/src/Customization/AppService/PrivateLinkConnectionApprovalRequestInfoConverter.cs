// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.AppService.Models;

// ROOT CAUSE: GA 1.5.0 exposed CreateOrUpdate / Update overloads on the four
// PrivateEndpointConnection collections+resources (Hosting, Site, SiteSlot,
// StaticSite) that took `PrivateLinkConnectionApprovalRequestInfo`. The new
// TypeSpec emitter renames the body type to
// `RemotePrivateEndpointConnectionARMResourceData`. The GA model survives as
// a customization (see PrivateLinkConnectionApprovalRequestInfo.cs); these
// shims preserve the GA call-site shape by converting between the two models.
namespace Azure.ResourceManager.AppService
{
    internal static class PrivateLinkConnectionApprovalRequestInfoConverter
    {
        public static RemotePrivateEndpointConnectionARMResourceData ToResourceData(PrivateLinkConnectionApprovalRequestInfo info)
        {
            if (info == null)
            {
                return null;
            }
            return new RemotePrivateEndpointConnectionARMResourceData
            {
                Kind = info.Kind,
                PrivateLinkServiceConnectionState = info.PrivateLinkServiceConnectionState,
            };
        }
    }
}
