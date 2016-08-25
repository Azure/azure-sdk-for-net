/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition;
    /// <summary>
    /// Entry point to network security group management.
    /// </summary>
    public interface INetworkSecurityGroups  :
        ISupportsCreating<Microsoft.Azure.Management.V2.Network.NetworkSecurityGroup.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup>,
        ISupportsListingByGroup<Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup>,
        ISupportsGettingById<Microsoft.Azure.Management.V2.Network.INetworkSecurityGroup>,
        ISupportsDeleting,
        ISupportsDeletingByGroup
    {
    }
}