// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.ResourceManager.Marketplace
{
    [ModelReaderWriterBuildable(typeof(MarketplaceApprovalRequestData))]
    [ModelReaderWriterBuildable(typeof(MarketplaceApprovalRequestResource))]
    [ModelReaderWriterBuildable(typeof(MarketplaceAdminApprovalRequestData))]
    [ModelReaderWriterBuildable(typeof(MarketplaceAdminApprovalRequestResource))]
    public partial class AzureResourceManagerMarketplaceContext
    {
    }
}
