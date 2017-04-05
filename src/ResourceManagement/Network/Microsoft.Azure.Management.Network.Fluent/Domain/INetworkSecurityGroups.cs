// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to network security group management.
    /// </summary>
    public interface INetworkSecurityGroups  :
        ISupportsCreating<NetworkSecurityGroup.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        ISupportsBatchDeletion,
        IHasManager<Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        IHasInner<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroupsOperations>
    {
    }
}