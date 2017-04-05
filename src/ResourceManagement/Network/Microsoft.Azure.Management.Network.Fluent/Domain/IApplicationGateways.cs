// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to application gateway management API in Azure.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IApplicationGateways  :
        ISupportsCreating<ApplicationGateway.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IHasManager<INetworkManager>,
        IHasInner<IApplicationGatewaysOperations>
    {
    }
}