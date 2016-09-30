// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.Network.NetworkSecurityGroup.Definition;
    /// <summary>
    /// Entry point to network security group management.
    /// </summary>
    public interface INetworkSecurityGroups  :
        ISupportsCreating<Microsoft.Azure.Management.Fluent.Network.NetworkSecurityGroup.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Fluent.Network.INetworkSecurityGroup>,
        ISupportsListingByGroup<Microsoft.Azure.Management.Fluent.Network.INetworkSecurityGroup>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Fluent.Network.INetworkSecurityGroup>,
        ISupportsGettingById<Microsoft.Azure.Management.Fluent.Network.INetworkSecurityGroup>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Fluent.Network.INetworkSecurityGroup>
    {
    }
}