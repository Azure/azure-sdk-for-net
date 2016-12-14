// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using NetworkSecurityGroup.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to network security group management.
    /// </summary>
    public interface INetworkSecurityGroups  :
        ISupportsCreating<NetworkSecurityGroup.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.INetworkSecurityGroup>
    {
    }
}