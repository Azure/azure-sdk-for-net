// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Entry point to application gateway management API in Azure.
    /// </summary>
    public interface IApplicationGateways  :
        ISupportsCreating<ApplicationGateway.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IHasManager<INetworkManager>
    {
    }
}