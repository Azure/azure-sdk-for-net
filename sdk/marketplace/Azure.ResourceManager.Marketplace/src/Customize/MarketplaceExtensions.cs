// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Marketplace
{
    public static partial class MarketplaceExtensions
    {
        /// <summary> Gets an approval request resource by identifier. </summary>
        /// <param name="client"> The client used to get the resource. </param>
        /// <param name="id"> The resource identifier. </param>
        /// <returns> The approval request resource. </returns>
        public static MarketplaceApprovalRequestResource GetMarketplaceApprovalRequestResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableMarketplaceArmClient(client).GetMarketplaceApprovalRequestResource(id);
        }

        /// <summary> Gets an admin approval request resource by identifier. </summary>
        /// <param name="client"> The client used to get the resource. </param>
        /// <param name="id"> The resource identifier. </param>
        /// <returns> The admin approval request resource. </returns>
        public static MarketplaceAdminApprovalRequestResource GetMarketplaceAdminApprovalRequestResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableMarketplaceArmClient(client).GetMarketplaceAdminApprovalRequestResource(id);
        }
    }
}
