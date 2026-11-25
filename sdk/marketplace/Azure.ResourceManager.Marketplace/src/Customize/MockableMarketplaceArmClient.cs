// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Marketplace.Mocking
{
    public partial class MockableMarketplaceArmClient
    {
        /// <summary> Gets an approval request resource by identifier. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <returns> The approval request resource. </returns>
        public virtual MarketplaceApprovalRequestResource GetMarketplaceApprovalRequestResource(ResourceIdentifier id)
        {
            MarketplaceApprovalRequestResource.ValidateResourceId(id);
            return new MarketplaceApprovalRequestResource(Client, id);
        }

        /// <summary> Gets an admin approval request resource by identifier. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <returns> The admin approval request resource. </returns>
        public virtual MarketplaceAdminApprovalRequestResource GetMarketplaceAdminApprovalRequestResource(ResourceIdentifier id)
        {
            MarketplaceAdminApprovalRequestResource.ValidateResourceId(id);
            return new MarketplaceAdminApprovalRequestResource(Client, id);
        }
    }
}
